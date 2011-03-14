using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using OES.Properties;
using OES.UPanel;
using OES.Model;

namespace OES.UControl
{
    public partial class ChptList : UserControl
    {
        public static List<choicepro> choiceproL = new List<choicepro>();
        private readonly List<String> chpt_name = new List<string>();
        private readonly List<Button> subPanel = new List<Button>();
        private readonly List<int> chpt_ID = new List<int>();
        private readonly List<int> subPanelStatus = new List<int>();
        private choicepro achoicepro;

        private int btnHeight;
        public int chpt_num = -1;
        public static int count = 20;
        private Panel mainPanel;
        public int page = 1;
        public int totalpage = 1;
        public static int pro_num = 0;
        ProMan aProMan;
        public string selectedchpt;
        public static string click_num="0";
        public static string click_name = "";
        ProList aProList;

        public ChptList(ProMan pm)
        {
            InitializeComponent();
            aProMan = pm;
        }

        private void next_MouseClick(object sender, MouseEventArgs e)
        {
            if (page < totalpage && page > 0)
            {
                page++;
                refresh();
            }
        }

        private void last_MouseClick(object sender, MouseEventArgs e)
        {
            if (page > 1)
            {
                page--;
                refresh();
            }
        }

        public void refresh()
        {
            if (page < totalpage)
            {
                for (int i = 0; i < count; i++)
                {
                    subPanel[i].Controls[0].Text = chpt_name[((page - 1)*count + i)];
                }
            }
            else
            {
                for (int i = 0; i < chpt_name.Count - count*(totalpage - 1); i++)
                {
                    subPanel[i].Controls[0].Text = chpt_name[((totalpage - 1)*count + i)];
                }
                for (int i = chpt_name.Count - count*(totalpage - 1); i < count; i++)
                {
                    subPanel[i].Controls[0].Text = "";
                }
            }
        }



        

