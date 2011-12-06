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
            tbAnswerFile.Text = "";
            tbProblemFile.Text = "";
            lbAnsList.Items.Clear();
            this.Visible = true;
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
                ansList = InfoControl.getAnswer(tbAnswerFile.Text);
                for (int i = 0; i < ansList.Count; i++)
                {
                    lbAnsList.Items.Add(ansList[i]);
                }

            }
        }
    }
}
