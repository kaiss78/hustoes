using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OES.Error
{
    public class ErrorControl
    {
        public static void ShowError(ErrorType et)
        {
            switch(et)
            {
                case ErrorType.LoginNoPersonError:
                    MessageBox.Show(ErrorTable.LoginNoPersonError);
                    break;
            }
        }
    }
}
