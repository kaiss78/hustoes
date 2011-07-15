using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OES.UPanel;

namespace OES.UControl
{
    public partial class AddChapter : UserControl
    {
        ProMan aProMan;
        public AddChapter(ProMan pm)
        {
            InitializeComponent();
            aProMan = pm;
            switch (aProMan.ProType)
            { 
                case 0:
                    title.Text = "选择题";
                    break;
                case 1:
                    title.Text = "填空题";
                    break;               
                case 2:
                    title.Text = "判断题";
                    break;
                //case 3:
                //    title.Text = "电子表格";
                //    break;
                //case 4:
                //    title.Text = "演示文稿";
                //    break;
                //case 5:
                //    title.Text = "字处理";
                //    break;
                //case 6:
                //    title.Text = "C程序填空";
                //    break;
                //case 7:
                //    title.Text = "C程序改错";
                //    break;
                //case 8:
                //    title.Text = "C程序编程";
                //    break;
                //case 9:
                //    title.Text = "C++程序填空";
                //    break;
                //case 10:
                //    title.Text = "C++程序改错";
                //    break;
                //case 11:
                //    title.Text = "C++程序编程";
                //    break;
            }
        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            InfoControl.OesData.AddUnit(rtxtNewChapterName.Text); 
            MessageBox.Show("添加成功！");
            rtxtNewChapterName.Text = null;
            aProMan.aChptList.RefreshChptLst();
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
            aProMan.aProList.Show();
            aProMan.ShowTBPanel();
        }
    }
}
