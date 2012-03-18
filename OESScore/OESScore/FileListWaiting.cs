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
    public partial class FileListWaiting : Form
    {
        private static FileListWaiting instance;

        public static FileListWaiting Instance
        {
            get 
            {
                if (instance == null || instance.IsDisposed) instance = new FileListWaiting();
                return FileListWaiting.instance; 
            }
        }

        public void setProcessBar(int value)
        {
            progressBar1.Value = value;
        }

        public void setText(int value)
        {
            label1.Text = "还剩"+value.ToString()+"个文件";
        }
        private FileListWaiting()
        {
            InitializeComponent();
            progressBar1.Maximum = 1000;
        }
    }
}
