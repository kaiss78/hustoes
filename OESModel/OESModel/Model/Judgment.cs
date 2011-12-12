using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace OES.Model
{
    public class Judgment:Problem
    {
        public string ans, stuAns;
        public Judgment()
        {
            type = ProblemType.Judgment;
        }
        public Judgment(string p)
        {
            problem = p;
            stuAns = "";
            ans = "";
            type = ProblemType.Judgment;
        }
        public override string getAns()
        {
            return stuAns;
        }
    }
}
