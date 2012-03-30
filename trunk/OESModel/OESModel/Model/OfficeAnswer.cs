using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OESModel.Model
{
    class OfficeAnswer
    {
        public string OfficeFile;
        public string XMLFile;
        public OfficeAnswer(string office, string xml)
        {
            OfficeFile = office;
            XMLFile = xml;
        }
        public OfficeAnswer()
        { }
    }
}
