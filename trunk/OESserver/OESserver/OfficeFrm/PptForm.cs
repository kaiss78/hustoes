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
    public partial class PptForm : Form
    {
        public PptForm()
        {
            InitializeComponent();
        }

        public void LoadPPT(string ppt_path, string xml_path)
        {
            testPowerpoint1.LoadPowerpoint(ppt_path, xml_path);
        }

        private void PptForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            testPowerpoint1.ClosePPT();
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
