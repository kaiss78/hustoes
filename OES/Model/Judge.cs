using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    class Judge
    {
        public string ans, problem,stuAns;
        public int score;
        public Judge()
        { 
        }
        public Judge(string a, string p)
        {
            ans = a;
            problem = p;
            stuAns = "";
        }
    }
}
