using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OES.UPanel
{
    public partial class TeacherManage : UserPanel
    {
        public TeacherManage()
        {
            InitializeComponent();
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
            
        }

        private void changeBtnEnable(bool en)               //改变下方增删改查按钮的可用性
        {
            btnAdd.Enabled = btnDelete.Enabled = btnEdit.Enabled = btnQuery.Enabled = en;
        }
    }
}
