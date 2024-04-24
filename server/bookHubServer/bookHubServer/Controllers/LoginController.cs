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
        
        public class LoginData
        {
            public string username { get; set; }
            public string password { get; set; }
        }

        [HttpPost]
        public IActionResult Login([FromBody]LoginData loginData)
        {
            try
            {
                MySqlConnection connection = DataBaseTool.GetConnection();

                connection.Open();

                MySqlCommand mySqlCommand_check = new MySqlCommand("SELECT COUNT(*) FROM User WHERE username=@username", connection);
                mySqlCommand_check.Parameters.AddWithValue("@username", loginData.username);
              
                int count = Convert.ToInt32(mySqlCommand_check.ExecuteScalar());

                if (count == 0)
                {
                    return StatusCode(500, "user does not exist");
                }
                else
                {
                    MySqlCommand mySqlCommand_verify = new MySqlCommand("SELECT userID,username,email,password FROM User WHERE username=@username AND password=@password", connection);
                    mySqlCommand_verify.Parameters.AddWithValue("@username",loginData.username);
                    mySqlCommand_verify.Parameters.AddWithValue("@password",loginData.password);


                    MySqlDataReader reader = mySqlCommand_verify.ExecuteReader();

                    TokenClaim tokenClaim = new TokenClaim();
                    if(reader.HasRows)
                    {
                        while (reader.Read())
                        { 
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                if (i == 0)
                                {
                                    tokenClaim.userID = (int)reader[i];
                                }else if (i == 1)
                                {
                                    tokenClaim.username = (string)reader[i];
                                }else if (i == 2)
                                {
                                    tokenClaim.email = (string)reader[i];
                                }
                                else
                                {
                                    tokenClaim.password = (string)reader[i];
                                }
                            }
                        }
                        return Ok(TokenTool.GenerateToken(tokenClaim));
                    }
                    else
                    {
                        return StatusCode(500, "wrong password");
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

