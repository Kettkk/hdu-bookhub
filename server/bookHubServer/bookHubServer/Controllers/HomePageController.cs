using bookHubServer.Tool;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace bookHubServer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HomePageController : ControllerBase
{
    class HomePageBook
    {
        public int bookID { get; set; }
        public string bookname { get; set; }
        public decimal price { get; set; }
        public string description { get; set; }
        public string imgURL { get; set; }
    }

    [HttpGet("RecommendedBook")]
    public IActionResult GetRecommendedBook()
    {


        try
        {
           
            MySqlConnection connection = DataBaseTool.GetConnection();

            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT Good.* FROM Good INNER JOIN `User` ON Good.sellerID=`User`.userID ORDER BY `User`.star DESC LIMIT 8", connection);

            MySqlDataReader reader = command.ExecuteReader();

            List<HomePageBook> recommendedBooks = new List<HomePageBook>();

            while (reader.Read())
            {
                int nameLength = 0;

                HomePageBook book = new HomePageBook();

                book.bookID = reader.GetInt32("goodID");
                book.price = reader.GetDecimal("price");
                book.description = reader.GetString("description");
                book.imgURL = reader.GetString("bookImg"); 

                for(int i=0;i<book.description.Length;i++)
                {
                    if (book.description[i] == '：')
                    {
                        nameLength = i;
                        break;
                    }
                }

                book.bookname = book.description.Substring(0, nameLength);

                recommendedBooks.Add(book);

            }

            connection.Close();
            return Ok(recommendedBooks);
        }
        catch(Exception ex)
        {
            return StatusCode(500, $"Error:{ex.Message}");
        }
       
    }

   

    [HttpGet("LatestBook")] 
    public IActionResult GetLatestBook()
    {
        try
        {

            MySqlConnection connection = DataBaseTool.GetConnection();

            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT * FROM Good ORDER BY createTime DESC LIMIT 8", connection);

            MySqlDataReader reader = command.ExecuteReader();

            List<HomePageBook> latestBooks = new List<HomePageBook>();

            while (reader.Read())
            {
                int nameLength = 0;

                HomePageBook book = new HomePageBook();

                book.bookID = reader.GetInt32("goodID");
                book.price = reader.GetDecimal("price");
                book.description = reader.GetString("description");
                book.imgURL = reader.GetString("bookImg");

                for (int i = 0; i < book.description.Length; i++)
                {
                    if (book.description[i] == '：')
                    {
                        nameLength = i;
                        break;
                    }
                }

                book.bookname = book.description.Substring(0, nameLength);

                latestBooks.Add(book);
            }
            connection.Close();
            return Ok(latestBooks);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error:{ex.Message}");
        }
    }

    class GoldUser
    {
        public int userId { get; set; }
        public string userName { get; set; }
        public float star { get; set; }
        public string avatarImg { get; set; }
    }

    [HttpGet("GoldUser")]
    public IActionResult GetGoldUser()
    {
        try
        {
            MySqlConnection connection = DataBaseTool.GetConnection();

            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT * FROM User ORDER BY star DESC LIMIT 5", connection);

            MySqlDataReader reader = command.ExecuteReader();

            List<GoldUser> goldUsers = new List<GoldUser>();

            while (reader.Read())
            {
                GoldUser goldUser = new GoldUser();
                goldUser.userId = reader.GetInt32("userID");
                goldUser.userName = reader.GetString("username");
                goldUser.star = reader.GetFloat("star");
                goldUser.avatarImg = reader.GetString("avatarImg");

                goldUsers.Add(goldUser);
            }
            connection.Close();
            return Ok(goldUsers);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error:{ex.Message}");
        }
    }


}
