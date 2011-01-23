using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OES.UPanel;
using OES.Properties;
using OES.Model;


namespace OES.UControl
{
    public partial class ChoiceEdit : UserControl
    {
        ProMan aProMan;
        public ChoiceEdit(ProMan pm)
        {
            InitializeComponent();
            aProMan = pm;

            A.BackgroundImage = Resources.circle_black;
            A.BackgroundImageLayout = ImageLayout.Stretch;
            B.BackgroundImage = Resources.circle_black;
            B.BackgroundImageLayout = ImageLayout.Stretch;
            C.BackgroundImage = Resources.circle_black;
            C.BackgroundImageLayout = ImageLayout.Stretch;
            D.BackgroundImage = Resources.circle_black;
            D.BackgroundImageLayout = ImageLayout.Stretch;

        }

        
        private void button6_Click(object sender, EventArgs e)
        {
            aProMan.bottomPanel.Show();
            aProMan.titlePanel.Show();
            aProMan.aProList.Show();
            this.Hide();          
        }

        public void fill(List<Choice> achoice)
        {
            procon.Text = achoice[0].problem;
            Atxt.Text = achoice[0].optionA;
            Btxt.Text = achoice[0].optionB;
            Ctxt.Text = achoice[0].optionC;
            Dtxt.Text = achoice[0].optionD;

            switch (achoice[0].ans)
            { 
                case "A":
                    optioncontrol("A");
                    break;
                case "B":
                    optioncontrol("B");
                    break;
                case "C":
                    optioncontrol("C");
                    break;
                case "D":
                    optioncontrol("D");
                    break;
            }
        }

        public void optioncontrol(string s)
        {
            switch (s)
            { 
                case "A":
                    A.BackgroundImage = Resources.circle_red;
                    B.BackgroundImage = Resources.circle_black;
                    C.BackgroundImage = Resources.circle_black;
                    D.BackgroundImage = Resources.circle_black;
                    break;
                case "B":
                    A.BackgroundImage = Resources.circle_black;
                    B.BackgroundImage = Resources.circle_red;
                    C.BackgroundImage = Resources.circle_black;
                    D.BackgroundImage = Resources.circle_black;
                    break;
                case "C":
                    A.BackgroundImage = Resources.circle_black;
                    B.BackgroundImage = Resources.circle_red;
                    C.BackgroundImage = Resources.circle_black;
                    D.BackgroundImage = Resources.circle_black;
                    break;
                case "D":
                    A.BackgroundImage = Resources.circle_black;
                    B.BackgroundImage = Resources.circle_black;
                    C.BackgroundImage = Resources.circle_black;
                    D.BackgroundImage = Resources.circle_red;
                    break;


            }
        }

        private void A_Click(object sender, EventArgs e)
        {
            optioncontrol("A");
        }

        private void B_Click(object sender, EventArgs e)
        {
            optioncontrol("B");
        }

        private void C_Click(object sender, EventArgs e)
        {
            optioncontrol("C");
        }

        private void D_Click(object sender, EventArgs e)
        {
            optioncontrol("D");
        }



    }
}
