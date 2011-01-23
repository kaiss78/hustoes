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
            procon.Text = aJudge[0].problem;
            //optioncontrol(aJudge[0].ans);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            aProMan.bottomPanel.Show();
            aProMan.aProList.Show();
            this.Hide(); 
        }

        public void optioncontrol(bool s)
        {
            if (s)
            {
                yes.BackgroundImage = Resources.circle_red;
                no.BackgroundImage = Resources.circle_black;
            }
            else
            {
                yes.BackgroundImage = Resources.circle_black;
                no.BackgroundImage = Resources.circle_red;
            }
        }
    }
}
