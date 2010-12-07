using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OESserver.UPanel;

namespace OESserver
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            ProMan aProMan = new ProMan();
            MainPanel.Controls.Add(aProMan);

        }
    }
}
