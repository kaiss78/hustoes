using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OES.Model;

namespace OES.UPanel
{
    public partial class PaperEditPanel : UserPanel
    {
        public List<LinkLabel> proTypeLink;
        public LinkLabel choiceLink=new LinkLabel();
        public LinkLabel completionLink=new LinkLabel();
        public LinkLabel judgeLink = new LinkLabel();
        public LinkLabel wordLink = new LinkLabel();
        public LinkLabel excelLink = new LinkLabel();
        public LinkLabel pptLink = new LinkLabel();
        public LinkLabel pCLink = new LinkLabel();
        public LinkLabel pFLink = new LinkLabel();
        public LinkLabel pMLink = new LinkLabel();
        public DataTable proList;
        public Paper paper;

        public PaperEditPanel()
        {
            InitializeComponent();

            choiceLink.Tag = 1;
            completionLink.Tag = 2;
            judgeLink.Tag = 3;
            wordLink.Tag = 4;
            excelLink.Tag = 5;
            pptLink.Tag = 6;
            pCLink.Tag = 7;
            pFLink.Tag = 8;
            pMLink.Tag = 9;
        }

        public void LoadChoice()
        {
            
        }

        override public void ReLoad(int paperID)
        {
            this.Visible = true;            
        }
    }
}
