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
            this.buttonQuery = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.studentInfoGruop = new System.Windows.Forms.GroupBox();
            this.studentInfoDGV = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.studentManageLayout = new System.Windows.Forms.TableLayoutPanel();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.studentAdd = new OES.UControl.StudentAdd();
            this.studentInfoGruop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.studentInfoDGV)).BeginInit();
            this.studentManageLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonQuery
            // 
            this.buttonQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonQuery.Location = new System.Drawing.Point(436, 548);
            this.buttonQuery.Name = "buttonQuery";
            this.buttonQuery.Size = new System.Drawing.Size(117, 39);
            this.buttonQuery.TabIndex = 3;
            this.buttonQuery.Text = "查找学生";
            this.buttonQuery.UseVisualStyleBackColor = true;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDelete.Location = new System.Drawing.Point(147, 605);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(118, 37);
            this.buttonDelete.TabIndex = 2;
            this.buttonDelete.Text = "删除学生";
            this.buttonDelete.UseVisualStyleBackColor = true;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAdd.Location = new System.Drawing.Point(147, 548);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(118, 39);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "添加学生";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // studentInfoGruop
            // 
            this.studentManageLayout.SetColumnSpan(this.studentInfoGruop, 6);
            this.studentInfoGruop.Controls.Add(this.studentAdd);
            this.studentInfoGruop.Controls.Add(this.studentInfoDGV);
            this.studentInfoGruop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.studentInfoGruop.Font = new System.Drawing.Font("宋体", 12F);
            this.studentInfoGruop.Location = new System.Drawing.Point(12, 4);
            this.studentInfoGruop.Name = "studentInfoGruop";
            this.studentManageLayout.SetRowSpan(this.studentInfoGruop, 2);
            this.studentInfoGruop.Size = new System.Drawing.Size(718, 516);
            this.studentInfoGruop.TabIndex = 0;
            this.studentInfoGruop.TabStop = false;
            this.studentInfoGruop.Text = "学生信息";
            this.studentInfoGruop.Enter += new System.EventHandler(this.groupBox1_Enter);
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
            this.studentInfoDGV.Size = new System.Drawing.Size(712, 491);
            this.studentInfoDGV.TabIndex = 0;
            // 
            // studentManageLayout
            // 
            this.studentManageLayout.ColumnCount = 8;
            this.studentManageLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.34483F));
            this.studentManageLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 89.65517F));
            this.studentManageLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.studentManageLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 124F));
            this.studentManageLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 165F));
            this.studentManageLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 123F));
            this.studentManageLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 177F));
            this.studentManageLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.studentManageLayout.Controls.Add(this.studentInfoGruop, 1, 1);
            this.studentManageLayout.Controls.Add(this.buttonEdit, 5, 6);
            this.studentManageLayout.Controls.Add(this.buttonQuery, 5, 4);
            this.studentManageLayout.Controls.Add(this.buttonAdd, 3, 4);
            this.studentManageLayout.Controls.Add(this.buttonDelete, 3, 6);
            this.studentManageLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.studentManageLayout.Location = new System.Drawing.Point(0, 0);
            this.studentManageLayout.Name = "studentManageLayout";
            this.studentManageLayout.RowCount = 8;
            this.studentManageLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.577909F));
            this.studentManageLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 98.42209F));
            this.studentManageLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 404F));
            this.studentManageLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.studentManageLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.studentManageLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.studentManageLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.studentManageLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.studentManageLayout.Size = new System.Drawing.Size(742, 666);
            this.studentManageLayout.TabIndex = 0;
            // 
            // buttonEdit
            // 
            this.buttonEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonEdit.Location = new System.Drawing.Point(436, 605);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(117, 37);
            this.buttonEdit.TabIndex = 4;
            this.buttonEdit.Text = "修改学生";
            this.buttonEdit.UseVisualStyleBackColor = true;
            // 
            // studentAdd
            // 
            this.studentAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.studentAdd.Location = new System.Drawing.Point(3, 22);
            this.studentAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.studentAdd.Name = "studentAdd";
            this.studentAdd.Size = new System.Drawing.Size(712, 491);
            this.studentAdd.TabIndex = 1;
            // 
            // StudentManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.studentManageLayout);
            this.Name = "StudentManage";
            this.Size = new System.Drawing.Size(742, 666);
            this.studentInfoGruop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.studentInfoDGV)).EndInit();
            this.studentManageLayout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonQuery;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.GroupBox studentInfoGruop;
        private System.Windows.Forms.TableLayoutPanel studentManageLayout;
        private System.Windows.Forms.Button buttonEdit;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView studentInfoDGV;
        private OES.UControl.StudentAdd studentAdd;


    }
}
