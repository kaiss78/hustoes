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
    public partial class ExcelFrm : Form
    {
        string ret = "";
        string used_xml_path;       //临时使用的xml文件

        public ExcelFrm()
        {
            InitializeComponent();
        }

        public string ShowForm()    //外部调用的显示对话框
        {
            this.ShowDialog();
            return ret;
        }

        public void LoadExcel(string excel_path, string xml_path)
        {
            used_xml_path = xml_path;
            testExcel1.LoadExcel(excel_path, xml_path);
        }

        private void ExcelFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (File.Exists(used_xml_path))
                File.Delete(used_xml_path);
            testExcel1.CloseExcel();
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
