namespace OES.UControl
{
    partial class ProPreview
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
            this.ProText = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnSelectPro = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.SuspendLayout();
            // 
            // ProText
            // 
            this.ProText.Location = new System.Drawing.Point(3, 52);
            this.ProText.Margin = new System.Windows.Forms.Padding(5);
            this.ProText.Name = "ProText";
            this.ProText.ReadOnly = true;
            this.ProText.Size = new System.Drawing.Size(507, 554);
            this.ProText.StateCommon.Content.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ProText.TabIndex = 0;
            this.ProText.Text = "Text";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(3, 3);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(116, 43);
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.kryptonLabel1.TabIndex = 1;
            this.kryptonLabel1.Values.Text = "题干：";
            // 
            // btnSelectPro
            // 
            this.btnSelectPro.AutoSize = true;
            this.btnSelectPro.Location = new System.Drawing.Point(400, 620);
            this.btnSelectPro.Name = "btnSelectPro";
            this.btnSelectPro.Size = new System.Drawing.Size(101, 35);
            this.btnSelectPro.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSelectPro.StateCommon.Border.Rounding = 16;
            this.btnSelectPro.StateCommon.Content.ShortText.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSelectPro.TabIndex = 2;
            this.btnSelectPro.Values.Text = "选择题目";
            // 
            // ProPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSelectPro);
            this.Controls.Add(this.kryptonLabel1);
            this.Controls.Add(this.ProText);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ProPreview";
            this.Size = new System.Drawing.Size(515, 666);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public ComponentFactory.Krypton.Toolkit.KryptonRichTextBox ProText;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        public ComponentFactory.Krypton.Toolkit.KryptonButton btnSelectPro;
    }
}
