using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.keyandValue
{
    public class ListItem
    {
        public string key { get; set; }
        public string value { get; set; }

        public ListItem(String pKey,string pValue)
        {
            this.key = pKey;
            this.value = pValue;
        }
    }
}
