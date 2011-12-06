using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    public class ProgramAnswer
    {
        
        int AID;
        int PID;       
        int SeqNum;
        string Input;
        string Output;

        public ProgramAnswer()
        {
            AID = 0;
            PID = 0;
            SeqNum = 0;
            Input = "";
            Output = "";

        }

        public ProgramAnswer(int pid, int seqnum, string input, string output)
        {
            PID = pid;
            SeqNum = seqnum;
            Input = input;
            Output = output;
        }

        public ProgramAnswer(int aid,int pid, int seqnum, string input, string output)
        {
            AID = aid;
            PID = pid;
            SeqNum = seqnum;
            Input = input;
            Output = output;
        }

    }
}
