namespace OES.UPanel
{
    partial class AddExcel
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
            this.groupInfo = new System.Windows.Forms.GroupBox();
            this.btnXmlSel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textXmlExcel = new System.Windows.Forms.TextBox();
            this.buttonTestPoint = new System.Windows.Forms.Button();
            this.textInfo = new System.Windows.Forms.TextBox();
            this.labelInfo = new System.Windows.Forms.Label();
            this.textOriExcel = new System.Windows.Forms.TextBox();
            this.btnAnsSel = new System.Windows.Forms.Button();
            this.labelOriPPT = new System.Windows.Forms.Label();
            this.btnOriSel = new System.Windows.Forms.Button();
            this.labelAnsPPT = new System.Windows.Forms.Label();
            this.textAnsExcel = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupInfo
            // 
            this.groupInfo.Controls.Add(this.btnXmlSel);
            this.groupInfo.Controls.Add(this.label1);
            this.groupInfo.Controls.Add(this.textXmlExcel);
            this.groupInfo.Controls.Add(this.buttonTestPoint);
            this.groupInfo.Controls.Add(this.textInfo);
            this.groupInfo.Controls.Add(this.labelInfo);
            this.groupInfo.Controls.Add(this.textOriExcel);
            this.groupInfo.Controls.Add(this.btnAnsSel);
            this.groupInfo.Controls.Add(this.labelOriPPT);
            this.groupInfo.Controls.Add(this.btnOriSel);
            this.groupInfo.Controls.Add(this.labelAnsPPT);
            this.groupInfo.Controls.Add(this.textAnsExcel);
            this.groupInfo.Location = new System.Drawing.Point(12, 3);
            this.groupInfo.Name = "groupInfo";
            this.groupInfo.Size = new System.Drawing.Size(715, 472);
            this.groupInfo.TabIndex = 8;
            this.groupInfo.TabStop = false;
            this.groupInfo.Text = "XLS文件/路径信息";
            // 
            // btnXmlSel
            // 
            this.btnXmlSel.Location = new System.Drawing.Point(546, 72);
            this.btnXmlSel.Name = "btnXmlSel";
            this.btnXmlSel.Size = new System.Drawing.Size(75, 23);
            this.btnXmlSel.TabIndex = 12;
            this.btnXmlSel.Text = "浏览...";
            this.btnXmlSel.UseVisualStyleBackColor = true;
            this.btnXmlSel.Click += new System.EventHandler(this.btnXmlSel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "考点xml文件";
            // 
            // textXmlExcel
            // 
            this.textXmlExcel.Location = new System.Drawing.Point(116, 74);
            this.textXmlExcel.Name = "textXmlExcel";
            this.textXmlExcel.Size = new System.Drawing.Size(412, 21);
            this.textXmlExcel.TabIndex = 20;
            this.textXmlExcel.Text = "F:\\点维工作室\\lkq.xml";
            // 
            // buttonTestPoint
            // 
            this.buttonTestPoint.Location = new System.Drawing.Point(116, 101);
            this.buttonTestPoint.Name = "buttonTestPoint";
            this.buttonTestPoint.Size = new System.Drawing.Size(412, 38);
            this.buttonTestPoint.TabIndex = 9;
            this.buttonTestPoint.Text = "点此建立新考点";
            this.buttonTestPoint.UseVisualStyleBackColor = true;
            this.buttonTestPoint.Click += new System.EventHandler(this.buttonTestPoint_Click);
            // 
            // textInfo
            // 
            this.textInfo.Location = new System.Drawing.Point(116, 145);
            this.textInfo.Multiline = true;
            this.textInfo.Name = "textInfo";
            this.textInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textInfo.Size = new System.Drawing.Size(412, 232);
            this.textInfo.TabIndex = 8;
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Location = new System.Drawing.Point(40, 145);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(53, 12);
            this.labelInfo.TabIndex = 7;
            this.labelInfo.Text = "题干描述";
            // 
            // textOriExcel
            // 
            this.textOriExcel.Location = new System.Drawing.Point(116, 20);
            this.textOriExcel.Name = "textOriExcel";
            this.textOriExcel.Size = new System.Drawing.Size(412, 21);
            this.textOriExcel.TabIndex = 3;
            this.textOriExcel.Text = "F:\\点维工作室\\stulkq.xls";
            // 
            // btnAnsSel
            // 
            this.btnAnsSel.Location = new System.Drawing.Point(546, 45);
            this.btnAnsSel.Name = "btnAnsSel";
            this.btnAnsSel.Size = new System.Drawing.Size(75, 23);
            this.btnAnsSel.TabIndex = 6;
            this.btnAnsSel.Text = "浏览...";
            this.btnAnsSel.UseVisualStyleBackColor = true;
            this.btnAnsSel.Click += new System.EventHandler(this.btnAnsSel_Click);
            // 
            // labelOriPPT
            // 
            this.labelOriPPT.AutoSize = true;
            this.labelOriPPT.Location = new System.Drawing.Point(38, 24);
            this.labelOriPPT.Name = "labelOriPPT";
            this.labelOriPPT.Size = new System.Drawing.Size(71, 12);
            this.labelOriPPT.TabIndex = 1;
            this.labelOriPPT.Text = "初始XLS文件";
            // 
            // btnOriSel
            // 
            this.btnOriSel.Location = new System.Drawing.Point(546, 18);
            this.btnOriSel.Name = "btnOriSel";
            this.btnOriSel.Size = new System.Drawing.Size(75, 23);
            this.btnOriSel.TabIndex = 5;
            this.btnOriSel.Text = "浏览...";
            this.btnOriSel.UseVisualStyleBackColor = true;
            this.btnOriSel.Click += new System.EventHandler(this.btnOriSel_Click);
            // 
            // labelAnsPPT
            // 
            this.labelAnsPPT.AutoSize = true;
            this.labelAnsPPT.Location = new System.Drawing.Point(38, 51);
            this.labelAnsPPT.Name = "labelAnsPPT";
            this.labelAnsPPT.Size = new System.Drawing.Size(71, 12);
            this.labelAnsPPT.TabIndex = 2;
            this.labelAnsPPT.Text = "标答XLS文件";
            // 
            // textAnsExcel
            // 
            this.textAnsExcel.Location = new System.Drawing.Point(116, 47);
            this.textAnsExcel.Name = "textAnsExcel";
            this.textAnsExcel.Size = new System.Drawing.Size(412, 21);
            this.textAnsExcel.TabIndex = 4;
            this.textAnsExcel.Text = "F:\\点维工作室\\lkq.xls";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(634, 503);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(93, 30);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "返回";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(535, 503);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(93, 30);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "保存试题";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // AddExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupInfo);
            this.Name = "AddExcel";
            this.Size = new System.Drawing.Size(742, 553);
            this.groupInfo.ResumeLayout(false);
            this.groupInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupInfo;
        private System.Windows.Forms.Button buttonTestPoint;
        private System.Windows.Forms.TextBox textInfo;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.TextBox textOriExcel;
        private System.Windows.Forms.Button btnAnsSel;
        private System.Windows.Forms.Label labelOriPPT;
        private System.Windows.Forms.Button btnOriSel;
        private System.Windows.Forms.Label labelAnsPPT;
        private System.Windows.Forms.TextBox textAnsExcel;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnXmlSel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textXmlExcel;
    }
}
