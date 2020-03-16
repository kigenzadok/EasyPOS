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
    public partial class Stocks_Reports : Form
    {
         System.Data.SqlClient.SqlDataReader DR;
        public Stocks_Reports()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Price_List pl = new Price_List();
            pl.Show();
        }

        private void btnStockReplenish_Click(object sender, EventArgs e)
        {

            //label1.Text = "From Date";
            //label2.Text = "To Date";
           // if (btnStockReplenish.Text == "Stock Replenishment")
           // {
           //     dateTimePickerfrom.Text = "";
           // }
           //// else if (EditButton.Text == "Update")
           // {
           // }
        }

        private void Stocks_Reports_Load(object sender, EventArgs e)
        {
            Label l= new Label();
        }

        private void GenerateStatementBtn_Click(object sender, EventArgs e)
        {
            //try
            //{
            sqlconnectionclass read4report = new sqlconnectionclass();
            DR = read4report.ReadDB("SELECT stockin.rep_no, products.productName,stockin.qty, stockin.unitprice,stockin.vat,stockin.totalcost,stockin.greplenishno,stockin.suppliername, stockin.date FROM stockin INNER JOIN products ON products.productno=stockin.productno where stockin.Date between '" + DateTime.Parse(dateTimePickerfrom.Text) + "' and '" + DateTime.Parse(dateTimePickerTo.Text) + "'");//'" + DateTime.Parse(dtpfrom.Text) + "' and date<='" + DateTime.Parse(dtpto.Text) + "' "
            if (DR.HasRows)
            {
             

            }
            }

                //catch (Exception exc)
                //{
                //     MessageBox.Show(""+exc);   
                //}
        }
        }

       
    //}

