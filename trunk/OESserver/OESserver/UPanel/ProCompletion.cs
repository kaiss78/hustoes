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
    public partial class ProCompletion : UserPanel
    {
        static List<string> ansList;

        public ProCompletion()
        {
            InitializeComponent();
        }

        public override void ReLoad()
        {
            rtbPContent.Text = "";            
            tbProblemFile.Text = "";
            
            this.Visible = true;
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            if (ofdBrowser.ShowDialog() == DialogResult.OK)
            {
                tbProblemFile.Text = ofdBrowser.FileName;
            }
        }
    }
}
