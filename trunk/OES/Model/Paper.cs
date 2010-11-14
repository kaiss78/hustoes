using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    class Paper
    {
        public List<Choice> choice;
        public List<Completion> completion;
        public List<Judge> judge;
        public PCompletion pCompletion;
        public PModif pModif;
        public PFunction pFunction;

        public Paper()
        {
            choice = new List<Choice>();
            completion = new List<Completion>();
            judge = new List<Judge>();
            pCompletion = new PCompletion();
            pModif = new PModif();
            pFunction = new PFunction();
        }
    }
}
