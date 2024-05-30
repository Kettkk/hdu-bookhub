using System;
namespace bookHubServer.Model;
public class ChatObject
{
    public int id { get; set; }
    public int chatID { get; set; }
    public int userAID { get; set; }
    public int userBID { get; set; }
    public DateTime createTime { get; set; }
    public DateTime lastUpdateTime { get; set; }
}


