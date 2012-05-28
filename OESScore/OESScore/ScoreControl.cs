using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OES;
using OES.XMLFile;
using OES.Model;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;
using OES.Net;

namespace OESScore
{
    public class ScoreControl
    {

        public static StaAns staAns;

        public static ClientEvt scoreNet = new ClientEvt();
        /// <summary>
        /// 配置文件设置
        /// </summary>
        public static OESConfig config = new OESConfig("PathConfig.xml",
        new string[,] {
                        {"PaperPath","D:\\Paper\\"},
                        {"AnswerPath","D:\\Answer\\"}
                      });

        /// <summary>
        /// 数据库工厂
        /// </summary>
        private static OESData oesData = null;
        public static OESData OesData
        {
            get
            {
                if (oesData == null) { oesData = new OESData(); }
                return ScoreControl.oesData;
            }
            set { ScoreControl.oesData = value; }
        }

        /// <summary>
        /// 获取文件夹信息
        /// 获取文件夹中的目录信息，只获取文件夹的信息
        /// </summary>
        /// <param name="path">文件夹目录</param>
        /// <returns></returns>
        public static List<DirectoryInfo> GetFolderInfo(string path)
        {

            return new DirectoryInfo(path).GetDirectories().ToList<DirectoryInfo>();
        }


        /// <summary>
        /// 获取客观题答案
        /// </summary>
        /// <param name="pro">所要获取答案的客观题</param>
        /// <param name="ansList">答案列表</param>
        /// <returns></returns>
        static private Answer getAnswer(IdScoreType pro, List<IdAnswerType> ansList)
        {
            Answer ans;
            ans = new Answer();
            ans.ID = pro.id;
            ans.Score = pro.score;
            ans.Type = pro.pt;
            foreach (IdAnswerType a in ansList)
            {
                if ((a.id == pro.id) && (a.pt == pro.pt))
                {
                    ans.Ans = a.answer;
                    break;
                }
            }
            return ans;
        }
        /// <summary>
        /// 获取程序题答案
        /// </summary>
        /// <param name="pro">所要获取答案的程序题</param>
        /// <returns></returns>
        static private ProgramProblem getPAnswer(IdScoreType pro)
        {
            ProgramProblem programProblem = new ProgramProblem();
            switch (pro.pt)
            {
                case ProblemType.CProgramCompletion:
                case ProblemType.CProgramModification:
                case ProblemType.CProgramFun:
                    programProblem.language = PLanguage.C;
                    break;
                case ProblemType.CppProgramCompletion:
                case ProblemType.CppProgramModification:
                case ProblemType.CppProgramFun:
                    programProblem.language = PLanguage.CPP;
                    break;
                case ProblemType.VbProgramCompletion:
                case ProblemType.VbProgramModification:
                case ProblemType.VbProgramFun:
                    programProblem.language = PLanguage.VB;
                    break;
            }
            switch (pro.pt)
            {
                case ProblemType.CProgramCompletion:
                case ProblemType.CppProgramCompletion:
                case ProblemType.VbProgramCompletion:
                    programProblem.Type = ProgramPType.Completion;
                    break;
                case ProblemType.CppProgramFun:
                case ProblemType.VbProgramFun:
                case ProblemType.CProgramFun:
                    programProblem.Type = ProgramPType.Function;
                    break;
                case ProblemType.CppProgramModification:
                case ProblemType.CProgramModification:
                case ProblemType.VbProgramModification:
                    programProblem.Type = ProgramPType.Modify;
                    break;
            }
            programProblem.type = pro.pt;
            programProblem.score = pro.score;
            programProblem.ansList = ScoreControl.oesData.FindProgramAnswerByPID(pro.id);
            return programProblem;

        }

        /// <summary>
        /// 获取office提答案
        /// </summary>
        /// <param name="pro">题目类型及ID</param>
        /// <param name="path">放置路径</param>
        /// <returns></returns>
        static private OfficeAnswer getOfficeAnswer(IdScoreType pro, string path, string ex)
        {
            switch (pro.pt)
            {
                case ProblemType.Word:
                    scoreNet.LoadWordA(pro.id, -1);
                    scoreNet.LoadWordT(pro.id, -1);
                    break;
                case ProblemType.Excel:
                    scoreNet.LoadExcelA(pro.id, -1);
                    scoreNet.LoadExcelT(pro.id, -1);
                    break;
                case ProblemType.PowerPoint:
                    scoreNet.LoadPowerPointA(pro.id, -1);
                    scoreNet.LoadPowerPointT(pro.id, -1);
                    break;
            }            
            return new OfficeAnswer(path + "a" + pro.id.ToString() + ex, path + "t" + pro.id.ToString() + ".xml",pro.score);
        }


