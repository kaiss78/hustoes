using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace OESNet
{
    public partial class ThreadsInfo : Form
    {
        public string logName = "threads.log";
        public ThreadsInfo()
        {
            InitializeComponent();
        }
        public void InsertMsg(string msg)
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            this.BeginInvoke(new MethodInvoker(() =>
            {
                listBoxMsg.Items.Add("["+threadId.ToString()+"]" + "\t" + DateTime.Now.ToString() + "\t" + msg);
                using (StreamWriter sw = new StreamWriter(logName,true, Encoding.Default))
                {
                    sw.WriteLine("[" + threadId.ToString() + "]" + "\t" + DateTime.Now.ToString() + "\t" + msg);
                }
            }));
        }

    }
}
