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
    public partial class ClassManage : UserPanel
    {
        ClassAdd clsAdd;
        ClassEdit clsEdit;
        ClassFind clsFind;
        public static List<Classes> findData;
        public static List<Teacher> teacherList;
        public static string[] comboInfo;
        public static int findState = 0;

        private DataTable dt;

        public ClassManage()
        {
            InitializeComponent();
            clsEdit = null;
        }

        public override void ReLoad()
        {
            this.Visible = true;
            classInfoDGV.Visible = true;
            changeBtnEnable(true);
            if (disposeControl() == 0)
                getClassTable(InfoControl.OesData.FindAllClass());
            getTeacherInfo();
        }

        private void getTeacherInfo()           //获得可选的教师信息
        {
            teacherList = InfoControl.OesData.FindTeacher();
            comboInfo = new string[teacherList.Count + 1];
            for (int i = 0; i < teacherList.Count; i++)
                comboInfo[i] = (teacherList[i].TeacherName + "(" + teacherList[i].UserName + ")");
            comboInfo[teacherList.Count] = "暂无教师";
            
        }

        private int disposeControl()                       //消除原来产生的UserControl
        {
            int check = 0;
            if (clsEdit != null) { clsEdit.Dispose(); check = 1; }
            if (clsFind != null) { clsFind.Dispose(); check = 1; }
            if (clsAdd != null) { clsAdd.Dispose(); check = 1; }
            return check;
        }

        private void changeBtnEnable(bool en)               //改变下方增删改查按钮的可用性
        {
            btnAdd.Enabled = btnDelete.Enabled = btnEdit.Enabled = btnQuery.Enabled = en;
        }

        void clsOperation_Disposed(object sender, EventArgs e)
        {
            changeBtnEnable(true);
            classInfoDGV.Visible = true;
            classInfoGroup.Text = "班级信息";
            if (findState == 1)
                getClassTable(findData);
            else
                getClassTable(InfoControl.OesData.FindAllClass());
            findState = 0;
            getTeacherInfo();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            changeBtnEnable(false);
            classInfoDGV.Visible = false;
            classInfoGroup.Text = "添加班级";
            clsAdd = new ClassAdd();
            clsAdd.Disposed += new EventHandler(clsOperation_Disposed);
            classInfoGroup.Controls.Add(clsAdd);
            clsAdd.Dock = DockStyle.Fill;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int cr = classInfoDGV.CurrentRow.Index;
            if (cr <= -1) { return; }
            changeBtnEnable(false);
            classInfoDGV.Visible = false;
            classInfoGroup.Text = "修改班级";
            Classes currentClass = new Classes(dt.Rows[cr][1].ToString(), dt.Rows[cr][2].ToString(),
                dt.Rows[cr][3].ToString(), dt.Rows[cr][4].ToString(), dt.Rows[cr][5].ToString());
            clsEdit = new ClassEdit(currentClass);
            clsEdit.Disposed += new EventHandler(clsOperation_Disposed);
            classInfoGroup.Controls.Add(clsEdit);
            clsEdit.Dock = DockStyle.Fill;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int state = 0;
            List<string> del = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dt.Rows[i][0]) == true)
                    del.Add(dt.Rows[i][1].ToString());
            }
            if (del.Count == 0)
            {
                MessageBox.Show("请先选中要删除的班级！", "班级管理", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("确认删除这些班级信息？", "班级管理", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                for (int i = 0; i < del.Count; i++)
                {
                    try { InfoControl.OesData.DeleteClass(del[i]); }
                    catch { state = 1; }
                }
                string info = state == 0 ? "删除完成！" :
                    "部分班级未能删除，请将这些班内的学生加入别的班级后再试！";
                MessageBox.Show(info, "班级管理", MessageBoxButtons.OK, state == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                getClassTable(InfoControl.OesData.FindAllClass());
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            changeBtnEnable(false);
            classInfoDGV.Visible = false;
            classInfoGroup.Text = "查找班级";
            clsFind = new ClassFind();
            clsFind.Disposed += new EventHandler(clsOperation_Disposed);
            classInfoGroup.Controls.Add(clsFind);
            clsFind.Dock = DockStyle.Fill;
        }

        private void getClassTable(List<Classes> data)
        {
            dt = new DataTable("Class");
            object[] values = new object[6];
            dt.Columns.Add("选中", typeof(bool));
            dt.Columns.Add("班级编号");
            dt.Columns.Add("学院");
            dt.Columns.Add("班级名称");
            dt.Columns.Add("教师姓名");
            dt.Columns.Add("教工号");
            foreach (Classes cls in data)
            {
                values[0] = false;
                values[1] = cls.classID;
                values[2] = cls.dept;
                values[3] = cls.className;
                values[4] = cls.teacherName;
                values[5] = cls.teacherUserName;
                dt.Rows.Add(values);
            }
            classInfoDGV.DataSource = dt;
            classInfoDGV.Columns[0].FillWeight = 5;
            classInfoDGV.Columns[1].FillWeight = 12;
            classInfoDGV.Columns[2].FillWeight = 20;
            classInfoDGV.Columns[3].FillWeight = 25;
            classInfoDGV.Columns[4].FillWeight = 20;
            classInfoDGV.Columns[5].FillWeight = 20;

            classInfoDGV.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            classInfoDGV.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            classInfoDGV.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            classInfoDGV.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            classInfoDGV.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            classInfoDGV.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;

            classInfoDGV.Columns[1].Visible = false;
        }

        private void classInfoDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int RIndex = e.RowIndex;
            if (RIndex > -1)
            {
                dt.Rows[RIndex][0] = !Convert.ToBoolean(dt.Rows[RIndex][0]);
            }
        }

    }
}
