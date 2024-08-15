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
        DataTable _ListPrint;
        DataTable _EditStatus;
        DataTable dt = new DataTable();
        public uCheckPass()
        {
            InitializeComponent();
            previewBtn.Visible = false;
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

        private DataTable dtPrint
        {
            get
            {
                if (_ListPrint == null)
                {
                    _ListPrint = new DataTable();
                    _ListPrint = dt.Clone();
                    _ListPrint.TableName = "Print";
                }
                return _ListPrint;
            }
        }

        private DataTable dtEditStatus
        {
            get
            {
                if(_EditStatus == null)
                {
                    _EditStatus = new DataTable();
                    _EditStatus = dt.Clone();
                    _EditStatus.TableName = "Edit";
                }
                return _EditStatus;
            }
        }

        void SetPrint(DataTable dt)
        {

        }
        private void previewBtn_Click(object sender, EventArgs e)
        {
            //var dt = ((DataTable)dataGridView1.DataSource).Clone();
            //var dv = new DataView((DataTable)dataGridView1.DataSource);
            //dv.RowFilter = "Selected = true";
            //foreach (DataRow dataRow in dv.ToTable().Rows)
            //{
            //    var drNew = dt.NewRow();
            //    drNew.ItemArray = dataRow.ItemArray;
            //    dt.Rows.Add(drNew);
            //}

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
                Console.WriteLine($"{item.JobName}, จำนวนครั้งที่ปรากฏ: {item.Count}");
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

            btnCustom2_Click(null, null);
        }

        private void uCheckPass_Load(object sender, EventArgs e)
        {
            Global.Combo.Load(cboStatus, typeof(AppSetting.ePassStatus));
            Global.Combo.Load(cboJobName, new DataObject.JobType(), AppSetting.eComboList.All);
        }

        private void btnCustom2_Click(object sender, EventArgs e)
        {
            var fWHERE = "WHERE IsPrint IS NULL";
            if (!checkBox1.Checked)
                fWHERE = "WHERE IsPrint IS NOT NULL";
            if (Convert.ToInt16(cboStatus.SelectedValue) == (int)AppSetting.ePassStatus.All)
                fWHERE += " AND JobHead.mDate BETWEEN @DateStart AND @DateEnd";
            else if (Convert.ToInt16(cboStatus.SelectedValue) == (int)AppSetting.ePassStatus.NotPass)
                fWHERE += " AND JobHead.mDate BETWEEN @DateStart AND @DateEnd AND JobDetail.pass_date IS NULL";
            else
                fWHERE += " AND JobDetail.pass_date BETWEEN @DateStart AND @DateEnd";

            if (!string.IsNullOrEmpty(txtEmpCode.Texts))
                fWHERE += $" AND JobHead.EmpCode = '{txtEmpCode.Texts}'";
            if (!string.IsNullOrEmpty(txtOrderNo.Texts))
                fWHERE += $" AND JobDetail.OrderNo = '{txtOrderNo.Texts}'";
            if (Convert.ToInt16(cboJobName.SelectedValue) != 0)
                fWHERE += $" AND JobHead.JobType = {cboJobName.SelectedValue}";

            Center.cmd.CommandText = $"SELECT JobHead.JobName, JobDetail.CustCode, JobDetail.OrderNo, JobDetail.ListNo, JobHead.EmpCode, JobHead.EmpName, JobHead.DocNo, JobDetail.JobBarcode" +
                $", JobDetail.pass_date, JobHead.JobDate, JobHead.DueDate, JobDetail.UserName, CASE WHEN JobDetail.pass_ok = 0 THEN 'ยังไม่ได้ตรวจออก' ELSE 'ตรวจออกแล้ว' END AS pass_ok, IsPrint, ID" +
                $" FROM JobHead LEFT JOIN JobDetail ON JobHead.DocNo = JobDetail.DocNo AND JobHead.EmpCode = JobDetail.EmpCode" +
                $" LEFT JOIN PrintStatus ON JobHead.DocNo = PrintStatus.DocNo AND JobHead.EmpCode = PrintStatus.EmpCode AND JobDetail.JobBarcode = PrintStatus.JobBarcode" +
                $" {fWHERE}" +
                $" ORDER BY JobHead.JobType, JobHead.DocNo";

            Center.AddParameter(Center.cmd, nameof(DateStart), DateStart.Value.Date);
            Center.AddParameter(Center.cmd, nameof(DateEnd), DateEnd.Value.Date.AddDays(1).AddSeconds(-1));

            dt = Center.Execute(Center.cmd.CommandText);
            dt.Columns.Add(cSelected.DataPropertyName, typeof(bool));
            bool areEqual = false;
            foreach (DataRow dataRow in dt.Rows)
            {
                dataRow[cSelected.DataPropertyName] = false;
                foreach (DataRow dataRow1 in dtPrint.Rows)
                {
                    areEqual = dataRow1.ItemArray.SequenceEqual(dataRow.ItemArray);
                    if (areEqual)
                    {
                        dataRow[cSelected.DataPropertyName] = true;
                        break;
                    }
                }                
            }

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dt;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 14);
            dataGridView1.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 14);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            previewBtn.Enabled = checkBox1.Checked;
            btnDelete.Enabled = !checkBox1.Checked;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty)
            {
                if (dataGridView1.CurrentRow.Cells[cSelected.Name].Value != DBNull.Value)
                    dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
                else
                    dataGridView1.CancelEdit();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var i = 0;
            foreach (DataRow dr in dtPrint.Rows)
            {
                var cmd = Center.cmd;
                string sql = $"DELETE FROM PrintStatus WHERE ID = {dr[cID.DataPropertyName]}";
                cmd.CommandText = sql;
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();
                i = cmd.ExecuteNonQuery();
            }
            dataGridView1.Refresh();
            btnCustom2_Click(null, null);

        }

        private void btnCustom1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnCustom1_Click(object sender, EventArgs e)
        {
            SelectedForm form = new SelectedForm(dtPrint);
            form.Show();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;
            if (dataGridView1.Columns[e.ColumnIndex].Name != dataGridView1.Columns[cSelected.Index].Name) return;

            bool isChecked = (bool)dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            bool areEqual = false;
            var newRow = ((DataRowView)(dataGridView1.Rows[e.RowIndex].DataBoundItem)).Row;

            DataTable dt = dtPrint.Clone();
            var dr = dt.NewRow();
            dr.ItemArray = newRow.ItemArray;
            dt.Rows.Add(dr);
            dt.Rows[0]["Selected"] = false;

            if (!btnDelete.Enabled)
            {
                if (isChecked)
                {
                    foreach (DataRow dataRow in dtPrint.Rows)
                    {
                        areEqual = dataRow.ItemArray.SequenceEqual(dt.Rows[0].ItemArray);
                        if (areEqual)
                            break;
                    }
                    if (!areEqual)
                    {
                        var drNew = dtPrint.NewRow();
                        drNew.ItemArray = dt.Rows[0].ItemArray;
                        dtPrint.Rows.Add(drNew);
                        Console.WriteLine($"Add Data | {newRow["Selected"]}");
                    }
                }
                else
                {
                    for (int i = dtPrint.Rows.Count - 1; i >= 0; i--)
                    {
                        areEqual = dtPrint.Rows[i].ItemArray.SequenceEqual(dt.Rows[0].ItemArray);
                        if (areEqual)
                        {
                            dtPrint.Rows[i].Delete();
                            Console.WriteLine("Delete Data");
                        }
                    }
                }
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dataGridViewRow in dataGridView1.Rows)
            {
                dataGridViewRow.Cells[0].Value = chkAll.Checked;
            }
        }
    }
}
