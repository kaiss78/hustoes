using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OES.UPanel;

namespace OES
{
    class PanelControl
    {
        public const int PanelNumber=15;
        public List<UserPanel> panelList = new List<UserPanel>(PanelNumber);

        public PanelControl(MainForm mf)
        {
            for (int i = 0; i < PanelNumber; i++)
            {
                panelList.Add(new UserPanel());                
            }
            for (int i = 0; i < 12; i++)
            {
                panelList[i] = mf.proMan;
            }            
            mf.proMan.PanelID = 0;
            panelList[12] = mf.paperInfo;
            mf.paperInfo.PanelID = 12;
            panelList[13] = mf.paperListPanel;
            mf.paperListPanel.PanelID = 12;
        }

        public void HideAllPanel()
        {
            foreach (UserPanel up in panelList)
            {
                up.Visible = false;
            }
        }

        public void ChangPanel(int x)
        {
            HideAllPanel();
            if (x < 12)
            {
                panelList[x].ReLoad(x);
            }
            else
            {
                panelList[x].ReLoad();
            }
            
        }
    }
}
