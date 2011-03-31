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
        public static bool allowScore;
        public static string inipath;
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
             }
             else
             {
                 using (StreamWriter sw = new StreamWriter(File.Create("config.ini")))
                 {
                     inipath = "config.ini";                     
                     sw.WriteLine("[path]");
                     sw.WriteLine(@"TempPaperPath=D:\OES\TempPaper\");
                     Directory.CreateDirectory(@"D:\OES\TempPaper\");
                     TempPaperPath = @"D:\OES\TempPaper\";
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
