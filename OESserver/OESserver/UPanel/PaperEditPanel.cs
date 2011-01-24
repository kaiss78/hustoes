using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OES.Model;
using OES.UControl;
using OES.XMLFile;

namespace OES.UPanel
{
    public partial class PaperEditPanel : UserPanel
    {
        public Paper paper;
        public OESData oesData;
        public List<IdScoreType> proIDList;
        private ProblemItem tmpItem;
        public List<ProblemItem> ItemList;   

        public PaperEditPanel()
        {
            InitializeComponent();
        }

        public void LoadPro<T>(List<T> proList) where T : Problem
        {
            ItemList = new List<ProblemItem>();
            ItemPanel.Controls.Clear();
            for (int i = 0; i < proList.Capacity; i++)
            {
                tmpItem = new ProblemItem();
                tmpItem.ItemNo.Text = (i + 1).ToString();
                tmpItem.ItemText.Text = "-";
                
                if (!proList[i].Equals(null))
                {
                    tmpItem.ItemText.Text = proList[i].problem;
                }                
                ItemList.Add(tmpItem);
                ItemPanel.Controls.Add(tmpItem);
                tmpItem.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
                tmpItem.Padding = new System.Windows.Forms.Padding(1, 1, 1, 1);                
            }
        }

        public void loadPaper()
        {
            proIDList = XMLControl.ReadPaper(this.paper.paperPath);
        }

        override public void ReLoad()
        {
            this.Visible = true;
            btnChoice.Visible = InfoControl.TmpPaper.choice.Capacity > 0;
            btnJudge.Visible = InfoControl.TmpPaper.judge.Capacity > 0;
            btnCompletion.Visible = InfoControl.TmpPaper.completion.Capacity > 0;
            
            btnWord.Visible = InfoControl.TmpPaper.officeWord.exist;
            btnPPT.Visible = InfoControl.TmpPaper.officePPT.exist;
            btnExcel.Visible = InfoControl.TmpPaper.officeExcel.exist;
            btnPModif.Visible = InfoControl.TmpPaper.pModif.exist;
            btnPCompletion.Visible = InfoControl.TmpPaper.pCompletion.exist;
            btnPFunction.Visible = InfoControl.TmpPaper.pFunction.exist;
        }

        private void BtnProType_Click(object sender, EventArgs e)
        {
          
            switch (Convert.ToInt32(((ComponentFactory.Krypton.Toolkit.KryptonButton)sender).Tag))
            {
                case 0:
                    LoadPro(InfoControl.TmpPaper.choice);
                    break;
                case 1: 
                    LoadPro(InfoControl.TmpPaper.judge);
                    break;
                case 2: 
                    LoadPro(InfoControl.TmpPaper.completion);
                    break;
                default:
                    break;
            }
        }        
    }
}
