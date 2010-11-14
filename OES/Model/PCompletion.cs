using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    class PCompletion
    {
        public string path, ans1, ans2, ans3;
        public int score;
        public PCompletion()
        { 
        }
        public PCompletion(string p)
        {
            path = p;
            ans1 = "";
            ans2 = "";
            ans3 = "";
        }
    }
}
