using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OESAnalyse
{
    public partial class OESAnalyse : Form
    {
        private FolderBrowserDialog fbd=new FolderBrowserDialog();

        public OESAnalyse()
        {
            InitializeComponent();
        }

        private void PathBut_Click(object sender, EventArgs e)
        {
            if (fbd.ShowDialog().Equals(DialogResult.OK))
            {
                String a = fbd.SelectedPath;
                
            }
        }

    }
}
