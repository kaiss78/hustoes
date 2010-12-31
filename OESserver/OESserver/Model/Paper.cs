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
        //ProgramState:0表示没有编程题；1表示是C语言编程；2表示C++语言编程
        public int programState = 0;
        public List<Choice> choice;
        public List<Completion> completion;
        public List<Judge> judge;
        public OfficeExcel officeExcel;
        public OfficePowerPoint officePPT;
        public OfficeWord officeWord;
        public PCompletion pCompletion;
        public PFunction pFunction;
        public PModif pModif;
        public List<Problem> problemList;        

        public Paper()
        {
            choice = new List<Choice>();
            completion = new List<Completion>();
            judge = new List<Judge>();
            officeWord = new OfficeWord();
            officePPT = new OfficePowerPoint();
            pCompletion = new PCompletion();
            pModif = new PModif();
            pFunction = new PFunction();
            problemList = new List<Problem>();
            officeExcel = new OfficeExcel();
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
            else if (p is Judge)
            {
                judge.Add((Judge) p);
            }
            else if (p is PCompletion)
            {
                pCompletion = (PCompletion) p;
            }
            else if (p is PModif)
            {
                pModif = (PModif) p;
            }
            else if (p is PFunction)
            {
                pFunction = (PFunction) p;
            }
            else if (p is OfficeExcel)
            {
                officeExcel = (OfficeExcel) p;
            }
            else if (p is OfficePowerPoint)
            {
                officePPT = (OfficePowerPoint) p;
            }
            else if (p is OfficeWord)
            {
                officeWord = (OfficeWord) p;
            }
            p.problemId = problemList.Count;
            problemList.Add(p);
        }

        public OESData db = new OESData();

        public void AddPaper()
        {
            db.AddPaper(createTime,testTime,paperPath,paperName,authorId);
        }
        public void DeletePaper()
        {
            db.DeletePaper(paperID);
        }
        public void UpdatePaper()
        {
            db.UpdatePaper(paperID, createTime, testTime, paperPath, paperName, authorId);
        }
        public List<Paper> FindPaper()
        {
            return db.FindPaper();
        }
    }
    public enum ProblemType
    {
        Choice,
        Completion,
        Tof,
        Word,
        Excel,
        PowerPoint,
        ProgramCompletion,
        ProgramModification,
        ProgramFun,
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