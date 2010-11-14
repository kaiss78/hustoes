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
    public partial class CustomCompletion : UserControl
    {
      //  ReadProblemFile readproblemfile = new ReadProblemFile();
        string [] readstring=new string[200];
        int i = 0;
        public CustomCompletion()
        {
            InitializeComponent();
            ReadProblemFile readproblemfile = new ReadProblemFile();
            readproblemfile.readfile(readstring);
        }

        private void myusercotroll_Load(object sender, EventArgs e)
        {
            Rquest.Text = readstring[i];
            RquestTeam.Text = readstring[i + 1];
            i += 2;
        }

        private void lastproblem_Click(object sender, EventArgs e)
        {
            i -= 4;
            if (i >= 0)
            {
                Rquest.Text = readstring[i];
                RquestTeam.Text = readstring[i + 1];
                Answer_richbox.Text=" ";
                i += 2;
            }
            else
            {
                MessageBox.Show("前面没有填空题了");
                i += 4;
            }

        }

        private void nextproblem_Click(object sender, EventArgs e)
        {
            if (readstring[i] == null)
            {
                MessageBox.Show("后面没有填空题了，可以做其他题目");
            }
            else
            {
                Rquest.Text = readstring[i];
                RquestTeam.Text=readstring[i-1];
                Answer_richbox.Text = " ";
                i += 2;
            }
        }
    }
}
