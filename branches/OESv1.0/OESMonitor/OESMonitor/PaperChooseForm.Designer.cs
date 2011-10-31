namespace OESMonitor
{
    partial class PaperChooseForm
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
            this.paperListPanel1 = new OES.UPanel.PaperListPanel();
            this.SuspendLayout();
            // 
            // paperListPanel1
            // 
            this.paperListPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paperListPanel1.Location = new System.Drawing.Point(0, 0);
            this.paperListPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.paperListPanel1.Name = "paperListPanel1";
            this.paperListPanel1.Size = new System.Drawing.Size(734, 632);
            this.paperListPanel1.TabIndex = 0;
            // 
            // PaperChooseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 632);
            this.Controls.Add(this.paperListPanel1);
            this.Name = "PaperChooseForm";
            this.Text = "PaperChooseForm";
            this.Load += new System.EventHandler(this.PaperChooseForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private OES.UPanel.PaperListPanel paperListPanel1;

    }
}