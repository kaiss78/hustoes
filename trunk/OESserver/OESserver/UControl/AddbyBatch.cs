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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                AddPath.Text = (openFileDialog1.FileName);
            }
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
        }
    }
}
