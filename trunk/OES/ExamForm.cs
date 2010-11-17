using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OES
{
    public partial class ExamForm : Form
    {
        Form loginForm;
        public ExamForm(Form login,string name,string examNo,string id)
        {
            InitializeComponent();
            this.loginForm = login;
            this.ExamNo.Text = examNo;
            this.SName.Text = name;
            this.ID.Text = id;
        }

        private void Start_Click(object sender, EventArgs e)
        {
            ClientControl.isResume = false;
            ControlBar controlBar = new ControlBar(this);
            controlBar.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            loginForm.Show();
            this.Dispose();
        }

        private void button_resume_Click(object sender, EventArgs e)
        {
            ClientControl.isResume = true;
            ControlBar controlBar = new ControlBar(this);
            try
            {
                controlBar.Show();
                this.Hide();
            }
            catch
            { }
        }

    }
}
