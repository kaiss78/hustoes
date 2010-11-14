using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    class PFunction
    {
        public string path, inp1, inp2, inp3, outp1, outp2, outp3;
        public int score;
        public PFunction()
        {
        }
        public PFunction(string p)
        {
            path = p;
            inp1 = "";
            inp2 = "";
            inp3 = "";
            outp1 = "";
            outp2 = "";
            outp3 = "";
        }
    }
}
