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
    public partial class LoginForm : Form
    {        
        public LoginForm()
        {
            InitializeComponent();           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butLogin_Click(object sender, EventArgs e)
        {
            Student student = new Student(this.SName.Text, this.ExamNo.Text, "123456789", this.Password.Text);
            ExamForm examForm = new ExamForm(this);
            examForm.Show();
            this.Hide();
        }
    }
}
