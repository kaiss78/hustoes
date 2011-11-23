using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
 
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace OESMonitor
{
    public partial class CommandLine : Form
    {
        public string logFileName = "";
        private string _msg;

        private delegate void ShowMessage();
        public CommandLine(string logFileName)
        {
            InitializeComponent();
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.logFileName = logFileName;
        }
        public void showMessage(string message)
        {
            _msg = message;
            listView1.Invoke(new ShowMessage(UpdateUI));
            //ServerMessage_listBox.Items.Add(message);
        }

        private void UpdateUI()
        {
            if (!string.IsNullOrEmpty(logFileName))
            {
                using (StreamWriter sw = new StreamWriter(logFileName, true, Encoding.Default))
                {
                    sw.WriteLine(_msg);
                }
            }
            listView1.Items.Add(_msg);
            listView1.SelectedIndex = listView1.Items.Count - 1;
        }
    }
}
