﻿namespace OESOffice
{
    partial class testPowerpoint
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
            this.btnOK = new System.Windows.Forms.Button();
            this.testPointView = new System.Windows.Forms.TreeView();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(349, 420);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(95, 34);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "添加考点";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // testPointView
            // 
            this.testPointView.Location = new System.Drawing.Point(6, 6);
            this.testPointView.Name = "testPointView";
            this.testPointView.Size = new System.Drawing.Size(337, 448);
            this.testPointView.TabIndex = 5;
            this.testPointView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.testPointView_AfterSelect);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.HorizontalScrollbar = true;
            this.checkedListBox1.Location = new System.Drawing.Point(349, 6);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(293, 404);
            this.checkedListBox1.TabIndex = 4;
            // 
            // testPowerpoint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.testPointView);
            this.Controls.Add(this.checkedListBox1);
            this.Name = "testPowerpoint";
            this.Size = new System.Drawing.Size(656, 468);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TreeView testPointView;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
    }
}
