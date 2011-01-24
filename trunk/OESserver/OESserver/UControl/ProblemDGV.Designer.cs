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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.proDGV = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.proListBox = new ComponentFactory.Krypton.Toolkit.KryptonListBox();
            ((System.ComponentModel.ISupportInitialize)(this.proDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // proDGV
            // 
            this.proDGV.AllowUserToDeleteRows = false;
            this.proDGV.AllowUserToOrderColumns = true;
            this.proDGV.AllowUserToResizeColumns = false;
            this.proDGV.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.proDGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.proDGV.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.proDGV.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Mixed;
            this.proDGV.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundSheet;
            this.proDGV.GridStyles.StyleColumn = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.proDGV.GridStyles.StyleRow = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.proDGV.ImeMode = System.Windows.Forms.ImeMode.On;
            this.proDGV.Location = new System.Drawing.Point(0, 461);
            this.proDGV.Margin = new System.Windows.Forms.Padding(5);
            this.proDGV.Name = "proDGV";
            this.proDGV.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.proDGV.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.proDGV.RowTemplate.Height = 23;
            this.proDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.proDGV.Size = new System.Drawing.Size(512, 200);
            this.proDGV.TabIndex = 0;
            // 
            // proListBox
            // 
            this.proListBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.proListBox.Location = new System.Drawing.Point(0, 0);
            this.proListBox.Name = "proListBox";
            this.proListBox.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue;
            this.proListBox.Size = new System.Drawing.Size(517, 453);
            this.proListBox.TabIndex = 1;
            // 
            // ProblemDGV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.proListBox);
            this.Controls.Add(this.proDGV);
            this.Name = "ProblemDGV";
            this.Size = new System.Drawing.Size(517, 666);
            ((System.ComponentModel.ISupportInitialize)(this.proDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView proDGV;
        private ComponentFactory.Krypton.Toolkit.KryptonListBox proListBox;
    }
}
