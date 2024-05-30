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
    }


    [HttpPost("GetAllOrders")]
    public IActionResult GetAllOrders(int personalID)
    {
        try
        {

            MySqlConnection connection = DataBaseTool.GetConnection();

            connection.Open();

            MySqlCommand command = new MySqlCommand(
                "SELECT `Order`.*,`User`.username,Good.description FROM `Order`,`User`,Good WHERE `Order`.sellerID = `User`.userID AND `Order`.goodID = Good.goodID AND `Order`.consumerID = @consumerID AND `Order`.`status` = 0 ORDER BY `Order`.createTime DESC",
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



}
