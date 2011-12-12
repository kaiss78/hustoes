using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OES.UPanel
{
    public partial class BulkImport : UserControl
    {
        Dictionary<Button, TextBox> dict = new Dictionary<Button, TextBox>();
        public BulkImport()
        {
            InitializeComponent();
            dict.Add(btnBrowse1, textBox1);
            dict.Add(btnBrowse2, textBox2);
            dict.Add(btnBrowse3, textBox3);
            dict.Add(btnBrowse4, textBox4);
            dict.Add(btnBrowse5, textBox5);
            dict.Add(btnBrowse6, textBox6);
        }

        private void btnBrowse1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                dict[sender as Button].Text = openFileDialog1.FileName;
            }
        }

        private void btnConfirm1_Click(object sender, EventArgs e)
        {

        }

        private void btnConfirm2_Click(object sender, EventArgs e)
        {

        }

        private void btnConfirm3_Click(object sender, EventArgs e)
        {

        }

        private void btnConfirm4_Click(object sender, EventArgs e)
        {

        }

        private void btnConfirm5_Click(object sender, EventArgs e)
        {

        }

        private void btnConfirm6_Click(object sender, EventArgs e)
        {

        }
    }
}
