using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Data;
using System.Windows.Forms;
using WindowsFormsApp2;

namespace CheckProcessApplication
{
    public partial class BatheForms : Form
    {
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

        ReportDocument cReport;
        protected string xsdFile
        {
            get
            {
                var s = cReport.FileName.Replace(".rpt", ".xsd");
                return s.Replace("rassdk://", "");
            }

        }

        private void previewBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(invInput.Texts)) { return; }
            var WHERE = $"WHERE Inv_No = '{invInput.Texts}'";
            Center.cmd.CommandText = $"select * from V_Bathe {WHERE} order by DocNo, JobBarcode";

            var dt = Center.Load();
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show($"ไม่พบข้อมูล Inv. {invInput.Texts}", "ERROR!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cReport = new ReportDocument();
            DataSet ds = new DataSet();
            if (!ds.Tables.Contains(dt.TableName))
                ds.Tables.Add(dt.Copy());

            cReport.Load($"{Application.StartupPath}/Reports/BatheReport2.rpt");
            ds.WriteXmlSchema(xsdFile);
            cReport.SetDataSource(dt);
            var u = new uReportViewer(cReport);
            u.WindowState = FormWindowState.Maximized;
            u.Show();

            System.IO.File.Delete(xsdFile);
        }
    }
}
