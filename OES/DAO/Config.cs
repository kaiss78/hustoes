using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;

namespace OES
{
    class Config
    {
        public static string stuPath;//单个学生路径
        public static string StuPath;//学生文件夹路径
        public static string PaperPath;//试卷文件夹路径
        public static string paperPath;//单张试卷路径
        public static string server;
        public static int portNum;
        public static bool allowScore;
        private static string inipath = "OesConfig.ini";

        public static string Inipath
        {
            get 
            {
                return Config.inipath; 
            }
            set 
            { 
                Config.inipath = value; 
            }
        }
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);


        public Config(string INIPath)
         {
             inipath = INIPath;
             if(ExistINIFile())
             {
                StuPath=this.IniReadValue("path","stupath");
                PaperPath=this.IniReadValue("path","paperpath");
                server = this.IniReadValue("path", "serverip");
                portNum = Convert.ToInt32(this.IniReadValue("path", "port"));
             }
             else
             {

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
