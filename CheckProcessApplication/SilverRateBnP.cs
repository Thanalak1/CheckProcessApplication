using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckProcessApplication
{
    public partial class SilverRateBnP : Form
    {
        SqlConnection con = new SqlConnection("Data Source=SERVER;Initial Catalog=Best_ManageDB;Persist Security Info=True;User ID=admin;Password=jp;Encrypt=True;TrustServerCertificate=True");
        public SilverRateBnP()
        {
            InitializeComponent();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            var SRATE = SrateInput.Texts.Trim();
            if (string.IsNullOrEmpty(SRATE))
            {
                MessageBox.Show("กรุณากรอก 'Rate เนื้อเงิน'", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (!decimal.TryParse(SRATE, out _))
                {
                    MessageBox.Show("กรุณากรอก 'Rate เนื้อเงิน' เป็น 'ตัวเลข' เท่านั้น", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    string query = "SELECT TOP (1) cDate FROM SilverRate ORDER BY cDate DESC";
                    try
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand(query, con);
                        var result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            DateTime lastDate = (DateTime)result;
                            DateTime now = DateTime.Now;
                            int monthDifference = (now.Year - lastDate.Year) * 12 + now.Month - lastDate.Month;
                            if (monthDifference == 0)
                            {
                                CheckPWforEdit checkPWPopup = new CheckPWforEdit();
                                checkPWPopup.StartPosition = FormStartPosition.CenterScreen;
                                if (checkPWPopup.ShowDialog() == DialogResult.OK)
                                {
                                    UpdateSilverRate(SRATE);
                                }
                                else
                                {
                                    MessageBox.Show("ยกเลิกการแก้ไข Silver Rate", "การยกเลิก", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else if (monthDifference >= 1)
                            {
                                InsertSilverRate(SRATE);
                            }
                            else if (monthDifference <= -1)
                            {
                                MessageBox.Show("วันที่ปัจจุบันน้อยกว่าข้อมูลล่าสุดในฐานข้อมูล", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            InsertSilverRate(SRATE);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"เกิดข้อผิดพลาด: {ex.Message}", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }
        private void InsertSilverRate(string srate)
        {
            string insertQuery = "INSERT INTO SilverRate (SilverRate, cDate) VALUES (@SilverRate, GETDATE())";
            try
            {
                SqlCommand insertCmd = new SqlCommand(insertQuery, con);
                insertCmd.Parameters.AddWithValue("@SilverRate", srate);
                insertCmd.ExecuteNonQuery();
                MessageBox.Show("เพิ่มข้อมูลสำเร็จ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"เกิดข้อผิดพลาด: {ex.Message}", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateSilverRate(string srate)
        {
            string updateQuery = @"UPDATE SilverRate SET SilverRate = @SilverRate, mDate = GetDate() WHERE cDate = (SELECT TOP 1 cDate FROM SilverRate ORDER BY cDate DESC)";
            try
            {
                SqlCommand updateCmd = new SqlCommand(updateQuery, con);
                updateCmd.Parameters.AddWithValue("@SilverRate", srate);
                updateCmd.ExecuteNonQuery();
                MessageBox.Show("แก้ไขข้อมูลสำเร็จ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"เกิดข้อผิดพลาด: {ex.Message}", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
