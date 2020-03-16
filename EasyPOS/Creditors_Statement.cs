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
    public partial class Creditors_Statement : Form
    {
        System.Data.SqlClient.SqlDataReader DR;
        public Creditors_Statement()
        {
            InitializeComponent();
        }
        void fill_combo()
        {
            try
            {

                sqlconnectionclass selecttousers = new sqlconnectionclass();
                DR = selecttousers.ReadDB("select * from Credit_Customers ");

                while (DR.Read())
                {
                    string BusinessName = DR.GetString(1);
                    cmbCreditorsName.Items.Add(BusinessName);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            fill_combo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             sqlconnectionclass read4report = new sqlconnectionclass();
             DR = read4report.ReadDB("SELECT dbo.GLedger.Date, dbo.GLedger.Naration, ISNULL(dbo.GLedger.Debit, 0) AS Debit, ISNULL(dbo.GLedger.Credit, 0) AS Credit, dbo.GLedger.Balance, dbo.GLedger.[user] FROM dbo.credit_sales LEFT OUTER JOIN dbo.Credit_Customers ON dbo.credit_sales.credit_customerID = dbo.Credit_Customers.credit_customerID LEFT OUTER JOIN dbo.GLedger ON dbo.Credit_Customers.credit_customerID = dbo.GLedger.credit_customerID LEFT OUTER JOIN dbo.creditPayment ON dbo.GLedger.credit_customerID = dbo.creditPayment.credit_customerID WHERE (dbo.Credit_Customers.BussinessName = '"+cmbCreditorsName.Text +"') AND (dbo.GLedger.Date BETWEEN '"+dateTimePicker1.Value+"' AND '"+dateTimePicker2.Value+"') GROUP BY ISNULL(dbo.GLedger.Debit, 0), ISNULL(dbo.GLedger.Credit, 0), dbo.GLedger.Balance, dbo.GLedger.credit_customerID, dbo.Credit_Customers.BussinessName, dbo.GLedger.Naration, dbo.GLedger.Date, dbo.GLedger.[user]");
            if (DR.HasRows)
            {
                CRStatement cr = new CRStatement();
                cr.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void Creditors_Statement_Load(object sender, EventArgs e)
        {

        }
    }
}
