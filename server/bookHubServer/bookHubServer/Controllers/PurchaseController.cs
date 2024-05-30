using bookHubServer.Model;
using bookHubServer.Tool;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace bookHubServer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PurchaseController : ControllerBase
{
    class PurchaseData
    {
        public int orderID { get; set; }
        public int sellerID { get; set; }
        public int consumerID { get; set; }
        public int goodID { get; set; }
        public int status { get; set; }
        public DateTime createTime { get; set; }
        public DateTime lastUpdateTime { get; set; }
    }

    public class ExtraData
    {
        public string tokenStr { get; set; }
        public int sellerID { get; set; }
        public int goodID { get; set; }
    }

    [HttpPost]
    public IActionResult PurchaseGood(ExtraData extraData)
    {
        try
        {

            
            PurchaseData purchaseData = new PurchaseData();
            purchaseData.orderID = OrderIDTool.GetMaxOrderID() + 1;
            Console.WriteLine(purchaseData.orderID);
            TokenClaim tokenClaim = TokenTool.ParseToken(extraData.tokenStr);

            if(extraData.sellerID != tokenClaim.userID)
            {
                purchaseData.consumerID = tokenClaim.userID;

                purchaseData.sellerID = extraData.sellerID;
                purchaseData.goodID = extraData.goodID;

                purchaseData.status = 0;
                purchaseData.createTime = DateTime.Now;
                purchaseData.lastUpdateTime = DateTime.Now;

                MySqlConnection connection = DataBaseTool.GetConnection();

                connection.Open();

                MySqlCommand command = new MySqlCommand(
                    "INSERT INTO `Order` (orderID,sellerID,consumerID,goodID,`status`,createTime,latestUpdateTime) " +
                    "VALUES(@orderID,@sellerID,@consumerID,@goodID,@status,@createTime,@latestUpdateTime)",
                    connection
                );

                command.Parameters.AddWithValue("@orderID", purchaseData.orderID);
                command.Parameters.AddWithValue("@sellerID", purchaseData.sellerID);
                command.Parameters.AddWithValue("@consumerID", purchaseData.consumerID);
                command.Parameters.AddWithValue("@goodID", purchaseData.goodID);
                command.Parameters.AddWithValue("@status", purchaseData.status);
                command.Parameters.AddWithValue("@createTime", purchaseData.createTime);
                command.Parameters.AddWithValue("@latestUpdateTime", purchaseData.lastUpdateTime);
                int res = command.ExecuteNonQuery();
                connection.Close();
            }

            return Ok(tokenClaim.userID);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error:{ex.Message}");
        }
    }
}
