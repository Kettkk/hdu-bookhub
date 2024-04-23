using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookHubServer.Tool;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bookHubServer.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        [Route("api/test")]
        public IActionResult Post()
        {
            try
            {
                var config = ConfigureTool.getConfig();
                string connectionString = config["ConnectionStrings:DefaultConnection"];

                int userID = 1;
                string username = "ketk3";
                string password = "klalala";
                string email = "ketk3@outlook.com";
                double money = 0.35;
                double star = 4.6;
                DateTime createTime = DateTime.Now;
                DateTime lastUpdateTime = DateTime.Now;

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "Insert into User (userID, username, password, email, money, star, createTime, lastUpdateTime) values(@userID, @username, @password, @email, @money, @star, @createTime, @lastUpdateTime)";

                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@userID", userID);
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@money", money);
                        command.Parameters.AddWithValue("@star", star);
                        command.Parameters.AddWithValue("@createTime", createTime);
                        command.Parameters.AddWithValue("@lastUpdateTime", lastUpdateTime);

                        int res = command.ExecuteNonQuery();

                        return Ok(res);
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error:{ex.Message}");
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

