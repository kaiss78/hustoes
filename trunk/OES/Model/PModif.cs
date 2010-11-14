using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    class PModif
    {
        public string path, ans1, ans2, ans3;
        public int score;
        public PModif()
        { 
        }
        public PModif(string p, string a1, string a2, string a3)
        {
            path = p;
            ans1 = a1;
            ans2 = a2;
            ans3 = a3;
        }
    }
}
