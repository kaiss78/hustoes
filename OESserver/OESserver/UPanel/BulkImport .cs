using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OES.UPanel
{
    public partial class BulkImport : UserPanel
    {
        Dictionary<Button, TextBox> dict = new Dictionary<Button, TextBox>();
        public BulkImport()
        {
            InitializeComponent();
            dict.Add(btnBrowse1, textBox1);
            dict.Add(btnBrowse2, textBox2);
            dict.Add(btnBrowse3, textBox3);
            dict.Add(btnBrowse4, textBox4);
            dict.Add(btnBrowse5, textBox5);
            dict.Add(btnBrowse6, textBox6);
        }

        public override void ReLoad()
        {
            this.Visible = true;
        }

        private void btnBrowse1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                dict[sender as Button].Text = openFileDialog1.FileName;
            }
        }
        //选择题
        private void btnConfirm1_Click(object sender, EventArgs e)
        {
            List<string[]> list = CSVHelper.CSVImporter.getObjectInCSV(textBox1.Text, 8);
            InfoControl.OesData.ImportChoice(list);
            MessageBox.Show("选择题批量导入成功!");
            textBox1.Clear();
        }
        //填空题
        private void btnConfirm2_Click(object sender, EventArgs e)
        {
            List<string[]> list = CSVHelper.CSVImporter.getObjectInCSV(textBox2.Text, 4);
            InfoControl.OesData.ImportCompletion(list);
            MessageBox.Show("填空题批量导入成功!");
            textBox2.Clear();
        }
        //判断题
        private void btnConfirm3_Click(object sender, EventArgs e)
        {
            List<string[]> list = CSVHelper.CSVImporter.getObjectInCSV(textBox3.Text, 4);
            InfoControl.OesData.ImportJudgment(list);
            MessageBox.Show("判断题批量导入成功!");
            textBox3.Clear();
        }
        //Office题
        private void btnConfirm4_Click(object sender, EventArgs e)
        {
            List<string[]> list = CSVHelper.CSVImporter.getObjectInCSV(textBox4.Text, 7);
            InfoControl.OesData.ImportOffice(list);
            MessageBox.Show("Office题批量导入成功!");
            textBox4.Clear();
        }
        //编程题
        private void btnConfirm5_Click(object sender, EventArgs e)
        {
            List<string[]> list = CSVHelper.CSVImporter.getObjectInCSV(textBox5.Text, 9);
            InfoControl.OesData.ImportProgram(list);
            MessageBox.Show("编程题批量导入成功!");
            textBox5.Clear();
        }
        //单元
        private void btnConfirm6_Click(object sender, EventArgs e)
        {
            List<string[]> list = CSVHelper.CSVImporter.getObjectInCSV(textBox6.Text, 2);
            InfoControl.OesData.ImportUnit(list);
            MessageBox.Show("单元批量导入成功!");
            textBox6.Clear();
        }
    }
}
