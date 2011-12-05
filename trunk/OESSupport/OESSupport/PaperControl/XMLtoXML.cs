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

        static public List<OfficeExcel> officeexcel = new List<OfficeExcel>();
        static public List<OfficePowerPoint> officeppt = new List<OfficePowerPoint>();
        static public List<OfficeWord> officeword = new List<OfficeWord>();
        static public List<PCompletion> pcompletion = new List<PCompletion>();
        static public List<PModif> pmodif = new List<PModif>();
        static public List<PFunction> pfunction = new List<PFunction>();

        static public void ClearAll()
        {
            choiceList.Clear();
            completionList.Clear();
            judgeList.Clear();
            officeexcel.Clear();
            officeppt.Clear();
            officeword.Clear();
            pcompletion.Clear();
            pmodif.Clear();
            pfunction.Clear();
            problemList.Clear();
            paperid = "";
            pXml = null;
        }

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

                    case ProblemType.Word:
                        officeword.Add(PaperControl.OesData.FindOfficeWordById(problem.id.ToString())[0]);
                        File.Copy(Program.config["Root"] + Program.config["Word"] + "p" + problem.id.ToString() + ".doc", paperpath + "d" + (officeword.Count - 1).ToString() + ".doc", true);
                        break;
                    case ProblemType.Excel:
                        officeexcel.Add(PaperControl.OesData.FindOfficeExcelById(problem.id.ToString())[0]);
                        File.Copy(Program.config["Root"] + Program.config["Excel"] + "p" + problem.id.ToString() + ".xls", paperpath + "e" + (officeexcel.Count-1).ToString() + ".xls", true);
                        break;
                    case ProblemType.PowerPoint:
                        officeppt.Add(PaperControl.OesData.FindOfficePowerPointById(problem.id.ToString())[0]);
                        File.Copy(Program.config["Root"] + Program.config["PowerPoint"] + "p" + problem.id.ToString() + ".ppt", paperpath + "f" + (officeppt.Count - 1).ToString() + ".ppt", true);
                        break;
                   
                    case ProblemType.CProgramCompletion:
                        pcompletion.Add(PaperControl.OesData.FindCompletionProgramById(problem.id.ToString())[0]);
                        File.Copy(Program.config["Root"] + Program.config["CCompletion"] + "p" + problem.id.ToString() + ".c", paperpath + "g" + (pcompletion.Count - 1).ToString() + ".c", true);
                        break;
                    case ProblemType.CProgramModification:
                        pmodif.Add(PaperControl.OesData.FindModificationProgramById(problem.id.ToString())[0]);
                        File.Copy(Program.config["Root"] + Program.config["CModification"] + "p" + problem.id.ToString() + ".c", paperpath + "h" + (pmodif.Count - 1).ToString() + ".c", true);
                        break;
                    case ProblemType.CProgramFun:
                        pfunction.Add(PaperControl.OesData.FindFunProgramById(problem.id.ToString())[0]);
                        File.Copy(Program.config["Root"] + Program.config["CFunction"] + "p" + problem.id.ToString() + ".c", paperpath + "i" + (pfunction.Count - 1).ToString() + ".c", true);
                        break;

                    case ProblemType.CppProgramCompletion:
                        pcompletion.Add(PaperControl.OesData.FindCompletionProgramById(problem.id.ToString())[0]);
                        File.Copy(Program.config["Root"] + Program.config["CppCompletion"] + "p" + problem.id.ToString() + ".cpp", paperpath + "g" + (pcompletion.Count - 1).ToString() + ".cpp", true);
                        break;
                    case ProblemType.CppProgramModification:
                        pmodif.Add(PaperControl.OesData.FindModificationProgramById(problem.id.ToString())[0]);
                        File.Copy(Program.config["Root"] + Program.config["CppModification"] + "p" + problem.id.ToString() + ".cpp", paperpath + "h" + (pmodif.Count - 1).ToString() + ".cpp", true);
                        break;
                    case ProblemType.CppProgramFun:
                        pfunction.Add(PaperControl.OesData.FindFunProgramById(problem.id.ToString())[0]);
                        File.Copy(Program.config["Root"] + Program.config["CppFunction"] + "p" + problem.id.ToString() + ".cpp", paperpath + "i" + (pfunction.Count - 1).ToString() + ".cpp", true);
                        break;

                    case ProblemType.VbProgramCompletion:
                        pcompletion.Add(PaperControl.OesData.FindCompletionProgramById(problem.id.ToString())[0]);
                        File.Copy(Program.config["Root"] + Program.config["VbCompletion"] + "p" + problem.id.ToString() + ".vb", paperpath + "g" + (pcompletion.Count - 1).ToString() + ".vb", true);
                        break;
                    case ProblemType.VbProgramModification:
                        pmodif.Add(PaperControl.OesData.FindModificationProgramById(problem.id.ToString())[0]);
                        File.Copy(Program.config["Root"] + Program.config["VbModification"] + "p" + problem.id.ToString() + ".vb", paperpath + "h" + (pmodif.Count - 1).ToString() + ".vb", true);
                        break;
                    case ProblemType.VbProgramFun:
                        pfunction.Add(PaperControl.OesData.FindFunProgramById(problem.id.ToString())[0]);
                        File.Copy(Program.config["Root"] + Program.config["VbFunction"] + "p" + problem.id.ToString() + ".vb", paperpath + "i" + (pfunction.Count - 1).ToString() + ".vb", true);
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
            if (officeword.Count != 0)
            {
                pXml = new ProblemXML(paperpath + "d.xml", false);
                pXml.SetWordProbelm(officeword);
            }
            if (officeexcel.Count != 0)
            {
                pXml = new ProblemXML(paperpath + "e.xml", false);
                pXml.SetExcelProbelm(officeexcel);
            }
            if (officeppt.Count != 0)
            {
                pXml = new ProblemXML(paperpath + "f.xml", false);
                pXml.SetPowerPointProbelm(officeppt);
            }
            if (pcompletion.Count != 0)
            {
                pXml = new ProblemXML(paperpath + "g.xml", false);
                pXml.SetPCompletionProbelm(pcompletion);
            }
            if (pmodif.Count != 0)
            {
                pXml = new ProblemXML(paperpath + "h.xml", false);
                pXml.SetPModifProbelm(pmodif);
            }
            if (pfunction.Count != 0)
            {
                pXml = new ProblemXML(paperpath + "i.xml", false);
                pXml.SetPFunctionProbelm(pfunction);
            }
            RARHelper.CompressRAR(paperpath, paperid, Program.config["Root"] + Program.config["PaperPkg"], "123456");
            ClearAll();
        }
    }
}
