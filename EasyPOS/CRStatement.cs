using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;

namespace EasyPOS
{

    public partial class CRStatement : Form
    {
        // List<CrystalReportcreditor> list;
        System.Data.SqlClient.SqlDataReader DR;
        //List<memberDetails> _member;
        //member _member;
        public CRStatement()
        {
            InitializeComponent();
            //this.list= list; 
            //_member = _member; 
        }
        private string tel,Add;
        void fill_combo()
        {
            try
            {

                sqlconnectionclass selecttousers = new sqlconnectionclass();
                DR = selecttousers.ReadDB("select * from Credit_Customers ");

                if (DR.HasRows)
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

        private void CRStatement_Load(object sender, EventArgs e)
        {
            fill_combo1();
          //  CrystalReportcreditor1.SetDataSource(_member);
        }
        void fill_combo1()
        {
            cmbCreditorsName.Items.Clear();
            sqlconnectionclass selectusers = new sqlconnectionclass();
            DR = selectusers.ReadDB("select * from Credit_Customers");
            if (DR.HasRows)
            {
                while (DR.Read())
                {
                    cmbCreditorsName.Items.Add(DR[1]);
                    tel = Convert.ToString(DR[4]);
                    Add = Convert.ToString(DR[3]);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectme"].ConnectionString);

            SqlCommand cmd = new SqlCommand("SELECT dbo.GLedger.Date, dbo.GLedger.Naration, ISNULL(dbo.GLedger.Debit, 0) AS Debit, ISNULL(dbo.GLedger.Credit, 0) AS Credit, dbo.GLedger.Balance, dbo.GLedger.[user] FROM dbo.credit_sales LEFT OUTER JOIN dbo.Credit_Customers ON dbo.credit_sales.credit_customerID = dbo.Credit_Customers.credit_customerID LEFT OUTER JOIN dbo.GLedger ON dbo.Credit_Customers.credit_customerID = dbo.GLedger.credit_customerID LEFT OUTER JOIN dbo.creditPayment ON dbo.GLedger.credit_customerID = dbo.creditPayment.credit_customerID WHERE (dbo.Credit_Customers.BussinessName = '" + cmbCreditorsName.Text + "') AND (dbo.GLedger.Date BETWEEN '" + dateTimePicker1.Value + "' AND '" + dateTimePicker2.Value + "') GROUP BY ISNULL(dbo.GLedger.Debit, 0), ISNULL(dbo.GLedger.Credit, 0), dbo.GLedger.Balance, dbo.GLedger.credit_customerID, dbo.Credit_Customers.BussinessName, dbo.GLedger.Naration, dbo.GLedger.Date, dbo.GLedger.[user]", conn);

            SqlDataAdapter dscmd = new SqlDataAdapter(cmd);

            DataSet2 ds = new DataSet2();
            dscmd.Fill(ds, "GLedger");
            ds.Tables[0].TableName = "GLedger";

            CrystalReportcreditor objRpt = new CrystalReportcreditor();
            objRpt.SetDataSource(ds);
            objRpt.SetParameterValue("Name",cmbCreditorsName.Text );
            objRpt.SetParameterValue("Telephone", tel);
            objRpt.SetParameterValue("Address", Add);


            //objRpt.SetDataSource(ds.GLedger.Select(c => new
            //{
            //    Date = c.Date,
            //    Naration = c.Naration,
            //    Debit = c.Debit,
            //    Credit = c.Credit,
            //    Balance = c.Balance,
            //    user = c.user

            //}));
            //this.CrystalReportcreditor1.reo
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
            ////}

        }
    }
}
