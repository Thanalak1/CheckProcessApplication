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

    public partial class BuryForms : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=server;Initial Catalog=PrincessData;Persist Security Info=True;User ID=admin; Password=jp");
        public BuryForms()
        {
            InitializeComponent();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void previewBtn_Click(object sender, EventArgs e)
        {
            String inv = InvInput.Texts;
            String sqlQuery = "select * from V_InlaidReport_Testing where Inv_No = '" + inv + "' order by DocNo asc;";

            PreviewBuryReports previewBury = new PreviewBuryReports();
            BuryReports reports = new BuryReports();

            SqlCommand comm = new SqlCommand(sqlQuery, conn);
            SqlDataAdapter adap = new SqlDataAdapter(comm);
            DataSet ds = new DataSet();
            adap.SelectCommand.CommandTimeout = 360;
            adap.Fill(ds, "V_InlaidReport_Testing");
            reports.SetDataSource(ds);

            reports.SetDatabaseLogon("admin", "jp", "server", "PrincessData");
            reports.VerifyDatabase();
            previewBury.crystalReportViewer1.ReportSource = reports;
            previewBury.crystalReportViewer1.Refresh();
            previewBury.Show();
            conn.Close();
        }
    }
}
