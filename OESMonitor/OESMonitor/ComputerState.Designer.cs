namespace OESMonitor
{
    partial class ComputerState
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.IpLab = new System.Windows.Forms.Label();
            this.PortLab = new System.Windows.Forms.Label();
            this.IdLab = new System.Windows.Forms.Label();
            this.NameLab = new System.Windows.Forms.Label();
            this.StateLab = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ip地址:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "端口:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "学号:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "姓名:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "状态:";
            // 
            // IpLab
            // 
            this.IpLab.AutoSize = true;
            this.IpLab.Location = new System.Drawing.Point(66, 22);
            this.IpLab.Name = "IpLab";
            this.IpLab.Size = new System.Drawing.Size(41, 12);
            this.IpLab.TabIndex = 5;
            this.IpLab.Text = "label6";
            // 
            // PortLab
            // 
            this.PortLab.AutoSize = true;
            this.PortLab.Location = new System.Drawing.Point(66, 70);
            this.PortLab.Name = "PortLab";
            this.PortLab.Size = new System.Drawing.Size(41, 12);
            this.PortLab.TabIndex = 6;
            this.PortLab.Text = "label7";
            // 
            // IdLab
            // 
            this.IdLab.AutoSize = true;
            this.IdLab.Location = new System.Drawing.Point(66, 117);
            this.IdLab.Name = "IdLab";
            this.IdLab.Size = new System.Drawing.Size(41, 12);
            this.IdLab.TabIndex = 7;
            this.IdLab.Text = "label8";
            // 
            // NameLab
            // 
            this.NameLab.AutoSize = true;
            this.NameLab.Location = new System.Drawing.Point(66, 160);
            this.NameLab.Name = "NameLab";
            this.NameLab.Size = new System.Drawing.Size(41, 12);
            this.NameLab.TabIndex = 8;
            this.NameLab.Text = "label9";
            // 
            // StateLab
            // 
            this.StateLab.AutoSize = true;
            this.StateLab.Location = new System.Drawing.Point(66, 204);
            this.StateLab.Name = "StateLab";
            this.StateLab.Size = new System.Drawing.Size(47, 12);
            this.StateLab.TabIndex = 9;
            this.StateLab.Text = "label10";
            // 
            // ComputerState
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.StateLab);
            this.Controls.Add(this.NameLab);
            this.Controls.Add(this.IdLab);
            this.Controls.Add(this.PortLab);
            this.Controls.Add(this.IpLab);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ComputerState";
            this.Size = new System.Drawing.Size(168, 280);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label IpLab;
        private System.Windows.Forms.Label PortLab;
        private System.Windows.Forms.Label IdLab;
        private System.Windows.Forms.Label NameLab;
        private System.Windows.Forms.Label StateLab;
    }
}
