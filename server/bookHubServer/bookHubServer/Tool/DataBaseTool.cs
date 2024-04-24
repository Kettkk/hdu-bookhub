using MySql.Data.MySqlClient;

namespace bookHubServer.Tool;

public class DataBaseTool
{
    public static MySqlConnection GetConnection()
    {
        IConfiguration configuration;

        configuration = ConfigureTool.getConfig();

        MySqlConnection connection = new MySqlConnection();

        connection.ConnectionString = configuration["ConnectionStrings:DefaultConnection"];

        return connection;
    }
}
