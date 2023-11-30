namespace CheckProcessApplication
{
    partial class BatheForms
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
            this.BatheTitle = new System.Windows.Forms.Label();
            this.InvHead = new System.Windows.Forms.Label();
            this.invInput = new CheckProcessApplication.CustomTools.TextBoxCustom();
            this.previewBtn = new CheckProcessApplication.CustomTools.BtnCustom();
            this.CloseBtn = new CheckProcessApplication.CustomTools.BtnCustom();
            this.SuspendLayout();
            // 
            // BatheTitle
            // 
            this.BatheTitle.AutoSize = true;
            this.BatheTitle.Font = new System.Drawing.Font("Angsana New", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.BatheTitle.Location = new System.Drawing.Point(81, 36);
            this.BatheTitle.Name = "BatheTitle";
            this.BatheTitle.Size = new System.Drawing.Size(249, 50);
            this.BatheTitle.TabIndex = 0;
            this.BatheTitle.Text = "โปรแกรมตรวจงานชุบ";
            // 
            // InvHead
            // 
            this.InvHead.AutoSize = true;
            this.InvHead.Font = new System.Drawing.Font("Angsana New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.InvHead.Location = new System.Drawing.Point(79, 90);
            this.InvHead.Name = "InvHead";
            this.InvHead.Size = new System.Drawing.Size(55, 29);
            this.InvHead.TabIndex = 1;
            this.InvHead.Text = "Inv No.";
            this.InvHead.Click += new System.EventHandler(this.label1_Click);
            // 
            // invInput
            // 
            this.invInput.BackColor = System.Drawing.SystemColors.Window;
            this.invInput.BorderColor = System.Drawing.Color.LightPink;
            this.invInput.BorderFocusColor = System.Drawing.Color.HotPink;
            this.invInput.BorderRadius = 0;
            this.invInput.BorderSize = 2;
            this.invInput.Location = new System.Drawing.Point(84, 123);
            this.invInput.Multiline = true;
            this.invInput.Name = "invInput";
            this.invInput.PasswordChar = false;
            this.invInput.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.invInput.PlaceholderText = "";
            this.invInput.Size = new System.Drawing.Size(250, 30);
            this.invInput.TabIndex = 2;
            this.invInput.Texts = "";
            this.invInput.UnderLineStyle = false;
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
            this.previewBtn.Location = new System.Drawing.Point(84, 194);
            this.previewBtn.Name = "previewBtn";
            this.previewBtn.Size = new System.Drawing.Size(250, 40);
            this.previewBtn.TabIndex = 3;
            this.previewBtn.Text = "Preview";
            this.previewBtn.UseVisualStyleBackColor = false;
            this.previewBtn.Click += new System.EventHandler(this.previewBtn_Click);
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
            this.CloseBtn.Location = new System.Drawing.Point(84, 267);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(250, 40);
            this.CloseBtn.TabIndex = 4;
            this.CloseBtn.Text = "Close";
            this.CloseBtn.UseVisualStyleBackColor = false;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // BatheForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 411);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.previewBtn);
            this.Controls.Add(this.invInput);
            this.Controls.Add(this.InvHead);
            this.Controls.Add(this.BatheTitle);
            this.Name = "BatheForms";
            this.Text = "โปรแกรมตรวจงานชุบ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label BatheTitle;
        private System.Windows.Forms.Label InvHead;
        private CustomTools.TextBoxCustom invInput;
        private CustomTools.BtnCustom previewBtn;
        private CustomTools.BtnCustom CloseBtn;
    }
}