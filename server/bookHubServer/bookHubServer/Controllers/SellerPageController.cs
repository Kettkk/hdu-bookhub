using bookHubServer.Tool;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace bookHubServer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SellerPageController : ControllerBase
{
    class SellerInfo
    {
        public int userID { get; set; }
        public string userName { get; set; }
        public float star { get; set; }
        public string avatarImg { get; set; }
    }

    [HttpPost("SellerInfo")]
    public IActionResult GetSellerInfo(int sellerID)
    {
        try
        {
            MySqlConnection connection = DataBaseTool.GetConnection();

            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT * FROM User WHERE userID = @sellerID", connection);
            command.Parameters.AddWithValue("@sellerID", sellerID);

            MySqlDataReader reader = command.ExecuteReader();

            SellerInfo sellerInfo = new SellerInfo();

            if (reader.Read())
            {
                sellerInfo.userID = reader.GetInt32("userID");
                sellerInfo.userName = reader.GetString("username");
                sellerInfo.star = reader.GetFloat("star");
                sellerInfo.avatarImg = reader.GetString("avatarImg");
            }

            connection.Close();
            return Ok(sellerInfo);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error:{ex.Message}");
        }
    }

    class SellerBook
    {
        public int bookID { get; set; }
        public string bookname { get; set; }
        public decimal price { get; set; }
        public string description { get; set; }
        public string imgURL { get; set; }
        public int sellerID { get; set; }
    }



    [HttpPost("SellerBook")]
    public IActionResult GetSellerBook(int sellerID)
    {
        try
        {
            MySqlConnection connection = DataBaseTool.GetConnection();

            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT * FROM Good WHERE sellerID = @sellerID EXCEPT SELECT Good.* FROM Good,`Order`WHERE Good.goodID = `Order`.goodID", connection);
            command.Parameters.AddWithValue("@sellerID", sellerID);

            MySqlDataReader reader = command.ExecuteReader();

            List<SellerBook> sellerBooks = new List<SellerBook>();

            while (reader.Read())
            {
                int nameLength = 0;

                SellerBook book = new SellerBook();

                book.bookID = reader.GetInt32("goodID");
                book.price = reader.GetDecimal("price");
                book.description = reader.GetString("description");
                book.imgURL = reader.GetString("bookImg");
                book.sellerID = reader.GetInt32("sellerID");
                for (int i = 0; i < book.description.Length; i++)
                {
                    if (book.description[i] == '：')
                    {
                        nameLength = i;
                        break;
                    }
                }

                book.bookname = book.description.Substring(0, nameLength);

                sellerBooks.Add(book);
            }

            connection.Close();

            return Ok(sellerBooks);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error:{ex.Message}");
        }
    }
}