using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    class OfficePowerPoint:Problem
    {
        public string rawPath = "";
        public string ansPath = "";
        public string stuAnsPath = "";

        public OfficePowerPoint()
        {
            type = ProblemType.PowerPoint;
        }

        public OfficePowerPoint(string p)
        {
            problem = p;
            type = ProblemType.PowerPoint;
        }

        public OfficePowerPoint(string rawPath, string ansPath, string stuAnsPath)
        {
            this.ansPath = ansPath;
            this.rawPath = rawPath;
            this.stuAnsPath = stuAnsPath;
            type = ProblemType.PowerPoint;
        }
        public override string getAns()
        {
            return stuAnsPath;
        }
    }
}
