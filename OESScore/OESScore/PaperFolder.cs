using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using OES.Model;
namespace OESScore
{
    public class PaperFolder
    {
        //考生文件夹列表
        public List<FileInfo> StuList;
        //试卷信息
        public Paper paperInfo;
        //文件夹路径
        public DirectoryInfo Path;
    }
}
