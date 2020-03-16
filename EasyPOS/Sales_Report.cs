using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EasyPOS
{
    public partial class Sales_Report : Form
    {
        System.Data.SqlClient.SqlDataReader DR;
        public Sales_Report()
        {
            InitializeComponent();
        }

        private void Sales_Report_Load(object sender, EventArgs e)
        {
            crystalReportViewer1.Refresh();
        }

        private void Loadbtn_Click(object sender, EventArgs e)
        {
            //try
        //    {
        //        sqlconnectionclass read4report = new sqlconnectionclass();
        //        DR = read4report.ReadDB("SELECT dbo.Sales.ProductNo, dbo.Products.ProductName, ISNULL(SUM(dbo.Sales.sqty), 0) AS QTY, SUM(dbo.Sales.Totalcost) AS TotalCost, ISNULL(SUM(dbo.Sales.sqty), 0) * dbo.Products.BuyingPrice AS PurchaseTotal, dbo.Sales.date FROM dbo.Sales INNER JOIN dbo.Products ON dbo.Sales.ProductNo = dbo.Products.ProductNo WHERE (dbo.Sales.date convert(date,[timestamp]) = '" + dateTimeFrom.Value + "') GROUP BY dbo.Sales.ProductNo, dbo.Products.ProductName, dbo.Products.BuyingPrice, dbo.Sales.date");
        //        if (DR.HasRows)
        //        {


        //        }
        //    }

        //    catch (Exception exc)
        //    {
        //        MessageBox.Show("" + exc);
        //    }
        }

        private void reportViewer2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Daily_Sales ds = new Daily_Sales();
            //ds.Show();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
