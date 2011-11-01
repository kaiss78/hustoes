using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    public class OfficeExcel:Office
    {
        public string rawPath;
        public string ansPath;
        public string stuAnsPath;        
        public OfficeExcel()
        {
            type = ProblemType.Excel;
        }

        public OfficeExcel(string p)
        {
            problem = p;
            type = ProblemType.Excel;
        }

        public OfficeExcel(string rawPath, string ansPath, string stuAnsPath):base(rawPath,ansPath,stuAnsPath)
        {
            type = ProblemType.Excel;
        }
        public override string getAns()
        {
            return stuAnsPath;
        }
    }
}
