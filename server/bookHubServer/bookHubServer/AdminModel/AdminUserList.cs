namespace bookHubServer.AdminModel
{
    public class AdminUserList
    {
        public string Username { get; set; }
        public int UserID { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public decimal Money { get; set; }
        public float Star { get; set; }
        public string AvatarImg { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime LastUpdateTime { get; set; }
    }
}
