using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    public class PFunction : Program
    {
 
        public PFunction(ProblemType pt)
        {
            type = pt;
        }
        public PFunction(ProblemType pt, string p)
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
