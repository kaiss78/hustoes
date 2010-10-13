using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace kongzhitiao
{
    public partial class Form1 : Form

    {
        shitichuangti shitichuang = new shitichuangti();

        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.SetDesktopLocation(400, 0);

            shitichuang.Visible = true;
            shitichuang.SetDesktopLocation(400,200);
           
        } 

        private void Form1_AutoSizeChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (shiti.Text.Equals("隐藏试题"))
            {
                shitichuang.Visible = false;
                shiti.Text = "显示试题";
            }
            else
            {
                shitichuang.Visible = true;
                shiti.Text = "隐藏试题";
            }

        }


    }
}
