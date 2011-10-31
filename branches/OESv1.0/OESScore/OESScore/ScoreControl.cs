using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OES;

namespace OESScore
{
    class ScoreControl
    {
        public static OESConfig config = new OESConfig("PathConfig.xml",
        new string[,] {
                        {"PaperPath","D:\\OES\\Paper\\"}
                      });
        private static OESData oesData = null;
        public static OESData OesData
        {
            get
            {
                if (oesData == null) { oesData = new OESData(); }
                return ScoreControl.oesData;
            }
            set { ScoreControl.oesData = value; }
        }

    }
}
