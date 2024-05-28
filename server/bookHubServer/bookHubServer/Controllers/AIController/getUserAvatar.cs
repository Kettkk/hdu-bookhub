using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookHubServer.Model;
using bookHubServer.Tool;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using static bookHubServer.Controllers.PersonalPageController;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bookHubServer.Controllers.AIController
{
    [Route("api/assistant/[controller]")]
    public class getUserAvatar : Controller
    {
        class PersonalData
        {
            public int userId { get; set; }
            public string userName { get; set; }
            public float star { get; set; }
            public decimal money { get; set; }
            public string avatarImg { get; set; }
            public string email { get; set; }
            public DateTime createTime { get; set; }
            public int publishedNum { get; set; }
            public int soldNum { get; set; }
            public int purchasedNum { get; set; }
        }

        public class AITokenStr
        {
            public string tokenValue { get; set; }
        }

        [HttpPost]
        public IActionResult GetPersonalData([FromBody] TokenStr tokenStr)
        {
            try
            {
                TokenClaim tokenClaim = new TokenClaim();
                tokenClaim = TokenTool.ParseToken(tokenStr.tokenValue);

                MySqlConnection connection = DataBaseTool.GetConnection();

                connection.Open();

                PersonalData personalData = new PersonalData();

                MySqlCommand command_info = new MySqlCommand("SELECT * FROM User WHERE userID = @userID", connection);
                command_info.Parameters.AddWithValue("@userID", tokenClaim.userID);

                using (MySqlDataReader reader_info = command_info.ExecuteReader())
                {
                    if (reader_info.Read())
                    {
                        personalData.userId = tokenClaim.userID;
                        personalData.userName = reader_info.GetString("username");
                        personalData.star = reader_info.GetFloat("star");
                        personalData.money = reader_info.GetDecimal("money");
                        personalData.avatarImg = reader_info.GetString("avatarImg");
                        personalData.email = reader_info.GetString("email");
                        personalData.createTime = reader_info.GetDateTime("createTime");
                    }
                }

                connection.Close();
                return Ok(personalData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error:{ex.Message}");
            }
        }
    }
}

