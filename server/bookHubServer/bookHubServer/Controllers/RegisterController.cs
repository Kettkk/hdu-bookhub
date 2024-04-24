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
        [HttpPost]



        public IActionResult addUser(User user)
        {
            try
            {
                MySqlConnection connection = DataBaseTool.GetConnection();

                connection.Open();

                MySqlCommand mySqlCommand_check = new MySqlCommand("SELECT COUNT(*) FROM User WHERE username=@username", connection);
                mySqlCommand_check.Parameters.AddWithValue("@username", user.username);
                int count = Convert.ToInt32(mySqlCommand_check.ExecuteScalar());

                if (count == 0)
                {
                    user.userID = UserIDTool.GetMaxUserID() + 1;
                    user.money = 0;
                    user.star = 0;
                    user.createTime = DateTime.Now;
                    user.lastUpdateTime = DateTime.Now;

                    MySqlCommand mySqlCommand_insert = new MySqlCommand(
                       "Insert into User (userID, username, password, email, money, star, createTime, lastUpdateTime) values(@userID, @username, @password, @email, @money, @star, @createTime, @lastUpdateTime)",
                        connection
                    );
                    mySqlCommand_insert.Parameters.AddWithValue("@userID", user.userID);
                    mySqlCommand_insert.Parameters.AddWithValue("@username", user.username);
                    mySqlCommand_insert.Parameters.AddWithValue("@email", user.email);
                    mySqlCommand_insert.Parameters.AddWithValue("@password", user.password);
                    mySqlCommand_insert.Parameters.AddWithValue("@money", user.money);
                    mySqlCommand_insert.Parameters.AddWithValue("@star", user.star);
                    mySqlCommand_insert.Parameters.AddWithValue("@createTime", user.createTime);
                    mySqlCommand_insert.Parameters.AddWithValue("@lastUpdateTime", user.lastUpdateTime);

                    int res = mySqlCommand_insert.ExecuteNonQuery();

                    return Ok("registration success");
                }
                else
                {
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
