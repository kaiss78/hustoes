using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    public class ProgramAnswer
    {
        
        public int AID;
        public int PID;
        public int SeqNum;
        public string Input;
        public string Output;

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

        public ProgramAnswer(int seqnum, string input, string output)
        {            
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
