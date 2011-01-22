using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using OES.Properties;
using OES.UPanel;

namespace OES.UControl
{
    public partial class ChptList : UserControl
    {
        private readonly List<String> chpt_name = new List<string>();
        private readonly List<Button> subPanel = new List<Button>();
        private readonly List<int> subPanelStatus = new List<int>();
        private int btnHeight;
        public int chpt_num = -1;
        public int count = 20;
        private Panel mainPanel;
        public int page = 1;
        public int totalpage = 1;
        ProMan aProMan;
        private int ProType;

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

        public void Reload()
        {
            ProType = aProMan.ProType;


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
            OESData aOESData = new OESData();
            chpt_num = aOESData.FindUnit(ProType).Count;

            //list赋初值
            for (int i = 0; i < chpt_num; i++)
            {
                chpt_name.Add(aOESData.FindUnit(ProType)[i].UnitName);
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
                        var temp1 = new Label();
                        temp1.Location = new Point(0, 0);

                        temp1.Text = chpt_name[i];
                        temp1.AutoSize = true;
                        temp1.ForeColor = Color.White;
                        temp1.BackColor = Color.Transparent;
                        temp1.Font = new Font(new FontFamily("微软雅黑"), 11, FontStyle.Bold);


                        var temp = new Button();
                        temp.Width = (Width);
                        temp.Height = btnHeight;
                        temp.Location = new Point(0, (int) (btnHeight*(i + 0.8)));
                        temp.BackgroundImage = Resources.title;
                        temp.BackgroundImageLayout = ImageLayout.Stretch;
                        mainPanel.Controls.Add(temp);
                        subPanel.Add(temp);
                        subPanelStatus.Add(0);
                        temp.FlatStyle = FlatStyle.Popup;
                        temp.Controls.Add(temp1);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}