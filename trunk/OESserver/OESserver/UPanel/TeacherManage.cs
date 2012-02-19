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
    public partial class TeacherManage : UserPanel
    {
        private TeacherAdd teaAdd;
        private DataTable dt;

        public TeacherManage()
        {
            InitializeComponent();
            teaAdd = null;
        }

        public override void ReLoad()
        {
            this.Visible = true;
            teacherInfoDGV.Visible = true;
            changeBtnEnable(true);
            disposeControl();
            teacherInfoGroup.Text = "教师信息";
            getTeacherTable();
        }

        private void disposeControl()                       //消除原来产生的UserControl
        {
            if (teaAdd != null) { teaAdd.Dispose(); }
        }

        private void changeBtnEnable(bool en)               //改变下方增删改查按钮的可用性
        {
            btnAdd.Enabled = btnDelete.Enabled = btnEdit.Enabled = en;
        }

        void teacherOperation_Disposed(object sender, EventArgs e)
        {
            changeBtnEnable(true);
            teacherInfoDGV.Visible = true;
            teacherInfoGroup.Text = "教师信息";
            getTeacherTable();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            List<int> del = new List<int>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dt.Rows[i][0]) == true)
                    del.Add(Convert.ToInt32(dt.Rows[i][1]));
            }
            if (del.Count == 0)
            {
                MessageBox.Show("请先选中要删除的教师！", "教师管理", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("确认删除这些教师信息？", "教师管理", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                for (int i = 0; i < del.Count; i++)
                    InfoControl.OesData.DeleteTeacherById(del[i]);
                MessageBox.Show("删除完成！", "教师管理", MessageBoxButtons.OK, MessageBoxIcon.Information);
                getTeacherTable();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            changeBtnEnable(false);
            teacherInfoDGV.Visible = false;
            teacherInfoGroup.Text = "添加教师";
            teaAdd = new TeacherAdd(null);
            teaAdd.Disposed += new EventHandler(teacherOperation_Disposed);
            teacherInfoGroup.Controls.Add(teaAdd);
            teaAdd.Dock = DockStyle.Fill;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int cr = teacherInfoDGV.CurrentRow.Index;
            if (cr <= -1)  { return; }
            changeBtnEnable(false);
            teacherInfoDGV.Visible = false;
            teacherInfoGroup.Text = "修改教师";
            int permission = dt.Rows[cr][5].ToString().Equals("超级管理员") ? 1 : 0;
            Teacher th = new Teacher(Convert.ToInt32(dt.Rows[cr][1]), dt.Rows[cr][2].ToString(),
                dt.Rows[cr][3].ToString(), dt.Rows[cr][4].ToString(), permission);
            teaAdd = new TeacherAdd(th);
            teaAdd.Disposed += new EventHandler(teacherOperation_Disposed);
            teacherInfoGroup.Controls.Add(teaAdd);
            teaAdd.Dock = DockStyle.Fill;
        }

        private void getTeacherTable()
        {
            dt = new DataTable("Teacher");
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
            teacherInfoDGV.DataSource = dt;
            teacherInfoDGV.Columns[0].FillWeight = 5;
            teacherInfoDGV.Columns[1].FillWeight = 12;
            teacherInfoDGV.Columns[2].FillWeight = 25;
            teacherInfoDGV.Columns[3].FillWeight = 20;
            teacherInfoDGV.Columns[4].FillWeight = 18;
            teacherInfoDGV.Columns[5].FillWeight = 20;

            teacherInfoDGV.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            teacherInfoDGV.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            teacherInfoDGV.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            teacherInfoDGV.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            teacherInfoDGV.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            teacherInfoDGV.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
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
