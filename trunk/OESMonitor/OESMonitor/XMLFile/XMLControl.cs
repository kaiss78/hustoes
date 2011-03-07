using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using OESMonitor.Model;

namespace OESMonitor.XMLFile
{
    class XMLControl
    {
        public static XMLAssistant paperXML;
        public static XMLAssistant scoreXML;
        public static XMLAssistant studentAnsXML;
        public static XMLAssistant paperAnsXML;
        public static XMLAssistant logXML;
        //public static string rootPath = Config.TempPaperPath;
        
        public static void CreatePaperXML(string filePath,string paperId)
        {
            paperXML = new XMLAssistant(filePath, XMLType.Paper, paperId);
        }
        public static void AddProblemToPaper(ProblemType pt ,int id,int score)
        {
            paperXML.AddPaper(pt, new Pid_Score(id, score));
        }
        public static List<IdScoreType> ReadPaper(string filePath)
        {
            paperXML = new XMLAssistant(filePath, XMLType.Paper, 0);
            return paperXML.Get();
        }
        public static string getPaperId(string filePath)
        {
            paperXML=new XMLAssistant(filePath,XMLType.Paper,0);
            return paperXML.getPaperId();
        }
    }
    public class IdScoreType
    {
        public int id;
        public ProblemType pt;
        public int score;
        public IdScoreType()
        {
        }
        public IdScoreType(int id,ProblemType pt,int score)
        {
            this.id=id;
            this.pt=pt;
            this.score=score;
        }
    }
}
