using System;
using System.Collections.Generic;

using System.Text;
using System.IO;
using System.Runtime.InteropServices;

namespace OES
{
    class Config
    {
        public static OESConfig config = new OESConfig("PathConfig.xml", new string[,]{
            {"StuPath",@"C:\Exam\Student\"},
            {"PaperPath",@"C:\Exam\Paper\"},
            {"HistoryPath",@"C:\Exam\History\"}
        });
        public static string stuPath;//单个学生路径
        public static string StuPath;//学生文件夹路径
        public static string PaperPath;//试卷文件夹路径
        public static string paperPath;//单张试卷路径
        private static string historyPath;//所有考试记录

        public static string HistoryPath
        {
            get { return Config.historyPath; }
            set 
            {
                Config.historyPath = value;
                if (!Directory.Exists(Config.historyPath))
                {
                    Directory.CreateDirectory(Config.historyPath);
                }
            }
        }

        public Config(string INIPath)
        {
            StuPath = config["StuPath"];
            PaperPath = config["PaperPath"];
            HistoryPath = config["HistoryPath"];
        }

    }
}
