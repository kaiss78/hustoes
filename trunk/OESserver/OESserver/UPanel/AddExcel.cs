using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace OES.UPanel
{
    public partial class AddExcel : UserPanel
    {
        int mode = 0;
        FileInfo fori, fans, fxml;
        string tmpDir;
        int PID;

        public AddExcel()
        {
            InitializeComponent();
            tmpDir = InfoControl.config["ExcelPath"];
        }

        public override void ReLoad()
        {
            mode = 0;
            this.Visible = true;
            textInfo.Text = "";
        }

        public void SetMode(int md)
        {
            mode = md;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            PanelControl.ChangPanel(0);
        }

        private void btnOriSel_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "电子表格(*.xls)|*.xls";
            if (ofd.ShowDialog() == DialogResult.OK)
                textOriExcel.Text = ofd.FileName;
        }

        private void btnAnsSel_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "电子表格(*.xls)|*.xls";
            if (ofd.ShowDialog() == DialogResult.OK)
                textAnsExcel.Text = ofd.FileName;
        }

        private void btnXmlSel_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Xml文档(*.xml)|*.xml";
            if (ofd.ShowDialog() == DialogResult.OK)
                textXmlExcel.Text = ofd.FileName;
        }

        private void buttonTestPoint_Click(object sender, EventArgs e)
        {
            if (File.Exists(textOriExcel.Text) && File.Exists(textAnsExcel.Text))
            {
                OfficeFrm.ExcelFrm ef = new OES.OfficeFrm.ExcelFrm();
                FileInfo f = new FileInfo(textAnsExcel.Text);
                string msk = f.Name.Substring(0, f.Name.LastIndexOf('.'));
                string xml_path = f.DirectoryName + "\\" + msk + ".tmp";
                buttonTestPoint.Text = "正在打开添加考点界面，请耐心等待...";
                buttonTestPoint.Enabled = false;
                ef.LoadExcel(textAnsExcel.Text, xml_path);
                //ef.ShowDialog();
                string tmp = ef.ShowForm();
                if (tmp != "")
                    textXmlExcel.Text = tmp;
                buttonTestPoint.Enabled = true;
                buttonTestPoint.Text = "点此建立新考点";
            }
            else
            {
                MessageBox.Show("请检查Excel文件路径是否有误！", "添加考点", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private int judgeFileExist()
        {
            fori = new FileInfo(textOriExcel.Text);
            fans = new FileInfo(textAnsExcel.Text);
            fxml = new FileInfo(textXmlExcel.Text);
            if (!fori.Exists) return -1;
            if (!fans.Exists) return -2;
            if (!fxml.Exists) return -3;
            return 0;
        }

        private void upload(int pid)
        {
            fori.CopyTo(tmpDir + "p" + pid.ToString() + ".xls", true);
            fans.CopyTo(tmpDir + "a" + pid.ToString() + ".xls", true);
            fxml.CopyTo(tmpDir + "t" + pid.ToString() + ".xml", true);
            InfoControl.ClientObj.SaveExcelA(pid, InfoControl.User.Id);
            InfoControl.ClientObj.SaveExcelP(pid, InfoControl.User.Id);
            InfoControl.ClientObj.SaveExcelT(pid, InfoControl.User.Id);
            InfoControl.ClientObj.SendFiles();
        }

        private void delTmpFile(int pid)    //删除临时文件
        {
            fori = new FileInfo(tmpDir + "p" + pid.ToString() + ".xls");
            fans = new FileInfo(tmpDir + "a" + pid.ToString() + ".xls");
            fxml = new FileInfo(tmpDir + "t" + pid.ToString() + ".xml");
            fori.Delete(); fans.Delete(); fxml.Delete();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int unit = (this.Parent.Parent as AddQuetionPanel).Capter;
            int plvl = (this.Parent.Parent as AddQuetionPanel).Difficulity;

            if (textAnsExcel.Text == "" || textOriExcel.Text == "" || textInfo.Text == "")
            {
                MessageBox.Show("请完成试题信息");
                return;
            }
            if (mode == 0)              //新增Excel
            {
                int judge = judgeFileExist();
                if (judge == -1)
                    MessageBox.Show("初始Excel文件不存在！");
                else if (judge == -2)
                    MessageBox.Show("标答Excel文件不存在！");
                else if (judge == -3)
                    MessageBox.Show("考点xml文件不存在！");
                else if (MessageBox.Show("确定提交吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    PID = InfoControl.OesData.AddOffice(textInfo.Text, unit, plvl, OES.Model.Office.OfficeType.Excel);
                    Net.ClientEvt.FilesComplete += new Action(ClientEvt_FilesComplete);
                    upload(PID);
                }
            }
            else                        //修改Excel
            {

            }
        }

        void ClientEvt_FilesComplete()
        {
            MessageBox.Show("保存成功");
            delTmpFile(PID);
            Net.ClientEvt.FilesComplete -= ClientEvt_FilesComplete;
            ReLoad();
        }
    }
}
