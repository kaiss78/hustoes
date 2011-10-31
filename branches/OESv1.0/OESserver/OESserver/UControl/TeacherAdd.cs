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
            if (textName.Text == "" || textUserName.Text == "")
            {
                MessageBox.Show("输入信息不完整！", "教师管理", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (currentTeacher == null)         //添加教师过程
                {
                    if (textPW.Text != "" && textPW.Text != textPW2.Text)
                    {
                        MessageBox.Show("两次密码输入不一致！", "添加教师", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        string pw = textPW.Text != "" ? textPW.Text : textUserName.Text;
                        int pm = radioUser.Checked == true ? 0 : 1;
                        InfoControl.OesData.AddTeacher(textName.Text, pw, pm, textUserName.Text);
                        MessageBox.Show("教师添加成功！", "添加教师", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Dispose();
                    }
                }
                else
                {
                    if (textPW.Text != "" && textPW.Text != textPW2.Text)
                    {
                        MessageBox.Show("两次密码输入不一致！", "修改教师", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        string pw = textPW.Text != "" ? textPW.Text : currentTeacher.password;
                        int pm = radioUser.Checked == true ? 0 : 1;
                        InfoControl.OesData.UpdateTeacherById(currentTeacher.Id, textName.Text, pw, pm, textUserName.Text);
                        MessageBox.Show("信息修改成功！", "修改教师", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Dispose();
                    }
                }
            }
        }
    }
}
