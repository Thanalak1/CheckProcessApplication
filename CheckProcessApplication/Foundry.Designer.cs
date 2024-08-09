namespace CheckProcessApplication
{
    partial class Foundry
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
            this.CloseBtn = new CheckProcessApplication.CustomTools.BtnCustom();
            this.previewBtn = new CheckProcessApplication.CustomTools.BtnCustom();
            this.label2 = new System.Windows.Forms.Label();
            this.InvInput = new CheckProcessApplication.CustomTools.TextBoxCustom();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxCustom1 = new CheckProcessApplication.CustomTools.TextBoxCustom();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            this.CloseBtn.Location = new System.Drawing.Point(219, 239);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(256, 40);
            this.CloseBtn.TabIndex = 9;
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
            this.previewBtn.Location = new System.Drawing.Point(219, 176);
            this.previewBtn.Name = "previewBtn";
            this.previewBtn.Size = new System.Drawing.Size(256, 40);
            this.previewBtn.TabIndex = 8;
            this.previewBtn.Text = "Preview";
            this.previewBtn.UseVisualStyleBackColor = false;
            this.previewBtn.Click += new System.EventHandler(this.previewBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Angsana New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(221, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 26);
            this.label2.TabIndex = 7;
            this.label2.Text = "Inv No.";
            // 
            // InvInput
            // 
            this.InvInput.BackColor = System.Drawing.SystemColors.Window;
            this.InvInput.BorderColor = System.Drawing.Color.LightPink;
            this.InvInput.BorderFocusColor = System.Drawing.Color.HotPink;
            this.InvInput.BorderRadius = 0;
            this.InvInput.BorderSize = 2;
            this.InvInput.Location = new System.Drawing.Point(219, 78);
            this.InvInput.Multiline = true;
            this.InvInput.Name = "InvInput";
            this.InvInput.PasswordChar = false;
            this.InvInput.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.InvInput.PlaceholderText = "";
            this.InvInput.Size = new System.Drawing.Size(256, 30);
            this.InvInput.TabIndex = 6;
            this.InvInput.Texts = "";
            this.InvInput.UnderLineStyle = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Angsana New", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(217, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 50);
            this.label1.TabIndex = 5;
            this.label1.Text = "โปรแกรมตรวจงานหล่อ";
            // 
            // textBoxCustom1
            // 
            this.textBoxCustom1.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxCustom1.BorderColor = System.Drawing.Color.LightPink;
            this.textBoxCustom1.BorderFocusColor = System.Drawing.Color.HotPink;
            this.textBoxCustom1.BorderRadius = 0;
            this.textBoxCustom1.BorderSize = 2;
            this.textBoxCustom1.Location = new System.Drawing.Point(219, 140);
            this.textBoxCustom1.Multiline = true;
            this.textBoxCustom1.Name = "textBoxCustom1";
            this.textBoxCustom1.PasswordChar = false;
            this.textBoxCustom1.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.textBoxCustom1.PlaceholderText = "";
            this.textBoxCustom1.Size = new System.Drawing.Size(256, 30);
            this.textBoxCustom1.TabIndex = 10;
            this.textBoxCustom1.Texts = "";
            this.textBoxCustom1.UnderLineStyle = false;
            this.textBoxCustom1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCustom1_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Angsana New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(221, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 26);
            this.label3.TabIndex = 11;
            this.label3.Text = "จำนวนที่ใช้หาร";
            // 
            // Foundry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 476);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxCustom1);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.previewBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.InvInput);
            this.Controls.Add(this.label1);
            this.Name = "Foundry";
            this.Text = "Foundry";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomTools.BtnCustom CloseBtn;
        private CustomTools.BtnCustom previewBtn;
        private System.Windows.Forms.Label label2;
        private CustomTools.TextBoxCustom InvInput;
        private System.Windows.Forms.Label label1;
        private CustomTools.TextBoxCustom textBoxCustom1;
        private System.Windows.Forms.Label label3;
    }
}