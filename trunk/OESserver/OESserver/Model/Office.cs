using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    public class Office : Problem
    {
        public string rawPath;
        public string ansPath;
        public string stuAnsPath;

        public Office()
        {
        }
        public Office(string rawPath, string ansPath, string stuAnsPath)
        {
            this.ansPath = ansPath;
            this.rawPath = rawPath;
            this.stuAnsPath = stuAnsPath;
        }
    }
}
