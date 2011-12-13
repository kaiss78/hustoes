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
        }
        //填空题
        private void btnConfirm2_Click(object sender, EventArgs e)
        {
            List<string[]> list = CSVHelper.CSVImporter.getObjectInCSV(textBox2.Text, 4);
            InfoControl.OesData.ImportCompletion(list);
        }
        //判断题
        private void btnConfirm3_Click(object sender, EventArgs e)
        {
            List<string[]> list = CSVHelper.CSVImporter.getObjectInCSV(textBox3.Text, 4);
            InfoControl.OesData.ImportJudgment(list);
        }
        //Office题
        private void btnConfirm4_Click(object sender, EventArgs e)
        {
            List<string[]> list = CSVHelper.CSVImporter.getObjectInCSV(textBox4.Text, 7);
            InfoControl.OesData.ImportOffice(list);
        }
        //编程题
        private void btnConfirm5_Click(object sender, EventArgs e)
        {
            List<string[]> list = CSVHelper.CSVImporter.getObjectInCSV(textBox5.Text, 9);
            InfoControl.OesData.ImportProgram(list);
        }
        //单元
        private void btnConfirm6_Click(object sender, EventArgs e)
        {
            List<string[]> list = CSVHelper.CSVImporter.getObjectInCSV(textBox6.Text, 2);
            InfoControl.OesData.ImportUnit(list);
        }
    }
}
