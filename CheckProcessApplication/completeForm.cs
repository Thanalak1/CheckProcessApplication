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
    public partial class completeForm : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=server;Initial Catalog=PrincessData;Persist Security Info=True;User ID=admin; Password=jp");
        public completeForm()
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
            String sqlQuery = "select * from V_Complete where Inv_No = '" + inv + "' order by DocNo asc, JobBarCode asc;";

            PreviewComplete previewComplete = new PreviewComplete();
            CompleteReport reports = new CompleteReport();

            SqlCommand comm = new SqlCommand(sqlQuery, conn);
            SqlDataAdapter adap = new SqlDataAdapter(comm);
            DataSet ds = new DataSet();
            adap.SelectCommand.CommandTimeout = 480;
            adap.Fill(ds, "V_Complete");
            reports.SetDataSource(ds);

            reports.SetDatabaseLogon("admin", "jp", "server", "PrincessData");
            reports.VerifyDatabase();
            previewComplete.crystalReportViewer1.ReportSource = reports;
            previewComplete.crystalReportViewer1.Refresh();
            previewComplete.Show();
            conn.Close();
        }
    }
}
