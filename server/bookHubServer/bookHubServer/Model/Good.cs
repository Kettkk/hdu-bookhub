namespace bookHubServer.Model;

public class Good
{
    public int goodID { get; set; }
    public int sellerID { get; set; }
    public string description { get; set; }
    public string bookImg { get; set; }
    public decimal price { get; set; }
    public DateTime createTime { get; set; }
    public DateTime lastUpdateTime { get; set; }
}
