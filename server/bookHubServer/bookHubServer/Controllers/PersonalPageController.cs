using bookHubServer.Model;
using bookHubServer.Tool;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Mozilla;
using System.Data;

namespace bookHubServer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PersonalPageController : ControllerBase
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

    public class TokenStr
    {
        public string tokenValue { get; set; }
    }

    [HttpPost]
    public IActionResult GetPersonalData([FromBody]TokenStr tokenStr)
    {
        try
        {
            TokenClaim tokenClaim = new TokenClaim();
            tokenClaim = TokenTool.ParseToken(tokenStr.tokenValue);

            MySqlConnection connection = DataBaseTool.GetConnection();

            connection.Open();

            PersonalData personalData = new PersonalData();

            //查询与商品无关的个人信息
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
           

            //查询发布的商品数量
            MySqlCommand command_publishedNum = new MySqlCommand("SELECT COUNT(*) AS publishedNum FROM Good WHERE sellerID = @sellerID", connection);
            command_publishedNum.Parameters.AddWithValue("@sellerID", tokenClaim.userID);
           
            using (MySqlDataReader reader_publishedNum = command_publishedNum.ExecuteReader())
            {
                if (reader_publishedNum.Read())
                {
                    personalData.publishedNum = reader_publishedNum.GetInt32("publishedNum");
                }
            }


            //查询卖出的商品数量
            MySqlCommand command_soldNum = new MySqlCommand("SELECT COUNT(*) AS soldNum FROM `Order` WHERE sellerID = @sellerID AND `status` = 1", connection);
            command_soldNum.Parameters.AddWithValue("@sellerID", tokenClaim.userID);
            
            using (MySqlDataReader reader_soldNum = command_soldNum.ExecuteReader())
            {
                if (reader_soldNum.Read())
                {
                    personalData.soldNum = reader_soldNum.GetInt32("soldNum");
                }
            }
            //查询买到商品数量
            MySqlCommand command_purchasedNum = new MySqlCommand("SELECT COUNT(*) AS purchasedNum FROM `Order` WHERE consumerID = @consumerID AND `status` = 1", connection);
            command_purchasedNum.Parameters.AddWithValue("@consumerID", tokenClaim.userID);

            using (MySqlDataReader reader_purchasedNum = command_purchasedNum.ExecuteReader())
            {
                if (reader_purchasedNum.Read())
                {
                    personalData.purchasedNum = reader_purchasedNum.GetInt32("purchasedNum");
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
