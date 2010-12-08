using System.Collections.Generic;

namespace OES.Model
{
    internal class Paper
    {
        public static string pName = "EXAM001";
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
            officeExcel = new OfficeExcel();
            pCompletion = new PCompletion();
            pModif = new PModif();
            pFunction = new PFunction();
            problemList = new List<Problem>();
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
    }
}