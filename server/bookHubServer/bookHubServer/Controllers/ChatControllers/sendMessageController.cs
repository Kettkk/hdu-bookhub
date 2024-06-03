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
    public class getMessageData
    {
        public string jwt { get; set; }
        public string receiverName { get; set; }
        public string content { get; set; }
    }

    public class sentMessageInfo
    {
        public int chatID { get; set; }
        public int senderID { get; set; }
        public int receiverID { get; set; }
        public string content { get; set; }
        public DateTime sendTime { get; set; }
    }

    [Route("api/chat/[controller]")]
    public class sendMessageController : Controller
    {
        [HttpPost]
        public IActionResult sendMessage([FromBody]getMessageData data)
        {
            try
            {
                using (MySqlConnection connection = DataBaseTool.GetConnection())
                {
                    connection.Open();

                    int receiverID_tmp = UserIDTool.getUserIDByName(data.receiverName);
                    TokenClaim userInfo = TokenTool.ParseToken(data.jwt);

                    string sql = "insert into ChatMessage (chatID,senderID,receiverID,content,sendTime) values(@chatID,@senderID,@receiverID,@content,@sendTime)";
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@chatID", ChatIDTool.getMaxChatID());
                    cmd.Parameters.AddWithValue("@senderID", userInfo.userID);
                    cmd.Parameters.AddWithValue("@receiverID", receiverID_tmp);
                    cmd.Parameters.AddWithValue("@content", data.content);
                    cmd.Parameters.AddWithValue("@sendTime", DateTime.Now);

                    int res = cmd.ExecuteNonQuery();
                    if(res > 0)
                    {
                        return Ok("send success");
                    }
                    else
                    {
                        return Ok("haven not sent");
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

