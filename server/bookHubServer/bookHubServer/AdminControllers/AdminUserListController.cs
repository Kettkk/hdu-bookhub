using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using bookHubServer.AdminModel;
using bookHubServer.AdminTools;

namespace bookHubServer.AdminControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminUserListController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetUsers()
        {
            try
            {
                List<AdminUserList> users = new List<AdminUserList>();
                using (MySqlConnection connection = AdminDBTool.getDBC())
                {
                    connection.Open();
                    string query = "SELECT * FROM User";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        AdminUserList user = new AdminUserList
                        {
                            UserID = reader.GetInt32("userID"),
                            Username = reader.GetString("username"),
                            Password = reader.GetString("password"),
                            Email = reader.GetString("email"),
                            Money = reader.GetDecimal("money"),
                            Star = reader.GetFloat("star"),
                            AvatarImg = reader.GetString("avatarImg"),
                            CreateTime = reader.GetDateTime("createTime"),
                            LastUpdateTime = reader.GetDateTime("lastUpdateTime")
                        };
                        users.Add(user);
                    }
                }
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                using (MySqlConnection connection = AdminDBTool.getDBC())
                {
                    connection.Open();
                    string deleteQuery = "DELETE FROM User WHERE userID = @userID";
                    MySqlCommand command = new MySqlCommand(deleteQuery, connection);
                    command.Parameters.AddWithValue("@userID", id);
                    int result = command.ExecuteNonQuery();

                    if (result > 0)
                    {
                        return Ok("User deleted successfully.");
                    }
                    else
                    {
                        return NotFound("User not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateUser([FromBody] AdminUserList updatedUser)
        {
            try
            {
                using (MySqlConnection connection = AdminDBTool.getDBC())
                {
                    connection.Open();
                    string updateQuery = @"
                        UPDATE User 
                        SET 
                            username = @username,
                            password = @password,
                            email = @Email,
                            money = @Money,
                            star = @Star,
                            lastUpdateTime = @LastUpdateTime
                        WHERE 
                            userID = @userID";
                    MySqlCommand command = new MySqlCommand(updateQuery, connection);
                    command.Parameters.AddWithValue("@userID", updatedUser.UserID);
                    command.Parameters.AddWithValue("@username", updatedUser.Username);
                    command.Parameters.AddWithValue("@password", updatedUser.Password);
                    command.Parameters.AddWithValue("@Email", updatedUser.Email);
                    command.Parameters.AddWithValue("@Money", updatedUser.Money);
                    command.Parameters.AddWithValue("@Star", updatedUser.Star);
                    command.Parameters.AddWithValue("@LastUpdateTime", DateTime.Now);

                    int result = command.ExecuteNonQuery();

                    if (result > 0)
                    {
                        return Ok("User updated successfully.");
                    }
                    else
                    {
                        return NotFound("User not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
