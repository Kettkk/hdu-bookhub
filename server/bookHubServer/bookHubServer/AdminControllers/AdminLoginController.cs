using bookHubServer.AdminModel;
using bookHubServer.AdminTools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace bookHubServer.AdminControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminLoginController : ControllerBase
    {
        [HttpPost]
        public IActionResult LoginUser(AdminUser user)
        {
            try
            {
                MySqlConnection connection = AdminDBTool.getDBC();
                connection.Open();
                string loginQuery = "SELECT * FROM Manager WHERE username = @username AND password = @password";
                MySqlCommand command = new MySqlCommand(loginQuery, connection);
                command.Parameters.AddWithValue("@username", user.username);
                command.Parameters.AddWithValue("@password", user.password);
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    connection.Close();
                    return Ok("Login successful");
                }
                else
                {
                    connection.Close();
                    return BadRequest("Invalid username or password");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
