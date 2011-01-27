using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OES.UControl
{
    public partial class ClassAdd : UserControl
    {
        public ClassAdd()
        {
            InitializeComponent();
            radioAddOne.Checked = true;
            groupAddMany.Enabled = false;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void radioAddOne_CheckedChanged(object sender, EventArgs e)
        {
            groupAddOne.Enabled = radioAddOne.Checked;
        }

        private void radioAddMany_CheckedChanged(object sender, EventArgs e)
        {
            groupAddMany.Enabled = radioAddMany.Checked;
        }

        private void btnAddOne_Click(object sender, EventArgs e)
        {
            if (textDept.Text == "" || textClass.Text == "")
            {
                MessageBox.Show("输入信息不完整！", "班级管理", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                InfoControl.OesData.AddClass(textDept.Text, textClass.Text, textUserName.Text);
                MessageBox.Show("添加成功！", "班级管理", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearInfo();
            }
            catch
            {
                MessageBox.Show("添加出现错误！", "班级管理", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void clearInfo()
        {
            textDept.Text = textClass.Text = textUserName.Text = "";
        }

        
    }
}
