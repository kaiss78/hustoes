using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    class Choice
    {
        public string optionA, optionB, optionC, optionD, problem, ans, stuAns;
        public int score;
        public Choice()
        {
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
        }
    }
}


