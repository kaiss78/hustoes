using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Error
{
    public class ErrorTable
    {
        public static string LoginNoPersonError = "对不起，你的密码错误！";
    }
    public enum ErrorType
    {
        LoginNoPersonError,
        LoginWPasswordError
    }
}
