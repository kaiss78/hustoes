using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OES.UControl
{
    public partial class PointEditWord : UserControl
    {
        public PointEditWord()
        {
            InitializeComponent();
        }

        public OfficeWordEdit aOfficeWordEdit;
        public Boolean isLoaded;
        public string xmlPath = Config.PPTPath + "t" + ProList.click_proid + ".xml";
        public PointEditWord(OfficeWordEdit word)
        {
            InitializeComponent();
            aOfficeWordEdit = word;
            try 
            {
                testWord1.LoadWord(aOfficeWordEdit.anspathPointEdit, xmlPath);
                isLoaded = true; 
            }
            catch 
            {
                isLoaded = false;
                MessageBox.Show("打开文件失败！", "添加考点", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //界面跳转
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您当前编辑的考点未保存，是否确认退出？", "确认操作",
   MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                testWord1.CloseDocument();
                testWord1.Show();//TODO: 界面跳转
                this.Dispose();
            }
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            //TODO: Upload File To Server.
            MessageBox.Show("上传完成！(加方法......)");
            testWord1.CloseDocument();
            testWord1.Show();//TODO: 界面跳转
            this.Dispose();
        }
    }
}
