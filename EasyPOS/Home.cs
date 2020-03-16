using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EasyPOS
{
    public partial class Home : Form
    {
        System.Data.SqlClient.SqlDataReader DR;
        private string pid;
        public Home()
        {
            InitializeComponent();
            lbluser.Text = "Login User: " + Form1.UserName;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Are you sure you want to exit this system", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (d == DialogResult.No)
            {
                //   
            }
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            Users u = new Users();
            u.ShowDialog();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            AddEditPCategory aepc = new AddEditPCategory();
            aepc.ShowDialog();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            AddEditProduct aep = new AddEditProduct();
            aep.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddEditSuppliers aes = new AddEditSuppliers();
            aes.ShowDialog();

        }

        private void btnPOS_Click(object sender, EventArgs e)
        {
            Sales sa = new Sales();
            sa.ShowDialog();

        }

        private void btnStocksReport_Click(object sender, EventArgs e)
        {
            Stocks_Reports sr = new Stocks_Reports();
            sr.ShowDialog();
        }

        private void stockManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void productReplenishmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StockReplenishment Replenish = new StockReplenishment();
            Replenish.ShowDialog();
        }

        private void btnDailySales_Click(object sender, EventArgs e)
        {
            Sales_Report sr = new Sales_Report();
            sr.ShowDialog();
        }

        private void lbluser_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Return_Outwards ro = new Return_Outwards();
            ro.Show();
        }

        private void closingStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //sqlconnectionclass selectpid = new sqlconnectionclass();
            //DR = selectpid.ReadDB("select ProductNo from Products ");
            //if(DR.HasRows)
            //{
            //    while (DR.Read())
            //    {
            //        pid = DR["ProductNo"].ToString();
            //        string inserttousers = ("INSERT INTO closing_stock([ProductNo],[openning],[soldqty],[repqty],[date])VALUES( '" + pid + "',(select isnull(sum(qty),0)as availab from stockin where ProductNo= '" + pid + "')-(select isnull(sum(sqty),0)as qty from sales where ProductNo= '" + pid + "'),(select isnull(sum(sqty),0)as availab from sales where ProductNo= '" + pid + "' and date='" + System.DateTime.Today.AddDays(-1) + "'),(select isnull(sum(qty),0)as availab from stockin where ProductNo= '" + pid + "' and date='" + System.DateTime.Today.AddDays(-1) + "'),'" + System.DateTime.Today.AddDays(-1) + "')");
            //        new sqlconnectionclass().WriteDB(inserttousers);
            //    }
            //    MessageBox.Show("Close Done!");
            //}
        }

        private void addEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditMembers aem = new AddEditMembers();
            aem.Show();
        }

        private void stockConversionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //stockconversion sc = new stockconversion();
            //sc.ShowDialog(this);
        }

        private void membersToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void creditPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Credit_Payment cp = new Credit_Payment();
            cp.ShowDialog();
        }

        private void creditorsStatementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CRStatement cr = new CRStatement();
            cr.ShowDialog();
        }

        private void dailySalesReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Sales_Report ds = new Sales_Report();
            ds.Show();
        }

        private void stocksReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Stocks_Reports sr = new Stocks_Reports();
            //sr.Show();
        }

        private void vatAnalysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vat_Analysis va = new Vat_Analysis();
            va.Show();
        }

        private void stockValuationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stock_Valuation sv = new Stock_Valuation();
            sv.Show();
        }

        private void stockReplenishmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Purchases_Report pr = new Purchases_Report();
            pr.Show();
        }

        private void salesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report_sales rs = new Report_sales();
            rs.Show();
        }

        private void agingReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ageing_Analysis aa = new Ageing_Analysis();
            aa.Show();
        }

        private void listToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Creditors_List cl = new Creditors_List();
            cl.Show();
        }

        private void varianceReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Variance_Report vr = new Variance_Report();
            vr.Show();
        }

        private void addEditToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddEditMembers aem = new AddEditMembers();
            aem.ShowDialog();
        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
