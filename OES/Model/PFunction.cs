using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    class PFunction
    {
        public string path, inp1, inp2, inp3, outp1, outp2, outp3;
        public PFunction(string p, string i1, string i2, string i3, string o1, string o2, string o3)
        {
            path = p;
            inp1 = i1;
            inp2 = i2; 
            inp3 = i3;
            outp1 = o1;
            outp2 = o2;
            outp3 = o3;
        }
    }
}
