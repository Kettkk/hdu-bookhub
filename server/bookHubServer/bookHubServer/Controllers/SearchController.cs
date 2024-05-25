using bookHubServer.Tool;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace bookHubServer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SearchController : ControllerBase
{
    class SearchedBook
    {
        public int bookID { get; set; }
        public int sellerID { get; set; }
        public string bookname { get; set; }
        public decimal price { get; set; }
        public string description { get; set; }
        public string imgURL { get; set; }
    }

    [HttpPost]
    public IActionResult GetSearchedBook(string keyword)
    {
        try
        {
            MySqlConnection connection = DataBaseTool.GetConnection();

            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT * FROM Good WHERE description LIKE @keyword", connection);

            command.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

            MySqlDataReader reader = command.ExecuteReader();

            List<SearchedBook> searchedBooks = new List<SearchedBook>();

            while (reader.Read())
            {
                int nameLength = 0;

                SearchedBook book = new SearchedBook();

                book.bookID = reader.GetInt32("goodID");
                book.sellerID = reader.GetInt32("sellerID");
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

                searchedBooks.Add(book);
            }
            connection.Close();
            return Ok(searchedBooks);
        }catch(Exception ex)
        {
            return StatusCode(500, $"Error:{ex.Message}");
        }
    }
}
