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
    public partial class WordFrm : Form
    {
        string ret = "";
        string used_xml_path;       //临时使用的xml文件

        public WordFrm()
        {
            InitializeComponent();
        }

        public string ShowForm()
        {
            this.ShowDialog();
            return ret;
        }

        public void LoadWord(string word_path, string xml_path)
        {
            used_xml_path = xml_path;
            testWord1.LoadWord(word_path, xml_path);
        }

        private void WordFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            testWord1.CloseDocument();
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Xml文件(.xml)|*.xml";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ret = sfd.FileName;
                File.Copy(used_xml_path, ret, true);
                File.Delete(used_xml_path);
                this.Close();
            }
            else if (MessageBox.Show("是否放弃添加？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                File.Delete(used_xml_path);
                this.Close();
            }
        }
        
    }
}
