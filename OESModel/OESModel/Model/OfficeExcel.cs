using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    public class OfficeExcel:Office
    {       
        public OfficeExcel()
        {
            type = ProblemType.Excel;
        }
        public OfficeExcel(Office office)
        {
            this.orderId = office.orderId;
            this.Plevel = office.Plevel;
            this.problem = office.problem;
            this.problemId = office.problemId;
            this.rawPath = office.rawPath;
            this.score = office.score;
            this.stuAnsPath = office.stuAnsPath;
            this.type = ProblemType.Excel;
            this.unit = office.unit;
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
