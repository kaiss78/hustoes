using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OESserver.UControl
{
    public partial class ProList : UserControl
    {
        Panel mainPanel;

        List<Label> titleList = new List<Label>();
        List<Button> subPanel = new List<Button>();
        List<int> subPanelStatus = new List<int>();
        List<choicepro> choiceproL = new List<choicepro>();
        choicepro achoicepro;

        public int count = 10;
        public int pro_num = 23;
        public int totalpage = 1;
        public int page = 1;
        int btnHeight;
        int numWidth;
        int proWidth;
        int chptWidth;
        int listWidth;

        public ProList()
        {
            InitializeComponent();

            mainPanel = new Panel();
            mainPanel.Height = this.Height;
            mainPanel.Width = this.Width;
            this.Controls.Add(mainPanel);
            btnHeight = this.Height / (count + 1);
            listWidth = (int)(this.Width * 0.95);
            numWidth = (int)(this.Width * 0.1);
            proWidth =(int)(this.Width*0.6);
            chptWidth =(int)(this.Width*0.3);
            totalpage = (int)((pro_num / count) + 1);

            mainPanel.AutoScroll = true;
            //title
            for (int i = 0; i < 3; i++)
            {
                Label templt = new Label();
                templt.Height = btnHeight;
                templt.ForeColor = Color.White;
                templt.BackColor = Color.Transparent;
                templt.Font = new Font(new FontFamily("微软雅黑"), 11, FontStyle.Bold);
                templt.TextAlign = ContentAlignment.MiddleCenter;
                titleList.Add(templt);
                mainPanel.Controls.Add(templt);

            }
            titleList[0].Width = numWidth;
            titleList[1].Width = proWidth;
            titleList[2].Width = chptWidth;

            titleList[0].Text = "题号";          
            titleList[1].Text = "题干";
            titleList[2].Text = "章节";

            titleList[0].Location = new Point(0, 0);
            titleList[1].Location = new Point(numWidth, 0);
            titleList[2].Location = new Point((numWidth + proWidth), 0);

            //list赋初值
            for (int i = 0; i < 23; i++)
            {
                achoicepro = new choicepro(i, i.ToString(), i.ToString());
                choiceproL.Add(achoicepro);
            }


            //判断动态生成章节列表
            if (pro_num > 0)
            {
                for (int i = 0; i < pro_num; i++)
                {


                    Label templ1 = new Label();
                    templ1.Height = btnHeight;
                    templ1.ForeColor = Color.White;
                    templ1.BackColor = Color.Transparent;
                    templ1.Font = new Font(new FontFamily("微软雅黑"), 11, FontStyle.Bold);

                    Label templ2 = new Label();
                    templ2.Height = btnHeight;
                    templ2.ForeColor = Color.White;
                    templ2.BackColor = Color.Transparent;
                    templ2.Font = new Font(new FontFamily("微软雅黑"), 11, FontStyle.Bold);

                    Label templ3 = new Label();
                    templ3.Height = btnHeight;
                    templ3.ForeColor = Color.White;
                    templ3.BackColor = Color.Transparent;
                    templ3.Font = new Font(new FontFamily("微软雅黑"), 11, FontStyle.Bold);

                    templ1.Location = new Point(0, 0);
                    templ1.Width = numWidth;
                    templ1.Text = choiceproL[i].num.ToString();

                    templ2.Location = new Point(numWidth, 0);
                    templ2.Width = proWidth;
                    templ2.Text = choiceproL[i].pro;

                    templ3.Location = new Point((numWidth + proWidth), 0);
                    templ3.Width = numWidth;
                    templ3.Text = choiceproL[i].chpt;

                    Button temp = new Button();
                    temp.Width = (int)(this.Width);
                    temp.Height = btnHeight;
                    temp.Location = new Point(0, (int)(btnHeight * (i + 1)));
                    temp.BackgroundImage = Properties.Resources.cpt_btn;
                    temp.BackgroundImageLayout = ImageLayout.Stretch;
                    mainPanel.Controls.Add(temp);
                    subPanel.Add(temp);
                    subPanelStatus.Add(0);
                    temp.FlatStyle = FlatStyle.Popup;
                    temp.Controls.Add(templ1);
                    temp.Controls.Add(templ2);
                    temp.Controls.Add(templ3);                   
                }
            }
        }

        public class choicepro
        {
            public int num;
            public string pro;
            public string chpt;
            public choicepro(int n,string p,string c) 
            {
                num=n;  
                pro=p;
                chpt=c;
            }
        }
    }
}
