using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
 
using System.Text;
using System.Windows.Forms;
using OES.UControl;
using OES.XMLFile;
using OES.Model;

namespace OES
{
    public partial class MainForm : Form
    {

        static public bool wordExists = false;
        static public bool pptExists = false;
        static public bool excelExists = false;
        static public bool pCompletionExists = false;
        static public bool pModifExists = false;
        static public bool pFunctionExists = false;
        static public bool choiceExists = false;
        static public bool judgeExists = false;
        static public bool completionExists = false;

        static private CustomWord officeWord;
        static private CustomPPT officePpt;
        static private CustomExcel officeExcel;
        static private CustomProgramInfo pCompletion;
        static private CustomProgramInfo pModif;
        static private CustomProgramInfo pFunction;
        static private CustomJudge judge;
        static private CustomChoice choice;
        static private CustomCompletion completion;

        private List<ProblemTabPage> tabList = new List<ProblemTabPage>();
        

        static public ProblemsList problemsList;
        public MainForm()
        {
            InitializeComponent();
            //this.FormBorderStyle = FormBorderStyle.None;
        }

        public void addPage(ProblemType pt)
        {
            ProblemTabPage temp;
            switch (pt)
            {
                case ProblemType.Choice:
                    choice = new CustomChoice();
                    choice.Font = new Font("宋体", 9);
                    temp = new ProblemTabPage("选择题");
                    temp.Controls.Add(choice);       
                    break;
                case ProblemType.Completion:
                    completion = new CustomCompletion();
                    completion.Font = new Font("宋体", 9);
                    temp = new ProblemTabPage("填空题");
                    temp.Controls.Add(completion);
                    break;
                case ProblemType.Tof:
                    judge = new CustomJudge();
                        judge.Font = new Font("宋体", 9);
                        temp = new ProblemTabPage("判断题");
                        temp.Controls.Add(judge);             
                    break;
                case ProblemType.Word:
                    officeWord = new CustomWord();
                    officeWord.Font = new Font("宋体", 9);
                    temp = new ProblemTabPage("Word操作题");
                    temp.Controls.Add(officeWord);
                    break;
                case ProblemType.Excel:
                    officeExcel = new CustomExcel();
                    officeExcel.Font = new Font("宋体", 9);
                    temp = new ProblemTabPage("Excel操作题");
                    temp.Controls.Add(officeExcel);         
                    break;
                case ProblemType.PowerPoint:
                    officePpt = new CustomPPT();
                    officePpt.Font = new Font("宋体", 9);
                    temp = new ProblemTabPage("PowerPoint操作题");
                    temp.Controls.Add(officePpt);
                    break;
                case ProblemType.CProgramCompletion:
                case ProblemType.CppProgramCompletion:
                case ProblemType.VbProgramCompletion:
                    pCompletion = new CustomProgramInfo(pt);
                    pCompletion.Font = new Font("宋体", 9);
                    temp = new ProblemTabPage("程序填空题");
                    temp.Controls.Add(pCompletion);
                    break;
                case ProblemType.CProgramModification:
                case ProblemType.CppProgramModification:
                case ProblemType.VbProgramModification:
                    pModif = new CustomProgramInfo(pt);
                    pModif.Font = new Font("宋体", 9);
                    temp = new ProblemTabPage("程序改错题");
                    temp.Controls.Add(pModif);
                    break;
                case ProblemType.CProgramFun:
                case ProblemType.CppProgramFun:
                case ProblemType.VbProgramFun:
                    pFunction = new CustomProgramInfo(pt);
                    pFunction.Font = new Font("宋体", 9);
                    temp = new ProblemTabPage("程序综合题");
                    temp.Controls.Add(pFunction);
                    break;
                default:
                    temp = new ProblemTabPage("未知题型");
                    break;
            }
            temp.type = pt;
            tabControl.TabPages.Add(temp);
            tabList.Add(temp);
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
          

            //这里初始化右边的问题列表
            //构造函数里面的值是列表的题目数量
            problemsList = new ProblemsList(ClientControl.paper.problemList.Count);
            panelProList.Controls.Add(problemsList);
            //为问题列表添加选中事件，事件函数为problemsList_OnChoose
            problemsList.OnChoose += new EventHandler(problemsList_OnChoose);

            //this.addChoicePage();

            tabControl.SelectedIndexChanged += new EventHandler(tabControl_SelectedIndexChanged);
            tabControl_SelectedIndexChanged(tabControl, null);
        }

