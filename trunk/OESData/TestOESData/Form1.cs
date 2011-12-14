using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OES;

namespace TestOESData
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public OESData oesdata=new OESData();
        private void button1_Click(object sender, EventArgs e)
        {
            //oesdata.FindAllChoice("d", -1, -1, 1, 10);
            //MessageBox.Show(oesdata.AddChoice("testChoice", "A", "B", "C", "D", "A", 1, 2).ToString());
            //oesdata.DeleteChoice(55);
            //oesdata.UpdateChoice(54, "UpdatedChoice", "A", "B", "C", "D", "A", 1, 2);
            //oesdata.FindChoiceByPID(54);
            //oesdata.FindAllChoice("", -1, -1, 1, 1000);
            
            //oesdata.DeleteCompletion(13);
            //oesdata.UpdateCompletion(11, "运行的快捷键是【1】?", 1, 2, new List<string>() { "Ctrl+R", "Ctrl-R" });
            //oesdata.FindCompletionAnswerByPID(13);
            //oesdata.FindCompletionAnswerByPID(11);
            //oesdata.FindCompletionByPID(11);
            //oesdata.FindAllCompletion("：", -1, -1, 1, 10);
            //oesdata.FindCompletionByPID(11);
            //int x = oesdata.FindItemsCount("Choice", "d", -1, -1, -1, -1);

            //MessageBox.Show(oesdata.AddJudgment("1+2=3.", "T", 1, 2).ToString());
            //oesdata.DeleteJudgment(11);
            //oesdata.UpdateJudgment(12, "3+4=5.", "F", 1, 3);
            //oesdata.FindJudgmentByPID(12);
            //MessageBox.Show(oesdata.FindAllJudgment("", -1, -1, 1, 1000).Count.ToString());

            //MessageBox.Show(oesdata.AddOffice("第2道PPT", 1, 2, OESData.OfficeType.PowerPoint).ToString());
            //oesdata.DeleteOffice(4);
            //oesdata.UpdateOffice(3, "Updated PPT", 3, 5, OESData.OfficeType.PowerPoint);
            Application.Exit();

        }
    }
}
