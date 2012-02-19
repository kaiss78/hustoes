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
    public partial class AddPowerpoint : UserPanel
    {
        int mode = 0;           //新增或修改 分别为0和1
        FileInfo fori, fans, fxml;
        string tmpDir;

        public AddPowerpoint()
        {
            InitializeComponent();
            tmpDir = InfoControl.config["PPTPath"];
        }

        public override void ReLoad()
        {
            this.Visible = true;
            //textOriPPT.Text = "";
            //textAnsPPT.Text = "";
            textInfo.Text = "";
        }

        public void SetMode(int md)
        {
            mode = md;
        }

        private void reset()
        {
            textInfo.Text = textOriPPT.Text = textAnsPPT.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
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

        private void buttonTestPoint_Click(object sender, EventArgs e)
        {
            if (File.Exists(textOriPPT.Text) && File.Exists(textAnsPPT.Text))
            {
                OfficeFrm.PptForm pf = new OES.OfficeFrm.PptForm();
                FileInfo f = new FileInfo(textOriPPT.Text);
                string xml_path = f.DirectoryName + "\\!Mask!" + f.Name + ".xml";
                buttonTestPoint.Text = "正在打开添加考点界面，请耐心等待...";
                buttonTestPoint.Enabled = false;
                pf.LoadPPT(textOriPPT.Text, xml_path);
                pf.ShowDialog();
                buttonTestPoint.Enabled = true;
                buttonTestPoint.Text = "点此添加考点";
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
            string xml_path = fori.DirectoryName + "\\!Mask!" + fori.Name + ".xml";
            fxml = new FileInfo(xml_path);
            if (!fori.Exists) return -1;
            if (!fans.Exists) return -2;
            if (!fxml.Exists) return -3;
            return 0;
        }

        private void upload(int pid)
        {
            fori.CopyTo(tmpDir + "p" + pid.ToString() + ".ppt");
            fans.CopyTo(tmpDir + "a" + pid.ToString() + ".ppt");
            fxml.CopyTo(tmpDir + "t" + pid.ToString() + ".xml");
            InfoControl.ClientObj.SavePowerPointA(pid, InfoControl.User.Id);
            InfoControl.ClientObj.SavePowerPointP(pid, InfoControl.User.Id);
            InfoControl.ClientObj.SavePowerPointT(pid, InfoControl.User.Id);
            InfoControl.ClientObj.SendFiles();
            while (!OES.Net.ClientEvt.isOver) ;
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
            if (mode == 0)      //新增PPT
            {
                int judge = judgeFileExist();
                if (judge == -1)
                    MessageBox.Show("初始PPT文件不存在！");
                else if (judge == -2)
                    MessageBox.Show("标答PPT文件不存在！");
                else if (judge == -3)
                    MessageBox.Show("考点xml文件不存在！");
                else if (MessageBox.Show("确定提交吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int PID = InfoControl.OesData.AddOffice(textInfo.Text, unit, plvl, OES.Model.Office.OfficeType.PowerPoint);
                    upload(PID);
                    MessageBox.Show("保存成功");
                    ReLoad();
                }
            }
            else                //修改PPT
            {
                        
            }
        }
    }
}
