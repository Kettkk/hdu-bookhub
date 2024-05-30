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
            public int userAID { get; set; }
            public int userBID { get; set; }
        }

        [HttpPost]
        public IActionResult CreateChat([FromBody]chatData chatData)
        {
            try
            {
                MySqlConnection connection = DataBaseTool.GetConnection();
                connection.Open();

                Console.WriteLine("连接已打开");
                MySqlCommand sql = new MySqlCommand("select COUNT(*) from ChatList where userAID=@userAID and userBID=@userBID",connection);
                sql.Parameters.AddWithValue("@userAID", chatData.userAID);
                sql.Parameters.AddWithValue("@userBID", chatData.userBID);

                object result = sql.ExecuteScalar();
                int count = result != null ? Convert.ToInt32(result) : 0;
                Console.WriteLine("查询记录有:" + count);

                if (count == 0)
                {
                    ChatObject newChat = new ChatObject();
                    newChat.chatID = ChatIDTool.getMaxChatID() + 1;
                    newChat.userAID = chatData.userAID;
                    newChat.userBID = chatData.userBID;
                    newChat.createTime = DateTime.Now;
                    newChat.lastUpdateTime = DateTime.Now;

                    MySqlCommand sql_insert = new MySqlCommand("insert into ChatList " +
                        "(chatID, userAID, userBID, createTime, lastUpdateTime) " +
                        "values(@chatID, @userAID, @userBID, @createTime, @lastUpdateTime)",
                        connection);

                    Console.WriteLine("插入sql创建");

                    sql_insert.Parameters.AddWithValue("@chatID", newChat.chatID);
                    sql_insert.Parameters.AddWithValue("@userAID", newChat.userAID);
                    sql_insert.Parameters.AddWithValue("@userBID", newChat.userBID);
                    sql_insert.Parameters.AddWithValue("@createTime", newChat.createTime);
                    sql_insert.Parameters.AddWithValue("@lastUpdateTime", newChat.lastUpdateTime);

                    int res = sql_insert.ExecuteNonQuery();
                    connection.Close();
                    return Ok("ChatObject insert success");
                }
                else
                {
                    connection.Close();
                    return StatusCode(500, "chatObject already exist");
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Error:{ex.Message}");
            }
        }
    }
}

