using bookHubServer.AdminModel;
using bookHubServer.AdminTools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace bookHubServer.AdminControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminGoodManagementController : ControllerBase
    {
        [HttpGet]
        public IActionResult getOrderManagement()
        {
            try
            {
                List<AdminGoodList> goodList = new List<AdminGoodList>();
                using (MySqlConnection connection = AdminDBTool.getDBC())
                {
                    connection.Open();
                    string query = @"
                        SELECT 
                            Good.goodID AS goodID, 
                            `User`.username AS sellerName, 
                            Good.description AS bookName, 
                            Good.bookImg AS bookPicture, 
                            Good.price AS bookPrice,
                            Good.createTime AS goodCreateTime, 
                            Good.latestUpdateTime AS goodLatestUpdateTime 
                        FROM Good 
                        JOIN `User` ON Good.sellerID = User.userID";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AdminGoodList good = new AdminGoodList()
                            {
                                goodID = reader.GetInt32("goodID"),
                                sellerName = reader.GetString("sellerName"),
                                bookName = reader.GetString("bookName"),
                                bookPicture = reader.GetString("bookPicture"),
                                bookPrice = reader.GetInt32("bookPrice"),
                                goodCreateTime = reader.GetDateTime("goodCreateTime"),
                                goodLatestUpdateTime = reader.GetDateTime("goodLatestUpdateTime")
                            };
                            goodList.Add(good);
                        }
                    }
                }
                return Ok(goodList);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error retrieving order management data: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }
}
