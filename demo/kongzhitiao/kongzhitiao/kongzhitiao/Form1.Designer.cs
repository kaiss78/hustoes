namespace kongzhitiao
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.jiaojuan = new System.Windows.Forms.Button();
            this.shijian = new System.Windows.Forms.Button();
            this.stuinfo = new System.Windows.Forms.Button();
            this.shiti = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // jiaojuan
            // 
            this.jiaojuan.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.jiaojuan.Image = global::kongzhitiao.Properties.Resources.调整大小_Submit;
            this.jiaojuan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.jiaojuan.Location = new System.Drawing.Point(459, -1);
            this.jiaojuan.Name = "jiaojuan";
            this.jiaojuan.Size = new System.Drawing.Size(95, 36);
            this.jiaojuan.TabIndex = 3;
            this.jiaojuan.Text = "   交卷";
            this.jiaojuan.UseVisualStyleBackColor = true;
            // 
            // shijian
            // 
            this.shijian.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.shijian.Image = global::kongzhitiao.Properties.Resources.调整大小_2;
            this.shijian.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.shijian.Location = new System.Drawing.Point(337, -1);
            this.shijian.Name = "shijian";
            this.shijian.Size = new System.Drawing.Size(128, 36);
            this.shijian.TabIndex = 2;
            this.shijian.Text = "  ";
            this.shijian.UseVisualStyleBackColor = true;
            // 
            // stuinfo
            // 
            this.stuinfo.CausesValidation = false;
            this.stuinfo.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.stuinfo.Image = global::kongzhitiao.Properties.Resources._1;
            this.stuinfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.stuinfo.Location = new System.Drawing.Point(131, -1);
            this.stuinfo.Name = "stuinfo";
            this.stuinfo.Size = new System.Drawing.Size(210, 36);
            this.stuinfo.TabIndex = 1;
            this.stuinfo.Text = "    stuinfo";
            this.stuinfo.UseVisualStyleBackColor = true;
            // 
            // shiti
            // 
            this.shiti.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.shiti.Image = ((System.Drawing.Image)(resources.GetObject("shiti.Image")));
            this.shiti.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.shiti.Location = new System.Drawing.Point(-1, -1);
            this.shiti.Name = "shiti";
            this.shiti.Size = new System.Drawing.Size(135, 36);
            this.shiti.TabIndex = 0;
            this.shiti.Text = "   隐藏试题";
            this.shiti.UseVisualStyleBackColor = true;
            this.shiti.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 32);
            this.ControlBox = false;
            this.Controls.Add(this.jiaojuan);
            this.Controls.Add(this.shijian);
            this.Controls.Add(this.stuinfo);
            this.Controls.Add(this.shiti);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button shiti;
        private System.Windows.Forms.Button stuinfo;
        private System.Windows.Forms.Button shijian;
        private System.Windows.Forms.Button jiaojuan;
        private System.Windows.Forms.Timer timer1;
    }
}

