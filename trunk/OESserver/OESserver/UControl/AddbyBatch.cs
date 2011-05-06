using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OES.UPanel;

namespace OES.UControl
{
    public partial class AddbyBatch : UserControl
    {
        ProMan aProMan;  
        public AddbyBatch(ProMan pm)
        {
            InitializeComponent();
            aProMan = pm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                AddPath.Text = (openFileDialog1.FileName);
            }
        }
    }
}
