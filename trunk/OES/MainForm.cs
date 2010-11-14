using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OES.UControl;

namespace OES
{
    public partial class MainForm : Form
    {
        static private CustomWord officeWord;
        static private CustomPPT officePpt;
        static private CustomExcel officeExcel;
        static private CustomProgramInfo cCompletion;
        static private CustomJudge judge;
        static private CustomChoice choice;
        static private CustomCompletion completion;

        static public MainForm mf ;

        static private TabPage oficeWordPage;
        static private TabPage oficePptPage;
        static private TabPage oficeExcelPage;
        static private TabPage cCompletionPage;
        static private TabPage judgePage;
        static private TabPage choicePage;
        static private TabPage completionPage;

        static private ProblemsList problemsList;
        public MainForm()
        {
            InitializeComponent();
            //this.FormBorderStyle = FormBorderStyle.None;
        }

        private void addChoicePage()
        {
            choice = new CustomChoice();
            choice.Font = new Font("宋体", 9);
            choicePage = new TabPage("选择题");
            choicePage.Controls.Add(choice);
            tabControl.TabPages.Add(choicePage);
        }

        private void addCompletionPage()
        {
            completion = new CustomCompletion();
            completion.Font = new Font("宋体", 9);
            completionPage = new TabPage("填空题");
            completionPage.Controls.Add(completion);
            tabControl.TabPages.Add(completionPage);
        }

        private void addJudgePage()
        {
            judge = new CustomJudge();
            judge.Font = new Font("宋体", 9);
            judgePage = new TabPage("判断题");
            judgePage.Controls.Add(judge);
            tabControl.TabPages.Add(judgePage);
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
            cCompletion = new CustomProgramInfo("");
            cCompletion.Font = new Font("宋体", 9);
            cCompletionPage = new TabPage("程序填空题");
            cCompletionPage.Controls.Add(cCompletion);
            tabControl.TabPages.Add(cCompletionPage);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ReadTxt.ReadChoice(@"OESTEST\Paper\");
            ReadTxt.ReadCompletion(@"OESTEST\Paper\");
            ReadTxt.ReadJudge(@"OESTEST\Paper\");
            problemsList = new ProblemsList(ClientControl.paper.choice.Count + ClientControl.paper.completion.Count + ClientControl.paper.judge.Count);
            problemsList.count = ClientControl.paper.choice.Count + ClientControl.paper.completion.Count + ClientControl.paper.judge.Count;
            panelProList.Controls.Add(problemsList);
            problemsList.OnChoose += new EventHandler(problemsList_OnChoose);
            addChoicePage();
            addCompletionPage();
            addJudgePage();
            addWordPage();
            addPptPage();
            addExcelPage();
            addCComPage();
            mf = this;
        }

        void problemsList_OnChoose(object sender, EventArgs e)
        {
            ClientControl.JumpToPro((int)sender);
        }

        internal void JumpPro(string tab, int index)
        {
            foreach (TabPage tp in tabControl.TabPages)
            {
                if (tp.Text == tab)
                {
                    tabControl.SelectedTab = tp;
                    switch (tab)
                    {
                        case "选择题":
                            choice.SetQuestion(index);
                            break;
                        case "填空题":
                            completion.SetQuestion(index);
                            break;
                        case "判断题":
                            judge.SetQuestion(index);
                            break;
                        case "编程填空题":
                            
                            break;
                        case "编程综合题":
                            
                            break;
                        case "编程改错题":

                            break;
                        //case "":
                        //    break;
                        //case "":
                        //    break;
                        //case "":
                        //    break;

                    }
                    break;
                }
            }

        }
    }
}
