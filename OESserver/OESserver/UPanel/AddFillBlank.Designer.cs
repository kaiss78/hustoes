namespace OES.UPanel
{
    partial class AddFillBlank
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddFillBlank));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Add_Answer = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.SaveData = new System.Windows.Forms.PictureBox();
            this.Return = new System.Windows.Forms.PictureBox();
            this.contentOfFillblank = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaveData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Return)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(19, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(71, 33);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Add_Answer
            // 
            this.Add_Answer.CausesValidation = false;
            this.Add_Answer.Location = new System.Drawing.Point(18, 126);
            this.Add_Answer.Name = "Add_Answer";
            this.Add_Answer.Size = new System.Drawing.Size(72, 26);
            this.Add_Answer.TabIndex = 2;
            this.Add_Answer.Text = "添加答案";
            this.Add_Answer.UseVisualStyleBackColor = true;
            this.Add_Answer.Click += new System.EventHandler(this.button1_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(96, 126);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(595, 347);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // SaveData
            // 
            this.SaveData.Image = global::OES.Properties.Resources.btnSaveData;
            this.SaveData.Location = new System.Drawing.Point(76, 479);
            this.SaveData.Name = "SaveData";
            this.SaveData.Size = new System.Drawing.Size(86, 29);
            this.SaveData.TabIndex = 4;
            this.SaveData.TabStop = false;
            this.SaveData.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // Return
            // 
            this.Return.Image = global::OES.Properties.Resources.btnReturn;
            this.Return.Location = new System.Drawing.Point(567, 479);
            this.Return.Name = "Return";
            this.Return.Size = new System.Drawing.Size(89, 29);
            this.Return.TabIndex = 5;
            this.Return.TabStop = false;
            this.Return.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // contentOfFillblank
            // 
            this.contentOfFillblank.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.contentOfFillblank.Location = new System.Drawing.Point(96, 17);
            this.contentOfFillblank.Multiline = true;
            this.contentOfFillblank.Name = "contentOfFillblank";
            this.contentOfFillblank.Size = new System.Drawing.Size(475, 100);
            this.contentOfFillblank.TabIndex = 1;
            // 
            // AddFillBlank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CausesValidation = false;
            this.Controls.Add(this.Return);
            this.Controls.Add(this.SaveData);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.Add_Answer);
            this.Controls.Add(this.contentOfFillblank);
            this.Controls.Add(this.pictureBox1);
            this.Name = "AddFillBlank";
            this.Size = new System.Drawing.Size(742, 553);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaveData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Return)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private  System.Windows.Forms.Button Add_Answer;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox SaveData;
        private System.Windows.Forms.PictureBox Return;
        private  System.Windows.Forms.TextBox contentOfFillblank;
    }
}
