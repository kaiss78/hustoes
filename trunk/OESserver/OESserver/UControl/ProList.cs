using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using OES.Properties;
using OES.UPanel;
using OES.Model;

namespace OES.UControl
{
    public partial class ProList : UserControl
    {
 
        private readonly List<Button> subPanel = new List<Button>();
        private readonly List<int> subPanelStatus = new List<int>();
        private readonly List<Label> titleList = new List<Label>();
        public List<Button> checkList = new List<Button>();
        public List<check> acheckproList = new List<check>();
    
        public static int btnHeight;
        public static int choWidth;
        public static int count = 10;
        public static int listWidth;
        public Panel mainPanel;
        public static int numWidth;
        public int page = 1;
        public static int proWidth;

        public int totalpage = 1;
        ProMan aProMan;
        public static string click_proid = "";


        public ProList(ProMan pm)
        {
            InitializeComponent();
            aProMan=pm;

        }



        private void ProList_Resize(object sender, EventArgs e)
        {
            Controls.Clear();
            mainPanel = new Panel();
            mainPanel.Height = Height;
            mainPanel.Width = Width;
            Controls.Add(mainPanel);

            totalpage = ((ChptList.pro_num / count) + 1);
            

            mainPanel.AutoScroll = true;
            

            //判断动态生成题目列表
            for (int i = 0; i < ChptList.pro_num; i++)
            {
                var checkButton = new Button();
                checkButton.Height = btnHeight;
                checkButton.Width = choWidth;
                checkButton.Location = new Point(0, (btnHeight * i));
                checkButton.BackgroundImage = Resources.circle_black;
                checkButton.BackgroundImageLayout = ImageLayout.Stretch;
                checkButton.Tag = i;

                var templ2 = new Label();
                templ2.Height = btnHeight;
                templ2.ForeColor = Color.White;
                templ2.BackColor = Color.Transparent;
                templ2.Tag = ChptList.choiceproL[i].num;
                templ2.Font = new Font(new FontFamily("微软雅黑"), 20, FontStyle.Bold);
                templ2.TextAlign = ContentAlignment.MiddleCenter;
                templ2.AutoSize = false;
                

                var templ3 = new Label();
                templ3.Height = btnHeight;
                templ3.ForeColor = Color.White;
                templ3.BackColor = Color.Transparent;
                templ3.Tag = ChptList.choiceproL[i].num;
                templ3.Font = new Font(new FontFamily("微软雅黑"), 15, FontStyle.Bold);
                templ3.TextAlign = ContentAlignment.MiddleCenter;
                templ3.AutoSize = false;


                templ2.Location = new Point(0, 0);
                templ2.Width = numWidth;
                templ2.Text =ChptList.choiceproL[i].num;

                templ3.Location = new Point(numWidth, 0);
                templ3.Width = proWidth;
                templ3.Text = ChptList.choiceproL[i].pro;

                var temp = new Button();
                temp.Width = (listWidth-choWidth);
                temp.Height = btnHeight;
                temp.Tag = ChptList.choiceproL[i].num;
                temp.Location = new Point(choWidth, (btnHeight * i));
                temp.BackgroundImage = Resources.btnmaobi;//按钮背景图片
                temp.BackgroundImageLayout = ImageLayout.Stretch;
                mainPanel.Controls.Add(temp);
                subPanel.Add(temp);
                subPanelStatus.Add(0);
                temp.FlatStyle = FlatStyle.Popup;
                temp.Controls.Add(templ2);
                temp.Controls.Add(templ3);

                mainPanel.Controls.Add(checkButton);
                checkList.Add(checkButton);
                check acheck = new check(false, ChptList.choiceproL[i].num);
                acheckproList.Add(acheck);
                                      
                temp.MouseClick +=new MouseEventHandler(temp_MouseClick);
                templ2.MouseClick += new MouseEventHandler(templ2_MouseClick);
                templ3.MouseClick += new MouseEventHandler(templ3_MouseClick);
                checkButton.MouseClick += new MouseEventHandler(checkButton_MouseClick);
                 
            }

        }
        

        
        void checkButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (acheckproList[(int)((Button)sender).Tag].selected)
            {
                ((Button)sender).BackgroundImage = Resources.circle_black;
                acheckproList[(int)((Button)sender).Tag].selected = false;              
            }
            else
            {
                ((Button)sender).BackgroundImage = Resources.circle_red;
                acheckproList[(int)((Button)sender).Tag].selected = true;
                
            }
        }

