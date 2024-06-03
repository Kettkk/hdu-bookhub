using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookHubServer.Model;
using bookHubServer.Tool;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace bookHubServer.Controllers.ChatControllers
{
    [Route("api/chat/[controller]")]
    public class contactListDelController : Controller
    {
        public class contactDelData
        {
            public string jwtStr { get; set; }
            public int otherID { get; set; }
        }

        [HttpPost]
        public IActionResult deleteChat([FromBody] contactDelData data)
        {
            try
            {
                using (MySqlConnection connection = DataBaseTool.GetConnection())
                {
                    connection.Open();
                    TokenClaim tokenClaim = TokenTool.ParseToken(data.jwtStr);

                    string sql = "DELETE FROM ChatList WHERE (userAID = @userAID AND userBID = @userBID) OR (userAID = @userBID AND userBID = @userAID)";
                    MySqlCommand command = new MySqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@userAID", tokenClaim.userID);
                    command.Parameters.AddWithValue("@userBID", data.otherID);

                    int res = command.ExecuteNonQuery();

                    if (res > 0)
                    {
                        return Ok("delete success");
                    }
                    else
                    {
                        return Ok("no matching record found");
                    }
                }
            }
            catch (MySqlException mysqlEx)
            {
                Console.WriteLine($"MySQL Error: {mysqlEx.Message}");
                return StatusCode(500, $"MySQL Error: {mysqlEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }
}
