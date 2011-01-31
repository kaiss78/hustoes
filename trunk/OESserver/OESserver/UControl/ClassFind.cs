using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OES.Model;
using OES.UPanel;

namespace OES.UControl
{
    public partial class ClassFind : UserControl
    {
        private List<Teacher> teacherList = null;

        public ClassFind()
        {
            InitializeComponent();
            radioByDept.Checked = true;
            comboTeacher.Hide();
            textKey.Show();
            teacherList = InfoControl.OesData.FindTeacher();
            comboTeacher.Items.Clear();
            comboTeacher.Items.AddRange(ClassManage.comboInfo);
            comboTeacher.SelectedIndex = 0;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

      
        private void btnFind_Click(object sender, EventArgs e)
        {
            if (radioByDept.Checked)
                ClassManage.findData = InfoControl.OesData.FindClassByDept(textKey.Text);
            else if (radioByClass.Checked)
                ClassManage.findData = InfoControl.OesData.FindClassByClassName(textKey.Text);
            else if (radioByTeacherName.Checked)
            {
                string userName = "";
                if (comboTeacher.Text != "暂无教师")
                {
                    int pos = comboTeacher.Text.IndexOf('(');
                    userName = comboTeacher.Text.Substring(pos + 1, comboTeacher.Text.Length - pos - 2);
                }
                ClassManage.findData = InfoControl.OesData.FindClassByUserName(userName);
            }
            ClassManage.findState = 1;
            this.Dispose();
        }

        private void radioByDept_CheckedChanged(object sender, EventArgs e)
        {
            if (radioByDept.Checked)
            {
                labelInfo.Text = "学院名称：";
                textKey.Show();
                comboTeacher.Hide();
            }
        }

        private void radioByClass_CheckedChanged(object sender, EventArgs e)
        {
            if (radioByClass.Checked)
            {
                labelInfo.Text = "班级名称：";
                textKey.Show();
                comboTeacher.Hide();
            }
        }

        private void radioByTeacherName_CheckedChanged(object sender, EventArgs e)
        {
            if (radioByTeacherName.Checked)
            {
                labelInfo.Text = "教师信息：";
                textKey.Hide();
                comboTeacher.Show();
            }
        }

    }
}
