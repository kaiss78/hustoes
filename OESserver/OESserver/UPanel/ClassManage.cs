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

        ClassEdit clsAdd;

        public ClassManage()
        {
            InitializeComponent();
            clsAdd = null;
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
            //changeBtnEnable(false);
            //classInfoDGV.Visible = false;
            //classInfoGroup.Text = "添加班级";
            //clsAdd = new ClassEdit(0, null);
            //clsAdd.Disposed += new EventHandler(clsOperation_Disposed);
            //classInfoGroup.Controls.Add(clsAdd);
            //clsAdd.Dock = DockStyle.Fill;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Classes currentClass = new Classes(1, "软件学院", "软件工程0805班", "罗康琦");   
            changeBtnEnable(false);
            classInfoDGV.Visible = false;
            classInfoGroup.Text = "修改班级";
            clsAdd = new ClassEdit(currentClass);
            clsAdd.Disposed += new EventHandler(clsOperation_Disposed);
            classInfoGroup.Controls.Add(clsAdd);
            clsAdd.Dock = DockStyle.Fill;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认删除这些班级信息？", "班级管理", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //TODO: Delete them.
            }
        }

    }
}
