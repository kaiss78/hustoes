namespace OES.UControl
{
    partial class ProblemDGV
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.proDGV = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.proDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // proDGV
            // 
            this.proDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.proDGV.Location = new System.Drawing.Point(0, 0);
            this.proDGV.Name = "proDGV";
            this.proDGV.RowTemplate.Height = 23;
            this.proDGV.Size = new System.Drawing.Size(527, 490);
            this.proDGV.TabIndex = 0;
            // 
            // ProblemDGV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.proDGV);
            this.Name = "ProblemDGV";
            this.Size = new System.Drawing.Size(527, 490);
            ((System.ComponentModel.ISupportInitialize)(this.proDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView proDGV;
    }
}
