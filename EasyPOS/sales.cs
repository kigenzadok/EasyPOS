using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using PrinterUtility;
using System.Collections;
using System.IO;
using System.Globalization;


namespace EasyPOS
{
    public partial class Sales : Form
    {
        System.Data.SqlClient.SqlDataReader DR, DR1, dr2; int status;
        float total = 0, unitprice = 0, qty = 0, totalamount = 0, totaladd = 0, Cash = 0, mpesa = 0, Balance = 0, bal = 0, bal2, totalbal, available = 0, totalqty;
        string ReceiptNo = "";
        public Sales()
        {
            InitializeComponent();
            fill_combo();
            foreach (Control ctrl in this.Controls)
            {

                if (ctrl is MdiClient)
                {
                    ctrl.BackColor = SystemColors.Control;
                }


            }
        }
        DataTable table = new DataTable();
        private string pid, cust_id;
        private double Vatrate, totalvat;
        int nextcreditno = 0;
        // private float bal;

        void fill_combo()
        {
            try
            {
                sqlconnectionclass selecttousers = new sqlconnectionclass();
                DR = selecttousers.ReadDB("select * from Products ");

                while (DR.Read())
                {
                    string ProductName = DR.GetString(1);
                    itemsearchBox1.Items.Add(ProductName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        void AutoCompleteText()
        {
            //itemsearchBox1.AutoCompleteMode= AutoCompleteMode.
        }

        private void itemsearchBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            sqlconnectionclass selectpid = new sqlconnectionclass();
            DR1 = selectpid.ReadDB("select ProductNo,vat_rate from Products where productname= '" + itemsearchBox1.Text + "'");
            if (DR1.HasRows)
            {
                DR1.Read();
                pid = DR1["ProductNo"].ToString();
                sqlconnectionclass selecttousers = new sqlconnectionclass();
                DR = selecttousers.ReadDB("select ProductName,(select top 1 unitprice from stockin where productno = '" + pid + "' ORDER BY rep_no DESC ) as currentprice,((select isnull(sum(qty),0)as availab from stockin where ProductNo= '" + pid + "')-(select isnull(sum(sqty),0)as qty from sales where ProductNo= '" + pid + "')) As available from products where ProductNo='" + pid + "'");
                while (DR.Read())
                {
                    string ProductName = (string)DR["ProductName"].ToString(); ;
                    textBoxProductName.Text = ProductName;
                    string RetailPrice = (string)DR["currentprice"].ToString();
                    label11.Visible = true;
                    label12.Visible = true;
                    label12.Text = "KES " + RetailPrice;
                    textBox1.Text = DR[2].ToString();

                    //itemsearchBox1.Text = "";
                }
                sqlconnectionclass getstatus = new sqlconnectionclass();
                dr2 = getstatus.ReadDB("select count(*) from stockin where productno='" + pid + "'");
                if (dr2.HasRows) { dr2.Read(); if (Convert.ToInt32(dr2[0]) > 0) { rdunknown.Checked = false; } else { rdunknown.Checked = true; } }
            }
            //textBoxQuantity.Text;

        }
        private void tableheaders()
        {


        }

        private void sales_Load(object sender, EventArgs e)
        {
            initiategrid();

        }

        private void initiategrid()
        {
            //throw new NotImplementedException();
            table.Columns.Add("ProductNo", typeof(int));
            table.Columns.Add("ProductName", typeof(string));
            table.Columns.Add("UnitPrice", typeof(int));
            table.Columns.Add("Quantity", typeof(int));
            table.Columns.Add("VAT", typeof(double));
            table.Columns.Add("Total", typeof(float));

            dataGridView1.DataSource = table;

            DataGridViewLinkColumn Editlink = new DataGridViewLinkColumn();
            Editlink.UseColumnTextForLinkValue = true;
            Editlink.HeaderText = "Remove";
            Editlink.DataPropertyName = "lnkColumn";
            Editlink.LinkBehavior = LinkBehavior.SystemDefault;
            Editlink.Text = "Remove";
            dataGridView1.Columns.Add(Editlink);

            receiptBindingSource.DataSource = new List<Receipt>();


            textBoxTotalAmount.Text = (from DataGridViewRow row in dataGridView1.Rows
                                       where row.Cells[3].FormattedValue.ToString() != string.Empty
                                       select Convert.ToInt32(row.Cells[3].FormattedValue)).Sum().ToString();
        }

        private void Iexit_Click(object sender, EventArgs e)
        {
            DialogResult Iexit;
            Iexit = MessageBox.Show("Confirm you want to exit", "Sales", MessageBoxButtons.YesNo);
            if (Iexit == DialogResult.Yes)
            {
                Application.Exit();
            }

        }
        private void AddtothecartBtn_Click(object sender, EventArgs e)
        {
            AddCart();
        }
        string productname;
        private void AddCart()
        {
            //throw new NotImplementedException();
            try
            {
                //if ((Convert.ToInt32(textBoxUnitPrice.Text) <= Convert.ToInt32(label12.Text)))
                //{
                if (textBoxProductName.Text != "" && textBoxUnitPrice.Text != "" && textBoxQuantity.Text != "" && txtBoxVat.Text != "" && textBoxTotal.Text != "")
                {
                    if (rdunknown.Checked == true || (Convert.ToInt32(textBoxQuantity.Text) <= Convert.ToInt32(textBox1.Text)))
                    {
                        //Receipt obj = new Receipt() { Id = ReceiptNo++, ProductName = textBoxProductName.Text, unitprice = Convert.ToInt32(textBoxUnitPrice.Text), Quantity = Convert.ToInt32(textBoxQuantity.Text), VAT = Convert.ToDouble(txtBoxVat.Text) };
                        //total += obj.unitprice * obj.Quantity;
                        //receiptBindingSource.Add(obj);
                        //receiptBindingSource.MoveLast();
                        //adds to the text box
                        if (textBoxProductName.TextLength > 18)
                        {
                            productname = textBoxProductName.Text.Substring(0, 18);
                        }
                        else { productname = textBoxProductName.Text; }
                        table.Rows.Add(pid, productname, textBoxUnitPrice.Text, textBoxQuantity.Text, txtBoxVat.Text, textBoxTotal.Text);
                        dataGridView1.DataSource = table;
                        totaladd = Convert.ToInt32(textBoxTotal.Text);
                        totalamount = Convert.ToInt32(textBoxTotalAmount.Text) + totaladd;
                        textBoxTotalAmount.Text = totalamount.ToString();

                        sqlconnectionclass selecttousers = new sqlconnectionclass();
                        DR = selecttousers.ReadDB("select * from Products where ProductName='" + itemsearchBox1.Text + "'");
                    }
                    else
                    {
                        MessageBox.Show("Quantity cannot exceed Stock Quantity");
                    }

                    textBoxTotal.Text = ""; textBoxQuantity.Text = ""; textBoxProductName.Text = ""; txtBoxVat.Text = ""; textBoxUnitPrice.Text = "";
                }
                else
                {
                    MessageBox.Show("Fields can't be empty!");
                }
                // }
                //else
                //{
                //    MessageBox.Show("Item cannot be sold UnderPrice!");
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ProductName_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxQuantity_TextChanged(object sender, EventArgs e)
        {
            if (textBoxQuantity.TextLength > 0)
            {
                try
                {
                    unitprice = Convert.ToInt32(textBoxUnitPrice.Text);
                    qty = Convert.ToInt32(textBoxQuantity.Text);
                    total = unitprice * qty;
                    textBoxTotal.Text = total.ToString();

                    Vatrate = Convert.ToDouble(DR1["Vat_Rate"]);
                    totalvat = (Vatrate / 100 * Convert.ToDouble(textBoxUnitPrice.Text) * qty);
                    txtBoxVat.Text = totalvat.ToString();

                    //quantity = Convert.ToInt32(textBox1.Text);
                    //avail = quantity - qty;
                    //textBox1.Text = avail.ToString();


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Operation not Succesfull");
                }
            }
            else
            {
                // MessageBox.Show("Operation not Succesfull");
            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; ++i)
            {
                sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value);
            }
            try
            {
                decimal tot = 0;
                for (int i = 0; i <= dataGridView1.RowCount - 1; ++i)
                {
                    tot = Convert.ToDecimal(dataGridView1.Rows[i].Cells[3].Value);
                }
                //if(tot==0 )
                //{

                //}
                textBoxTotalAmount.Text = tot.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                textBoxTotalAmount.Text = (Convert.ToInt32(textBoxTotalAmount.Text) - Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString().Trim())).ToString();
                dataGridView1.Rows.Remove(dataGridView1.Rows[e.RowIndex]);
                //receiptBindingSource.RemoveCurrent();
            }
        }

        private void textBoxCash_TextChanged(object sender, EventArgs e)
        {
            if (textBoxCash.TextLength > 0)
            {
                try
                {
                    total = Convert.ToInt32(textBoxTotalAmount.Text);
                    Cash = Convert.ToInt32(textBoxCash.Text);
                    Balance = Cash - total;
                    textBoxBalance.Text = Balance.ToString();
                    try
                    {
                        if (Convert.ToInt32(textBoxCash.Text) < Convert.ToInt32(textBoxTotalAmount.Text))
                        {
                            txtcreditsales.Text = (Convert.ToInt32(textBoxTotalAmount.Text) - Convert.ToInt32(textBoxCash.Text)).ToString();
                        }
                        else { txtcreditsales.Text = "0"; }
                    }
                    catch (Exception)
                    { //
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else { textBoxCash.Text = "0"; }
        }

        private void textBoxUnitPrice_TextChanged(object sender, EventArgs e)
        {

        }
        private void creditbalance()
        {
            sqlconnectionclass selecttousers = new sqlconnectionclass();
            DR = selecttousers.ReadDB("select ((select ISNULL(SUM(amount), 0)as availab from Credit_sales where credit_customerID= '" + cust_id + "')-(select ISNULL(SUM(amount), 0)as qty from creditPayment where credit_customerID= '" + cust_id + "')) As available from Credit_Customers where credit_customerID='" + cust_id + "'");
            if (DR.Read())
            {
                bal = Convert.ToInt32(DR[0]);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            sell();
            MessageBox.Show("Complete! Give the receipt to the customer.");
            this.Close();
        }

        private void sell()
        {
            //throw new NotImplementedException();
            try
            {
                if (textBoxTotalAmount.Text != "" && textBoxBalance.Text != "" && textBoxCash.Text != "" || textBox2.Text != "")
                {
                    getreceiptno();
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells[0].Value != null)
                        {
                            //float available = 0,totalqty;
                            available = Convert.ToInt32(textBox1.Text);
                            //sold = Convert.ToInt32(textBoxQuantity.Text);
                            totalqty = available - qty;
                            getCreditno();
                            sqlconnectionclass getstatus = new sqlconnectionclass();
                            DR = getstatus.ReadDB("select count(*) from stockin where productno='" + row.Cells[0].Value + "'");
                            if (DR.HasRows) { DR.Read(); if (Convert.ToInt32(DR[0]) > 0) { status = 0; } else { status = 1; } }
                            string insertsale = "INSERT INTO [Sales]([ProductNo],[sqty],[sprice],[totalcost],[VAT],[credit_customerID],[credit_no],[unknown],[receiptno],[date])VALUES('" + row.Cells[0].Value + "','" + row.Cells[3].Value + "','" + row.Cells[2].Value + "','" + row.Cells[5].Value + "','" + row.Cells[4].Value + "','" + cust_id + "','" + nextcreditno + "','" + status + "','" + ReceiptNo + "','" + System.DateTime.Now + "')";
                            new sqlconnectionclass().WriteDB(insertsale);
                            string insertstockcard = "INSERT INTO [Stockcard]([ProductNo] ,[Transaction_Date],[Naration] ,[Qty_in] ,[Qty_out],[Lacation],[System_User],[New_Stock],[Available_Stock],[DateReport],[Timereport]) VALUES('" + row.Cells[0].Value + "','" + System.DateTime.Now + "','Sale of ''" + productname + "','" + '0' + "','" + row.Cells[3].Value + "','Store','" + Form1.UserName + "','" + totalqty + "','" + textBox1.Text + "','" + System.DateTime.Now + "','" + System.DateTime.Now + "')";
                            new sqlconnectionclass().WriteDB(insertstockcard);
                            if (radioButton2.Checked == true)
                            {

                                string insertcredit = "INSERT INTO credit_sales([credit_no],[credit_customerID],[amount],[description],[user],[date])values('" + nextcreditno + "','" + cust_id + "','" + txtcreditsales.Text + "','being sales of''" + productname + "','" + Form1.UserName + "','" + System.DateTime.Now.ToShortDateString() + "')";
                                new sqlconnectionclass().WriteDB(insertcredit);
                                creditbalance();
                                totalbal = Convert.ToInt32(txtcreditsales.Text);
                                bal2 = bal + totalbal;
                                string insertgledger = "INSERT INTO [GLedger]([credit_customerID],[Debit],[Balance],[Date],[user],[Naration])values('" + cust_id + "','" + txtcreditsales.Text + "','" + bal2 + "','" + System.DateTime.Now + "','" + Form1.UserName + "','Being sales of''" + productname + "')";
                                new sqlconnectionclass().WriteDB(insertgledger);
                            }
                        }
                    }

                    //if(){}
                    /*****======================Begin Print=====================*****/
                    PrinterUtility.EscPosEpsonCommands.EscPosEpson obj = new PrinterUtility.EscPosEpsonCommands.EscPosEpson();
                    var BytesValue = Encoding.ASCII.GetBytes(string.Empty);
                    //BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Separator());
                    BytesValue = PrintExtensions.AddBytes(BytesValue, obj.CharSize.DoubleWidth2());
                    BytesValue = PrintExtensions.AddBytes(BytesValue, obj.FontSelect.FontA());
                    BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Center());
                    //BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes("\n"));
                    BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes("JOMAT GENERAL HARDWARE\n"));
                    BytesValue = PrintExtensions.AddBytes(BytesValue, obj.CharSize.Nomarl());
                    BytesValue = PrintExtensions.AddBytes(BytesValue, obj.FontSelect.FontA());
                    BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes("Dealers in: Hardware e.g Iron sheets, Cement,\n Plywood, Paints, Glassmart, Supply of general\nbuilding materials etc.\n"));
                    BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes("P.O. BOX 4, NGONG\nNGONG RD-KISERIAN, MATASIA SHOPPING CENTRE\nTEL: 0721-283-402/0724-477-792\nKRA PIN.:A001204489T \n"));
                    BytesValue = PrintExtensions.AddBytes(BytesValue, obj.CharSize.Nomarl());
                    BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Separator());
                    BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes("RECEIPT\n"));
                    BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Left());
                    BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes("Receipt No  : " + ReceiptNo + "\n"));
                    BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes("Date        : " + System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss", CultureInfo.InvariantCulture) + "\n"));
                    //BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes("PIN.        :A001204489T \n"));
                    BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Separator());
                    //BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Right());
                    BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes("  Item                   Qty    U. Price    VAT         Total\n"));
                    //BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Center());
                    BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes("  Name                             KES      KES          KES\n"));
                    BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Separator());
                    foreach (DataGridViewRow dgv in dataGridView1.Rows)
                    {
                        BytesValue = PrintExtensions.AddBytes(BytesValue, string.Format("{0,-19}{1,9}{2,9}{3,10}{4,16:N2}\n", dgv.Cells[1].Value, dgv.Cells[3].Value, dgv.Cells[2].Value, dgv.Cells[4].Value, dgv.Cells[5].Value));
                    }
                    //BytesValue = PrintExtensions.AddBytes(BytesValue, string.Format("{0,-40}{1,6}{2,9}{3,9:N2}\n", "item 1", 12, 11, 144.00));
                    //BytesValue = PrintExtensions.AddBytes(BytesValue, string.Format("{0,-40}{1,6}{2,9}{3,9:N2}\n", "item 2", 12, 11, 144.00));
                    BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Right());
                    BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Separator());
                    BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes("Total: "));
                    BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes(textBoxTotalAmount.Text + "\n"));
                    BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes("Cash: "));
                    BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes(textBoxCash.Text + "\n"));
                    BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes("Change: "));
                    BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes(textBoxBalance.Text + "\n"));
                    BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Separator());
                    BytesValue = PrintExtensions.AddBytes(BytesValue, obj.CharSize.DoubleWidth2());
                    BytesValue = PrintExtensions.AddBytes(BytesValue, obj.FontSelect.FontA());
                    BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Center());
                    BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes("Mpesa Till No 524049\n"));
                    BytesValue = PrintExtensions.AddBytes(BytesValue, obj.CharSize.Nomarl());
                    BytesValue = PrintExtensions.AddBytes(BytesValue, obj.FontSelect.FontA());
                    BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
                    BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Center());
                    //BytesValue = PrintExtensions.AddBytes(BytesValue, obj.BarCode.Code128("12345"));
                    //BytesValue = PrintExtensions.AddBytes(BytesValue, obj.QrCode.Print("12345", PrinterUtility.Enums.QrCodeSize.Grande));
                    BytesValue = PrintExtensions.AddBytes(BytesValue, "Goods Once sold cannot be returned\n");
                    BytesValue = PrintExtensions.AddBytes(BytesValue, "You're served by " + Form1.UserName + "\n");
                    BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Separator());
                    BytesValue = PrintExtensions.AddBytes(BytesValue, "Designed by Amtech Technologies\n");
                    BytesValue = PrintExtensions.AddBytes(BytesValue, "Website: www.amtechafrica.com Email: info@amtechafrica.com\n");
                    BytesValue = PrintExtensions.AddBytes(BytesValue, "------Thank you for shopping with us-------\n");
                    BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Left());
                    BytesValue = PrintExtensions.AddBytes(BytesValue, CutPage());
                    //PrinterUtility.PrintExtensions.Print(BytesValue, EasyPOS.Properties.Settings.Default.printerpath);
                    if (File.Exists(".\\tmpPrint.print"))
                        File.Delete(".\\tmpPrint.print");
                    File.WriteAllBytes(".\\tmpPrint.print", BytesValue);
                    RawPrinterHelper.SendFileToPrinter("Generic / Text Only", ".\\tmpPrint.print");
                    try
                    {
                        File.Delete(".\\tmpPrint.print");
                    }
                    catch
                    {

                    }
                    /******END PRINT & Begin collection**********/
                    PrinterUtility.EscPosEpsonCommands.EscPosEpson obj1 = new PrinterUtility.EscPosEpsonCommands.EscPosEpson();
                    var BytesValue1 = Encoding.ASCII.GetBytes(string.Empty);
                    //BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Separator());
                    BytesValue1 = PrintExtensions.AddBytes(BytesValue1, obj1.CharSize.DoubleWidth2());
                    BytesValue1 = PrintExtensions.AddBytes(BytesValue1, obj1.FontSelect.FontA());
                    BytesValue1 = PrintExtensions.AddBytes(BytesValue1, obj1.Alignment.Center());
                    //BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes("\n"));
                    BytesValue1 = PrintExtensions.AddBytes(BytesValue1, Encoding.ASCII.GetBytes("JOMAT GENERAL HARDWARE\n"));
                    BytesValue1 = PrintExtensions.AddBytes(BytesValue1, obj1.CharSize.Nomarl());
                    BytesValue1 = PrintExtensions.AddBytes(BytesValue1, Encoding.ASCII.GetBytes("Collection RECEIPT\n"));
                    BytesValue1 = PrintExtensions.AddBytes(BytesValue1, obj1.CharSize.Nomarl());
                    BytesValue1 = PrintExtensions.AddBytes(BytesValue1, obj1.Alignment.Right());
                    BytesValue1 = PrintExtensions.AddBytes(BytesValue1, Encoding.ASCII.GetBytes("Receipt No : " + ReceiptNo + "\n"));
                    BytesValue1 = PrintExtensions.AddBytes(BytesValue1, Encoding.ASCII.GetBytes("Date: " + System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss", CultureInfo.InvariantCulture) + "\n"));
                    BytesValue1 = PrintExtensions.AddBytes(BytesValue1, obj1.Separator());
                    BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Left());
                    BytesValue1 = PrintExtensions.AddBytes(BytesValue1, Encoding.ASCII.GetBytes("  Item                   Qty    U. Price    VAT         Total\n"));
                    //BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Center());
                    BytesValue = PrintExtensions.AddBytes(BytesValue1, Encoding.ASCII.GetBytes("  Name                             KES      KES          KES\n"));
                    BytesValue1 = PrintExtensions.AddBytes(BytesValue1, obj1.Separator());
                    foreach (DataGridViewRow dgv in dataGridView1.Rows)
                    {
                        BytesValue1 = PrintExtensions.AddBytes(BytesValue1, string.Format("{0,-19}{1,9}{2,9}{3,10}{4,16:N2}\n", dgv.Cells[1].Value, dgv.Cells[3].Value, dgv.Cells[2].Value, dgv.Cells[4].Value, dgv.Cells[5].Value));
                    }
                    BytesValue1 = PrintExtensions.AddBytes(BytesValue1, obj1.Alignment.Right());
                    BytesValue1 = PrintExtensions.AddBytes(BytesValue1, obj1.Separator());
                    //BytesValue1 = PrintExtensions.AddBytes(BytesValue1, Encoding.ASCII.GetBytes("Total: "));
                    //BytesValue1 = PrintExtensions.AddBytes(BytesValue1, Encoding.ASCII.GetBytes(textBoxTotalAmount.Text + "\n"));
                    BytesValue1 = PrintExtensions.AddBytes(BytesValue1, obj.Lf());
                    BytesValue1 = PrintExtensions.AddBytes(BytesValue1, "Signed:.............................................\n");
                    BytesValue1 = PrintExtensions.AddBytes(BytesValue1, obj1.Alignment.Center());
                    BytesValue1 = PrintExtensions.AddBytes(BytesValue1, "You're served by " + Form1.UserName + "\n");
                    BytesValue1 = PrintExtensions.AddBytes(BytesValue1, obj.Separator());
                    BytesValue1 = PrintExtensions.AddBytes(BytesValue1, "Designed by Amtech Technologies\n");
                    BytesValue1 = PrintExtensions.AddBytes(BytesValue1, "Website: www.amtechafrica.com Email: info@amtechafrica.com\n");
                    BytesValue1 = PrintExtensions.AddBytes(BytesValue1, obj1.Alignment.Left());
                    BytesValue1 = PrintExtensions.AddBytes(BytesValue1, CutPage());
                    if (File.Exists(".\\tmpPrint1.print"))
                        File.Delete(".\\tmpPrint1.print");
                    File.WriteAllBytes(".\\tmpPrint1.print", BytesValue1);
                    RawPrinterHelper.SendFileToPrinter("Generic / Text Only", ".\\tmpPrint1.print");
                    try
                    {
                        File.Delete(".\\tmpPrint1.print");
                    }
                    catch
                    {

                    }
                    /*********END collector copy****************/
                    textBoxTotalAmount.Text = "0"; textBoxCash.Text = "0"; textBoxBalance.Text = "0";
                }
                else
                {
                    MessageBox.Show("Enter Cash Amount");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void getreceiptno()
        {
            //throw new NotImplementedException();
            sqlconnectionclass getrecip = new sqlconnectionclass();
            DR = getrecip.ReadDB("select top 1 receiptno from sales order by sales_id desc");
            if (DR.HasRows)
            {
                DR.Read();
                ReceiptNo = (Convert.ToInt32(DR[0]) + 1).ToString("00000000");
            }
            else
            {
                ReceiptNo = "00000001";
            }
        }

        public byte[] CutPage()
        {
            List<byte> oby = new List<byte>();
            oby.Add(Convert.ToByte(Convert.ToChar(0x1D)));
            oby.Add(Convert.ToByte('V'));
            oby.Add((byte)66);
            oby.Add((byte)3);
            return oby.ToArray();
        }
        public byte[] GetLogo(string LogoPath)
        {
            List<byte> byteList = new List<byte>();
            if (!File.Exists(LogoPath))
                return null;
            BitmapData data = GetBitmapData(LogoPath);
            BitArray dots = data.Dots;
            byte[] width = BitConverter.GetBytes(data.Width);

            int offset = 0;
            MemoryStream stream = new MemoryStream();
            // BinaryWriter bw = new BinaryWriter(stream);
            byteList.Add(Convert.ToByte(Convert.ToChar(0x1B)));
            //bw.Write((char));
            byteList.Add(Convert.ToByte('@'));
            //bw.Write('@');
            byteList.Add(Convert.ToByte(Convert.ToChar(0x1B)));
            // bw.Write((char)0x1B);
            byteList.Add(Convert.ToByte('3'));
            //bw.Write('3');
            //bw.Write((byte)24);
            byteList.Add((byte)24);
            while (offset < data.Height)
            {
                byteList.Add(Convert.ToByte(Convert.ToChar(0x1B)));
                byteList.Add(Convert.ToByte('*'));
                //bw.Write((char)0x1B);
                //bw.Write('*');         // bit-image mode
                byteList.Add((byte)33);
                //bw.Write((byte)33);    // 24-dot double-density
                byteList.Add(width[0]);
                byteList.Add(width[1]);
                //bw.Write(width[0]);  // width low byte
                //bw.Write(width[1]);  // width high byte

                for (int x = 0; x < data.Width; ++x)
                {
                    for (int k = 0; k < 3; ++k)
                    {
                        byte slice = 0;
                        for (int b = 0; b < 8; ++b)
                        {
                            int y = (((offset / 8) + k) * 8) + b;
                            // Calculate the location of the pixel we want in the bit array.
                            // It'll be at (y * width) + x.
                            int i = (y * data.Width) + x;

                            // If the image is shorter than 24 dots, pad with zero.
                            bool v = false;
                            if (i < dots.Length)
                            {
                                v = dots[i];
                            }
                            slice |= (byte)((v ? 1 : 0) << (7 - b));
                        }
                        byteList.Add(slice);
                        //bw.Write(slice);
                    }
                }
                offset += 24;
                byteList.Add(Convert.ToByte(0x0A));
                //bw.Write((char));
            }
            // Restore the line spacing to the default of 30 dots.
            byteList.Add(Convert.ToByte(0x1B));
            byteList.Add(Convert.ToByte('3'));
            //bw.Write('3');
            byteList.Add((byte)30);
            return byteList.ToArray();
            //bw.Flush();
            //byte[] bytes = stream.ToArray();
            //return logo + Encoding.Default.GetString(bytes);
        }

        public BitmapData GetBitmapData(string bmpFileName)
        {
            using (var bitmap = (Bitmap)Bitmap.FromFile(bmpFileName))
            {
                var threshold = 127;
                var index = 0;
                double multiplier = 570; // this depends on your printer model. for Beiyang you should use 1000
                double scale = (double)(multiplier / (double)bitmap.Width);
                int xheight = (int)(bitmap.Height * scale);
                int xwidth = (int)(bitmap.Width * scale);
                var dimensions = xwidth * xheight;
                var dots = new BitArray(dimensions);

                for (var y = 0; y < xheight; y++)
                {
                    for (var x = 0; x < xwidth; x++)
                    {
                        var _x = (int)(x / scale);
                        var _y = (int)(y / scale);
                        var color = bitmap.GetPixel(_x, _y);
                        var luminance = (int)(color.R * 0.3 + color.G * 0.59 + color.B * 0.11);
                        dots[index] = (luminance < threshold);
                        index++;
                    }
                }

                return new BitmapData()
                {
                    Dots = dots,
                    Height = (int)(bitmap.Height * scale),
                    Width = (int)(bitmap.Width * scale)
                };
            }
        }

        public class BitmapData
        {
            public BitArray Dots
            {
                get;
                set;
            }

            public int Height
            {
                get;
                set;
            }

            public int Width
            {
                get;
                set;
            }
        }

        private void getCreditno()
        {
            //throw new NotImplementedException();
            if (radioButton2.Checked == true)
            {
                sqlconnectionclass selecttousers = new sqlconnectionclass();
                DR = selecttousers.ReadDB("select top 1 credit_no from credit_sales ORDER BY credit_no DESC");
                if (DR.HasRows)
                {
                    DR.Read();
                    nextcreditno = Convert.ToInt32(DR[0]) + 1;
                }
                else
                {
                    nextcreditno = 1;
                }
                cust_id = label3.Text;
            }
            else { nextcreditno = 0; cust_id = "0"; }
        }

        private void buttonCredit_Click(object sender, EventArgs e)
        {
            AddEditMembers aem = new AddEditMembers();
            aem.Show();
        }

        private void comboBoxCustomer_DropDown(object sender, EventArgs e)
        {
            fill_combo1();
        }
        void fill_combo1()
        {
            try
            {
                comboBoxCustomer.Items.Clear();
                sqlconnectionclass selecttousers = new sqlconnectionclass();
                DR = selecttousers.ReadDB("select * from Credit_Customers ");
                while (DR.Read())
                {
                    string BussinessName = DR.GetString(1);
                    string id = DR[0].ToString();
                    comboBoxCustomer.Items.Add(id.ToString() + ": " + BussinessName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void comboBoxCustomer_SelectedValueChanged(object sender, EventArgs e)
        {
            label3.Text = comboBoxCustomer.Text.Split(':')[0];
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            radioButton3.Visible = true;
            if (radioButton2.Checked == true) { comboBoxCustomer.Visible = true; buttonCredit.Visible = true; label8.Visible = true; txtcreditsales.Visible = true; } else { comboBoxCustomer.Visible = false; buttonCredit.Visible = false; label8.Visible = false; txtcreditsales.Visible = false; }
        }

        private void textBoxQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddCart();
            }
        }

        private void textBoxCash_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (radioButton1.Checked == true)
                {
                    if (txtmpesa.TextLength == 10 && txtmpesano.TextLength == 10 && textBox2.Text != "")
                    {
                        sell();
                        string insertmpesa = "INSERT INTO MpesaTransactions(receiptno,MpesaNo,MpesaCode,Amount)values('" + ReceiptNo + "','" + txtmpesano.Text + "','" + txtmpesa.Text + "','" + textBox2.Text + "')";
                        new sqlconnectionclass().WriteDB(insertmpesa);
                    }
                    else
                    {
                        MessageBox.Show("Fill all M-Pesa details Correctly!");
                    }
                }
                else if (radioButton1.Checked == false)
                {
                    sell();
                }
                MessageBox.Show("Complete! Give the receipt to the customer.");
                this.Close();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            radioButton3.Visible = true;
            if (radioButton1.Checked == true) { label4.Visible = true; label10.Visible = true; textBox2.Visible = true; txtmpesa.Visible = true; label9.Visible = true; txtmpesano.Visible = true; } else { txtmpesa.Visible = false; label9.Visible = false; txtmpesano.Visible = false; label4.Visible = false; label10.Visible = false; textBox2.Visible = false; }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.Checked = false; radioButton2.Checked = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (radioButton1.Checked == true)
                {
                    if (txtmpesa.TextLength == 10 && txtmpesano.TextLength == 10 && textBox2.Text != "")
                    {
                        sell();
                        string insertmpesa = "INSERT INTO MpesaTransactions(receiptno,MpesaNo,MpesaCode,Amount)values('" + ReceiptNo + "','" + txtmpesano.Text + "','" + txtmpesa.Text + "','" + textBox2.Text + "')";
                        new sqlconnectionclass().WriteDB(insertmpesa);
                    }
                    else
                    {
                        MessageBox.Show("Fill all M-Pesa details Correctly!");
                    }
                }
                else if (radioButton1.Checked == false)
                {
                    sell();
                }
                MessageBox.Show("Complete! Give the receipt to the customer.");
                this.Close();
            }
        }

        private void buttonVAT_Click(object sender, EventArgs e)
        {
            AddEditProduct aed = new AddEditProduct();
            aed.ShowDialog();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnsell_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                if (txtmpesa.TextLength == 10 && txtmpesano.TextLength == 10 && textBox2.Text != "")
                {
                    sell();
                    string insertmpesa = "INSERT INTO MpesaTransactions(receiptno,MpesaNo,MpesaCode,Amount)values('" + ReceiptNo + "','" + txtmpesano.Text + "','" + txtmpesa.Text + "','" + textBox2.Text + "')";
                    new sqlconnectionclass().WriteDB(insertmpesa);
                }
                else
                {
                    MessageBox.Show("Fill all M-Pesa details Correctly!");
                }
            }
            else if (radioButton1.Checked == false)
            {
                sell();
            }
            MessageBox.Show("Complete! Give the receipt to the customer.");
            this.Close();
        }

        private void itemsearchBox1_DropDown(object sender, EventArgs e)
        {
            fill_combo();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                sqlconnectionclass selectpid = new sqlconnectionclass();
                DR1 = selectpid.ReadDB("select * from P_Category where cat_id = '30'");
                if (DR1.HasRows)
                {
                    // DR1.Read();
                    //pid = DR1["ProductNo"].ToString();
                    //sqlconnectionclass selecttousers = new sqlconnectionclass();
                    //DR = selecttousers.ReadDB("select ProductName,(select top 1 unitprice from stockin where productno = '" + pid + "' ORDER BY rep_no DESC ) as currentprice,((select isnull(sum(qty),0)as availab from stockin where ProductNo= '" + pid + "')-(select isnull(sum(sqty),0)as qty from sales where ProductNo= '" + pid + "')) As available from products where ProductNo='" + pid + "'");
                    //while (DR.Read())
                    //{
                    //string Name = (string)DR["name"].ToString(); ;
                    //button7.Text = Name;
                    //string RetailPrice = (string)DR["currentprice"].ToString();
                    //label11.Visible = true;
                    //label12.Visible = true;
                    //label12.Text = "KES " + RetailPrice;
                    button7.Text = DR["1"].ToString();
                    //itemsearchBox1.Text = "";
                    //}
                    //sqlconnectionclass getstatus = new sqlconnectionclass();
                    //dr2 = getstatus.ReadDB("select count(*) from stockin where productno='" + pid + "'");
                    //if (dr2.HasRows) { dr2.Read(); if (Convert.ToInt32(dr2[0]) > 0) { rdunknown.Checked = false; } else { rdunknown.Checked = true; } }
                }
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            {
            }
        }

        private void textBoxTotalAmount_TextChanged(object sender, EventArgs e)
        {

        }
    }
}


