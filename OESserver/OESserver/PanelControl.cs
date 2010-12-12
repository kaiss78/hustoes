using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OESserver.UPanel;

namespace OESserver
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
            
            panelList[0] = mf.proMan;
            mf.proMan.PanelID = 0;
            panelList[12] = mf.paperInfo;
            mf.paperInfo.PanelID = 12;            
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
            panelList[x].ReLoad();
        }
    }
}
