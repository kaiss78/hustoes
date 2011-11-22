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
                List<Judge> list = pXml.GetJudgeProbelms();
                foreach (Judge c in list)
                {
                    ClientControl.paper.Add(c);
                }
                ClientControl.MainForm.addPage(ProblemType.Tof);
            }
        }

        public static void ReadPCompletion(string path)
        {
            pXml = new ProblemXML(path + "h.xml", true);
            if (!pXml.isError)
            {
                PCompletion obj = pXml.GetPCompletionProbelm();

                ClientControl.paper.Add(obj);

                ClientControl.MainForm.addPage(ProblemType.ProgramCompletion);
            }
        }

        public static void ReadPModif(string path)
        {
            pXml = new ProblemXML(path + "g.xml", true);
            if (!pXml.isError)
            {
                PModif obj = pXml.GetPModifProbelm();

                ClientControl.paper.Add(obj);

                ClientControl.MainForm.addPage(ProblemType.ProgramModification);
            }
        }

        public static void ReadPFunction(string path)
        {
            pXml = new ProblemXML(path + "i.xml", true);
            if (!pXml.isError)
            {
                PFunction obj = pXml.GetPFunctionProbelm();

                ClientControl.paper.Add(obj);

                ClientControl.MainForm.addPage(ProblemType.ProgramFun);
            }
        }

        public static void ReadOfficeWord(string path)
        {
            pXml = new ProblemXML(path + "d.xml", true);
            if (!pXml.isError)
            {
                OfficeWord obj = pXml.GetWordProbelm();

                ClientControl.paper.Add(obj);

                ClientControl.MainForm.addPage(ProblemType.Word);
            }
        }

        public static void ReadOfficePPT(string path)
        {
            pXml = new ProblemXML(path + "e.xml", true);
            if (!pXml.isError)
            {
                OfficePowerPoint obj = pXml.GetPowerPointProbelm();

                ClientControl.paper.Add(obj);

                ClientControl.MainForm.addPage(ProblemType.PowerPoint);
            }

        }

        public static void ReadOfficeExcel(string path)
        {
            pXml = new ProblemXML(path + "f.xml", true);
            if (!pXml.isError)
            {
                OfficeExcel obj = pXml.GetExcelProbelm();

                ClientControl.paper.Add(obj);


                ClientControl.MainForm.addPage(ProblemType.Excel);
            }

        }

        public static void ReadPaper(string path)
        {
            ReadXML.ReadChoice(path);
            ReadXML.ReadCompletion(path);
            ReadXML.ReadJudge(path);
            ReadXML.ReadOfficeWord(path);
            ReadXML.ReadOfficePPT(path);
            ReadXML.ReadOfficeExcel(path);
            ReadXML.ReadPModif(path);
            ReadXML.ReadPCompletion(path);
            ReadXML.ReadPFunction(path);
        }
    }
}
