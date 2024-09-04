namespace CheckProcessApplication
{
    partial class SilverRateBnP
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
            this.label4 = new System.Windows.Forms.Label();
            this.SrateInput = new CheckProcessApplication.CustomTools.TextBoxCustom();
            this.saveBtn = new CheckProcessApplication.CustomTools.BtnCustom();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Angsana New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(131, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 26);
            this.label4.TabIndex = 10;
            this.label4.Text = "Rate เนื้อเงิน";
            // 
            // SrateInput
            // 
            this.SrateInput.BackColor = System.Drawing.SystemColors.Window;
            this.SrateInput.BorderColor = System.Drawing.Color.LightPink;
            this.SrateInput.BorderFocusColor = System.Drawing.Color.HotPink;
            this.SrateInput.BorderRadius = 0;
            this.SrateInput.BorderSize = 2;
            this.SrateInput.Location = new System.Drawing.Point(136, 97);
            this.SrateInput.Multiline = true;
            this.SrateInput.Name = "SrateInput";
            this.SrateInput.PasswordChar = false;
            this.SrateInput.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.SrateInput.PlaceholderText = "";
            this.SrateInput.Size = new System.Drawing.Size(284, 30);
            this.SrateInput.TabIndex = 9;
            this.SrateInput.Texts = "";
            this.SrateInput.UnderLineStyle = false;
            // 
            // saveBtn
            // 
            this.saveBtn.BackColor = System.Drawing.Color.ForestGreen;
            this.saveBtn.BorderRadius = 0;
            this.saveBtn.BorderSize = 0;
            this.saveBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saveBtn.FlatAppearance.BorderSize = 0;
            this.saveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.saveBtn.ForeColor = System.Drawing.Color.White;
            this.saveBtn.Location = new System.Drawing.Point(136, 146);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(284, 40);
            this.saveBtn.TabIndex = 11;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = false;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Angsana New", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(127, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(268, 50);
            this.label1.TabIndex = 12;
            this.label1.Text = "Rate เนื้อเงิน งานขัด+ชุบ";
            // 
            // SilverRateBnP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(550, 231);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SrateInput);
            this.Name = "SilverRateBnP";
            this.Text = "Rate เนื้อเงิน งานขัด+ชุบ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private CustomTools.TextBoxCustom SrateInput;
        private CustomTools.BtnCustom saveBtn;
        private System.Windows.Forms.Label label1;
    }
}