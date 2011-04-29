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
    public partial class ClassEdit : UserControl
    {
        private Classes currentClass;

        public ClassEdit(Classes cls)
        {
            InitializeComponent();
            currentClass = cls;
            textDept.Text = currentClass.dept;
            textClass.Text = currentClass.className;
            btnEdit.Text = "修改班级";
            labelInfo.Text = "当前要修改的班级为：" + currentClass.dept + " " + currentClass.className;
            comboTeacher.Items.AddRange(ClassManage.comboInfo);
            comboTeacher.SelectedIndex = ClassManage.teacherList.Count;
            for (int i = 0; i < ClassManage.teacherList.Count; i++)
                if (currentClass.teacherUserName == ClassManage.teacherList[i].TeacherName)
                {
                    comboTeacher.SelectedIndex = i;
                    break;
                }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (textDept.Text == "" || textClass.Text == "")
            {
                MessageBox.Show("输入信息不完整！", "班级管理", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                string userName = "";
                if (comboTeacher.Text != "暂无教师")
                {
                    int pos = comboTeacher.Text.IndexOf('(');
                    userName = comboTeacher.Text.Substring(pos + 1, comboTeacher.Text.Length - pos - 2);
                }
                InfoControl.OesData.UpdateClass(currentClass.classID, textDept.Text, textClass.Text, userName);
                MessageBox.Show("修改成功！", "班级管理", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch 
            {
                MessageBox.Show("修改出现意外错误！", "班级管理", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            this.Dispose();
        }
    }
}
