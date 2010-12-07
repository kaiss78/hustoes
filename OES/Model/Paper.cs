using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OES.XMLFile;

namespace OES.Model
{
    class Paper
    {
        public static string pName = "EXAM001";
        public List<Choice> choice;
        public List<Completion> completion;
        public List<Judge> judge;
        public OfficeWord officeWord;
        public OfficePowerPoint officePPT;
        public OfficeExcel officeExcel;
        public PCompletion pCompletion;
        public PModif pModif;
        public PFunction pFunction;
        public List<Problem> problemList;

        public Paper()
        {
            choice = new List<Choice>();
            completion = new List<Completion>();
            judge = new List<Judge>();
            officeWord = new OfficeWord();
            officePPT = new OfficePowerPoint();
            officeExcel = new OfficeExcel();
            pCompletion = new PCompletion();
            pModif = new PModif();
            pFunction = new PFunction();
            problemList = new List<Problem>();
        }

        public void Resume()
        {
            for (int i = 0; i < choice.Count; i++)
            {
                choice[i].stuAns = XMLControl.FindLog(ProblemType.Choice, i);
                (problemList[choice[i].problemId] as Choice).stuAns = choice[i].stuAns;
            }
            for (int i = 0; i < completion.Count; i++)
            {
                completion[i].stuAns = XMLControl.FindLog(ProblemType.Completion, i);
                (problemList[completion[i].problemId] as Completion).stuAns = completion[i].stuAns;
            }
            for (int i = 0; i < judge.Count; i++)
            {
                judge[i].stuAns = XMLControl.FindLog(ProblemType.Tof, i);
                (problemList[judge[i].problemId] as Judge).stuAns = judge[i].stuAns;
            }
        }
        public void ReadPaper()
        {
            choice = new List<Choice>();
            completion = new List<Completion>();
            judge = new List<Judge>();
            officeWord = new OfficeWord();
            officePPT = new OfficePowerPoint();
            officeExcel = new OfficeExcel();
            pCompletion = new PCompletion();
            pModif = new PModif();
            pFunction = new PFunction();
            problemList = new List<Problem>();
            OES.ReadTxt.ReadPaper(Config.paperPath, ClientControl.MainForm);
        }
        public void Add(Problem p)
        {
            if (p is Choice)
            {
                choice.Add((Choice)p);
            }
            else if (p is Completion)
            {
                completion.Add((Completion)p);
            }
            else if (p is Judge)
            {
                judge.Add((Judge)p);
            }
            else if (p is PCompletion)
            {
                pCompletion = (PCompletion)p;
            }
            else if (p is PModif)
            {
                pModif = (PModif)p;
            }
            else if (p is PFunction)
            {
                pFunction = (PFunction)p;
            }
            else if (p is OfficeExcel)
            {
                officeExcel = (OfficeExcel)p;
            }
            else if (p is OfficePowerPoint)
            {
                officePPT = (OfficePowerPoint)p;
            }
            else if (p is OfficeWord)
            {
                officeWord = (OfficeWord)p;
            }
            p.problemId = problemList.Count;
            problemList.Add(p);
           
        }
    }
}
