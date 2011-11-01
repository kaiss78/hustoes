using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    public class OfficePowerPoint:Office
    {
       
        public OfficePowerPoint()
        {
            type = ProblemType.PowerPoint;
        }

        public OfficePowerPoint(string p)
        {
            problem = p;
            type = ProblemType.PowerPoint;
        }

        public OfficePowerPoint(string rawPath, string ansPath, string stuAnsPath):base(rawPath,ansPath,stuAnsPath)
        {
            type = ProblemType.PowerPoint;
        }
        public override string getAns()
        {
            return stuAnsPath;
        }
    }
}
