namespace EasyPOS
{
    partial class Sales_Report
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
            this.dateTimeFrom = new System.Windows.Forms.DateTimePicker();
            this.dateTimeTodate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Loadbtn = new System.Windows.Forms.Button();
            this.dateTimeTo = new System.Windows.Forms.DateTimePicker();
            this.Daily_Sales_ReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CrystalReportsales1 = new EasyPOS.CrystalReportsales();
            this.sales2 = new EasyPOS.sales();
            this.sales1 = new EasyPOS.sales();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.CrystalReportsaler1 = new EasyPOS.CrystalReportsaler();
            ((System.ComponentModel.ISupportInitialize)(this.Daily_Sales_ReportBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.AutoSize = true;
            this.reportViewer1.DocumentMapWidth = 1;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = null;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "EasyPOS.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(-2, 40);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(2, 2);
            this.reportViewer1.TabIndex = 0;
            // 
            // dateTimeFrom
            // 
            this.dateTimeFrom.Location = new System.Drawing.Point(85, 14);
            this.dateTimeFrom.Name = "dateTimeFrom";
            this.dateTimeFrom.Size = new System.Drawing.Size(197, 20);
            this.dateTimeFrom.TabIndex = 1;
            // 
            // dateTimeTodate
            // 
            this.dateTimeTodate.Location = new System.Drawing.Point(340, 12);
            this.dateTimeTodate.Name = "dateTimeTodate";
            this.dateTimeTodate.Size = new System.Drawing.Size(196, 20);
            this.dateTimeTodate.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "From Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(288, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "To Date";
            // 
            // Loadbtn
            // 
            this.Loadbtn.Location = new System.Drawing.Point(542, 13);
            this.Loadbtn.Name = "Loadbtn";
            this.Loadbtn.Size = new System.Drawing.Size(75, 23);
            this.Loadbtn.TabIndex = 6;
            this.Loadbtn.Text = "Load";
            this.Loadbtn.UseVisualStyleBackColor = true;
            this.Loadbtn.Click += new System.EventHandler(this.Loadbtn_Click);
            // 
            // dateTimeTo
            // 
            this.dateTimeTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeTo.Location = new System.Drawing.Point(245, 12);
            this.dateTimeTo.Name = "dateTimeTo";
            this.dateTimeTo.Size = new System.Drawing.Size(95, 20);
            this.dateTimeTo.TabIndex = 2;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = 0;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ReportSource = this.CrystalReportsaler1;
            this.crystalReportViewer1.Size = new System.Drawing.Size(895, 507);
            this.crystalReportViewer1.TabIndex = 7;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.crystalReportViewer1.Load += new System.EventHandler(this.crystalReportViewer1_Load);
            // 
            // Sales_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(895, 507);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.Loadbtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimeTodate);
            this.Controls.Add(this.dateTimeFrom);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Sales_Report";
            this.Text = "Sales_Report";
            this.Load += new System.EventHandler(this.Sales_Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Daily_Sales_ReportBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.DateTimePicker dateTimeFrom;
        private System.Windows.Forms.DateTimePicker dateTimeTodate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Loadbtn;
        private System.Windows.Forms.DateTimePicker dateTimeTo;
        private System.Windows.Forms.BindingSource Daily_Sales_ReportBindingSource;
        //private easyposDataSet5TableAdapters.Daily_Sales_ReportTableAdapter Daily_Sales_ReportTableAdapter;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private sales sales1;
        private sales sales2;
        private CrystalReportsales CrystalReportsales1;
        private CrystalReportsaler CrystalReportsaler1;
    }
}