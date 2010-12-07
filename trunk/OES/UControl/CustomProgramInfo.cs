using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace OES.UControl
{
    public partial class CustomProgramInfo : UserControl
    {
        [DllImport("user32", EntryPoint = "HideCaret")]
        private static extern bool HideCaret(IntPtr hWnd);
        private string path;
        private int type;
        public CustomProgramInfo(int t)
        {
            InitializeComponent();
            type = t;            
            switch (type)
            {
                case 1: 
                    this.Question.Text = ClientControl.paper.pCompletion.problem;
                    break ;
                case 2: 
                    this.Question.Text = ClientControl.paper.pModif.problem;
                    break ;
                case 3: 
                    this.Question.Text = ClientControl.paper.pFunction.problem;
                    break ;
            }
        }

        private void butOpen_Click(object sender, EventArgs e)
        {

        }

        private void butRedo_Click(object sender, EventArgs e)
        {
            Correct.correctPF(@"G:\Documents\Visual Studio 2008\Projects\OES\OES\bin\Debug\OESTEST\Paper\i.cpp");
        }


        private void Hide_MouseDown(object sender, MouseEventArgs e)
        {
            HideCaret(((RichTextBox)sender).Handle);
        }
        private void Hide1_MouseDown(object sender, MouseEventArgs e)
        {
            HideCaret(((TextBox)sender).Handle);
        }
    }
}
