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
            disposeControl();
            classInfoGroup.Text = "班级信息";
        }

        private void disposeControl()                       //消除原来产生的UserControl
        {
            if (clsEdit != null) { clsEdit.Dispose(); }
            if (clsFind != null) { clsFind.Dispose(); }
            if (clsAdd != null) { clsAdd.Dispose(); }
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
            Classes currentClass = new Classes(1, "软件学院", "软件工程0805班", "1", "罗康琦");   
            changeBtnEnable(false);
            classInfoDGV.Visible = false;
            classInfoGroup.Text = "修改班级";
            clsEdit = new ClassEdit(currentClass);
            clsEdit.Disposed += new EventHandler(clsOperation_Disposed);
            classInfoGroup.Controls.Add(clsEdit);
            clsEdit.Dock = DockStyle.Fill;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认删除这些班级信息？", "班级管理", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //TODO: Delete them.
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

        private void getClassTable()
        {
            dt = new DataTable("Class");
            List<Classes> data = null;
            object[] values = new object[5];
            dt.Columns.Add("选中", typeof(bool));
            dt.Columns.Add("班级编号");
            dt.Columns.Add("学院");
            dt.Columns.Add("班级名称");
            dt.Columns.Add("老师");
            foreach (Classes cls in data)
            {
                values[0] = false;
                values[1] = cls.classID;
                values[2] = cls.dept;
                values[3] = cls.className;
                values[4] = cls.teacherName;
                dt.Rows.Add(values);
            }
            classInfoDGV.DataSource = dt;
            classInfoDGV.Columns[0].FillWeight = 5;
            classInfoDGV.Columns[1].FillWeight = 12;
            classInfoDGV.Columns[2].FillWeight = 25;
            classInfoDGV.Columns[3].FillWeight = 20;
            classInfoDGV.Columns[4].FillWeight = 18;
            classInfoDGV.Columns[5].FillWeight = 20;

            classInfoDGV.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            classInfoDGV.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            classInfoDGV.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            classInfoDGV.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            classInfoDGV.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            classInfoDGV.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
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
