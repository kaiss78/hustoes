using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OES.Model;
using OES.XMLFile;
using System.IO;
using OESXML;

namespace OESSupport.PaperControl
{
    public class XMLtoXML
    {
        static public List<IdScoreType> problemList = new List<IdScoreType>();
        private static string paperid;

        static private ProblemXML pXml;

        static public List<Choice> choiceList = new List<Choice>();
        static public List<Completion> completionList = new List<Completion>();
        static public List<Judge> judgeList = new List<Judge>();

        static public OfficeExcel officeexcel = null;
        static public OfficePowerPoint officeppt = null;
        static public OfficeWord officeword = null;
        static public PCompletion pcompletion = null;
        static public PModif pmodif = null;
        static public PFunction pfunction = null;

        static public void xmltoxml(string xmlpath)
        {
            problemList = XMLControl.ReadPaper(xmlpath);
            paperid = XMLControl.getPaperId(xmlpath);

            string paperpath = "";
            string filepath = "";
            paperpath = Program.config["Root"] + Program.config["PaperPkg"] + paperid + "\\";
            Directory.CreateDirectory(paperpath);

            foreach (IdScoreType problem in problemList)
            {
                switch (problem.pt)
                {
                    case ProblemType.Choice:
                        choiceList.Add(PaperControl.OesData.FindChoiceById(problem.id.ToString())[0]);
                        break;
                    case ProblemType.Completion:
                        completionList.Add(PaperControl.OesData.FindCompletionById(problem.id.ToString())[0]);
                        break;
                    case ProblemType.Tof:
                        judgeList.Add(PaperControl.OesData.FindTofById(problem.id.ToString())[0]);
                        break;
                    case ProblemType.Excel:
                        officeexcel = PaperControl.OesData.FindOfficeExcelById(problem.id.ToString())[0];
                        File.Copy(Program.config["Root"] + Program.config["Excel"] + "p" + problem.id.ToString() + ".xls", paperpath + "f" + ".xls", true);
                        break;
                    case ProblemType.PowerPoint:
                        officeppt = PaperControl.OesData.FindOfficePowerPointById(problem.id.ToString())[0];
                        File.Copy(Program.config["Root"] + Program.config["PowerPoint"] + "p" + problem.id.ToString() + ".ppt", paperpath + "e" + ".ppt", true);
                        break;
                    case ProblemType.Word:
                        officeword = PaperControl.OesData.FindOfficeWordById(problem.id.ToString())[0];
                        File.Copy(Program.config["Root"] + Program.config["Word"] + "p" + problem.id.ToString() + ".doc", paperpath + "d" + ".doc", true);
                        break;
                    case ProblemType.ProgramCompletion:
                        pcompletion = PaperControl.OesData.FindCompletionProgramById(problem.id.ToString())[0];
                        File.Copy(Program.config["Root"] + Program.config["CCompletion"] + "p" + problem.id.ToString() + ".c", paperpath + "g" + ".c", true);
                        break;
                    case ProblemType.ProgramModification:
                        pmodif = PaperControl.OesData.FindModificationProgramById(problem.id.ToString())[0];
                        File.Copy(Program.config["Root"] + Program.config["CModification"] + "p" + problem.id.ToString() + ".c", paperpath + "h" + ".c", true);
                        break;
                    case ProblemType.ProgramFun:
                        pfunction = PaperControl.OesData.FindFunProgramById(problem.id.ToString())[0];
                        File.Copy(Program.config["Root"] + Program.config["CFunction"] + "p" + problem.id.ToString() + ".c", paperpath + "i" + ".c", true);
                        break;
                }
            }
            if (choiceList.Count != 0)
            {
                pXml = new ProblemXML(paperpath + "a.xml", false);
                pXml.SetChoiceProbelms(choiceList);
            }
            if (completionList.Count != 0)
            {
                pXml = new ProblemXML(paperpath + "b.xml", false);
                pXml.SetCompletionProbelms(completionList);
            }
            if (judgeList.Count != 0)
            {
                pXml = new ProblemXML(paperpath + "c.xml", false);
                pXml.SetJudgeProbelms(judgeList);
            }
            if (officeword != null)
            {
                pXml = new ProblemXML(paperpath + "d.xml", false);
                pXml.SetWordProbelm(officeword);
            }
            if (officeexcel != null)
            {
                pXml = new ProblemXML(paperpath + "e.xml", false);
                pXml.SetExcelProbelm(officeexcel);
            }
            if (officeppt != null)
            {
                pXml = new ProblemXML(paperpath + "f.xml", false);
                pXml.SetPowerPointProbelm(officeppt);
            }
            if (pcompletion != null)
            {
                pXml = new ProblemXML(paperpath + "g.xml", false);
                pXml.SetPCompletionProbelm(pcompletion);
            }
            if (pmodif != null)
            {
                pXml = new ProblemXML(paperpath + "h.xml", false);
                pXml.SetPModifProbelm(pmodif);
            }
            if (pfunction != null)
            {
                pXml = new ProblemXML(paperpath + "i.xml", false);
                pXml.SetPFunctionProbelm(pfunction);
            }
            RARHelper.CompressRAR(paperpath, paperid, Program.config["Root"] + Program.config["PaperPkg"], "123456");

        }
    }
}
