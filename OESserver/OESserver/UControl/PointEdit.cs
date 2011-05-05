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
    public partial class PointEdit : UserControl
    {
        public OfficeExcelEdit aOfficeExcelEdit;
        public PointEdit(OfficeExcelEdit exl)
        {
            InitializeComponent();
            aOfficeExcelEdit = exl;
            try { openExcelFile(@"F:\Excel\ExcelFile\lkq.xls"); }
            catch 
            {
                MessageBox.Show("打开文件失败！", "添加考点", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //界面跳转
            }
        }

        private void openExcelFile(string fileName)
        {
            testExcel1.loadExcel(fileName);
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            //TODO: Upload File To Server.
            MessageBox.Show("上传完成！(加方法......)");
            testExcel1.CloseExcel();
            //TODO: 界面跳转
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您当前编辑的考点未保存，是否确认退出？", "确认操作", 
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                testExcel1.CloseExcel();
                //TODO: 界面跳转
            }
        }


    }
}
