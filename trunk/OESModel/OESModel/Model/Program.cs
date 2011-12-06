using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    public class Program:Problem
    {
        public Language language;
        public ProType Type;
        public List<ProgramAnswer> ansList;

        public Program()
        { 
        }

        public enum ProType
        {
            Completion=0,
            Judgment=1,
            Modify=2
        }
        public enum Language
        {
            C=0,
            CPP=1,
            VB=2            
        }
    }
}
