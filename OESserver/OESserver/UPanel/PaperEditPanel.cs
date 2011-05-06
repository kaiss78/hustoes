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
        static public List<ProblemItem> ItemList;
        static public ProPreview propanel;
        public int protype;
        public int value;
        private readonly ProblemType[] PT ={ ProblemType.Choice, ProblemType.Completion, ProblemType.Tof, 
                                                                      ProblemType.Excel, ProblemType.PowerPoint, ProblemType.Word, 
                                                                      ProblemType.ProgramCompletion, ProblemType.ProgramModification, ProblemType.ProgramFun };

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

            btnExcel.Visible = InfoControl.TmpPaper.ProList[3][0].exist;
            btnPPT.Visible = InfoControl.TmpPaper.ProList[4][0].exist;
            btnWord.Visible = InfoControl.TmpPaper.ProList[5][0].exist;
            btnPCompletion.Visible = InfoControl.TmpPaper.ProList[6][0].exist;
            btnPModif.Visible = InfoControl.TmpPaper.ProList[7][0].exist;
            btnPFunction.Visible = InfoControl.TmpPaper.ProList[8][0].exist;
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
            for (int k = 0; k < 9; k++)
            {
                for (int i = 0; i < InfoControl.TmpPaper.ProList[k].Count; i++)
                {
                    if (InfoControl.TmpPaper.ProList[k][i].problemId != -1)
                    {
                        XMLControl.AddProblemToPaper(PT[k], InfoControl.TmpPaper.ProList[k][i].problemId, InfoControl.TmpPaper.ProList[k][i].score);
                    }
                }
            }
            PanelControl.ReturnToMain();
        }
    }
}
