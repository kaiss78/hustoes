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
    public partial class AddWord : UserPanel
    {
        int mode = 0;           //新增或修改 分别为0和1
        FileInfo fori, fans, fxml;
        string tmpDir;

        public AddWord()
        {
            InitializeComponent();
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
            ofd.Filter = "Word文档(*.doc)|*.doc";
            if (ofd.ShowDialog() == DialogResult.OK)
                textOriPPT.Text = ofd.FileName;
        }

        private void btnAnsSel_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Word文档(*.doc)|*.doc";
            if (ofd.ShowDialog() == DialogResult.OK)
                textAnsPPT.Text = ofd.FileName;
        }
    }
}
