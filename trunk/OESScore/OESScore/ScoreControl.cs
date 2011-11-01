using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OES;
using System.IO;

namespace OESScore
{
    class ScoreControl
    {
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

    }
}
