using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OES.UPanel;
using OES.Model;

namespace OES.UControl
{
    public partial class CppModifEdit : UserControl
    {
        ProMan aProMan;
        public bool isnew = false;
        public CppModifEdit(ProMan pm)
        {
            InitializeComponent();
            aProMan = pm;
        }

        public void fill(List<PModif> aPModif)
        {
            procon.Text = aPModif[0].problem;
            propath.Text = aPModif[0].path;
            anscon1.Text = aPModif[0].ans1;
            anscon2.Text = aPModif[0].ans2;
            anscon3.Text = aPModif[0].ans3;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                propath.Text=(openFileDialog1.FileName);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!isnew)
            {
                InfoControl.OesData.UpdateCompletionModificationProgram(ProList.click_proid, "2", procon.Text, propath.Text, anscon1.Text, anscon2.Text, anscon3.Text, "0");
            }
            else
            {
                InfoControl.OesData.AddCompletionModificationProgram("2", procon.Text, propath.Text, anscon1.Text, anscon2.Text, anscon3.Text, "0");
            }

            MessageBox.Show("保存成功！");
            aProMan.bottomPanel.Show();
            aProMan.titlePanel.Show();
            this.Hide();
            ProMan.isediting = false;
            aProMan.aChptList.newpl();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            aProMan.bottomPanel.Show();
            aProMan.titlePanel.Show();
            aProMan.aProList.Show();
            this.Hide();
            ProMan.isediting = false;
        }
    }
}
