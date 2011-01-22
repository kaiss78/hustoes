using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using OES.Properties;
using OES.UPanel;

namespace OES.UControl
{
    public partial class ProList : UserControl
    {
        private readonly List<choicepro> choiceproL = new List<choicepro>();
        private readonly List<Button> subPanel = new List<Button>();
        private readonly List<int> subPanelStatus = new List<int>();
        private readonly List<Label> titleList = new List<Label>();
        public List<Button> checkList = new List<Button>();
        public List<int> checkNumList=new List<int>();
        public List<bool> checkClickList = new List<bool>();
        private choicepro achoicepro;

        private int ProType=0;
        private int btnHeight;
        private int choWidth;
        public int count = 10;
        private int listWidth;
        private Panel mainPanel;
        private int numWidth;
        public int page = 1;
        private int proWidth;
        public int pro_num = 23;
        public int totalpage = 1;
        ProMan aProMan;


        public ProList(ProMan pm)
        {
            InitializeComponent();
            aProMan=pm;

        }

        public void Reload()
        {
            ProType = aProMan.ProType;
        }

        private void ProList_Resize(object sender, EventArgs e)
        {
            Controls.Clear();
            mainPanel = new Panel();
            mainPanel.Height = Height;
            mainPanel.Width = Width;
            Controls.Add(mainPanel);
            btnHeight = (int)((Height / (count + 1))*1.0186);
            listWidth = (int)(Width * 0.973);
            choWidth = (int)(Width * 0.1);
            numWidth = (int)(Width * 0.1);
            proWidth = (int)(Width * 0.773);
            totalpage = ((pro_num / count) + 1);

            mainPanel.AutoScroll = true;
            //title
            for (int i = 0; i < 3; i++)
            {
                var templt = new Label();
                templt.Height = btnHeight;
                templt.ForeColor = Color.White;
                templt.BackColor = Color.Transparent;
                templt.Font = new Font(new FontFamily("微软雅黑"), 11, FontStyle.Bold);
                templt.TextAlign = ContentAlignment.MiddleCenter;
                titleList.Add(templt);
                mainPanel.Controls.Add(templt);
            }
            titleList[0].Width = choWidth;
            titleList[1].Width = numWidth;
            titleList[2].Width = proWidth;

            titleList[0].Text = "勾选";
            titleList[1].Text = "题号";
            titleList[2].Text = "题干";

            titleList[0].ForeColor = Color.Blue;
            titleList[1].ForeColor = Color.Blue;
            titleList[2].ForeColor = Color.Blue;

            titleList[0].Location = new Point(0, 0);
            titleList[1].Location = new Point(choWidth, 0);
            titleList[2].Location = new Point((choWidth + numWidth), 0);

            //list赋初值
            for (int i = 0; i < 23; i++)
            {
                achoicepro = new choicepro(i, i.ToString(), i.ToString());
                choiceproL.Add(achoicepro);
            }

            

            //判断动态生成题目列表
            if (pro_num > 0)
            {
                for (int i = 0; i < pro_num; i++)
                {
                    var checkButton = new Button();
                    checkButton.Height = btnHeight;
                    checkButton.Width = choWidth;
                    checkButton.Location = new Point(0, (btnHeight * (i + 1)));
                    checkButton.BackgroundImage = Resources.circle_black;
                    checkButton.BackgroundImageLayout = ImageLayout.Stretch;

                    var templ2 = new Label();
                    templ2.Height = btnHeight;
                    templ2.ForeColor = Color.White;
                    templ2.BackColor = Color.Transparent;
                    templ2.Font = new Font(new FontFamily("微软雅黑"), 11, FontStyle.Bold);

                    var templ3 = new Label();
                    templ3.Height = btnHeight;
                    templ3.ForeColor = Color.White;
                    templ3.BackColor = Color.Transparent;
                    templ3.Font = new Font(new FontFamily("微软雅黑"), 11, FontStyle.Bold);


                    templ2.Location = new Point(choWidth, 0);
                    templ2.Width = numWidth;
                    templ2.Text = choiceproL[i].pro;

                    templ3.Location = new Point((choWidth + numWidth), 0);
                    templ3.Width = choWidth;
                    templ3.Text = choiceproL[i].chpt;

                    var temp = new Button();
                    temp.Width = (listWidth-choWidth);
                    temp.Height = btnHeight;
                    temp.Location = new Point(choWidth, (btnHeight * (i + 1)));
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
                    templ2.MouseClick += new MouseEventHandler(temp_MouseClick);
                    templ3.MouseClick += new MouseEventHandler(temp_MouseClick);
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
            change(ProType);

        }

        void change(int x)
        {
            aProMan.EditList[x].Show();
            for (int i=0; i < 12 && i != x; i++)
            {
                aProMan.EditList[i].Hide();
            }
        }

        #region Nested type: choicepro

        public class choicepro
        {
            public string chpt;
            public int num;
            public string pro;

            public choicepro(int n, string p, string c)
            {
                num = n;
                pro = p;
                chpt = c;
            }
        }

        #endregion
    }
}