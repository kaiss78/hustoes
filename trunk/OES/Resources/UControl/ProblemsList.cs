using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OES.UControl
{
    public partial class ProblemsList : UserControl
    {
        Panel mainPanel;
        List<Button> subPanel=new List<Button>();
        List<int> subPanelStatus = new List<int>();
        public int count=20;
        int halfHeight;
        public ProblemsList(int c)
        {
            InitializeComponent();
            count = c;
            mainPanel = new Panel();
            mainPanel.Height = this.Height;
            mainPanel.Width = this.Width;
            this.Controls.Add(mainPanel);
            halfHeight = this.Height / (count + 2);
            for (int i = 0; i < count; i++)
            {
                Label temp1 = new Label();
                temp1.Location = new Point(this.Width/2,halfHeight);

                temp1.Text = (i+1).ToString();
                temp1.AutoSize = true;
                temp1.ForeColor = Color.White;
                temp1.BackColor = Color.Transparent;
                temp1.Font = new Font(new FontFamily("微软雅黑"),11,FontStyle.Bold);
                
                Button temp = new Button();
                temp.Width = (int)(this.Width );
                temp.Height = halfHeight * 2;
                temp.Location = new Point(0, halfHeight * i);
                mainPanel.Controls.Add(temp);
                subPanel.Add(temp);
                subPanelStatus.Add(0);
                temp.FlatStyle = FlatStyle.Popup;
                temp.BackgroundImage = Properties.Resources.undo;
                temp.BackgroundImageLayout = ImageLayout.Stretch;
                temp.MouseEnter += new EventHandler(temp_MouseEnter);
                temp.MouseLeave += new EventHandler(temp_MouseLeave);
                temp.MouseHover += new EventHandler(temp_MouseHover);
                temp.MouseClick += new MouseEventHandler(temp_MouseClick);
                temp.Controls.Add(temp1);
               
            }
            this.Refresh();
        }
        public event EventHandler OnChoose;
        void temp_MouseClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < count; i++)
            {
                if (subPanelStatus[i]==2)
                {
                    subPanelStatus[i] = 0;
                }
                if (subPanel[i].Equals(sender))
                {
                    subPanelStatus[i] = 2;
                    OnChoose(i, e);
                }
            }
            refreshS();
        }
        void refreshS()
        {
            for (int i = 0; i < count; i++)
            {
                switch (subPanelStatus[i])
                {
                    case 0:
                        subPanel[i].BackgroundImage = Properties.Resources.undo;
                        break;
                    case 1:
                        subPanel[i].BackgroundImage = Properties.Resources.done;
                        break;
                    case 2:
                        subPanel[i].BackgroundImage = Properties.Resources.doing;
                        break;
                }
            }
        }
        void temp_MouseHover(object sender, EventArgs e)
        {
            
        }

        void temp_MouseLeave(object sender, EventArgs e)
        {

            for (int i = 0; i < count; i++)
            {
                subPanel[i].Location = new Point(0, halfHeight * i);
               // subLabel[i].Location = new Point(0, halfHeight * i + halfHeight);
            }

        }

        void temp_MouseEnter(object sender, EventArgs e)
        {
            bool isfind = false;
            if (subPanel != null && !sender.Equals(subPanel[0]))
            {
                for (int i = 0; i < count;i++)
                {
                    if (isfind)
                    {
                        subPanel[i].Location = new Point(subPanel[i].Location.X, subPanel[i].Location.Y + halfHeight);
                       // subLabel[i].Location = new Point(subLabel[i].Location.X, subLabel[i].Location.Y + halfHeight);
                    }
                    if (subPanel[i].Equals(sender))
                    {
                        subPanel[i].Location = new Point(subPanel[i].Location.X, subPanel[i].Location.Y + halfHeight);
                       // subLabel[i].Location = new Point(subLabel[i].Location.X, subLabel[i].Location.Y + halfHeight);
                        isfind = true;
                    }
                }
            }
        }
        public void setDone(int index)
        {
            subPanelStatus[index] = 1;
            refreshS();
        }
        public void setDoing(int index)
        {
            for (int i = 0; i < count; i++)
            {
                if (subPanelStatus[i] == 2)
                {
                    subPanelStatus[i] = 0;
                    break;
                }
            }
            subPanelStatus[index] = 2;
            refreshS();
        }
    }
}
