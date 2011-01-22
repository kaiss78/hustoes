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
    public partial class CommandLine : Form
    {
        private string _msg;

        private delegate void ShowMessage();
        public CommandLine()
        {
            InitializeComponent();
        }
        public void showMessage(string message)
        {
            _msg = message;
            listView1.Invoke(new ShowMessage(UpdateUI));
            //ServerMessage_listBox.Items.Add(message);
        }

        private void UpdateUI()
        {
            listView1.Items.Add(_msg);

        }
    }
}
