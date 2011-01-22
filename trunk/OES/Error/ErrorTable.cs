using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Error
{
    public class ErrorTable
    {
        public static string LoginNoPersonError = "对不起，你的密码错误！";
        public static string RARNotExist = "本机未装RAR软件！";
        public static string ExistAnsXML = "您已经完成考试，无法恢复考试！";
        public static string TeacherPassWrong = "教师验证码错误！";
    }
    public enum ErrorType
    {
        LoginNoPersonError,
        LoginWPasswordError,
        RARNotExist,
        ExistAnsXML,
        TeacherPassWrong
    }
}
