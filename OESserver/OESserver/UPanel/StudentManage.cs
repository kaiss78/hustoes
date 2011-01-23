using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OES.UControl;
using OES.Model;

namespace OES.UPanel
{
    public partial class StudentManage : UserPanel
    {
        StudentAdd stuAdd;
        StudentEdit stuEdit;

        private DataTable dt;

        public StudentManage()
        {
            InitializeComponent();
            stuAdd = null;
            stuEdit = null;
        }

        public override void ReLoad()
        {
            this.Visible = true;
            studentInfoDGV.Visible = true;
            changeBtnEnable(true);
            disposeControl();
            studentInfoGroup.Text = "学生信息";
        }

        private void disposeControl()               //消除原来产生的UserControl
        {
            if (stuEdit != null) { stuEdit.Dispose(); }
            if (stuAdd != null) { stuAdd.Dispose(); }
        }

        private void changeBtnEnable(bool en)               //改变下方增删改查按钮的可用性
        {
            btnAdd.Enabled = btnDelete.Enabled = btnEdit.Enabled = btnQuery.Enabled = en;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            changeBtnEnable(false);
            studentInfoDGV.Visible = false;
            studentInfoGroup.Text = "添加学生";
            stuAdd = new StudentAdd();
            stuAdd.Disposed += new EventHandler(stuOperation_Disposed);
            studentInfoGroup.Controls.Add(stuAdd);
            stuAdd.Dock = DockStyle.Fill;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            changeBtnEnable(false);
            studentInfoDGV.Visible = false;
            studentInfoGroup.Text = "修改学生";
            stuEdit = new StudentEdit();
            stuEdit.Disposed += new EventHandler(stuOperation_Disposed);
            studentInfoGroup.Controls.Add(stuEdit);
            stuEdit.Dock = DockStyle.Fill;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认删除这些学生信息？", "学生管理", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            { 
                //TODO: Delete them.
            }
        }

        void stuOperation_Disposed(object sender, EventArgs e)
        {
            changeBtnEnable(true);
            studentInfoDGV.Visible = true;
            studentInfoGroup.Text = "学生信息";
        }

        private void getStudentTable()
        {
            dt = new DataTable("Student");
            List<Teacher> data = InfoControl.OesData.FindTeacher();
            object[] values = new object[6];
            dt.Columns.Add("选中", typeof(bool));
            dt.Columns.Add("教师编号");
            dt.Columns.Add("教师姓名");
            dt.Columns.Add("教工号");
            dt.Columns.Add("密码");
            dt.Columns.Add("权限");
            foreach (Teacher th in data)
            {
                values[0] = false;
                values[1] = th.Id;
                values[2] = th.TeacherName;
                values[3] = th.UserName;
                values[4] = th.password;
                values[5] = th.permission == 1 ? "超级管理员" : "普通用户";
                dt.Rows.Add(values);
            }
            studentInfoDGV.DataSource = dt;
            studentInfoDGV.Columns[0].FillWeight = 5;
            studentInfoDGV.Columns[1].FillWeight = 12;
            studentInfoDGV.Columns[2].FillWeight = 25;
            studentInfoDGV.Columns[3].FillWeight = 20;
            studentInfoDGV.Columns[4].FillWeight = 18;
            studentInfoDGV.Columns[5].FillWeight = 20;

            studentInfoDGV.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            studentInfoDGV.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            studentInfoDGV.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            studentInfoDGV.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            studentInfoDGV.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            studentInfoDGV.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void teacherInfoDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int RIndex = e.RowIndex;
            if (RIndex > -1)
            {
                dt.Rows[RIndex][0] = !Convert.ToBoolean(dt.Rows[RIndex][0]);
            }
        }
        
    }
}
