using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;

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
            ClientControl.SetDone(ClientControl.CurrentProblemNum);
            switch (type)
            {
                case 1:
                    if (!File.Exists(Config.stuPath + "g.cpp"))
                    {
                        File.Copy(Config.paperPath + "g.cpp", Config.stuPath + "g.cpp", true);
                    }
                    Process.Start(Config.stuPath + "g.cpp");
                    break ;
                case 2:
                    if (!File.Exists(Config.stuPath + "h.cpp"))
                    {
                        File.Copy(Config.paperPath + "h.cpp", Config.stuPath + "h.cpp", true);
                    }
                    Process.Start(Config.stuPath + "h.cpp");
                    break ;
                case 3:
                    if (!File.Exists(Config.stuPath + "i.cpp"))
                    {
                        File.Copy(Config.paperPath + "i.cpp", Config.stuPath + "i.cpp", true);
                    }
                    Process.Start(Config.stuPath + "i.cpp");
                    break ;
            }
           
        }

        private void butRedo_Click(object sender, EventArgs e)
        {
            //Correct.correctPF(@"G:\Documents\Visual Studio 2008\Projects\OES\OES\bin\Debug\OESTEST\Paper\i.cpp");
            if (MessageBox.Show("继续将会删除之前答案", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                switch (type)
                {
                    case 1:
                        File.Copy(Config.paperPath + "g.cpp", Config.stuPath + "g.cpp", true);
                        Process.Start(Config.stuPath + "g.cpp");
                        break;
                    case 2:
                        File.Copy(Config.paperPath + "h.cpp", Config.stuPath + "h.cpp", true);
                        Process.Start(Config.stuPath + "h.cpp");
                        break;
                    case 3:
                        File.Copy(Config.paperPath + "i.cpp", Config.stuPath + "i.cpp", true);
                        Process.Start(Config.stuPath + "i.cpp");
                        break;
                }
            }
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
