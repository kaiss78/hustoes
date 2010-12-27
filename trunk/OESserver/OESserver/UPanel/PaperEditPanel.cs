using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OES.UPanel
{
    public partial class PaperEditPanel : UserControl
    {
        public List<LinkLabel> proTypeLink;
        public LinkLabel choiceLink;
        public LinkLabel completionLink;
        public LinkLabel judgeLink;
        public LinkLabel wordLink;
        public LinkLabel excelLink;
        public LinkLabel pptLink;
        public LinkLabel pCLink;
        public LinkLabel pFLink;
        public LinkLabel pMLink;

        public PaperEditPanel()
        {
            InitializeComponent();
        }

    }
}
