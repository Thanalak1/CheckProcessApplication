namespace CheckProcessApplication
{
    partial class CheckPWforEdit
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
            this.pwInput = new CheckProcessApplication.CustomTools.TextBoxCustom();
            this.verifyBtn = new CheckProcessApplication.CustomTools.BtnCustom();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pwInput
            // 
            this.pwInput.BackColor = System.Drawing.SystemColors.Window;
            this.pwInput.BorderColor = System.Drawing.Color.LightPink;
            this.pwInput.BorderFocusColor = System.Drawing.Color.HotPink;
            this.pwInput.BorderRadius = 0;
            this.pwInput.BorderSize = 2;
            this.pwInput.Location = new System.Drawing.Point(136, 72);
            this.pwInput.Multiline = true;
            this.pwInput.Name = "pwInput";
            this.pwInput.PasswordChar = false;
            this.pwInput.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.pwInput.PlaceholderText = "";
            this.pwInput.Size = new System.Drawing.Size(284, 30);
            this.pwInput.TabIndex = 0;
            this.pwInput.Texts = "";
            this.pwInput.UnderLineStyle = false;
            // 
            // verifyBtn
            // 
            this.verifyBtn.BackColor = System.Drawing.Color.RoyalBlue;
            this.verifyBtn.BorderRadius = 0;
            this.verifyBtn.BorderSize = 0;
            this.verifyBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.verifyBtn.FlatAppearance.BorderSize = 0;
            this.verifyBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.verifyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.verifyBtn.ForeColor = System.Drawing.Color.White;
            this.verifyBtn.Location = new System.Drawing.Point(136, 124);
            this.verifyBtn.Name = "verifyBtn";
            this.verifyBtn.Size = new System.Drawing.Size(284, 40);
            this.verifyBtn.TabIndex = 12;
            this.verifyBtn.Text = "Verify";
            this.verifyBtn.UseVisualStyleBackColor = false;
            this.verifyBtn.Click += new System.EventHandler(this.verifyBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Angsana New", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(92, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(382, 50);
            this.label1.TabIndex = 13;
            this.label1.Text = "โปรดกรอกรหัสผ่านเพื่อแก้ไขข้อมูล";
            // 
            // CheckPWforEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(550, 231);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.verifyBtn);
            this.Controls.Add(this.pwInput);
            this.Name = "CheckPWforEdit";
            this.Text = "CheckPWforEdit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomTools.TextBoxCustom pwInput;
        private CustomTools.BtnCustom verifyBtn;
        private System.Windows.Forms.Label label1;
    }
}