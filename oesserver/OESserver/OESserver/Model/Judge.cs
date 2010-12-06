using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    class Judge:Problem
    {
        public string ans, stuAns;
        public Judge()
        {
            type = "判断题";
        }
        public Judge(string p)
        {
            problem = p;
            stuAns = "";
            ans = "";
            type = "判断题";
        }
    }
}
