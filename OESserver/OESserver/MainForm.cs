using System;
using System.Windows.Forms;
using OESserver.UPanel;

namespace OESserver
{
    public partial class MainForm : Form
    {
        public PaperInfo paperInfo;
        public ProMan proMan;
        private PanelControl panelControl;

        public MainForm()
        {
            InitializeComponent();
            proMan = new ProMan();                 //题目管理界面
            paperInfo = new PaperInfo();          //试卷信息界面
            MainPanel.Controls.Add(proMan);
            MainPanel.Controls.Add(paperInfo);
            //ProMan aProMan = new ProMan();
            //MainPanel.Controls.Add(aProMan);

            panelControl = new PanelControl(this);
            panelControl.HideAllPanel();
        }

        private void Lbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panelControl.ChangPanel(Convert.ToInt32(((LinkLabel)sender).Tag));
        }
    }
}