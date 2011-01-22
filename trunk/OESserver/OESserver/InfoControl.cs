using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES
{
    public class InfoControl
    {
        private static OESData oesData = null;
        public static OESData OesData
        {
            get
            {
                if (oesData == null) { OesData = new OESData(); }
                return InfoControl.oesData;
            }
            set { InfoControl.oesData = value; }
        }
    }
}
