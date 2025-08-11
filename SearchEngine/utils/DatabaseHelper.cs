using System;
using System.Data.SqlClient;

namespace MyApp.Utils
{
    public static class DatabaseHelper
    {
        private static string _connectionString = "Your_Connection_String_Here";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public static void ExecuteNonQuery(string query, Action<SqlCommand> parameterize = null)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SqlCommand(query, conn))
                {
                    parameterize?.Invoke(cmd);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
