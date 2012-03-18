using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using OES.Model;

namespace OES.UPanel
{
    public partial class AddPowerpoint : UserPanel
    {
        int mode = 0;           //新增或修改 分别为0和1
        FileInfo fori, fans, fxml;
        string tmpDir;
        int PID;

        public AddPowerpoint()
        {
            InitializeComponent();
            tmpDir = InfoControl.config["PPTPath"];
        }

        public override void ReLoad()
        {
            mode = 0;
            this.Visible = true;
            textInfo.Text = "";
        }

        public override void ReLoad(int pid)
        {
            ReLoad();
            mode = 1;
            PID = pid;
            delTmpFile(pid);
            List<OfficePowerPoint> lop = InfoControl.OesData.FindOfficePowerPointByPID(PID);
            OfficePowerPoint op = lop[0];
            textInfo.Text = op.problem;
            InfoControl.ClientObj.LoadPowerPointA(pid, InfoControl.User.Id);
            InfoControl.ClientObj.LoadPowerPointP(pid, InfoControl.User.Id);
            InfoControl.ClientObj.LoadPowerPointT(pid, InfoControl.User.Id);
            textOriPPT.Text = InfoControl.config["PPTPath"] + "p" + pid.ToString() + ".ppt";
            textAnsPPT.Text = InfoControl.config["PPTPath"] + "a" + pid.ToString() + ".ppt";
            textXmlPPT.Text = InfoControl.config["PPTPath"] + "t" + pid.ToString() + ".xml";
            InfoControl.ClientObj.ReceiveFiles();
        }

        public void SetMode(int md)
        {
            mode = md;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (PID != 0)
                delTmpFile(PID);
            PanelControl.ChangPanel(0);
        }

        private void btnOriSel_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "演示文稿(*.ppt)|*.ppt";
            if (ofd.ShowDialog() == DialogResult.OK)
                textOriPPT.Text = ofd.FileName;
        }

        private void btnAnsSel_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "演示文稿(*.ppt)|*.ppt";
            if (ofd.ShowDialog() == DialogResult.OK)
                textAnsPPT.Text = ofd.FileName;
        }

        private void btnXmlSel_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Xml文档(*.xml)|*.xml";
            if (ofd.ShowDialog() == DialogResult.OK)
                textXmlPPT.Text = ofd.FileName;
        }

        private void buttonTestPoint_Click(object sender, EventArgs e)
        {
            if (File.Exists(textOriPPT.Text) && File.Exists(textAnsPPT.Text))
            {
                OfficeFrm.PptFrm pf = new OES.OfficeFrm.PptFrm();
                FileInfo f = new FileInfo(textAnsPPT.Text);
                string msk = f.Name.Substring(0, f.Name.LastIndexOf('.'));
                string xml_path = f.DirectoryName + "\\" + msk + ".tmp";
                buttonTestPoint.Text = "正在打开添加考点界面，请耐心等待...";
                buttonTestPoint.Enabled = false;
                pf.LoadPPT(textAnsPPT.Text, xml_path);
                //pf.ShowDialog();
                string tmp = pf.ShowForm();
                if (tmp != "")
                    textXmlPPT.Text = tmp;
                buttonTestPoint.Enabled = true;
                buttonTestPoint.Text = "点此建立新考点";
            }
            else
            {
                MessageBox.Show("请检查PPT路径是否有误！", "添加考点", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private int judgeFileExist()
        {
            fori = new FileInfo(textOriPPT.Text);
            fans = new FileInfo(textAnsPPT.Text);
            fxml = new FileInfo(textXmlPPT.Text);
            if (!fori.Exists) return -1;
            if (!fans.Exists) return -2;
            if (!fxml.Exists) return -3;
            return 0;
        }

        private void upload(int pid)
        {
            if (fori.FullName != tmpDir + "p" + pid.ToString() + ".ppt")
                fori.CopyTo(tmpDir + "p" + pid.ToString() + ".ppt", true);
            if (fans.FullName != tmpDir + "a" + pid.ToString() + ".ppt")
                fans.CopyTo(tmpDir + "a" + pid.ToString() + ".ppt", true);
            if (fxml.FullName != tmpDir + "t" + pid.ToString() + ".xml")
                fxml.CopyTo(tmpDir + "t" + pid.ToString() + ".xml", true);
            InfoControl.ClientObj.SavePowerPointA(pid, InfoControl.User.Id);
            InfoControl.ClientObj.SavePowerPointP(pid, InfoControl.User.Id);
            InfoControl.ClientObj.SavePowerPointT(pid, InfoControl.User.Id);
            InfoControl.ClientObj.SendFiles();
        }

        private void delTmpFile(int pid)    //删除临时文件
        {
            fori = new FileInfo(tmpDir + "p" + pid.ToString() + ".ppt");
            fans = new FileInfo(tmpDir + "a" + pid.ToString() + ".ppt");
            fxml = new FileInfo(tmpDir + "t" + pid.ToString() + ".xml");
            if (fori.Exists) fori.Delete();
            if (fans.Exists) fans.Delete();
            if (fxml.Exists) fxml.Delete();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int unit = (this.Parent.Parent as AddQuetionPanel).Capter;
            int plvl = (this.Parent.Parent as AddQuetionPanel).Difficulity;

            if (textAnsPPT.Text == "" || textOriPPT.Text == "" || textInfo.Text == "")
            {
                MessageBox.Show("请完成试题信息");
                return;
            }
            int judge = judgeFileExist();
            if (judge == -1)
                MessageBox.Show("初始PPT文件不存在！");
            else if (judge == -2)
                MessageBox.Show("标答PPT文件不存在！");
            else if (judge == -3)
                MessageBox.Show("考点xml文件不存在！");
            else if (MessageBox.Show("确定提交吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (mode == 0)      //新增PPT
                {
                    PID = InfoControl.OesData.AddOffice(textInfo.Text, unit, plvl, OES.Model.Office.OfficeType.PowerPoint);
                    Net.ClientEvt.FilesComplete += new Action(ClientEvt_FilesComplete);
                    upload(PID);
                }
                else                //修改PPT
                {
                    InfoControl.OesData.UpdateOffice(PID, textInfo.Text, unit, plvl, OES.Model.Office.OfficeType.PowerPoint);
                    InfoControl.ClientObj.DelPowerPointA(PID, InfoControl.User.Id);
                    InfoControl.ClientObj.DelPowerPointP(PID, InfoControl.User.Id);
                    InfoControl.ClientObj.DelPowerPointT(PID, InfoControl.User.Id);
                    InfoControl.ClientObj.DelFiles();
                    Net.ClientEvt.FilesComplete += new Action(ClientEvt_FilesComplete);
                    upload(PID);
                }
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
