using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OES.UControl
{
    public partial class CustomProgramInfo : UserControl
    {
        private string path;
        private int type;
        public CustomProgramInfo(int t)
        {
            InitializeComponent();
            type = t;            
            switch (type)
            {
                case 1: 
                    this.Question.Text = ClientControl.paper.pCompletion.problem;
                    break ;
                case 2: 
                    this.Question.Text = ClientControl.paper.pModif.problem;
                    break ;
                case 3: 
                    this.Question.Text = ClientControl.paper.pFunction.problem;
                    break ;
            }
        }

        private void butOpen_Click(object sender, EventArgs e)
        {

        }
    }
}
