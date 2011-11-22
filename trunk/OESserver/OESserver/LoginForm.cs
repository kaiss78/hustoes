using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OES.Net;

namespace OES
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            #region 网络连接状态初始化
            netState1.ReConnect += new EventHandler(netState1_ReConnect);
            netState1.State = 2;
            ClientEvt.Client.ConnectedServer += new EventHandler(Client_ConnectedServer);
            ClientEvt.Client.DisConnectError += new System.IO.ErrorEventHandler(Client_DisConnectError);
            InfoControl.ClientObj.Init();
            #endregion
        }
        #region 网络连接状态
        void Client_DisConnectError(object sender, System.IO.ErrorEventArgs e)
        {
            while (!this.IsHandleCreated) ;
            this.BeginInvoke(new MethodInvoker(() =>
            {
                netState1.State = 0;
            }));
        }

        void Client_ConnectedServer(object sender, EventArgs e)
        {
            while (!this.IsHandleCreated) ;
            this.BeginInvoke(new MethodInvoker(() =>
            {
                netState1.State = 1;
            }));
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
        #endregion
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

        private void btnConfig_Click(object sender, EventArgs e)
        {
            new ConfigForm().ShowDialog();
        }
    }
}
