using CrystalDecisions.CrystalReports.Engine;
using JPM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2;

namespace CheckProcessApplication
{
    public partial class SelectedForm : Form
    {

        DataTable dtPrint;
        DataTable dt = new DataTable();

        public SelectedForm(DataTable dtPrint)
        {
            InitializeComponent();
            this.dtPrint = dtPrint;
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            cReport = new ReportDocument();
            DataSet ds = new DataSet();
            if (!ds.Tables.Contains(dtPrint.TableName))
                ds.Tables.Add(dt.Copy());

            cReport.Load($"{Application.StartupPath}/Reports/CheckPass.rpt");

            // - SetPrint
            var result = dtPrint.AsEnumerable()
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
                text += $"{fSpacing}{item.JobName.Trim()} จำนวน {item.Count} บิล";
                fSpacing = "  |  ";
                //Console.WriteLine($"{item.JobName}, จำนวนครั้งที่ปรากฏ: {item.Count}");
            }

            // - Print
            cReport.DataDefinition.FormulaFields["CountJobName"].Text = JPM.SetPrint.SetString(text);
            ds.WriteXmlSchema(xsdFile);
            cReport.SetDataSource(dtPrint);
            var u = new uReportViewer(cReport);
            u.WindowState = FormWindowState.Maximized;
            u.Show();

            System.IO.File.Delete(xsdFile);

            var i = 0;
            foreach (DataRow dr in dtPrint.Rows)
            {
                var cmd = Center.cmd;
                string sql = $"INSERT INTO PrintStatus (JobBarcode, DocNo, EmpCode, IsPrint) VALUES('{dr["JobBarcode"]}', '{dr["DocNo"]}', '{dr["EmpCode"]}', 1)";
                cmd.CommandText = sql;
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();
                i = cmd.ExecuteNonQuery();
            }
        }

        private void SelectedForm_Load(object sender, EventArgs e)
        {
            string[] columnOrder = { "DocNo", "JobBarcode", "OrderNo", "ListNo", "EmpCode", "EmpName", "pass_date", "pass_ok", "ID", "IsPrint", "Selected", "JobDate", "DueDate", "UserName", "CustCode" };

            DataTable dt2 = SwapColumns(dtPrint, columnOrder);
            foreach (DataRow dataRow in dtPrint.Rows)
            {
                DataRow newRow = dt2.NewRow();
                foreach (string colName in columnOrder)
                {
                    newRow[colName] = dataRow[colName];
                }
                dt2.Rows.Add(newRow);
            }

            dgv.DataSource = dt2;

            foreach (DataGridViewColumn col in dgv.Columns)
            {
                //Console.WriteLine(col.Name);
            }

            dgv.Columns["ID"].Visible = false;
            dgv.Columns["isPrint"].Visible = false;
            dgv.Columns["Selected"].Visible = false;
            dgv.Columns["JobDate"].Visible = false;
            dgv.Columns["DueDate"].Visible = false;
            dgv.Columns["UserName"].Visible = false;
            dgv.Columns["CustCode"].Visible = false;

            dgv.Columns["DocNo"].HeaderText = "เลขที่เอกสาร";
            dgv.Columns["JobBarcode"].HeaderText = "รหัสรับงานช่าง";
            dgv.Columns["OrderNo"].HeaderText = "Order No.";
            dgv.Columns["ListNo"].HeaderText = "ลำดับที่";
            dgv.Columns["EmpCode"].HeaderText = "รหัสช่าง";
            dgv.Columns["EmpName"].HeaderText = "ชื่อช่าง";
            dgv.Columns["pass_date"].HeaderText = "วันที่ตรวจออก";
            dgv.Columns["pass_ok"].HeaderText = "สถานะตรวจออก";

            dgv.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 14);
            dgv.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 14);
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv.AllowUserToAddRows = false;
        }

        private DataTable SwapColumns(DataTable dt, string[] colOrder)
        {
            DataTable dataTable = new DataTable();

            foreach (string colName in colOrder)
            {
                if (dt.Columns.Contains(colName))
                {
                    dataTable.Columns.Add(colName, dt.Columns[colName].DataType);
                }
            }

            return dataTable;
        }
    }
}
