using System;
namespace bookHubServer.Model
{
	public class ContactObject
	{
        public int chatID { get; set; }
        public int userAID { get; set; }
        public string userAName { get; set; }
        public string userAAvatar { get; set; }
        public int otherID { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }
}