        void temp_MouseClick(object sender, MouseEventArgs e)
        {
            this.Hide();
            aProMan.bottomPanel.Hide();
            aProMan.titlePanel.Hide();
            change(Convert.ToInt32(((Button)sender).Tag),aProMan.ProType);

        }

        void templ3_MouseClick(object sender, MouseEventArgs e)
        {
            this.Hide();
            aProMan.bottomPanel.Hide();
            aProMan.titlePanel.Hide();
            change(Convert.ToInt32(((Label)sender).Tag), aProMan.ProType);
        }

        void templ2_MouseClick(object sender, MouseEventArgs e)
        {
            this.Hide();
            aProMan.bottomPanel.Hide();
            aProMan.titlePanel.Hide();
            change(Convert.ToInt32(((Label)sender).Tag), aProMan.ProType);
        }

        //调用加载函数，控制控件隐藏现实的转换
        void change(int id,int pt)
        {
            click_proid = Convert.ToString(id);
            loadpro(id, pt);
            aProMan.EditList[pt].Show();
            ProMan.isediting = true;
            for (int i=0; i < 12 && i != pt; i++)
            {
                aProMan.EditList[i].Hide();
            }
        }

        
        //加载函数，加载问题编辑界面的原始数据
        void loadpro(int id,int pt)
        {
            
            switch (pt)
            {
                case 0:
                    aProMan.aChoiceEdit.isnew = false;
                    aProMan.aChoiceEdit.fill(InfoControl.OesData.FindChoiceById(id.ToString()));
                    break;
                case 1:
                    aProMan.aCompletionEdit.isnew = false;
                    aProMan.aCompletionEdit.fill(InfoControl.OesData.FindCompletionById(id.ToString()));
                    break;
                case 2:
                    aProMan.aJudgeEdit.isnew = false;
                    aProMan.aJudgeEdit.fill(InfoControl.OesData.FindTofById(id.ToString()));
                    break;
                case 3:
                    aProMan.aOfficeExcelEdit.isnew = false;
                    aProMan.aOfficeExcelEdit.fill(InfoControl.OesData.FindOfficeExcelById(id.ToString()));
                    break;
                case 4:
                    aProMan.aOfficePowerpointEdit.isnew = false;
                    aProMan.aOfficePowerpointEdit.fill(InfoControl.OesData.FindOfficePowerPointById(id.ToString()));
                    break;
                case 5:
                    aProMan.aOfficeWordEdit.isnew = false;
                    aProMan.aOfficeWordEdit.fill(InfoControl.OesData.FindOfficeWordById(id.ToString()));
                    break;
                case 6:
                    aProMan.aCCompletionEdit.isnew = false;
                    aProMan.aCCompletionEdit.fill(InfoControl.OesData.FindCompletionProgramById(id.ToString()));
                    break;
                case 7:
                    aProMan.aCModifEdit.isnew = false;
                    aProMan.aCModifEdit.fill(InfoControl.OesData.FindModificationProgramById(id.ToString()));
                    break;
                case 8:
                    aProMan.aCFuctionEdit.isnew = false;
                    aProMan.aCFuctionEdit.fill(InfoControl.OesData.FindFunProgramById(id.ToString()));
                    break;
                case 9:
                    aProMan.aCppCompletionEdit.isnew = false;
                    aProMan.aCppCompletionEdit.fill(InfoControl.OesData.FindCompletionProgramById(id.ToString()));
                    break;
                case 10:
                    aProMan.aCppModifEdit.isnew = false;
                    aProMan.aCppModifEdit.fill(InfoControl.OesData.FindModificationProgramById(id.ToString()));
                    break;
                case 11:
                    aProMan.aCppFuctionEdit.isnew = false;
                    aProMan.aCppFuctionEdit.fill(InfoControl.OesData.FindFunProgramById(id.ToString()));
                    break;
                default:
                    break;
            }
        }

        #region Nested type: choicepro

        public class check
        {
            public bool selected;
            public string proid;

            public check(bool s, string p)
            {
                selected = s;
                proid = p;
            }
        }

        #endregion

        
    }
}