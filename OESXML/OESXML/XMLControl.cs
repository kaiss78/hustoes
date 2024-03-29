﻿using System;
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
        public static void CreateStudentAnsXML(string rootPath, string stuId, string paperId)
        {
            if (File.Exists(rootPath + "studentAns.xml"))
            {
                File.Delete(rootPath + "studentAns.xml");
            }
            studentAnsXML = new XMLAssistant(rootPath + "studentAns.xml", XMLType.StudentAnswer, new String[] { stuId, paperId });
        }
        public static void AddStudentAns(ProblemType pt, int id, string answer)
        {
            studentAnsXML.AddStudentAns(pt, new Pid_Ans(id, answer));
        }
        public static List<IdAnswerType> ReadStudentAns(string filePath)
        {
            studentAnsXML = new XMLAssistant(filePath, XMLType.StudentAnswer, null);
            return studentAnsXML.GetAnswer();
        }
        public static int GetStudentAnsPaper(string filePath)
        {
            studentAnsXML  = new XMLAssistant(filePath, XMLType.StudentAnswer, null);
            return Convert.ToInt32(studentAnsXML.getStuAnsPaperId());
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
            logXML = new XMLAssistant(rootPath + "log.xml", XMLType.Log,new object());
        }
        public static bool LoadLogXML(string rootPath)
        {
            if (File.Exists(rootPath + "log.xml"))
            {
                logXML = new XMLAssistant(rootPath + "log.xml", XMLType.Log, null);
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void WriteLogXML(string rootPath, ProblemType pt, int proId, String ans)
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
                case ProblemType.Judgment:
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
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            paperXML = new XMLAssistant(filePath, XMLType.Paper, paperId);
        }
        public static void AddProblemToPaper(ProblemType pt, int id, int score)
        {
            paperXML.AddPaper(pt, new Pid_Score(id, score));
        }
        public static List<IdScoreType> ReadPaper(string filePath)
        {
            paperXML = new XMLAssistant(filePath, XMLType.Paper, null);
            return paperXML.GetPaper();
        }
        public static string getPaperId(string filePath)
        {
            paperXML = new XMLAssistant(filePath, XMLType.Paper, null);
            return paperXML.getPaperId();
        }
        #endregion

        #region 考生分数XML
        public static void CreateScoreXML(string path, string paperId, string stuId)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            scoreXML = new XMLAssistant(path, XMLType.StudentScore, new String[] { paperId, stuId });
        }
        public static void AddScore(ProblemType pt, int id, int score)
        {
            scoreXML.AddScore(pt, new Pid_Score(id, score));
        }
        public static List<IdScoreType> ReadScoreSheet(string filePath)
        {
            scoreXML = new XMLAssistant(filePath, XMLType.StudentScore, null);
            return scoreXML.GetPaper();
        }
        #endregion

        #region 试卷答案XML
        public static void CreatePaperAnsXML(string path, string paperId)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            paperAnsXML = new XMLAssistant(path, XMLType.PaperAnswer, new String[] { paperId });
        }
        public static void AddPaperAns(ProblemType pt, int id, string answer)
        {
            paperAnsXML.AddPaperAns(pt, new Pid_Ans(id, answer));
        }
        public static List<IdAnswerType> ReadPaperAns(string filePath)
        {
            paperAnsXML = new XMLAssistant(filePath, XMLType.PaperAnswer, null);
            return paperAnsXML.GetAnswer();
        }
        #endregion

    }

}
