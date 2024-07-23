using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace WindowsFormsApp2
{
    public partial class uReportViewer : Form
    {
        public uReportViewer(ReportDocument rpt)
        {
            InitializeComponent();
            try
            {
                cReportViewer.ReportSource = rpt;
                cReportViewer.Visible = true;
                cReportViewer.Show();
                cReportViewer = null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void uReportViewer_Load(object sender, EventArgs e)
        {
            
        }
    }
}
