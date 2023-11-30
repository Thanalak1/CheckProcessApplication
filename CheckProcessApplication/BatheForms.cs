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
    public partial class BatheForms : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=server;Initial Catalog=PrincessData;Persist Security Info=True;User ID=admin; Password=jp");
        public BatheForms()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void previewBtn_Click(object sender, EventArgs e)
        {
            String inv = invInput.Texts;
            String sqlQuery = "select * from V_Bathe where Inv_No = '" + inv + "' order by DocNo asc;";

            PreviewBath previewBath = new PreviewBath();
            BathReports reports = new BathReports();

            SqlCommand comm = new SqlCommand(sqlQuery, conn);
            SqlDataAdapter adap = new SqlDataAdapter(comm);
            DataSet ds = new DataSet();
            adap.SelectCommand.CommandTimeout = 360;
            adap.Fill(ds, "V_Bathe");
            reports.SetDataSource(ds);

            reports.SetDatabaseLogon("admin", "jp", "server", "PrincessData");
            reports.VerifyDatabase();
            previewBath.crystalReportViewer1.ReportSource = reports;
            previewBath.crystalReportViewer1.Refresh();
            previewBath.Show();
            conn.Close();
        }
    }
}
