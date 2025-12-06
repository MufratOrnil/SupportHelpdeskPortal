using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SupportHelpdeskPortal
{
    public static class DbHelper
    {
        private static string ConnString =>
            ConfigurationManager.ConnectionStrings["HelpdeskDB"].ConnectionString;

        // Use this for STORED PROCEDURES only
        public static DataTable ExecuteDataTable(string procName, params SqlParameter[] parameters)
        {
            using (var conn = new SqlConnection(ConnString))
            using (var cmd = new SqlCommand(procName, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (parameters != null && parameters.Length > 0)
                    cmd.Parameters.AddRange(parameters);

                using (var da = new SqlDataAdapter(cmd))
                {
                    var dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        // Use this for STORED PROCEDURES that do INSERT/UPDATE/DELETE
        public static int ExecuteNonQuery(string procName, params SqlParameter[] parameters)
        {
            using (var conn = new SqlConnection(ConnString))
            using (var cmd = new SqlCommand(procName, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (parameters != null && parameters.Length > 0)
                    cmd.Parameters.AddRange(parameters);

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        // NEW: use this for raw SQL text (SELECT ...), e.g. dashboard/profile queries
        public static DataTable ExecuteSql(string sql, params SqlParameter[] parameters)
        {
            using (var conn = new SqlConnection(ConnString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.CommandType = CommandType.Text;
                if (parameters != null && parameters.Length > 0)
                    cmd.Parameters.AddRange(parameters);

                using (var da = new SqlDataAdapter(cmd))
                {
                    var dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
    }
}
