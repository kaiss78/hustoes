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
    public partial class StudentAdd : UserControl
    {
        public StudentAdd()
        {
            InitializeComponent();
            radioAddOne.Checked = true;
            groupAddMany.Enabled = false;
            showAllDepts();
        }

        private void radioAddOne_CheckedChanged(object sender, EventArgs e)
        {
            groupAddOne.Enabled = radioAddOne.Checked;
        }

        private void radioAddMany_CheckedChanged(object sender, EventArgs e)
        {
            groupAddMany.Enabled = radioAddMany.Checked;
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
            comboOneDept.Items.Clear();
            comboOneDept.Items.AddRange(ob);
            comboOneDept.SelectedIndex = 0;
        }

        private void showClassInDept(string dept)
        {
            List<String> cls = InfoControl.OesData.FindClassNameOfDept(dept);
            object[] ob = new object[cls.Count];
            for (int i = 0; i < cls.Count; i++)
                ob[i] = cls[i];
            comboOneClass.Items.Clear();
            comboOneClass.Items.AddRange(ob);
            comboOneClass.SelectedIndex = 0;
        }

        private void comboOneDept_TextChanged(object sender, EventArgs e)
        {
            showClassInDept(comboOneDept.Text);
        }

        private void btnAddOne_Click(object sender, EventArgs e)
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
            string pw = textPW.Text != "" ? textPW.Text : textID.Text;
            //InfoControl.AddStudent();
            MessageBox.Show("貌似成功了");
            clearInfo();
        }

        private void clearInfo()
        {
            showAllDepts();
            textID.Text = textName.Text = textPW.Text = textPW2.Text = "";
        }

        private void btnAddMany_Click(object sender, EventArgs e)
        {
            List<Object[]> dataList;
            if (textClass.Text == "" || textDept.Text == "" || textFile.Text == "")
            {
                MessageBox.Show("输入信息不完整！", "学生管理", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try 
            {
                dataList = CVSHelper.CSVImporter.getObjectInCSV(textFile.Text, 2);
                for (int i = 0; i < dataList.Count; i++)
                {
                    for (int j = 0; j < 2; j++)
                        Console.Write(dataList[i][j].ToString() + " ");
                    Console.WriteLine("");
                }
            } 
            catch 
            {
                MessageBox.Show("文件读取失败！", "学生管理", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            /*
            for (int i = 0; i < dataList.Count; i++)
            {
                try 
                { 
                    //InfoControl.OesData.AddS
                }
                catch { }
            }
            */
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