        void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (((ProblemTabPage)((TabControl)sender).SelectedTab).type)
            {
                case ProblemType.Choice:
                    ClientControl.CurrentProblemNum = ClientControl.paper.choice[choice.GetQuestion()].problemId;
                    break;
                case ProblemType.Completion:
                    ClientControl.CurrentProblemNum = ClientControl.paper.completion[completion.GetQuestion()].problemId;
                    break;
                case ProblemType.Tof:
                    ClientControl.CurrentProblemNum = ClientControl.paper.judge[judge.GetQuestion()].problemId;
                    break;
                case ProblemType.CProgramCompletion:
                case ProblemType.CppProgramCompletion:
                case ProblemType.VbProgramCompletion:
                    ClientControl.CurrentProblemNum = ClientControl.paper.pCompletion[pCompletion.GetQuestion()].problemId;
                    break;
                case ProblemType.CProgramModification:
                case ProblemType.CppProgramModification:
                case ProblemType.VbProgramModification:
                    ClientControl.CurrentProblemNum = ClientControl.paper.pModif[pModif.GetQuestion()].problemId;
                    break;
                case ProblemType.CProgramFun:
                case ProblemType.CppProgramFun:
                case ProblemType.VbProgramFun:
                    ClientControl.CurrentProblemNum = ClientControl.paper.pFunction[pFunction.GetQuestion()].problemId;
                    break;
                
                case ProblemType.Word:
                    ClientControl.CurrentProblemNum = ClientControl.paper.officeWord[officeWord.GetQuestion()].problemId;
                    break;
                case ProblemType.PowerPoint:
                    ClientControl.CurrentProblemNum = ClientControl.paper.officePPT[officePpt.GetQuestion()].problemId;
                    break;
                case ProblemType.Excel:
                    ClientControl.CurrentProblemNum = ClientControl.paper.officeExcel[officeExcel.GetQuestion()].problemId;
                    break;

            }
        }

        //这里就是问题列表选中时触发的事件
        void problemsList_OnChoose(object sender, EventArgs e)
        {
            //主要是将选中的题目号传到总控类
            ClientControl.JumpToPro((int)sender);
        }

        internal void JumpPro(ProblemType tab, int index)
        {
            foreach (ProblemTabPage tp in tabControl.TabPages)
            {
                if (tp.type == tab)
                {
                    tabControl.SelectedIndexChanged -= tabControl_SelectedIndexChanged;
                    tabControl.SelectedTab = tp;
                    tabControl.SelectedIndexChanged += tabControl_SelectedIndexChanged;
                    switch (tab)
                    {
                        case ProblemType.Choice:
                            choice.SetQuestion(index);
                            break;
                        case ProblemType.Completion:
                            completion.SetQuestion(index);
                            break;
                        case ProblemType.Tof:
                            judge.SetQuestion(index);
                            break;
                        case ProblemType.CProgramCompletion:
                        case ProblemType.CppProgramCompletion:
                        case ProblemType.VbProgramCompletion:
                            pCompletion.SetQuestion(index);
                            break;
                        case ProblemType.CProgramModification:
                        case ProblemType.CppProgramModification:
                        case ProblemType.VbProgramModification:
                            pModif.SetQuestion(index);
                            break;
                        case ProblemType.CProgramFun:
                        case ProblemType.CppProgramFun:
                        case ProblemType.VbProgramFun:
                            pFunction.SetQuestion(index);
                            break;
                        case ProblemType.Word:
                            officeWord.SetQuestion(index);
                            break;
                        case ProblemType.PowerPoint:
                            officePpt.SetQuestion(index);
                            break;
                        case ProblemType.Excel:
                            officeExcel.SetQuestion(index);
                            break;
                    }
                    break;
                }
            }

        }
    }
}
