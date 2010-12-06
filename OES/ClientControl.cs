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
        private static int currentProblemNum = 0;
        public static Boolean isResume = false;
        /// <summary>
        /// 当前题目号属性，可以自动进行列表状态切换
        /// </summary>
        public static  int CurrentProblemNum
        {
            set
            {
                currentProblemNum = value;
                MainForm.problemsList.setDoing(value);
                //调回主界面进行界面切换
                MainForm.mf.JumpPro(paper.problemList[currentProblemNum].type, paper.problemList[currentProblemNum].orderId);
            }
            get
            {
                return currentProblemNum;
            }
        }
        public static void SetDone(int id)
        {
            MainForm.problemsList.setDone(id);
        }
        public static void AddChoice(Choice choice)
        {
            paper.Add(choice);
        }
        public static Choice GetChoice(int proID)
        {
            return paper.choice[proID];
        }
        public static void AddCompletion(Completion completion)
        {
            paper.Add(completion);
        }

        public static Completion GetCompletion(int proID)
        {
            return paper.completion[proID];
        }

        public static void AddJudge(Judge judge)
        {
            paper.Add(judge);
        }
        public static Judge GetJudge(int proID)
        {
            return paper.judge[proID];
        }

        //总控类设置当前题目号
        internal static void JumpToPro(int p)
        {
            CurrentProblemNum = p;
        }
    }
}
