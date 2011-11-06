using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace correctExcel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Microsoft Excel工作表(*.xls)|*.xls";
            if (of.ShowDialog() == DialogResult.OK)
                textOrigin.Text = of.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Microsoft Excel工作表(*.xls)|*.xls";
            if (of.ShowDialog() == DialogResult.OK)
                textAns.Text = of.FileName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "XML文档(*.xml)|*.xml";
            if (of.ShowDialog() == DialogResult.OK)
                textPoint.Text = of.FileName;
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            if (textOrigin.Text == "" || textPoint.Text == "" || textAns.Text == "")
            {
                MessageBox.Show("请选择文件！");
                return;
            }
            correctExcel co = new correctExcel();
            int points = co.checkPoints(textOrigin.Text, textAns.Text, textPoint.Text);
            MessageBox.Show("评分结束： " + points.ToString() + "分");
        }
    }
}
