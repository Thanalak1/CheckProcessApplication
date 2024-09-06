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
            this.CloseBtn = new CheckProcessApplication.CustomTools.BtnCustom();
            this.previewBtn = new CheckProcessApplication.CustomTools.BtnCustom();
            this.invInput = new CheckProcessApplication.CustomTools.TextBoxCustom();
            this.silverbtn = new System.Windows.Forms.Button();
            this.SratetxtBox = new CheckProcessApplication.CustomTools.TextBoxCustom();
            this.label3 = new System.Windows.Forms.Label();
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
            // silverbtn
            // 
            this.silverbtn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.silverbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.silverbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.silverbtn.Location = new System.Drawing.Point(536, 272);
            this.silverbtn.Name = "silverbtn";
            this.silverbtn.Size = new System.Drawing.Size(116, 40);
            this.silverbtn.TabIndex = 9;
            this.silverbtn.Text = "Silver Rate";
            this.silverbtn.UseVisualStyleBackColor = false;
            this.silverbtn.Click += new System.EventHandler(this.silverbtn_Click);
            // 
            // SratetxtBox
            // 
            this.SratetxtBox.BackColor = System.Drawing.SystemColors.Window;
            this.SratetxtBox.BorderColor = System.Drawing.Color.LightPink;
            this.SratetxtBox.BorderFocusColor = System.Drawing.Color.HotPink;
            this.SratetxtBox.BorderRadius = 0;
            this.SratetxtBox.BorderSize = 2;
            this.SratetxtBox.Enabled = false;
            this.SratetxtBox.Location = new System.Drawing.Point(30, 280);
            this.SratetxtBox.Multiline = true;
            this.SratetxtBox.Name = "SratetxtBox";
            this.SratetxtBox.PasswordChar = false;
            this.SratetxtBox.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.SratetxtBox.PlaceholderText = "";
            this.SratetxtBox.Size = new System.Drawing.Size(284, 30);
            this.SratetxtBox.TabIndex = 10;
            this.SratetxtBox.Texts = "";
            this.SratetxtBox.UnderLineStyle = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Angsana New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(27, 252);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 26);
            this.label3.TabIndex = 11;
            this.label3.Text = "Rate เนื้อเงินปัจจุบัน";
            // 
            // BatheAndPolish
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(695, 476);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SratetxtBox);
            this.Controls.Add(this.silverbtn);
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
        private System.Windows.Forms.Button silverbtn;
        private CustomTools.TextBoxCustom SratetxtBox;
        private System.Windows.Forms.Label label3;
    }
}