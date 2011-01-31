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
    public partial class StudentEdit : UserControl
    {
        private Student currentStudent;

        public StudentEdit(Student stu)
        {
            InitializeComponent();
            currentStudent = stu;
            textID.Text = currentStudent.ID;
            textName.Text = currentStudent.sName;
            showAllDepts();
            for (int i = 0; i < comboDept.Items.Count; i++)
                if (comboDept.Items[i].ToString() == currentStudent.dept)
                {
                    comboDept.SelectedIndex = i;
                    break;
                }
            for (int i = 0; i < comboClass.Items.Count; i++)
                if (comboClass.Items[i].ToString() == currentStudent.className)
                {
                    comboClass.SelectedIndex = i;
                    break;
                }
            labelInfo.Text = "当前要修改的学生为：" + currentStudent.ID + " " + currentStudent.sName;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void showAllDepts()
        {
            List<string> dps = InfoControl.OesData.FindAllDept();
            object[] ob = new object[dps.Count];
            for (int i = 0; i < dps.Count; i++)
                ob[i] = dps[i];
            comboDept.Items.Clear();
            comboDept.Items.AddRange(ob);
            comboDept.SelectedIndex = 0;
        }

        private void showClassInDept(string dept)
        {
            List<String> cls = InfoControl.OesData.FindClassNameOfDept(dept);
            object[] ob = new object[cls.Count];
            for (int i = 0; i < cls.Count; i++)
                ob[i] = cls[i];
            comboClass.Items.Clear();
            comboClass.Items.AddRange(ob);
            comboClass.SelectedIndex = 0;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (textName.Text == "" || textID.Text == "")
            {
                MessageBox.Show("输入信息不完整！", "学生管理", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textPW.Text != "" && textPW.Text != textPW2.Text)
            {
                MessageBox.Show("两次密码输入不一致！", "学生管理", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string pw = textPW.Text != "" ? textPW.Text : currentStudent.password;
            try
            {
                InfoControl.OesData.UpdateStudent(textID.Text, textName.Text, comboDept.Text, comboClass.Text, pw, currentStudent.ID);
                MessageBox.Show("修改成功！", "学生管理", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            catch
            {
                MessageBox.Show("修改失败，请检查学号是否重复！", "学生管理", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void comboDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            showClassInDept(comboDept.Text);
        }

    }
}
