namespace CheckProcessApplication
{
    partial class BuryForms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuryForms));
            this.BuryTitle = new System.Windows.Forms.Label();
            this.InvHead = new System.Windows.Forms.Label();
            this.InvInput = new CheckProcessApplication.CustomTools.TextBoxCustom();
            this.previewBtn = new CheckProcessApplication.CustomTools.BtnCustom();
            this.CloseBtn = new CheckProcessApplication.CustomTools.BtnCustom();
            this.SuspendLayout();
            // 
            // BuryTitle
            // 
            this.BuryTitle.AutoSize = true;
            this.BuryTitle.Font = new System.Drawing.Font("Angsana New", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.BuryTitle.Location = new System.Drawing.Point(216, 3);
            this.BuryTitle.Name = "BuryTitle";
            this.BuryTitle.Size = new System.Drawing.Size(243, 50);
            this.BuryTitle.TabIndex = 0;
            this.BuryTitle.Text = "โปรแกรมตรวจงานฝัง";
            // 
            // InvHead
            // 
            this.InvHead.AutoSize = true;
            this.InvHead.Font = new System.Drawing.Font("Angsana New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.InvHead.Location = new System.Drawing.Point(224, 67);
            this.InvHead.Name = "InvHead";
            this.InvHead.Size = new System.Drawing.Size(49, 26);
            this.InvHead.TabIndex = 1;
            this.InvHead.Text = "Inv No.";
            // 
            // InvInput
            // 
            this.InvInput.BackColor = System.Drawing.SystemColors.Window;
            this.InvInput.BorderColor = System.Drawing.Color.LightPink;
            this.InvInput.BorderFocusColor = System.Drawing.Color.HotPink;
            this.InvInput.BorderRadius = 0;
            this.InvInput.BorderSize = 2;
            this.InvInput.Location = new System.Drawing.Point(229, 96);
            this.InvInput.Multiline = true;
            this.InvInput.Name = "InvInput";
            this.InvInput.PasswordChar = false;
            this.InvInput.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.InvInput.PlaceholderText = "";
            this.InvInput.Size = new System.Drawing.Size(220, 30);
            this.InvInput.TabIndex = 2;
            this.InvInput.Texts = "";
            this.InvInput.UnderLineStyle = false;
            // 
            // previewBtn
            // 
            this.previewBtn.BackColor = System.Drawing.Color.RoyalBlue;
            this.previewBtn.BorderRadius = 0;
            this.previewBtn.BorderSize = 0;
            this.previewBtn.FlatAppearance.BorderSize = 0;
            this.previewBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.previewBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.previewBtn.ForeColor = System.Drawing.Color.White;
            this.previewBtn.Location = new System.Drawing.Point(229, 143);
            this.previewBtn.Name = "previewBtn";
            this.previewBtn.Size = new System.Drawing.Size(220, 40);
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
            this.CloseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.CloseBtn.ForeColor = System.Drawing.Color.White;
            this.CloseBtn.Location = new System.Drawing.Point(229, 203);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(220, 40);
            this.CloseBtn.TabIndex = 4;
            this.CloseBtn.Text = "Close";
            this.CloseBtn.UseVisualStyleBackColor = false;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // BuryForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(695, 476);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.previewBtn);
            this.Controls.Add(this.InvInput);
            this.Controls.Add(this.InvHead);
            this.Controls.Add(this.BuryTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BuryForms";
            this.Text = "ตรวจงานฝัง";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label BuryTitle;
        private System.Windows.Forms.Label InvHead;
        private CustomTools.TextBoxCustom InvInput;
        private CustomTools.BtnCustom previewBtn;
        private CustomTools.BtnCustom CloseBtn;
    }
}