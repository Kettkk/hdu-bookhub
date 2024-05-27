using bookHubServer.Model;
using bookHubServer.Tool;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace bookHubServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        
        public class RegisterData
        {
            public string username { get; set; }
            public string email { get; set; }
            public string password { get; set; }
        }

        [HttpPost]
        public IActionResult addUser([FromBody]RegisterData registerData)
        {
            try
            {
                MySqlConnection connection = DataBaseTool.GetConnection();

                connection.Open();

                MySqlCommand mySqlCommand_check = new MySqlCommand("SELECT COUNT(*) FROM User WHERE username=@username", connection);
                mySqlCommand_check.Parameters.AddWithValue("@username", registerData.username);
                int count = Convert.ToInt32(mySqlCommand_check.ExecuteScalar());

                if (count == 0)
                {
                    User user = new User();
                    user.userID = UserIDTool.GetMaxUserID() + 1;
                    user.money = 0;
                    user.star = 0;
                    user.avatarImg = "";
                    user.createTime = DateTime.Now;
                    user.lastUpdateTime = DateTime.Now;

                    MySqlCommand mySqlCommand_insert = new MySqlCommand(
                       "Insert into User (userID, username, password, email, money, star, avatarImg, createTime, lastUpdateTime) values(@userID, @username, @password, @email, @money, @star, @createTime, @lastUpdateTime)",
                        connection
                    );
                    mySqlCommand_insert.Parameters.AddWithValue("@userID", user.userID);
                    mySqlCommand_insert.Parameters.AddWithValue("@username", registerData.username);
                    mySqlCommand_insert.Parameters.AddWithValue("@email", registerData.email);
                    mySqlCommand_insert.Parameters.AddWithValue("@password",registerData.password);
                    mySqlCommand_insert.Parameters.AddWithValue("@money", user.money);
                    mySqlCommand_insert.Parameters.AddWithValue("@star", user.star);
                    mySqlCommand_insert.Parameters.AddWithValue("@avatarImg", user.avatarImg);
                    mySqlCommand_insert.Parameters.AddWithValue("@createTime", user.createTime);
                    mySqlCommand_insert.Parameters.AddWithValue("@lastUpdateTime", user.lastUpdateTime);

                    int res = mySqlCommand_insert.ExecuteNonQuery();

                    connection.Close();
                    return Ok("registration success");
                }
                else
                {
                    connection.Close();
                    return StatusCode(500, "username already taken");
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Error:{ex.Message}");
            }
          
        }
    }
}
