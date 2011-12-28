using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OESMonitor
{
    public partial class MessageContent : Form
    {
        private MessageContent()
        {
            InitializeComponent();
        }
        private static string _msg = "";
        public static string DisplayDialog()
        {
            MessageContent mc = new MessageContent();
            mc.ShowDialog();
            return _msg;
        }
        private void sendButton_Click(object sender, EventArgs e)
        {
            _msg = contentTextBox.Text;
            this.Close();
        }
    }
}
