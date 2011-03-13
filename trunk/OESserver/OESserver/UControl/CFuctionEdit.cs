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
    public partial class CFuctionEdit : UserControl
    {
        ProMan aProMan;
        public bool isnew = false;
        public CFuctionEdit(ProMan pm)
        {
            InitializeComponent();
            aProMan = pm;
        }

        public void fill(List<PFunction> aPFunction)
        {
            procon.Text = aPFunction[0].problem;
            propath.Text = aPFunction[0].path;
            anspath.Text = aPFunction[0].correctC;
            in1.Text = aPFunction[0].inp1;
            in2.Text = aPFunction[0].inp2;
            in3.Text = aPFunction[0].inp3;
            out1.Text = aPFunction[0].outp1;
            out2.Text = aPFunction[0].outp2;
            out3.Text = aPFunction[0].outp3;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                anspath.Text=(openFileDialog2.FileName);
            }
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
                InfoControl.OesData.UpdateFunProgram(ProList.click_proid, procon.Text, propath.Text, in1.Text, in2.Text, in3.Text, out1.Text, out2.Text, out3.Text, anspath.Text, "1");
            }
            else
            {
                InfoControl.OesData.AddFunProgram(procon.Text, propath.Text, in1.Text, in2.Text, in3.Text, out1.Text, out2.Text, out3.Text, anspath.Text, "1");
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
