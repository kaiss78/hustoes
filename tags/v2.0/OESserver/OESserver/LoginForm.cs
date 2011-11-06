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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Loginbtn_Click(object sender, EventArgs e)
        {
            InfoControl.User = InfoControl.OesData.FindTeacherByLoginName(UserName.Text);
            if (InfoControl.User.Equals(null))
            {
                MessageBox.Show("用户名错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (Password.Text == InfoControl.User.password)
                {
                    InfoControl.ClientObj.Login(Convert.ToInt32(InfoControl.User.Id));
                    InfoControl.MainForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("密码错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
