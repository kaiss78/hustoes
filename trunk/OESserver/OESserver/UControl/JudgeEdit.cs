using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OES.UPanel;

namespace OES.UControl
{
    public partial class JudgeEdit : UserControl
    {
        ProMan aProMan;
        public JudgeEdit(ProMan pm)
        {
            InitializeComponent();
            aProMan = pm;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            aProMan.bottomPanel.Show();
            aProMan.aProList.Show();
            this.Hide(); 
        }
    }
}
