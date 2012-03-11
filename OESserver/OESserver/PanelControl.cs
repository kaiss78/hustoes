using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OES.UPanel;
using OES.Model;

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

            panelList[0] = mf.quesBankForm;
            mf.quesBankForm.PanelID = 0;
            
            panelList[1] = mf.paperListPanel;
            mf.paperListPanel.PanelID = 1;

            panelList[2] = mf.paperInfo;
            mf.paperInfo.PanelID = 2;

            panelList[3] = mf.studentManage;
            mf.studentManage.PanelID = 3;

            panelList[4] = mf.classManage;
            mf.classManage.PanelID = 4;

            panelList[5] = mf.teacherManage;
            mf.teacherManage.PanelID=5;

            panelList[6] = mf.scoreManage;
            mf.scoreManage.PanelID = 6;

            //panelList[7] = mf.paperEditPanel;                        
            //mf.paperEditPanel.PanelID = 7;


            panelList[8] = mf.addQuestionPanel;
            mf.addQuestionPanel.PanelID = 8;
            


            panelList[9] = mf.bulkImport;
            mf.bulkImport.PanelID = 9;


            panelList[12] = mf.paperInfo;
            mf.paperInfo.PanelID = 12;

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
                case 0:
                case 1:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                    panelList[x].ReLoad();
                    break;
                case 2:
                    InfoControl.TmpPaper = new OES.Model.Paper();
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
            panelList[x].HideAll();
            panelList[x].ReLoad(y);
        }


        static public void QueUpdate(int PID,int PType,int Course,String Chapter,int level)
        {
            HideAllPanel();
            panelList[8].ReLoad(PID, PType,Course,Chapter,level);
           
            
        }

        static public void ReturnToPaper()
        {
            HideAllPanel();
            panelList[19].Show();
        }

        static public void EditPaper()
        {
            HideAllPanel();
            panelList[12].Show();
            panelList[12].ReLoad(InfoControl.TmpPaper);
        }

        static public void ReturnToMain()
        {
            HideAllPanel();
        }
    }
}
