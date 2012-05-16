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
        string fName, xName;
        int pos;

        testPowerpoint testPPT = new testPowerpoint();
        testWord testDoc = new testWord();
        testExcel testXls = new testExcel();
        int cas;

        void AllFalse()
        {
            testDoc.Visible = false;
            testXls.Visible = false;
            testPPT.Visible = false;
        }

        public Form1()
        {
            InitializeComponent();
            panel1.Controls.Add(testDoc);
            panel1.Controls.Add(testXls);
            panel1.Controls.Add(testPPT);
            AllFalse();
        }

        private void buttonPPT_Click(object sender, EventArgs e)
        {
            AllFalse();
            cas = 2;
            testPPT.Visible = true;
            fName = textBoxPath.Text;
            pos = fName.LastIndexOf('.');
            xName = fName.Substring(0, pos + 1) + "xml";
            testPPT.LoadPowerpoint(@"F:\点维工作室\OESscore\testAns.ppt",
                @"F:\点维工作室\OESscore\testPpt.xml");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cas == 1)
                testXls.CloseExcel();
            else if (cas == 2)
                testPPT.ClosePPT();
            cas = -1;
            AllFalse();
        }

        private void buttonExcel_Click(object sender, EventArgs e)
        {
            AllFalse();
            cas = 1;
            testXls.Visible = true;
            fName = textBoxPath.Text;
            pos = fName.LastIndexOf('.');
            xName = fName.Substring(0, pos + 1) + "xml";
            testXls.LoadExcel(fName, xName);
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
                textBoxPath.Text = ofd.FileName;
        }
    }
}
