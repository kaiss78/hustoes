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
    public partial class OfficePowerpointEdit : UserControl
    {
        ProMan aProMan;
        public bool isnew = false;
        public OfficePowerpointEdit(ProMan pm)
        {
            InitializeComponent();
            aProMan = pm;
        }

        public void fill(List<OfficePowerPoint> aOfficePowerPoint)
        {
            procon.Text = aOfficePowerPoint[0].problem;
            propath.Text = aOfficePowerPoint[0].rawPath;
            anspath.Text = aOfficePowerPoint[0].ansPath;
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
                InfoControl.OesData.UpdateOffice(ProList.click_proid, procon.Text, anspath.Text, propath.Text, "3");
            }
            else
            {
                InfoControl.OesData.AddOffice(procon.Text, anspath.Text, propath.Text, "3");
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
