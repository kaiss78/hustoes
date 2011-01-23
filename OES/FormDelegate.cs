using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES
{
    public class FormDelegate
    {
        public delegate void DispatchMsg(MsgType mt, object o);
        public static DispatchMsg dispatchMsgs = dispatchMsg;
        public static void dispatchMsg(MsgType mt, object o)
        {
            switch (mt)
            {
                case MsgType.LoginOk:
                    {
                        ClientControl.LoginForm.Login(true);
                        break;
                    }
                case MsgType.LoginError:
                    {
                        ClientControl.LoginForm.Login(false);
                        break;
                    }
            }
        }
    }
    public enum MsgType
    {
        LoginOk,
        LoginError
    }
}
