using bookHubServer.Tool;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace bookHubServer.Controllers;

[Route("api/[controller]")]
[ApiController]


public class PurchasePageController : ControllerBase
{
    class PurchaseBook
    {
        //information of seller
        public int sellerID { get; set; }//userID
        public string sellername { get; set; }//username
        public float sellerscore { get; set; }//star
        public string selleravatar { get; set; }//avatarImg

        //information of book
        public int bookID { get; set; }//goodID
        public string bookname { get; set; }
        public decimal price { get; set; }//price
        public string description { get; set; }//description
        public string imgURL { get; set; }//bookImg
    }

    [HttpPost]
    public IActionResult GetPurchaseBook(int purchaseBookID)
    {
        try
        {
            MySqlConnection connection = DataBaseTool.GetConnection();

            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT * FROM Good INNER JOIN `User` ON Good.sellerID=`User`.userID AND Good.goodID=@purchaseBookID", connection);
            command.Parameters.AddWithValue("@purchaseBookID", purchaseBookID);

            MySqlDataReader reader = command.ExecuteReader();

            PurchaseBook purchaseBook = new PurchaseBook();

            if (reader.Read())
            {
                purchaseBook.sellerID = reader.GetInt32("userID");
                purchaseBook.sellername = reader.GetString("username");
                purchaseBook.sellerscore = reader.GetFloat("star");
                purchaseBook.selleravatar = reader.GetString("avatarImg");

                purchaseBook.bookID = reader.GetInt32("goodID");
                purchaseBook.price = reader.GetDecimal("price");
                purchaseBook.description = reader.GetString("description");
                purchaseBook.imgURL = reader.GetString("bookImg");
            }

            connection.Close();
            return Ok(purchaseBook);

        }catch(Exception ex){
            return StatusCode(500, $"Error:{ex.Message}");
        }
    }
}
