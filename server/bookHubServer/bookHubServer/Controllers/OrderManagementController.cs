using bookHubServer.Model;
using bookHubServer.Tool;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace bookHubServer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderManagementController : ControllerBase
{   
    class Order
    {
        public int orderID { get; set; }
        public string goodName { get; set; }
        public string sellerName{ get; set; }
        public string purchaseTime { get; set; }
        public string bookImg { get; set; }
        public decimal price { get; set; }
    }


    [HttpPost("GetAllOrders")]
    public IActionResult GetAllOrders(int personalID)
    {
        try
        {

            MySqlConnection connection = DataBaseTool.GetConnection();

            connection.Open();

            MySqlCommand command = new MySqlCommand(
                "SELECT `Order`.*,`User`.username,Good.description,Good.bookImg,Good.price FROM `Order`,`User`,Good WHERE `Order`.sellerID = `User`.userID AND `Order`.goodID = Good.goodID AND `Order`.consumerID = @consumerID AND `Order`.`status` = 0 ORDER BY `Order`.createTime DESC",
                connection
            );
            command.Parameters.AddWithValue("@consumerID", personalID);

            MySqlDataReader reader = command.ExecuteReader();

            List<Order> orders = new List<Order>();

            while(reader.Read())
            {
                int nameLength = 0;

                Order order = new Order();

                order.orderID = reader.GetInt32("orderID");
                string descriptionText = reader.GetString("description");//获取商品描述，以便获取书名
                order.sellerName = reader.GetString("username");
                order.purchaseTime = reader.GetDateTime("createTime").ToString();
                order.bookImg = reader.GetString("bookImg");
                order.price = reader.GetDecimal("price");

                for (int i = 0; i < descriptionText.Length; i++)
                {
                    if (descriptionText[i] == '：')
                    {
                        nameLength = i;
                        break;
                    }
                }

                order.goodName = descriptionText.Substring(0, nameLength);

                orders.Add(order);
            }

            connection.Close();
            return Ok(orders);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error:{ex.Message}");
        }
    }


    public class AcceptGoodData
    {
        public int orderID { get; set; }
        public float star { get; set; }
    }

    [HttpPost("AcceptAndRate")]
    public IActionResult AcceptGood(AcceptGoodData acceptGoodData)
    {
        try
        {
            MySqlConnection connection = DataBaseTool.GetConnection();

            connection.Open();

            int res;

            //更新Order表中的订单状态和修改时间
            MySqlCommand command_updatestatus = new MySqlCommand("UPDATE `Order` SET `status` = 1,latestUpdateTime = @time WHERE orderID = @orderID", connection);
            command_updatestatus.Parameters.AddWithValue("@orderID", acceptGoodData.orderID);
            command_updatestatus.Parameters.AddWithValue("@time", DateTime.Now);
            res = command_updatestatus.ExecuteNonQuery();

            //获取卖家修改前的评分
            float oldStar = 0;
            MySqlCommand command_getselleroldstar = new MySqlCommand("SELECT star FROM `User`,`Order` WHERE `User`.userID = `Order`.sellerID AND `Order`.orderID = @orderID", connection);
            command_getselleroldstar.Parameters.AddWithValue("@orderID", acceptGoodData.orderID);
            using(MySqlDataReader reader = command_getselleroldstar.ExecuteReader())
            {
                if(reader.Read())
                {
                    oldStar = reader.GetFloat("star");
                }
            }

            //更新卖家评分
            MySqlCommand command_updatesellerstar = new MySqlCommand("UPDATE `User` SET star = @sum /2 WHERE `User`.userID = (SELECT sellerID FROM `Order` WHERE `Order`.orderID = @orderID)", connection);
            command_updatesellerstar.Parameters.AddWithValue("@sum", oldStar + acceptGoodData.star);
            command_updatesellerstar.Parameters.AddWithValue("@orderID", acceptGoodData.orderID);
            res = command_updatesellerstar.ExecuteNonQuery();

            //更新卖家的余额
            MySqlCommand command_transfer = new MySqlCommand(
                "UPDATE `User` SET money = money + " +
                "(SELECT price FROM Good WHERE goodID = ( SELECT goodID FROM `Order` WHERE orderID = @orderID ))" +
                " WHERE userID = (SELECT sellerID FROM `Order` WHERE orderID = @orderID)",
                connection
            );

            command_transfer.Parameters.AddWithValue("@orderID", acceptGoodData.orderID);
            res = command_transfer.ExecuteNonQuery();

            connection.Close();
            return Ok("successful");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error:{ex.Message}");
        }

    }

}
