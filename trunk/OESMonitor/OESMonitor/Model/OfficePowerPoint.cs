using System;
using System.Collections.Generic;
 
using System.Text;

namespace OESMonitor.Model
{
    public class OfficePowerPoint:Problem
    {
        public string rawPath;
        public string ansPath;
        public string stuAnsPath;

        public OfficePowerPoint()
        {            
            type = "PowerPoint操作题";
        }

        public OfficePowerPoint(string p)
        {
            problem = p;
            type = "PowerPoint操作题";
        }

        public OfficePowerPoint(string rawPath, string ansPath, string stuAnsPath)
        {
            this.ansPath = ansPath;
            this.rawPath = rawPath;
            this.stuAnsPath = stuAnsPath;
            type = "PowerPoint操作题";
        }
    }
}
