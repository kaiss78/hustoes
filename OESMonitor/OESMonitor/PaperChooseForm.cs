using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OESMonitor.Net;
using System.Threading;

namespace OESMonitor
{
    public partial class PaperChooseForm : Form
    {
        public PaperChooseForm()
        {
            InitializeComponent();
            paperListPanel1.parent = this;

        }

        private void PaperChooseForm_Load(object sender, EventArgs e)
        {

        }
    }
}
