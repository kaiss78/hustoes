using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OES.Model;

namespace OES
{
    public class InfoControl
    {
        private static OESData oesData = null;
        public static OESData OesData
        {
            get
            {
                if (oesData == null) { oesData = new OESData(); }
                return InfoControl.oesData;
            }
            set { InfoControl.oesData = value; }
        }

        private static Teacher teacher=null;
        public static Teacher User
        {
            get
            {
                if (teacher == null) { teacher = new Teacher(); }
                return InfoControl.teacher;
            }
            set { InfoControl.teacher = value; }
        }

        private static Paper paper = null;
        public static Paper TmpPaper
        {
            get
            {
                if (paper == null){paper = new Paper();}
                return InfoControl.paper;
            }
            set { InfoControl.paper = value; }
        }

        #region 窗体逻辑控制
        private static LoginForm loginForm = null;
        public static LoginForm LoginForm
        {
            get
            {
                if (loginForm == null || loginForm.IsDisposed) { LoginForm = new LoginForm(); }
                return InfoControl.loginForm;
            }
            set { InfoControl.loginForm = value; }
        }
        
        private static MainForm mainForm = null;
        public static MainForm MainForm
        {
            get
            {
                if (mainForm == null || mainForm.IsDisposed) {MainForm = new MainForm();}
                return InfoControl.mainForm;
            }
            set { InfoControl.mainForm = value; }
        }

        #endregion 窗体逻辑控制
    }
}
