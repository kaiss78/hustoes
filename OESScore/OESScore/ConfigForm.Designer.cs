namespace OESScore
{
    partial class ConfigForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
            this.groupBoxServerConfig = new System.Windows.Forms.GroupBox();
            this.groupBoxPathConfig = new System.Windows.Forms.GroupBox();
            this.groupBoxDbConfig = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // groupBoxServerConfig
            // 
            this.groupBoxServerConfig.Location = new System.Drawing.Point(13, 13);
            this.groupBoxServerConfig.Name = "groupBoxServerConfig";
            this.groupBoxServerConfig.Size = new System.Drawing.Size(266, 317);
            this.groupBoxServerConfig.TabIndex = 0;
            this.groupBoxServerConfig.TabStop = false;
            this.groupBoxServerConfig.Text = "服务器Ip端口配置";
            // 
            // groupBoxPathConfig
            // 
            this.groupBoxPathConfig.Location = new System.Drawing.Point(296, 13);
            this.groupBoxPathConfig.Name = "groupBoxPathConfig";
            this.groupBoxPathConfig.Size = new System.Drawing.Size(269, 317);
            this.groupBoxPathConfig.TabIndex = 1;
            this.groupBoxPathConfig.TabStop = false;
            this.groupBoxPathConfig.Text = "路径配置";
            // 
            // groupBoxDbConfig
            // 
            this.groupBoxDbConfig.Location = new System.Drawing.Point(571, 13);
            this.groupBoxDbConfig.Name = "groupBoxDbConfig";
            this.groupBoxDbConfig.Size = new System.Drawing.Size(269, 317);
            this.groupBoxDbConfig.TabIndex = 2;
            this.groupBoxDbConfig.TabStop = false;
            this.groupBoxDbConfig.Text = "数据库配置";
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 342);
            this.Controls.Add(this.groupBoxDbConfig);
            this.Controls.Add(this.groupBoxPathConfig);
            this.Controls.Add(this.groupBoxServerConfig);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConfigForm";
            this.Text = "ConfigForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxServerConfig;
        private System.Windows.Forms.GroupBox groupBoxPathConfig;
        private System.Windows.Forms.GroupBox groupBoxDbConfig;
    }
}