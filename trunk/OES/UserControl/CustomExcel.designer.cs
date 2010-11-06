namespace Office
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
            this.Text_Content = new System.Windows.Forms.RichTextBox();
            this.button_check = new System.Windows.Forms.Button();
            this.button_open = new System.Windows.Forms.Button();
            this.button_repeat = new System.Windows.Forms.Button();
            this.button_getPro = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_title
            // 
            this.label_title.AutoSize = true;
            this.label_title.Location = new System.Drawing.Point(93, 47);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(29, 12);
            this.label_title.TabIndex = 0;
            this.label_title.Text = "题目";
            // 
            // Text_Content
            // 
            this.Text_Content.Location = new System.Drawing.Point(95, 108);
            this.Text_Content.Name = "Text_Content";
            this.Text_Content.ReadOnly = true;
            this.Text_Content.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.Text_Content.Size = new System.Drawing.Size(566, 271);
            this.Text_Content.TabIndex = 1;
            this.Text_Content.Text = "";
            // 
            // button_check
            // 
            this.button_check.Location = new System.Drawing.Point(95, 405);
            this.button_check.Name = "button_check";
            this.button_check.Size = new System.Drawing.Size(75, 23);
            this.button_check.TabIndex = 2;
            this.button_check.Text = "评分";
            this.button_check.UseVisualStyleBackColor = true;
            this.button_check.Click += new System.EventHandler(this.button_check_Click);
            // 
            // button_open
            // 
            this.button_open.Location = new System.Drawing.Point(586, 405);
            this.button_open.Name = "button_open";
            this.button_open.Size = new System.Drawing.Size(75, 23);
            this.button_open.TabIndex = 3;
            this.button_open.Text = "打开";
            this.button_open.UseVisualStyleBackColor = true;
            this.button_open.Click += new System.EventHandler(this.button_open_Click);
            // 
            // button_repeat
            // 
            this.button_repeat.Location = new System.Drawing.Point(586, 444);
            this.button_repeat.Name = "button_repeat";
            this.button_repeat.Size = new System.Drawing.Size(75, 23);
            this.button_repeat.TabIndex = 4;
            this.button_repeat.Text = "重做";
            this.button_repeat.UseVisualStyleBackColor = true;
            this.button_repeat.Click += new System.EventHandler(this.button_repeat_Click);
            // 
            // button_getPro
            // 
            this.button_getPro.Location = new System.Drawing.Point(95, 444);
            this.button_getPro.Name = "button_getPro";
            this.button_getPro.Size = new System.Drawing.Size(75, 23);
            this.button_getPro.TabIndex = 5;
            this.button_getPro.Text = "获取题";
            this.button_getPro.UseVisualStyleBackColor = true;
            this.button_getPro.Click += new System.EventHandler(this.button_getPro_Click);
            // 
            // Control_excel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button_getPro);
            this.Controls.Add(this.button_repeat);
            this.Controls.Add(this.button_open);
            this.Controls.Add(this.button_check);
            this.Controls.Add(this.Text_Content);
            this.Controls.Add(this.label_title);
            this.Name = "Control_excel";
            this.Size = new System.Drawing.Size(784, 489);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.RichTextBox Text_Content;
        private System.Windows.Forms.Button button_check;
        private System.Windows.Forms.Button button_open;
        private System.Windows.Forms.Button button_repeat;
        private System.Windows.Forms.Button button_getPro;
    }
}
