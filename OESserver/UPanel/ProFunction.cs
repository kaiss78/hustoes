using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OES.UPanel
{
    public partial class ProFunction : UserPanel
    {
        public ProFunction()
        {
            InitializeComponent();
        }

        private void ProFunction_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnBrowser1_Click(object sender, EventArgs e)
        {
            if (ofdBrowser.ShowDialog() == DialogResult.OK)
            {
                tbProblemFile.Text = ofdBrowser.FileName;
            }
        }

        private void btnBrowser2_Click(object sender, EventArgs e)
        {
            if (ofdBrowser.ShowDialog() == DialogResult.OK)
            {
                tbAnswerFile.Text = ofdBrowser.FileName;
            }
        }
    }
}
