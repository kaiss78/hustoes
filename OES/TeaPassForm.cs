using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
 
using System.Text;
using System.Windows.Forms;
using OES.Net;

namespace OES
{
    public partial class TeaPassForm : Form
    {
        public TeaPassForm()
        {
            InitializeComponent();
            ClientEvt.ConfirmReStart += new EventHandler(ClientEvt_ConfirmReStart);
        }

        void ClientEvt_ConfirmReStart(object sender, EventArgs e)
        {
            this.Invoke(new MethodInvoker(() =>
            {
                ClientControl.paper.ReadPaper();

                ClientControl.isResume = false;
                ClientControl.ControlBar.Show();
                ClientControl.MainForm.Show();
                this.Dispose();
                ClientControl.TeaPassForm = null;
            }));

        }

        private void CancleButton_Click(object sender, EventArgs e)
        {
            ClientControl.ExamForm.Show();
            this.Dispose();
            ClientControl.TeaPassForm = null;
        }

        private void BeginButton_Click(object sender, EventArgs e)
        {
            //验证教师密码正确性
            //
            ClientEvt.beginExam(3,maskedTextBox1.Text);
            
        }
    }
}
