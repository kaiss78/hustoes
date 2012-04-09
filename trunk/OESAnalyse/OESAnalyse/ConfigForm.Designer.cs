namespace OESAnalyse
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
            this.groupBoxDbConfig = new System.Windows.Forms.GroupBox();
            this.groupBoxPathConfig = new System.Windows.Forms.GroupBox();
            this.groupBoxServerConfig = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // groupBoxDbConfig
            // 
            this.groupBoxDbConfig.Location = new System.Drawing.Point(632, 12);
            this.groupBoxDbConfig.Name = "groupBoxDbConfig";
            this.groupBoxDbConfig.Size = new System.Drawing.Size(269, 317);
            this.groupBoxDbConfig.TabIndex = 5;
            this.groupBoxDbConfig.TabStop = false;
            this.groupBoxDbConfig.Text = "数据库配置";
            // 
            // groupBoxPathConfig
            // 
            this.groupBoxPathConfig.Location = new System.Drawing.Point(322, 12);
            this.groupBoxPathConfig.Name = "groupBoxPathConfig";
            this.groupBoxPathConfig.Size = new System.Drawing.Size(269, 317);
            this.groupBoxPathConfig.TabIndex = 4;
            this.groupBoxPathConfig.TabStop = false;
            this.groupBoxPathConfig.Text = "路径配置";
            // 
            // groupBoxServerConfig
            // 
            this.groupBoxServerConfig.Location = new System.Drawing.Point(12, 12);
            this.groupBoxServerConfig.Name = "groupBoxServerConfig";
            this.groupBoxServerConfig.Size = new System.Drawing.Size(266, 317);
            this.groupBoxServerConfig.TabIndex = 6;
            this.groupBoxServerConfig.TabStop = false;
            this.groupBoxServerConfig.Text = "服务器Ip端口配置";
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 347);
            this.Controls.Add(this.groupBoxServerConfig);
            this.Controls.Add(this.groupBoxDbConfig);
            this.Controls.Add(this.groupBoxPathConfig);
            this.Name = "ConfigForm";
            this.Text = "ConfigForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxDbConfig;
        private System.Windows.Forms.GroupBox groupBoxPathConfig;
        private System.Windows.Forms.GroupBox groupBoxServerConfig;
    }
}