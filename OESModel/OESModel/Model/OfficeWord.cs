using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    public class OfficeWord:Office
    {
        public OfficeWord()
        {
            type = ProblemType.Word;
        }
        public OfficeWord(Office office)
        {
            this.orderId = office.orderId;
            this.Plevel = office.Plevel;
            this.problem = office.problem;
            this.problemId = office.problemId;
            this.rawPath = office.rawPath;
            this.score = office.score;
            this.stuAnsPath = office.stuAnsPath;
            this.type = ProblemType.Word;
            this.unit = office.unit;
        }
        public OfficeWord(string p)
        {
            problem = p;
            type = ProblemType.Word;
        }
        public OfficeWord(string rawPath, string ansPath, string stuAnsPath):base(rawPath,ansPath,stuAnsPath)
        {

            type = ProblemType.Word;
        }
        public override string getAns()
        {
            return stuAnsPath;
        }
    }
}
