using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    class OfficeExcel:Problem
    {
        public string rawPath = "";
        public string ansPath = "";
        public string stuAnsPath = "";

        public OfficeExcel()
        {
            type = ProblemType.Excel;
        }

        public OfficeExcel(string p)
        {
            problem = p;
            type = ProblemType.Excel;
        }

        public OfficeExcel(string rawPath, string ansPath, string stuAnsPath)
        {
            this.ansPath = ansPath;
            this.rawPath = rawPath;
            this.stuAnsPath = stuAnsPath;
            type = ProblemType.Excel;
        }
        public override string getAns()
        {
            return stuAnsPath;
        }
    }
}
