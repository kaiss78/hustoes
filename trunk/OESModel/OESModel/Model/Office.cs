using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    public class Office : Problem       //Office题类
    {
        public string rawPath;          //Office题源文件路径
        public string ansPath;          //Office题标答文件路径
        public string stuAnsPath;       //Office题考试答案路径

        public Office()
        {
        }

        //Office构造函数
        public Office(string rawPath, string ansPath, string stuAnsPath)
        {
            this.ansPath = ansPath;
            this.rawPath = rawPath;
            this.stuAnsPath = stuAnsPath;
        }

        //Office题类型枚举
        public enum OfficeType
        {
            Null = -1,
            Word = 0,
            Excel = 1,
            PowerPoint = 2
        }
    }
}
