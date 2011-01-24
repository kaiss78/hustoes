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
    public partial class TeaPassForm : Form
    {
        public TeaPassForm()
        {
            InitializeComponent();
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
            if (maskedTextBox1.Text=="123")
            {
                ClientControl.paper.ReadPaper();

                ClientControl.isResume = false;
                ClientControl.ControlBar.Show();
                ClientControl.MainForm.Show();
                this.Dispose();
                ClientControl.TeaPassForm = null;
                Program.Client.beginExam(3);
            }
            else
            {
                Error.ErrorControl.ShowError(OES.Error.ErrorType.TeacherPassWrong);
            }
        }
    }
}
