using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    public class Paper
    {
        public string paperName = "";
        public string paperID="";
        public string createTime="";
        public string authorId="";
        public string author = "";
        public string testTime = "";
        public string paperPath = "";

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
        public int programState = 0;
        public List<Choice> choice;
        public List<Completion> completion;
        public List<Judgment> judge;
        public List<OfficeExcel> officeExcel;
        public List<OfficePowerPoint> officePPT;
        public List<OfficeWord> officeWord;
        public List<PCompletion> pCompletion;
        public List<PFunction> pFunction;
        public List<PModif> pModif;
        public List<Problem> problemList;
        public List<Problem>[] ProList = new List<Problem>[12];

        public Paper()
        {
            choice = new List<Choice>();
            completion = new List<Completion>();
            judge = new List<Judgment>();
            officeWord = new List<OfficeWord>();
            officePPT = new List<OfficePowerPoint>();
            pCompletion = new List<PCompletion>();
            pModif = new List<PModif>();
            pFunction = new List<PFunction>();
            problemList = new List<Problem>();
            officeExcel = new List<OfficeExcel>();
            for (int i = 0; i < 12; i++)
            {
                ProList[i] = new List<Problem>();
            }
            paperID = "-";
        }
            
        public void Add(Problem p)
        {
            if (p is Choice)
            {
                choice.Add((Choice) p);
            }
            else if (p is Completion)
            {
                completion.Add((Completion) p);
            }
            else if (p is Judgment)
            {
                judge.Add((Judgment) p);
            }
            else if (p is PCompletion)
            {
                pCompletion.Add((PCompletion) p);
            }
            else if (p is PModif)
            {
                pModif.Add((PModif) p);
            }
            else if (p is PFunction)
            {
                pFunction.Add((PFunction) p);
            }
            else if (p is OfficeExcel)
            {
                officeExcel.Add((OfficeExcel) p);
            }
            else if (p is OfficePowerPoint)
            {
                officePPT.Add((OfficePowerPoint) p);
            }
            else if (p is OfficeWord)
            {
                officeWord.Add((OfficeWord) p);
            }
            p.problemId = problemList.Count;
            problemList.Add(p);
        }
    }
    public enum ProblemType
    {
        Choice,
        Completion,
        Judgment,
        Word,
        Excel,
        PowerPoint,
        CProgramCompletion,
        CProgramModification,
        CProgramFun,
        CppProgramCompletion,
        CppProgramModification,
        CppProgramFun,
        VbProgramCompletion,
        VbProgramModification,
        VbProgramFun,
        BaseProgramCompletion,
        BaseProgramModification,
        BaseProgramFun,
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