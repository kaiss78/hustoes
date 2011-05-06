using System;
using System.Collections.Generic;
 
using System.Text;
using OES;

namespace OESMonitor.PaperControl
{
    public class PaperControl
    {
        private static OESData oesData = null;
        public static OESData OesData
        {
            get
            {
                if (oesData == null) { oesData = new OESData(); }
                return PaperControl.oesData;
            }
            set { PaperControl.oesData = value; }
        }

        private static Config config = null;
        public static Config OESConfig
        {
            get
            {
                if(config==null){config=new Config();}
                return PaperControl.config;
            }
            set { PaperControl.config = value; }
        }
    }
}
