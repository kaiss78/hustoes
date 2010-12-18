using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OESserver
{
    public class PModif:Problem
    {
        public string path, ans1, ans2, ans3;
        public bool kind;
        public PModif()
        {
            type = "程序改错题";
        }
        public PModif(string p)
        {
            problem = p;
            ans1 = "";
            ans2 = "";
            ans3 = "";
            type = "程序改错题";
        }
    }
}
