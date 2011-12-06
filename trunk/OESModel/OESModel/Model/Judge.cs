using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace OES.Model
{
    public class Judge:Problem
    {
        public string ans, stuAns;
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
