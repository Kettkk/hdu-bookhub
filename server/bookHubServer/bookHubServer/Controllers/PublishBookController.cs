using bookHubServer.Model;
using bookHubServer.Tool;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace bookHubServer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PublishBookController : ControllerBase
{

    [HttpPost]
    public IActionResult GetPublishedBookInfo()
    {
        try
        {
            var tokenStr = HttpContext.Request.Headers["Authorization"].ToString().Split(" ")[1];
            TokenClaim tokenClaim = TokenTool.ParseToken(tokenStr);
            var formData = Request.Form;
            Good good = new Good();

            good.goodID = GoodIDTool.GetMaxGoodID() + 1;
            good.sellerID = tokenClaim.userID;
            good.price = decimal.Parse(formData["price"]);
            good.description = formData["goodName"] + '：' + formData["description"];
            var imgFile = formData.Files.GetFile("img");

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imgFile.FileName);
            var filePath = Path.Combine(@"http://101.34.70.172/BookImg/", fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                imgFile.CopyTo(stream);
            }

            good.bookImg = "http://101.34.70.172/BookImg/" + fileName;
            good.createTime = DateTime.Now;
            good.lastUpdateTime = DateTime.Now;


            MySqlConnection connection = DataBaseTool.GetConnection();

            connection.Open();

            MySqlCommand command = new MySqlCommand(
                "INSERT INTO Good (goodID,sellerID,description,bookImg,price,createTime,latestUpdateTime) " +
                "VALUES(@goodID,@sellerID,@description,@bookImg,@price,@createTime,@latestUpdateTime)",
                connection
            );

            command.Parameters.AddWithValue("@goodID", good.goodID);
            command.Parameters.AddWithValue("@sellerID", good.sellerID);
            command.Parameters.AddWithValue("@description", good.description);
            command.Parameters.AddWithValue("@bookImg", good.bookImg);
            command.Parameters.AddWithValue("@price", good.price);
            command.Parameters.AddWithValue("@createTime", good.createTime);
            command.Parameters.AddWithValue("@latestUpdateTime", good.lastUpdateTime);

            int res = command.ExecuteNonQuery();
            connection.Close();
            return Ok("上传成功");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error:{ex.Message}");
        }
    }

}
