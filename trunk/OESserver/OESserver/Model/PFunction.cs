using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OESserver
{
   public class PFunction:Problem
    {
        public string path, inp1, inp2, inp3, outp1, outp2, outp3,correctC;
        public bool kind;
        public PFunction()
        {
            type = "程序综合题";
        }
        public PFunction(string p)
        {
            problem = p;
            inp1 = "";
            inp2 = "";
            inp3 = "";
            outp1 = "";
            outp2 = "";
            outp3 = "";
            type = "程序综合题";
        }
    }
}
