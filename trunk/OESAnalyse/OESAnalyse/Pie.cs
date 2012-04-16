using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OESAnalyse
{
    public partial class Pie : UserControl
    {
        public Pie()
        {
            InitializeComponent();
        }

        private void Pie_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = this.CreateGraphics();
            draw(graphics);
        }

        public void draw(Graphics graphics)
        {
            Pen my_pen = new Pen(Color.Black);
            drawMyPie(graphics,new float[]{10,20,30,40});

        }

        public void drawMyPie(Graphics graphics,params float[] percents)
        {
         
            for (int i = 0; i < percents.Length; i++)
            {
                Pen my_pen = new Pen(Color.Black);
                if (i == 0)
                    graphics.DrawPie(my_pen, new Rectangle(100, 100, 800, 400), 0, percents[i]*324);
                else
                    graphics.DrawPie(my_pen,new Rectangle(100,100,800,400),percents[i-1]*360,percents[i]*324);
             
            }
        }
    }
}
