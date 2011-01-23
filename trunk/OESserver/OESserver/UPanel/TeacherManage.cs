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
        }

        private void disposeControl()               //消除原来产生的UserControl
        {
            if (teaAdd != null) { teaAdd.Dispose(); }
        }

        private void changeBtnEnable(bool en)               //改变下方增删改查按钮的可用性
        {
            btnAdd.Enabled = btnDelete.Enabled = btnEdit.Enabled = btnQuery.Enabled = en;
        }

        void teacherOperation_Disposed(object sender, EventArgs e)
        {
            changeBtnEnable(true);
            teacherInfoDGV.Visible = true;
            teacherInfoGroup.Text = "教师信息";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认删除这些教师信息？", "教师管理", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //TODO: Delete them.
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
            changeBtnEnable(false);
            teacherInfoDGV.Visible = false;
            teacherInfoGroup.Text = "修改教师";
            teaAdd = new TeacherAdd(new Teacher("0001", "罗康琦", "hust.elt", "wqeqweq", 1));
            teaAdd.Disposed += new EventHandler(teacherOperation_Disposed);
            teacherInfoGroup.Controls.Add(teaAdd);
            teaAdd.Dock = DockStyle.Fill;
        }
    }
}
