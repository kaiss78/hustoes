using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    public class PCompletion : ProgramProblem
    {

        public PCompletion(ProblemType pt)
        {
            type = pt;
        }
        public PCompletion(ProblemType pt,string p)
        {
            problem = p;

            type = pt;
        }
        public PCompletion(ProblemType pt, string rawPath, string stuAnsPath)
        {

            type = pt;
        }
        public override string getAns()
        {
            return "";
        }
    }
}
