using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OES.UControl
{
    public partial class ClassFind : UserControl
    {
        public ClassFind()
        {
            InitializeComponent();
            radioByDept.Checked = true;
            textClass.Enabled = false;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void radioByDept_CheckedChanged(object sender, EventArgs e)
        {
            textDept.Enabled = radioByDept.Checked;
        }

        private void radioByClass_CheckedChanged(object sender, EventArgs e)
        {
            textClass.Enabled = radioByClass.Checked;
        }
    }
}
