using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckProcessApplication
{
    public partial class DressForms : Form
    {
        //SqlConnection conn = new SqlConnection("Data Source=server;Initial Catalog=PrincessData;Persist Security Info=True;User ID=admin; Password=jp");
        private string connectionBest = "Data Source=server;Initial Catalog=Best_ManageDB;Persist Security Info=True;User ID=admin; Password=jp";
        private string connectionPrincess = "Data Source=server;Initial Catalog=PrincessData;Persist Security Info=True;User ID=admin; Password=jp";

        public DressForms()
        {
            InitializeComponent();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void previewBtn_Click(object sender, EventArgs e)
        {
            //String inv = InvInput.Texts;
            //String sqlQuery = "select * from V_Dress where Inv_No = '" + inv + "' order by DocNo, JobBarCode asc;";

            //PreviewDress previewDress = new PreviewDress();
            //DressReports reports = new DressReports();

            //SqlCommand comm = new SqlCommand(sqlQuery, conn);
            //SqlDataAdapter adap = new SqlDataAdapter(comm);
            //DataSet ds = new DataSet();
            //adap.SelectCommand.CommandTimeout = 360;
            //adap.Fill(ds, "V_Dress");
            //reports.SetDataSource(ds);

            //reports.SetDatabaseLogon("admin", "jp", "server", "PrincessData");
            //reports.VerifyDatabase();
            //previewDress.crystalReportViewer1.ReportSource = reports;
            //previewDress.crystalReportViewer1.Refresh();
            //previewDress.Show();
            //conn.Close();

            string sqlQuery = "select * from V_DressV2 where Inv_No = @Inv order by DocNo asc;";
            DataTable dt;

            DatabaseConnections db = new DatabaseConnections(connectionPrincess);
            SqlParameter[] parameters = { 
                new SqlParameter("@Inv", InvInput.Texts)
            };

            dt = db.ExecuteQuery(sqlQuery, parameters);

            foreach (DataRow row in dt.Rows)
            {
                foreach (DataColumn column in dt.Columns)
                {
                    Console.WriteLine(column.ColumnName);
                }
            }

            PreviewDressSecondForm form = new PreviewDressSecondForm();
            DressReport2 report = new DressReport2();

            report.SetDataSource(dt);
            form.crystalReportViewer1.ReportSource = report;
            form.crystalReportViewer1.Refresh();
            form.Show();
        }
    }
}
