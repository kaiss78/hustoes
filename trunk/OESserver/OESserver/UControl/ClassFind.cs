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
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

      
        private void btnFind_Click(object sender, EventArgs e)
        {

        }
    }
}
