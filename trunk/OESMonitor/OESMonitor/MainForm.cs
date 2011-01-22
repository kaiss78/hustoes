using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OESMonitor.Net;

namespace OESMonitor
{
    public partial class OESMonitor : Form
    {
        public List<Computer> ComputerList = new List<Computer>();
        CommandLine cl = new CommandLine();
        private delegate void UpdatePanel(Client c);
        public OESMonitor()
        {
            InitializeComponent();
            Net.MessageSupervisor.mainForm = this;
            Net.MessageSupervisor.targetFrm = cl;
            cl.Show();
            Program.server = new Net.OESServer();

        }
        public void addComputer(Client client)
        {
            flowLayoutPanel1.Invoke(new UpdatePanel(AddComputer), client);
        }
        public void AddComputer(Client client)
        {
            Computer com=new Computer();
            com.State=1;
            com.client = client;
            ComputerList.Add(com);
            UpdateList();
        }
        private void UpdateList()
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (Computer c in ComputerList)
            {
                flowLayoutPanel1.Controls.Add(c);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            flowLayoutPanel1.Controls.Add(new Computer());
        }
    }
}
