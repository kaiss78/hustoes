namespace OESAnalyse
{
    partial class PieChart
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._pieChartShowObj = new System.Drawing.PieChart.PieChartControl();
            this.SuspendLayout();
            // 
            // _pieChartShowObj
            // 
            this._pieChartShowObj.Location = new System.Drawing.Point(100, 60);
            this._pieChartShowObj.Name = "_pieChartShowObj";
            this._pieChartShowObj.Size = new System.Drawing.Size(592, 333);
            this._pieChartShowObj.TabIndex = 2;
            this._pieChartShowObj.ToolTips = null;
            // 
            // PieChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 461);
            this.Controls.Add(this._pieChartShowObj);
            this.Name = "PieChart";
            this.Text = "PieChart";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Drawing.PieChart.PieChartControl _pieChartShowObj;

    }
}