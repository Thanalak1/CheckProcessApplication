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
    public partial class BatheAndPolish : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=server;Initial Catalog=PrincessData;Persist Security Info=True;User ID=admin; Password=jp");
        public BatheAndPolish()
        {
            InitializeComponent();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void previewBtn_Click(object sender, EventArgs e)
        {
            String inv = invInput.Texts;
            String sqlQuery = "select * from V_PolishAndBathe where Inv_No = '" + inv + "' order by DocNo asc;";

            PreviewPolishAndBath previewPolishAndBath = new PreviewPolishAndBath();
            PolishAndBathReports reports = new PolishAndBathReports();

            SqlCommand comm = new SqlCommand(sqlQuery, conn);
            SqlDataAdapter adap = new SqlDataAdapter(comm);
            DataSet ds = new DataSet();
            adap.SelectCommand.CommandTimeout = 360;
            adap.Fill(ds, "V_PolishAndBathe");
            reports.SetDataSource(ds);

            reports.SetDatabaseLogon("admin", "jp", "server", "PrincessData");
            reports.VerifyDatabase();
            previewPolishAndBath.crystalReportViewer1.ReportSource = reports;
            previewPolishAndBath.crystalReportViewer1.Refresh();
            previewPolishAndBath.Show();
            conn.Close();
        }
    }
}
