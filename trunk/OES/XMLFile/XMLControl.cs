using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using OES.Model;

namespace OES.XMLFile
{
    class XMLControl
    {
        public static XMLAssistant paperXML;
        public static XMLAssistant scoreXML;
        public static XMLAssistant studentAnsXML;
        public static XMLAssistant paperAnsXML;
        public static XMLAssistant logXML;
        public static string rootPath = Config.stuPath;

        
        public static void CreatePaperXML(string filePath,string paperId)
        {
            paperXML = new XMLAssistant(filePath, XMLType.Paper, paperId);
        }
        public static void AddProblemToPaper(ProblemType pt ,int id,int score)
        {
            paperXML.AddPaper(pt, new Pid_Score(id, score));
        }
    }
}
