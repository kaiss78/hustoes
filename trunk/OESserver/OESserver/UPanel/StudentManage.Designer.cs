namespace OES.UPanel
{
    partial class StudentManage
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
            this.StudentInfoGruop = new System.Windows.Forms.GroupBox();
            this.StudentInfoDGV = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonQuery = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.StudentInfoGruop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StudentInfoDGV)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // StudentInfoGruop
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.StudentInfoGruop, 6);
            this.StudentInfoGruop.Controls.Add(this.StudentInfoDGV);
            this.StudentInfoGruop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StudentInfoGruop.Font = new System.Drawing.Font("宋体", 12F);
            this.StudentInfoGruop.Location = new System.Drawing.Point(58, 40);
            this.StudentInfoGruop.Name = "StudentInfoGruop";
            this.StudentInfoGruop.Size = new System.Drawing.Size(613, 464);
            this.StudentInfoGruop.TabIndex = 0;
            this.StudentInfoGruop.TabStop = false;
            this.StudentInfoGruop.Text = "学生列表";
            this.StudentInfoGruop.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // StudentInfoDGV
            // 
            this.StudentInfoDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StudentInfoDGV.Location = new System.Drawing.Point(3, 22);
            this.StudentInfoDGV.Name = "StudentInfoDGV";
            this.StudentInfoDGV.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver;
            this.StudentInfoDGV.RowTemplate.Height = 23;
            this.StudentInfoDGV.Size = new System.Drawing.Size(607, 439);
            this.StudentInfoDGV.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 124F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 165F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 123F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 117F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tableLayoutPanel1.Controls.Add(this.StudentInfoGruop, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonAdd, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonDelete, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.buttonQuery, 5, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonEdit, 5, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.459677F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.54032F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 14F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(742, 666);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAdd.Location = new System.Drawing.Point(148, 537);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(118, 41);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "添加学生";
            this.buttonAdd.UseVisualStyleBackColor = true;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDelete.Location = new System.Drawing.Point(148, 598);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(118, 41);
            this.buttonDelete.TabIndex = 2;
            this.buttonDelete.Text = "删除学生";
            this.buttonDelete.UseVisualStyleBackColor = true;
            // 
            // buttonQuery
            // 
            this.buttonQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonQuery.Location = new System.Drawing.Point(437, 537);
            this.buttonQuery.Name = "buttonQuery";
            this.buttonQuery.Size = new System.Drawing.Size(117, 41);
            this.buttonQuery.TabIndex = 3;
            this.buttonQuery.Text = "查找学生";
            this.buttonQuery.UseVisualStyleBackColor = true;
            // 
            // buttonEdit
            // 
            this.buttonEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonEdit.Location = new System.Drawing.Point(437, 598);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(117, 41);
            this.buttonEdit.TabIndex = 4;
            this.buttonEdit.Text = "修改学生";
            this.buttonEdit.UseVisualStyleBackColor = true;
            // 
            // StudentManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "StudentManage";
            this.Size = new System.Drawing.Size(742, 666);
            this.StudentInfoGruop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.StudentInfoDGV)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox StudentInfoGruop;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonQuery;
        private System.Windows.Forms.Button buttonEdit;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView StudentInfoDGV;

    }
}
