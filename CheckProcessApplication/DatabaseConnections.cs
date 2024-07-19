using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckProcessApplication
{
    internal class DatabaseConnections
    {
        private string connectingString;

        public DatabaseConnections()
        {
            this.connectingString = "Data Source=server;Initial Catalog=PrincessData;Persist Security Info=True;User ID=admin; Password=jp";
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(this.connectingString);
        }

        public DataTable ExecuteQuery(string query, SqlParameter[] parameters = null, int timeout = 560)
        {
            using (SqlConnection conn = GetConnection())
            {
                SqlCommand comm = new SqlCommand(query, conn);
                if (parameters != null)
                {
                    comm.Parameters.AddRange(parameters);
                }

                comm.CommandTimeout = timeout;

                DataTable dt = new DataTable();

                try
                {
                    conn.Open();
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }

                return dt;
            }
        }

        public int ExecuteNonQuery(string query, SqlParameter[] parameters = null, int timeout = 30)
        {
            using (SqlConnection conn = GetConnection())
            {
                SqlCommand comm = new SqlCommand(query, conn);
                if (parameters != null)
                {
                    comm.Parameters.AddRange(parameters);
                }

                comm.CommandTimeout = timeout;

                int rowsAffected = 0;

                try
                {
                    conn.Open();
                    rowsAffected = comm.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }

                return rowsAffected;
            }
        }

        public object ExecuteScalar(string query, SqlParameter[] parameters = null, int timeout = 30)
        {
            using (SqlConnection conn = GetConnection())
            {
                SqlCommand comm = new SqlCommand(query, conn);
                if (parameters != null)
                {
                    comm.Parameters.AddRange(parameters);
                }

                comm.CommandTimeout = timeout;

                object result = null;

                try
                {
                    conn.Open();
                    result = comm.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }

                return result;
            }
        }
    }
}
