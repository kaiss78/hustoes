using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OES.Model;
namespace OES
{
    public partial class frmAddAnswer : Form
    {
        public bool Result;
        public ProgramAnswer ProAns;

        public frmAddAnswer(int Count)
        {            
            InitializeComponent();
            Result = false;
            cbNum.Items.Clear();           
            for (int i = 0; i < Count; i++)
            {
                cbNum.Items.Add(i+1);
            }
            cbNum.SelectedIndex = 0;
        }

        public frmAddAnswer(int Count,ProgramAnswer PA)
        {
            InitializeComponent();
            Result = false;
            cbNum.Items.Clear();
            for (int i = 0; i < Count; i++)
            {
                cbNum.Items.Add(i + 1);
            }
            ProAns=PA;
            rtbAnswer.Text = PA.Output;
            cbNum.SelectedIndex = PA.SeqNum-1;
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Result = true;            
            ProAns = new ProgramAnswer(Convert.ToInt32(cbNum.SelectedItem), "", rtbAnswer.Text);
            this.Close();
        }
    }
}
