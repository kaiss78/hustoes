using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    class Completion
    {
        public string problem;
        public List<string> ans;
        public Completion(string p,List<string> a)
        {
            problem = p;
            ans = a;
        }
    }
}
