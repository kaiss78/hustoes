using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OESMonitor.Model;
using OES.XMLFile;

namespace OESMonitor
{
    public class XMLtoTXT
    {
        static public List<IdScoreType> problemList=new List<IdScoreType>();
        static public string[] prostr = new string[9];        

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
                        
                        break;
                    case ProblemType.Completion:
                        break;
                    case ProblemType.Tof:
                        break;
                    case ProblemType.Excel:
                        break;
                    case ProblemType.PowerPoint:                                                
                        break;       
                    case ProblemType.Word:
                        break;
                    case ProblemType.ProgramCompletion:
                        break;
                    case ProblemType.ProgramModification:
                        break;
                    case ProblemType.ProgramFun:
                        break;
                }
            }
        }
    }
}
