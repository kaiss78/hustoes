using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OESOffice;

namespace TestOESOffice
{
    public partial class Form1 : Form
    {

        testPowerpoint testPPT = new testPowerpoint();

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonPPT_Click(object sender, EventArgs e)
        {
            panel1.Controls.Add(testPPT);
            testPPT.LoadPowerpoint(@"F:\点维工作室\OESscore\testAns.ppt",
                @"F:\点维工作室\OESscore\testPpt.xml");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ;
        }
    }
}
