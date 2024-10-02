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
                                        CASE WHEN minJobKeep.MINmDate > DATEADD(DAY, 10, JobHead.JobDate) THEN 'YES' ELSE '' END AS Late,
                                        COALESCE(LessJobkeep.Less, '') AS Less,
                                        CASE WHEN minJobKeep.MINmDate > DATEADD(DAY, 10, JobHead.JobDate) OR COALESCE(LessJobkeep.Less, '') = 'YES' THEN CAST((JobDetail.PriceJob * FLOOR(AccEmp2.OKQty)) / 2 AS DECIMAL(18, 2)) ELSE null END AS LateFee,
                                        CASE WHEN ISNULL(AccEmp2.AccPrice, 0) > ISNULL(JobCost.Cost3, 0) THEN 'ไม่ถูกต้อง' ELSE '' END AS CenterAcc,
                                        CASE WHEN ISNULL(AccEmp.DMWG, 0) + ISNULL(AccEmp.LSWG, 0) + ISNULL(AccEmp.LSGemAmount, 0) + ISNULL(AccEmp.DMGemAmount, 0) + ISNULL(DeductAmount.Deduct, 0) > 500 THEN 'ไม่ถูกต้อง' ELSE '' END AS DeductLost,
                                        CASE WHEN SUM(ISNULL(AccEmp2.OKWG, 0)) OVER (PARTITION BY AccEmp.DocNo, AccEmp.EmpCode) + ISNULL(JobBills.RtWg, 0) + ISNULL(JobBills.Silver, 0) + ISNULL(V_JobMaterial_Sum.MatRecWg, 0) + SUM(ROUND(((((ISNULL(AccEmp2.OKWG, 0)) * ISNULL(JobDetail.DMPercent, 0)) / 100) * 100) / 100, 2)) OVER (PARTITION BY AccEmp.DocNo, AccEmp.EmpCode) - (SUM(JobDetail.Ttlwg) OVER (PARTITION BY AccEmp.DocNo, AccEmp.EmpCode) + ISNULL(V_JobMaterial_Sum.MatRecWg, 0) + ISNULL(CTE_JobGemDetail.GemWg, 0)) > SUM(ROUND(((((ISNULL(AccEmp2.OKWG, 0)) * ISNULL(JobDetail.DMPercent, 0)) / 100) * 100) / 100, 2)) OVER (PARTITION BY AccEmp.DocNo, AccEmp.EmpCode) THEN 'ไม่ถูกต้อง' ELSE '' END AS DiffWg,
                                        CASE WHEN CAST((ISNULL(AccEmp.EmpAmount, 0) + ISNULL(AccEmp.ISAAmount, 0)) AS DECIMAL(18, 2)) <> CAST(ISNULL(AccEmp2.AccPrice, 0) * SUM(CASE WHEN AccEmp2.OKQty = 0.5 THEN 0.5 ELSE CASE WHEN TEmpProfile.TitleName = 'บริษัท' THEN AccEmp2.OKQty ELSE FLOOR(AccEmp2.OKQty) END END) OVER (PARTITION BY AccEmp.DocNo, AccEmp.EmpCode) - (AccEmp.DMWG + AccEmp.LSWG + AccEmp.DMGemAmount + AccEmp.LSGemAmount + AccEmp.DeductAmount + AccEmp.ISAAmount) AS DECIMAL(18, 2)) THEN 'ค่าแรงไม่ถูกต้อง' ELSE '' END AS Wage,
                                        CASE WHEN LEFT(JobDetail.Article, 1) = 'B' OR CProfile.TdesArt LIKE '%ทองเหลือง%' THEN 0.00 ELSE COALESCE(CAST((SUM(ISNULL(JobDetail.Ttlwg, 0)) OVER(Partition By AccEmp.DocNo, AccEmp.EmpCode) - (SUM(ISNULL(JobDetail.MatWg, 0) + ISNULL(JobDetail.MatWg2, 0)) OVER(Partition By AccEmp.DocNo, AccEmp.EmpCode))) - (ISNULL(AccEmp.ISSWG, 0) - (ISNULL(V_JobMaterial_Sum.MatWg, 0) + ISNULL(V_JobMaterial_Sum.MatWg2, 0))) AS DECIMAL(18, 2)), 0.00) END AS RawDiffWg1,
                                        CAST(SUM(ISNULL(JobDetail.MatWg, 0) + ISNULL(JobDetail.MatWg2, 0)) OVER(Partition By AccEmp.DocNo) - (ISNULL(V_JobMaterial_Sum.MatWg, 0) + ISNULL(V_JobMaterial_Sum.MatWg2, 0)) AS DECIMAL(18, 2)) AS RawDiffMat1,
                                        CAST(SUM((ISNULL(AccEmp2.OKWG, 0) + ISNULL(V_JobMaterial_Sum.MatRecWg, 0) + ISNULL(JobBills.RtWg, 0) + ISNULL(JobBills.Silver, 0) + (FLOOR((((ISNULL(AccEmp2.OKWG, 0) - (ISNULL(JobDetail.MatWg, 0) + ISNULL(JobDetail.MatWg2, 0))) * ISNULL(JobDetail.DMPercent, 0)) / 100) *100) /100)) - (ISNULL(AccEmp2.OKWG, 0) + ISNULL(V_JobMaterial_Sum.MatRecWg, 0) + ISNULL(JobBills.RtWg, 0) + ISNULL(JobBills.Silver, 0) + (FLOOR((((ISNULL(AccEmp2.OKWG, 0) - (ISNULL(JobDetail.MatWg, 0) + ISNULL(JobDetail.MatWg2, 0))) * ISNULL(JobDetail.DMPercent, 0)) / 100) *100) /100))) OVER() AS DECIMAL(18, 2)) AS DiffWg2,
                                        CAST(SUM(ISNULL(V_JobMaterial_Sum.MatRecWg, 0) - ISNULL(V_JobMaterial_Sum.MatRecWg, 0)) OVER() AS DECIMAL(18, 2)) AS DiffMat2,
                                        CASE WHEN CTE_ChkBrass.ChkBrass = 1 THEN 0 - ISNULL(CTE_JobGemDetail.GemWg, 0) ELSE SUM(ISNULL(AccEmp2.OKWG, 0)) OVER (PARTITION BY AccEmp.DocNo, AccEmp.EmpCode) + ISNULL(JobBills.RtWg, 0) + ISNULL(JobBills.Silver, 0) + ISNULL(V_JobMaterial_Sum.MatRecWg, 0) + SUM(ROUND(((((ISNULL(AccEmp2.OKWG, 0)) * ISNULL(JobDetail.DMPercent, 0)) / 100) * 100) / 100, 2)) OVER (PARTITION BY AccEmp.DocNo, AccEmp.EmpCode) - (SUM(JobDetail.Ttlwg) OVER (PARTITION BY AccEmp.DocNo, AccEmp.EmpCode) + ISNULL(V_JobMaterial_Sum.MatRecWg, 0) + ISNULL(CTE_JobGemDetail.GemWg, 0)) END AS DiffTWg,
                                        CAST(CASE WHEN CTE_ChkBrass.ChkBrass = 1 THEN 0 - ISNULL(CTE_JobGemDetail.GemWg, 0) ELSE CASE WHEN CTE_ChkBrass.ChkBrass = 1 THEN 0 - ISNULL(CTE_JobGemDetail.GemWg, 0) ELSE SUM(ISNULL(AccEmp2.OKWG, 0)) OVER (PARTITION BY AccEmp.DocNo, AccEmp.EmpCode) + ISNULL(JobBills.RtWg, 0) + ISNULL(JobBills.Silver, 0) + ISNULL(V_JobMaterial_Sum.MatRecWg, 0) + SUM(ROUND(((((ISNULL(AccEmp2.OKWG, 0)) * ISNULL(JobDetail.DMPercent, 0)) / 100) * 100) / 100, 2)) OVER (PARTITION BY AccEmp.DocNo, AccEmp.EmpCode) - (SUM(JobDetail.Ttlwg) OVER (PARTITION BY AccEmp.DocNo, AccEmp.EmpCode) + ISNULL(V_JobMaterial_Sum.MatRecWg, 0) + ISNULL(CTE_JobGemDetail.GemWg, 0)) END / NULLIF(SUM(ISNULL(JobDetail.TtlWg, 0) + ISNULL(V_JobMaterial_Sum.MatRecWg, 0) + ISNULL(JobGemDetail.JobWg, 0)) OVER (), 0) END * 100 AS DECIMAL(18, 2)) AS RawPerDiffTTWg,
                                        CAST(ISNULL(AccEmp2.AccPrice, 0) * SUM(CASE WHEN AccEmp2.OKQty = 0.5 THEN 0.5 ELSE CASE WHEN TEmpProfile.TitleName = 'บริษัท' THEN AccEmp2.OKQty ELSE FLOOR(AccEmp2.OKQty) END END) OVER (PARTITION BY AccEmp.DocNo, AccEmp.EmpCode) - (AccEmp.DMWG + AccEmp.LSWG + AccEmp.DMGemAmount + AccEmp.LSGemAmount + AccEmp.DeductAmount) AS DECIMAL(18, 2)) AS NormalEmpAmount
                                        FROM (SELECT * FROM AccEmp {WHERE}) AS AccEmp
                                        LEFT JOIN AccEmp2 ON AccEmp2.DocNo = AccEmp.DocNo AND AccEmp2.EmpCode = AccEmp.EmpCode
                                        LEFT JOIN JobHead ON JobHead.DocNo = AccEmp2.DocNo AND JobHead.EmpCode = AccEmp2.EmpCode
                                        LEFT JOIN JobDetail ON JobDetail.DocNo = AccEmp2.DocNo AND JobDetail.EmpCode = AccEmp2.EmpCode AND JobDetail.JobBarcode = AccEmp2.JobBarCode
                                        LEFT JOIN CProfile ON CProfile.Article = JobDetail.Article AND CProfile.ArtCode = JobDetail.ArtCode
                                        LEFT JOIN (SELECT AccEmp.DocNo, MIN(JobKeep.mDate) AS MINmDate FROM JobKeep LEFT JOIN AccEmp on JobKeep.DocNo = AccEmp.DocNo AND JobKeep.EmpCode = AccEmp.EmpCode {WHERE} GROUP BY AccEmp.DocNo) AS minJobKeep ON minJobKeep.DocNo = AccEmp.DocNo
                                        LEFT JOIN (SELECT AccEmp.DocNo, AccEmp.EmpCode, 'YES' AS Less FROM AccEmp LEFT JOIN (SELECT DocNo, EmpCode, SUM(TtQty) AS TtQty, Num FROM JobKeep GROUP BY DocNo, EmpCode, Num) AS JobKeeps ON AccEmp.DocNo = JobKeeps.DocNo AND AccEmp.EmpCode = JobKeeps.EmpCode LEFT JOIN JobDetail ON AccEmp.DocNo = JobDetail.DocNo AND AccEmp.EmpCode = JobDetail.EmpCode WHERE JobKeeps.DocNo = AccEmp.DocNo AND JobKeeps.TtQty < 0.7 * JobDetail.TtQty AND JobKeeps.Num = 1 {AND}) LessJobkeep ON LessJobkeep.DocNo = AccEmp.DocNo AND LessJobkeep.EmpCode = AccEmp.EmpCode
                                        LEFT JOIN JobCost ON JobCost.OrderNo = JobDetail.Orderno AND JobCost.LotNo = JobDetail.LotNo
                                        LEFT JOIN (SELECT DocNo, EmpCode, CASE WHEN DeductAmount = ISAAmount THEN DeductAmount WHEN DeductAmount <> ISAAmount THEN ISAAmount + DeductAmount WHEN DeductAmount = 0 and ISAAmount <> 0 THEN ISAAmount WHEN DeductAmount <> 0 and ISAAmount = 0 THEN DeductAmount ELSE 0 END AS Deduct FROM AccEmp {WHERE}) AS DeductAmount on DeductAmount.DocNo = AccEmp.DocNo and DeductAmount.EmpCode = AccEmp.EmpCode
                                        LEFT JOIN (SELECT DocNo, EmpCode, Silver, SUM(OKTtl) AS OKTtl, SUM(RtWg) AS RtWg FROM JobBill GROUP BY DocNo, EmpCode, Silver) AS JobBills ON AccEmp.DocNo = JobBills.DocNo AND AccEmp.EmpCode = JobBills.EmpCode
                                        LEFT JOIN V_JobMaterial_Sum on V_JobMaterial_Sum.DocNo = AccEmp.DocNo AND V_JobMaterial_Sum.EmpCode = AccEmp.EmpCode
                                        LEFT JOIN (SELECT JobDetail.DocNo, JobDetail.EmpCode, JobDetail.JobBarcode, sum(JobGemDetail.JobQty) AS GemQty, sum(JobGemDetail.JobWg) AS GemWg, sum(JobGemDetail.PerProduct * JobDetail.TtQty) AS GemPerProduct from JobGemDetail left join JobDetail on JobGemDetail.DocNo = JobDetail.DocNo and JobGemDetail.EmpCode = JobDetail.EmpCode and JobGemDetail.JobBarcode = JobDetail.JobBarcode group by JobDetail.DocNo, JobDetail.EmpCode, JobDetail.JobBarcode) AS CTE_JobGemDetail on AccEmp2.DocNo = CTE_JobGemDetail.DocNo and AccEmp2.EmpCode = CTE_JobGemDetail.EmpCode and AccEmp2.JobBarCode = CTE_JobGemDetail.JobBarcode
                                        LEFT JOIN TEmpProfile on AccEmp2.EmpCode = TEmpProfile.EmpCode
                                        LEFT JOIN (SELECT JobDetail.DocNo, JobDetail.EmpCode, JobDetail.JobBarcode, case when LEFT(JobDetail.Article, 1) = 'B' then 1 when LEFT(JobDetail.Article, 1) = 'Z' and CProfile.TDesArt LIKE '%ทองเหลือง%' then 1 else 0 end as ChkBrass from JobDetail left join CProfile on JobDetail.ArtCode = CProfile.ArtCode and JobDetail.Article = CProfile.Article) AS CTE_ChkBrass on CTE_ChkBrass.DocNo = AccEmp2.DocNo and CTE_ChkBrass.EmpCode = AccEmp2.EmpCode and CTE_ChkBrass.JobBarcode = AccEmp2.JobBarCode
                                        LEFT JOIN (SELECT DocNo, SUM(JobWg) as JobWg FROM JobGemDetail GROUP BY DocNo) AS JobGemDetail on JobGemDetail.DocNo = AccEmp.DocNo
                                        WHERE AccEmp.JobType = 3 AND AccEmp.JobName = 'ขัด'
                                        GROUP BY AccEmp.EmpCode, JobHead.EmpName, AccEmp.Inv_No, AccEmp.DocNo, AccEmp2.JobBarCode, JobHead.JobDate, JobDetail.Article, CProfile.TDesArt, JobHead.ChkReturn, JobHead.ChkAccount, minJobKeep.MINmDate, LessJobkeep.Less, JobDetail.PriceJob, AccEmp2.OKQty, AccEmp2.AccPrice, JobCost.Cost3, AccEmp.DMWG, AccEmp.LSWG, AccEmp.LSGemAmount, AccEmp.DMGemAmount, DeductAmount.Deduct, AccEmp2.OKWG, JobDetail.DMPercent, JobBills.RtWg, JobBills.Silver, V_JobMaterial_Sum.MatRecWg, CTE_JobGemDetail.GemWg, JobDetail.Ttlwg, TEmpProfile.TitleName, AccEmp.EmpAmount, AccEmp.ISAAmount, AccEmp.DeductAmount, JobDetail.MatWg, JobDetail.MatWg2, AccEmp.ISSWG, V_JobMaterial_Sum.MatWg, V_JobMaterial_Sum.MatWg2, CTE_ChkBrass.ChkBrass, JobGemDetail.JobWg
                                        )
                                        SELECT DENSE_RANK() OVER (ORDER BY DocNo) AS [ลำดับที่], EmpCode, EmpName, Inv_No, DocNo, JobBarCode, JobDate, TypeOfWork, TypeOfBill, Late, Less, LateFee, CenterAcc, DeductLost, DiffWg, Wage, (SELECT SUM(RawDiffWg1) FROM PolishData) AS DiffWg1, (SELECT SUM(RawDiffMat1) FROM PolishData) AS DiffMat1, DiffWg2, DiffMat2, DiffTWg, (SELECT SUM(DiffTWg) FROM (SELECT DISTINCT DocNo, DiffTWg FROM PolishData) AS DistinctDiffTWg) AS DiffTTWg, (SELECT SUM(RawPerDiffTTWg) FROM (SELECT DISTINCT DocNo, RawPerDiffTTWg FROM PolishData) AS DistinctDiffTWg) AS PerDiffTTWg, (SELECT SUM(NormalEmpAmount) FROM (SELECT DISTINCT DocNo, NormalEmpAmount FROM PolishData) AS DistinctData) AS NetWage FROM PolishData ORDER BY JobBarCode;";

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
