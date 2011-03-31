﻿using System;
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

        public PaperEditPanel()
        {
            InitializeComponent();
            ItemList = new List<ProblemItem>();
        }

        public void LoadPro<T>(List<T> proList) where T : Problem
        {                        
            while (proList.Capacity > ItemList.Count)
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
            while (proList.Capacity < ItemList.Count)
            {
                ItemPanel.Controls.Remove(ItemList[ItemList.Count-1]);
                ItemList.RemoveAt(ItemList.Count-1);                
            }
            for (int i = 0; i < proList.Capacity; i++)
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
            btnChoice.Visible = InfoControl.TmpPaper.choice.Capacity > 0;
            btnJudge.Visible = InfoControl.TmpPaper.judge.Capacity > 0;
            btnCompletion.Visible = InfoControl.TmpPaper.completion.Capacity > 0;
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
            LoadPro(InfoControl.TmpPaper.ProList[protype]);
        }
        void ItemText_Click(object sender, EventArgs e)
        {
            value = Convert.ToInt32(((ComponentFactory.Krypton.Toolkit.KryptonButton) sender).Tag);
            PanelControl.ChangPanel(18, protype);
        }
    }
}
