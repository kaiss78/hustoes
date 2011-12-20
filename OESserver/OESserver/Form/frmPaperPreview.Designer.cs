namespace OES
{
    partial class frmPaperPreview
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
            this.dgvPaperPreview = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaperPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPaperPreview
            // 
            this.dgvPaperPreview.AllowUserToAddRows = false;
            this.dgvPaperPreview.Location = new System.Drawing.Point(12, 12);
            this.dgvPaperPreview.Name = "dgvPaperPreview";
            this.dgvPaperPreview.ReadOnly = true;
            this.dgvPaperPreview.RowHeadersVisible = false;
            this.dgvPaperPreview.RowTemplate.Height = 23;
            this.dgvPaperPreview.Size = new System.Drawing.Size(667, 332);
            this.dgvPaperPreview.TabIndex = 0;
            // 
            // frmPaperPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 382);
            this.Controls.Add(this.dgvPaperPreview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmPaperPreview";
            this.Text = "试卷预览";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaperPreview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvPaperPreview;
    }
}