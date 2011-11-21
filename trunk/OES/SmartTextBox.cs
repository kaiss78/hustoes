using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TextBoxS
{
    public partial class SmartTextBox : TextBox
    {
        public SmartTextBox()
        {
            InitializeComponent();
            base.BorderStyle = BorderStyle.None;
        }
        private string inText = "";
        public string InText
        {
            set
            {
                string[] lines = value.Split('\n');
                int linenum=0;
                string result = "";
                foreach (string line in lines)
                {
                    result += InsertLineEnter(line);
                }
                base.Text = result;
                for (int i = 0; i < result.Length; i++)
                {
                    if (result[i] == '\n') linenum++;
                }
                base.Height = (int)(linenum * base.FontHeight);
                inText = value;
            }
            get
            {
                return inText;
            }
        }
        private int lineCount = 20;
        public int LineCount
        {
            get { return lineCount; }
            set { lineCount = value; }
        }
        private string InsertLineEnter(string s)
        {
            string result = "";
            int len = Encoding.Default.GetBytes(s).Length;
            int begin = 0;
            if (len > lineCount)
            {
                while (len > lineCount)
                {
                    int k = 1;
                    while (begin+k-1<s.Length && Encoding.Default.GetBytes(s.Substring(begin, k)).Length <= lineCount)
                    {
                        k++;
                    }
                    k--;
                    result += s.Substring(begin, k) + "\r\n";
                    len -= Encoding.Default.GetBytes(s.Substring(begin, k)).Length;
                    begin += k;
                }
                result += s.Substring(begin) + "\r\n";
            }
            else
            {
                result = s + "\r\n";
            }
            return result;
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
