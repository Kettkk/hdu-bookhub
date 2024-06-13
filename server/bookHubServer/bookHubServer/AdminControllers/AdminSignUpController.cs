using bookHubServer.AdminModel;
using bookHubServer.AdminTools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace bookHubServer.AdminControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminSignUpController : ControllerBase
    {
        [HttpPost]
        public IActionResult InsertUser(AdminUser user)
        {
            try
            {
                MySqlConnection connection = AdminDBTool.getDBC();
                connection.Open();
                string insertQuery = "INSERT INTO Manager (username, password) VALUES (@username, @password)";
                MySqlCommand command = new MySqlCommand(insertQuery, connection);
                command.Parameters.AddWithValue("@username", user.username);
                command.Parameters.AddWithValue("@password", user.password);
                int res = command.ExecuteNonQuery();
                connection.Close();
                return Ok("insert successful: " + res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }
}
