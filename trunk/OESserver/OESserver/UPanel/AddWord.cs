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
    public partial class AddWord : UserPanel
    {
        int mode = 0;           //新增或修改 分别为0和1
        FileInfo fori, fans, fxml;
        string tmpDir;

        public AddWord()
        {
            InitializeComponent();
            tmpDir = InfoControl.config["WordPath"];
        }

        public override void ReLoad()
        {
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
            ofd.Filter = "Word文档(*.doc)|*.doc";
            if (ofd.ShowDialog() == DialogResult.OK)
                textOriWord.Text = ofd.FileName;
        }

        private void btnAnsSel_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Word文档(*.doc)|*.doc";
            if (ofd.ShowDialog() == DialogResult.OK)
                textAnsWord.Text = ofd.FileName;
        }

        private void buttonTestPoint_Click(object sender, EventArgs e)
        {
            if (File.Exists(textOriWord.Text) && File.Exists(textAnsWord.Text))
            {
                OfficeFrm.WordFrm wf = new OES.OfficeFrm.WordFrm();
                FileInfo f = new FileInfo(textAnsWord.Text);
                string xml_path = f.DirectoryName + "\\!Mask!" + f.Name + ".xml";
                buttonTestPoint.Text = "正在打开添加考点界面，请耐心等待...";
                buttonTestPoint.Enabled = false;
                wf.LoadWord(textAnsWord.Text, xml_path);
                wf.ShowDialog();
                buttonTestPoint.Enabled = true;
                buttonTestPoint.Text = "点此添加考点";
            }
            else
            {
                MessageBox.Show("请检查Word路径是否有误！", "添加考点", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private int judgeFileExist()
        {
            fori = new FileInfo(textOriWord.Text);
            fans = new FileInfo(textAnsWord.Text);
            string xml_path = fori.DirectoryName + "\\!Mask!" + fori.Name + ".xml";
            fxml = new FileInfo(xml_path);
            if (!fori.Exists) return -1;
            if (!fans.Exists) return -2;
            if (!fxml.Exists) return -3;
            return 0;
        }

        private void upload(int pid)
        {
            fori.CopyTo(tmpDir + "p" + pid.ToString() + ".doc");
            fans.CopyTo(tmpDir + "a" + pid.ToString() + ".doc");
            fxml.CopyTo(tmpDir + "t" + pid.ToString() + ".xml");
            InfoControl.ClientObj.SaveWordA(pid, InfoControl.User.Id);
            InfoControl.ClientObj.SaveWordP(pid, InfoControl.User.Id);
            InfoControl.ClientObj.SaveWordT(pid, InfoControl.User.Id);
            InfoControl.ClientObj.SendFiles();
        }

        private void delTmpFile(int pid)    //删除临时文件
        {
            fori = new FileInfo(tmpDir + "p" + pid.ToString() + ".doc");
            fans = new FileInfo(tmpDir + "a" + pid.ToString() + ".doc");
            fxml = new FileInfo(tmpDir + "t" + pid.ToString() + ".xml");
            fori.Delete(); fans.Delete(); fxml.Delete();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int unit = (this.Parent.Parent as AddQuetionPanel).Capter;
            int plvl = (this.Parent.Parent as AddQuetionPanel).Difficulity;

            if (textAnsWord.Text == "" || textOriWord.Text == "" || textInfo.Text == "")
            {
                MessageBox.Show("请完成试题信息");
                return;
            }
            if (mode == 0)      //新增Word
            {
                int judge = judgeFileExist();
                if (judge == -1)
                    MessageBox.Show("初始Word文件不存在！");
                else if (judge == -2)
                    MessageBox.Show("标答Word文件不存在！");
                else if (judge == -3)
                    MessageBox.Show("考点xml文件不存在！");
                else if (MessageBox.Show("确定提交吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int PID = InfoControl.OesData.AddOffice(textInfo.Text, unit, plvl, OES.Model.Office.OfficeType.PowerPoint);
                    Net.ClientEvt.FilesComplete += new Action(ClientEvt_FilesComplete);
                    upload(PID);
                }
            }
        }

        void ClientEvt_FilesComplete()
        {
            
        }


    }
}
