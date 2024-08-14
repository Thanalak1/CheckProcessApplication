namespace CheckProcessApplication
{
    partial class uCheckPass
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DateStart = new System.Windows.Forms.DateTimePicker();
            this.DateEnd = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboJobName = new System.Windows.Forms.ComboBox();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cJobBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cBillNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cOrderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cListNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cJobName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cEmpCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cpass_ok = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cpass_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnDelete = new CheckProcessApplication.CustomTools.BtnCustom();
            this.btnCustom2 = new CheckProcessApplication.CustomTools.BtnCustom();
            this.txtOrderNo = new CheckProcessApplication.CustomTools.TextBoxCustom();
            this.previewBtn = new CheckProcessApplication.CustomTools.BtnCustom();
            this.txtEmpCode = new CheckProcessApplication.CustomTools.TextBoxCustom();
            this.btnCustom1 = new CheckProcessApplication.CustomTools.BtnCustom();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Angsana New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(12, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 26);
            this.label3.TabIndex = 18;
            this.label3.Text = "Order No.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Angsana New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 26);
            this.label2.TabIndex = 14;
            this.label2.Text = "รหัสช่าง";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Angsana New", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(330, -5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 50);
            this.label1.TabIndex = 12;
            this.label1.Text = "โปรแกรมตรวจงานออก";
            // 
            // DateStart
            // 
            this.DateStart.Font = new System.Drawing.Font("Angsana New", 14.25F);
            this.DateStart.Location = new System.Drawing.Point(419, 40);
            this.DateStart.Name = "DateStart";
            this.DateStart.Size = new System.Drawing.Size(159, 33);
            this.DateStart.TabIndex = 19;
            // 
            // DateEnd
            // 
            this.DateEnd.Font = new System.Drawing.Font("Angsana New", 14.25F);
            this.DateEnd.Location = new System.Drawing.Point(419, 93);
            this.DateEnd.Name = "DateEnd";
            this.DateEnd.Size = new System.Drawing.Size(159, 33);
            this.DateEnd.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Angsana New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(378, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 26);
            this.label4.TabIndex = 21;
            this.label4.Text = "วันที่";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Angsana New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.Location = new System.Drawing.Point(388, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 26);
            this.label5.TabIndex = 22;
            this.label5.Text = "ถึง";
            // 
            // cboJobName
            // 
            this.cboJobName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboJobName.Font = new System.Drawing.Font("Angsana New", 14.25F);
            this.cboJobName.FormattingEnabled = true;
            this.cboJobName.Location = new System.Drawing.Point(17, 165);
            this.cboJobName.Name = "cboJobName";
            this.cboJobName.Size = new System.Drawing.Size(185, 34);
            this.cboJobName.TabIndex = 24;
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.Font = new System.Drawing.Font("Angsana New", 14.25F);
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(246, 165);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(185, 34);
            this.cboStatus.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Angsana New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label6.Location = new System.Drawing.Point(12, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 26);
            this.label6.TabIndex = 26;
            this.label6.Text = "ประเภทงาน";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Angsana New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label7.Location = new System.Drawing.Point(241, 136);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 26);
            this.label7.TabIndex = 27;
            this.label7.Text = "สถานะการตรวจงาน";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cSelected,
            this.cJobBarcode,
            this.cBillNo,
            this.cOrderNo,
            this.cListNo,
            this.cJobName,
            this.cEmpCode,
            this.Column1,
            this.cpass_ok,
            this.cpass_date,
            this.cID});
            this.dataGridView1.Location = new System.Drawing.Point(16, 211);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1017, 446);
            this.dataGridView1.TabIndex = 28;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.CurrentCellDirtyStateChanged += new System.EventHandler(this.dataGridView1_CurrentCellDirtyStateChanged);
            // 
            // cSelected
            // 
            this.cSelected.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cSelected.DataPropertyName = "Selected";
            this.cSelected.HeaderText = "เลือกรายการ";
            this.cSelected.Name = "cSelected";
            this.cSelected.Width = 73;
            // 
            // cJobBarcode
            // 
            this.cJobBarcode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cJobBarcode.DataPropertyName = "JobBarcode";
            this.cJobBarcode.HeaderText = "รหัสรับงานช่าง";
            this.cJobBarcode.Name = "cJobBarcode";
            this.cJobBarcode.Width = 99;
            // 
            // cBillNo
            // 
            this.cBillNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cBillNo.DataPropertyName = "DocNo";
            this.cBillNo.HeaderText = "เลขที่บิลจ่ายงาน";
            this.cBillNo.Name = "cBillNo";
            this.cBillNo.Width = 80;
            // 
            // cOrderNo
            // 
            this.cOrderNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cOrderNo.DataPropertyName = "OrderNo";
            this.cOrderNo.HeaderText = "Order No.";
            this.cOrderNo.Name = "cOrderNo";
            this.cOrderNo.Width = 72;
            // 
            // cListNo
            // 
            this.cListNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cListNo.DataPropertyName = "ListNo";
            this.cListNo.HeaderText = "ลำดับที่";
            this.cListNo.Name = "cListNo";
            this.cListNo.Width = 60;
            // 
            // cJobName
            // 
            this.cJobName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cJobName.DataPropertyName = "JobName";
            this.cJobName.HeaderText = "ประเภทงาน";
            this.cJobName.Name = "cJobName";
            this.cJobName.Width = 80;
            // 
            // cEmpCode
            // 
            this.cEmpCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cEmpCode.DataPropertyName = "EmpCode";
            this.cEmpCode.HeaderText = "รหัสช่าง";
            this.cEmpCode.Name = "cEmpCode";
            this.cEmpCode.Width = 63;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column1.DataPropertyName = "EmpName";
            this.Column1.HeaderText = "ชื่อช่าง";
            this.Column1.Name = "Column1";
            this.Column1.Width = 58;
            // 
            // cpass_ok
            // 
            this.cpass_ok.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cpass_ok.DataPropertyName = "pass_ok";
            this.cpass_ok.HeaderText = "สถานะการทำงาน";
            this.cpass_ok.Name = "cpass_ok";
            this.cpass_ok.Width = 86;
            // 
            // cpass_date
            // 
            this.cpass_date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cpass_date.DataPropertyName = "pass_date";
            this.cpass_date.HeaderText = "วันที่ตรวจออก";
            this.cpass_date.Name = "cpass_date";
            this.cpass_date.Width = 89;
            // 
            // cID
            // 
            this.cID.DataPropertyName = "ID";
            this.cID.HeaderText = "ID";
            this.cID.Name = "cID";
            this.cID.Visible = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(455, 174);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(123, 17);
            this.checkBox1.TabIndex = 29;
            this.checkBox1.Text = "เฉพาะบิลที่ยังไม่ปริ้น";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnDelete.BorderRadius = 0;
            this.btnDelete.BorderSize = 0;
            this.btnDelete.Enabled = false;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(758, 663);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(136, 40);
            this.btnDelete.TabIndex = 32;
            this.btnDelete.Text = "แก้ไขสถานะ";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnCustom1_Click);
            // 
            // btnCustom2
            // 
            this.btnCustom2.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnCustom2.BorderRadius = 0;
            this.btnCustom2.BorderSize = 0;
            this.btnCustom2.FlatAppearance.BorderSize = 0;
            this.btnCustom2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustom2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnCustom2.ForeColor = System.Drawing.Color.White;
            this.btnCustom2.Location = new System.Drawing.Point(608, 165);
            this.btnCustom2.Name = "btnCustom2";
            this.btnCustom2.Size = new System.Drawing.Size(103, 40);
            this.btnCustom2.TabIndex = 31;
            this.btnCustom2.Text = "Search";
            this.btnCustom2.UseVisualStyleBackColor = false;
            this.btnCustom2.Click += new System.EventHandler(this.btnCustom2_Click);
            // 
            // txtOrderNo
            // 
            this.txtOrderNo.BackColor = System.Drawing.SystemColors.Window;
            this.txtOrderNo.BorderColor = System.Drawing.Color.LightPink;
            this.txtOrderNo.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtOrderNo.BorderRadius = 0;
            this.txtOrderNo.BorderSize = 2;
            this.txtOrderNo.Location = new System.Drawing.Point(80, 98);
            this.txtOrderNo.Multiline = true;
            this.txtOrderNo.Name = "txtOrderNo";
            this.txtOrderNo.PasswordChar = false;
            this.txtOrderNo.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtOrderNo.PlaceholderText = "";
            this.txtOrderNo.Size = new System.Drawing.Size(254, 30);
            this.txtOrderNo.TabIndex = 17;
            this.txtOrderNo.Texts = "";
            this.txtOrderNo.UnderLineStyle = false;
            // 
            // previewBtn
            // 
            this.previewBtn.BackColor = System.Drawing.Color.RoyalBlue;
            this.previewBtn.BorderRadius = 0;
            this.previewBtn.BorderSize = 0;
            this.previewBtn.Enabled = false;
            this.previewBtn.FlatAppearance.BorderSize = 0;
            this.previewBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.previewBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.previewBtn.ForeColor = System.Drawing.Color.White;
            this.previewBtn.Location = new System.Drawing.Point(900, 663);
            this.previewBtn.Name = "previewBtn";
            this.previewBtn.Size = new System.Drawing.Size(133, 40);
            this.previewBtn.TabIndex = 15;
            this.previewBtn.Text = "Preview";
            this.previewBtn.UseVisualStyleBackColor = false;
            this.previewBtn.Click += new System.EventHandler(this.previewBtn_Click);
            // 
            // txtEmpCode
            // 
            this.txtEmpCode.BackColor = System.Drawing.SystemColors.Window;
            this.txtEmpCode.BorderColor = System.Drawing.Color.LightPink;
            this.txtEmpCode.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtEmpCode.BorderRadius = 0;
            this.txtEmpCode.BorderSize = 2;
            this.txtEmpCode.Location = new System.Drawing.Point(80, 45);
            this.txtEmpCode.Multiline = true;
            this.txtEmpCode.Name = "txtEmpCode";
            this.txtEmpCode.PasswordChar = false;
            this.txtEmpCode.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtEmpCode.PlaceholderText = "";
            this.txtEmpCode.Size = new System.Drawing.Size(254, 30);
            this.txtEmpCode.TabIndex = 13;
            this.txtEmpCode.Texts = "";
            this.txtEmpCode.UnderLineStyle = false;
            // 
            // btnCustom1
            // 
            this.btnCustom1.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnCustom1.BorderRadius = 0;
            this.btnCustom1.BorderSize = 0;
            this.btnCustom1.FlatAppearance.BorderSize = 0;
            this.btnCustom1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustom1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnCustom1.ForeColor = System.Drawing.Color.White;
            this.btnCustom1.Location = new System.Drawing.Point(748, 165);
            this.btnCustom1.Name = "btnCustom1";
            this.btnCustom1.Size = new System.Drawing.Size(177, 40);
            this.btnCustom1.TabIndex = 33;
            this.btnCustom1.Text = "List Print";
            this.btnCustom1.UseVisualStyleBackColor = false;
            this.btnCustom1.Click += new System.EventHandler(this.btnCustom1_Click_1);
            // 
            // uCheckPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1045, 715);
            this.Controls.Add(this.btnCustom1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCustom2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboStatus);
            this.Controls.Add(this.cboJobName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DateEnd);
            this.Controls.Add(this.DateStart);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtOrderNo);
            this.Controls.Add(this.previewBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEmpCode);
            this.Controls.Add(this.label1);
            this.Name = "uCheckPass";
            this.Text = "uCheckPass";
            this.Load += new System.EventHandler(this.uCheckPass_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private CustomTools.TextBoxCustom txtOrderNo;
        private CustomTools.BtnCustom previewBtn;
        private System.Windows.Forms.Label label2;
        private CustomTools.TextBoxCustom txtEmpCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DateStart;
        private System.Windows.Forms.DateTimePicker DateEnd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboJobName;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckBox checkBox1;
        private CustomTools.BtnCustom btnCustom2;
        private CustomTools.BtnCustom btnDelete;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn cJobBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn cBillNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cOrderNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cListNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cJobName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cEmpCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cpass_ok;
        private System.Windows.Forms.DataGridViewTextBoxColumn cpass_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn cID;
        private CustomTools.BtnCustom btnCustom1;
    }
}