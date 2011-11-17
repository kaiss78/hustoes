using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace OES
{
    public partial class ConfigEditor : UserControl
    {
        private Dictionary<string, string> dict = new Dictionary<string, string>();

        private OESConfig config;

        public OESConfig Config
        {
            get { return config; }
            set 
            {
                config = value;
                if (config != null)
                {
                    dict = config.GetAllConfig();
                    foreach (string key in dict.Keys)
                    {
                        configDataGridView.Rows.Add(key, dict[key]);
                    }
                }
                else
                {
                    Console.WriteLine("配置文件出错!");
                }
            }
        }
        private string configFilePath = "";

        public string ConfigFilePath
        {
            get 
            {
                return configFilePath; 
            }
            set
            {
                if (File.Exists(value))
                {
                    configFilePath = value;
                    Config = new OESConfig(configFilePath);
                }
                else
                {
                    Console.WriteLine(configFilePath+" 文件不存在!");
                }
            }
        }
        public ConfigEditor(string filePath)
        {
            InitializeComponent();
            ConfigFilePath = filePath;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            dict.Clear();
            foreach (DataGridViewRow row in configDataGridView.Rows)
            {
                if (row.Cells[0].Value!=null && row.Cells[1].Value!=null)
                {
                    dict.Add(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString());
                }
            }
            config.SetAllConfig(dict);
            MessageBox.Show("需要当前配置生效，必须重启该软件。");
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            configDataGridView.Rows.Clear();
            ConfigFilePath = configFilePath;
        }
    }
}
