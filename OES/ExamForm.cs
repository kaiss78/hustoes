using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OES.Model;
using System.IO;

namespace OES
{
    public partial class ExamForm : Form
    {
        Config config;
        public ExamForm()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            ClientControl.isResume = false;
            ClientControl.ControlBar.Show();
            this.Hide();
        }

        private void ExamForm_Load(object sender, EventArgs e)
        {
            this.ExamNo.Text = Student.examID;
            this.SName.Text = Student.sName;
            this.ID.Text = Student.ID;
            config = new Config(System.Environment.CurrentDirectory + @"\config.ini");
            Config.stuPath = Config.stuPath + Student.examID + @"\";
            Config.paperPath = Config.paperPath + Paper.pName + @"\";

            if (!File.Exists(Config.paperPath))
            {
                Directory.CreateDirectory(Config.paperPath);
            }

            if (!File.Exists(Config.stuPath))
            {
                Directory.CreateDirectory(Config.stuPath);
            }
        }

        private void Resume_Click(object sender, EventArgs e)
        {
            ClientControl.isResume = true;
            try
            {
                ClientControl.ControlBar.Show();
                this.Hide();
            }
            catch
            {

            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            ClientControl.LoginForm.Show();
            this.Hide();
        }

    }
}
