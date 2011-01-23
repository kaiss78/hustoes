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
        private ProblemDGV proDGV;

        public PaperEditPanel()
        {
            InitializeComponent();
            proDGV=new ProblemDGV();
            ControlPanel.Controls.Add(proDGV);
            proDGV.Dock = System.Windows.Forms.DockStyle.Fill;

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
                    proDGV.LoadPro(InfoControl.TmpPaper.choice);
                    break;
                case 1: 
                    proDGV.LoadPro(InfoControl.TmpPaper.judge);
                    break;
                case 2: 
                    proDGV.LoadPro(InfoControl.TmpPaper.completion);
                    break;
                default:
                    break;
            }
        }        
    }
}
