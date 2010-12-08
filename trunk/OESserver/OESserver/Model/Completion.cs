using System.Collections.Generic;

namespace OES.Model
{
    internal class Completion : Problem
    {
        public List<string> ans;
        public string stuAns;

        public Completion()
        {
            type = "填空题";
        }

        public Completion(string p)
        {
            problem = p;
            stuAns = "";
            ans = new List<string>();
            type = "填空题";
        }
    }
}