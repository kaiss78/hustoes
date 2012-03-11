using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using OES.Net;

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
            List<int> ids = InfoControl.OesData.ImportOffice(list);
            string basePath = new FileInfo(textBox4.Text).DirectoryName;
            for (int i = 0; i < list.Count; i++)
            {
                switch (list[i][3].ToLower())
                {
                    case "word":
                        File.Move(basePath + list[i][4], InfoControl.config["WordPath"] + "p" + ids[i] + ".doc");
                        File.Move(basePath + list[i][5], InfoControl.config["WordPath"] + "a" + ids[i] + ".doc");
                        File.Move(basePath + list[i][6], InfoControl.config["WordPath"] + "t" + ids[i] + ".xml");
                        InfoControl.ClientObj.SaveWordP(ids[i], InfoControl.User.Id);
                        InfoControl.ClientObj.SaveWordA(ids[i], InfoControl.User.Id);
                        InfoControl.ClientObj.SaveWordT(ids[i], InfoControl.User.Id);
                        break;
                    case "excel":
                        File.Move(basePath + list[i][4], InfoControl.config["ExcelPath"] + "p" + ids[i] + ".xls");
                        File.Move(basePath + list[i][5], InfoControl.config["ExcelPath"] + "a" + ids[i] + ".xls");
                        File.Move(basePath + list[i][6], InfoControl.config["ExcelPath"] + "t" + ids[i] + ".xml");
                        InfoControl.ClientObj.SaveExcelP(ids[i], InfoControl.User.Id);
                        InfoControl.ClientObj.SaveExcelA(ids[i], InfoControl.User.Id);
                        InfoControl.ClientObj.SaveExcelT(ids[i], InfoControl.User.Id);
                        break;
                    case "powerpoint":
                        File.Move(basePath + list[i][4], InfoControl.config["PPTPath"] + "p" + ids[i] + ".doc");
                        File.Move(basePath + list[i][5], InfoControl.config["PPTPath"] + "a" + ids[i] + ".doc");
                        File.Move(basePath + list[i][6], InfoControl.config["PPTPath"] + "t" + ids[i] + ".xml");
                        InfoControl.ClientObj.SavePowerPointP(ids[i], InfoControl.User.Id);
                        InfoControl.ClientObj.SavePowerPointA(ids[i], InfoControl.User.Id);
                        InfoControl.ClientObj.SavePowerPointT(ids[i], InfoControl.User.Id);
                        break;
                }
                InfoControl.ClientObj.SendFiles();
                MessageBox.Show("Office题批量导入成功!");
                textBox4.Clear();
            }
        }
        //编程题
        private void btnConfirm5_Click(object sender, EventArgs e)
        {
            List<string[]> list = CSVHelper.CSVImporter.getObjectInCSV(textBox5.Text, 9);
            List<int> ids = InfoControl.OesData.ImportProgram(list);
            string basePath = new FileInfo(textBox5.Text).DirectoryName;
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
