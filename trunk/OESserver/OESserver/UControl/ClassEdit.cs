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
    public partial class ClassEdit : UserControl
    {
        private Classes currentClass;

        public ClassEdit(Classes cls)
        {
            InitializeComponent();
            currentClass = cls;
            textDept.Text = currentClass.dept;
            textClass.Text = currentClass.className;
            textTeacherUserName.Text = currentClass.teacherUserName;
            btnEdit.Text = "修改班级";
            labelInfo.Text = "当前要修改的班级为：" + currentClass.dept + " " + currentClass.className;
            

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
                InfoControl.OesData.UpdateClass(currentClass.classID, textDept.Text, textClass.Text, textTeacherUserName.Text);
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
