namespace Super_Market
{
    partial class Report2
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.super_marketDataSet = new Super_Market.super_marketDataSet();
            this.sellingsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sellingsTableAdapter = new Super_Market.super_marketDataSetTableAdapters.sellingsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.super_marketDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sellingsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource3.Name = "DataSet1";
            reportDataSource3.Value = this.sellingsBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Super_Market.Report2.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(642, 343);
            this.reportViewer1.TabIndex = 0;
            // 
            // super_marketDataSet
            // 
            this.super_marketDataSet.DataSetName = "super_marketDataSet";
            this.super_marketDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sellingsBindingSource
            // 
            this.sellingsBindingSource.DataMember = "sellings";
            this.sellingsBindingSource.DataSource = this.super_marketDataSet;
            // 
            // sellingsTableAdapter
            // 
            this.sellingsTableAdapter.ClearBeforeFill = true;
            // 
            // Report2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 343);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Report2";
            this.Text = "Report2";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Report2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.super_marketDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sellingsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource sellingsBindingSource;
        private super_marketDataSetTableAdapters.sellingsTableAdapter sellingsTableAdapter;
        public Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        public super_marketDataSet super_marketDataSet;
    }
}