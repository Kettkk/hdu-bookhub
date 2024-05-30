using System;
using MySql.Data.MySqlClient;

namespace bookHubServer.Tool;

public class ChatIDTool
{
    public static int getMaxChatID()
    {
        MySqlConnection connection = DataBaseTool.GetConnection();
        connection.Open();

        MySqlCommand command = new MySqlCommand("SELECT MAX(chatID) FROM ChatList", connection);

        int res = Convert.ToInt32(command.ExecuteScalar());

        return res;
    }  
}


