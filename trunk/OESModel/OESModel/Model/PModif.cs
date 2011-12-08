using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    public class PModif : ProgramProblem
    {
        public PModif(ProblemType pt)
        {
            type = pt;
        }
        public PModif(ProblemType pt, string p)
        {
            problem = p;
 
            type = pt;
        }
        public override string getAns()
        {
            return "";
        }
    }
}
