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
            oesdata.FindProgramAnswerByPID(1);
            //oesdata.FindAllChoice("", -1, 1, -1, 1, 100);
            //oesdata.DeleteProgram(36);
            //oesdata.FindAllProgram("", OES.Model.ProgramPType.Null, 
            //    OES.Model.PLanguage.Null, -1, -1, 1, 100);
            //oesdata.DeleteOffice(3);
            //oesdata.FindAllChoice("", 1, -1, 1, 20);

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

            //MessageBox.Show(oesdata.AddProgram("fsddfsfs", OES.Model.ProgramProblem.ProType.Modify, OES.Model.ProgramProblem.Language.CPP,
            //     1, 1).ToString());
            /*
            string a = "1`1``11``22``33";
            string[] str = a.Split(new string[] { "``" }, StringSplitOptions.RemoveEmptyEntries);
            List<string[]> testImport = new List<string[]>();
            for (int i = 0; i < 5; i++)
            {
                string[] test = new string[9];
                test[0] = "testImport:" + i.ToString() + "-problem";
                test[1] = (i * 19 % 5 + 1).ToString();
                test[2] = (i % 5 + 1).ToString();
                test[3] = (i % 3 == 0 ? "Comp" : (i % 3 == 1 ? "Modi" : "Prog"));
                test[4] = (i % 3 == 0 ? "C" : (i % 3 == 1 ? "Cpp" : "Vb"));
                if (i == 2)
                    test[7] = "111`222`333";
                test[8] = "a0`a1`a2``b0`b1`b2``c0`c1`c2";
                testImport.Add(test);
            }
            oesdata.ImportProgram(testImport);
            */
            Application.Exit();

        }
    }
}
