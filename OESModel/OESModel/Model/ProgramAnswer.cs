using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    public class ProgramAnswer
    {
        
        //答案ID
        public int AID;
        //对应题目的ID
        public int PID;
        //答案对应空的序号
        public int SeqNum;
        //输入
        public string Input;
        //输出（答案）
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
