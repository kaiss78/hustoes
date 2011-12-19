using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OES.Model;
using System.IO;
using OESXML;

namespace OES.DAO
{
    public class ReadXML
    {
        private static ProblemXML pXml;
        public static void ReadChoice(string path)
        {
            pXml = new ProblemXML(path + "a.xml", true);
            if (!pXml.isError)
            {
                List<Choice> list = pXml.GetChoiceProbelms();
                foreach (Choice c in list)
                {
                    ClientControl.paper.Add(c);
                }
                ClientControl.MainForm.addPage(ProblemType.Choice);
            }
        }

        public static void ReadCompletion(string path)
        {
            pXml = new ProblemXML(path + "b.xml", true);
            if (!pXml.isError)
            {
                List<Completion> list = pXml.GetCompletionProbelms();
                foreach (Completion c in list)
                {
                    ClientControl.paper.Add(c);
                }
                ClientControl.MainForm.addPage(ProblemType.Completion);
            }
        }

        public static void ReadJudge(string path)
        {
            pXml = new ProblemXML(path + "c.xml", true);
            if (!pXml.isError)
            {
                List<Judgment> list = pXml.GetJudgeProbelms();
                foreach (Judgment c in list)
                {
                    ClientControl.paper.Add(c);
                }
                ClientControl.MainForm.addPage(ProblemType.Judgment);
            }
        }

        public static void ReadPCompletion(string path)
        {
            pXml = new ProblemXML(path + "g.xml", true);
            if (!pXml.isError)
            {
                List<PCompletion> list = pXml.GetPCompletionProbelm();
                foreach (PCompletion c in list)
                {
                    ClientControl.paper.Add(c);
                }
                ClientControl.MainForm.addPage(ProblemType.BaseProgramCompletion);
            }
        }

        public static void ReadPModif(string path)
        {
            pXml = new ProblemXML(path + "h.xml", true);
            if (!pXml.isError)
            {
                List<PModif> list = pXml.GetPModifProbelm();
                foreach (PModif c in list)
                {
                    ClientControl.paper.Add(c);
                }
                ClientControl.MainForm.addPage(ProblemType.BaseProgramModification);
            }
        }

        public static void ReadPFunction(string path)
        {
            pXml = new ProblemXML(path + "i.xml", true);
            if (!pXml.isError)
            {
                List<PFunction> list = pXml.GetPFunctionProbelm();
                foreach (PFunction c in list)
                {
                    ClientControl.paper.Add(c);
                }
                ClientControl.MainForm.addPage(ProblemType.BaseProgramFun);
            }
        }

        public static void ReadOfficeWord(string path)
        {
            pXml = new ProblemXML(path + "d.xml", true);
            if (!pXml.isError)
            {
                List<OfficeWord> list = pXml.GetWordProbelm();
                foreach (OfficeWord c in list)
                {
                    ClientControl.paper.Add(c);
                }
                ClientControl.MainForm.addPage(ProblemType.Word);
            }
        }

        public static void ReadOfficeExcel(string path)
        {
            pXml = new ProblemXML(path + "e.xml", true);
            if (!pXml.isError)
            {
                List<OfficeExcel> list = pXml.GetExcelProbelm();
                foreach (OfficeExcel c in list)
                {
                    ClientControl.paper.Add(c);
                }
                ClientControl.MainForm.addPage(ProblemType.Excel);
            }

        }

        public static void ReadOfficePPT(string path)
        {
            pXml = new ProblemXML(path + "f.xml", true);
            if (!pXml.isError)
            {
                List<OfficePowerPoint> list = pXml.GetPowerPointProbelm();
                foreach (OfficePowerPoint c in list)
                {
                    ClientControl.paper.Add(c);
                }
                ClientControl.MainForm.addPage(ProblemType.PowerPoint);
            }

        }

        public static void ReadPaper(string path)
        {
            ReadXML.ReadChoice(path);
            ReadXML.ReadCompletion(path);
            ReadXML.ReadJudge(path);
            ReadXML.ReadOfficeWord(path);
            ReadXML.ReadOfficeExcel(path);
            ReadXML.ReadOfficePPT(path);
            ReadXML.ReadPCompletion(path);
            ReadXML.ReadPModif(path);
            ReadXML.ReadPFunction(path);
        }
    }
}
