using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OESOffice
{
    public class DisplayObject
    {
        public string displayText;
        public string useText;
        public object value;

        public DisplayObject(string dt, string ut, object v)
        {
            displayText = dt;
            useText = ut;
            value = v;
        }

        public override string ToString()
        {
            return displayText + ":" + value.ToString();
        }
    }

}
