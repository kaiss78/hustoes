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
        public PModif(string p)
        {
            path = p;
            ans1 = "";
            ans2 = "";
            ans3 = "";
        }
    }
}
