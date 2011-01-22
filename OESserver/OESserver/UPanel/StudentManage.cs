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
            stuAdd = null;
            stuEdit = null;
        }

        public override void ReLoad()
        {
            this.Visible = true;
            studentInfoDGV.Visible = true;
            changeBtnEnable(true);
            disposeControl();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void disposeControl()               //消除原来产生的UserControl
        {
            if (stuEdit != null) { stuEdit.Dispose(); }
            if (stuAdd != null) { stuAdd.Dispose(); }
        }

        private void changeBtnEnable(bool en)
        {
            btnAdd.Enabled = btnDelete.Enabled = btnEdit.Enabled = btnQuery.Enabled = en;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            changeBtnEnable(false);
            studentInfoDGV.Visible = false;
            stuAdd = new StudentAdd();
            studentInfoGruop.Controls.Add(stuAdd);
            stuAdd.Dock = DockStyle.Fill;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            changeBtnEnable(false);
            studentInfoDGV.Visible = false;
            stuEdit = new StudentEdit();
            studentInfoGruop.Controls.Add(stuEdit);
            stuEdit.Dock = DockStyle.Fill;
        }
    }
}
