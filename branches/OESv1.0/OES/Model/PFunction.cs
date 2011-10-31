using System;
using System.Collections.Generic;
 
using System.Text;

namespace OES.Model
{
    class PFunction:Problem
    {
        public string path = "";
        public string inp1 = "";
        public string inp2 = "";
        public string inp3 = "";
        public string outp1 = "";
        public string outp2 = "";
        public string outp3 = "";
        public string stuAnsPath = "";
        public PFunction()
        {
            type = ProblemType.ProgramFun;
        }
        public PFunction(string p)
        {
            problem = p;
            inp1 = "";
            inp2 = "";
            inp3 = "";
            outp1 = "";
            outp2 = "";
            outp3 = "";
            type = ProblemType.ProgramFun;
        }
        public override string getAns()
        {
            return stuAnsPath;
        }
    }
}
