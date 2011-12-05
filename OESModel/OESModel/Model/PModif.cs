using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    public class PModif : Problem
    {
        public string path, ans1, ans2, ans3;
        public bool kind;
        public string stuAnsPath = "";
        public List<string> ans;
        public PModif(ProblemType pt)
        {
            type = pt;
        }
        public PModif(ProblemType pt, string p)
        {
            problem = p;
            ans1 = "";
            ans2 = "";
            ans3 = "";
            ans = new List<string>();
            type = pt;
        }
        public override string getAns()
        {
            return stuAnsPath;
        }
    }
}