        private void ChptList_Resize(object sender, EventArgs e)
        {
            Controls.Clear();
            
            mainPanel = new Panel();
            mainPanel.Height = Height;
            mainPanel.Width = Width;
            Controls.Add(mainPanel);
            btnHeight = Height/(count + 1);
            totalpage = ((chpt_num/count) + 1);
            chpt_num = InfoControl.OesData.FindUnit().Count;
            

            //list赋初值
            for (int i = 0; i < chpt_num; i++)
            {
                chpt_name.Add(InfoControl.OesData.FindUnit()[i].UnitName);
                chpt_ID.Add(Convert.ToInt32(InfoControl.OesData.FindUnit()[i].UnitId));
            }

            var last = new Button();
            last.Width = (Width);
            last.Height = (int)(btnHeight/(1.2));
            last.Location = new Point(0, 0);
            last.BackgroundImage = Resources.up;
            last.BackgroundImageLayout = ImageLayout.Stretch;
            last.FlatStyle = FlatStyle.Popup;
            mainPanel.Controls.Add(last);
            last.MouseClick += last_MouseClick;


            var next = new Button();
            next.Width = (Width);
            next.Height = (int)(btnHeight/(1.2));
            next.Location = new Point(0, Height - next.Height);
            next.BackgroundImage = Resources.down;
            next.BackgroundImageLayout = ImageLayout.Stretch;
            next.FlatStyle = FlatStyle.Popup;
            mainPanel.Controls.Add(next);
            next.MouseClick += next_MouseClick;

            //判断动态生成章节列表
            if (chpt_num > 0)
            {
                for (int i = 0; i < chpt_num; i++)
                {
                    if (i < count)
                    {
                        var temp = new Button();
                        temp.Text = chpt_name[i];
                        temp.Tag = chpt_ID[i];
                        temp.Width = (Width);
                        temp.Height = btnHeight;
                        temp.ForeColor = Color.White;
                        temp.BackColor = Color.Transparent;
                        temp.Font = new Font(new FontFamily("微软雅黑"), 11, FontStyle.Bold);
                        temp.Location = new Point(0, (int) (btnHeight*(i + 0.8)));
                        temp.BackgroundImage = Resources.title;
                        temp.BackgroundImageLayout = ImageLayout.Stretch;
                        mainPanel.Controls.Add(temp);
                        subPanel.Add(temp);
                        subPanelStatus.Add(0);
                        temp.FlatStyle = FlatStyle.Popup;
                        temp.MouseClick += new MouseEventHandler(temp_MouseClick);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        void temp_MouseClick(object sender, MouseEventArgs e)
        {
            click_num =Convert.ToString(((Button)sender).Tag);
            click_name = ((Button)sender).Text;
            newpl();
        }

        //装载题目预览
        public void newpl()
        {
            if (!ProMan.isediting)
            {
                if (aProMan.Controls.Contains(aProList))
                {
                    aProMan.aProList.Dispose();
                }

                switch (aProMan.ProType)
                {
                    case 0:
                        Loadpl(InfoControl.OesData.FindChoiceByUnit(Convert.ToInt32(click_num)), 0);
                        aProList = new ProList(aProMan);
                        aProList.SetBounds(ProMan.ClWidth, ProMan.TpHeight, ProMan.PlWidth, ProMan.PlHeight);
                        aProMan.aProList = aProList;
                        aProMan.Controls.Add(aProList);
                        break;
                    case 1:
                        Loadpl(InfoControl.OesData.FindCompletionByUnit2(Convert.ToInt32(click_num)), 1);
                        aProList = new ProList(aProMan);
                        aProList.SetBounds(ProMan.ClWidth, ProMan.TpHeight, ProMan.PlWidth, ProMan.PlHeight);
                        aProMan.aProList = aProList;
                        aProMan.Controls.Add(aProList);
                        break;
                    case 2:
                        Loadpl(InfoControl.OesData.FindTofByUnit(Convert.ToInt32(click_num)), 2);
                        aProList = new ProList(aProMan);
                        aProList.SetBounds(ProMan.ClWidth, ProMan.TpHeight, ProMan.PlWidth, ProMan.PlHeight);
                        aProMan.aProList = aProList;
                        aProMan.Controls.Add(aProList);
                        break;
                    case 3:
                        Loadpl(InfoControl.OesData.FindExcelProblemContent(), 3);
                        aProList = new ProList(aProMan);
                        aProList.SetBounds(ProMan.ClWidth, ProMan.TpHeight, ProMan.PlWidth, ProMan.PlHeight);
                        aProMan.aProList = aProList;
                        aProMan.Controls.Add(aProList);
                        break;
                    case 4:
                        Loadpl(InfoControl.OesData.FindPowerPointProblemContent(), 4);
                        aProList = new ProList(aProMan);
                        aProList.SetBounds(ProMan.ClWidth, ProMan.TpHeight, ProMan.PlWidth, ProMan.PlHeight);
                        aProMan.aProList = aProList;
                        aProMan.Controls.Add(aProList);
                        break;
                    case 5:
                        Loadpl(InfoControl.OesData.FindWordProblemContent(), 5);
                        aProList = new ProList(aProMan);
                        aProList.SetBounds(ProMan.ClWidth, ProMan.TpHeight, ProMan.PlWidth, ProMan.PlHeight);
                        aProMan.aProList = aProList;
                        aProMan.Controls.Add(aProList);
                        break;
                    case 6:
                        Loadpl(InfoControl.OesData.FindCCompletionProblemContent(), 6);
                        aProList = new ProList(aProMan);
                        aProList.SetBounds(ProMan.ClWidth, ProMan.TpHeight, ProMan.PlWidth, ProMan.PlHeight);
                        aProMan.aProList = aProList;
                        aProMan.Controls.Add(aProList);
                        break;
                    case 7:
                        Loadpl(InfoControl.OesData.FindCModificationProblemContent(), 7);
                        aProList = new ProList(aProMan);
                        aProList.SetBounds(ProMan.ClWidth, ProMan.TpHeight, ProMan.PlWidth, ProMan.PlHeight);
                        aProMan.aProList = aProList;
                        aProMan.Controls.Add(aProList);
                        break;
                    case 8:
                        Loadpl(InfoControl.OesData.FindCFunProblemContent(), 8);
                        aProList = new ProList(aProMan);
                        aProList.SetBounds(ProMan.ClWidth, ProMan.TpHeight, ProMan.PlWidth, ProMan.PlHeight);
                        aProMan.aProList = aProList;
                        aProMan.Controls.Add(aProList);
                        break;
                    case 9:
                        Loadpl(InfoControl.OesData.FindCppCompletionProblemContent(), 9);
                        aProList = new ProList(aProMan);
                        aProList.SetBounds(ProMan.ClWidth, ProMan.TpHeight, ProMan.PlWidth, ProMan.PlHeight);
                        aProMan.aProList = aProList;
                        aProMan.Controls.Add(aProList);
                        break;
                    case 10:
                        Loadpl(InfoControl.OesData.FindCppModificationProblemContent(), 10);
                        aProList = new ProList(aProMan);
                        aProList.SetBounds(ProMan.ClWidth, ProMan.TpHeight, ProMan.PlWidth, ProMan.PlHeight);
                        aProMan.aProList = aProList;
                        aProMan.Controls.Add(aProList);
                        break;
                    case 11:
                        Loadpl(InfoControl.OesData.FindCppFunProblemContent(), 11);
                        aProList = new ProList(aProMan);
                        aProList.SetBounds(ProMan.ClWidth, ProMan.TpHeight, ProMan.PlWidth, ProMan.PlHeight);
                        aProMan.aProList = aProList;
                        aProMan.Controls.Add(aProList);
                        break;
                    default:
                        break;
                }
            }
        }

        //prolist赋初值
        public void Loadpl(List<Problem> pl,int pt)
        {
            choiceproL.Clear();
            pro_num = pl.Count;
            

            //将取出题目属性导入变量列表
            for (int i = 0; i < pro_num; i++)
            {
                achoicepro = new choicepro(pl[i].problemId.ToString(), pl[i].problem);
                choiceproL.Add(achoicepro);
            }
                     

            
        }

        #region Nested type: choicepro

        public class choicepro
        {
            public string chpt;
            public string num;
            public string pro;

            public choicepro(string n, string p)
            {
                num = n;
                pro = p;
            }
        }

        #endregion
    }
}