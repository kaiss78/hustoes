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
    public partial class CustomProgramInfo : UserControl
    {
        private string path;
        public CustomProgramInfo(string p)
        {
            InitializeComponent();
            path = p;
        }

        private void ProgramInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
