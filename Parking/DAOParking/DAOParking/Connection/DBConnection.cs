using MySql.Data.MySqlClient;

namespace DAOParking.Connection
{
    public class DBConnection
    {
        public MySqlConnection connection;
        private static DBConnection instance;
        private DBConnection(string connectionString)
        {
            connection = new MySqlConnection(connectionString);
        }
        public static DBConnection getInstance(string connectionString)
        {
            if (instance == null)
                instance = new DBConnection(connectionString);
            return instance;
        }
    }
}
