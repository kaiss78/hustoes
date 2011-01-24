namespace OES.UControl
{
    partial class ProblemItem
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ItemText = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.ItemNo = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.ItemText, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.ItemNo, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(500, 40);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // ItemText
            // 
            this.ItemText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ItemText.Location = new System.Drawing.Point(61, 3);
            this.ItemText.Margin = new System.Windows.Forms.Padding(1, 3, 3, 3);
            this.ItemText.Name = "ItemText";
            this.ItemText.Size = new System.Drawing.Size(436, 34);
            this.ItemText.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.ItemText.StateCommon.Border.Rounding = 15;
            this.ItemText.TabIndex = 0;
            this.ItemText.Values.Text = "Text";
            this.ItemText.Click += new System.EventHandler(this.ItemText_Click);
            // 
            // ItemNo
            // 
            this.ItemNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ItemNo.Location = new System.Drawing.Point(3, 3);
            this.ItemNo.Margin = new System.Windows.Forms.Padding(3, 3, 1, 3);
            this.ItemNo.Name = "ItemNo";
            this.ItemNo.Size = new System.Drawing.Size(56, 34);
            this.ItemNo.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)));
            this.ItemNo.StateCommon.Border.Rounding = 15;
            this.ItemNo.TabIndex = 1;
            this.ItemNo.Values.Text = "No";
            // 
            // ProblemItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.Name = "ProblemItem";
            this.Size = new System.Drawing.Size(500, 40);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public ComponentFactory.Krypton.Toolkit.KryptonButton ItemText;
        public ComponentFactory.Krypton.Toolkit.KryptonButton ItemNo;
    }
}
