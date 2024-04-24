using bookHubServer.Model;
using bookHubServer.Tool;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Net;

namespace bookHubServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
     
        public IActionResult Login(User user)
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
                    return StatusCode(500, "user does not exist");
                }
                else
                {
                    MySqlCommand mySqlCommand_verify = new MySqlCommand("SELECT COUNT(*) FROM User WHERE username=@username AND password=@password", connection);
                    mySqlCommand_verify.Parameters.AddWithValue("@username",user.username);
                    mySqlCommand_verify.Parameters.AddWithValue("@password",user.password);

                    int res = Convert.ToInt32(mySqlCommand_verify.ExecuteScalar());

                    if(res == 0)
                    {
                        return StatusCode(500, "wrong password");
                    }
                    else
                    {
                        return Ok(TokenTool.GenerateToken(user));
                    }
                   
                }

            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Error:{ex.Message}");
            }
         
        }
    }
}

