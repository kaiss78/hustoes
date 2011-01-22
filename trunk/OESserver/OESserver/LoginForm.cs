﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OES
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Loginbtn_Click(object sender, EventArgs e)
        {
            InfoControl.User = InfoControl.OesData.FindTeacherByLoginName(UserName.Text);
            if (InfoControl.User != null)
            {
                MessageBox.Show(InfoControl.User.Id);
            }
            else
            {

            }
        }
    }
}
