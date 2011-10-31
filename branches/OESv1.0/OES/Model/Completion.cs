using System;
using System.Collections.Generic;
 
using System.Text;

namespace OES.Model
{
    class Completion:Problem
    {
        public string stuAns = "";
        public List<string> ans=new List<string>();
        public Completion()
        {
            type = ProblemType.Completion;
        }
        public Completion(string p)
        {
            problem = p;
            stuAns = "";
            ans = new List<string>();
            type = ProblemType.Completion;
        }
        public override string getAns()
        {
            return stuAns;
        }
    }
}
