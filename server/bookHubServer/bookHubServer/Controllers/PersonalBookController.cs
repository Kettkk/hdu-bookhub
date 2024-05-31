using bookHubServer.Tool;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace bookHubServer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PersonalBookController : ControllerBase
{
    #region 我发布的商品数据显示
    class PublishedGood
    {
        public string publishedTime { get; set; }
        public string bookName { get; set; }
        public string bookImg { get; set; }
        public decimal price { get; set; }
    }

    [HttpPost("GetAllPublishedGoods")]
    public IActionResult GetAllPublishedGoods(int personalID)
    {
        try
        {
            MySqlConnection connection = DataBaseTool.GetConnection();

            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT * FROM Good WHERE sellerID = @personalID", connection);

            command.Parameters.AddWithValue("@personalID", personalID);

            MySqlDataReader reader = command.ExecuteReader();
            List<PublishedGood> publishedGoods = new List<PublishedGood>();

            while(reader.Read())
            {
                int nameLength = 0;

                PublishedGood publishedGood = new PublishedGood();

                publishedGood.publishedTime = reader.GetDateTime("createTime").ToString();

                string descriptionText = reader.GetString("description");

                for (int i = 0; i < descriptionText.Length; i++)
                {
                    if (descriptionText[i] == '：')
                    {
                        nameLength = i;
                        break;
                    }
                }

                publishedGood.bookName = descriptionText.Substring(0, nameLength);
                publishedGood.bookImg = reader.GetString("bookImg");
                publishedGood.price = reader.GetDecimal("price");

                publishedGoods.Add(publishedGood);
            }


            connection.Close();
            return Ok(publishedGoods);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error:{ex.Message}");
        }
    }
    #endregion


    #region 我卖出的商品数据显示
    class SoldGood
    {
        public string publishedTime { get; set; }
        public string acceptTime { get; set; }//买家收货时间
        public int orderID { get; set; }
        public string bookName { get; set; }
        public string bookImg { get; set; }
        public decimal price { get; set; }
        public string buyerName { get; set; }
    }

    [HttpPost("GetAllSoldGoods")]
    public IActionResult GetAllSoldGoods(int personalID)
    {
        try
        {
            MySqlConnection connection = DataBaseTool.GetConnection();

            connection.Open();

            MySqlCommand command = new MySqlCommand(
                "SELECT g.createTime,o.latestUpdateTime,o.orderID,g.description,g.bookImg,g.price,u.username FROM" +
                " `User` u,Good g,`Order` o WHERE o.sellerID = @personalID AND o.`status` = 1 AND o.goodID = g.goodID AND o.consumerID = u.userID ORDER BY o.latestUpdateTime DESC",
                connection
            );

            command.Parameters.AddWithValue("@personalID", personalID);

            MySqlDataReader reader = command.ExecuteReader();

            List<SoldGood> soldGoods = new List<SoldGood>();
            while(reader.Read())
            {
                int nameLength = 0;

                SoldGood soldGood = new SoldGood();
                soldGood.publishedTime = reader.GetDateTime("createTime").ToString();
                soldGood.acceptTime = reader.GetDateTime("latestUpdateTime").ToString();
                soldGood.orderID = reader.GetInt32("orderID");
                string descriptionText = reader.GetString("description");

                for (int i = 0; i < descriptionText.Length; i++)
                {
                    if (descriptionText[i] == '：')
                    {
                        nameLength = i;
                        break;
                    }
                }

                soldGood.bookName = descriptionText.Substring(0, nameLength);
                soldGood.bookImg = reader.GetString("bookImg");
                soldGood.price = reader.GetDecimal("price");
                soldGood.buyerName = reader.GetString("username");

                soldGoods.Add(soldGood);
            }

            connection.Close();
            return Ok(soldGoods);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error:{ex.Message}");
        }
    }
    #endregion


    #region 我买到的商品数据显示
    class PurchasedGood
    {
        public string purchasedTime { get; set; }
        public string acceptTime { get; set; }//收货时间
        public int orderID { get; set; }
        public string bookName { get; set; }
        public string bookImg { get; set; }
        public decimal price { get; set; }
        public string sellerName { get; set; }
    }

    [HttpPost("GetAllPurchasedGood")]
    public IActionResult GetAllPurchasedGood(int personalID)
    {
        try
        {
            MySqlConnection connection = DataBaseTool.GetConnection();

            connection.Open();

            MySqlCommand command = new MySqlCommand(
                "select o.createTime,o.latestUpdateTime,o.orderID,g.description,g.bookImg,g.price,u.username FROM " +
                "`User` u,Good g,`Order` o WHERE o.consumerID = @personalID AND o.`status` = 1 AND o.goodID = g.goodID AND o.sellerID = u.userID ORDER BY o.latestUpdateTime DESC",
                connection
            );

            command.Parameters.AddWithValue("@personalID", personalID);

            MySqlDataReader reader = command.ExecuteReader();
            List<PurchasedGood> purchasedGoods = new List<PurchasedGood>();
            while (reader.Read())
            {
                int nameLength = 0;

                PurchasedGood purchasedGood = new PurchasedGood();
                purchasedGood.purchasedTime = reader.GetDateTime("createTime").ToString();
                purchasedGood.acceptTime = reader.GetDateTime("latestUpdateTime").ToString();
                purchasedGood.orderID = reader.GetInt32("orderID");
                string descriptionText = reader.GetString("description");

                for (int i = 0; i < descriptionText.Length; i++)
                {
                    if (descriptionText[i] == '：')
                    {
                        nameLength = i;
                        break;
                    }
                }

                purchasedGood.bookName = descriptionText.Substring(0, nameLength);
                purchasedGood.bookImg = reader.GetString("bookImg");
                purchasedGood.price = reader.GetDecimal("price");
                purchasedGood.sellerName = reader.GetString("username");

                purchasedGoods.Add(purchasedGood);
            }

            connection.Close();
            return Ok(purchasedGoods);

        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error:{ex.Message}");
        }
    }
    #endregion
}
