using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OES.Model;

namespace OES.UControl
{
    public partial class TeacherAdd : UserControl
    {
        private Teacher currentTeacher;

        public TeacherAdd(Teacher th)
        {
            InitializeComponent();
            currentTeacher = th;
            radioUser.Checked = true;
            if (currentTeacher != null)
            {
                textUserName.Text = currentTeacher.UserName;
                textName.Text = currentTeacher.TeacherName;
                if (currentTeacher.permission == 0)
                    radioUser.Checked = true;
                else
                    radioAdmin.Checked = true;
                btnAdd.Text = "保存修改";
                labelPW.Text = "（若不修改密码，此项请留空）";
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
        }
    }
}
