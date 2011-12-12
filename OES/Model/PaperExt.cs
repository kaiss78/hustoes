using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OES.XMLFile;
using OES.DAO;

namespace OES.Model
{
    public static class PaperExt
    {
        public static void Resume(this Paper p)
        {
            for (int i = 0; i < p.choice.Count; i++)
            {
                p.choice[i].stuAns = XMLControl.FindLog(ProblemType.Choice, i);
                (p.problemList[p.choice[i].problemId] as Choice).stuAns = p.choice[i].stuAns;
            }
            for (int i = 0; i < p.completion.Count; i++)
            {
                p.completion[i].stuAns = XMLControl.FindLog(ProblemType.Completion, i);
                (p.problemList[p.completion[i].problemId] as Completion).stuAns = p.completion[i].stuAns;
            }
            for (int i = 0; i < p.judge.Count; i++)
            {
                p.judge[i].stuAns = XMLControl.FindLog(ProblemType.Judgment, i);
                (p.problemList[p.judge[i].problemId] as Judgment).stuAns = p.judge[i].stuAns;
            }
        }

        public static int ResumeSecond(this Paper p)
        {
            return Convert.ToInt32(XMLControl.FindLog(ProblemType.Start, 0));
        }
        public static void ReadPaper(this Paper p)
        {
            p.choice = new List<Choice>();
            p.completion = new List<Completion>();
            p.judge = new List<Judgment>();
            p.officeWord = new List<OfficeWord>();
            p.officePPT = new List<OfficePowerPoint>();
            p.officeExcel = new List<OfficeExcel>();
            p.pCompletion = new List<PCompletion>();
            p.pModif = new List<PModif>();
            p.pFunction = new List<PFunction>();
            p.problemList = new List<Problem>();
            ReadXML.ReadPaper(Config.PaperPath + p.paperID + @"\");
        }
    }
}
