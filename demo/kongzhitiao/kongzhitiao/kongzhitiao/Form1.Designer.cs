namespace kongzhitiao
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.shiti = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // shiti
            // 
            this.shiti.Image = ((System.Drawing.Image)(resources.GetObject("shiti.Image")));
            this.shiti.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.shiti.Location = new System.Drawing.Point(-1, -1);
            this.shiti.Name = "shiti";
            this.shiti.Size = new System.Drawing.Size(135, 36);
            this.shiti.TabIndex = 0;
            this.shiti.Text = "隐藏试题";
            this.shiti.UseVisualStyleBackColor = true;
            this.shiti.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 32);
            this.ControlBox = false;
            this.Controls.Add(this.shiti);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.AutoSizeChanged += new System.EventHandler(this.Form1_AutoSizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button shiti;
    }
}

