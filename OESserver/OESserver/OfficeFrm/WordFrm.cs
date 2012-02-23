using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OES.OfficeFrm
{
    public partial class WordFrm : Form
    {
        public WordFrm()
        {
            InitializeComponent();
        }

        public void LoadWord(string word_path, string xml_path)
        {
            testWord1.LoadWord(word_path, xml_path);
        }

        private void WordFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            testWord1.CloseDocument();
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
