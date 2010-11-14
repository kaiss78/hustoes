using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    class Completion
    {
        public string problem, stuAns;
        public int score;
        public List<string> ans;
        public Completion()
        { 
        }
        public Completion(string p,List<string> a)
        {
            problem = p;
            ans = a;
            stuAns = "";
        }
    }
}
