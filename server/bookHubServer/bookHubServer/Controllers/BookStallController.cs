using bookHubServer.Tool;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace bookHubServer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookStallController : ControllerBase
{
    class BookStallBook
    {
        public int bookID { get; set; }
        public string bookname { get; set; }
        public decimal price { get; set; }
        public string description { get; set; }
        public string imgURL { get; set; }
        public int sellerID { get; set; }
    }

    [HttpGet("AllRecommendedBook")]
    public IActionResult GetRecommendedBook()
    {
        try
        {

            MySqlConnection connection = DataBaseTool.GetConnection();

            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT g.*,`User`.userID FROM (SELECT * FROM Good EXCEPT SELECT Good.* FROM Good,`Order`WHERE Good.goodID = `Order`.goodID) AS g,`User` WHERE g.sellerID=`User`.userID ORDER BY `User`.star DESC  \r\n", connection);

            MySqlDataReader reader = command.ExecuteReader();

            List<BookStallBook> allRecommendedBooks = new List<BookStallBook>();

            while (reader.Read())
            {
                int nameLength = 0;

                BookStallBook book = new BookStallBook();

                book.bookID = reader.GetInt32("goodID");
                book.price = reader.GetDecimal("price");
                book.description = reader.GetString("description");
                book.imgURL = reader.GetString("bookImg");
                book.sellerID = reader.GetInt32("userID");
                for (int i = 0; i < book.description.Length; i++)
                {
                    if (book.description[i] == '：')
                    {
                        nameLength = i;
                        break;
                    }
                }

                book.bookname = book.description.Substring(0, nameLength);

                allRecommendedBooks.Add(book);
            }

            connection.Close();
            return Ok(allRecommendedBooks);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error:{ex.Message}");
        }
    }

    [HttpGet("AllLatestBook")]
    public IActionResult GetLatestBook()
    {
        try
        {

            MySqlConnection connection = DataBaseTool.GetConnection();

            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT g.*,`User`.userID FROM (SELECT * FROM Good EXCEPT SELECT Good.* FROM Good,`Order`WHERE Good.goodID = `Order`.goodID) AS g,`User` WHERE g.sellerID=`User`.userID ORDER BY g.createTime DESC ", connection);

            MySqlDataReader reader = command.ExecuteReader();

            List<BookStallBook> allLatestBooks = new List<BookStallBook>();

            while (reader.Read())
            {
                int nameLength = 0;

                BookStallBook book = new BookStallBook();

                book.bookID = reader.GetInt32("goodID");
                book.price = reader.GetDecimal("price");
                book.description = reader.GetString("description");
                book.imgURL = reader.GetString("bookImg");
                book.sellerID = reader.GetInt32("userID");
                for (int i = 0; i < book.description.Length; i++)
                {
                    if (book.description[i] == '：')
                    {
                        nameLength = i;
                        break;
                    }
                }

                book.bookname = book.description.Substring(0, nameLength);

                allLatestBooks.Add(book);
            }

            connection.Close();
            return Ok(allLatestBooks);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error:{ex.Message}");
        }
    }

}
