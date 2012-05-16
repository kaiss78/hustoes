namespace OES.UPanel
{
    partial class PaperListPanel
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.year = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.paperName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.startTime = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.endTime = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.btnFind = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PaperListDGV = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.cbtnFindByYear = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.cbtnFindByTime = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.cbtnFindByName = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.csFind = new ComponentFactory.Krypton.Toolkit.KryptonCheckSet(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PaperListDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.csFind)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnEdit, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnDel, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbtnFindByYear, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbtnFindByTime, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbtnFindByName, 3, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(742, 666);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanel1, 6);
            this.flowLayoutPanel1.Controls.Add(this.year);
            this.flowLayoutPanel1.Controls.Add(this.paperName);
            this.flowLayoutPanel1.Controls.Add(this.startTime);
            this.flowLayoutPanel1.Controls.Add(this.endTime);
            this.flowLayoutPanel1.Controls.Add(this.btnFind);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(10, 45);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(722, 35);
            this.flowLayoutPanel1.TabIndex = 9;
            // 
            // year
            // 
            this.year.Dock = System.Windows.Forms.DockStyle.Left;
            this.year.Location = new System.Drawing.Point(3, 3);
            this.year.Maximum = new decimal(new int[] {
            6000,
            0,
            0,
            0});
            this.year.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.year.Name = "year";
            this.year.Size = new System.Drawing.Size(80, 29);
            this.year.StateCommon.Content.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.year.TabIndex = 4;
            this.year.Value = new decimal(new int[] {
            2011,
            0,
            0,
            0});
            // 
            // paperName
            // 
            this.paperName.Dock = System.Windows.Forms.DockStyle.Left;
            this.paperName.Location = new System.Drawing.Point(86, 5);
            this.paperName.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.paperName.Name = "paperName";
            this.paperName.Size = new System.Drawing.Size(250, 26);
            this.paperName.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.paperName.StateCommon.Border.Rounding = 12;
            this.paperName.StateCommon.Content.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.paperName.TabIndex = 5;
            // 
            // startTime
            // 
            this.startTime.CalendarTodayDate = new System.DateTime(2011, 3, 19, 0, 0, 0, 0);
            this.startTime.Cursor = System.Windows.Forms.Cursors.Default;
            this.startTime.CustomFormat = "yyyy/MM/dd";
            this.startTime.Dock = System.Windows.Forms.DockStyle.Left;
            this.startTime.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.startTime.Location = new System.Drawing.Point(339, 3);
            this.startTime.Name = "startTime";
            this.startTime.ShowUpDown = true;
            this.startTime.Size = new System.Drawing.Size(134, 29);
            this.startTime.StateCommon.Content.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.startTime.TabIndex = 6;
            this.startTime.ValueNullable = new System.DateTime(2011, 3, 27, 0, 0, 0, 0);
            // 
            // endTime
            // 
            this.endTime.CalendarTodayDate = new System.DateTime(2011, 3, 19, 0, 0, 0, 0);
            this.endTime.CustomFormat = "yyyy/MM/dd";
            this.endTime.Dock = System.Windows.Forms.DockStyle.Left;
            this.endTime.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.endTime.Location = new System.Drawing.Point(479, 3);
            this.endTime.Name = "endTime";
            this.endTime.ShowUpDown = true;
            this.endTime.Size = new System.Drawing.Size(134, 29);
            this.endTime.StateCommon.Content.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.endTime.TabIndex = 7;
            this.endTime.ValueNullable = new System.DateTime(2011, 3, 27, 0, 0, 0, 0);
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(618, 1);
            this.btnFind.Margin = new System.Windows.Forms.Padding(2, 1, 2, 2);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(80, 32);
            this.btnFind.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnFind.StateCommon.Border.Rounding = 15;
            this.btnFind.StateCommon.Border.Width = 1;
            this.btnFind.TabIndex = 8;
            this.btnFind.Values.Text = "查询";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // groupBox1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox1, 6);
            this.groupBox1.Controls.Add(this.PaperListDGV);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(13, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(716, 570);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "试卷列表";
            // 
            // PaperListDGV
            // 
            this.PaperListDGV.AllowUserToAddRows = false;
            this.PaperListDGV.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(236)))), ((int)(((byte)(242)))));
            this.PaperListDGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.PaperListDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PaperListDGV.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Mixed;
            this.PaperListDGV.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ButtonNavigatorMini;
            this.PaperListDGV.GridStyles.StyleColumn = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.PaperListDGV.GridStyles.StyleRow = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.PaperListDGV.Location = new System.Drawing.Point(3, 22);
            this.PaperListDGV.Name = "PaperListDGV";
            this.PaperListDGV.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver;
            this.PaperListDGV.ReadOnly = true;
            this.PaperListDGV.RowHeadersVisible = false;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.PaperListDGV.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.PaperListDGV.RowTemplate.Height = 23;
            this.PaperListDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.PaperListDGV.Size = new System.Drawing.Size(710, 545);
            this.PaperListDGV.TabIndex = 0;
            this.PaperListDGV.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PaperListDGV_CellDoubleClick);
            this.PaperListDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PaperListDGV_CellClick);
            // 
            // btnEdit
            // 
            this.btnEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEdit.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEdit.Location = new System.Drawing.Point(534, 12);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(96, 31);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "编辑试卷";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDel
            // 
            this.btnDel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDel.Location = new System.Drawing.Point(634, 12);
            this.btnDel.Margin = new System.Windows.Forms.Padding(2);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(96, 31);
            this.btnDel.TabIndex = 5;
            this.btnDel.Text = "删除试卷";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // cbtnFindByYear
            // 
            this.cbtnFindByYear.Checked = true;
            this.cbtnFindByYear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbtnFindByYear.Location = new System.Drawing.Point(13, 13);
            this.cbtnFindByYear.Name = "cbtnFindByYear";
            this.cbtnFindByYear.Size = new System.Drawing.Size(69, 29);
            this.cbtnFindByYear.TabIndex = 6;
            this.cbtnFindByYear.Values.Text = "按年";
            this.cbtnFindByYear.Click += new System.EventHandler(this.cbtnFindByYear_Click);
            // 
            // cbtnFindByTime
            // 
            this.cbtnFindByTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbtnFindByTime.Location = new System.Drawing.Point(88, 13);
            this.cbtnFindByTime.Name = "cbtnFindByTime";
            this.cbtnFindByTime.Size = new System.Drawing.Size(69, 29);
            this.cbtnFindByTime.TabIndex = 7;
            this.cbtnFindByTime.Values.Text = "按时间段";
            this.cbtnFindByTime.Click += new System.EventHandler(this.cbtnFindByTime_Click);
            // 
            // cbtnFindByName
            // 
            this.cbtnFindByName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbtnFindByName.Location = new System.Drawing.Point(163, 13);
            this.cbtnFindByName.Name = "cbtnFindByName";
            this.cbtnFindByName.Size = new System.Drawing.Size(69, 29);
            this.cbtnFindByName.TabIndex = 8;
            this.cbtnFindByName.Values.Text = "按试卷名";
            this.cbtnFindByName.Click += new System.EventHandler(this.cbtnFindByName_Click);
            // 
            // csFind
            // 
            this.csFind.CheckButtons.Add(this.cbtnFindByTime);
            this.csFind.CheckButtons.Add(this.cbtnFindByName);
            this.csFind.CheckButtons.Add(this.cbtnFindByYear);
            this.csFind.CheckedButton = this.cbtnFindByYear;
            // 
            // PaperListPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "PaperListPanel";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PaperListDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.csFind)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDel;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckSet csFind;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton cbtnFindByTime;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton cbtnFindByName;
        private System.Windows.Forms.GroupBox groupBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView PaperListDGV;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton cbtnFindByYear;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown year;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox paperName;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker startTime;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker endTime;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnFind;
    }
}
