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

        private delegate void ShowMessage();
        public CommandLine(string logFileName)
        {
            InitializeComponent();
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.logFileName = logFileName;
        }
        public void showMessage(string message)
        {
            listView1.BeginInvoke(new MethodInvoker(() => {
                if (!string.IsNullOrEmpty(logFileName))
                {
                    using (StreamWriter sw = new StreamWriter(logFileName, true, Encoding.Default))
                    {
                        sw.WriteLine(message);
                    }
                }
                listView1.Items.Add(message);
                listView1.SelectedIndex = listView1.Items.Count - 1;
            }));
        }
    }
}
