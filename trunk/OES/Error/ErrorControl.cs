using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace OES.Error
{
    public class ErrorControl
    {
        public static void ShowError(ErrorType et)
        {

            MessageBox.Show(Type.GetType("OES.Error.ErrorTable").GetField(et.ToString()).GetValue(null).ToString());
            //switch (et)
            //{
            //    case ErrorType.LoginNoPersonError:
            //        MessageBox.Show(ErrorTable.LoginNoPersonError);
            //        break;
            //    case ErrorType.RARNotExist:
            //        MessageBox.Show(ErrorTable.RARNotExist);
            //        break;
            //}
        }
    }
}
