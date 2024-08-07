using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Data;
using System.Windows.Forms;
using WindowsFormsApp2;

namespace CheckProcessApplication
{
    public partial class Foundry : Form
    {
        public Foundry()
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
            if (string.IsNullOrEmpty(InvInput.Texts)) { return; }
            var value = 300;
            var WHERE = $"WHERE Inv_No = '{InvInput.Texts}'";
            if (!string.IsNullOrEmpty(textBoxCustom1.Texts)) { value = Convert.ToInt32(textBoxCustom1.Texts); }
            Center.cmd.CommandText = $"SELECT EmpCode, EmpName, Inv_No, DocNo, JobBarCode, JobDate, TypeOfWork, TypeOfBill, Late, TtQy, CASE WHEN Late = 'YES' OR TtQy = 'YES' THEN (PriceJob * FLOOR(OKQty)) / 2 ELSE 0 END AS DeductLate, JobCenter, Wage, DIFFQty, DIFFOrder, DIFFModel, DIFFSI, DIFFWG1, DIFFWG2, DIFFWG3, DIFFMatWG, DIFFTotalWG, DIFFTotalWGPercent, TotalWage, TEST" +
                $" FROM (SELECT AccEmp.EmpCode, JobHead.EmpName, AccEmp.Inv_No, AccEmp.DocNo, AccEmp2.JobBarCode, JobHead.JobDate" +
                $", CASE WHEN LEFT(JobDetail.Article,1) = 'B' OR CProfile.TDesArt LIKE '%ทองเหลือง%' THEN 'ทองเหลือง' ELSE '' END AS TypeOfWork" +
                $", CASE WHEN JobHead.ChkReturn = 0 AND JobHead.ChkAccount = 1 THEN 'ซ่อม' ELSE '' END AS TypeOfBill" +
                $", CASE WHEN DATEDIFF(DAY, DATEADD(DAY, CASE WHEN JobDetail.DMPercent != 0 THEN 10 ELSE 0 END, DATEADD(DAY, (CASE WHEN JobDetail.ChkModel = 1 AND JobDetail.Model > 0 THEN 13 ELSE 10 END), JobHead.JobDate)), JobKeeps.mdate) > 10 THEN 'YES' ELSE '' END AS Late" +
                $", CASE WHEN ISNULL(JobKeeps.TtQty, 0) > (ISNULL(JobDetail.TtQty, 0) * 70) / 100 THEN '' ELSE 'YES' END AS TtQy" +
                $", ISNULL(JobDetail.PriceJob, 0) AS PriceJob, ISNULL(AccEmp2.OKQty, 0) AS OKQty" +
                $", CASE WHEN ISNULL(JobDetail.PriceJob, 0) > ISNULL(JobCost.Cost1, 0) THEN 'ไม่ถูกต้อง' ELSE '' END AS JobCenter" +
                $", CASE WHEN ISNULL(AccEmp.EmpAmount, 0) + ISNULL(AccEmp.ISAAmount, 0) <> (ISNULL(JobDetail.PriceJob, 0) * FLOOR(ISNULL(AccEmp2.OKQty, 0)) - (ISNULL(AccEmp.DMWG, 0) + ISNULL(AccEmp.LSWG, 0) + ISNULL(AccEmp.DMGemAmount, 0))) + (ISNULL(Emps.qtys, 0) * ModelNewP) + (FLOOR(ISNULL(AccEmp.OKQty, 0) - ISNULL(AccEmp2.OKQty,0))) * ISNULL(JobDetail.PriceJob, 0) THEN 'ค่าแรงไม่ถูกต้อง' ELSE '' END AS Wage" +
                $", CEILING(CASE WHEN ISNULL(Jobmodel_purchase.qty, 0) <> 0 THEN ISNULL(Jobmodel_purchase.qty, 0) - (ISNULL(AccEmp.OKQTY, 0) / {value}) ELSE 0 END) AS DIFFQty, 0 AS DIFF2" +
                $", CASE WHEN ISNULL(Jobmodel_purchase.qty, 0) = 0 THEN 0 ELSE CASE WHEN ISNULL(AccEmp.ModelNewQ, 0) + ISNULL(AccEmp.ModelNewQ2, 0) + ISNULL(AccEmp.ModelNewQ3, 0) >= ISNULL(Jobmodel_purchase.qty, 0) THEN CASE WHEN ISNULL(Jobmodel_purchase.qty, 0) <= CEILING(ISNULL(AccEmp.OKQTY, 0) / {value}) THEN ISNULL(Jobmodel_purchase.qty, 0) ELSE CEILING(ISNULL(AccEmp.OKQTY, 0) / {value}) END ELSE CASE WHEN ISNULL(Jobmodel_purchase.qty, 0) <= CEILING(ISNULL(AccEmp.OKQTY, 0) / {value}) THEN ISNULL(AccEmp.ModelNewQ, 0) + ISNULL(AccEmp.ModelNewQ2, 0) + ISNULL(AccEmp.ModelNewQ3, 0) ELSE CEILING(ISNULL(AccEmp.OKQTY, 0) / {value}) END END END AS DIFFOrder" +
                $", CASE WHEN (JobDetail.ChkModel = 1) OR (JobDetail.ChkChunk = 1) THEN (ISNULL(V_JobModel_Sum.QtyR_REC, 0) + ISNULL(V_JobModel_Sum.QtyM_REC, 0)) - (ISNULL(V_JobModel_Sum.QtyR_ISS, 0) - ISNULL(V_JobModel_Sum.QtyM_ISS, 0)) ELSE 0 END AS DIFFModel" +
                $", (ISNULL(AccEmp2.OKWG, 0) * ISNULL(JobDetail.DMPercent, 0)) / 100 AS DIFFSI" +
                $", CASE WHEN JobHead.ChkReturn = 0 AND JobHead.ChkAccount = 1 THEN ISNULL(JobDetail.Ttlwg, 0) - ISNULL(AccEmp.ISSWG, 0) - ISNULL(V_JobMaterial_Sum.MatWg, 0) + ISNULL(V_JobMaterial_Sum.MatWg2, 0) ELSE 0 END AS DIFFWG1" +
                $", CASE WHEN JobHead.ChkReturn = 0 AND JobHead.ChkAccount = 1 THEN ISNULL(JobDetail.MatWg, 0) + ISNULL(JobDetail.MatWg2, 0) - ISNULL(AccEmp.ISSWG, 0) - ISNULL(V_JobMaterial_Sum.MatWg, 0) + ISNULL(V_JobMaterial_Sum.MatWg2, 0) ELSE 0 END AS DIFFWG2" +
                $", CASE WHEN JobHead.ChkReturn = 0 AND JobHead.ChkAccount = 1 THEN (ISNULL(AccEmp2.OKWG, 0) + ISNULL(JobBills.RtWg, 0) + ISNULL(V_JobMaterial_Sum.MatRecWg, 0) + ((ISNULL(AccEmp2.OKWG, 0) - (ISNULL(V_JobMaterial_Sum.MatWg, 0) + ISNULL(V_JobMaterial_Sum.MatWg2, 0))) / 100)) - ISNULL(AccEmp.OKWG, 0) ELSE 0 END AS DIFFWG3" +
                $", CASE WHEN JobHead.ChkReturn = 0 AND JobHead.ChkAccount = 1 THEN ISNULL(PSKTran2.recwg, 0) - ISNULL(V_JobMaterial_Sum.MatRecWg, 0) ELSE 0 END AS DIFFMatWG" +
                $", CASE WHEN JobHead.ChkReturn = 0 AND JobHead.ChkAccount = 1 THEN ISNULL(AccEmp2.OKWG, 0) + ISNULL(JobBills.RtWg, 0) + ISNULL(V_JobMaterial_Sum.MatRecWg, 0) + ((ISNULL(AccEmp2.OKWG, 0) - ISNULL(V_JobMaterial_Sum.MatWg, 0) + ISNULL(V_JobMaterial_Sum.MatWg2, 0)) / 100) - ISNULL(AccEmp.ISSWG, 0) ELSE 0 END AS DIFFTotalWG" +
                $", CASE WHEN JobHead.ChkReturn = 0 AND JobHead.ChkAccount = 1 THEN ((ISNULL(AccEmp2.OKWG, 0) + ISNULL(JobBills.RtWg, 0) + ISNULL(V_JobMaterial_Sum.MatRecWg, 0) + ((ISNULL(AccEmp2.OKWG, 0) - ISNULL(V_JobMaterial_Sum.MatWg, 0) + ISNULL(V_JobMaterial_Sum.MatWg2, 0)) / 100) - ISNULL(AccEmp.ISSWG, 0)) / ISNULL(AccEmp.ISSWG, 0)) * 100 ELSE 0 END AS DIFFTotalWGPercent" +
                $", (JobDetail.PriceJob * FLOOR(AccEmp2.OKQty)) - AccEmp.DMWG + AccEmp.LSWG + AccEmp.DMGemAmount + AccEmp.LSGemAmount + AccEmp.DeductAmount AS TotalWage" +
                $", CASE WHEN JobDeducts.Amounts IS NULL THEN 0 ELSE (JobDeductFormula.Deduct * JobDeductFormula.Price) - JobDeducts.Amounts END AS TEST" +
                $" FROM (SELECT * FROM AccEmp {WHERE}) AS AccEmp" +
                $" LEFT JOIN AccEmp2 ON AccEmp.DocNo = AccEmp2.DocNo AND AccEmp.EmpCode = AccEmp2.EmpCode" +
                $" LEFT JOIN JobHead ON AccEmp.DocNo = JobHead.DocNo AND AccEmp.EmpCode = JobHead.EmpCode" +
                $" LEFT JOIN JobDetail ON AccEmp.DocNo = JobDetail.DocNo AND AccEmp.EmpCode = JobDetail.EmpCode AND AccEmp2.JobBarCode = JobDetail.JobBarcode" +
                $" LEFT JOIN CProfile ON JobDetail.Article = CProfile.Article AND JobDetail.ArtCode = CProfile.ArtCode" +
                $" LEFT JOIN (SELECT DocNo, EmpCode, JobBarcode, mdate, TtQty FROM JobKeep WHERE Num = '01') AS JobKeeps ON AccEmp.DocNo = JobKeeps.DocNo AND AccEmp.EmpCode = JobKeeps.EmpCode AND AccEmp2.JobBarCode = JobKeeps.JobBarcode" +
                $" LEFT JOIN JobCost ON JobDetail.OrderNo = JobCost.Orderno AND JobDetail.LotNo = JobCost.LotNo" +
                $" LEFT JOIN Jobmodel_purchase ON AccEmp2.JobBarCode = Jobmodel_purchase.Jobbarcode" +
                $" LEFT JOIN V_JobModel_Sum ON AccEmp.DocNo = V_JobModel_Sum.DocNo AND AccEmp.EmpCode = V_JobModel_Sum.EmpCode" +
                $" LEFT JOIN V_JobMaterial_Sum ON AccEmp.DocNo = V_JobMaterial_Sum.DocNo AND AccEmp.EmpCode = V_JobMaterial_Sum.EmpCode" +
                $" LEFT JOIN (SELECT DocNo, EmpCode, SUM(OKTtl) AS OKTtl, SUM(RtWg) AS RtWg FROM JobBill GROUP BY DocNo, EmpCode) AS JobBills ON AccEmp.DocNo = JobBills.DocNo AND AccEmp.EmpCode = JobBills.EmpCode" +
                $" LEFT JOIN PSKTran2 ON JobDetail.OrderNo = PSKTran2.Orderno AND JobDetail.LotNo = PSKTran2.LotNo AND JobDetail.Barcode = PSKTran2.Barcode" +
                $" LEFT JOIN (SELECT DocNo, EmpCode, SUM(ISNULL(OKQty,0) * ISNULL(AccPrice, 0)) AS PriceJob, SUM(ISNULL(qty, 0)) AS qtys FROM AccEmp2 INNER JOIN Jobmodel_purchase ON AccEmp2.JobBarCode = Jobmodel_purchase.Jobbarcode GROUP BY DocNo, EmpCode) AS Emps ON AccEmp.DocNo = Emps.DocNo AND AccEmp.EmpCode = Emps.EmpCode" +
                $" LEFT JOIN JobDeductFormula ON JobHead.JobType = JobDeductFormula.JobType AND (JobDetail.TtQty BETWEEN JobDeductFormula.StartQty AND JobDeductFormula.EndQty)" +
                $" LEFT JOIN (SELECT Docno, EmpCode, Jobbarcode, SUM(Amount) AS Amounts FROM JobDeduct GROUP BY Docno, EmpCode, Jobbarcode) AS JobDeducts ON AccEmp.DocNo = JobDeducts.Docno AND AccEmp.EmpCode = JobDeducts.EmpCode AND AccEmp2.JobBarCode = JobDeducts.Jobbarcode" +
                $") AS s" +
                $" ORDER BY DocNo, JobBarCode";

            var dt = Center.Load();
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show($"ไม่พบข้อมูล Inv. {InvInput.Texts}", "ERROR!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cReport = new ReportDocument();
            DataSet ds = new DataSet();
            if (!ds.Tables.Contains(dt.TableName))
                ds.Tables.Add(dt.Copy());

            cReport.Load($"{Application.StartupPath}/Reports/CrystalReport2.rpt");
            ds.WriteXmlSchema(xsdFile);
            cReport.SetDataSource(dt);
            var u = new uReportViewer(cReport);
            u.WindowState = FormWindowState.Maximized;
            u.Show();

            System.IO.File.Delete(xsdFile);

        }

        private void textBoxCustom1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
