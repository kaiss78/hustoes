using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    public class Choice:Problem 
    {
        public string optionA;
        public string optionB;
        public string optionC;
        public string optionD;
        public string ans;
        public string stuAns;

        
        public Choice()
        {
            type = ProblemType.Choice;
        }
        public Choice(string p, string oa, string ob, string oc, string od)
        {
            problem = p;
            optionA = oa;
            optionB = ob;
            optionC = oc;
            optionD = od;
            stuAns = "";
            ans = "";
            type = ProblemType.Choice;
        }
        public override string getAns()
        {
            return stuAns;
        }
    }
}


