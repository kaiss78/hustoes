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
    public partial class ClassAdd : UserControl
    {

        public ClassAdd()
        {
            InitializeComponent();
            radioAddOne.Checked = true;
            groupAddMany.Enabled = false;
            comboTeacher.Items.AddRange(ClassManage.comboInfo);
            comboTeacher.SelectedIndex = 0;
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
                string userName = "";
                if (comboTeacher.Text != "暂无教师")
                {
                    int pos = comboTeacher.Text.IndexOf('(');
                    userName = comboTeacher.Text.Substring(pos + 1, comboTeacher.Text.Length - pos - 2);
                }
                InfoControl.OesData.AddClass(textDept.Text, textClass.Text, userName);
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
            textDept.Text = textClass.Text = textFile.Text = "";
            comboTeacher.SelectedIndex = 0;
        }

        private void btnAddMany_Click(object sender, EventArgs e)
        {
            List<string[]> dataList;
            try
            {
                dataList = CSVHelper.CSVImporter.getObjectInCSV(textFile.Text, 3);
            }
            catch
            {
                MessageBox.Show("文件读取失败！", "班级管理", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                InfoControl.OesData.AddManyClasses(dataList);
                MessageBox.Show("导入成功！", "班级管理", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearInfo();
            }
            catch
            {
                MessageBox.Show("导入失败！", "班级管理", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "CSV文件(逗号分隔)(*.csv)|*.csv|所有文件(*.*)|*.*";
            of.ShowDialog();
            textFile.Text = of.FileName;
        }

        
    }
}
