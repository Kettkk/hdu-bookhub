using bookHubServer.Model;
using bookHubServer.Tool;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace bookHubServer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EditPersonalInfoController : ControllerBase
{
    [HttpPost]
    public IActionResult UpdatePersonalInfo()
    {
        try
        {
            var tokenStr = HttpContext.Request.Headers["Authorization"].ToString().Split(" ")[1];
            TokenClaim tokenClaim = TokenTool.ParseToken(tokenStr);
            var formData = Request.Form;

            MySqlConnection connection = DataBaseTool.GetConnection();

            connection.Open();

            if (formData["editedName"] != "")
            {
                MySqlCommand command = new MySqlCommand("UPDATE `User` SET username = @username  WHERE userID = @userID ", connection);
                command.Parameters.AddWithValue("@username", formData["editedName"]);
                command.Parameters.AddWithValue("@userID", tokenClaim.userID);
                int res = command.ExecuteNonQuery();
            }

            if (formData["editedEmail"] != "")
            {
                MySqlCommand command = new MySqlCommand("UPDATE `User` SET email = @email  WHERE userID = @userID ", connection);
                command.Parameters.AddWithValue("@email", formData["editedEmail"]);
                command.Parameters.AddWithValue("@userID", tokenClaim.userID);
                int res = command.ExecuteNonQuery();
            }

            var imgFile = formData.Files.GetFile("img");
            if (imgFile != null)
            {
                //删除原来的图片文件
                MySqlCommand command_delete = new MySqlCommand("SELECT avatarImg FROM `User` WHERE userID = @userID", connection);
                command_delete.Parameters.AddWithValue("@userID", tokenClaim.userID);
                using (MySqlDataReader reader = command_delete.ExecuteReader())
                {
                    if(reader.Read())
                    {
                        string avartarUrl = reader.GetString("avatarImg");
                        if(avartarUrl != null)
                        {
                            string serverLocalPath = @"/root/document/project/gitProject/hdu-bookhub/server/bookHubServer/bookHubServer/Assets/AvatarImg/" + avartarUrl.Substring(31);
                            System.IO.File.Delete(serverLocalPath);
                        }
                    }

                }
               
                //保存新图片到本地并且将地址进行更新
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imgFile.FileName);
                var filePath = Path.Combine(@"/root/document/project/gitProject/hdu-bookhub/server/bookHubServer/bookHubServer/Assets/AvatarImg/", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    imgFile.CopyTo(stream);
                }

                MySqlCommand command_update = new MySqlCommand("UPDATE `User` SET avatarImg = @avatarImg  WHERE userID = @userID",connection);
                command_update.Parameters.AddWithValue("@avatarImg", "http://101.34.70.172/AvatarImg/" + fileName);
                command_update.Parameters.AddWithValue("@userID", tokenClaim.userID);
                int res = command_update.ExecuteNonQuery();
            }

            connection.Close();
            return Ok("修改成功");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error:{ex.Message}");
        }
    }
}
