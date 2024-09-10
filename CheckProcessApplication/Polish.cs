using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Data;
using System.Windows.Forms;
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
            var WHERE = $"WHERE Inv_No = '{txtInvoice.Texts.Trim()}'";
            var AND = $"AND Inv_No = '{txtInvoice.Texts.Trim()}'";

            Center.cmd.CommandText = $@"WITH PolishData AS
                                        (SELECT AccEmp.EmpCode, JobHead.EmpName, AccEmp.Inv_No, AccEmp.DocNo, AccEmp2.JobBarCode, JobHead.JobDate,
                                        CASE WHEN LEFT(JobDetail.Article, 1) = 'B' OR CProfile.TdesArt LIKE '%ทองเหลือง%' THEN 'ทองเหลือง' ELSE '' END AS TypeOfWork,
                                        CASE WHEN JobHead.ChkReturn = 0 AND JobHead.ChkAccount = 1 THEN 'ซ่อม' ELSE '' END AS TypeOfBill,
                                        CASE WHEN (SELECT MIN(JobKeep.mDate) FROM JobKeep WHERE JobKeep.DocNo = AccEmp.DocNo {AND}) > DATEADD(DAY, 10, JobHead.JobDate) THEN 'YES' ELSE '' END AS Late,
                                        CASE WHEN EXISTS (SELECT Accemp.Inv_No, Jobkeeps.TtQty, Jobdetail.TtQty, JobKeep.Num FROM JobKeep JobKeep LEFT JOIN (SELECT DocNo, EmpCode, JobBarcode, mdate, TtQty, Num FROM JobKeep) AS JobKeeps ON AccEmp.DocNo = JobKeeps.DocNo AND AccEmp.EmpCode = JobKeeps.EmpCode LEFT JOIN JobDetail ON AccEmp.DocNo = JobDetail.DocNo AND AccEmp.EmpCode = JobDetail.EmpCode WHERE JobKeeps.DocNo = AccEmp.DocNo AND JobKeeps.TtQty < 0.7 * JobDetail.TtQty  AND JobKeeps.Num = 1 {AND}) THEN 'YES' ELSE '' END AS Less,
                                        CASE WHEN (SELECT MIN(JobKeep.mDate) FROM JobKeep WHERE JobKeep.DocNo = AccEmp.DocNo {AND}) > DATEADD(DAY, 10, JobHead.JobDate) OR EXISTS (SELECT Accemp.Inv_No, Jobkeeps.TtQty, Jobdetail.TtQty, JobKeep.Num FROM JobKeep JobKeep LEFT JOIN (SELECT DocNo, EmpCode, JobBarcode, mdate, TtQty, Num FROM JobKeep) AS JobKeeps ON AccEmp.DocNo = JobKeeps.DocNo AND AccEmp.EmpCode = JobKeeps.EmpCode LEFT JOIN JobDetail ON AccEmp.DocNo = JobDetail.DocNo AND AccEmp.EmpCode = JobDetail.EmpCode WHERE JobKeeps.DocNo = AccEmp.DocNo AND JobKeeps.TtQty < 0.7 * JobDetail.TtQty  AND JobKeeps.Num = 1 {AND}) THEN CAST((JobDetail.PriceJob * FLOOR(AccEmp2.OKQty)) / 2 AS DECIMAL(18, 2)) ELSE null END AS LateFee,
                                        CASE WHEN ISNULL(AccEmp2.AccPrice, 0) > ISNULL(JobCost.Cost3, 0) THEN 'ไม่ถูกต้อง' ELSE '' END AS CenterAcc,
                                        CASE WHEN ISNULL(AccEmp.DMWG, 0) + ISNULL(AccEmp.LSWG, 0) + ISNULL(AccEmp.LSGemAmount, 0) + ISNULL(AccEmp.DMGemAmount, 0) + ISNULL(DeductAmount.Deduct, 0) > 500 THEN 'ไม่ถูกต้อง' ELSE '' END AS DeductLost,
                                        CASE WHEN (case when CTE_ChkBrass.ChkBrass = 1 then 0 - isnull(CTE_JobGemDetail.GemWg, 0) else (AccEmp2.OKWG + isnull(V_JobMaterial_Sum.MatRecWg, 0) + isnull(JobBills.RtWg, 0) + JobBills.Silver + (FLOOR((((AccEmp2.OKWG - (JobDetail.MatWg + JobDetail.MatWg2)) * JobDetail.DMPercent) / 100) * 100) / 100)) - (JobDetail.Ttlwg + JobDetail.MatWg + JobDetail.MatWg2 + isnull(CTE_JobGemDetail.GemWg, 0)) END) > (case when CTE_ChkBrass.ChkBrass = 1 then 0 else FLOOR((((AccEmp2.OKWG - (JobDetail.MatWg + JobDetail.MatWg2)) * JobDetail.DMPercent) / 100) * 100) / 100 END) THEN 'ไม่ถูกต้อง' ELSE '' END AS DiffWg,
                                        CASE WHEN ISNULL(AccEmp.EmpAmount, 0) + ISNULL(AccEmp.ISAAmount, 0) <> ISNULL(JobDetail.PriceJob, 0) * ISNULL(SUM(CASE WHEN AccEmp2.OKQty = 0.5 THEN 0.5 ELSE CASE WHEN TEmpProfile.TitleName = 'บริษัท' THEN AccEmp2.OKQty ELSE FLOOR(AccEmp2.OKQty) END END) OVER (PARTITION BY AccEmp2.DocNo, AccEmp2.EmpCode), 0) - (ISNULL(AccEmp.DMWG ,0) + ISNULL(AccEmp.LSWG, 0) + ISNULL(AccEmp.LSGemAmount, 0) + ISNULL(AccEmp.DMGemAmount, 0) + case when ISNULL(AccEmp.DeductAmount, 0) = ISNULL(AccEmp.ISAAmount, 0) then ISNULL(AccEmp.DeductAmount, 0) else ISNULL(AccEmp.DeductAmount, 0) + ISNULL(AccEmp.ISAAmount, 0) end) THEN 'ค่าแรงไม่ถูกต้อง' ELSE '' END AS Wage,
                                        CAST(ISNULL(JobDetail.Ttlwg, 0) - (ISNULL(JobDetail.MatWg, 0) + ISNULL(JobDetail.MatWg2, 0)) - (ISNULL(AccEmp.ISSWG, 0) - (ISNULL(V_JobMaterial_NoSum.MatWg, 0) + ISNULL(V_JobMaterial_NoSum.MatWg2, 0))) AS DECIMAL(18, 2)) AS DiffWg1,
                                        CAST(ISNULL(JobDetail.MatWg, 0) + ISNULL(JobDetail.MatWg2, 0) - (ISNULL(V_JobMaterial_NoSum.MatWg, 0) + ISNULL(V_JobMaterial_NoSum.MatWg2, 0)) AS DECIMAL(18, 2)) AS DiffMat1,
                                        CAST(SUM((ISNULL(AccEmp2.OKWG, 0) + ISNULL(V_JobMaterial_NoSum.MatRecWg, 0) + ISNULL(JobBills.RtWg, 0) + ISNULL(JobBills.Silver, 0) + (FLOOR((((ISNULL(AccEmp2.OKWG, 0) - (ISNULL(JobDetail.MatWg, 0) + ISNULL(JobDetail.MatWg2, 0))) * ISNULL(JobDetail.DMPercent, 0)) / 100) *100) /100)) - (ISNULL(AccEmp2.OKWG, 0) + ISNULL(V_JobMaterial_NoSum.MatRecWg, 0) + ISNULL(JobBills.RtWg, 0) + ISNULL(JobBills.Silver, 0) + (FLOOR((((ISNULL(AccEmp2.OKWG, 0) - (ISNULL(JobDetail.MatWg, 0) + ISNULL(JobDetail.MatWg2, 0))) * ISNULL(JobDetail.DMPercent, 0)) / 100) *100) /100))) OVER() AS DECIMAL(18, 2)) AS DiffWg2,
                                        CAST(ISNULL(V_JobMaterial_NoSum.MatRecWg, 0) - ISNULL(V_JobMaterial_NoSum.MatRecWg, 0) AS DECIMAL(18, 2)) AS DiffMat2,
                                        CAST((SUM(ISNULL(AccEmp2.OKWG, 0) + ISNULL(V_JobMaterial_NoSum.MatRecWg, 0) + ISNULL(JobBills.RtWg, 0) + ISNULL(JobBills.Silver, 0) + (FLOOR((((ISNULL(AccEmp2.OKWG, 0) - (ISNULL(JobDetail.MatWg, 0) + ISNULL(JobDetail.MatWg2, 0))) * ISNULL(JobDetail.DMPercent, 0)) / 100) * 100) / 100)) OVER () - SUM(ISNULL(JobDetail.TtlWg, 0) + ISNULL(JobDetail.MatWg, 0) + ISNULL(JobDetail.MatWg2, 0)) OVER ()) AS DECIMAL(18, 2)) AS DiffTTWg,
                                        CAST(((CAST(SUM(ISNULL(AccEmp2.OKWG, 0) + ISNULL(V_JobMaterial_NoSum.MatRecWg, 0) + ISNULL(JobBills.RtWg, 0) + ISNULL(JobBills.Silver, 0) + FLOOR(((ISNULL(AccEmp2.OKWG, 0) - (ISNULL(JobDetail.MatWg, 0) + ISNULL(JobDetail.MatWg2, 0))) * ISNULL(JobDetail.DMPercent, 0) / 100) * 100 / 100)) OVER () - (SUM(ISNULL(JobDetail.TtlWg, 0) + ISNULL(JobDetail.MatWg, 0) + ISNULL(JobDetail.MatWg2, 0)) OVER ()) AS DECIMAL(18, 2))) / NULLIF(SUM(ISNULL(JobDetail.TtlWg, 0) + ISNULL(JobDetail.MatWg, 0) + ISNULL(JobDetail.MatWg2, 0)) OVER (), 0) * 100) AS DECIMAL(5, 2)) AS PerDiffTTWg,
                                        SUM((ISNULL(JobDetail.PriceJob, 0) * CASE WHEN AccEmp2.OKQty = 0.5 THEN 0.5 ELSE CASE WHEN TEmpProfile.TitleName = 'บริษัท' THEN AccEmp2.OKQty ELSE FLOOR(AccEmp2.OKQty) END END ) - (ISNULL(AccEmp.DMWG, 0) + ISNULL(AccEmp.LSWG, 0) + ISNULL(AccEmp.DMGemAmount, 0) + ISNULL(AccEmp.LSGemAmount, 0) + ISNULL(AccEmp.DeductAmount, 0))) OVER () AS NetWage
                                        FROM (SELECT * FROM AccEmp {WHERE}) AS AccEmp
                                        LEFT JOIN AccEmp2 ON AccEmp.DocNo = AccEmp2.DocNo AND AccEmp.EmpCode = AccEmp2.EmpCode
                                        LEFT JOIN JobDetail ON AccEmp.DocNo = JobDetail.DocNo AND AccEmp.EmpCode = JobDetail.EmpCode AND AccEmp2.JobBarCode = JobDetail.JobBarcode
                                        LEFT JOIN JobHead ON AccEmp.DocNo = JobHead.DocNo AND AccEmp.EmpCode = JobHead.EmpCode
                                        LEFT JOIN V_JobMaterial_Sum ON AccEmp.DocNo = V_JobMaterial_Sum.DocNo AND AccEmp.EmpCode = V_JobMaterial_Sum.EmpCode
                                        LEFT JOIN V_JobMaterial_NoSum on AccEmp.DocNo = V_JobMaterial_NoSum.DocNo AND AccEmp.EmpCode = V_JobMaterial_NoSum.EmpCode
                                        LEFT JOIN CProfile ON JobDetail.Article = CProfile.Article AND JobDetail.ArtCode = CProfile.ArtCode
                                        LEFT JOIN (SELECT DocNo, EmpCode, JobBarcode, mdate, TtQty FROM JobKeep) AS JobKeeps ON AccEmp.DocNo = JobKeeps.DocNo AND AccEmp.EmpCode = JobKeeps.EmpCode AND AccEmp2.JobBarCode = JobKeeps.JobBarcode
                                        LEFT JOIN JobCost ON JobDetail.OrderNo = JobCost.Orderno AND JobDetail.LotNo = JobCost.LotNo 
										LEFT JOIN (SELECT DocNo, EmpCode, Silver, SUM(OKTtl) AS OKTtl, SUM(RtWg) AS RtWg FROM JobBill GROUP BY DocNo, EmpCode, Silver) AS JobBills ON AccEmp.DocNo = JobBills.DocNo AND AccEmp.EmpCode = JobBills.EmpCode
                                        LEFT JOIN PSKTran2 ON JobDetail.OrderNo = PSKTran2.Orderno AND JobDetail.LotNo = PSKTran2.LotNo AND JobDetail.Barcode = PSKTran2.Barcode
                                        LEFT JOIN (SELECT JobDetail.DocNo, JobDetail.EmpCode, JobDetail.JobBarcode, case when LEFT(JobDetail.Article, 1) = 'B' then 1 when LEFT(JobDetail.Article, 1) = 'Z' and CProfile.TDesArt LIKE '%ทองเหลือง%' then 1 else 0 end as ChkBrass from JobDetail left join CProfile on JobDetail.ArtCode = CProfile.ArtCode and JobDetail.Article = CProfile.Article) AS CTE_ChkBrass on CTE_ChkBrass.DocNo = AccEmp2.DocNo and CTE_ChkBrass.EmpCode = AccEmp2.EmpCode and CTE_ChkBrass.JobBarcode = AccEmp2.JobBarCode
										LEFT JOIN (SELECT JobDetail.DocNo, JobDetail.EmpCode, JobDetail.JobBarcode, sum(JobGemDetail.JobQty) AS GemQty, sum(JobGemDetail.JobWg) AS GemWg, sum(JobGemDetail.PerProduct * JobDetail.TtQty) AS GemPerProduct from JobGemDetail left join JobDetail on JobGemDetail.DocNo = JobDetail.DocNo and JobGemDetail.EmpCode = JobDetail.EmpCode and JobGemDetail.JobBarcode = JobDetail.JobBarcode group by JobDetail.DocNo, JobDetail.EmpCode, JobDetail.JobBarcode) AS CTE_JobGemDetail on AccEmp2.DocNo = CTE_JobGemDetail.DocNo and AccEmp2.EmpCode = CTE_JobGemDetail.EmpCode and AccEmp2.JobBarCode = CTE_JobGemDetail.JobBarcode
                                        LEFT JOIN TEmpProfile on AccEmp2.EmpCode = TEmpProfile.EmpCode
                                        LEFT JOIN (SELECT DocNo, EmpCode, CASE WHEN DeductAmount = ISAAmount THEN DeductAmount WHEN DeductAmount <> ISAAmount THEN ISAAmount + DeductAmount WHEN DeductAmount = 0 and ISAAmount <> 0 THEN ISAAmount WHEN DeductAmount <> 0 and ISAAmount = 0 THEN DeductAmount ELSE 0 END AS Deduct FROM AccEmp) AS DeductAmount on DeductAmount.DocNo = AccEmp.DocNo and DeductAmount.EmpCode = AccEmp.EmpCode
	                                    GROUP BY AccEmp.EmpCode, JobHead.EmpName, AccEmp.Inv_No, AccEmp.DocNo, AccEmp2.JobBarCode, JobHead.JobDate, LEFT(JobDetail.Article, 1), CProfile.TdesArt, JobHead.ChkReturn, JobHead.ChkAccount, JobDetail.PriceJob, AccEmp2.OKQty, AccEmp2.AccPrice, JobCost.Cost3, AccEmp2.OKWG, V_JobMaterial_Sum.MatWg, V_JobMaterial_Sum.MatWg2, V_JobMaterial_NoSum.MatWg, V_JobMaterial_NoSum.MatWg2, V_JobMaterial_NoSum.MatRecWg, AccEmp.DMWG, AccEmp.LSWG, AccEmp.DMGemAmount, AccEmp.LSGemAmount, AccEmp.DeductAmount, AccEmp.EmpAmount, AccEmp.ISAAmount, AccEmp.ISSWG, JobDetail.Ttlwg, JobDetail.Matwg, JobDetail.Matwg2, JobBills.RtWg, JobBills.Silver, JobDetail.DMPercent, AccEmp2.DocNo, AccEmp2.EmpCode, AccEmp.GemRepeat, CTE_ChkBrass.ChkBrass, CTE_JobGemDetail.GemWg, V_JobMaterial_Sum.MatRecWg, TEmpProfile.TitleName, DeductAmount.Deduct
                                        ) 
                                        SELECT DENSE_RANK() OVER (ORDER BY DocNo) AS [ลำดับที่], EmpCode, EmpName, Inv_No, DocNo, JobBarCode, JobDate, TypeOfWork, TypeOfBill, Late, Less, LateFee, CenterAcc, DeductLost, DiffWg, Wage, DiffWg1, DiffMat1, DiffWg2, DiffMat2, DiffTTWg, PerDiffTTWg, NetWage FROM PolishData;";

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
            cReport.Load($"\\\\factoryserver\\BillingScrip\\Reports\\PolishReport.rpt");
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
