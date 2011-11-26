using System;
using System.Collections.Generic;
 
using System.Text;

namespace OES.Error
{
    public class ErrorTable
    {
        public static string LoginNoPersonError = "登录失败！（1.密码用户名不正确 2.教师未设置试卷 3.您已经交卷 4.该ID已经登录）";
        public static string RARNotExist = "本机未装RAR软件！";
        public static string ExistAnsXML = "您已经完成考试，无法恢复考试！";
        public static string TeacherPassWrong = "教师验证码错误！";
        public static string ServerConnectFailure = "服务器连接出错！";
        public static string NoLogXML = "未发现日志文件，无法恢复考试！";
    }
    public enum ErrorType
    {
        LoginNoPersonError,
        LoginWPasswordError,
        RARNotExist,
        ExistAnsXML,
        NoLogXML,
        TeacherPassWrong,
        ServerConnectFailure
    }
}
