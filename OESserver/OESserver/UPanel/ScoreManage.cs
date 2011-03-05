using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OES.UPanel
{
    public partial class ScoreManage : UserPanel
    {

        List<String> dps = new List<string>();
        List<String> cls = new List<string>();
        List<String> paper = new List<string>();
        public ScoreManage()
        {
            InitializeComponent();
            //将显示学院信息
            if (InfoControl.User.permission == 1)           //admin
                dps = InfoControl.OesData.FindAllDept();
            else
                dps = InfoControl.OesData.FindAllDeptWithTeacher(InfoControl.User.UserName);
           object[] ob = new object[dps.Count];
            for (int i = 0; i < dps.Count; i++)
                ob[i] = dps[i];
            comboDept.Items.AddRange(ob);
            comboDept.SelectedIndex = 0;

            //在combox中显示paper信息
            paper = InfoControl.OesData.FindAllPaper();
            object[] obp = new object[paper.Count];
            for (int i = 0; i < paper.Count; i++)
                obp[i] = paper[i];
            comboPaper.Items.AddRange(obp);
            comboDept.SelectedIndex = 0;

        }
        private void showClassInDept(string dept)
        {
            
            if (InfoControl.User.permission == 1)
                cls = InfoControl.OesData.FindClassNameOfDept(dept);
            else
                cls = InfoControl.OesData.FindClassNameOfDeptWithTeacher(dept, InfoControl.User.UserName);
            object[] ob = new object[cls.Count];
            for (int i = 0; i < cls.Count; i++)
                ob[i] = cls[i];
            comboClass.Items.Clear();
            comboClass.Items.Add("所有学生");
            comboClass.Items.AddRange(ob);
            comboClass.SelectedIndex = 0;
        }

        private void comboDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            showClassInDept(comboDept.Text);
        }

    }
}
