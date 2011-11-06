﻿using System;
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
            // 
            // netState1
            // 
            this.netState1 = new OES.NetState(10);
            this.netState1.BackColor = System.Drawing.Color.Transparent;
            this.netState1.Location = new System.Drawing.Point(556, 290);
            this.netState1.Name = "netState1";
            this.netState1.Size = new System.Drawing.Size(208, 26);
            this.netState1.State = 0;
            this.netState1.TabIndex = 9;
            this.Controls.Add(this.netState1);
            ClientEvt.LoginReturn -= ClientEvt_LoginReturn;
            netState1.ReConnect -= netState1_ReConnect;
            ClientEvt.LoginReturn += new EventHandler(ClientEvt_LoginReturn);
            netState1.ReConnect += new EventHandler(netState1_ReConnect);
        }

        void netState1_ReConnect(object sender, EventArgs e)
        {
            if (netState1.State == 0)
            {
                ClientEvt.Client.InitializeClient();
            }
            else
            {
                netState1.State = 0;
            }
        }

        void ClientEvt_LoginReturn(object sender, EventArgs e)
        {
            this.Invoke(new MethodInvoker(() =>
                        {
                            if (sender != null)
                            {
                                ClientEvt.Paper = sender.ToString();
                                ClientControl.ExamForm.Show();
                                ClientControl.ExamForm.ExamForm_Load(ClientControl.ExamForm, null);
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

        public void SetNetState(int state)
        {
            netState1.State = state;
        }
    }
}