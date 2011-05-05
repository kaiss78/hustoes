namespace OES.UControl
{
    partial class PointEdit
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
            this.testExcel1 = new testExcel.testExcel();
            this.SuspendLayout();
            // 
            // testExcel1
            // 
            this.testExcel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testExcel1.Location = new System.Drawing.Point(0, 0);
            this.testExcel1.Name = "testExcel1";
            this.testExcel1.Size = new System.Drawing.Size(593, 666);
            this.testExcel1.TabIndex = 0;
            // 
            // PointEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.testExcel1);
            this.Name = "PointEdit";
            this.Size = new System.Drawing.Size(593, 666);
            this.ResumeLayout(false);

        }

        #endregion

        private testExcel.testExcel testExcel1;
    }
}
