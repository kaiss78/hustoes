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
            this.btnQuery = new System.Windows.Forms.Button();
            this.studentManageLayout = new System.Windows.Forms.TableLayoutPanel();
            this.studentInfoGroup = new System.Windows.Forms.GroupBox();
            this.studentInfoDGV = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.studentManageLayout.SuspendLayout();
            this.studentInfoGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.studentInfoDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // btnQuery
            // 
            this.btnQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnQuery.Font = new System.Drawing.Font("宋体", 12F);
            this.btnQuery.Location = new System.Drawing.Point(161, 608);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(117, 37);
            this.btnQuery.TabIndex = 3;
            this.btnQuery.Text = "查找学生";
            this.btnQuery.UseVisualStyleBackColor = true;
            // 
            // studentManageLayout
            // 
            this.studentManageLayout.ColumnCount = 7;
            this.studentManageLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.studentManageLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.studentManageLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 123F));
            this.studentManageLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.studentManageLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 123F));
            this.studentManageLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.studentManageLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.studentManageLayout.Controls.Add(this.studentInfoGroup, 1, 1);
            this.studentManageLayout.Controls.Add(this.btnEdit, 4, 5);
            this.studentManageLayout.Controls.Add(this.btnQuery, 2, 5);
            this.studentManageLayout.Controls.Add(this.btnAdd, 2, 3);
            this.studentManageLayout.Controls.Add(this.btnDelete, 4, 3);
            this.studentManageLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.studentManageLayout.Location = new System.Drawing.Point(0, 0);
            this.studentManageLayout.Name = "studentManageLayout";
            this.studentManageLayout.RowCount = 7;
            this.studentManageLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.studentManageLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.studentManageLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.studentManageLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.studentManageLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.studentManageLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.studentManageLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.studentManageLayout.Size = new System.Drawing.Size(742, 666);
            this.studentManageLayout.TabIndex = 0;
            // 
            // studentInfoGroup
            // 
            this.studentManageLayout.SetColumnSpan(this.studentInfoGroup, 5);
            this.studentInfoGroup.Controls.Add(this.studentInfoDGV);
            this.studentInfoGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.studentInfoGroup.Font = new System.Drawing.Font("宋体", 12F);
            this.studentInfoGroup.Location = new System.Drawing.Point(11, 11);
            this.studentInfoGroup.Name = "studentInfoGroup";
            this.studentInfoGroup.Size = new System.Drawing.Size(720, 512);
            this.studentInfoGroup.TabIndex = 0;
            this.studentInfoGroup.TabStop = false;
            this.studentInfoGroup.Text = "学生信息";
            // 
            // studentInfoDGV
            // 
            this.studentInfoDGV.AllowUserToAddRows = false;
            this.studentInfoDGV.AllowUserToDeleteRows = false;
            this.studentInfoDGV.AllowUserToResizeRows = false;
            this.studentInfoDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.studentInfoDGV.Location = new System.Drawing.Point(3, 22);
            this.studentInfoDGV.Name = "studentInfoDGV";
            this.studentInfoDGV.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver;
            this.studentInfoDGV.ReadOnly = true;
            this.studentInfoDGV.RowTemplate.Height = 23;
            this.studentInfoDGV.Size = new System.Drawing.Size(714, 487);
            this.studentInfoDGV.TabIndex = 0;
            // 
            // btnEdit
            // 
            this.btnEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEdit.Font = new System.Drawing.Font("宋体", 12F);
            this.btnEdit.Location = new System.Drawing.Point(464, 608);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(117, 37);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "修改学生";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAdd.Font = new System.Drawing.Font("宋体", 12F);
            this.btnAdd.Location = new System.Drawing.Point(161, 547);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(117, 37);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "添加学生";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDelete.Font = new System.Drawing.Font("宋体", 12F);
            this.btnDelete.Location = new System.Drawing.Point(464, 547);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(117, 37);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "删除学生";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // StudentManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.studentManageLayout);
            this.Name = "StudentManage";
            this.Size = new System.Drawing.Size(742, 666);
            this.studentManageLayout.ResumeLayout(false);
            this.studentInfoGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.studentInfoDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.TableLayoutPanel studentManageLayout;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox studentInfoGroup;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView studentInfoDGV;


    }
}
