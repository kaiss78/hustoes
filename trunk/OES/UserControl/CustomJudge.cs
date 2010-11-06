using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OES
{
    public partial class CustomJudge : UserControl
    {
        string[] readstring = new string[200];
        int i = 0;
        public CustomJudge()
        {
            InitializeComponent();
            ReadProblemFile readproblemfile = new ReadProblemFile();
            readproblemfile.readfile(readstring);
        }

        private void MyUserControl_Load(object sender, EventArgs e)
        {
            Request.Text=readstring[i];
            RequestTeam.Text = readstring[i + 1];
            i += 2;
        }

        private void LastProblem_Click(object sender, EventArgs e)
        {
            i -= 4;
            if (i >= 0)
            {
                Request.Text = readstring[i];
                RequestTeam.Text = readstring[i + 1];
                i += 2;
            }
            else {
                MessageBox.Show("前面没有判断题了");
                i += 4;
            }

        }

        private void NestProblem_Click(object sender, EventArgs e)
        {
            if (readstring[i] == null)
            { MessageBox.Show("后面没有判断题了，可以做其他题目"); }
            else
            {
                Request.Text=readstring[i];
                RequestTeam.Text=readstring[i+1];
                i += 2;
            }
        }
          
        
    }
}
