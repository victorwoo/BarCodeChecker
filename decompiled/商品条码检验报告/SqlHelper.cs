namespace 商品条码检验报告
{
    using System;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;

    internal class SqlHelper
    {
        public static SqlDataReader ExecDataReader(DatabaseConn dbconn, string sqlstring, SqlParameter param)
        {
            SqlDataReader reader;
            SqlConnection connection = GetConnection(dbconn);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlstring, connection);
                command.Parameters.Add(param);
                reader = command.ExecuteReader();
            }
            catch (SqlException exception)
            {
                throw exception;
            }
            return reader;
        }

        public static int ExecNonQuery(DatabaseConn dbconn, string sqlstring, SqlParameter param)
        {
            int num;
            using (SqlConnection connection = GetConnection(dbconn))
            {
                using (SqlCommand command = new SqlCommand(sqlstring, connection))
                {
                    connection.Open();
                    command.Parameters.Add(param);
                    num = command.ExecuteNonQuery();
                }
            }
            return num;
        }

        public static int ExecNonQuery(DatabaseConn dbconn, string sqlstring, SqlParameter[] param)
        {
            int num;
            using (SqlConnection connection = GetConnection(dbconn))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    PreparedCommand(command, connection, CommandType.Text, sqlstring, param);
                    num = command.ExecuteNonQuery();
                }
            }
            return num;
        }

        public static object ExecScalar(DatabaseConn dbconn, string sqlstring, SqlParameter param)
        {
            object obj2;
            using (SqlConnection connection = GetConnection(dbconn))
            {
                using (SqlCommand command = new SqlCommand(sqlstring, connection))
                {
                    connection.Open();
                    command.Parameters.Add(param);
                    obj2 = command.ExecuteScalar();
                }
            }
            return obj2;
        }

        public static object ExecScalar(DatabaseConn dbconn, string sqlstring, SqlParameter[] param)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection connection = GetConnection(dbconn))
            {
                PreparedCommand(cmd, connection, CommandType.Text, sqlstring, param);
                return cmd.ExecuteScalar();
            }
        }

        public static DataTable ExecSql(DatabaseConn dbconn, string sqlstring)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = GetConnection(dbconn))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlstring, connection))
                {
                    connection.Open();
                    adapter.Fill(dataTable);
                }
            }
            return dataTable;
        }

        public static DataTable ExecSql(DatabaseConn dbconn, string sqlstring, SqlParameter param)
        {
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            using (SqlConnection connection = GetConnection(dbconn))
            {
                using (SqlCommand command = new SqlCommand(sqlstring, connection))
                {
                    command.Parameters.Add(param);
                    adapter.SelectCommand = command;
                    adapter.Fill(dataTable);
                }
            }
            return dataTable;
        }

        public static DataTable ExecSql(DatabaseConn dbconn, string sqlstring, SqlParameter[] param)
        {
            DataTable dataTable = new DataTable();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter adapter = new SqlDataAdapter();
            using (SqlConnection connection = GetConnection(dbconn))
            {
                PreparedCommand(cmd, connection, CommandType.Text, sqlstring, param);
                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);
            }
            return dataTable;
        }

        public static DataTable ExePro(DatabaseConn dbconn, string procedure, SqlParameter[] param)
        {
            DataTable dataTable = new DataTable();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter adapter = new SqlDataAdapter();
            using (SqlConnection connection = GetConnection(dbconn))
            {
                PreparedCommand(cmd, connection, CommandType.StoredProcedure, procedure, param);
                cmd.CommandTimeout = 120;
                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);
            }
            return dataTable;
        }

        private static SqlConnection GetConnection(DatabaseConn dbconn) => 
            new SqlConnection(ConfigurationManager.ConnectionStrings[dbconn.ToString()].ConnectionString);

        public static bool IsExists(DatabaseConn dbconn, string sqlstring, SqlParameter param)
        {
            bool flag = false;
            if (Convert.ToInt32(ExecScalar(dbconn, sqlstring, param)) > 0)
            {
                flag = true;
            }
            return flag;
        }

        public static bool IsExists(DatabaseConn dbconn, string sqlstring, SqlParameter[] param)
        {
            bool flag = false;
            if (Convert.ToInt32(ExecScalar(dbconn, sqlstring, param)) > 0)
            {
                flag = true;
            }
            return flag;
        }

        private static void PreparedCommand(SqlCommand cmd, SqlConnection conn, CommandType type, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            cmd.CommandType = type;
            if (cmdParms != null)
            {
                foreach (SqlParameter parameter in cmdParms)
                {
                    cmd.Parameters.Add(parameter);
                }
            }
        }
    }
}

