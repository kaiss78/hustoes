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
    public partial class ChptList : UserControl
    {
        Panel mainPanel;

        List<Button> subPanel = new List<Button>();
        List<int> subPanelStatus = new List<int>();
        List<String> chpt_name = new List<string>();
        public int count = 20;
        public int chpt_num = 23;
        public int totalpage = 1;
        public int page = 1;
        int btnHeight;

        public ChptList()
        {
            InitializeComponent();
            mainPanel = new Panel();
            mainPanel.Height = this.Height;
            mainPanel.Width = this.Width;
            this.Controls.Add(mainPanel);
            btnHeight = this.Height /(count+1);
            totalpage = (int)((chpt_num / count) + 1);

            //list赋初值
            for (int i = 0; i < 23; i++)
            {
                chpt_name.Add((i + 1).ToString());
            }
            
            Button last = new Button();
            last.Width = (int)(this.Width);
            last.Height = (btnHeight/2);
            last.Location = new Point(0, 0);
            last.BackgroundImage = Properties.Resources.cpt_btn;
            last.BackgroundImageLayout = ImageLayout.Stretch;
            last.FlatStyle = FlatStyle.Popup;
            mainPanel.Controls.Add(last);
            last.MouseClick += new MouseEventHandler(last_MouseClick);
           

            Button next = new Button();
            next.Width = (int)(this.Width);
            next.Height = (btnHeight / 2);
            next.Location = new Point(0, this.Height-next.Height);
            next.BackgroundImage = Properties.Resources.cpt_btn;
            next.BackgroundImageLayout = ImageLayout.Stretch;
            next.FlatStyle = FlatStyle.Popup;
            mainPanel.Controls.Add(next);
            next.MouseClick += new MouseEventHandler(next_MouseClick);

            //判断动态生成章节列表
            if (chpt_num > 0)
            {
                for (int i = 0; i < chpt_num; i++)
                {
                    if (i < count)
                    {
                        Label temp1 = new Label();
                        temp1.Location = new Point(0, 0);

                        temp1.Text = chpt_name[i];
                        temp1.AutoSize = true;
                        temp1.ForeColor = Color.White;
                        temp1.BackColor = Color.Transparent;
                        temp1.Font = new Font(new FontFamily("微软雅黑"), 11, FontStyle.Bold);


                        Button temp = new Button();
                        temp.Width = (int)(this.Width);
                        temp.Height = btnHeight;
                        temp.Location = new Point(0, (int)(btnHeight * (i + 0.5)));
                        temp.BackgroundImage = Properties.Resources.cpt_btn;
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
            //else
            //{
            //    for (int i = 0; i < count; i++)
            //    {
            //        Label temp1 = new Label();
            //        temp1.Location = new Point(0, 0);

            //        temp1.Text = chpt_name[i];
            //        temp1.AutoSize = true;
            //        temp1.ForeColor = Color.White;
            //        temp1.BackColor = Color.Transparent;
            //        temp1.Font = new Font(new FontFamily("微软雅黑"), 11, FontStyle.Bold);


            //        Button temp = new Button();
            //        temp.Width = (int)(this.Width);
            //        temp.Height = btnHeight;
            //        temp.Location = new Point(0, (int)(btnHeight * (i+0.5)));
            //        temp.BackgroundImage = Properties.Resources.cpt_btn;
            //        temp.BackgroundImageLayout = ImageLayout.Stretch;
            //        mainPanel.Controls.Add(temp);
            //        subPanel.Add(temp);
            //        subPanelStatus.Add(0);
            //        temp.FlatStyle = FlatStyle.Popup;
            //        temp.Controls.Add(temp1);
            //    }
            //    next.Enabled = true;
            //}
        }

        void next_MouseClick(object sender, MouseEventArgs e)
        {
            if (page <totalpage && page > 0)
            {
                page++;
                refresh();
                
            }

        }

        void last_MouseClick(object sender, MouseEventArgs e)
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

                    subPanel[i].Controls[0].Text = chpt_name[((page - 1) * count + i)];

                }
            }
            else
            {
                for (int i = 0; i < chpt_name.Count - count * (totalpage - 1); i++)
                {
                    subPanel[i].Controls[0].Text = chpt_name[((totalpage - 1) * count + i)];
                }
                for (int i = chpt_name.Count - count * (totalpage - 1); i < count; i++)
                {
                    subPanel[i].Controls[0].Text = "";
                }
            }
        }
    }
}
