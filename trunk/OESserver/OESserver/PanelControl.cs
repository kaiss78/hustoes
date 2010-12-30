using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OES.UPanel;

namespace OES
{
    public class PanelControl
    {
        public const int PanelNumber=15;
        static public List<UserPanel> panelList = new List<UserPanel>(PanelNumber);

        public PanelControl( )
        {
        }

        static public void init(MainForm mf)
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
            panelList[14] = mf.paperEditPanel;
        }

        static public void HideAllPanel()
        {
            foreach (UserPanel up in panelList)
            {
                up.Visible = false;
            }
        }

        static public void ChangPanel(int x)
        {
            HideAllPanel();
            switch (x)
            {
                case 12:
                    panelList[x].ReLoad();
                    break;
                case 13:
                    panelList[x].ReLoad();
                    break;
                default:
                    panelList[x].ReLoad(x);
                    break;
            }
        }

        static public void ChangPanel(int x, int y)
        {
            HideAllPanel();
            panelList[x].ReLoad(y);
        }
    }
}
