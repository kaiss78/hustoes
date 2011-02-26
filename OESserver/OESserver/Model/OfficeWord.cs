using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    public class OfficeWord:Office
    {
        

        public OfficeWord()
        {            
            type = "Word操作题";
        }

        public OfficeWord(string p)
        {
            problem = p;
            type = "Word操作题";
        }
        public OfficeWord(string rawPath, string ansPath, string stuAnsPath):base(rawPath,ansPath,stuAnsPath)
        {
            
            type = "Word操作题";
        }
    }
}
