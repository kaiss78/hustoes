using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    class OfficeWord:Problem
    {
        public string rawPath = "";
        public string ansPath = "";
        public string stuAnsPath = "";

        public OfficeWord()
        {
            type = ProblemType.Word;
        }

        public OfficeWord(string p)
        {
            problem = p;
            type = ProblemType.Word;
        }
        public OfficeWord(string rawPath, string ansPath, string stuAnsPath)
        {
            this.ansPath = ansPath;
            this.rawPath = rawPath;
            this.stuAnsPath = stuAnsPath;
            type = ProblemType.Word;
        }
        public override string getAns()
        {
            return stuAnsPath;
        }
    }
}
