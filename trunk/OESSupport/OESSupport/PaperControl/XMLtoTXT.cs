using System;
using System.Collections.Generic;
 
using System.Text;
using System.IO;
using OES.Model;
using OES.XMLFile;
using OESSupport;

namespace OESSupport.PaperControl
{
    public class XMLtoTXT
    {
        static public List<IdScoreType> problemList=new List<IdScoreType>();
        private static string paperid;
        static public string[] prostr = new string[9];
        static private string[] fileName = { "a.txt", "b.txt", "c.txt", "d.txt", "e.txt", 
                                                    "f.txt","g.txt","h.txt","i.txt"};
        static public Choice choice=new Choice();
        static public Judge judge=new Judge();
        static public Completion completion=new Completion();
        static public OfficeExcel officeexcel=new OfficeExcel();
        static public OfficePowerPoint officeppt=new OfficePowerPoint();
        static public OfficeWord officeword=new OfficeWord();
        static public PCompletion pcompletion=new PCompletion();
        static public PModif pmodif=new PModif();
        static public PFunction pfunction=new PFunction();
        
        static public void xmltotxt(string xmlpath)
        {
            

            problemList = XMLControl.ReadPaper(xmlpath);
            paperid = XMLControl.getPaperId(xmlpath);
            for(int i=0;i<9;i++)
            {
                prostr[i] = "";
            }
            
            string paperpath = "";
            string filepath = "";
            paperpath = Program.config["Root"]+Program.config["PaperPkg"] + paperid + "\\";
            Directory.CreateDirectory(paperpath);

            foreach (IdScoreType problem in problemList)
            {
                switch(problem.pt)
                {
                    case ProblemType.Choice:
                        choice = PaperControl.OesData.FindChoiceById(problem.id.ToString())[0];
                        prostr[0] = prostr[0] + choice.problem + "\n";
                        prostr[0] = prostr[0] + choice.optionA + "\n";
                        prostr[0] = prostr[0] + choice.optionB + "\n";
                        prostr[0] = prostr[0] + choice.optionC + "\n";
                        prostr[0] = prostr[0] + choice.optionD + "\n";                        
                        break;
                    case ProblemType.Completion:
                        completion = PaperControl.OesData.FindCompletionById(problem.id.ToString())[0];
                        prostr[1] = prostr[1] + completion.problem + "\n";                        
                        break;
                    case ProblemType.Tof:
                        judge = PaperControl.OesData.FindTofById(problem.id.ToString())[0];
                        prostr[2] = prostr[2] + judge.problem + "\n";    
                        break;
                    case ProblemType.Excel:
                        officeexcel = PaperControl.OesData.FindOfficeExcelById(problem.id.ToString())[0];
                        prostr[3] = prostr[3] + officeexcel.problem + "\n";
                        File.Copy(Program.config["Root"] + Program.config["Excel"] + "p" + problem.id.ToString() + ".xls", paperpath + "f" + ".xls",true);
                        break;
                    case ProblemType.PowerPoint:
                        officeppt = PaperControl.OesData.FindOfficePowerPointById(problem.id.ToString())[0];
                        prostr[4] = prostr[4] + officeppt.problem + "\n";
                        File.Copy(Program.config["Root"] + Program.config["PowerPoint"] + "p" + problem.id.ToString() + ".ppt", paperpath + "e" + ".ppt", true);
                        break;       
                    case ProblemType.Word:
                        officeword = PaperControl.OesData.FindOfficeWordById(problem.id.ToString())[0];
                        prostr[5] = prostr[5] + officeword.problem + "\n";
                        File.Copy(Program.config["Root"] + Program.config["Word"] + "p" + problem.id.ToString() + ".doc", paperpath + "d" + ".doc", true);
                        break;
                    case ProblemType.ProgramCompletion:
                        pcompletion = PaperControl.OesData.FindCompletionProgramById(problem.id.ToString())[0];
                        prostr[6] = prostr[6] + pcompletion.problem + "\n";
                        File.Copy(Program.config["Root"] + Program.config["CCompletion"] + "p" + problem.id.ToString() + ".c", paperpath + "g" + ".c", true);
                        break;
                    case ProblemType.ProgramModification:
                        pmodif=PaperControl.OesData.FindModificationProgramById(problem.id.ToString())[0];
                        prostr[7] = prostr[7] + pmodif.problem + "\n";
                        File.Copy(Program.config["Root"] + Program.config["CModification"] + "p" + problem.id.ToString() + ".c", paperpath + "h" + ".c", true);
                        break;
                    case ProblemType.ProgramFun:
                        pfunction = PaperControl.OesData.FindFunProgramById(problem.id.ToString())[0];
                        prostr[8] = prostr[8] + pfunction.problem + "\n";
                        File.Copy(Program.config["Root"] + Program.config["CFunction"] + "p" + problem.id.ToString() + ".c", paperpath + "i" + ".c", true);
                        break;
                } 
            }
 

            for(int i=0;i<9;i++)
            {
                if(prostr[i]!="")
                {
                    filepath = paperpath + fileName[i];
                    //File.Create(filepath);
                    StreamWriter sw = File.CreateText(filepath);
                    sw.Write(prostr[i]);
                    sw.Close();
                }
            }
            RARHelper.CompressRAR(paperpath, paperid, Program.config["Root"]+Program.config["PaperPkg"], "123456");

        }
    }
}
