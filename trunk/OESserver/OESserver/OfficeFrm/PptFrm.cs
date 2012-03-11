using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace OES.OfficeFrm
{
    public partial class PptFrm : Form
    {
        string ret = "";
        string used_xml_path;       //临时使用的xml文件

        public PptFrm()
        {
            InitializeComponent();
        }

        public string ShowForm()    //外部调用的显示对话框
        {
            this.ShowDialog();
            return ret;
        }

        public void LoadPPT(string ppt_path, string xml_path)
        {
            used_xml_path = xml_path;
            testPowerpoint1.LoadPowerpoint(ppt_path, xml_path);
        }

        private void PptForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (File.Exists(used_xml_path))
                File.Delete(used_xml_path);
            testPowerpoint1.ClosePPT();
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Xml文档(*.xml)|*.xml";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ret = sfd.FileName;
                File.Copy(used_xml_path, ret, true);
                File.Delete(used_xml_path);
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否放弃添加？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ret = "";
                File.Delete(used_xml_path);
                this.Close();
            }
        }
    }
}
