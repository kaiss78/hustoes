using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    public  class PCompletion:Problem
    {
        public string path,ans1, ans2, ans3;
        public bool kind;
        public string rawPath;
        public string stuAnsPath;
        public PCompletion()
        {
            type = "程序填空题";
        }
        public PCompletion(string p)
        {
            problem = p;
            ans1 = "";
            ans2 = "";
            ans3 = "";
            type = "程序填空题";
        }
        public PCompletion(string rawPath,string stuAnsPath)
        {
            this.rawPath = rawPath;
            this.stuAnsPath = stuAnsPath;
            type = "PowerPoint操作题";
        }
    }
}
