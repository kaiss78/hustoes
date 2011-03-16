using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
 
using System.Text;
using System.Windows.Forms;
using OES.Model;
using OES.Error;
using OES.Net;

namespace OES
{
    public partial class LoginForm : Form
    {        
        public LoginForm()
        {
            InitializeComponent();
            ClientEvt.LoginReturn += new EventHandler(ClientEvt_LoginReturn);
        }

        void ClientEvt_LoginReturn(object sender, EventArgs e)
        {
            this.Invoke(new MethodInvoker(() =>
                        {
                            if (sender != null)
                            {
                                ClientEvt.Paper = sender.ToString();
                                ClientControl.ExamForm.Show();
                                this.Hide();
                            }
                            else
                            {
                                ErrorControl.ShowError(ErrorType.LoginNoPersonError);
                            }
                        }));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butLogin_Click(object sender, EventArgs e)
        {
            //获取当前学生信息
            ClientControl.student = new Student(this.SName.Text,"", this.ExamNo.Text, this.Password.Text);
            
            //递交服务端验证……
            ClientEvt.validStudent(ClientControl.student.sName, ClientControl.student.ID, ClientControl.student.password);
            //
            
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            ClientControl.LoginForm = this;
        }
    }
}
