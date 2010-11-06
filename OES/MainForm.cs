using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CProblem;
using Office;

namespace OES
{
    public partial class MainForm : Form
    {
        static private CustomWord officeWord;
        static private CustomPPT officePpt;
        static private CustomExcel officeExcel;
        static private CustomProgramInfo cCompletion;

        static private TabPage oficeWordPage;        
        static private TabPage oficePptPage;
        static private TabPage oficeExcelPage;
        static private TabPage cCompletionPage;

        public MainForm()
        {
            InitializeComponent();
        }

        private void addWordPage()
        {
            officeWord = new CustomWord();
            officeWord.Font = new Font("宋体", 9);
            oficeWordPage = new TabPage("Word操作题");
            oficeWordPage.Controls.Add(officeWord);
            tabControl.TabPages.Add(oficeWordPage);
        }

        private void addPptPage()
        {
            officePpt = new CustomPPT();
            officePpt.Font = new Font("宋体", 9);
            oficePptPage = new TabPage("PowerPoint操作题");
            oficePptPage.Controls.Add(officePpt);
            tabControl.TabPages.Add(oficePptPage);
        }

        private void addExcelPage()
        {
            officeExcel = new CustomExcel();
            officeExcel.Font = new Font("宋体", 9);
            oficeExcelPage = new TabPage("Excel操作题");
            oficeExcelPage.Controls.Add(officeExcel);
            tabControl.TabPages.Add(oficeExcelPage);
        }

        private void addCComPage()
        {
            cCompletion = new CustomProgramInfo();
            cCompletion.Font = new Font("宋体", 9);
            cCompletionPage = new TabPage("程序填空题");
            cCompletionPage.Controls.Add(cCompletion);
            tabControl.TabPages.Add(cCompletionPage);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            addWordPage();
            addPptPage();
            addExcelPage();
            addCComPage();
        }
    }
}
