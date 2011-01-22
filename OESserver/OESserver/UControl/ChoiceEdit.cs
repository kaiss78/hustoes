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
            aProMan.aProList.Show();
            this.Hide();          
        }
    }
}
