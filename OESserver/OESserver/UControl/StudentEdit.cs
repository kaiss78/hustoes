using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OES.Model;

namespace OES.UControl
{
    public partial class StudentEdit : UserControl
    {
        private Student currentStudent;

        public StudentEdit(Student stu)
        {
            InitializeComponent();
            currentStudent = stu;
            textID.Text = currentStudent.ID;
            textName.Text = currentStudent.sName;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
