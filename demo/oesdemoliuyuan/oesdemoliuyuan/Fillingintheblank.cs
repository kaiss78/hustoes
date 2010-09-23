using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace oesdemoliuyuan
{   
    public partial class Fillingintheblank : UserControl
    {
        ReadEMFile reademfile;
        string [] readstring;
        public Fillingintheblank()
        {
            InitializeComponent();
            ReadEMFile reademfile = new ReadEMFile();
            readstring=reademfile.read();
        }

        private void radioButtonA_CheckedChanged(object sender, EventArgs e)
        {
            radioButtonA.Text = "readstring[2]";
        }

        private void radioButtonB_CheckedChanged(object sender, EventArgs e)
        {
            radioButtonB.Text = "readstring[3]";
        }

        private void radioButtonC_CheckedChanged(object sender, EventArgs e)
        {
            radioButtonC.Text = "readstring[4]";
        }

        private void radioButtonD_CheckedChanged(object sender, EventArgs e)
        {
            radioButtonD.Text = "readstring[5]";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Text="readstring[0]";
        }

        private void EMcontest_SelectedIndexChanged(object sender, EventArgs e)
        {
            EMcontest.Text = "readstring[1]";
        }

        
    }
   
}
