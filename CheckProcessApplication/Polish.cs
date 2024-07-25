using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;
using WindowsFormsApp2;


namespace CheckProcessApplication
{
    public partial class Polish : Form
    {
        public Polish()
        {
            InitializeComponent();
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
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }
        private void Search()
        {
            if (string.IsNullOrEmpty(txtInvoice.Texts)) { return; }
            var Where = $"WHERE Inv_No = '{txtInvoice.Texts.Trim()}'";

            Center.cmd.CommandText = $@"WITH RankedData AS (
                                            SELECT AccEmp.EmpCode, JobHead.EmpName, AccEmp.Inv_No, AccEmp.DocNo, AccEmp2.JobBarCode, JobHead.JobDate,
                                                CASE WHEN LEFT(JobDetail.Article, 1) = 'B' OR CProfile.TdesArt LIKE '%ทองเหลือง%' THEN 'ทองเหลือง' ELSE '' END AS TypeOfWork,
                                                CASE WHEN JobHead.ChkReturn = 0 AND JobHead.ChkAccount = 1 THEN 'ซ่อม' ELSE '' END AS TypeOfBill,
                                                CASE WHEN (SELECT MIN(JobKeep.mDate) FROM JobKeep WHERE JobKeep.DocNo = AccEmp.DocNo) > DATEADD(DAY, 10, JobHead.JobDate) THEN 'YES' ELSE '' END AS Late,
                                                CASE WHEN EXISTS (SELECT 1 FROM JobKeep WHERE JobKeep.DocNo = AccEmp.DocNo AND JobKeep.TtQty < 0.7 * JobKeep.TtQty AND JobKeep.mDate < DATEADD(DAY, 13, JobDate) AND JobKeep.Num = 1) THEN 'YES' ELSE '' END AS Less,
                                                CASE WHEN (SELECT MIN(JobKeep.mDate) FROM JobKeep WHERE JobKeep.DocNo = AccEmp.DocNo) > DATEADD(DAY, 10, JobHead.JobDate) OR EXISTS (SELECT 1 FROM JobKeep WHERE JobKeep.DocNo = AccEmp.DocNo AND JobKeep.TtQty < 0.7 * JobDetail.TtQty AND JobKeep.mDate < DATEADD(DAY, 13, JobHead.JobDate) AND JobKeep.Num = 1) THEN CAST((JobDetail.PriceJob * FLOOR(AccEmp2.OKQty)) / 2 AS DECIMAL) ELSE 0 END AS LateFee,
                                                CASE WHEN ISNULL(JobDetail.PriceJob, 0) > ISNULL(JobCost.Cost3, 0) THEN 'ไม่ถูกต้อง' ELSE '' END AS CenterAcc,
                                                CASE WHEN ISNULL(AccEmp2.OKWG, 0) > ISNULL(AccEmp2.OKWG, 0) + ((ISNULL(AccEmp2.OKWG, 0) - (ISNULL(V_JobMaterial_Sum.MatWg, 0) + ISNULL(V_JobMaterial_Sum.MatWg2, 0))) / 100) THEN 'ไม่ถูกต้อง' ELSE '' END AS DeductLost,
                                                CASE WHEN ISNULL(AccEmp.DMWG, 0) + ISNULL(AccEmp.LSWG, 0) + ISNULL(AccEmp.DMGemAmount, 0) + ISNULL(AccEmp.LSGemAmount, 0) > 500 THEN CAST(ISNULL(AccEmp.DMWG, 0) + ISNULL(AccEmp.LSWG, 0) + ISNULL(AccEmp.DMGemAmount, 0) + ISNULL(AccEmp.LSGemAmount, 0) AS DECIMAL) ELSE 0 END AS DiffWg,
                                                CASE WHEN ISNULL(AccEmp.EmpAmount, 0) + ISNULL(AccEmp.ISAAmount, 0) <> (ISNULL(JobDetail.PriceJob, 0) * FLOOR(ISNULL(AccEmp2.OKQty, 0)) - (ISNULL(AccEmp.DMWG, 0) + ISNULL(AccEmp.LSWG, 0) + ISNULL(AccEmp.DMGemAmount, 0) + ISNULL(AccEmp.LSGemAmount, 0) + ISNULL(AccEmp.DeductAmount, 0))) THEN 'ค่าแรงไม่ถูกต้อง' ELSE '' END AS Wage,
                                                CASE WHEN ISNULL(SUM(JobDetail.Ttlwg) OVER(), 0) - ( ISNULL(SUM(AccEmp.ISSWG) OVER(), 0) - ( ISNULL(SUM(V_JobMaterial_Sum.MatWg) OVER(), 0) + ISNULL(SUM(V_JobMaterial_Sum.MatWg2) OVER(), 0))) > 0 THEN CAST( ISNULL(SUM(JobDetail.Ttlwg) OVER(), 0) - ( ISNULL(SUM(AccEmp.ISSWG) OVER(), 0) - ( ISNULL(SUM(V_JobMaterial_Sum.MatWg) OVER(), 0) + ISNULL(SUM(V_JobMaterial_Sum.MatWg2) OVER(), 0))) AS DECIMAL(18, 2)) ELSE 0 END AS DiffWg1,
	                                            CASE WHEN ISNULL(SUM(JobDetail.Matwg) OVER(), 0) + ISNULL(SUM(JobDetail.Matwg2) OVER(), 0) - (ISNULL(SUM(AccEmp.ISSWG) OVER(), 0) - (ISNULL(SUM(V_JobMaterial_Sum.MatWg) OVER(), 0) + ISNULL(SUM(V_JobMaterial_Sum.MatWg2) OVER(), 0))) > 0 THEN CAST(ISNULL(SUM(JobDetail.Matwg) OVER(), 0) + ISNULL(SUM(JobDetail.Matwg2) OVER(), 0) - (ISNULL(SUM(AccEmp.ISSWG) OVER(), 0) - (ISNULL(SUM(V_JobMaterial_Sum.MatWg) OVER(), 0) + ISNULL(SUM(V_JobMaterial_Sum.MatWg2) OVER(), 0)))AS DECIMAL(18, 2)) ELSE 0 END AS DiffMat1,
	                                            CASE WHEN ISNULL(SUM(AccEmp2.OKWG) OVER(), 0) + ISNULL(SUM(JobBills.RtWg) OVER(), 0) + ISNULL(SUM(V_JobMaterial_Sum.MatRecWg) OVER(), 0) + ISNULL(SUM((AccEmp2.OKWG - (V_JobMaterial_Sum.MatWg + V_JobMaterial_Sum.MatWg2)) / 100) OVER(), 0) - ISNULL(SUM(AccEmp.OKWG) OVER(), 0) > 0 THEN CAST(ISNULL(SUM(AccEmp2.OKWG) OVER(), 0) + ISNULL(SUM(JobBills.RtWg) OVER(), 0) + ISNULL(SUM(V_JobMaterial_Sum.MatRecWg) OVER(), 0) + ISNULL(SUM((AccEmp2.OKWG - (V_JobMaterial_Sum.MatWg + V_JobMaterial_Sum.MatWg2)) / 100) OVER(), 0) - ISNULL(SUM(AccEmp.OKWG) OVER(), 0) AS DECIMAL(18, 2)) ELSE 0 END AS DiffWg2,
	                                            CASE WHEN ISNULL(SUM(PSKTran2.recwg) OVER(), 0) - ISNULL(SUM(V_JobMaterial_Sum.MatRecWg) OVER(), 0) > 0 THEN CAST(ISNULL(SUM(PSKTran2.recwg) OVER(), 0) - ISNULL(SUM(V_JobMaterial_Sum.MatRecWg) OVER(), 0) AS DECIMAL(18, 2))ELSE 0 END AS DiffMat2,
	                                            CASE WHEN ISNULL(SUM(AccEmp2.OKWG) OVER() + SUM(JobBills.RtWg) OVER() + SUM(V_JobMaterial_Sum.MatRecWg) OVER() + SUM((AccEmp2.OKWG - (V_JobMaterial_Sum.MatWg + V_JobMaterial_Sum.MatWg2)) / 100.0) OVER(), 0) - ISNULL(SUM(AccEmp.ISSWG) OVER(), 0) > 0 THEN CAST(ISNULL(SUM(AccEmp2.OKWG) OVER() + SUM(JobBills.RtWg) OVER() + SUM(V_JobMaterial_Sum.MatRecWg) OVER() + SUM((AccEmp2.OKWG - (V_JobMaterial_Sum.MatWg + V_JobMaterial_Sum.MatWg2)) / 100.0) OVER(), 0) - ISNULL(SUM(AccEmp.ISSWG) OVER(), 0) AS DECIMAL(18, 2)) ELSE 0 END AS DiffTTWg,
	                                            CASE WHEN ISNULL(SUM(AccEmp.ISSWG) OVER(), 0) > 0 THEN CAST((ISNULL(SUM(AccEmp2.OKWG) OVER() + SUM(JobBills.RtWg) OVER() + SUM(V_JobMaterial_Sum.MatRecWg) OVER() + SUM((AccEmp2.OKWG - (V_JobMaterial_Sum.MatWg + V_JobMaterial_Sum.MatWg2)) / 100.0) OVER(), 0) - ISNULL(SUM(AccEmp.ISSWG) OVER(), 0)) / CAST(ISNULL(SUM(AccEmp.ISSWG) OVER(), 0) AS DECIMAL(18, 2)) * 100 AS DECIMAL(18, 2)) ELSE 0 END AS PerDiffTTWg,
	                                            SUM((JobDetail.PriceJob * FLOOR(AccEmp2.OKQty)) - (AccEmp.DMWG + AccEmp.LSWG + AccEmp.DMGemAmount + AccEmp.LSGemAmount + AccEmp.DeductAmount)) OVER() AS NetWage
                                            FROM (SELECT * FROM AccEmp {Where}) AS AccEmp
                                            LEFT JOIN AccEmp2 ON AccEmp.DocNo = AccEmp2.DocNo AND AccEmp.EmpCode = AccEmp2.EmpCode
                                            LEFT JOIN JobDetail ON AccEmp.DocNo = JobDetail.DocNo AND AccEmp.EmpCode = JobDetail.EmpCode AND AccEmp2.JobBarCode = JobDetail.JobBarcode
                                            LEFT JOIN JobHead ON AccEmp.DocNo = JobHead.DocNo AND AccEmp.EmpCode = JobHead.EmpCode
                                            LEFT JOIN JobCost ON JobDetail.OrderNo = JobCost.Orderno AND JobDetail.LotNo = JobCost.LotNo AND JobDetail.Barcode = JobCost.Barcode
                                            LEFT JOIN V_JobMaterial_Sum ON AccEmp.DocNo = V_JobMaterial_Sum.DocNo AND AccEmp.EmpCode = V_JobMaterial_Sum.EmpCode
                                            LEFT JOIN CProfile ON JobDetail.Article = CProfile.Article AND JobDetail.ArtCode = CProfile.ArtCode
                                            LEFT JOIN (SELECT DocNo, EmpCode, JobBarcode, mdate, TtQty FROM JobKeep WHERE Num = '01') AS JobKeeps ON AccEmp.DocNo = JobKeeps.DocNo AND AccEmp.EmpCode = JobKeeps.EmpCode AND AccEmp2.JobBarCode = JobKeeps.JobBarcode
                                            LEFT JOIN (SELECT DocNo, EmpCode, SUM(OKTtl) AS OKTtl, SUM(RtWg) AS RtWg FROM JobBill GROUP BY DocNo, EmpCode) AS JobBills ON AccEmp.DocNo = JobBills.DocNo AND AccEmp.EmpCode = JobBills.EmpCode
                                            LEFT JOIN PSKTran2 ON JobDetail.OrderNo = PSKTran2.Orderno AND JobDetail.LotNo = PSKTran2.LotNo AND JobDetail.Barcode = PSKTran2.Barcode
                                        )   SELECT DENSE_RANK() OVER (ORDER BY DocNo) AS [ลำดับที่], EmpCode, EmpName, Inv_No, DocNo, JobBarCode, JobDate, TypeOfWork, TypeOfBill, Late, Less, LateFee, CenterAcc, DeductLost, DiffWg, Wage, DiffWg1, DiffMat1, DiffWg2, DiffMat2, DiffTTWg, PerDiffTTWg, NetWage
                                        FROM RankedData;";

            var dt = Center.Load();
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show($"ไม่พบข้อมูล Inv. {txtInvoice.Texts.Trim()}", "ERROR!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            cReport = new ReportDocument();
            DataSet ds = new DataSet();
            if (!ds.Tables.Contains(dt.TableName))
                ds.Tables.Add(dt.Copy());

            cReport.Load(@"C:\Users\admin\source\repos\CheckProcessApplication\CheckProcessApplication\Reports\PolishCrystalReport.rpt");
            ds.WriteXmlSchema(xsdFile);
            cReport.SetDataSource(dt);
            var u = new uReportViewer(cReport);
            u.WindowState = FormWindowState.Maximized;
            u.Show();

            System.IO.File.Delete(xsdFile);
        }

        private void txtInvoice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                Search();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
