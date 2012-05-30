using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    public class Paper
    {
        //试卷名
        public string paperName = "";        
        //创建时间
        public string createTime="";
        //创建者ID
        public int authorId=0;
        //创建者名
        public string author = "";
        //考试时间（没用了)
        public string testTime = "";
        //试卷存放路径（没用了，貌似）
        public string paperPath = "";
        //试卷ID
        public int paperID;
        //各个类型题目的分值
        public int score_choice = 0;
        public int score_completion = 0;
        public int score_judge = 0;
        public int score_officeExcel = 0;
        public int score_officePPT = 0;
        public int score_officeWord = 0;
        public int score_pCompletion = 0;
        public int score_pFunction = 0;
        public int score_pModif = 0;

        //ProgramState:0表示没有编程题；1表示是C语言编程；2表示C++语言编程        
        //题目列表
        public List<Choice> choice;
        public List<Completion> completion;
        public List<Judgment> judge;
        public List<OfficeExcel> officeExcel;
        public List<OfficePowerPoint> officePPT;
        public List<OfficeWord> officeWord;
        public List<ProgramProblem> pCompletion;
        public List<ProgramProblem> pModif;
        public List<ProgramProblem> pFunction;
        public List<Problem> problemList;
       // public List<Problem>[] ProList = new List<Problem>[12];

        /// <summary>
        /// 构造一个空的试卷
        /// 初始化题目列表
        /// </summary>
        public Paper()
        {
            choice = new List<Choice>();
            completion = new List<Completion>();
            judge = new List<Judgment>();
            officeWord = new List<OfficeWord>();
            officePPT = new List<OfficePowerPoint>();
            pCompletion = new List<ProgramProblem>();
            pModif = new List<ProgramProblem>();
            pFunction = new List<ProgramProblem>();
            //problemList = new List<Problem>();
            officeExcel = new List<OfficeExcel>();
            //for (int i = 0; i < 12; i++)
            //{
            //    ProList[i] = new List<Problem>();
            //}
            paperID = -1;
        }
        /// <summary>
        /// 获取题目类型对应的中文名称
        /// </summary>
        /// <param name="pt">题目类型</param>
        /// <returns>中文名称</returns>
        public static string GetPTypeName(ProblemType pt)
        {
            switch (pt)
            {
                case ProblemType.Choice:
                    return "选择题";
                    break;
                case ProblemType.Completion:
                    return "填空题";
                    break;
                case ProblemType.Judgment:
                    return "判断题";
                    break;
                case ProblemType.Word:
                    return "Word题";
                    break;
                case ProblemType.PowerPoint:
                    return "PowerPoint题";
                    break;
                case ProblemType.Excel:
                    return "Excel题";
                    break;
                case ProblemType.CProgramCompletion:
                    return "C程序填空题";
                    break;
                case ProblemType.CProgramModification:
                    return "C程序改错题";
                    break;
                case ProblemType.CProgramFun:
                    return "C程序综合题";
                    break;
                case ProblemType.CppProgramCompletion:
                    return "C++程序填空题";
                    break;
                case ProblemType.CppProgramModification:
                    return "C++程序改错题";
                    break;
                case ProblemType.CppProgramFun:
                    return "C++程序综合题";
                    break;
                case ProblemType.VbProgramCompletion:
                    return "VB程序填空题";
                    break;
                case ProblemType.VbProgramModification:
                    return "VB程序改错题";
                    break;
                case ProblemType.VbProgramFun:
                    return "VB程序综合题";
                    break;


            }
            return "";
        }

        /// <summary>
        /// 往试卷中添加一道题目
        /// </summary>
        /// <param name="p">题目</param>
        public void Add(Problem p)
        {
            if (p is Choice)
            {
                p.orderId = choice.Count;
                choice.Add((Choice) p);
            }
            else if (p is Completion)
            {
                p.orderId = completion.Count;
                completion.Add((Completion) p);
            }
            else if (p is Judgment)
            {
                p.orderId = judge.Count;
                judge.Add((Judgment) p);
            }
            else if (p is PCompletion)
            {
                p.orderId = pCompletion.Count;
                pCompletion.Add((PCompletion) p);
            }
            else if (p is PModif)
            {
                p.orderId = pModif.Count;
                pModif.Add((PModif) p);
            }
            else if (p is PFunction)
            {
                p.orderId = pFunction.Count;
                pFunction.Add((PFunction) p);
            }
            else if (p is OfficeExcel)
            {
                p.orderId = officeExcel.Count;
                officeExcel.Add((OfficeExcel) p);
            }
            else if (p is OfficePowerPoint)
            {
                p.orderId = officePPT.Count;
                officePPT.Add((OfficePowerPoint) p);
            }
            else if (p is OfficeWord)
            {
                p.orderId = officeWord.Count;
                officeWord.Add((OfficeWord) p);
            }
            p.problemId = problemList.Count;

            problemList.Add(p);
        }
    }       

    //题目类型的枚举
    public enum ProblemType
    {
        Choice=0,
        Completion=1,
        Judgment=2,
        Word=3,
        Excel=4,
        PowerPoint=5,
        CProgramCompletion=6,
        CProgramModification=7,
        CProgramFun=8,
        CppProgramCompletion=9,
        CppProgramModification=10,
        CppProgramFun=11,
        VbProgramCompletion=12,
        VbProgramModification=13,
        VbProgramFun=14,
        BaseProgramCompletion=15,
        BaseProgramModification=16,
        BaseProgramFun=17,
        Start,
        Blank
    }

    public class Pid_Ans
    {
        public int id;
        public string ans;
        public Pid_Ans(int i, string s)
        {
            id = i;
            ans = s;
        }
    }
    public class Pid_Score
    {
        public int id;
        public int score;
        public Pid_Score(int i, int s)
        {
            id = i;
            score = s;
        }
    }
}