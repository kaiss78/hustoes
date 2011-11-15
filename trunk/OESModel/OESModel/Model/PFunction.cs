using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
   public class PFunction:Problem
    {
        public string path, inp1, inp2, inp3, outp1, outp2, outp3,correctC;
        public bool kind;
        public List<string> input;
        public List<string> output;
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
 
            input = new List<string>();
            output = new List<string>();
            type = ProblemType.ProgramFun;
        }
        public override string getAns()
        {
            return stuAnsPath;
        }
    }
}
