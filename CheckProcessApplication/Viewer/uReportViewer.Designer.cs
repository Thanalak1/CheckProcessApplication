namespace WindowsFormsApp2
{
    partial class uReportViewer
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
            this.cReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // cReportViewer
            // 
            this.cReportViewer.ActiveViewIndex = -1;
            this.cReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.cReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cReportViewer.Location = new System.Drawing.Point(0, 0);
            this.cReportViewer.Name = "cReportViewer";
            this.cReportViewer.Size = new System.Drawing.Size(933, 554);
            this.cReportViewer.TabIndex = 0;
            // 
            // uReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 554);
            this.Controls.Add(this.cReportViewer);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "uReportViewer";
            this.Text = "uReportViewer";
            this.Load += new System.EventHandler(this.uReportViewer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer cReportViewer;
    }
}