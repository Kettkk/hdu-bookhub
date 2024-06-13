namespace bookHubServer.AdminTools
{
    public class AdminConfigTool
    {
        public static IConfiguration getConfig()
        {
            var builder = new ConfigurationBuilder().SetBasePath("E:/Bookhub/hdu-bookhub/server/bookHubServer/bookHubServer/ConfigFile").AddJsonFile("appsettings.json");
            return builder.Build();
        }
    }
}
