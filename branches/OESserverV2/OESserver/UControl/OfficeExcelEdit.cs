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
using OES.Net;

namespace OES.UControl
{
    public partial class OfficeExcelEdit : UserControl
    {
        ProMan aProMan;
        public PointEdit aPointEdit;
        public bool isnew;
        public string anspathPointEdit;
        public OfficeExcelEdit(ProMan pm)
        {
            InitializeComponent();
            aProMan = pm;
        }

        public void fill(List<OfficeExcel> aOfficeExel)
        {
            procon.Text = aOfficeExel[0].problem;
            propath.Text = aOfficeExel[0].rawPath;
            anspath.Text = aOfficeExel[0].ansPath;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                anspath.Text = (openFileDialog2.FileName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                propath.Text = (openFileDialog1.FileName);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!isnew)
            {
                InfoControl.OesData.UpdateOffice(ProList.click_proid, procon.Text, anspath.Text, propath.Text,"2");
            }
            else
            {
                InfoControl.OesData.AddOffice(procon.Text, anspath.Text, propath.Text, "2");
                //ProList.click_proid=//缺数据库返回id
                isnew = false;

            }

            MessageBox.Show("保存成功！");
            //if (aProMan is ProManCho)
            //{
            //    (aProMan as ProManCho).bottomPanel.Show();
            //    (aProMan as ProManCho).titlePanel.Show();
            //    (aProMan as ProManCho).aChptList.newpl();
            //    (aProMan as ProManCho).aProList.Show();
            //}
            //else
            //{
            //    aProMan.bottomPanel.Show();
            //    aProMan.titlePanel.Show();
            //    aProMan.aChptList.newpl();
            //    aProMan.aProList.Show();
            //}

            //this.Hide();
            //ProMan.isediting = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //进行判断，区分proman和promancho
            if (aProMan is ProManCho)
            {
                (aProMan as ProManCho).bottomPanel.Show();
                (aProMan as ProManCho).titlePanel.Show();
                (aProMan as ProManCho).aProList.Show();

            }
            else
            {
                aProMan.bottomPanel.Show();
                aProMan.titlePanel.Show();
                aProMan.aProList.Show();
            }
            this.Hide();
            ProMan.isediting = false;
        }

        private void pointEdit_Click(object sender, EventArgs e)
        {
            if (!isnew)
            {
                InfoControl.ClientObj.LoadExcelT(Convert.ToInt16(ProList.click_proid), Convert.ToInt16(InfoControl.User.Id));//填下xml的函数
                InfoControl.ClientObj.ReceiveFiles();
            }
            anspathPointEdit = anspath.Text;
            aPointEdit = new PointEdit(this);
            aPointEdit.Location = new Point(ProMan.ClWidth, 0);
            if (aProMan is ProManCho)
            {
                (aProMan as ProManCho).Controls.Add(aPointEdit);
            }
            else 
                if(aPointEdit.isLoaded)
                {                 
                    aProMan.Controls.Add(aPointEdit);
                    this.Hide();
                    aPointEdit.Show();
                }            
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            if (!isnew)
            {
                FileConvertHelper.Execute(propath.Text, Convert.ToInt32(ProList.click_proid), OES.Net.FileConvertHelper.ProblemEnum.ExcelP);
                FileConvertHelper.Execute(anspath.Text, Convert.ToInt32(ProList.click_proid), OES.Net.FileConvertHelper.ProblemEnum.ExcelA);
                InfoControl.ClientObj.SaveExcelP(Convert.ToInt16(ProList.click_proid), Convert.ToInt16(InfoControl.User.Id));
                InfoControl.ClientObj.SaveExcelA(Convert.ToInt16(ProList.click_proid), Convert.ToInt16(InfoControl.User.Id));
                InfoControl.ClientObj.SendFiles();
            }
            else
                MessageBox.Show("请先保存");
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (!isnew)
            {
                InfoControl.ClientObj.LoadExcelP(Convert.ToInt16(ProList.click_proid), Convert.ToInt16(InfoControl.User.Id));
                InfoControl.ClientObj.LoadExcelA(Convert.ToInt16(ProList.click_proid), Convert.ToInt16(InfoControl.User.Id));
                InfoControl.ClientObj.ReceiveFiles();
            }
            else
                MessageBox.Show("请先保存");
        }

    }
}
