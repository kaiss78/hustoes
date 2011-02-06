using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OES.UPanel;
using OES.Model;

namespace OES.UControl
{
    public partial class StudentFind : UserControl
    {

        string permissionUserName = "";                 //当前登录的用户名，用来区分权限，若为空表示是管理员

        public StudentFind()
        {
            InitializeComponent();
            radioByName.Checked = true;
            comboTeacher.Hide();
            comboClass.Hide();
            comboDept.Hide();
            textKey.Show();
            comboTeacher.Items.Clear();
            comboTeacher.Items.AddRange(StudentManage.comboInfo);
            comboTeacher.SelectedIndex = 0;
            if (InfoControl.User.permission == 0)
            {
                permissionUserName = InfoControl.User.UserName;
                ChangeDisplay();
            }
            showAllDepts();
        }

        private void ChangeDisplay()
        {
            radioByTeacher.Visible = false;
            radioByID.Top = (radioByName.Top + radioByClass.Top) / 2;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void showAllDepts()
        {
            List<string> dps = new List<string>();
            if (permissionUserName == "")
                dps = InfoControl.OesData.FindAllDept();
            else
                dps = InfoControl.OesData.FindAllDeptWithTeacher(permissionUserName);
            object[] ob = new object[dps.Count];
            for (int i = 0; i < dps.Count; i++)
                ob[i] = dps[i];
            comboDept.Items.Clear();
            comboDept.Items.AddRange(ob);
            comboDept.SelectedIndex = 0;
        }

        private void showClassInDept(string dept)
        {
            List<String> cls = new List<string>();
            if (permissionUserName == "")
                cls = InfoControl.OesData.FindClassNameOfDept(dept);
            else
                cls = InfoControl.OesData.FindClassNameOfDeptWithTeacher(dept, permissionUserName);
            object[] ob = new object[cls.Count];
            for (int i = 0; i < cls.Count; i++)
                ob[i] = cls[i];
            comboClass.Items.Clear();
            comboClass.Items.Add("所有学生");
            comboClass.Items.AddRange(ob);
            comboClass.SelectedIndex = 0;
        }

        private void radioByName_CheckedChanged(object sender, EventArgs e)
        {
            labelInfo.Text = "学生姓名：";
            comboTeacher.Hide();
            comboDept.Hide();
            comboClass.Hide();
            textKey.Show();
        }

        private void radioByID_CheckedChanged(object sender, EventArgs e)
        {
            labelInfo.Text = "学生学号：";
            comboTeacher.Hide();
            comboDept.Hide();
            comboClass.Hide();
            textKey.Show();
        }

        private void radioByClass_CheckedChanged(object sender, EventArgs e)
        {
            labelInfo.Text = "班级信息：";
            comboTeacher.Hide();
            comboDept.Show();
            comboClass.Show();
            textKey.Hide();
        }

        private void radioByTeacher_CheckedChanged(object sender, EventArgs e)
        {
            labelInfo.Text = "教师信息：";
            comboTeacher.Show();
            comboDept.Hide();
            comboClass.Hide();
            textKey.Hide();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (radioByName.Checked)
                StudentManage.findData = InfoControl.OesData.FindStudentByName(textKey.Text);
            else if (radioByID.Checked)
                StudentManage.findData = InfoControl.OesData.FindStudentByStudentId(textKey.Text);
            else if (radioByTeacher.Checked)
            {
                string userName = "";
                if (comboTeacher.Text != "暂无教师")
                {
                    int pos = comboTeacher.Text.IndexOf('(');
                    userName = comboTeacher.Text.Substring(pos + 1, comboTeacher.Text.Length - pos - 2);
                }
                StudentManage.findData = InfoControl.OesData.FindStudentByUserName(userName);
            }
            else if (radioByClass.Checked)
            {
                string className = comboClass.Text != "所有学生" ? comboClass.Text : "";
                StudentManage.findData = InfoControl.OesData.FindStudentByClass(comboDept.Text, className);
            }
            StudentManage.findState = 1;
            this.Dispose();
        }

        private void comboDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            showClassInDept(comboDept.Text);
        }
    }
}
