using MySql.Data.MySqlClient;

namespace bookHubServer.AdminTools
{
    public class AdminDBTool
    {
        public static MySqlConnection getDBC()
        {
            IConfiguration config = AdminConfigTool.getConfig();
            string connectionString = config["ConnectionStrings:DefaultConnection"];
            return new MySqlConnection(connectionString);
        }
    }
}
