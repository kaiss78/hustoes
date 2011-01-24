using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OES.UPanel;
using OES.Properties;
using OES.Model;


namespace OES.UControl
{
    public partial class ChoiceEdit : UserControl
    {
        ProMan aProMan;
        public string answer;
        public bool isnew = false; 

        public ChoiceEdit(ProMan pm)
        {
            InitializeComponent();
            aProMan = pm;

            A.BackgroundImage = Resources.circle_red;
            A.BackgroundImageLayout = ImageLayout.Stretch;
            B.BackgroundImage = Resources.circle_black;
            B.BackgroundImageLayout = ImageLayout.Stretch;
            C.BackgroundImage = Resources.circle_black;
            C.BackgroundImageLayout = ImageLayout.Stretch;
            D.BackgroundImage = Resources.circle_black;
            D.BackgroundImageLayout = ImageLayout.Stretch;

            

        }

        
        private void button6_Click(object sender, EventArgs e)
        {
            aProMan.bottomPanel.Show();
            aProMan.titlePanel.Show();
            aProMan.aProList.Show();
            this.Hide();          
        }
        //填充进题目信息
        public void fill(List<Choice> achoice,string chpt)
        {
            chptlbl.Text = ChptList.click_name;
            procon.Text = achoice[0].problem;
            Atxt.Text = achoice[0].optionA;
            Btxt.Text = achoice[0].optionB;
            Ctxt.Text = achoice[0].optionC;
            Dtxt.Text = achoice[0].optionD;

            switch (achoice[0].ans)
            { 
                case "A":
                    optioncontrol("A");
                    break;
                case "B":
                    optioncontrol("B");
                    break;
                case "C":
                    optioncontrol("C");
                    break;
                case "D":
                    optioncontrol("D");
                    break;
            }
        }

        //写入函数，题目信息写进数据库

        //对选项按钮进行控制，无法多选
        public void optioncontrol(string s)
        {
            switch (s)
            { 
                case "A":
                    A.BackgroundImage = Resources.circle_red;
                    B.BackgroundImage = Resources.circle_black;
                    C.BackgroundImage = Resources.circle_black;
                    D.BackgroundImage = Resources.circle_black;
                    answer = "A";
                    break;
                case "B":
                    A.BackgroundImage = Resources.circle_black;
                    B.BackgroundImage = Resources.circle_red;
                    C.BackgroundImage = Resources.circle_black;
                    D.BackgroundImage = Resources.circle_black;
                    answer = "B";
                    break;
                case "C":
                    A.BackgroundImage = Resources.circle_black;
                    B.BackgroundImage = Resources.circle_black;
                    C.BackgroundImage = Resources.circle_red;
                    D.BackgroundImage = Resources.circle_black;
                    answer = "C";
                    break;
                case "D":
                    A.BackgroundImage = Resources.circle_black;
                    B.BackgroundImage = Resources.circle_black;
                    C.BackgroundImage = Resources.circle_black;
                    D.BackgroundImage = Resources.circle_red;
                    answer = "D";
                    break;


            }
        }

        private void A_Click(object sender, EventArgs e)
        {
            optioncontrol("A");
        }

        private void B_Click(object sender, EventArgs e)
        {
            optioncontrol("B");
        }

        private void C_Click(object sender, EventArgs e)
        {
            optioncontrol("C");
        }

        private void D_Click(object sender, EventArgs e)
        {
            optioncontrol("D");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!isnew)
            {
                InfoControl.OesData.UpdateChoice(ProList.click_proid, procon.Text, Atxt.Text, Btxt.Text, Ctxt.Text, Dtxt.Text, answer, Convert.ToInt32(ChptList.click_num));
            }
            else
            {
                InfoControl.OesData.AddChoice( procon.Text, Atxt.Text, Btxt.Text, Ctxt.Text, Dtxt.Text, answer, Convert.ToInt32(ChptList.click_num));
            }
            MessageBox.Show("保存成功！");
            aProMan.bottomPanel.Show();
            aProMan.titlePanel.Show();
            this.Hide();
            aProMan.aChptList.newpl();
        }



    }
}
