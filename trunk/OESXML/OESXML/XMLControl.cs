using System;
using System.Collections.Generic;
 
using System.Text;
using System.IO;
using System.Diagnostics;
using OES.Model;

namespace OES.XMLFile
{
    public class XMLControl
    {
        /// <summary>
        /// 试卷XML
        /// </summary>
        public static XMLAssistant paperXML;    
        /// <summary>
        /// 评分XML
        /// </summary>
        public static XMLAssistant scoreXML;    
        /// <summary>
        /// 考试答案XML
        /// </summary>
        public static XMLAssistant studentAnsXML;
        /// <summary>
        /// 试卷答案XML
        /// </summary>
        public static XMLAssistant paperAnsXML; 
        /// <summary>
        /// 考试日志XML
        /// </summary>
        public static XMLAssistant logXML;      

        #region 学生答案XML
        public static void CreateStudentAnsXML(string rootPath,string stuId)
        {
            if (File.Exists(rootPath + "studentAns.xml"))
            {
                File.Delete(rootPath + "studentAns.xml");
            }
            studentAnsXML = new XMLAssistant(rootPath + "studentAns.xml", XMLType.StudentAnswer, new String[] { stuId });
        }
        #endregion

        #region 考试日志XML
        public static void CreateLogXML(string rootPath)
        {
            if (File.Exists(rootPath + "log.xml"))
            {
                int i = 1;
                while (File.Exists(rootPath + "log" + i.ToString() + ".xml"))
                {
                    i++;
                }
                File.Move(rootPath + "log.xml", rootPath + "log" + i.ToString() + ".xml");
            }
            logXML = new XMLAssistant(rootPath + "log.xml", XMLType.Log, null);
        }
        public static void LoadLogXML(string rootPath)
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
        public static void WriteLogXML(string rootPath,ProblemType pt, int proId, String ans)
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
        #endregion

        #region 考试试卷XML
        public static void CreatePaperXML(string filePath, string paperId)
        {
            paperXML = new XMLAssistant(filePath, XMLType.Paper, paperId);
        }
        public static void AddProblemToPaper(ProblemType pt, int id, int score)
        {
            paperXML.AddPaper(pt, new Pid_Score(id, score));
        }
        public static List<IdScoreType> ReadPaper(string filePath)
        {
            paperXML = new XMLAssistant(filePath, XMLType.Paper, "0");
            return paperXML.Get();
        }
        public static string getPaperId(string filePath)
        {
            paperXML = new XMLAssistant(filePath, XMLType.Paper, "0");
            return paperXML.getPaperId();
        }
        #endregion

        #region 考生分数XML
        public static void CreateScoreXML(string path,string paperId, string stuId)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            scoreXML = new XMLAssistant(path, XMLType.StudentScore, new String[] {paperId, stuId });
        }
        #endregion

        #region 试卷答案XML
        public static void CreatePaperAnsXML(string path, string paperId)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            paperAnsXML = new XMLAssistant(path, XMLType.StudentScore, new String[] { paperId });
        }
        #endregion

    }
    public class IdScoreType
    {
        public int id;
        public ProblemType pt;
        public int score;
        public IdScoreType()
        {
        }
        public IdScoreType(int id, ProblemType pt, int score)
        {
            this.id = id;
            this.pt = pt;
            this.score = score;
        }
    }
}
