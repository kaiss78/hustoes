using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    public class OfficeExcel:Office     //OfficeExcel题类
    {    
        public OfficeExcel()
        {
            type = ProblemType.Excel;
        }
        //给出Excel题面的构造函数
        public OfficeExcel(string p)
        {
            problem = p;
            type = ProblemType.Excel;
        }
        //给出路径的构造函数
        public OfficeExcel(string rawPath, string ansPath, string stuAnsPath):base(rawPath,ansPath,stuAnsPath)
        {
            type = ProblemType.Excel;
        }
        //获取答案路径
        public override string getAns()
        {
            return stuAnsPath;
        }
    }
}
