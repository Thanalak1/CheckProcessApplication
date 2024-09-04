using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckProcessApplication
{
    public partial class CheckPWforEdit : Form
    {
        private SqlConnection con = new SqlConnection("Data Source=SERVER;Initial Catalog=Best_ManageDB;Persist Security Info=True;User ID=admin;Password=jp;Encrypt=True;TrustServerCertificate=True");
        public CheckPWforEdit()
        {
            InitializeComponent();
        }

        private void verifyBtn_Click(object sender, EventArgs e)
        {
            string password = pwInput.Texts.Trim();

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("กรุณากรอกรหัสผ่าน", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string query = "SELECT COUNT(*) FROM PasswordForEdit WHERE Password = @Password";

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Password", password);
                int count = (int)cmd.ExecuteScalar();

                if (count > 0)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("รหัสผ่านไม่ถูกต้อง", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
