using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    public class Completion:Problem
    {
        public string stuAns;
        public List<string> ans;      
        public Completion()
        {
            type = ProblemType.Completion;
        }
        public Completion(string p)
        {
            problem = p;
            stuAns = "";
            ans = new List<string>();
            type =ProblemType.Completion;
        }
        public override string getAns()
        {
            return stuAns;
        }
    }
}
