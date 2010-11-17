namespace OES.UControl
{
    partial class CustomExcel
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
            this.label_title = new System.Windows.Forms.Label();
            this.Question = new System.Windows.Forms.RichTextBox();
            this.button_check = new System.Windows.Forms.Button();
            this.button_open = new System.Windows.Forms.Button();
            this.button_repeat = new System.Windows.Forms.Button();
            this.button_getPro = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_title
            // 
            this.label_title.AutoSize = true;
            this.label_title.Location = new System.Drawing.Point(40, 101);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(29, 12);
            this.label_title.TabIndex = 0;
            this.label_title.Text = "题干";
            // 
            // Question
            // 
            this.Question.Location = new System.Drawing.Point(40, 128);
            this.Question.Name = "Question";
            this.Question.ReadOnly = true;
            this.Question.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.Question.Size = new System.Drawing.Size(665, 243);
            this.Question.TabIndex = 1;
            this.Question.Text = "";
            // 
            // button_check
            // 
            this.button_check.Location = new System.Drawing.Point(152, 420);
            this.button_check.Name = "button_check";
            this.button_check.Size = new System.Drawing.Size(75, 23);
            this.button_check.TabIndex = 2;
            this.button_check.Text = "评分";
            this.button_check.UseVisualStyleBackColor = true;
            this.button_check.Click += new System.EventHandler(this.button_check_Click);
            // 
            // button_open
            // 
            this.button_open.Location = new System.Drawing.Point(604, 388);
            this.button_open.Name = "button_open";
            this.button_open.Size = new System.Drawing.Size(101, 40);
            this.button_open.TabIndex = 3;
            this.button_open.Text = "打开";
            this.button_open.UseVisualStyleBackColor = true;
            this.button_open.Click += new System.EventHandler(this.button_open_Click);
            // 
            // button_repeat
            // 
            this.button_repeat.Location = new System.Drawing.Point(606, 434);
            this.button_repeat.Name = "button_repeat";
            this.button_repeat.Size = new System.Drawing.Size(101, 40);
            this.button_repeat.TabIndex = 4;
            this.button_repeat.Text = "重做";
            this.button_repeat.UseVisualStyleBackColor = true;
            this.button_repeat.Click += new System.EventHandler(this.button_repeat_Click);
            // 
            // button_getPro
            // 
            this.button_getPro.Location = new System.Drawing.Point(42, 420);
            this.button_getPro.Name = "button_getPro";
            this.button_getPro.Size = new System.Drawing.Size(75, 23);
            this.button_getPro.TabIndex = 5;
            this.button_getPro.Text = "获取题";
            this.button_getPro.UseVisualStyleBackColor = true;
            this.button_getPro.Click += new System.EventHandler(this.button_getPro_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox1.Location = new System.Drawing.Point(42, 37);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(664, 52);
            this.richTextBox1.TabIndex = 8;
            this.richTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "题目要求";
            // 
            // CustomExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button_getPro);
            this.Controls.Add(this.button_repeat);
            this.Controls.Add(this.button_open);
            this.Controls.Add(this.button_check);
            this.Controls.Add(this.Question);
            this.Controls.Add(this.label_title);
            this.Name = "CustomExcel";
            this.Size = new System.Drawing.Size(784, 489);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.RichTextBox Question;
        private System.Windows.Forms.Button button_check;
        private System.Windows.Forms.Button button_open;
        private System.Windows.Forms.Button button_repeat;
        private System.Windows.Forms.Button button_getPro;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
    }
}
