namespace bookHubServer.Model;

public class User
{
    public int userID { get; set; }
    public string username { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public decimal money { get; set; }
    public float star { get; set; }
    public string avatarImg { get; set; }
    public DateTime createTime { get; set; }
    public DateTime lastUpdateTime { get; set; }

}
