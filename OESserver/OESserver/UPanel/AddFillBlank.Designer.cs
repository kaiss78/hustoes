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
            this.Add_Answer = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.contentOfFillblank = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SaveData = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.Return = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.SuspendLayout();
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
            this.Add_Answer.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(96, 126);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(595, 347);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // contentOfFillblank
            // 
            this.contentOfFillblank.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.contentOfFillblank.Location = new System.Drawing.Point(96, 17);
            this.contentOfFillblank.Multiline = true;
            this.contentOfFillblank.Name = "contentOfFillblank";
            this.contentOfFillblank.Size = new System.Drawing.Size(616, 100);
            this.contentOfFillblank.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(5, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "试题题目";
            // 
            // SaveData
            // 
            this.SaveData.Location = new System.Drawing.Point(122, 479);
            this.SaveData.Name = "SaveData";
            this.SaveData.Size = new System.Drawing.Size(105, 39);
            this.SaveData.TabIndex = 7;
            this.SaveData.Values.Text = "保存";
            this.SaveData.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // Return
            // 
            this.Return.Location = new System.Drawing.Point(556, 479);
            this.Return.Name = "Return";
            this.Return.Size = new System.Drawing.Size(100, 39);
            this.Return.TabIndex = 8;
            this.Return.Values.Text = "返回";
            this.Return.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // AddFillBlank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CausesValidation = false;
            this.Controls.Add(this.Return);
            this.Controls.Add(this.SaveData);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.Add_Answer);
            this.Controls.Add(this.contentOfFillblank);
            this.Name = "AddFillBlank";
            this.Size = new System.Drawing.Size(742, 553);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private  System.Windows.Forms.Button Add_Answer;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private  System.Windows.Forms.TextBox contentOfFillblank;
        private System.Windows.Forms.Label label1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton SaveData;
        private ComponentFactory.Krypton.Toolkit.KryptonButton Return;
    }
}
