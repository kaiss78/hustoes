using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OES.UPanel;
using OES.Model;

namespace OES.UControl
{
    public partial class CCompletionEdit : UserControl
    {
        ProMan aProMan;
        public bool isnew = false;
        public CCompletionEdit(ProMan pm)
        {
            InitializeComponent();
            aProMan = pm;
        }

        public void fill(List<PCompletion> aPCompletion)
        {
            procon.Text = aPCompletion[0].problem;
            propath.Text = aPCompletion[0].path;
            anscon1.Text = aPCompletion[0].ans1;
            anscon2.Text = aPCompletion[0].ans2;
            anscon3.Text = aPCompletion[0].ans3;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                propath.Text=(openFileDialog1.FileName);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!isnew)
            {
                InfoControl.OesData.UpdateCompletionModificationProgram(ProList.click_proid, "1", procon.Text, propath.Text, anscon1.Text, anscon2.Text, anscon3.Text,"1");
            }
            else
            {
                InfoControl.OesData.AddCompletionModificationProgram("1", procon.Text, propath.Text, anscon1.Text, anscon2.Text, anscon3.Text, "1");
            }

            MessageBox.Show("保存成功！");
            aProMan.bottomPanel.Show();
            aProMan.titlePanel.Show();
            this.Hide();
            ProMan.isediting = false;
            aProMan.aChptList.newpl();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            aProMan.bottomPanel.Show();
            aProMan.titlePanel.Show();
            aProMan.aProList.Show();
            this.Hide();
            ProMan.isediting = false;
        }
    }
}
