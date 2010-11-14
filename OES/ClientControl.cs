using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OES.Model;

namespace OES
{   
    class ClientControl
    {        
        static public Paper paper= new Paper();

        public static void AddChoice(Choice choice)
        {
            paper.choice.Add(choice);
        }
        public static Choice GetChoice(int proID)
        {
            return paper.choice[proID];
        }
        public static void AddCompletion(Completion completion)
        {
            paper.completion.Add(completion);
        }

        public static Completion GetCompletion(int proID)
        {
            return paper.completion[proID];
        }

        public static void AddJudge(Judge judge)
        {
            paper.judge.Add(judge);
        }
        public static Judge GetJudge(int proID)
        {
            return paper.judge[proID];
        }
    }
}
