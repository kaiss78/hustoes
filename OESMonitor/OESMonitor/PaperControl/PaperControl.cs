using System;
using System.Collections.Generic;
 
using System.Text;
using OES;
using OES.Model;

namespace OESMonitor
{
    public class PaperControl
    {
        public static OESConfig PathConfig = new OESConfig("PathConfig.xml",new string[,]{
            {"StuAns",@"C:\OES\Student\"},
            {"StuRarKey",@"C:\OES\Student\Key\"},
            {"TmpPaper",@"C:\OES\TmpPaper\"}
        });
        public static OESConfig PwdConfig = new OESConfig("PwdConfig.xml", new string[,]{
            {"Password","123"}
        });
        public static OESConfig AdminConfig = new OESConfig("AdminConfig.xml", new string[,]{
            {"IsAdmin","false"}
        });
        public static OESData OesData = new OESData();
        public static int TestTime = 120;

        #region 考生状态记录
        public static object syncObjct = new object();
        private static Dictionary<Student, ExamState> studentCollection = new Dictionary<Student, ExamState>();

        public static Dictionary<Student, ExamState> StudentCollection
        {
            get 
            {
                lock (syncObjct)
                {
                    return PaperControl.studentCollection;
                }
            }
        }
        public static Dictionary<ExamState,string> MapExamStateString=new Dictionary<ExamState,string>(){
        {ExamState.Login,"已登录"},{ExamState.SendPaper,"已发卷"},{ExamState.Examing,"正在考试"},{ExamState.ResumeExaming,"恢复考试"},{ExamState.RestartExaming,"重新考试"},{ExamState.ApplyRestart,"申请重考"},{ExamState.HandIn,"已交卷"}};
        public static void ChangeStudentState(Student s,ExamState e)
        {
            if (StudentCollection.ContainsKey(s))
            {
                StudentCollection[s] = e;
            }
            else
            {
                StudentCollection.Add(s, e);
            }
        }
        #endregion
    }
    public enum ExamState
    {
        Login=2,
        Examing=3,
        HandIn=4,
        SendPaper=5,
        ResumeExaming=6,
        ApplyRestart=7,
        RestartExaming=8
    }
}
