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
using OES.Properties;

namespace OES.UControl
{
    public partial class JudgeEdit : UserControl
    {
        ProMan aProMan;
        public bool isnew;
        private string answer;
        public JudgeEdit(ProMan pm)
        {
            InitializeComponent();
            aProMan = pm;

            yes.BackgroundImage = Resources.circle_black;
            yes.BackgroundImageLayout = ImageLayout.Stretch;
            no.BackgroundImage = Resources.circle_black;
            no.BackgroundImageLayout = ImageLayout.Stretch;
        }
        public void fill(List<Judge> aJudge)
        {
            chptlbl.Text = ChptList.click_name;
            procon.Text = aJudge[0].problem;
            optioncontrol(aJudge[0].ans);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            aProMan.bottomPanel.Show();
            aProMan.titlePanel.Show();
            aProMan.aProList.Show();
            this.Hide();
            ProMan.isediting = false;
        }

        public void optioncontrol(string s)
        {
            if (s=="T")
            {
                yes.BackgroundImage = Resources.circle_red;
                no.BackgroundImage = Resources.circle_black;
                answer = "T";
            }
            else if(s=="F")
            {
                yes.BackgroundImage = Resources.circle_black;
                no.BackgroundImage = Resources.circle_red;
                answer = "F";
            }
        }

        private void yes_Click(object sender, EventArgs e)
        {
            optioncontrol("T");
        }

        private void no_Click(object sender, EventArgs e)
        {
            optioncontrol("F");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!isnew)
            {
                InfoControl.OesData.UpdateTof(ProList.click_proid, procon.Text, Convert.ToInt32(ChptList.click_num), answer);
            }
            else
            {
                InfoControl.OesData.AddTof(procon.Text, answer, Convert.ToInt32(ChptList.click_num));
            }
            
            MessageBox.Show("保存成功！");
            aProMan.bottomPanel.Show();
            aProMan.titlePanel.Show();
            this.Hide();
            ProMan.isediting = false;
            aProMan.aChptList.newpl();
        }
    }
}
