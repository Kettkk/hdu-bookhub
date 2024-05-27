using bookHubServer.Tool;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace bookHubServer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PersonalBookController : ControllerBase
{
    public class DirectView
    {
        public int userID { get; set; }
        public int whichView { get; set; }
    }
    
    class PersonalBookData
    {
        public int bookID { get; set; }
        public string bookname { get; set; }
        public decimal price { get; set; }
        public string description { get; set; }
        public string imgURL { get; set; }
        public int sellerID { get; set; }
    }

    [HttpPost]
    public IActionResult GetPersonalBookData(DirectView directView)
    {
        try
        {
            MySqlConnection connection = DataBaseTool.GetConnection();

            connection.Open();

            List<PersonalBookData> personalBooks = new List<PersonalBookData>();

            if(directView.whichView == 1)
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM Good WHERE sellerID = @sellerID", connection);
                command.Parameters.AddWithValue("@sellerID", directView.userID);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        int nameLength = 0;

                        PersonalBookData book = new PersonalBookData();

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

                        personalBooks.Add(book);
                    }
                }
            }
            else if(directView.whichView == 2)
            {
                MySqlCommand command = new MySqlCommand(
                    "SELECT Good.* FROM Good,`Order` WHERE Good.goodID=`Order`.goodID AND `Order`.sellerID = @sellerID AND `Order`.`status` = 1",
                    connection
                );

                command.Parameters.AddWithValue("sellerID", directView.userID);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int nameLength = 0;

                        PersonalBookData book = new PersonalBookData();

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

                        personalBooks.Add(book);
                    }
                }
            }
            else
            {
                MySqlCommand command = new MySqlCommand(
                    "SELECT Good.* FROM Good,`Order` WHERE Good.goodID=`Order`.goodID AND `Order`.consumerID=@consumerID AND `Order`.`status` = 1",
                    connection
                );

                command.Parameters.AddWithValue("@consumerID", directView.userID);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int nameLength = 0;

                        PersonalBookData book = new PersonalBookData();

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

                        personalBooks.Add(book);
                    }
                }
            }

            connection.Close();
            return Ok(personalBooks);
        }
        catch(Exception ex)
        {
            return StatusCode(500, $"Error:{ex.Message}");
        }
    }
}
