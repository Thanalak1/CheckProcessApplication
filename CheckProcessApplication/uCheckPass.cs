using CheckProcessApplication.Class;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApp2;

namespace CheckProcessApplication
{
    public partial class uCheckPass : Form
    {
        public uCheckPass()
        {
            InitializeComponent();
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
            var fWHERE = "WHERE";
            if (Convert.ToInt16(cboStatus.SelectedValue) == (int)AppSetting.ePassStatus.All)
                fWHERE += " JobHead.mDate BETWEEN @DateStart AND @DateEnd";
            else if (Convert.ToInt16(cboStatus.SelectedValue) == (int)AppSetting.ePassStatus.NotPass)
                fWHERE += " JobHead.mDate BETWEEN @DateStart AND @DateEnd AND JobDetail.pass_date IS NULL";
            else
                fWHERE += " JobDetail.pass_date BETWEEN @DateStart AND @DateEnd";

            if (!string.IsNullOrEmpty(txtEmpCode.Texts))
                fWHERE += $" AND JobHead.EmpCode = '{txtEmpCode.Texts}'";
            if (!string.IsNullOrEmpty(txtOrderNo.Texts))
                fWHERE += $" AND JobDetail.OrderNo = '{txtOrderNo.Texts}'";
            if (Convert.ToInt16(cboJobName.SelectedValue) != 0)
                fWHERE += $" AND JobHead.JobType = {cboJobName.SelectedValue}";

            Center.cmd.CommandText = $"SELECT JobHead.JobName, JobDetail.CustCode, JobDetail.OrderNo, JobDetail.ListNo, JobHead.EmpCode, JobHead.EmpName, JobHead.DocNo, JobDetail.JobBarcode" +
                $", JobDetail.pass_date, JobHead.JobDate, JobHead.DueDate, JobDetail.UserName, CASE WHEN JobDetail.pass_ok = 0 THEN 'ยังไม่ได้ตรวจออก' ELSE 'ตรวจออกแล้ว' END AS pass_ok" +
                $" FROM JobHead LEFT JOIN JobDetail ON JobHead.DocNo = JobDetail.DocNo AND JobHead.EmpCode = JobDetail.EmpCode" +
                $" {fWHERE}" +
                $" ORDER BY JobHead.JobType, JobHead.DocNo";

            Center.AddParameter(Center.cmd, nameof(DateStart), DateStart.Value.Date);
            Center.AddParameter(Center.cmd, nameof(DateEnd), DateEnd.Value.Date.AddDays(1).AddSeconds(-1));

            var dt = Center.Execute(Center.cmd.CommandText);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show($"ไม่พบข้อมูล", "ERROR!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cReport = new ReportDocument();
            DataSet ds = new DataSet();
            if (!ds.Tables.Contains(dt.TableName))
                ds.Tables.Add(dt.Copy());

            cReport.Load($"{Application.StartupPath}/Reports/CheckPass.rpt");

            var result = dt.AsEnumerable()
                .GroupBy(row => row.Field<string>("JobName"))
                .Select(group => new
                {
                    JobName = group.Key,
                    Count = group.Select(row => row.Field<string>("DocNo"))
                    .Distinct()
                    .Count()
                });

            string text = "";
            var fSpacing = "";
            foreach (var item in result)
            {
                text += $"{fSpacing}{item.JobName.Trim()} จำนวน {item.Count}";
                fSpacing = "  |  ";
                Console.WriteLine($"{item.JobName}, จำนวนครั้งที่ปรากฏ: {item.Count}");
            }

            cReport.DataDefinition.FormulaFields["CountJobName"].Text = JPM.SetPrint.SetString(text);
            ds.WriteXmlSchema(xsdFile);
            cReport.SetDataSource(dt);
            var u = new uReportViewer(cReport);
            u.WindowState = FormWindowState.Maximized;
            u.Show();

            System.IO.File.Delete(xsdFile);
        }

        private void uCheckPass_Load(object sender, EventArgs e)
        {
            Global.Combo.Load(cboStatus, typeof(AppSetting.ePassStatus));
            Global.Combo.Load(cboJobName, new DataObject.JobType(), AppSetting.eComboList.All);
            //var dt = (DataTable)cboJobName.DataSource;
            //var drRemove = new[] { 2, 4, 7, 9, 10, 11, 12, 13 };
            //var Newdt = dt.AsEnumerable().Where(row => !drRemove.Contains(row.Field<int>("JobNum"))).CopyToDataTable();
            //cboJobName.DataSource = Newdt;
        }
    }
}
