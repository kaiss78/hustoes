using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

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
        public static void CreateLogXML()
        {
            if (File.Exists(rootPath+"log.xml"))
            {
                int i=1;
                while (File.Exists(rootPath+"log" + i.ToString() + ".xml"))
                {
                    i++;
                }
                File.Move(rootPath + "log.xml", rootPath + "log" + i.ToString() + ".xml");
            }
            logXML = new XMLAssistant(rootPath+"log.xml", XMLType.Log, null);
        }
        public static void LoadLogXML()
        {
            if (File.Exists(rootPath + "log.xml"))
            {
                logXML = new XMLAssistant(rootPath + "log.xml", XMLType.Log, null);
            }
            else
            {
                throw new Exception("您无法重新考试");
            }
        }
        public static void WriteLogXML(ProblemType pt,int proId,String ans)
        {
            if (File.Exists(rootPath + "log.xml"))
            {
                logXML.AddLog(pt, new Pid_Ans(proId, ans));
            }
            else
            {
                Debug.WriteLine("File not exist!");
            }
        }
        public static string FindLog(ProblemType pt, int proId)
        {
            switch (pt)
            {
                case ProblemType.Choice:
                    {
                        return logXML.FindLogAns(pt, proId);
                    }
                case ProblemType.Completion:
                    {
                        return logXML.FindLogAns(pt, proId); 
                    }
                case ProblemType.Tof:
                    {
                        return logXML.FindLogAns(pt, proId); 
                    }
                case ProblemType.Start:
                    {
                        return logXML.TotleLogSecond().ToString();
                    }
            }
            return "";
        }
    }
}
