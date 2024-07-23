using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal class Center
    {
        private static string GetConnectionString()
        {
            string conString = "Data Source=SERVER;Initial Catalog=PrincessData;Persist Security Info=True;User ID=admin;Password=jp;Encrypt=True;TrustServerCertificate=True";
            return conString;
        }

        private static SqlConnection con = new SqlConnection();
        private static SqlDataAdapter da;
        private static BindingSource bs;
        private static string sql;
        public static SqlCommand cmd = new SqlCommand("", con);
        public static DataSet ds;
        public static DataTable dt;
        public static SqlDataReader dr;

        private static void openConnection()
        {            
            if (con.State != ConnectionState.Open) 
            { 
                con.ConnectionString = GetConnectionString();
                con.Open(); 
            }
        }

        private static void closeConnection()
        {
            if (con.State != ConnectionState.Closed) { con.Close(); }
        }

        public static DataTable Load()
        {
            openConnection();
            cmd = new SqlCommand(cmd.CommandText, con);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            closeConnection();
            return dt;
        }

        public static DataTable Execute(string CommandText)
        {
            openConnection();
            cmd = new SqlCommand(CommandText, con);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            closeConnection();
            return dt;
        }

        public static DataTable CurrentDataTable()
        {
            return dt;
        }
    }
}
