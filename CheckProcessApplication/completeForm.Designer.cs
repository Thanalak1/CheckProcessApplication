namespace CheckProcessApplication
{
    partial class completeForm
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
            this.InvInput = new CheckProcessApplication.CustomTools.TextBoxCustom();
            this.label2 = new System.Windows.Forms.Label();
            this.previewBtn = new System.Windows.Forms.Button();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Angsana New", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(34, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(324, 43);
            this.label1.TabIndex = 0;
            this.label1.Text = "โปรแกรมตรวจงานสำเร็จ-งานสร้อย";
            // 
            // InvInput
            // 
            this.InvInput.BackColor = System.Drawing.SystemColors.Window;
            this.InvInput.BorderColor = System.Drawing.Color.LightPink;
            this.InvInput.BorderFocusColor = System.Drawing.Color.HotPink;
            this.InvInput.BorderRadius = 0;
            this.InvInput.BorderSize = 2;
            this.InvInput.Location = new System.Drawing.Point(42, 141);
            this.InvInput.Multiline = true;
            this.InvInput.Name = "InvInput";
            this.InvInput.PasswordChar = false;
            this.InvInput.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.InvInput.PlaceholderText = "";
            this.InvInput.Size = new System.Drawing.Size(303, 30);
            this.InvInput.TabIndex = 1;
            this.InvInput.Texts = "";
            this.InvInput.UnderLineStyle = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Inv No.";
            // 
            // previewBtn
            // 
            this.previewBtn.BackColor = System.Drawing.Color.RoyalBlue;
            this.previewBtn.FlatAppearance.BorderSize = 0;
            this.previewBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.previewBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.previewBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.previewBtn.Location = new System.Drawing.Point(42, 219);
            this.previewBtn.Name = "previewBtn";
            this.previewBtn.Size = new System.Drawing.Size(303, 44);
            this.previewBtn.TabIndex = 3;
            this.previewBtn.Text = "Preview";
            this.previewBtn.UseVisualStyleBackColor = false;
            this.previewBtn.Click += new System.EventHandler(this.previewBtn_Click);
            // 
            // CloseBtn
            // 
            this.CloseBtn.BackColor = System.Drawing.Color.Crimson;
            this.CloseBtn.FlatAppearance.BorderSize = 0;
            this.CloseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.CloseBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.CloseBtn.Location = new System.Drawing.Point(42, 287);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(303, 44);
            this.CloseBtn.TabIndex = 4;
            this.CloseBtn.Text = "Close";
            this.CloseBtn.UseVisualStyleBackColor = false;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // completeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 411);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.previewBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.InvInput);
            this.Controls.Add(this.label1);
            this.Name = "completeForm";
            this.Text = "ตรวจงานสำเร็จงานสร้อย";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private CustomTools.TextBoxCustom InvInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button previewBtn;
        private System.Windows.Forms.Button CloseBtn;
    }
}