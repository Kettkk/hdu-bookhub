namespace bookHubServer.AdminModel
{
    public class AdminGoodList
    {
        public int goodID { get; set; }
        public string sellerName { get; set; }
        public string bookName { get; set; }
        public string bookPicture { get; set; }
        public int bookPrice { get; set; }
        public DateTime goodCreateTime { get; set; }
        public DateTime goodLatestUpdateTime { get; set; }
    }
}
