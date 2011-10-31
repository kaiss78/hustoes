using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OES.UPanel;

namespace OES.UControl
{
    public partial class AddbyBatch : UserControl
    {
        ProMan aProMan;  
        public AddbyBatch(ProMan pm)
        {
            InitializeComponent();
            aProMan = pm;
            switch (aProMan.ProType)
            { 
                case 0:
                    title.Text = "选择题";
                    break;
                case 1:
                    title.Text = "填空题";
                    break;               
                case 2:
                    title.Text = "判断题";
                    break;
                case 3:
                    title.Text = "电子表格";
                    break;
                case 4:
                    title.Text = "演示文稿";
                    break;
                case 5:
                    title.Text = "字处理";
                    break;
                case 6:
                    title.Text = "C程序填空";
                    break;
                case 7:
                    title.Text = "C程序改错";
                    break;
                case 8:
                    title.Text = "C程序编程";
                    break;
                case 9:
                    title.Text = "C++程序填空";
                    break;
                case 10:
                    title.Text = "C++程序改错";
                    break;
                case 11:
                    title.Text = "C++程序编程";
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                AddPath.Text = (openFileDialog1.FileName);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
            aProMan.aProList.Show();
            aProMan.ShowTBPanel();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<string[]> dataList;
            try
            {
                dataList = CSVHelper.CSVImporter.getObjectInCSV(AddPath.Text, 7);
            }
            catch
            {
                MessageBox.Show("文件读取失败！", "导入选择题", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                InfoControl.OesData.AddManyChoices(dataList);
                MessageBox.Show("导入成功！", "导入选择题", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("导入失败！", "导入选择题", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Dispose();
            aProMan.aProList.Show();
            aProMan.ShowTBPanel();
        }
    }
}
