using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OES.OfficeFrm
{
    public partial class ExcelFrm : Form
    {
        public ExcelFrm()
        {
            InitializeComponent();
        }

        public void LoadExcel(string excel_path, string xml_path)
        {
            testExcel1.LoadExcel(excel_path, xml_path);
        }

        private void ExcelFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            testExcel1.CloseExcel();
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
