using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OES.UControl;

namespace OES.UPanel
{
    public partial class StudentManage : UserPanel
    {
        StudentAdd stuAdd;
        StudentEdit stuEdit;

        public StudentManage()
        {
            InitializeComponent();
        }

        public override void ReLoad()
        {
            this.Visible = true;
            studentInfoGruop.Visible = true;
            studentInfoDGV.Visible = true;
            btnAdd.Visible = true;
            btnDelete.Visible = true;
            btnEdit.Visible = true;
            btnQuery.Visible = true;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            studentInfoDGV.Visible = false;
            stuAdd = new StudentAdd();
            studentInfoGruop.Controls.Add(stuAdd);
            stuAdd.Dock = DockStyle.Fill;
        }
    }
}
