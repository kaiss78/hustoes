using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OES.Model;
using OES.Error;

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
            //获取当前学生信息
            Student student = new Student(this.SName.Text, this.ExamNo.Text, "123456789", this.Password.Text);
            
            //递交服务端验证……
            //
            //
            if (true)
            {
                ClientControl.ExamForm.Show();
                this.Hide();
            }
            else
            {
                ErrorControl.ShowError(ErrorType.LoginNoPersonError);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            ClientControl.LoginForm = this;
            ClientControl.ExamForm = new ExamForm();
            ClientControl.ControlBar = new ControlBar();
            ClientControl.MainForm = new MainForm();
            ClientControl.WaitingForm = new WaitingForm();
        }
    }
}
