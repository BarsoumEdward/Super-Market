namespace Super_Market
{
    partial class Report_Form
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.sellingsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.super_marketDataSet = new Super_Market.super_marketDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.sellingsTableAdapter = new Super_Market.super_marketDataSetTableAdapters.sellingsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.sellingsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.super_marketDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // sellingsBindingSource
            // 
            this.sellingsBindingSource.DataMember = "sellings";
            this.sellingsBindingSource.DataSource = this.super_marketDataSet;
            // 
            // super_marketDataSet
            // 
            this.super_marketDataSet.DataSetName = "super_marketDataSet";
            this.super_marketDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.sellingsBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Super_Market.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(3, 3);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(673, 291);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // sellingsTableAdapter
            // 
            this.sellingsTableAdapter.ClearBeforeFill = true;
            // 
            // Report_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 306);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Report_Form";
            this.Text = "Report_Form";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Report_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sellingsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.super_marketDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource sellingsBindingSource;
        private super_marketDataSetTableAdapters.sellingsTableAdapter sellingsTableAdapter;
        public Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        public super_marketDataSet super_marketDataSet;
    }
}