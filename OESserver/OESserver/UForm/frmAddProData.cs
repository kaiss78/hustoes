using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;
using OES.Model;
using OESScore;
namespace OES
{
    public partial class frmAddProData : Form
    {
        private string Path;
        public ProgramAnswer ProAns;
        public bool Result;

        public frmAddProData(string path)
        {
            InitializeComponent();
            Path = path;
            Result = false;
        }

        public frmAddProData(string path, ProgramAnswer pa)
        {
            InitializeComponent();
            Path = path;
            rtbInput.Text = pa.Input;
            rtbOutput.Text = pa.Output;
            Result = false;
        }   

        private void btnCalc_Click(object sender, EventArgs e)
        {
            //ProgramScore.FindVC();
            rtbOutput.Text = ProgramScore.correctPF(Path, rtbInput.Text);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Result = true;
            ProAns = new ProgramAnswer(0, rtbInput.Text, rtbOutput.Text);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
