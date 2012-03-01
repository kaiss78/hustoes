using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace OES.UPanel
{
    public partial class AddExcel : UserPanel
    {
        int mode = 0;
        FileInfo fori, fans, fxml;
        string tmpDir;
        int PID;

        public AddExcel()
        {
            InitializeComponent();
            tmpDir = InfoControl.config["ExcelPath"];
        }

        public override void ReLoad()
        {
            this.Visible = true;
            textInfo.Text = "";
        }

        public void SetMode(int md)
        {
            mode = md;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            PanelControl.ChangPanel(0);
        }

        private void btnOriSel_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "电子表格(*.xls)|*.xls";
            if (ofd.ShowDialog() == DialogResult.OK)
                textOriExcel.Text = ofd.FileName;
        }

        private void btnAnsSel_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "电子表格(*.xls)|*.xls";
            if (ofd.ShowDialog() == DialogResult.OK)
                textAnsExcel.Text = ofd.FileName;
        }

        private void buttonTestPoint_Click(object sender, EventArgs e)
        {
            if (File.Exists(textOriExcel.Text) && File.Exists(textAnsExcel.Text))
            { 
            
            }
        }

    }
}
