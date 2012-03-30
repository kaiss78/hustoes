using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OESOfficeScore;

namespace TestOESOfficeScore
{
    public partial class MainFrame : Form
    {
        #region Defined Constants
        public const string PptXmlName = @"F:\点维工作室\OESscore\testPpt.xml";
        public const string PptStuName = @"F:\点维工作室\OESscore\testStu.ppt";
        public const string PptAnsName = @"F:\点维工作室\OESscore\testAns.ppt";

        public const string DocXmlName = @"F:\点维工作室\OESscore\testDoc.xml";
        public const string DocStuName = @"F:\点维工作室\OESscore\testStu.doc";
        public const string DocAnsName = @"F:\点维工作室\OESscore\testAns.doc";

        public const string XlsXmlName = @"F:\点维工作室\OESscore\testXls.xml";
        public const string XlsStuName = @"F:\点维工作室\OESscore\testStu.xls";
        public const string XlsAnsName = @"F:\点维工作室\OESscore\testAns.xls";
        #endregion

        public MainFrame()
        {
            InitializeComponent();
        }

        private void btnPPT_Click(object sender, EventArgs e)
        {
            int tp = PowerPointScore.ps.checkPoints(PptStuName, PptAnsName, PptXmlName);
            MessageBox.Show(tp.ToString());
        }

        private void btnXls_Click(object sender, EventArgs e)
        {
            int tp = ExcelScore.es.checkPoints(XlsStuName, XlsAnsName, XlsXmlName);
            MessageBox.Show(tp.ToString());
        }
        
        private void btnWord_Click(object sender, EventArgs e)
        {   
            int tp = WordScore.ws.checkPoints(DocStuName, DocAnsName, DocXmlName);
            MessageBox.Show(tp.ToString());
        }
    }
}
