using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace testWordApp
{
    public partial class Form1 : Form
    {

        testWord testWd = null;

        public Form1()
        {
            InitializeComponent();
            testWd = new testWord();
            this.Controls.Add(testWd);
            testWd.LoadWord(@"F:\点维工作室\OESscore\testAns.doc", @"F:\点维工作室\OESscore\testDoc.xml");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (testWd != null)
                testWd.CloseDocument();
        }
    }
}
