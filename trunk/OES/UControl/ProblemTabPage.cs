using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OES.Model;

namespace OES.UControl
{
    public class ProblemTabPage:TabPage
    {
        public ProblemType type;
        public ProblemTabPage(string text)
            : base(text)
        {
        }
    }
}
