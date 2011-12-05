using System;
using System.Collections.Generic;
 
using System.Text;
using OES.Model;
using OES.Error;
using OES.Net;
using System.Threading;
using System.IO;

namespace OES
{   
    class ClientControl
    {
        static public Student student;
        static public Paper paper=new Paper();
        private static int currentProblemNum = 0;
        public static Boolean isResume = false;
        public static string password = "123456";
        /// <summary>
        /// 是否从monitor端获得密码
        /// </summary>
        public static bool isGetPwd = false;

        #region 窗体逻辑控制
        private static LoginForm loginForm = null;

        public static LoginForm LoginForm
        {
            get 
            {
                if (loginForm == null || loginForm.IsDisposed) { LoginForm = new LoginForm();}
                loginForm.CreateControl();
                return ClientControl.loginForm; 
            }
            set { ClientControl.loginForm = value; }
        }

        private static ExamForm examForm = null;

        public static ExamForm ExamForm
        {
            get
            {

                if (examForm == null || examForm.IsDisposed) { ExamForm = new ExamForm();}
                examForm.CreateControl();
                return ClientControl.examForm; 
            }
            set { ClientControl.examForm = value; }
        }
        private static ControlBar controlBar = null;

        public static ControlBar ControlBar
        {
            get 
            {
                if (controlBar == null || controlBar.IsDisposed) { ControlBar = new ControlBar();}
                controlBar.CreateControl();
                return ClientControl.controlBar; 
            }
            set { ClientControl.controlBar = value; }
        }
        private static MainForm mainForm = null;

        public static MainForm MainForm
        {
            get 
            {
                if (mainForm == null || mainForm.IsDisposed) { MainForm = new MainForm();}
                mainForm.CreateControl();
                return ClientControl.mainForm; 
            }
            set { ClientControl.mainForm = value; }
        }
        private static WaitingForm waitingForm = null;

        public static WaitingForm WaitingForm
        {
            get 
            {
                if (waitingForm == null || waitingForm.IsDisposed) { WaitingForm = new WaitingForm();}
                waitingForm.CreateControl();
                return ClientControl.waitingForm; 
            }
            set { ClientControl.waitingForm = value; }
        }

        private static TeaPassForm teaPassForm = null;

        public static TeaPassForm TeaPassForm
        {
            get 
            {
                if (teaPassForm == null || teaPassForm.IsDisposed) { TeaPassForm = new TeaPassForm();} 
                teaPassForm.CreateControl(); 
                return ClientControl.teaPassForm; 
            }
            set { ClientControl.teaPassForm = value; }
        }
        #endregion 窗体逻辑控制

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
                ClientControl.MainForm.JumpPro(paper.problemList[currentProblemNum].type, paper.problemList[currentProblemNum].orderId);
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
        public static void AddOfficeWord(OfficeWord word)
        {
            paper.Add(word);
        }
        public static OfficeWord GetOfficeWord(int proID)
        {
            return paper.officeWord[proID];
        }
        public static void AddOfficeExcel(OfficeExcel excel)
        {
            paper.Add(excel);
        }
        public static OfficeExcel GetOfficeExcel(int proID)
        {
            return paper.officeExcel[proID];
        }
        public static void AddOfficePowerPoint(OfficePowerPoint ppt)
        {
            paper.Add(ppt);
        }
        public static OfficePowerPoint GetOfficePowerPoint(int proID)
        {
            return paper.officePPT[proID];
        }

        public static void AddProgramCompletion(PCompletion pCompletion)
        {
            paper.Add(pCompletion);
        }
        public static PCompletion GetProgramCompletion(int proID)
        {
            return paper.pCompletion[proID];
        }
        public static void AddProgramModif(PModif pModif)
        {
            paper.Add(pModif);
        }
        public static PModif GetProgramModif(int proID)
        {
            return paper.pModif[proID];
        }
        public static void AddProgramFunction(PFunction pFunction)
        {
            paper.Add(pFunction);
        }
        public static PFunction GetProgramFunction(int proID)
        {
            return paper.pFunction[proID];
        }
        //总控类设置当前题目号
        internal static void JumpToPro(int p)
        {
            CurrentProblemNum = p;
        }

        public static void SendInPaper()
        {
            if (RARHelper.Exists())
            {
                ClientEvt.getPassword();
                while (!isGetPwd) ;
                if (File.Exists(Config.stuPath + student.ID + ".rar")) File.Delete(Config.stuPath + student.ID + ".rar");
                Thread.Sleep(1000);
                RARHelper.CompressRAR(Config.stuPath, student.ID + ".rar", Config.stuPath, password);
                ClientEvt.Answer = Config.stuPath + student.ID + ".rar";
                ClientEvt.Client.SendFile();
                Thread.Sleep(1000);
                password = "123456";
                isGetPwd = false;
            }
            else
            {
                ErrorControl.ShowError(ErrorType.RARNotExist);
            }
        }
    }
}
