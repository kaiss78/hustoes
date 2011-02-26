using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    public class OfficeExcel:Office
    {
        public string rawPath;
        public string ansPath;
        public string stuAnsPath;        
        public OfficeExcel()
        {            
            type = "Excel操作题";
        }

        public OfficeExcel(string p)
        {
            problem = p;
            type = "Excel操作题";
        }

        public OfficeExcel(string rawPath, string ansPath, string stuAnsPath):base(rawPath,ansPath,stuAnsPath)
        { 
           type = "Excel操作题";
        }
    }
}
