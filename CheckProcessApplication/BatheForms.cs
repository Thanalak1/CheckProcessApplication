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
            //var WHERE = $"WHERE Inv_No = '{invInput.Texts}'";
            var WHERE = $"WHERE Inv_No = '{invInput.Texts.Trim()}'";
            var AND = $"AND Inv_No = '{invInput.Texts.Trim()}'";
            Center.cmd.CommandText = $@"--select * from V_Bathe {WHERE} order by DocNo, JobBarcode
                                        WITH BatheData AS
                                        (SELECT AccEmp.EmpCode, JobHead.EmpName, AccEmp.Inv_No, AccEmp.DocNo, AccEmp2.JobBarCode, JobHead.JobDate,
                                        CASE WHEN LEFT(JobDetail.Article, 1) = 'B' OR (LEFT(JobDetail.Article, 1) = 'Z' AND CProfile.TdesArt LIKE '%ทองเหลือง%') THEN 'ทองเหลือง' ELSE '' END AS TypeOfWork,
                                        CASE WHEN JobHead.ChkReturn = 0 AND JobHead.ChkAccount = 1 THEN 'ซ่อม' ELSE '' END AS TypeOfBill,
                                        CASE WHEN minJobKeep.MINmDate > DATEADD(DAY, 10, JobHead.JobDate) THEN 'YES' ELSE '' END AS Late,
                                        COALESCE(LessJobkeep.Less, '') AS Less,
                                        CASE WHEN minJobKeep.MINmDate > DATEADD(DAY, 10, JobHead.JobDate) OR COALESCE(LessJobkeep.Less, '') = 'YES' THEN CAST((JobDetail.PriceJob * FLOOR(AccEmp2.OKQty)) / 2 AS DECIMAL(18, 2)) ELSE null END AS LateFee,
                                        CASE WHEN ISNULL(AccEmp2.AccPrice, 0) > ISNULL(JobCost.Cost5, 0) THEN 'ไม่ถูกต้อง' ELSE '' END AS CenterAcc,
                                        CASE WHEN ISNULL(AccEmp2.AccPrice, 0) > 5.5 OR ISNULL(JobCost.Cost5, 0) > 5.5 THEN 'ไม่ถูกต้อง' ELSE '' END AS OverPrice,
                                        CASE WHEN ISNULL(AccEmp.DMWG, 0) + ISNULL(AccEmp.LSWG, 0) + ISNULL(AccEmp.LSGemAmount, 0) + ISNULL(AccEmp.DMGemAmount, 0) + ISNULL(DeductAmount.Deduct, 0) > 500 THEN 'ไม่ถูกต้อง' ELSE '' END AS DeductLost,
                                        COALESCE(CAST((V_JobMaterial_Sum.MatRecWg - SUM((JobDetail.MatWg + JobDetail.MatWg2)) OVER(Partition By AccEmp.DocNo)) AS DECIMAL(18, 2)), 0.00) AS DiffWgLoss,
                                        CAST(CASE WHEN COALESCE(CAST((V_JobMaterial_Sum.MatRecWg - SUM((JobDetail.MatWg + JobDetail.MatWg2)) OVER(Partition By AccEmp.DocNo)) AS DECIMAL(18, 2)), 0.00) <= -1 THEN COALESCE(CAST((V_JobMaterial_Sum.MatRecWg - SUM((JobDetail.MatWg + JobDetail.MatWg2)) OVER(Partition By AccEmp.DocNo)) AS DECIMAL(18, 2)), 0.00) / NULLIF(CAST((JobDetail.MatWg + JobDetail.MatWg2) / NULLIF(PSKTran2.Qty, 0) AS DECIMAL(18, 2)), 0) ELSE 0 END AS DECIMAL(18, 2)) AS UnitLoss,
                                        CASE WHEN SUM(ROUND(((((ISNULL(AccEmp2.OKWG, 0)) * ISNULL(JobDetail.DMPercent, 0)) / 100) * 100) / 100, 2)) OVER (PARTITION BY AccEmp.DocNo, AccEmp.EmpCode) = 0 THEN '' ELSE CASE WHEN SUM(ISNULL(AccEmp2.OKWG, 0)) OVER (PARTITION BY AccEmp.DocNo, AccEmp.EmpCode) + ISNULL(JobBills.RtWg, 0) + ISNULL(JobBills.Silver, 0) + ISNULL(V_JobMaterial_Sum.MatRecWg, 0) + SUM(((((ISNULL(AccEmp2.OKWG, 0)) * ISNULL(JobDetail.DMPercent, 0)) / 100) * 100) / 100) OVER (PARTITION BY AccEmp.DocNo, AccEmp.EmpCode) - (SUM(JobDetail.Ttlwg) OVER (PARTITION BY AccEmp.DocNo, AccEmp.EmpCode) + ISNULL(V_JobMaterial_Sum.MatRecWg, 0) + ISNULL(CTE_JobGemDetail.GemWg, 0)) > SUM(((((ISNULL(AccEmp2.OKWG, 0)) * ISNULL(JobDetail.DMPercent, 0)) / 100) * 100) / 100) OVER (PARTITION BY AccEmp.DocNo, AccEmp.EmpCode) THEN 'ไม่ถูกต้อง' ELSE '' END END AS DiffWgSI,
                                        CASE WHEN ISNULL(AccEmp.EmpAmount, 0) + ISNULL(AccEmp.ISAAmount, 0) <> ROUND(SUM(ISNULL(AccEmp2.AccPrice, 0) * ISNULL(CASE WHEN AccEmp2.OKQty = 0.5 THEN 0.5 ELSE CASE WHEN TEmpProfile.TitleName = 'บริษัท' THEN AccEmp2.OKQty ELSE FLOOR(AccEmp2.OKQty) END END, 0)) OVER (PARTITION BY AccEmp.DocNo) - (ISNULL(AccEmp.DMWG, 0) + ISNULL(AccEmp.LSWG, 0) + ISNULL(AccEmp.LSGemAmount, 0) + ISNULL(AccEmp.DMGemAmount, 0) + ISNULL(DeductAmount.Deduct, 0)) + (ISNULL(Jobmodel_purchase.qty, 0) * ISNULL(AccEmp.ModelNewP, 0)), 2) THEN 'ค่าแรงไม่ถูกต้อง' ELSE '' END AS Wage,
                                        CAST(SUM((CASE WHEN CTE_ChkBrass.ChkBrass = 1 THEN 0 ELSE ISNULL(JobDetail.Ttlwg, 0) END) - (CASE WHEN CTE_ChkBrass.ChkBrass = 1 THEN ISNULL(CTE_JobGemDetail.GemWg, 0) ELSE CASE WHEN Deduct.OKWG = ISNULL(AccEmp2.OKWG, 0) THEN ISNULL(AccEmp.ISSWG, 0) + ISNULL(CTE_JobGemDetail.GemWg, 0) ELSE 0 END END - ISNULL(V_JobMaterial_Sum.MatWg, 0) + ISNULL(V_JobMaterial_Sum.MatWg2, 0))) OVER()  AS DECIMAL(18, 2)) AS DiffWg1,
                                        CAST(SUM(ISNULL(JobDetail.MatWg, 0) + ISNULL(JobDetail.MatWg2, 0) - (ISNULL(V_JobMaterial_Sum.MatWg, 0) + ISNULL(V_JobMaterial_Sum.MatWg2, 0))) OVER() AS DECIMAL(18, 2)) AS DiffMat1,
                                        CAST(SUM((ISNULL(AccEmp2.OKWG, 0) + ISNULL(V_JobMaterial_Sum.MatRecWg, 0) + ISNULL(JobBills.RtWg, 0) + ISNULL(JobBills.Silver, 0) + (FLOOR((((ISNULL(AccEmp2.OKWG, 0) - (ISNULL(JobDetail.MatWg, 0) + ISNULL(JobDetail.MatWg2, 0))) * ISNULL(JobDetail.DMPercent, 0)) / 100) *100) /100)) - (ISNULL(AccEmp2.OKWG, 0) + ISNULL(V_JobMaterial_Sum.MatRecWg, 0) + ISNULL(JobBills.RtWg, 0) + ISNULL(JobBills.Silver, 0) + (FLOOR((((ISNULL(AccEmp2.OKWG, 0) - (ISNULL(JobDetail.MatWg, 0) + ISNULL(JobDetail.MatWg2, 0))) * ISNULL(JobDetail.DMPercent, 0)) / 100) *100) /100))) OVER() AS DECIMAL(18, 2)) AS DiffWg2,
                                        CAST(SUM(ISNULL(V_JobMaterial_Sum.MatRecWg, 0) - ISNULL(V_JobMaterial_Sum.MatRecWg, 0)) OVER() AS DECIMAL(18, 2)) AS DiffMat2,
                                        CASE WHEN CTE_ChkBrass.ChkBrass = 1 THEN 0 - ISNULL(CTE_JobGemDetail.GemWg, 0) ELSE SUM(ISNULL(AccEmp2.OKWG, 0)) OVER (PARTITION BY AccEmp.DocNo, AccEmp.EmpCode) + ISNULL(JobBills.RtWg, 0) + ISNULL(JobBills.Silver, 0) + ISNULL(V_JobMaterial_Sum.MatRecWg, 0) + SUM(((((ISNULL(AccEmp2.OKWG, 0) - (ISNULL(JobDetail.MatWg, 0) + ISNULL(JobDetail.MatWg2, 0))) * ISNULL(JobDetail.DMPercent, 0)) / 100) * 100) / 100) OVER (PARTITION BY AccEmp.DocNo, AccEmp.EmpCode) - (SUM(JobDetail.Ttlwg) OVER (PARTITION BY AccEmp.DocNo, AccEmp.EmpCode) + ISNULL(JobDetail.MatWg, 0) + ISNULL(JobDetail.MatWg2, 0)) END AS DiffTWg,
                                        CAST(CASE WHEN CTE_ChkBrass.ChkBrass = 1 THEN 0 - ISNULL(CTE_JobGemDetail.GemWg, 0) ELSE CASE WHEN CTE_ChkBrass.ChkBrass = 1 THEN 0 - ISNULL(CTE_JobGemDetail.GemWg, 0) ELSE SUM(ISNULL(AccEmp2.OKWG, 0)) OVER (PARTITION BY AccEmp.DocNo, AccEmp.EmpCode) + ISNULL(JobBills.RtWg, 0) + ISNULL(JobBills.Silver, 0) + ISNULL(V_JobMaterial_Sum.MatRecWg, 0) + SUM(((((ISNULL(AccEmp2.OKWG, 0) - (ISNULL(JobDetail.MatWg, 0) + ISNULL(JobDetail.MatWg2, 0))) * ISNULL(JobDetail.DMPercent, 0)) / 100) * 100) / 100) OVER (PARTITION BY AccEmp.DocNo, AccEmp.EmpCode) - (SUM(JobDetail.Ttlwg) OVER (PARTITION BY AccEmp.DocNo, AccEmp.EmpCode) + ISNULL(JobDetail.MatWg, 0) + ISNULL(JobDetail.MatWg2, 0)) END / NULLIF(SUM(ISNULL(JobDetail.TtlWg, 0) + ISNULL(JobDetail.MatWg, 0) + ISNULL(JobDetail.MatWg2, 0)) OVER (), 0) END * 100 AS DECIMAL(18, 2)) AS RawPerDiffTTWg,
                                        CAST(SUM((ISNULL(AccEmp2.AccPrice, 0) * CASE WHEN AccEmp2.OKQty = 0.5 THEN 0.5 ELSE CASE WHEN TEmpProfile.TitleName = 'บริษัท' THEN AccEmp2.OKQty ELSE FLOOR(AccEmp2.OKQty) END END) - (ISNULL(AccEmp.DMWG, 0) + ISNULL(AccEmp.LSWG, 0) + ISNULL(AccEmp.LSGemAmount, 0) + ISNULL(AccEmp.DMGemAmount, 0) + ISNULL(DeductAmount.Deduct, 0))) OVER () AS DECIMAL(18, 2)) AS NetWage
                                        FROM (SELECT * FROM AccEmp {WHERE}) AS AccEmp
                                        LEFT JOIN AccEmp2 ON AccEmp.DocNo = AccEmp2.DocNo AND AccEmp.EmpCode = AccEmp2.EmpCode
                                        LEFT JOIN JobDetail ON AccEmp.DocNo = JobDetail.DocNo AND AccEmp.EmpCode = JobDetail.EmpCode AND AccEmp2.JobBarCode = JobDetail.JobBarcode
                                        LEFT JOIN JobHead ON AccEmp.DocNo = JobHead.DocNo AND AccEmp.EmpCode = JobHead.EmpCode
                                        LEFT JOIN CProfile ON CProfile.Article = JobDetail.Article AND CProfile.ArtCode = JobDetail.ArtCode
                                        LEFT JOIN (SELECT AccEmp.DocNo, MIN(JobKeep.mDate) AS MINmDate FROM JobKeep LEFT JOIN AccEmp on JobKeep.DocNo = AccEmp.DocNo AND JobKeep.EmpCode = AccEmp.EmpCode {WHERE} GROUP BY AccEmp.DocNo) AS minJobKeep ON minJobKeep.DocNo = AccEmp.DocNo
                                        LEFT JOIN (SELECT AccEmp.DocNo, AccEmp.EmpCode, 'YES' AS Less FROM AccEmp LEFT JOIN (SELECT DocNo, EmpCode, SUM(TtQty) AS TtQty, Num FROM JobKeep GROUP BY DocNo, EmpCode, Num) AS JobKeeps ON AccEmp.DocNo = JobKeeps.DocNo AND AccEmp.EmpCode = JobKeeps.EmpCode LEFT JOIN JobDetail ON AccEmp.DocNo = JobDetail.DocNo AND AccEmp.EmpCode = JobDetail.EmpCode WHERE JobKeeps.DocNo = AccEmp.DocNo AND JobKeeps.TtQty < 0.7 * JobDetail.TtQty 
                                        AND JobKeeps.Num = 1 {AND}) LessJobkeep ON LessJobkeep.DocNo = AccEmp.DocNo AND LessJobkeep.EmpCode = AccEmp.EmpCode
                                        LEFT JOIN JobCost ON JobCost.OrderNo = JobDetail.Orderno AND JobCost.LotNo = JobDetail.LotNo
                                        LEFT JOIN (SELECT DocNo, EmpCode, CASE WHEN DeductAmount = ISAAmount THEN DeductAmount WHEN DeductAmount <> ISAAmount THEN ISAAmount + DeductAmount WHEN DeductAmount = 0 and ISAAmount <> 0 THEN ISAAmount WHEN DeductAmount <> 0 and ISAAmount = 0 THEN DeductAmount ELSE 0 END AS Deduct FROM AccEmp
                                        {WHERE}) AS DeductAmount on DeductAmount.DocNo = AccEmp.DocNo and DeductAmount.EmpCode = AccEmp.EmpCode
                                        LEFT JOIN V_JobMaterial_Sum on V_JobMaterial_Sum.DocNo = AccEmp.DocNo AND V_JobMaterial_Sum.EmpCode = AccEmp.EmpCode
                                        LEFT JOIN PSKTran2 ON PSKTran2.OrderNo = JobDetail.Orderno AND PSKTran2.LotNo = JobDetail.LotNo AND PSKTran2.Jobbarcode = JobDetail.Jobbarcode
                                        LEFT JOIN (SELECT DocNo, EmpCode, Silver, SUM(OKTtl) AS OKTtl, SUM(RtWg) AS RtWg FROM JobBill GROUP BY DocNo, EmpCode, Silver) AS JobBills ON AccEmp.DocNo = JobBills.DocNo AND AccEmp.EmpCode = JobBills.EmpCode
                                        LEFT JOIN (SELECT JobDetail.DocNo, JobDetail.EmpCode, JobDetail.JobBarcode, sum(JobGemDetail.JobQty) AS GemQty, sum(JobGemDetail.JobWg) AS GemWg, sum(JobGemDetail.PerProduct * JobDetail.TtQty) AS GemPerProduct from JobGemDetail left join JobDetail on JobGemDetail.DocNo = JobDetail.DocNo and JobGemDetail.EmpCode = JobDetail.EmpCode and JobGemDetail.JobBarcode = JobDetail.JobBarcode group by JobDetail.DocNo, JobDetail.EmpCode, JobDetail.JobBarcode) AS CTE_JobGemDetail on AccEmp2.DocNo = CTE_JobGemDetail.DocNo and AccEmp2.EmpCode = CTE_JobGemDetail.EmpCode and AccEmp2.JobBarCode = CTE_JobGemDetail.JobBarcode
                                        LEFT JOIN TEmpProfile on AccEmp2.EmpCode = TEmpProfile.EmpCode
                                        LEFT JOIN Jobmodel_purchase on AccEmp2.JobBarCode = Jobmodel_purchase.Jobbarcode
                                        LEFT JOIN (SELECT JobDetail.DocNo, JobDetail.EmpCode, JobDetail.JobBarcode, case when LEFT(JobDetail.Article, 1) = 'B' then 1 when LEFT(JobDetail.Article, 1) = 'Z' and CProfile.TDesArt LIKE '%ทองเหลือง%' then 1 else 0 end as ChkBrass from JobDetail left join CProfile on JobDetail.ArtCode = CProfile.ArtCode and JobDetail.Article = CProfile.Article) AS CTE_ChkBrass on CTE_ChkBrass.DocNo = AccEmp2.DocNo and CTE_ChkBrass.EmpCode = AccEmp2.EmpCode and CTE_ChkBrass.JobBarcode = AccEmp2.JobBarCode
                                        LEFT JOIN (select DocNo, EmpCode, min(OKWG) as OKWG from AccEmp2 group by DocNo, EmpCode) AS Deduct on Deduct.DocNo = AccEmp2.DocNo AND Deduct.EmpCode = AccEmp2.EmpCode
                                        WHERE AccEmp.JobType = 5 AND AccEmp.JobName = 'ชุบ'
                                        Group By AccEmp.EmpCode, JobHead.EmpName, AccEmp.Inv_No, AccEmp.DocNo, AccEmp2.JobBarCode, JobHead.JobDate, JobDetail.Article, CProfile.TdesArt, JobHead.ChkReturn, JobHead.ChkAccount, minJobKeep.MINmDate, LessJobkeep.Less, JobDetail.PriceJob, AccEmp2.OKQty, AccEmp2.AccPrice, JobCost.Cost5, AccEmp.LSWG, AccEmp.DMWG, AccEmp.LSGemAmount, AccEmp.DMGemAmount, DeductAmount.Deduct, V_JobMaterial_Sum.MatRecWg, JobDetail.MatWg, JobDetail.MatWg2, PSKTran2.Qty, AccEmp2.OKWG, JobBills.RtWg, JobBills.Silver, CTE_JobGemDetail.GemWg, JobDetail.DMPercent, JobDetail.Ttlwg, TEmpProfile.TitleName, AccEmp.EmpAmount, AccEmp.ISAAmount, Jobmodel_purchase.qty, AccEmp.ModelNewP, AccEmp.ISSWG, V_JobMaterial_Sum.MatWg, V_JobMaterial_Sum.MatWg2, CTE_ChkBrass.ChkBrass, Deduct.OKWG, AccEmp.DeductAmount
                                        )
                                        SELECT DENSE_RANK() OVER (ORDER BY DocNo) AS [ลำดับที่] , EmpCode, EmpName, Inv_No, DocNo, JobBarCode, JobDate, TypeOfWork, TypeOfBill, Late, Less, LateFee, CenterAcc, OverPrice, DeductLost, DiffWgLoss, UnitLoss, DiffWgSI, Wage, DiffWg1, DiffMat1, DiffWg2, DiffMat2, (SELECT SUM(DiffTWg) FROM (SELECT DISTINCT DocNo, DiffTWg FROM BatheData) AS DistinctDiffTWg) AS DiffTTWg,(SELECT SUM(RawPerDiffTTWg) FROM (SELECT DISTINCT DocNo, RawPerDiffTTWg FROM BatheData) AS DistinctDiffTWg) AS PerDiffTTWg, NetWage FROM BatheData Order By JobBarcode;";

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
            //$"\\\\factoryserver\\BillingScrip\\Reports\\BatheReport.rpt"
            //cReport.Load($"\\\\factoryserver\\BillingScrip\\Reports\\BatheReport2.rpt");
            cReport.Load($"{Application.StartupPath}/Reports/BatheCrystalReport.rpt");
            ds.WriteXmlSchema(xsdFile);
            cReport.SetDataSource(dt);
            var u = new uReportViewer(cReport);
            u.WindowState = FormWindowState.Maximized;
            u.Show();

            System.IO.File.Delete(xsdFile);
        }
    }
}
