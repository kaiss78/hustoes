namespace OES.UPanel
{
    partial class ProFunction
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
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnSave = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.ofdBrowser = new System.Windows.Forms.OpenFileDialog();
            this.btnBrowserAns = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.tbAnswerFile = new System.Windows.Forms.TextBox();
            this.btnBrowserSource = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.tbProblemFile = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.dgvAnsList = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddAns = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnEdit = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnDel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnsList)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.Location = new System.Drawing.Point(640, 624);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 34);
            this.btnCancel.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnCancel.StateCommon.Border.Rounding = 16;
            this.btnCancel.StateCommon.Content.Padding = new System.Windows.Forms.Padding(0);
            this.btnCancel.StateCommon.Content.ShortText.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnCancel.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnCancel.TabIndex = 23;
            this.btnCancel.Values.Text = "取消";
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = true;
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.Location = new System.Drawing.Point(540, 624);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 34);
            this.btnSave.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSave.StateCommon.Border.Rounding = 16;
            this.btnSave.StateCommon.Content.Padding = new System.Windows.Forms.Padding(0);
            this.btnSave.StateCommon.Content.ShortText.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnSave.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnSave.TabIndex = 22;
            this.btnSave.Values.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ofdBrowser
            // 
            this.ofdBrowser.Filter = "C文件|*.c|C++文件|*.cpp";
            // 
            // btnBrowserAns
            // 
            this.btnBrowserAns.AutoSize = true;
            this.btnBrowserAns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBrowserAns.Location = new System.Drawing.Point(640, 316);
            this.btnBrowserAns.Name = "btnBrowserAns";
            this.btnBrowserAns.Size = new System.Drawing.Size(94, 34);
            this.btnBrowserAns.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnBrowserAns.StateCommon.Border.Rounding = 16;
            this.btnBrowserAns.StateCommon.Content.Padding = new System.Windows.Forms.Padding(0);
            this.btnBrowserAns.StateCommon.Content.ShortText.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnBrowserAns.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnBrowserAns.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnBrowserAns.TabIndex = 21;
            this.btnBrowserAns.Values.Text = "浏览";
            this.btnBrowserAns.Click += new System.EventHandler(this.btnBrowserAns_Click);
            // 
            // tbAnswerFile
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.tbAnswerFile, 2);
            this.tbAnswerFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbAnswerFile.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbAnswerFile.Location = new System.Drawing.Point(113, 321);
            this.tbAnswerFile.Margin = new System.Windows.Forms.Padding(8);
            this.tbAnswerFile.Name = "tbAnswerFile";
            this.tbAnswerFile.Size = new System.Drawing.Size(516, 26);
            this.tbAnswerFile.TabIndex = 20;
            // 
            // btnBrowserSource
            // 
            this.btnBrowserSource.AutoSize = true;
            this.btnBrowserSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBrowserSource.Location = new System.Drawing.Point(640, 276);
            this.btnBrowserSource.Name = "btnBrowserSource";
            this.btnBrowserSource.Size = new System.Drawing.Size(94, 34);
            this.btnBrowserSource.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnBrowserSource.StateCommon.Border.Rounding = 16;
            this.btnBrowserSource.StateCommon.Content.Padding = new System.Windows.Forms.Padding(0);
            this.btnBrowserSource.StateCommon.Content.ShortText.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnBrowserSource.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnBrowserSource.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnBrowserSource.TabIndex = 19;
            this.btnBrowserSource.Values.Text = "浏览";
            this.btnBrowserSource.Click += new System.EventHandler(this.btnBrowserSource_Click);
            // 
            // tbProblemFile
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.tbProblemFile, 2);
            this.tbProblemFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbProblemFile.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbProblemFile.Location = new System.Drawing.Point(113, 281);
            this.tbProblemFile.Margin = new System.Windows.Forms.Padding(8);
            this.tbProblemFile.Name = "tbProblemFile";
            this.tbProblemFile.Size = new System.Drawing.Size(516, 26);
            this.tbProblemFile.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(8, 325);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 12, 0, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 17;
            this.label3.Text = "答案文件：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(8, 285);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 12, 0, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "题目文件：";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnBrowserSource, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 4, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnBrowserAns, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnSave, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.tbProblemFile, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.tbAnswerFile, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.dgvAnsList, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 4, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(742, 666);
            this.tableLayoutPanel1.TabIndex = 25;
            // 
            // groupBox1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox1, 4);
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(726, 262);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "题干";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(3, 22);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(720, 237);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // dgvAnsList
            // 
            this.dgvAnsList.AllowUserToAddRows = false;
            this.dgvAnsList.AllowUserToDeleteRows = false;
            this.tableLayoutPanel1.SetColumnSpan(this.dgvAnsList, 3);
            this.dgvAnsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAnsList.Location = new System.Drawing.Point(8, 356);
            this.dgvAnsList.Name = "dgvAnsList";
            this.dgvAnsList.ReadOnly = true;
            this.dgvAnsList.RowHeadersVisible = false;
            this.dgvAnsList.RowTemplate.Height = 23;
            this.dgvAnsList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAnsList.Size = new System.Drawing.Size(626, 262);
            this.dgvAnsList.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.dgvAnsList.StateCommon.DataCell.Content.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvAnsList.TabIndex = 24;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnAddAns);
            this.flowLayoutPanel1.Controls.Add(this.btnEdit);
            this.flowLayoutPanel1.Controls.Add(this.btnDel);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(637, 353);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(100, 268);
            this.flowLayoutPanel1.TabIndex = 25;
            // 
            // btnAddAns
            // 
            this.btnAddAns.Location = new System.Drawing.Point(3, 3);
            this.btnAddAns.Name = "btnAddAns";
            this.btnAddAns.Size = new System.Drawing.Size(94, 34);
            this.btnAddAns.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnAddAns.StateCommon.Border.Rounding = 16;
            this.btnAddAns.StateCommon.Content.Padding = new System.Windows.Forms.Padding(0);
            this.btnAddAns.StateCommon.Content.ShortText.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddAns.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnAddAns.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnAddAns.TabIndex = 31;
            this.btnAddAns.Values.Text = "添加";
            this.btnAddAns.Click += new System.EventHandler(this.btnAddAns_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(3, 43);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(94, 34);
            this.btnEdit.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnEdit.StateCommon.Border.Rounding = 16;
            this.btnEdit.StateCommon.Content.Padding = new System.Windows.Forms.Padding(0);
            this.btnEdit.StateCommon.Content.ShortText.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEdit.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnEdit.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnEdit.TabIndex = 32;
            this.btnEdit.Values.Text = "编辑";
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(3, 83);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(94, 34);
            this.btnDel.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnDel.StateCommon.Border.Rounding = 16;
            this.btnDel.StateCommon.Content.Padding = new System.Windows.Forms.Padding(0);
            this.btnDel.StateCommon.Content.ShortText.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDel.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnDel.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnDel.TabIndex = 33;
            this.btnDel.Values.Text = "删除";
            // 
            // ProFunction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ProFunction";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnsList)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSave;
        private System.Windows.Forms.OpenFileDialog ofdBrowser;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnBrowserAns;
        private System.Windows.Forms.TextBox tbAnswerFile;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnBrowserSource;
        private System.Windows.Forms.TextBox tbProblemFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvAnsList;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnEdit;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnAddAns;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnDel;

    }
}
