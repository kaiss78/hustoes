using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    public class OfficePowerPoint:Office
    {
       
        public OfficePowerPoint()
        {            
            type = "PowerPoint操作题";
        }

        public OfficePowerPoint(string p)
        {
            problem = p;
            type = "PowerPoint操作题";
        }

        public OfficePowerPoint(string rawPath, string ansPath, string stuAnsPath):base(rawPath,ansPath,stuAnsPath)
        {
            type = "PowerPoint操作题";
        }
    }
}
