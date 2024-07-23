using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckProcessApplication
{
    internal class ReportGenerator
    {
        public void ShowReport(string reportPath, DataTable dataTable)
        {
            try
            {
                ReportDocument reportDocument = new ReportDocument();
                reportDocument.Load(reportPath);

                // ตั้งค่า DataTable ให้กับรายงาน
                reportDocument.SetDataSource(dataTable);

                // สร้างฟอร์มเพื่อแสดงรายงาน
                Form reportForm = new Form();
                CrystalReportViewer crystalReportViewer = new CrystalReportViewer
                {
                    Dock = DockStyle.Fill,
                    ReportSource = reportDocument
                };
                reportForm.Controls.Add(crystalReportViewer);
                reportForm.WindowState = FormWindowState.Maximized;
                reportForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
