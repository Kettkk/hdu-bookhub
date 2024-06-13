namespace bookHubServer.AdminModel
{
    public class AdminOrderList
    {
        public int orderID { get; set; }
        public string sellerName { get; set; }
        public string consumerName { get; set;}
        public string bookName { get; set; }
        public string bookPicture { get; set; }
        public int orderStatus { get; set; }
        public string orderStatusString { get; set; }
        public DateTime orderCreateTime { get; set; }
        public DateTime orderLatestUpdateTime { get; set; }
    }
}
