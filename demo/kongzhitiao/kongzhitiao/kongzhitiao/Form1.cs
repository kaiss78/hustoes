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

            shitichuang.Load();
           
        } 

        private void Form1_AutoSizeChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


    }
}
