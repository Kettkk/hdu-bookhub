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
    [ApiController]
    public class contactListMountedController : ControllerBase
    {
        public class contactMountedData
        {
            public string jwtStr { get; set; }
        }

        [HttpPost]
        public IActionResult CreateChat([FromBody] contactMountedData contactData)
        {
            try
            {
                using (MySqlConnection connection = DataBaseTool.GetConnection())
                {
                    connection.Open();
                    Console.WriteLine("连接已打开");

                    TokenClaim userInfo = TokenTool.ParseToken(contactData.jwtStr);

                    string query = "SELECT ChatList.chatID,ChatList.userAID,userA.username AS userAName,userA.avatarImg AS userAAvatar,ChatList.userBID,userB.username AS userBName,userB.avatarImg AS userBAvatar " +
                        "FROM ChatList " +
                        "JOIN `User` AS userA ON ChatList.userAID = userA.userID " +
                        "JOIN `User` AS userB ON ChatList.userBID = userB.userID " +
                        "WHERE ChatList.userAID = @userID OR ChatList.userBID = @userID";
                    MySqlCommand sql = new MySqlCommand(query, connection);
                    sql.Parameters.AddWithValue("@userID", userInfo.userID);

                    MySqlDataReader reader = sql.ExecuteReader();

                    List<ContactObject> contactObjects = new List<ContactObject>();


                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ContactObject contactObject = new ContactObject();
                            contactObject.chatID = (int)reader["chatID"];
                            contactObject.userAID = (int)reader["userAID"];
                            contactObject.userAName = (string)reader["userAName"];
                            contactObject.userAAvatar = (string)reader["userAAvatar"];
                            contactObject.otherID = (int)reader["userBID"];
                            contactObject.name = (string)reader["userBName"];
                            contactObject.url = (string)reader["userBAvatar"];

                            contactObjects.Add(contactObject);
                        }
                    }

                    connection.Close();
                    return Ok(contactObjects);

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

