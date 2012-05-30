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
        private float centerX_above, centerY_above, centerX_below, centerY_below;
        private Rectangle rectangle_above, rectangle_below;
        private float[] distribution;
        private int narrow;
        public Pie()
        {
            InitializeComponent();
            rectangle_above = new Rectangle(0,0,400,400);
            rectangle_below = new Rectangle(0,100,400,400);
            centerX_above = 200;
            centerX_below = 200;
            centerY_above = 200;
            centerY_below = 300;
        }

        private void Pie_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = this.CreateGraphics();
            draw(graphics);
        }

        public void draw(Graphics graphics)
        {
            Pen my_pen = new Pen(Color.Black);
            drawMyPie(graphics,new float[]{30,30,20,20,0});

        }

        public SolidBrush getSolidBrush(int i)
        {
            if (i == 0)
            {
                return( new SolidBrush(Color.Yellow));
            }
            else if(i == 1)
            {
                return (new SolidBrush(Color.Red));
            }
            else if (i == 2)
            {
                return (new SolidBrush(Color.Blue));
            }
            else if (i == 3)
            {
                return (new SolidBrush(Color.Green));

            }
            else
            {
                return (new SolidBrush(Color.White));
            }
        }


        public void drawMyPie(Graphics graphics,params float[] percents)
        {
            Pen my_pen = new Pen(Color.Black);
            float[] thePercents = new float[percents.Length];

            for (int i = 0; i < percents.Length; i++)
            {
                percents[i] = percents[i] / 100;
                thePercents[i] = percents[i];
                if (percents[i] == 0)
                {
                    continue;
                }
                if (i == 0)
                {
                    graphics.FillPie(getSolidBrush(i%5), rectangle_below, 0, percents[i] * 324);
                    graphics.FillPie(getSolidBrush(i % 5), rectangle_above, 0, percents[i] * 324);
                    graphics.FillPolygon(getSolidBrush(i % 5), 
                        new Point[] { new Point(200, 200), new Point(200, 300), 
                            new Point(400, 300), new Point(400, 200) });

                    graphics.FillPolygon(getSolidBrush(i % 5), 
                        new Point[] { new Point(200, 200), new Point(200, 300), 
                            new Point(Convert.ToInt32(200 + 200 * Math.Cos(percents[i] * 324 / 180 * Math.PI)), Convert.ToInt32(300 + Math.Sin(percents[i] * 324 / 180 * Math.PI) * 200)), 
                            new Point(Convert.ToInt32(200 + Math.Cos(percents[i] * 324 / 180 * Math.PI) * 200), Convert.ToInt32(200 + Math.Sin(percents[i] * 324 / 180 * Math.PI) * 200)) });
                }

                else
                {
                    graphics.FillPie(getSolidBrush(i % 5), rectangle_below, percents[i - 1] * 360, percents[i] * 324);
                    graphics.FillPie(getSolidBrush(i % 5), rectangle_above, percents[i - 1] * 360, percents[i] * 324);
                    graphics.FillPolygon(getSolidBrush(i % 5), 
                        new Point[] { new Point(200, 200), 
                        new Point(200, 300), 
                        new Point(Convert.ToInt32(200 + 200 * Math.Cos(percents[i-1] * 360 / 180 * Math.PI)), Convert.ToInt32(300 + Math.Sin(percents[i-1] * 360 / 180 * Math.PI) * 200)), 
                        new Point(Convert.ToInt32(200 + Math.Cos(percents[i-1] * 360 / 180 * Math.PI) * 200), Convert.ToInt32(200 + Math.Sin(percents[i-1] * 360 / 180 * Math.PI) * 200)) });
                    graphics.FillPolygon(getSolidBrush(i % 5), new Point[] {
                        new Point(200, 200), new Point(200, 300), 
                        new Point(Convert.ToInt32(200 + 200 * Math.Cos((percents[i - 1] * 360 / 180 + percents[i] * 324 / 180) * Math.PI)), Convert.ToInt32(300 + Math.Sin((percents[i - 1] * 360 / 180 + percents[i] * 324 / 180) * Math.PI) * 200)), 
                        new Point(Convert.ToInt32(200 + Math.Cos((percents[i-1] * 360 / 180+percents[i] * 324 / 180) * Math.PI) * 200), Convert.ToInt32(200 + Math.Sin((percents[i-1] * 360 / 180+percents[i] * 324 / 180) * Math.PI) * 200)) });
                    percents[i] += percents[i - 1];
                }   
            }
            for (int i = 0; i < thePercents.Length; i++)
            {
           
                if (i == 0)
                {
                    graphics.DrawPie(my_pen, rectangle_above, 0, thePercents[i] * 324);
                    graphics.DrawPie(my_pen, rectangle_below, 0, thePercents[i] * 324);
                    graphics.DrawLine(my_pen, new Point(400, 200), new Point(400, 300));
                    graphics.DrawLine(my_pen, new Point(Convert.ToInt32(200 + 200 * Math.Cos(thePercents[i] * 324 / 180 * Math.PI)), Convert.ToInt32(200 + Math.Sin(thePercents[i] * 324 / 180 * Math.PI) * 200)), new Point(Convert.ToInt32(200 + Math.Cos(thePercents[i] * 324 / 180 * Math.PI) * 200), Convert.ToInt32(300 + Math.Sin(thePercents[i] * 324 / 180 * Math.PI) * 200)));
                }
                else
                {
                    graphics.DrawPie(my_pen, rectangle_above, thePercents[i - 1] * 360, thePercents[i] * 324);
                    graphics.DrawPie(my_pen, rectangle_below, thePercents[i - 1] * 360, thePercents[i] * 324);
                    graphics.DrawLine(my_pen, new Point(Convert.ToInt32(200 + 200 * Math.Cos(thePercents[i - 1] * 2 * Math.PI)), Convert.ToInt32(200 + Math.Sin(thePercents[i - 1] * 2 * Math.PI) * 200)), new Point(Convert.ToInt32(200 + Math.Cos(thePercents[i - 1] * 2 * Math.PI) * 200), Convert.ToInt32(300 + Math.Sin(thePercents[i - 1] * 2 * Math.PI) * 200)));
                    graphics.DrawLine(my_pen, new Point(Convert.ToInt32(200 + 200 * Math.Cos((thePercents[i] * 324 / 180 + thePercents[i - 1] * 2) * Math.PI)), Convert.ToInt32(200 + Math.Sin((thePercents[i] * 324 / 180 + thePercents[i - 1] * 2) * Math.PI) * 200)), new Point(Convert.ToInt32(200 + Math.Cos((thePercents[i] * 324 / 180 + thePercents[i - 1] * 2) * Math.PI) * 200), Convert.ToInt32(300 + Math.Sin((thePercents[i] * 324 / 180 + thePercents[i - 1] * 2) * Math.PI) * 200)));
                    thePercents[i] += thePercents[i - 1];
                }
            }
        }

    }
}
