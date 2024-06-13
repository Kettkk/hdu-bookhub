using bookHubServer.AdminModel;
using bookHubServer.AdminTools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace bookHubServer.AdminControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminOrderManagementController : ControllerBase
    {
        [HttpGet]
        public IActionResult getOrderManagement()
        {
            try
            {
                List<AdminOrderList> orderList = new List<AdminOrderList>();
                using (MySqlConnection connection = AdminDBTool.getDBC())
                {
                    connection.Open();
                    string query = @"
                        SELECT 
                            `Order`.orderID AS orderID, 
                            Seller.username AS sellerName, 
                            Consumer.username AS consumerName, 
                            Good.description AS bookName, 
                            Good.bookImg AS bookPicture, 
                            `Order`.status AS orderStatus, 
                            `Order`.createTime AS orderCreateTime, 
                            `Order`.latestUpdateTime AS orderLatestUpdateTime 
                        FROM `Order` 
                        JOIN `User` AS Seller ON `Order`.sellerID = Seller.userID 
                        JOIN `User` AS Consumer ON `Order`.consumerID = Consumer.userID 
                        JOIN `Good` ON `Order`.goodID = Good.goodID;";

                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string s = reader.GetString("bookName");
                            string bookName = "《";
                            for (int i = 0; i < s.Length; i++)
                            {
                                if (s[i] != '：')
                                {
                                    bookName += s[i];
                                }
                                else
                                {
                                    break;
                                }
                            }
                            bookName += "》";

                            string orderStatusString = "";
                            int orderStatusInt = reader.GetInt32("orderStatus");
                            if (orderStatusInt == 0)
                            {
                                orderStatusString = "未收货";
                            }
                            else
                            {
                                orderStatusString = "已成交";
                            }

                            AdminOrderList order = new AdminOrderList()
                            {
                                orderID = reader.GetInt32("orderID"),
                                sellerName = reader.GetString("sellerName"),
                                consumerName = reader.GetString("consumerName"),
                                bookName = bookName,
                                bookPicture = reader.GetString("bookPicture"),
                                orderStatus = orderStatusInt,
                                orderStatusString = orderStatusString,
                                orderCreateTime = reader.GetDateTime("orderCreateTime"),
                                orderLatestUpdateTime = reader.GetDateTime("orderLatestUpdateTime")
                            };
                            orderList.Add(order);
                        }
                    }
                }
                return Ok(orderList);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error retrieving order management data: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }
}
