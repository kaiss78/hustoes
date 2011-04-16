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
        public const int PanelNumber=20;
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
            mf.paperListPanel.PanelID = 13;

            panelList[14] = mf.studentManage;
            mf.studentManage.PanelID = 14;

            panelList[15] = mf.classManage;
            mf.classManage.PanelID = 15;

            panelList[16] = mf.teacherManage;
            mf.teacherManage.PanelID=16;

            panelList[17] = mf.scoreManage;
            mf.scoreManage.PanelID = 17;

            panelList[18] = mf.proManCho;
            mf.proManCho.PanelID = 18;

            panelList[19] = mf.paperEditPanel;                        
            mf.paperEditPanel.PanelID = 19;
            
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
            if (!ProMan.isediting)
            {
                HideAllPanel();
                switch (x)
                {
                    case 12:
                    case 13:
                    case 14:
                    case 15:
                    case 16:
                    case 17:
                    case 19:
                        panelList[x].ReLoad();
                        break;
                    default:
                        panelList[x].ReLoad(x);
                        break;
                }
            }
            else
            {
                MessageBox.Show("请先保存当前编辑页面");
            }
        }

        static public void ChangPanel(int x, int y)
        {
            HideAllPanel();
            MessageBox.Show(x.ToString() + " " + y.ToString());
            panelList[x].HideAll();
            panelList[x].ReLoad(y);
        }
        static public void ReturnToPaper()
        {
            HideAllPanel();
            panelList[19].Show();
        }
    }
}
