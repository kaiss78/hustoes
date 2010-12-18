using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OESserver
{
    public class Choice:Problem 
    {
        public string optionA;
        public string optionB;
        public string optionC;
        public string optionD;
        public string ans;
        public string stuAns;
        public string unit;
        
        public Choice()
        {
            type = "选择题";
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
            type = "选择题";
        }
    }
}


