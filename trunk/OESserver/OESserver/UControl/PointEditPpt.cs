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
    public partial class PointEditPpt : UserControl
    {
        public OfficePowerpointEdit aOfficePowerpointEdit;
        public Boolean isLoaded;
        public PointEditPpt(OfficePowerpointEdit ppt)
        {
            InitializeComponent();
            aOfficePowerpointEdit = ppt;
            try 
            {
                testPowerpoint1.LoadPowerpoint(aOfficePowerpointEdit.anspathPointEdit,"C:\\test.xml");
                isLoaded = true; 
            }
            catch 
            {
                isLoaded = false;
                MessageBox.Show("打开文件失败！", "添加考点", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //界面跳转
            }
        }



        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("您当前编辑的考点未保存，是否确认退出？", "确认操作",
               MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                testPowerpoint1.ClosePPT();
                aOfficePowerpointEdit.Show();//TODO: 界面跳转
                this.Dispose();
            }
        }

        private void btnComplete_Click_1(object sender, EventArgs e)
        {
            //TODO: Upload File To Server.
            MessageBox.Show("上传完成！(加方法......)");
            testPowerpoint1.ClosePPT();
            aOfficePowerpointEdit.Show();//TODO: 界面跳转
            this.Dispose();
        }
    }
}
