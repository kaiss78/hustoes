using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using OESXML;

namespace correctPowerPoint
{
    public partial class MainFrame : Form
    {
        #region Define Constants
        public const string xmlName = @"F:\点维工作室\OESscore\testPpt.xml";
        public const string stuName = @"F:\点维工作室\OESscore\testStu.ppt";
        public const string ansName = @"F:\点维工作室\OESscore\testAns.ppt";
        #endregion

        public MainFrame()
        {
            InitializeComponent();
        }

        private void btnCorrect_Click(object sender, EventArgs e)
        {
            correctPowerpoint cp = new correctPowerpoint();
            int totalPoints = cp.checkPoints(stuName, ansName, xmlName);
            MessageBox.Show(totalPoints.ToString());
        }
    }
}
