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
        StudentFind stuFind;
        public static List<Student> findData;
        public static List<Teacher> teacherList;
        public static string[] comboInfo;
        public static int findState = 0;

        private DataTable dt;

        public StudentManage()
        {
            InitializeComponent();
            stuAdd = null;
            stuEdit = null;
            stuFind = null;
        }

        public override void ReLoad()
        {
            this.Visible = true;
            studentInfoDGV.Visible = true;
            changeBtnEnable(true);
            if (disposeControl() == 0)
                showStudents();
            studentInfoGroup.Text = "学生信息";
            getTeacherInfo();
        }

        private void showStudents()         //点击学生管理时显示的学生信息
        {
            List<Student> lst = new List<Student>();
            if (InfoControl.User.permission == 0)
                lst = InfoControl.OesData.FindStudentByUserName(InfoControl.User.UserName);
            getStudentTable(lst);
        }

        private void getTeacherInfo()           //获得可选的教师信息
        {
            teacherList = InfoControl.OesData.FindTeacher();
            comboInfo = new string[teacherList.Count + 1];
            for (int i = 0; i < teacherList.Count; i++)
                comboInfo[i] = (teacherList[i].TeacherName + "(" + teacherList[i].UserName + ")");
            comboInfo[teacherList.Count] = "暂无教师";

        }

        private int disposeControl()               //消除原来产生的UserControl
        {
            int check = 0;
            if (stuEdit != null) { stuEdit.Dispose(); check = 1; }
            if (stuAdd != null) { stuAdd.Dispose(); check = 1; }
            if (stuFind != null) { stuFind.Dispose(); check = 1; }
            return check;
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

        private void btnQuery_Click(object sender, EventArgs e)
        {
            changeBtnEnable(false);
            studentInfoDGV.Visible = false;
            studentInfoGroup.Text = "查找学生";
            stuFind = new StudentFind();
            stuFind.Disposed += new EventHandler(stuOperation_Disposed);
            studentInfoGroup.Controls.Add(stuFind);
            stuFind.Dock = DockStyle.Fill;
        }
        
        private void btnEdit_Click(object sender, EventArgs e)
        {
            int cr = studentInfoDGV.CurrentRow.Index;
            if (cr <= -1) { return; }
            changeBtnEnable(false);
            studentInfoDGV.Visible = false;
            studentInfoGroup.Text = "修改学生";
            Student st = new Student(dt.Rows[cr][1].ToString(), dt.Rows[cr][2].ToString(), dt.Rows[cr][3].ToString(),
                dt.Rows[cr][4].ToString(), dt.Rows[cr][5].ToString(), dt.Rows[cr][6].ToString());
            stuEdit = new StudentEdit(st);
            stuEdit.Disposed += new EventHandler(stuOperation_Disposed);
            studentInfoGroup.Controls.Add(stuEdit);
            stuEdit.Dock = DockStyle.Fill;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            List<string> del = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dt.Rows[i][0]) == true)
                    del.Add(dt.Rows[i][1].ToString());
            }
            if (del.Count == 0)
            {
                MessageBox.Show("请先选中要删除的学生！", "学生管理", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("确认删除这些学生信息？", "学生管理", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    InfoControl.OesData.DeleteManyStudent(del);
                    MessageBox.Show("删除完成！", "学生管理", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    getStudentTable(InfoControl.OesData.FindAllStudent());
                }
                catch
                {
                    MessageBox.Show("删除失败，请重试！", "学生管理", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        void stuOperation_Disposed(object sender, EventArgs e)
        {
            changeBtnEnable(true);
            studentInfoDGV.Visible = true;
            studentInfoGroup.Text = "学生信息";
            if (findState == 1)
                getStudentTable(findData);
            else
                showStudents();
            findState = 0;
            getTeacherInfo();
        }

        private void getStudentTable(List<Student> data)
        {
            dt = new DataTable("Student");
            object[] values = new object[7];
            dt.Columns.Add("选中", typeof(bool));
            dt.Columns.Add("学号");
            dt.Columns.Add("姓名");
            dt.Columns.Add("班级编号");
            dt.Columns.Add("学院");
            dt.Columns.Add("班级");
            dt.Columns.Add("密码");
            foreach (Student st in data)
            {
                values[0] = false;
                values[1] = st.ID;
                values[2] = st.sName;
                values[3] = st.classId;
                values[4] = st.dept;
                values[5] = st.className;
                values[6] = st.password;
                dt.Rows.Add(values);
            }
            studentInfoDGV.DataSource = dt;
            studentInfoDGV.Columns[0].FillWeight = 5;
            studentInfoDGV.Columns[1].FillWeight = 16;
            studentInfoDGV.Columns[2].FillWeight = 16;
            studentInfoDGV.Columns[3].FillWeight = 10;
            studentInfoDGV.Columns[4].FillWeight = 24;
            studentInfoDGV.Columns[5].FillWeight = 24;
            studentInfoDGV.Columns[6].FillWeight = 16;

            studentInfoDGV.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            studentInfoDGV.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            studentInfoDGV.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            studentInfoDGV.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            studentInfoDGV.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            studentInfoDGV.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
            studentInfoDGV.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;

            studentInfoDGV.Columns[3].Visible = false;
        }

        
        private void studentInfoDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int RIndex = e.RowIndex;
            if (RIndex > -1)
            {
                dt.Rows[RIndex][0] = !Convert.ToBoolean(dt.Rows[RIndex][0]);
            }
        }

    }
}
