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
            if (textBox1.Text != "")
            {
                List<string[]> list = CSVHelper.CSVImporter.getObjectInCSV(textBox1.Text, 8);
                InfoControl.OesData.ImportChoice(list);
                MessageBox.Show("选择题批量导入成功!");
                textBox1.Clear();
            }
            else
                MessageBox.Show("请添加文件路径");
        }


        //填空题
        private void btnConfirm2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                List<string[]> list = CSVHelper.CSVImporter.getObjectInCSV(textBox2.Text, 4);
                InfoControl.OesData.ImportCompletion(list);
                MessageBox.Show("填空题批量导入成功!");
                textBox2.Clear();
            }
            else
                MessageBox.Show("请添加文件路径");
        }
        //判断题
        private void btnConfirm3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                List<string[]> list = CSVHelper.CSVImporter.getObjectInCSV(textBox3.Text, 4);
                InfoControl.OesData.ImportJudgment(list);
                MessageBox.Show("判断题批量导入成功!");
                textBox3.Clear();
            }
            else
                MessageBox.Show("请添加文件路径");
        }
        //Office题
        private void btnConfirm4_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {
                List<string[]> list = CSVHelper.CSVImporter.getObjectInCSV(textBox4.Text, 7);
                List<int> ids = InfoControl.OesData.ImportOffice(list);//获得批量导入后的每道题的ID
                string basePath = new FileInfo(textBox4.Text).DirectoryName + "\\";//获得父目录
                try
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        switch (list[i][3].ToLower())
                          {

                                case "word":
                                    if (!File.Exists(basePath + list[i][4]))
                                    {
                                        MessageBox.Show("文件出现异常，请检查");
                                        throw new Exception();
                                    }
                                    File.Copy(basePath + list[i][4], InfoControl.config["WordPath"] + "p" + ids[i] + ".doc");//配置word的路径
                                    File.Copy(basePath + list[i][5], InfoControl.config["WordPath"] + "a" + ids[i] + ".doc");
                                    File.Copy(basePath + list[i][6], InfoControl.config["WordPath"] + "t" + ids[i] + ".xml");
                                    InfoControl.ClientObj.SaveWordP(ids[i], InfoControl.User.Id);//保存文件到指定目录
                                    InfoControl.ClientObj.SaveWordA(ids[i], InfoControl.User.Id);
                                    InfoControl.ClientObj.SaveWordT(ids[i], InfoControl.User.Id);
                                    break;
                                case "excel":
                                    if (!File.Exists(basePath + list[i][4]))
                                    {
                                        MessageBox.Show("文件出现异常，请检查");
                                        throw new Exception();
                                    }
                                    File.Copy(basePath + list[i][4], InfoControl.config["ExcelPath"] + "p" + ids[i] + ".xls");
                                    File.Copy(basePath + list[i][5], InfoControl.config["ExcelPath"] + "a" + ids[i] + ".xls");
                                    File.Copy(basePath + list[i][6], InfoControl.config["ExcelPath"] + "t" + ids[i] + ".xml");
                                    InfoControl.ClientObj.SaveExcelP(ids[i], InfoControl.User.Id);
                                    InfoControl.ClientObj.SaveExcelA(ids[i], InfoControl.User.Id);
                                    InfoControl.ClientObj.SaveExcelT(ids[i], InfoControl.User.Id);
                                    break;
                                case "powerpoint":
                                    if (!File.Exists(basePath + list[i][4]))
                                    {
                                        MessageBox.Show("文件出现异常，请检查");
                                        throw new Exception();
                                    }
                                    File.Copy(basePath + list[i][4], InfoControl.config["PPTPath"] + "p" + ids[i] + ".ppt");
                                    File.Copy(basePath + list[i][5], InfoControl.config["PPTPath"] + "a" + ids[i] + ".ppt");
                                    File.Copy(basePath + list[i][6], InfoControl.config["PPTPath"] + "t" + ids[i] + ".xml");
                                    InfoControl.ClientObj.SavePowerPointP(ids[i], InfoControl.User.Id);
                                    InfoControl.ClientObj.SavePowerPointA(ids[i], InfoControl.User.Id);
                                    InfoControl.ClientObj.SavePowerPointT(ids[i], InfoControl.User.Id);
                                    break;
                            default:
                                    throw new Exception();
                            
                        }
                    }

                    InfoControl.ClientObj.SendFiles();
                    MessageBox.Show("Office题批量导入成功!");
                    textBox4.Clear();
                }
                catch
                {
                    MessageBox.Show("找不到指定文件，请检查");
                }
            }
            else
            {
                MessageBox.Show("请输入文件路径"); 
            }
        }
        //编程题
        private void btnConfirm5_Click(object sender, EventArgs e)
        {
            if (textBox5.Text != "")
            {
                List<string[]> list = CSVHelper.CSVImporter.getObjectInCSV(textBox5.Text, 9);
                List<int> ids = InfoControl.OesData.ImportProgram(list);
                string basePath = new FileInfo(textBox5.Text).DirectoryName + "\\";
                try
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        switch (list[i][4].ToLower())
                        {
                            case "c":
                                if (!File.Exists(basePath + list[i][5]))
                                {
                                    MessageBox.Show("文件出现异常，请检查");
                                    throw new Exception();
                                }
                                CPro(list[i], ids[i], basePath); break;
                            case "cpp":
                                if (!File.Exists(basePath + list[i][5]))
                                {
                                    MessageBox.Show("文件出现异常，请检查");
                                    throw new Exception();
                                }
                                CppPro(list[i], ids[i], basePath); break;
                            case "vb":
                                if (!File.Exists(basePath + list[i][5]))
                                {
                                    MessageBox.Show("文件出现异常，请检查");
                                    throw new Exception();
                                }
                                VBPro(list[i], ids[i], basePath); break;
                            default:
                                throw new Exception();
                                
                        }
                    }
                    InfoControl.ClientObj.SendFiles();
                    MessageBox.Show("编程题批量导入成功!");
                    textBox5.Clear();
                }
                catch {
                    MessageBox.Show("找不到指定文件，请检查");
                }
            }
            else
                MessageBox.Show("请输入文件路径");
        }
        //单元
        private void btnConfirm6_Click(object sender, EventArgs e)
        {
            if (textBox6.Text != "")
            {
                List<string[]> list = CSVHelper.CSVImporter.getObjectInCSV(textBox6.Text, 2);
                InfoControl.OesData.ImportUnit(list);
                MessageBox.Show("单元批量导入成功!");
                textBox6.Clear();
            }
            else
                MessageBox.Show("请输入文件路径");
        }


        public void CppPro(string[] list, int ids,string basePath)//list每一行逗号分隔符，以字符串组的形式村存储
        {                                                         //ids是每道题的题号,basePath为父目录的路径
            
                switch (list[3].ToLower())
                {
                    case "comp":
                        File.Copy(basePath + list[5], InfoControl.config["CompletionPath"] + "p" + ids + ".cpp");
                        InfoControl.ClientObj.SaveCppCompletion(ids, InfoControl.User.Id);
                        break;
                    case "modi":
                        File.Copy(basePath + list[5], InfoControl.config["ModificationPath"] + "p" + ids + ".cpp");
                        InfoControl.ClientObj.SaveCppModification(ids, InfoControl.User.Id);
                        break;
                    case "prog":
                        File.Copy(basePath + list[5], InfoControl.config["FunctionPath"] + "p" + ids + ".cpp");
                        File.Copy(basePath + list[6], InfoControl.config["FunctionPath"] + "a" + ids + ".cpp");
                        InfoControl.ClientObj.SaveCppFunctionP(ids, InfoControl.User.Id);
                        InfoControl.ClientObj.SaveCppFunctionA(ids, InfoControl.User.Id);
                        break;
            }
        }
        public void CPro(string[] list, int ids, string basePath)
        {
            
                switch (list[3].ToLower())
                {
                    case "comp":
                        File.Copy(basePath + list[5], InfoControl.config["CompletionPath"] + "p" + ids + ".c");
                        InfoControl.ClientObj.SaveCCompletion(ids, InfoControl.User.Id);
                        break;
                    case "modi":
                        File.Copy(basePath + list[5], InfoControl.config["ModificationPath"] + "p" + ids + ".c");
                        InfoControl.ClientObj.SaveCModification(ids, InfoControl.User.Id);
                        break;
                    case "prog":
                        File.Copy(basePath + list[5], InfoControl.config["FunctionPath"] + "p" + ids + ".c");
                        File.Copy(basePath + list[6], InfoControl.config["FunctionPath"] + "a" + ids + ".c");

                        InfoControl.ClientObj.SaveCFunctionP(ids, InfoControl.User.Id);
                        InfoControl.ClientObj.SaveCFunctionA(ids, InfoControl.User.Id);
                        break;
                

            }

        }
        public void VBPro(string[] list, int ids, string basePath)
        {
           
                switch (list[3].ToLower())
                {
                    case "comp":
                        File.Copy(basePath + list[5], InfoControl.config["CompletionPath"] + "p" + ids + ".vb");
                        InfoControl.ClientObj.SaveVbCompletion(ids, InfoControl.User.Id);
                        break;
                    case "modi":
                        File.Copy(basePath + list[5], InfoControl.config["ModificationPath"] + "p" + ids + ".vb");
                        InfoControl.ClientObj.SaveVbModification(ids, InfoControl.User.Id);
                        break;
                    case "prog":
                        File.Copy(basePath + list[5], InfoControl.config["FunctionPath"] + "p" + ids + ".vb");
                        File.Copy(basePath + list[6], InfoControl.config["FunctionPath"] + "a" + ids + ".vb");

                        InfoControl.ClientObj.SaveVbFunctionP(ids, InfoControl.User.Id);
                        InfoControl.ClientObj.SaveVbFunctionA(ids, InfoControl.User.Id);
                        break;
                

            }

        }
    }
}

