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
        public List<int> checkNumList=new List<int>();
        public List<bool> checkClickList = new List<bool>();
    
        public static int btnHeight;
        public static int choWidth;
        public static int count = 10;
        public static int listWidth;
        private Panel mainPanel;
        public static int numWidth;
        public int page = 1;
        public static int proWidth;

        public int totalpage = 1;
        ProMan aProMan;


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
            if (ChptList.pro_num > 0)
            {
                for (int i = 0; i < ChptList.pro_num; i++)
                {
                    var checkButton = new Button();
                    checkButton.Height = btnHeight;
                    checkButton.Width = choWidth;
                    checkButton.Location = new Point(0, (btnHeight * i));
                    checkButton.BackgroundImage = Resources.circle_black;
                    checkButton.BackgroundImageLayout = ImageLayout.Stretch;

                    var templ2 = new Label();
                    templ2.Height = btnHeight;
                    templ2.ForeColor = Color.White;
                    templ2.BackColor = Color.Transparent;
                    templ2.Tag = ChptList.choiceproL[i].num;
                    templ2.Font = new Font(new FontFamily("微软雅黑"), 11, FontStyle.Bold);

                    var templ3 = new Label();
                    templ3.Height = btnHeight;
                    templ3.ForeColor = Color.White;
                    templ3.BackColor = Color.Transparent;
                    templ3.Tag = ChptList.choiceproL[i].num;
                    templ3.Font = new Font(new FontFamily("微软雅黑"), 11, FontStyle.Bold);


                    templ2.Location = new Point(choWidth, 0);
                    templ2.Width = numWidth;
                    templ2.Text =ChptList.choiceproL[i].num;

                    templ3.Location = new Point((choWidth + numWidth), 0);
                    templ3.Width = choWidth;
                    templ3.Text = ChptList.choiceproL[i].pro;

                    var temp = new Button();
                    temp.Width = (listWidth-choWidth);
                    temp.Height = btnHeight;
                    temp.Tag = ChptList.choiceproL[i].num;
                    temp.Location = new Point(choWidth, (btnHeight * i));
                    temp.BackgroundImage = Resources.cpt_btn;
                    temp.BackgroundImageLayout = ImageLayout.Stretch;
                    mainPanel.Controls.Add(temp);
                    subPanel.Add(temp);
                    subPanelStatus.Add(0);
                    temp.FlatStyle = FlatStyle.Popup;
                    temp.Controls.Add(templ2);
                    temp.Controls.Add(templ3);

                    mainPanel.Controls.Add(checkButton);
                    checkList.Add(checkButton);
                    checkButton.Tag = checkList.Count;
                    checkClickList.Add(false);
                                          
                    temp.MouseClick +=new MouseEventHandler(temp_MouseClick);
                    templ2.MouseClick += new MouseEventHandler(templ2_MouseClick);
                    templ3.MouseClick += new MouseEventHandler(templ3_MouseClick);
                    checkButton.MouseClick += new MouseEventHandler(checkButton_MouseClick);
                     
                }

            }
        }

        
        void checkButton_MouseClick(object sender, MouseEventArgs e)
        {
            if ((checkClickList[(int)((Button)sender).Tag]))
            {
                ((Button)sender).BackgroundImage = Resources.circle_black;
                checkClickList[(int)((Button)sender).Tag] = false;
                checkNumList.Remove((int)((Button)sender).Tag);
            }
            else
            {
                ((Button)sender).BackgroundImage = Resources.circle_red;
                checkClickList[(int)((Button)sender).Tag] = true;
                checkNumList.Add((int)((Button)sender).Tag);
                
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


        void change(int id,int pt)
        {
            loadpro(id, pt);
            aProMan.EditList[pt].Show();
            for (int i=0; i < 12 && i != pt; i++)
            {
                aProMan.EditList[i].Hide();
            }
        }

        void loadpro(int id,int pt)
        {
            switch (pt)
            {
                case 0:
                    aProMan.aChoiceEdit.fill(InfoControl.OesData.FindChoiceById(id.ToString()));
                    break;
                case 1:
                    aProMan.aCompletionEdit.fill(InfoControl.OesData.FindCompletionById(id.ToString()));
                    break;
                case 2:
                    //aProMan.aJudgeEdit.fill(InfoControl.OesData.FindTofById(id.ToString()));
                    break;
                default:
                    break;
            }
        }

        
    }
}