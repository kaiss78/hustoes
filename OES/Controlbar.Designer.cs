namespace OES
{
    partial class ControlBar
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.butHandIn = new System.Windows.Forms.Button();
            this.time = new System.Windows.Forms.Button();
            this.studentID = new System.Windows.Forms.Button();
            this.butHideMF = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // butHandIn
            // 
            this.butHandIn.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butHandIn.Image = global::OES.Properties.Resources.调整大小_Submit;
            this.butHandIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHandIn.Location = new System.Drawing.Point(459, -1);
            this.butHandIn.Name = "butHandIn";
            this.butHandIn.Size = new System.Drawing.Size(95, 36);
            this.butHandIn.TabIndex = 3;
            this.butHandIn.Text = "   交卷";
            this.butHandIn.UseVisualStyleBackColor = true;
            this.butHandIn.Click += new System.EventHandler(this.butHandIn_Click);
            // 
            // time
            // 
            this.time.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.time.Image = global::OES.Properties.Resources.调整大小_2;
            this.time.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.time.Location = new System.Drawing.Point(337, -1);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(128, 36);
            this.time.TabIndex = 2;
            this.time.Text = "  ";
            this.time.UseVisualStyleBackColor = true;
            // 
            // studentID
            // 
            this.studentID.CausesValidation = false;
            this.studentID.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.studentID.Image = global::OES.Properties.Resources._1;
            this.studentID.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.studentID.Location = new System.Drawing.Point(131, -1);
            this.studentID.Name = "studentID";
            this.studentID.Size = new System.Drawing.Size(210, 36);
            this.studentID.TabIndex = 1;
            this.studentID.Text = "studentID";
            this.studentID.UseVisualStyleBackColor = true;
            // 
            // butHideMF
            // 
            this.butHideMF.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butHideMF.Image = global::OES.Properties.Resources.调整大小_调整大小_图标源;
            this.butHideMF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHideMF.Location = new System.Drawing.Point(-1, -1);
            this.butHideMF.Name = "butHideMF";
            this.butHideMF.Size = new System.Drawing.Size(135, 36);
            this.butHideMF.TabIndex = 0;
            this.butHideMF.Text = "   隐藏试题";
            this.butHideMF.UseVisualStyleBackColor = true;
            this.butHideMF.Click += new System.EventHandler(this.button1_Click);
            // 
            // ControlBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 32);
            this.ControlBox = false;
            this.Controls.Add(this.butHandIn);
            this.Controls.Add(this.time);
            this.Controls.Add(this.studentID);
            this.Controls.Add(this.butHideMF);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ControlBar";
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button butHideMF;
        private System.Windows.Forms.Button studentID;
        private System.Windows.Forms.Button time;
        private System.Windows.Forms.Button butHandIn;
        private System.Windows.Forms.Timer timer1;
    }
}

