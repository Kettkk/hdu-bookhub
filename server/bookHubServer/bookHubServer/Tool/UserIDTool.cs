using MySql.Data.MySqlClient;

namespace bookHubServer.Tool;

public class UserIDTool
{
    public static int GetMaxUserID()
    {
        MySqlConnection connection = DataBaseTool.GetConnection();
        connection.Open();

        MySqlCommand command = new MySqlCommand("SELECT MAX(userID) FROM User", connection);

        var res = command.ExecuteScalar();

        if (res == null || res == DBNull.Value)
        {
            connection.Close();
            return 0;
        }
        else
        {
            connection.Close();
            return Convert.ToInt32(res);
        }
    }

    public static int getUserIDByName(string username)
    {
        MySqlConnection connection = DataBaseTool.GetConnection();
        connection.Open();

        MySqlCommand cmd = new MySqlCommand("select userID from User where username=@username", connection);
        cmd.Parameters.AddWithValue("@username", username);

        int res = Convert.ToInt32(cmd.ExecuteScalar());
        return res;
    }
}
