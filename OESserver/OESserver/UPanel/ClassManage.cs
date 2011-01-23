using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OES.UControl;

namespace OES.UPanel
{
    public partial class ClassManage : UserPanel
    {

        ClassAdd clsAdd;

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

        void clsOperation_Disposed(object sender, EventArgs e)
        {
            changeBtnEnable(true);
            classInfoDGV.Visible = true;
            classInfoGroup.Text = "班级信息";
        }

    }
}
