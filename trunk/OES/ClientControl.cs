using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OES.Model;

namespace OES
{   
    class ClientControl
    {        
        static private Paper paper= new Paper();
        public ClientControl()
        {         
        }
        public static void AddChoice(Choice choice)
        {
            paper.choice.Add(choice);
        }
    }
}
