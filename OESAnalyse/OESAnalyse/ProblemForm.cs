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
    public partial class ProblemForm : Form
    {
        public TextBox newTextBox;
        public ProblemForm()
        {
            InitializeComponent();
            newTextBox = new TextBox();
            this.newTextBox.Visible = true;
            this.newTextBox.Multiline = true;
            this.newTextBox.WordWrap = true;
            this.newTextBox.Width = 285;
            this.newTextBox.Height = 251;
            this.newTextBox.Location = new Point(0, 0);
            this.Controls.Add(this.newTextBox);

        }
    }
}
