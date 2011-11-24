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
        public Boolean isLoaded;
        public string xmlPath = InfoControl.config["ExcelPath"] + "t" + ProList.click_proid + ".xml"; 
        public PointEdit(OfficeExcelEdit exl)
        {
            InitializeComponent();
            aOfficeExcelEdit = exl;
            try 
            {
                openExcelFile(aOfficeExcelEdit.anspathPointEdit);
                isLoaded = true; 
            }
            catch 
            {
                isLoaded = false;
                MessageBox.Show("打开文件失败！", "添加考点", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //界面跳转
            }
        }

        private void openExcelFile(string fileName)
        {
            testExcel1.loadExcel(fileName, xmlPath);
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            InfoControl.ClientObj.SaveExcelT(Convert.ToInt16(ProList.click_proid), Convert.ToInt16(InfoControl.User.Id));
            InfoControl.ClientObj.SendFiles();//TODO: Upload File To Server.填方法上传xml
            MessageBox.Show("上传完成！(加方法......)");
            testExcel1.CloseExcel();
            aOfficeExcelEdit.Show();//TODO: 界面跳转
            this.Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您当前编辑的考点未保存，是否确认退出？", "确认操作", 
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                testExcel1.CloseExcel();
                aOfficeExcelEdit.Show();//TODO: 界面跳转
                this.Dispose();
            }
        }


    }
}
