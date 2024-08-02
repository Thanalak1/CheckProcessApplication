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
            this.txtOrderNo = new CheckProcessApplication.CustomTools.TextBoxCustom();
            this.CloseBtn = new CheckProcessApplication.CustomTools.BtnCustom();
            this.previewBtn = new CheckProcessApplication.CustomTools.BtnCustom();
            this.txtEmpCode = new CheckProcessApplication.CustomTools.TextBoxCustom();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Angsana New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(159, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 26);
            this.label3.TabIndex = 18;
            this.label3.Text = "Order No.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Angsana New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(159, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 26);
            this.label2.TabIndex = 14;
            this.label2.Text = "รหัสช่าง";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Angsana New", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(217, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 50);
            this.label1.TabIndex = 12;
            this.label1.Text = "โปรแกรมตรวจงานหล่อ";
            // 
            // DateStart
            // 
            this.DateStart.Font = new System.Drawing.Font("Angsana New", 14.25F);
            this.DateStart.Location = new System.Drawing.Point(212, 176);
            this.DateStart.Name = "DateStart";
            this.DateStart.Size = new System.Drawing.Size(159, 33);
            this.DateStart.TabIndex = 19;
            // 
            // DateEnd
            // 
            this.DateEnd.Font = new System.Drawing.Font("Angsana New", 14.25F);
            this.DateEnd.Location = new System.Drawing.Point(408, 176);
            this.DateEnd.Name = "DateEnd";
            this.DateEnd.Size = new System.Drawing.Size(159, 33);
            this.DateEnd.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Angsana New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(171, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 26);
            this.label4.TabIndex = 21;
            this.label4.Text = "วันที่";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Angsana New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.Location = new System.Drawing.Point(377, 181);
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
            this.cboJobName.Location = new System.Drawing.Point(164, 246);
            this.cboJobName.Name = "cboJobName";
            this.cboJobName.Size = new System.Drawing.Size(185, 34);
            this.cboJobName.TabIndex = 24;
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.Font = new System.Drawing.Font("Angsana New", 14.25F);
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(393, 246);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(185, 34);
            this.cboStatus.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Angsana New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label6.Location = new System.Drawing.Point(159, 217);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 26);
            this.label6.TabIndex = 26;
            this.label6.Text = "ประเภทงาน";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Angsana New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label7.Location = new System.Drawing.Point(388, 217);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 26);
            this.label7.TabIndex = 27;
            this.label7.Text = "สถานะการตรวจงาน";
            // 
            // txtOrderNo
            // 
            this.txtOrderNo.BackColor = System.Drawing.SystemColors.Window;
            this.txtOrderNo.BorderColor = System.Drawing.Color.LightPink;
            this.txtOrderNo.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtOrderNo.BorderRadius = 0;
            this.txtOrderNo.BorderSize = 2;
            this.txtOrderNo.Location = new System.Drawing.Point(164, 140);
            this.txtOrderNo.Multiline = true;
            this.txtOrderNo.Name = "txtOrderNo";
            this.txtOrderNo.PasswordChar = false;
            this.txtOrderNo.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtOrderNo.PlaceholderText = "";
            this.txtOrderNo.Size = new System.Drawing.Size(414, 30);
            this.txtOrderNo.TabIndex = 17;
            this.txtOrderNo.Texts = "";
            this.txtOrderNo.UnderLineStyle = false;
            // 
            // CloseBtn
            // 
            this.CloseBtn.BackColor = System.Drawing.Color.Crimson;
            this.CloseBtn.BorderRadius = 0;
            this.CloseBtn.BorderSize = 0;
            this.CloseBtn.FlatAppearance.BorderSize = 0;
            this.CloseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.CloseBtn.ForeColor = System.Drawing.Color.White;
            this.CloseBtn.Location = new System.Drawing.Point(223, 379);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(256, 40);
            this.CloseBtn.TabIndex = 16;
            this.CloseBtn.Text = "Close";
            this.CloseBtn.UseVisualStyleBackColor = false;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // previewBtn
            // 
            this.previewBtn.BackColor = System.Drawing.Color.RoyalBlue;
            this.previewBtn.BorderRadius = 0;
            this.previewBtn.BorderSize = 0;
            this.previewBtn.FlatAppearance.BorderSize = 0;
            this.previewBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.previewBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.previewBtn.ForeColor = System.Drawing.Color.White;
            this.previewBtn.Location = new System.Drawing.Point(223, 316);
            this.previewBtn.Name = "previewBtn";
            this.previewBtn.Size = new System.Drawing.Size(256, 40);
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
            this.txtEmpCode.Location = new System.Drawing.Point(164, 78);
            this.txtEmpCode.Multiline = true;
            this.txtEmpCode.Name = "txtEmpCode";
            this.txtEmpCode.PasswordChar = false;
            this.txtEmpCode.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtEmpCode.PlaceholderText = "";
            this.txtEmpCode.Size = new System.Drawing.Size(414, 30);
            this.txtEmpCode.TabIndex = 13;
            this.txtEmpCode.Texts = "";
            this.txtEmpCode.UnderLineStyle = false;
            // 
            // uCheckPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 476);
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
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.previewBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEmpCode);
            this.Controls.Add(this.label1);
            this.Name = "uCheckPass";
            this.Text = "uCheckPass";
            this.Load += new System.EventHandler(this.uCheckPass_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private CustomTools.TextBoxCustom txtOrderNo;
        private CustomTools.BtnCustom CloseBtn;
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
    }
}