using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using OESMonitor.Model;
using OESMonitor.XMLFile;

namespace OESMonitor.PaperControl
{
    public class XMLtoTXT
    {
        static public List<IdScoreType> problemList=new List<IdScoreType>();

        static public string[] prostr = new string[9];

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
            for(int i=0;i<9;i++)
            {
                prostr[i] = "";
            }
            foreach (IdScoreType problem in problemList)
            {
                switch(problem.pt)
                {
                    case ProblemType.Choice:
                        choice = PaperControl.OesData.FindChoiceById(problem.id.ToString())[0];
                        prostr[0] = prostr[0] + choice.problem + "\r\n";
                        prostr[0] = prostr[0] + choice.optionA + "\r\n";
                        prostr[0] = prostr[0] + choice.optionB + "\r\n";
                        prostr[0] = prostr[0] + choice.optionC + "\r\n";
                        prostr[0] = prostr[0] + choice.optionD + "\r\n";                        
                        break;
                    case ProblemType.Completion:
                        completion = PaperControl.OesData.FindCompletionById(problem.id.ToString())[0];
                        prostr[1] = prostr[1] + completion.problem + "\r\n";                        
                        break;
                    case ProblemType.Tof:
                        judge = PaperControl.OesData.FindTofById(problem.id.ToString())[0];
                        prostr[2] = prostr[2] + judge.problem + "\r\n";    
                        break;
                    case ProblemType.Excel:
                        officeexcel = PaperControl.OesData.FindOfficeExcelById(problem.id.ToString(),"2")[0];
                        prostr[3] = prostr[3] + officeexcel.problem + "\r\n";    

                        break;
                    case ProblemType.PowerPoint:
                        officeppt = PaperControl.OesData.FindOfficePowerPointById(problem.id.ToString(), "3")[0];
                        prostr[4] = prostr[4] + officeppt.problem + "\r\n";    
                        break;       
                    case ProblemType.Word:
                        officeword = PaperControl.OesData.FindOfficeWordById(problem.id.ToString(), "1")[0];
                        prostr[5] = prostr[5] + officeword.problem + "\r\n"; 
                        break;
                    case ProblemType.ProgramCompletion:
                        pcompletion = PaperControl.OesData.FindCompletionProgramById(problem.id.ToString())[0];
                        prostr[6] = prostr[6] + pcompletion.problem + "\r\n";
                        break;
                    case ProblemType.ProgramModification:
                        pmodif=PaperControl.OesData.FindModificationProgramById(problem.id.ToString())[0];
                        prostr[7] = prostr[7] + pmodif.problem + "\r\n";
                        break;
                    case ProblemType.ProgramFun:
                        pfunction = PaperControl.OesData.FindFunProgramById(problem.id.ToString())[0];
                        prostr[9] = prostr[9] + pfunction.problem + "\r\n";
                        break;
                }
            }
        }
    }
}
