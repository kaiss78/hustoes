using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace testPowerPoint
{
    public partial class Form1 : Form
    {
        
        testPowerpoint testPPT = null;

        public Form1()
        {
            InitializeComponent();
            testPPT = new testPowerpoint();
            this.Controls.Add(testPPT);
            testPPT.LoadPowerpoint(@"F:\点维工作室\OESscore\testAns.ppt", @"F:\点维工作室\OESscore\testPpt.xml");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (testPPT != null)
                testPPT.ClosePPT();
        }

    }

}
