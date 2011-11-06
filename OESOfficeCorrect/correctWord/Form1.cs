using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace correctWord
{
    public partial class MainFrame : Form
    {

        #region Define Constants
        public const string xmlName = @"F:\点维工作室\OESscore\testDoc.xml";
        public const string stuName = @"F:\点维工作室\OESscore\testStu.doc";
        public const string ansName = @"F:\点维工作室\OESscore\testAns.doc";
        #endregion

        public MainFrame()
        {
            InitializeComponent();
        }

        private void btnCorrect_Click(object sender, EventArgs e)
        {
            correctDocument cd = new correctDocument();
            int totalPoints = cd.checkPoints(stuName, ansName, xmlName);
            MessageBox.Show(totalPoints.ToString());
        }
    }
}
