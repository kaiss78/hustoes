using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
 
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;
using OES.Model;

namespace OES.UControl
{
    public partial class CustomProgramInfo : UserControl
    {
        [DllImport("user32", EntryPoint = "HideCaret")]
        private static extern bool HideCaret(IntPtr hWnd);
        //private string path;
        private string filename = "";
        private int proid;
        private int totalCount;

        public int proID
        {
            get { return proid; }
            set
            {
                proid = value;
                NextProblem.Enabled = true;
                LastProblem.Enabled = true;
                if (proid == totalCount - 1)
                {
                    NextProblem.Enabled = false;
                }
                if (proid == 0)
                {
                    LastProblem.Enabled = false;
                }
            }
        }

        private Problem prob = new Problem();

        private ProblemType type;
        public CustomProgramInfo(ProblemType t)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            type = t;
            switch (type)
            {
                case ProblemType.BaseProgramCompletion:
                    this.Rquest.Text = "根据题目描述完成编程填空题。";
                    totalCount = ClientControl.paper.pCompletion.Count;
                    break ;
                case ProblemType.BaseProgramModification:
                    this.Rquest.Text = "根据题目描述完成编程改错题。";
                    totalCount = ClientControl.paper.pModif.Count;
                    break ;
                case ProblemType.BaseProgramFun:
                    this.Rquest.Text = "根据题目描述完成编程综合题。";
                    totalCount = ClientControl.paper.pFunction.Count;
                    break ;
            }
            this.SetQuestion(proID);
        }

        public void SetQuestion(int x)
        {
            proID = x;
            switch (type)
            {
                case ProblemType.BaseProgramCompletion:
                    prob = ClientControl.GetProgramCompletion(proID);
                    break;
                case ProblemType.BaseProgramModification:
                    prob = ClientControl.GetProgramModif(proID);
                    break;
                case ProblemType.BaseProgramFun:
                    prob = ClientControl.GetProgramFunction(proID);
                    break;
            }
            switch (prob.type)
            {
                case ProblemType.CProgramCompletion:
                    this.filename = "g" + proID.ToString() + ".c";
                    break;
                case ProblemType.CppProgramCompletion:
                    this.filename = "g" + proID.ToString() + ".cpp";
                    break;
                case ProblemType.VbProgramCompletion:
                    this.filename = "g" + proID.ToString() + ".vb";
                    break;
                case ProblemType.CProgramModification:
                    this.filename = "h" + proID.ToString() + ".c";
                    break;
                case ProblemType.CppProgramModification:
                    this.filename = "h" + proID.ToString() + ".cpp";
                    break;
                case ProblemType.VbProgramModification:
                    this.filename = "h" + proID.ToString() + ".vb";
                    break;
                case ProblemType.CProgramFun:
                    this.filename = "i" + proID.ToString() + ".c";
                    break;
                case ProblemType.CppProgramFun:
                    this.filename = "i" + proID.ToString() + ".cpp";
                    break;
                case ProblemType.VbProgramFun:
                    this.filename = "i" + proID.ToString() + ".vb";
                    break;
            }
            this.Question.Text = prob.problem;
        }

        private void nextstep_Click(object sender, EventArgs e)
        {
            switch (type)
            {
                case ProblemType.BaseProgramCompletion:
                    if (proID < ClientControl.paper.pCompletion.Count - 1)
                    {
                        this.SetQuestion(++proID);
                        ClientControl.CurrentProblemNum++;
                    }
                    break;
                case ProblemType.BaseProgramModification:
                    if (proID < ClientControl.paper.pModif.Count - 1)
                    {
                        this.SetQuestion(++proID);
                        ClientControl.CurrentProblemNum++;
                    }
                    break;
                case ProblemType.BaseProgramFun:
                    if (proID < ClientControl.paper.pFunction.Count - 1)
                    {
                        this.SetQuestion(++proID);
                        ClientControl.CurrentProblemNum++;
                    }
                    break;
            }
            
        }

        private void laststep_Click(object sender, EventArgs e)
        {
            switch (type)
            {
                case ProblemType.BaseProgramCompletion:
                    if (proID >0)
                    {
                        this.SetQuestion(--proID);
                        ClientControl.CurrentProblemNum--;
                    }
                    break;
                case ProblemType.BaseProgramModification:
                    if (proID >0)
                    {
                        this.SetQuestion(--proID);
                        ClientControl.CurrentProblemNum--;
                    }
                    break;
                case ProblemType.BaseProgramFun:
                    if (proID >0)
                    {
                        this.SetQuestion(--proID);
                        ClientControl.CurrentProblemNum--;
                    }
                    break;
            }

        }

        public int GetQuestion()
        {
            return proID;
        }


        private void butOpen_Click(object sender, EventArgs e)
        {
            if (!File.Exists(Config.stuPath + filename))
            {
                File.Copy(Config.paperPath + filename, Config.stuPath + filename, true);
            }
            while (!File.Exists(Config.stuPath + filename)) ;
            System.Diagnostics.Process.Start(Config.stuPath + filename);
            ClientControl.SetDone(ClientControl.CurrentProblemNum);
        }

        private void butRedo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("继续将会删除之前答案", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                File.Copy(Config.paperPath + filename, Config.stuPath+filename,true);
                System.Diagnostics.Process.Start(Config.stuPath+filename);
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
