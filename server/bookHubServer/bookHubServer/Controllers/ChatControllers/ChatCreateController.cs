using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookHubServer.Model;
using bookHubServer.Tool;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bookHubServer.Controllers.ChatControllers
{
    [Route("api/chat/[controller]")]
    [ApiController]
    public class ChatCreateController : ControllerBase
    {
        public class chatData
        {
            public string cookieStr { get; set; }
            public int userBID { get; set; }
        }
        [HttpPost]
        public IActionResult CreateChat([FromBody] chatData chatData)
        {
            try
            {
                using (MySqlConnection connection = DataBaseTool.GetConnection())
                {
                    connection.Open();
                    Console.WriteLine("连接已打开");

                    TokenClaim userInfo = TokenTool.ParseToken(chatData.cookieStr);

                    string query = "SELECT COUNT(*) FROM ChatList WHERE userAID=@userAID AND userBID=@userBID";
                    MySqlCommand sql = new MySqlCommand(query, connection);
                    sql.Parameters.AddWithValue("@userAID", userInfo.userID);
                    sql.Parameters.AddWithValue("@userBID", chatData.userBID);
                    int count = Convert.ToInt32(sql.ExecuteScalar());
                    Console.WriteLine("查询记录有: " + count);

                    string query_2 = "SELECT COUNT(*) FROM ChatList WHERE userAID=@userAID2 AND userBID=@userBID2";
                    MySqlCommand sql_2 = new MySqlCommand(query, connection);
                    sql.Parameters.AddWithValue("@userBID2", userInfo.userID);
                    sql.Parameters.AddWithValue("@userAID2", chatData.userBID);
                    count = count + Convert.ToInt32(sql.ExecuteScalar());
                    Console.WriteLine("查询记录有: " + count);

                    if (count == 0)
                    {
                        ChatObject newChat = new ChatObject
                        {
                            chatID = ChatIDTool.getMaxChatID() + 1,
                            userAID = userInfo.userID,
                            userBID = chatData.userBID,
                            createTime = DateTime.Now,
                            lastUpdateTime = DateTime.Now
                        };

                        string insertQuery = "INSERT INTO ChatList (chatID, userAID, userBID, createTime, lastUpdateTime) " +
                                             "VALUES(@chatID, @userAID, @userBID, @createTime, @lastUpdateTime)";
                        MySqlCommand sql_insert = new MySqlCommand(insertQuery, connection);

                        sql_insert.Parameters.AddWithValue("@chatID", newChat.chatID);
                        sql_insert.Parameters.AddWithValue("@userAID", userInfo.userID);
                        sql_insert.Parameters.AddWithValue("@userBID", chatData.userBID);
                        sql_insert.Parameters.AddWithValue("@createTime", newChat.createTime);
                        sql_insert.Parameters.AddWithValue("@lastUpdateTime", newChat.lastUpdateTime);

                        Console.WriteLine("插入SQL创建");

                        int res = sql_insert.ExecuteNonQuery();
                        connection.Close();
                        return Ok("ChatObject insert success");
                    }
                    else
                    {
                        connection.Close();
                        return StatusCode(500, "ChatObject already exists");
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

