using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
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
        public int protype;
        public int value;
        private ProPreview propanel;

        public PaperEditPanel()
        {
            InitializeComponent();
            ItemList = new List<ProblemItem>();            
            propanel = new ProPreview();
            propanel.btnSelectPro.Click += new EventHandler(SelectPro_Click);
            propanel.Visible = false;
            ItemPanel.Controls.Add(propanel);            
        }

        public void HideAllItem()
        {
            for (int i = 0; i < ItemList.Count; i++)
            {
                ItemList[i].Visible = false;
            }
        }

        public void LoadPro<T>(List<T> proList) where T : Problem
        {
            while (proList.Count > ItemList.Count)
            {
                tmpItem = new ProblemItem();
                tmpItem.ItemNo.Text = (ItemList.Count+1).ToString();
                tmpItem.ItemText.Text = "-";
                tmpItem.Margin = new System.Windows.Forms.Padding(0);
                tmpItem.Padding = new System.Windows.Forms.Padding(0);
                tmpItem.ItemText.Tag = ItemList.Count + 1;
                tmpItem.ItemText.Click += new EventHandler(ItemText_Click);                    
                ItemList.Add(tmpItem);
                ItemPanel.Controls.Add(tmpItem);
            }
            while (proList.Count < ItemList.Count)
            {
                ItemPanel.Controls.Remove(ItemList[ItemList.Count-1]);
                ItemList.RemoveAt(ItemList.Count-1);                
            }
            for (int i = 0; i < proList.Count; i++)
            {
                ItemList[i].ItemText.Text = "-";
                ItemList[i].Visible = true;
                if (!proList[i].Equals(null))
                {
                    ItemList[i].ItemText.Text = proList[i].problem;
                }
            }
        }

        public void loadPaper()
        {
            proIDList = XMLControl.ReadPaper(this.paper.paperPath);
        }

        override public void ReLoad()
        {
            this.Visible = true;
            btnChoice.Visible = InfoControl.TmpPaper.ProList[0].Count > 0;
            btnCompletion.Visible = InfoControl.TmpPaper.ProList[1].Count > 0;
            btnJudge.Visible = InfoControl.TmpPaper.ProList[2].Count > 0;
            btnWord.Visible = InfoControl.TmpPaper.officeWord.exist;
            btnPPT.Visible = InfoControl.TmpPaper.officePPT.exist;
            btnExcel.Visible = InfoControl.TmpPaper.officeExcel.exist;
            btnPModif.Visible = InfoControl.TmpPaper.pModif.exist;
            btnPCompletion.Visible = InfoControl.TmpPaper.pCompletion.exist;
            btnPFunction.Visible = InfoControl.TmpPaper.pFunction.exist;
            //ItemPanel.Controls.Clear();
        }

        private void BtnProType_Click(object sender, EventArgs e)
        {
            protype = Convert.ToInt32(((ComponentFactory.Krypton.Toolkit.KryptonButton) sender).Tag);
            if ((InfoControl.TmpPaper.programState == 1) && (protype > 5))
            {
                protype = protype + 3;
            }
            if (protype < 3)
            {
                propanel.Visible = false;
                LoadPro(InfoControl.TmpPaper.ProList[protype]);
            }
            else
            {
                HideAllItem();
                propanel.Visible = true;
            }
        }

        private void SelectPro_Click(object sender, EventArgs e)
        {
            if (protype > 8)
            {
                PanelControl.ChangPanel(18, protype-3);
            }
            else
            {
                PanelControl.ChangPanel(18, protype);
            }
        }

        void ItemText_Click(object sender, EventArgs e)
        {
            InfoControl.Value = Convert.ToInt32(((ComponentFactory.Krypton.Toolkit.KryptonButton)sender).Tag);
            PanelControl.ChangPanel(18, protype);            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            XMLControl.CreatePaperXML(Config.TempPaperPath + InfoControl.TmpPaper.paperID+".xml", InfoControl.TmpPaper.paperID);
            for(int i=0;i<InfoControl.TmpPaper.ProList[0].Count;i++)
            {
                XMLControl.AddProblemToPaper(ProblemType.Choice, InfoControl.TmpPaper.ProList[0][i].problemId, InfoControl.TmpPaper.score_choice);
            }
            for (int i = 0; i < InfoControl.TmpPaper.ProList[1].Count; i++)
            {
                XMLControl.AddProblemToPaper(ProblemType.Completion, InfoControl.TmpPaper.ProList[1][i].problemId, InfoControl.TmpPaper.score_completion);
            }
            for (int i = 0; i < InfoControl.TmpPaper.ProList[2].Count; i++)
            {
                XMLControl.AddProblemToPaper(ProblemType.Tof, InfoControl.TmpPaper.ProList[2][i].problemId, InfoControl.TmpPaper.score_judge);
            }
            if (InfoControl.TmpPaper.officeWord.problemId != -1)
            {
                XMLControl.AddProblemToPaper(ProblemType.Word, InfoControl.TmpPaper.officeWord.problemId, InfoControl.TmpPaper.score_officeWord);
            }
            if (InfoControl.TmpPaper.officeExcel.problemId != -1)
            {
                XMLControl.AddProblemToPaper(ProblemType.Excel, InfoControl.TmpPaper.officeExcel.problemId, InfoControl.TmpPaper.score_officeExcel);
            }
            if (InfoControl.TmpPaper.officePPT.problemId != -1)
            {
                XMLControl.AddProblemToPaper(ProblemType.PowerPoint, InfoControl.TmpPaper.officePPT.problemId, InfoControl.TmpPaper.score_officePPT);
            }
            if (InfoControl.TmpPaper.pCompletion.problemId != -1)
            {
                XMLControl.AddProblemToPaper(ProblemType.ProgramCompletion, InfoControl.TmpPaper.pCompletion.problemId, InfoControl.TmpPaper.score_pCompletion);
            }
            if (InfoControl.TmpPaper.pModif.problemId != -1)
            {
                XMLControl.AddProblemToPaper(ProblemType.ProgramModification, InfoControl.TmpPaper.pModif.problemId, InfoControl.TmpPaper.score_pModif);
            }
            if (InfoControl.TmpPaper.pFunction.problemId != -1)
            {
                XMLControl.AddProblemToPaper(ProblemType.ProgramFun, InfoControl.TmpPaper.pFunction.problemId, InfoControl.TmpPaper.score_pFunction);
            }
            PanelControl.ReturnToMain();
        }
    }
}
