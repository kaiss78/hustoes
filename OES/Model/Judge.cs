using System;
using System.Collections.Generic;
 
using System.Text;

namespace OES.Model
{
    class Judge:Problem
    {
        public string ans = "";
        public string stuAns = "";
        public Judge()
        {
            type = ProblemType.Tof;
        }
        public Judge(string p)
        {
            problem = p;
            stuAns = "";
            ans = "";
            type = ProblemType.Tof;
        }
        public override string getAns()
        {
            return stuAns;
        }
    }
}
