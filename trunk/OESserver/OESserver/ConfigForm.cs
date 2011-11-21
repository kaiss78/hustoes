using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OES
{
    public partial class ConfigForm : Form
    {
        private ConfigEditor clientConfig = new ConfigEditor("ClientConfig.xml");
        private ConfigEditor dbConfig = new ConfigEditor("DbConfig.xml");
        private ConfigEditor pathConfig = new ConfigEditor("PathConfig.xml");
        public ConfigForm()
        {
            InitializeComponent();

            groupBoxClientConfig.Controls.Add(clientConfig);
            clientConfig.Dock = DockStyle.Fill;
            clientConfig.Show();

            groupBoxDbConfig.Controls.Add(dbConfig);
            dbConfig.Dock = DockStyle.Fill;
            dbConfig.Show();

            groupBoxPathConfig.Controls.Add(pathConfig);
            pathConfig.Dock = DockStyle.Fill;
            pathConfig.Show();
        }
    }
}
