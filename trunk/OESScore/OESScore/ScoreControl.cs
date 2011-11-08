using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OES;
using OES.XMLFile;
using OES.Model;
using System.IO;

namespace OESScore
{
    class ScoreControl
    {
        public static StaAns staAns;
        /// <summary>
        /// 配置文件设置
        /// </summary>
        public static OESConfig config = new OESConfig("PathConfig.xml",
        new string[,] {
                        {"PaperPath","D:\\OES\\Paper\\"}
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


        public static void SetStandardAnswer(string ID,string path)
        {
            Answer ans;
            List<IdScoreType> proList = new List<IdScoreType>();
            List<IdAnswerType> ansList = new List<IdAnswerType>();
            proList = XMLControl.ReadPaper(path + ID + ".xml");
            ansList = XMLControl.GetPaperAns(path+"A"+ID+".xml");
            staAns=new StaAns();
            staAns.PaperID=ID;

            foreach (IdScoreType pro in proList)
            {
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
                staAns.Ans.Add(ans);
            }

        }

        public static List<Answer> GetStuAns(string path)
        {
            List<Answer> stuAns=new List<Answer>();
            Answer ans;
            List<IdAnswerType> ansList = new List<IdAnswerType>();
            ansList = XMLControl.GetPaperAns(path + "studentAns.xml");
            foreach (IdAnswerType pro in ansList)
            {
                ans = new Answer();
                ans.ID = pro.id;                
                ans.Type = pro.pt;
                ans.Ans = pro.answer;
                stuAns.Add(ans);
            }
            return stuAns;
        }

    }
}