        /// <summary>
        /// 获取正确答案
        /// </summary>
        /// <param name="ID">试卷ID</param>
        /// <param name="path">试卷路径</param>
        /// <returns></returns>
        public static StaAns SetStandardAnswer(string ID)
        {
            StaAns newAnswer;
            List<IdScoreType> proList;
            List<IdAnswerType> ansList;
            proList = new List<IdScoreType>();
            ansList = new List<IdAnswerType>();

            ClientEvt.RootPath = ScoreControl.config["AnswerPath"] + ID + "\\";
            if (!Directory.Exists(ClientEvt.RootPath))
            {
                Directory.CreateDirectory(ClientEvt.RootPath);
            }
            //if ((!File.Exists(ScoreControl.config["AnswerPath"] + ID + "\\" + ID + ".xml")) || (!File.Exists(ScoreControl.config["AnswerPath"] + ID + "\\A" + ID + ".xml")))
            //{   
            //    scoreNet.LoadPaper(Convert.ToInt32(ID), -1);
            //    scoreNet.ReceiveFiles();
            //    while (!ClientEvt.isOver) ;

            //    //return null;
            //}
            if (!ClientEvt.isError)
            {
                proList = XMLControl.ReadPaper(ScoreControl.config["AnswerPath"] + ID + "\\" + ID + ".xml");
                ansList = XMLControl.ReadPaperAns(ScoreControl.config["AnswerPath"] + ID + "\\A" + ID + ".xml");
                newAnswer = new StaAns();
                newAnswer.Ans = new List<Answer>();
                newAnswer.PaperID = ID;
                //ProgramProblem programProblem;
                newAnswer.PCList = new List<ProgramProblem>();
                newAnswer.PFList = new List<ProgramProblem>();
                newAnswer.PMList = new List<ProgramProblem>();
                newAnswer.WordList = new List<OfficeAnswer>();
                newAnswer.PowerPointList = new List<OfficeAnswer>();
                newAnswer.ExcelList = new List<OfficeAnswer>();
                foreach (IdScoreType pro in proList)
                {
                    switch (pro.pt)
                    {
                        case ProblemType.Choice:
                        case ProblemType.Completion:
                        case ProblemType.Judgment:
                            newAnswer.Ans.Add(getAnswer(pro, ansList));
                            break;
                        case ProblemType.CProgramCompletion:
                        case ProblemType.CppProgramCompletion:
                        case ProblemType.VbProgramCompletion:
                            newAnswer.PCList.Add(getPAnswer(pro));
                            break;
                        case ProblemType.CppProgramFun:
                        case ProblemType.VbProgramFun:
                        case ProblemType.CProgramFun:
                            newAnswer.PFList.Add(getPAnswer(pro));
                            break;
                        case ProblemType.CppProgramModification:
                        case ProblemType.CProgramModification:
                        case ProblemType.VbProgramModification:
                            newAnswer.PMList.Add(getPAnswer(pro));
                            break;
                        case ProblemType.Word:
                            newAnswer.WordList.Add(getOfficeAnswer(pro, ClientEvt.RootPath, ".doc"));
                            break;
                        case ProblemType.PowerPoint:
                            newAnswer.PowerPointList.Add(getOfficeAnswer(pro, ClientEvt.RootPath, ".ppt"));
                            break;
                        case ProblemType.Excel:
                            newAnswer.ExcelList.Add(getOfficeAnswer(pro, ClientEvt.RootPath, ".xls"));
                            break;
                    }
                }
                scoreNet.ReceiveFiles();
                while (!ClientEvt.isOver) ;
                return newAnswer;
            }
            return null;

        }

        public static StaAns GetStuAns(string path)
        {
            StaAns stuAns = new StaAns();
            stuAns.Ans = new List<Answer>();
            stuAns.ProAns = new List<List<Answer>>();

            Answer ans;
            List<IdAnswerType> ansList = new List<IdAnswerType>();
            ansList = XMLControl.ReadPaperAns(path + "\\studentAns.xml");
            foreach (IdAnswerType pro in ansList)
            {
                ans = new Answer();
                ans.ID = pro.id;
                ans.Type = pro.pt;
                ans.Ans = pro.answer;
                stuAns.Ans.Add(ans);
            }
            return stuAns;
        }

    }
}
