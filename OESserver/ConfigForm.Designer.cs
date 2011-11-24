namespace OES
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
            this.groupBoxClientConfig = new System.Windows.Forms.GroupBox();
            this.groupBoxPathConfig = new System.Windows.Forms.GroupBox();
            this.groupBoxDbConfig = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // groupBoxClientConfig
            // 
            this.groupBoxClientConfig.Location = new System.Drawing.Point(12, 12);
            this.groupBoxClientConfig.Name = "groupBoxClientConfig";
            this.groupBoxClientConfig.Size = new System.Drawing.Size(262, 325);
            this.groupBoxClientConfig.TabIndex = 0;
            this.groupBoxClientConfig.TabStop = false;
            this.groupBoxClientConfig.Text = "服务器端Ip端口配置";
            // 
            // groupBoxPathConfig
            // 
            this.groupBoxPathConfig.Location = new System.Drawing.Point(280, 12);
            this.groupBoxPathConfig.Name = "groupBoxPathConfig";
            this.groupBoxPathConfig.Size = new System.Drawing.Size(262, 325);
            this.groupBoxPathConfig.TabIndex = 1;
            this.groupBoxPathConfig.TabStop = false;
            this.groupBoxPathConfig.Text = "目录路径配置";
            // 
            // groupBoxDbConfig
            // 
            this.groupBoxDbConfig.Location = new System.Drawing.Point(548, 12);
            this.groupBoxDbConfig.Name = "groupBoxDbConfig";
            this.groupBoxDbConfig.Size = new System.Drawing.Size(262, 325);
            this.groupBoxDbConfig.TabIndex = 1;
            this.groupBoxDbConfig.TabStop = false;
            this.groupBoxDbConfig.Text = "数据库配置";
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 349);
            this.Controls.Add(this.groupBoxDbConfig);
            this.Controls.Add(this.groupBoxPathConfig);
            this.Controls.Add(this.groupBoxClientConfig);
            this.Name = "ConfigForm";
            this.Text = "ConfigForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxClientConfig;
        private System.Windows.Forms.GroupBox groupBoxPathConfig;
        private System.Windows.Forms.GroupBox groupBoxDbConfig;
    }
}