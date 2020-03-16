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
    public partial class VatCodes : Form
    {
        //System.Data.SqlClient.SqlDataReader DR;
        public VatCodes()
        {
            InitializeComponent();
        }

        private void VatCodes_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string insertVat = ("INSERT INTO VAT(VAT_Codes,VAT_Percentage)VALUES('" + textBoxVatCodes.Text + "','" + textBoxVatRate.Text + "')");
            new sqlconnectionclass().WriteDB(insertVat);
            MessageBox.Show("VAT Codes added Successfully!");
            textBoxVatCodes.Text = "";
            textBoxVatRate.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
