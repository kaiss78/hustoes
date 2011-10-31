using System;
using System.Collections.Generic;
 
using System.Text;

namespace OES.Model
{
    class PModif:Problem
    {
        public string path = "";
        public string ans1 = "";
        public string ans2 = "";
        public string ans3 = "";
        public string stuAnsPath = "";
        public PModif()
        {
            type = ProblemType.ProgramModification;
        }
        public PModif(string p)
        {
            problem = p;
            ans1 = "";
            ans2 = "";
            ans3 = "";
            type = ProblemType.ProgramModification;
        }
        public override string getAns()
        {
            return stuAnsPath;
        }
    }
}
