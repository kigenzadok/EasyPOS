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
    public partial class stockconversion : Form
    {
        System.Data.SqlClient.SqlDataReader DR1;
        string ProductNod, ProductNods, Suppliernamed = "ConvertingTSI", Suppliernames = "ConvertingFOI", deliverymode = "NA", note_no = "NA", VATs, VATd, TVATs, TVATd, Totalcosts, Totalcostd, unitprices, unitpriced;
        public stockconversion()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            Getproducts();
        }

        private void Getproducts()
        {
            comboBox1.Items.Clear();
            sqlconnectionclass selectusers = new sqlconnectionclass();
            DR1 = selectusers.ReadDB("select * from Products where itemtype='SI'");

            if (DR1.HasRows)
            {
                while (DR1.Read())
                {
                    comboBox1.Items.Add(DR1[0] + ":" + DR1[1]);
                    ProductNods = DR1[0].ToString();
                    VATs = DR1[12].ToString();
                    unitprices = DR1[8].ToString();
                }
            }
        }

        private void comboBox2_DropDown(object sender, EventArgs e)
        {
            fillproducts();
        }

        private void fillproducts()
        {
            comboBox2.Items.Clear();
            sqlconnectionclass selectusers = new sqlconnectionclass();
            DR1 = selectusers.ReadDB("select * from Products where itemtype='OI'");

            if (DR1.HasRows)
            {
                while (DR1.Read())
                {
                    comboBox2.Items.Add(DR1[0] + ":" + DR1[1]);
                    ProductNod = DR1[0].ToString();
                    VATd = DR1[12].ToString();
                    unitpriced = DR1[9].ToString();
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string pid = comboBox1.Text.Split(':')[0];
            sqlconnectionclass selecttousers = new sqlconnectionclass();
            DR1 = selecttousers.ReadDB("select baseqty,((select isnull(sum(qty),0)as availab from stockin where ProductNo= '" + pid + "')-(select isnull(sum(sqty),0)as qty from sales where ProductNo= '" + pid + "')) As available from products where ProductNo='" + pid + "'");
            while (DR1.Read())
            {
                textBox1.Text = DR1[1].ToString();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string pid = comboBox2.Text.Split(':')[0];
            sqlconnectionclass selecttousers = new sqlconnectionclass();
            DR1 = selecttousers.ReadDB("select baseqty,((select isnull(sum(qty),0)as availab from stockin where ProductNo= '" + pid + "')-(select isnull(sum(sqty),0)as qty from sales where ProductNo= '" + pid + "')) As available from products where ProductNo='" + pid + "'");
            while (DR1.Read())
            {
                textBox2.Text = DR1[1].ToString();
                label9.Text = DR1[0].ToString();
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox3.TextLength > 0)
                {
                    if (Convert.ToInt32(textBox3.Text) > Convert.ToInt32(textBox1.Text))
                    {
                        MessageBox.Show("You will not convert more than what is in source quantity!");
                        textBox3.Text = "0";
                    }
                    else
                    {
                        try
                        {
                            if (textBox3.TextLength > 0)
                            {
                                textBox4.Text = (Convert.ToInt32(textBox3.Text) * Convert.ToInt32(label9.Text)).ToString();
                            }
                            else
                            {
                                textBox4.Text = "0";
                            }
                        }
                        catch (NoNullAllowedException) { }
                    }
                }
            }
            catch (NotFiniteNumberException) { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int replenish = 0;
            Totalcostd = (Convert.ToInt32(textBox4.Text) * Convert.ToInt32(unitpriced)).ToString();
            Totalcosts = (Convert.ToInt32(textBox3.Text) *(-1)* Convert.ToInt32(unitprices)).ToString();
            TVATd = (Convert.ToInt32(Totalcostd)*Convert.ToInt32(VATd) / 100).ToString();
            TVATs = (Convert.ToInt32(Totalcosts)*Convert.ToInt32(VATs)/100).ToString();
            sqlconnectionclass getrepno = new sqlconnectionclass();
            DR1 = getrepno.ReadDB("select top 1 greplenishno from stockin ORDER BY greplenishno DESC");
            if (DR1.HasRows)
            {
                DR1.Read();

                replenish = Convert.ToInt32(DR1[0])+1;
            }
            else { replenish = 1; }
            float qtys =Convert.ToInt32(textBox3.Text)*(-1);
            //save source
            string insertsource = "INSERT INTO [stockin]([ProductNo],[Suppliername],[deliverymode],[note_no],[qty],[VAT],[Totalcost],[unitprice],[greplenishno],[date])VALUES('" + ProductNods + "','" + Suppliernames + "','" + deliverymode + "','" + note_no + "','" +qtys+ "','" + TVATs + "','" + Totalcosts + "','" + unitprices + "','" + replenish + "','" + System.DateTime.Now + "')";
            new sqlconnectionclass().WriteDB(insertsource);
            string insertdes = "INSERT INTO [stockin]([ProductNo],[Suppliername],[deliverymode],[note_no],[qty],[VAT],[Totalcost],[unitprice],[greplenishno],[date])VALUES('" + ProductNod + "','" + Suppliernamed + "','" + deliverymode + "','" + note_no + "','" + textBox4.Text + "','" + TVATd + "','" + Totalcostd + "','" + unitpriced + "','" + replenish + "','" + System.DateTime.Now + "')";
            new sqlconnectionclass().WriteDB(insertdes);
            MessageBox.Show("Done converting stock");
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";
            textBox4.Text = "0";
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";
            textBox4.Text = "0";
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
