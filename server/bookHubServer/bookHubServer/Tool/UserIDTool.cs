using MySql.Data.MySqlClient;

namespace bookHubServer.Tool;

public class UserIDTool
{
    public static int GetMaxUserID()
    {
        MySqlConnection connection = DataBaseTool.GetConnection();
        connection.Open();

        MySqlCommand command = new MySqlCommand("SELECT MAX(userID) FROM User", connection);

        int res = Convert.ToInt32(command.ExecuteScalar());

        return res;

    }

   

}
