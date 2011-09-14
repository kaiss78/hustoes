using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace OES
{
    public class Config
    {        
        public static string TempPaperPath;
        public static string ExcelPath;
        public static string WordPath;
        public static string PPTPath;
        public static string CompletionPath;
        public static string FunctionPath;
        public static string ModificationPath;
        public static bool allowScore;
        public static string inipath;
        public static string serverIP;
        [DllImport("kernel32")]
        private static extern bool WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);


        public Config(string INIPath)
         {
             inipath = INIPath;
             if(ExistINIFile())
             {
                 TempPaperPath = this.IniReadValue("path", "TempPaperPath")+"\\";
                 ExcelPath = this.IniReadValue("path", "ExcelPath") + "\\";
                 WordPath = this.IniReadValue("path", "WordPath") + "\\";
                 PPTPath = this.IniReadValue("path", "PPTPath") + "\\";
                 CompletionPath = this.IniReadValue("path", "CompletionPath") + "\\";
                 FunctionPath = this.IniReadValue("path", "FunctionPath") + "\\";
                 ModificationPath = this.IniReadValue("path", "ModificationPath") + "\\";
                 serverIP = this.IniReadValue("IP", "ServerIP") + "\\";
             }
             else
             {
                 using (StreamWriter sw = new StreamWriter(File.Create("config.ini")))
                 {
                     inipath = "config.ini"; 
                     sw.WriteLine("[path]");
                     sw.WriteLine(@"TempPaperPath=D:\OES\TempPaper\");
                     sw.WriteLine(@"ExcelPath=D:\OES\Excel\");
                     sw.WriteLine(@"WordPath=D:\OES\Word\");
                     sw.WriteLine(@"PPTPath=D:\OES\PPT\");
                     sw.WriteLine(@"CompletionPath=D:\OES\Completion\");
                     sw.WriteLine(@"FunctionPath =D:\OES\Function\");
                     sw.WriteLine(@"ModificationPath=D:\OES\Modification\");
                     sw.WriteLine("[IP]");
                     sw.WriteLine(@"ServerIP=211.69.197.116");
                     TempPaperPath = @"D:\OES\TempPaper\";
                     ExcelPath = @"D:\OES\Excel\";
                     WordPath = @"D:\OES\Word\";
                     PPTPath = @"D:\OES\PPT\";
                     serverIP = "211.69.197.116";
                 }
                 if (!Directory.Exists(TempPaperPath))
                 {
                     Directory.CreateDirectory(@"D:\OES\TempPaper\");
                 }
                 if (!Directory.Exists(ExcelPath))
                 {
                     Directory.CreateDirectory(@"D:\OES\Excel\");
                 }
                 if (!Directory.Exists(WordPath))
                 {
                     Directory.CreateDirectory(@"D:\OES\Word\");
                 }
                 if (!Directory.Exists(PPTPath))
                 {
                     Directory.CreateDirectory(@"D:\OES\PPT\");
                 }
                 if (!Directory.Exists(CompletionPath))
                 {
                     Directory.CreateDirectory(@"D:\OES\CompletionPath\");
                 }
                 if (!Directory.Exists(FunctionPath))
                 {
                     Directory.CreateDirectory(@"D:\OES\FunctionPath\");
                 }
                 if (!Directory.Exists(ModificationPath))
                 {
                     Directory.CreateDirectory(@"D:\OES\ModificationPath\");
                 }
             }             
         }

         /// <summary>
         /// 写入INI文件
        /// </summary>
        /// <param name="Section">项目名称(如 [TypeName] )</param>
        /// <param name="Key">键</param>
        /// <param name="Value">值</param>
        public void IniWriteValue(string Section, string Key, string Value)
         {
             WritePrivateProfileString(Section, Key, Value, Config.inipath);
            MessageBox.Show( WritePrivateProfileString(Section, Key, Value, Config.inipath).ToString());
        }

        /// <summary>
        /// 读出INI文件
        /// </summary>
        /// <param name="Section">项目名称(如 [TypeName] )</param>
        /// <param name="Key">键</param>        
        public string IniReadValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(500);
            int i = GetPrivateProfileString(Section, Key, "", temp, 500, Config.inipath);
            return temp.ToString();
        }

        /// <summary>
        /// 验证文件是否存在
        /// </summary>
        /// <returns>布尔值</returns>
        public bool ExistINIFile()
        {
            return File.Exists(inipath);
        }
    }
}
