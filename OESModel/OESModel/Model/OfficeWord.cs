using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    public class OfficeWord:Office
    {
        public OfficeWord()         //Office Word题类
        {
            type = ProblemType.Word;
        }
        //给出Word题面的构造函数
        public OfficeWord(string p)
        {
            problem = p;
            type = ProblemType.Word;
        }
        //给出路径的构造函数
        public OfficeWord(string rawPath, string ansPath, string stuAnsPath):base(rawPath,ansPath,stuAnsPath)
        {
            type = ProblemType.Word;
        }
        //获取答案路径
        public override string getAns()
        {
            return stuAnsPath;
        }
    }
}
