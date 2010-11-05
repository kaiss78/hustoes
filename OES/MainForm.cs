using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MainWindow
{
    public partial class MainForm : Form
    {
        static private ProgramInfo Completion;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            TabPage NewTabPage;
            
            Completion = new ProgramInfo();
            Completion.Font = new Font("宋体",9);
            NewTabPage = new TabPage("程序填空题");
            NewTabPage.Controls.Add(Completion);
            tabControl.TabPages.Add(NewTabPage);
        }
    }
}
