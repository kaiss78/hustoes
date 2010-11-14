using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.XMLFile
{
    class XMLControl
    {
        public static XMLAssistant paperXML;
        public static XMLAssistant scoreXML;
        public static XMLAssistant studentAnsXML;
        public static XMLAssistant paperAnsXML;
        public static XMLAssistant logXML;
        public static void Client(int paperId,int studentId)
        {
            paperXML = new XMLAssistant("paper_" + paperId.ToString()+".xml", XMLType.Paper, new string[] { paperId.ToString() });
            logXML = new XMLAssistant("log.xml", XMLType.Log, null);
            studentAnsXML = new XMLAssistant("SAnswer.xml", XMLType.StudentAnswer, new string[] { paperId.ToString() });
        }
    }
}
