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
    public class MsgListMountedData
    {
        public string jwtStr { get; set; }
        public string otherName { get; set; }
    }


    [Route("api/chat/[controller]")]
    public class MessageListMountedController : Controller
    {
        [HttpPost]
        public IActionResult ChatListMounted([FromBody] MsgListMountedData data)
        {
            try
            {
                using(MySqlConnection connection = DataBaseTool.GetConnection())
                {
                    connection.Open();

                    TokenClaim userInfo = TokenTool.ParseToken(data.jwtStr);

                    int otherID = UserIDTool.getUserIDByName(data.otherName);

                    string sql = "SELECT * FROM ChatMessage WHERE (senderID = @userID AND receiverID = @otherID) OR (senderID = @otherID AND receiverID = @userID) ORDER BY sendTime ASC;";
                    MySqlCommand command = new MySqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@userID", userInfo.userID);
                    command.Parameters.AddWithValue("@otherID", otherID);
                    MySqlDataReader reader = command.ExecuteReader();

                    List<MessageObject> messages = new List<MessageObject>();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            MessageObject messageObject = new MessageObject();
                            int senderID_tmp = (int)reader["senderID"];
                            int receiverID_tmp = (int)reader["receiverID"];

                            if (senderID_tmp == userInfo.userID)
                                messageObject.role = "user";
                            else
                                messageObject.role = "other";

                            messageObject.content = (string)reader["content"];

                            messages.Add(messageObject);
                        }
                    }

                    connection.Close();
                    return Ok(messages);
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

