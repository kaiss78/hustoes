using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    public class OfficePowerPoint:Office        //Office PowerPoint题类
    {
        public OfficePowerPoint()
        {
            type = ProblemType.PowerPoint;
        }
        //给出PowerPoint题面的构造函数
        public OfficePowerPoint(string p)
        {
            problem = p;
            type = ProblemType.PowerPoint;
        }
        //给出路径的构造函数
        public OfficePowerPoint(string rawPath, string ansPath, string stuAnsPath):base(rawPath,ansPath,stuAnsPath)
        {
            type = ProblemType.PowerPoint;
        }
        //获取答案路径
        public override string getAns()
        {
            return stuAnsPath;
        }
    }
}
