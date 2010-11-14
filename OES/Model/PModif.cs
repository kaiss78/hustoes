using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    class PModif:Problem
    {
        public string path, ans1, ans2, ans3;
        public PModif()
        {
            type = "程序改错题";
        }
        public PModif(string p)
        {
            path = p;
            ans1 = "";
            ans2 = "";
            ans3 = "";
            type = "程序改错题";
        }
    }
}
