using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    class Choice
    {
        public string optionA, optionB, optionC, optionD, problem, ans, stuAns;
        public Choice(string p, string oa, string ob, string oc, string od, string a)
        {
            problem = p;
            ans = a;
            optionA = oa;
            optionB = ob;
            optionC = oc;
            optionD = od;
            stuAns = "";
        }
    }
}


