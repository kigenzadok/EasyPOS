namespace EasyPOS
{
    partial class Price_List
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.easyposDataSet1 = new EasyPOS.easyposDataSet1();
            this.ProductsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ProductsTableAdapter = new EasyPOS.easyposDataSet1TableAdapters.ProductsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.easyposDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.AutoSize = true;
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.ProductsBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "EasyPOS.Price_List.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(666, 439);
            this.reportViewer1.TabIndex = 0;
            // 
            // easyposDataSet1
            // 
            this.easyposDataSet1.DataSetName = "easyposDataSet1";
            this.easyposDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ProductsBindingSource
            // 
            this.ProductsBindingSource.DataMember = "Products";
            this.ProductsBindingSource.DataSource = this.easyposDataSet1;
            // 
            // ProductsTableAdapter
            // 
            this.ProductsTableAdapter.ClearBeforeFill = true;
            // 
            // Price_List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 439);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Price_List";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Price_List";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Price_List_Load);
            ((System.ComponentModel.ISupportInitialize)(this.easyposDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ProductsBindingSource;
        private easyposDataSet1 easyposDataSet1;
        private easyposDataSet1TableAdapters.ProductsTableAdapter ProductsTableAdapter;
    }
}