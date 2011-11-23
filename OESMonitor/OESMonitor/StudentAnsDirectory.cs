using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace OESMonitor
{
    public partial class StudentAnsDirectory : UserControl
    {
        public delegate void SignalMsg(StudentAnsDirectory e);
        public event SignalMsg OnView;
        public event SignalMsg OnDelete;
        public StudentAnsDirectory()
        {
            InitializeComponent();
        }
        public StudentAnsDirectory(string path)
        {
            InitializeComponent();
            Text = new DirectoryInfo(path).Name;
        }
        public string Text
        {
            set
            {
                Title.Text = value;
            }
            get
            {
                return Title.Text;
            }
        }

        private void 查看ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OnView != null)
                OnView(this);
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您确定要删除该考生的答案？", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (OnDelete != null)
                    OnDelete(this);
            }
        }


    }
}
