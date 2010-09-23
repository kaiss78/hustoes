namespace oesdemoliuyuan
{
    partial class Fillingintheblank
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.EMcontest = new System.Windows.Forms.ListBox();
            this.radioButtonA = new System.Windows.Forms.RadioButton();
            this.radioButtonB = new System.Windows.Forms.RadioButton();
            this.radioButtonC = new System.Windows.Forms.RadioButton();
            this.radioButtonD = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.laststep = new System.Windows.Forms.Button();
            this.nextstep = new System.Windows.Forms.Button();
            this.groupchoice = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.groupchoice.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "题目要求";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(85, 13);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(303, 28);
            this.listBox1.TabIndex = 1;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // EMcontest
            // 
            this.EMcontest.FormattingEnabled = true;
            this.EMcontest.ItemHeight = 12;
            this.EMcontest.Location = new System.Drawing.Point(3, 3);
            this.EMcontest.Name = "EMcontest";
            this.EMcontest.Size = new System.Drawing.Size(382, 88);
            this.EMcontest.TabIndex = 3;
            this.EMcontest.SelectedIndexChanged += new System.EventHandler(this.EMcontest_SelectedIndexChanged);
            // 
            // radioButtonA
            // 
            this.radioButtonA.AutoSize = true;
            this.radioButtonA.Location = new System.Drawing.Point(6, 20);
            this.radioButtonA.Name = "radioButtonA";
            this.radioButtonA.Size = new System.Drawing.Size(95, 16);
            this.radioButtonA.TabIndex = 4;
            this.radioButtonA.TabStop = true;
            this.radioButtonA.Text = "radioButtonA";
            this.radioButtonA.UseVisualStyleBackColor = true;
            this.radioButtonA.CheckedChanged += new System.EventHandler(this.radioButtonA_CheckedChanged);
            // 
            // radioButtonB
            // 
            this.radioButtonB.AutoSize = true;
            this.radioButtonB.Location = new System.Drawing.Point(6, 51);
            this.radioButtonB.Name = "radioButtonB";
            this.radioButtonB.Size = new System.Drawing.Size(95, 16);
            this.radioButtonB.TabIndex = 5;
            this.radioButtonB.TabStop = true;
            this.radioButtonB.Text = "radioButtonB";
            this.radioButtonB.UseVisualStyleBackColor = true;
            this.radioButtonB.CheckedChanged += new System.EventHandler(this.radioButtonB_CheckedChanged);
            // 
            // radioButtonC
            // 
            this.radioButtonC.AutoSize = true;
            this.radioButtonC.Location = new System.Drawing.Point(6, 82);
            this.radioButtonC.Name = "radioButtonC";
            this.radioButtonC.Size = new System.Drawing.Size(95, 16);
            this.radioButtonC.TabIndex = 6;
            this.radioButtonC.TabStop = true;
            this.radioButtonC.Text = "radioButtonC";
            this.radioButtonC.UseVisualStyleBackColor = true;
            this.radioButtonC.CheckedChanged += new System.EventHandler(this.radioButtonC_CheckedChanged);
            // 
            // radioButtonD
            // 
            this.radioButtonD.AutoSize = true;
            this.radioButtonD.Location = new System.Drawing.Point(6, 118);
            this.radioButtonD.Name = "radioButtonD";
            this.radioButtonD.Size = new System.Drawing.Size(95, 16);
            this.radioButtonD.TabIndex = 7;
            this.radioButtonD.TabStop = true;
            this.radioButtonD.Text = "radioButtonD";
            this.radioButtonD.UseVisualStyleBackColor = true;
            this.radioButtonD.CheckedChanged += new System.EventHandler(this.radioButtonD_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Location = new System.Drawing.Point(18, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(415, 53);
            this.panel1.TabIndex = 8;
            // 
            // laststep
            // 
            this.laststep.Location = new System.Drawing.Point(36, 361);
            this.laststep.Name = "laststep";
            this.laststep.Size = new System.Drawing.Size(75, 23);
            this.laststep.TabIndex = 9;
            this.laststep.Text = "上一步";
            this.laststep.UseVisualStyleBackColor = true;
            // 
            // nextstep
            // 
            this.nextstep.Location = new System.Drawing.Point(343, 361);
            this.nextstep.Name = "nextstep";
            this.nextstep.Size = new System.Drawing.Size(75, 23);
            this.nextstep.TabIndex = 10;
            this.nextstep.Text = "下一步";
            this.nextstep.UseVisualStyleBackColor = true;
            // 
            // groupchoice
            // 
            this.groupchoice.Controls.Add(this.radioButtonA);
            this.groupchoice.Controls.Add(this.radioButtonB);
            this.groupchoice.Controls.Add(this.radioButtonC);
            this.groupchoice.Controls.Add(this.radioButtonD);
            this.groupchoice.Location = new System.Drawing.Point(3, 114);
            this.groupchoice.Name = "groupchoice";
            this.groupchoice.Size = new System.Drawing.Size(382, 140);
            this.groupchoice.TabIndex = 11;
            this.groupchoice.TabStop = false;
            this.groupchoice.Text = "groupchoice";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.EMcontest);
            this.panel2.Controls.Add(this.groupchoice);
            this.panel2.Location = new System.Drawing.Point(18, 62);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(415, 285);
            this.panel2.TabIndex = 12;
            // 
            // Fillingintheblank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.nextstep);
            this.Controls.Add(this.laststep);
            this.Controls.Add(this.panel1);
            this.Name = "Fillingintheblank";
            this.Size = new System.Drawing.Size(448, 395);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupchoice.ResumeLayout(false);
            this.groupchoice.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox EMcontest;
        private System.Windows.Forms.RadioButton radioButtonA;
        private System.Windows.Forms.RadioButton radioButtonB;
        private System.Windows.Forms.RadioButton radioButtonC;
        private System.Windows.Forms.RadioButton radioButtonD;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button laststep;
        private System.Windows.Forms.Button nextstep;
        private System.Windows.Forms.GroupBox groupchoice;
        private System.Windows.Forms.Panel panel2;
    }
}
