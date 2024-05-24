using MySql.Data.MySqlClient;

namespace bookHubServer.Tool;

public class GoodIDTool
{
    public static int GetMaxGoodID()
    {
        MySqlConnection connection = DataBaseTool.GetConnection();
        connection.Open();

        MySqlCommand command = new MySqlCommand("SELECT MAX(goodID) FROM Good", connection);

        int res = Convert.ToInt32(command.ExecuteScalar());

        connection.Close();
        return res;
    }
}

