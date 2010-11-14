﻿using System;
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
        public List<Problem> problemList;

        public Paper()
        {
            choice = new List<Choice>();
            completion = new List<Completion>();
            judge = new List<Judge>();
            pCompletion = new PCompletion();
            pModif = new PModif();
            pFunction = new PFunction();
            problemList = new List<Problem>();
        }

        public void Add(Problem p)
        {
            if (p is Choice)
            {
                choice.Add((Choice)p);
            }
            else if (p is Completion)
            {
                completion.Add((Completion)p);
            }
            else if (p is Judge)
            {
                judge.Add((Judge)p);
            }
            else if (p is PCompletion)
            {
                pCompletion = (PCompletion)p;
            }
            else if (p is PModif)
            {
                pModif = (PModif)p;
            }
            else if (p is PFunction)
            {
                pFunction = (PFunction)p;
            }
            problemList.Add(p);
        }
    }
}
