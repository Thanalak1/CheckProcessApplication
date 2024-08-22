namespace CheckProcessApplication
{
    partial class BatheAndPolish
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpInput = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SrateInput = new CheckProcessApplication.CustomTools.TextBoxCustom();
            this.CloseBtn = new CheckProcessApplication.CustomTools.BtnCustom();
            this.previewBtn = new CheckProcessApplication.CustomTools.BtnCustom();
            this.invInput = new CheckProcessApplication.CustomTools.TextBoxCustom();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Angsana New", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(192, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(293, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "โปรแกรมตรวจงานขัด+ชุบ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Angsana New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(196, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Inv No.";
            // 
            // dtpInput
            // 
            this.dtpInput.Location = new System.Drawing.Point(114, 283);
            this.dtpInput.Name = "dtpInput";
            this.dtpInput.Size = new System.Drawing.Size(200, 20);
            this.dtpInput.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Angsana New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(32, 283);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 26);
            this.label3.TabIndex = 6;
            this.label3.Text = "วันที่";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Angsana New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(32, 339);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 26);
            this.label4.TabIndex = 8;
            this.label4.Text = "Rate เนื้อเงิน";
            // 
            // SrateInput
            // 
            this.SrateInput.BackColor = System.Drawing.SystemColors.Window;
            this.SrateInput.BorderColor = System.Drawing.Color.LightPink;
            this.SrateInput.BorderFocusColor = System.Drawing.Color.HotPink;
            this.SrateInput.BorderRadius = 0;
            this.SrateInput.BorderSize = 2;
            this.SrateInput.Location = new System.Drawing.Point(114, 336);
            this.SrateInput.Multiline = true;
            this.SrateInput.Name = "SrateInput";
            this.SrateInput.PasswordChar = false;
            this.SrateInput.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.SrateInput.PlaceholderText = "";
            this.SrateInput.Size = new System.Drawing.Size(250, 30);
            this.SrateInput.TabIndex = 7;
            this.SrateInput.Texts = "";
            this.SrateInput.UnderLineStyle = false;
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
            this.CloseBtn.Location = new System.Drawing.Point(201, 188);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(284, 40);
            this.CloseBtn.TabIndex = 4;
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
            this.previewBtn.Location = new System.Drawing.Point(201, 136);
            this.previewBtn.Name = "previewBtn";
            this.previewBtn.Size = new System.Drawing.Size(284, 40);
            this.previewBtn.TabIndex = 3;
            this.previewBtn.Text = "Preview";
            this.previewBtn.UseVisualStyleBackColor = false;
            this.previewBtn.Click += new System.EventHandler(this.previewBtn_Click);
            // 
            // invInput
            // 
            this.invInput.BackColor = System.Drawing.SystemColors.Window;
            this.invInput.BorderColor = System.Drawing.Color.LightPink;
            this.invInput.BorderFocusColor = System.Drawing.Color.HotPink;
            this.invInput.BorderRadius = 0;
            this.invInput.BorderSize = 2;
            this.invInput.Location = new System.Drawing.Point(201, 88);
            this.invInput.Multiline = true;
            this.invInput.Name = "invInput";
            this.invInput.PasswordChar = false;
            this.invInput.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.invInput.PlaceholderText = "";
            this.invInput.Size = new System.Drawing.Size(284, 30);
            this.invInput.TabIndex = 2;
            this.invInput.Texts = "";
            this.invInput.UnderLineStyle = false;
            // 
            // BatheAndPolish
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(695, 476);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SrateInput);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpInput);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.previewBtn);
            this.Controls.Add(this.invInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "BatheAndPolish";
            this.Text = "ตรวจงานขัด+ชุบ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private CustomTools.TextBoxCustom invInput;
        private CustomTools.BtnCustom previewBtn;
        private CustomTools.BtnCustom CloseBtn;
        private System.Windows.Forms.DateTimePicker dtpInput;
        private System.Windows.Forms.Label label3;
        private CustomTools.TextBoxCustom SrateInput;
        private System.Windows.Forms.Label label4;
    }
}