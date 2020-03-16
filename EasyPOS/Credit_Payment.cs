using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PrinterUtility;
using System.IO;
using System.Globalization;

namespace EasyPOS
{
    public partial class Credit_Payment : Form
    {
        System.Data.SqlClient.SqlDataReader DR, DR1;
        private string pid;
        float balance, amount1, balance1;
        public Credit_Payment()
        {
            InitializeComponent();
        }
        void fill_combo()
        {
            try
            {

                sqlconnectionclass selecttousers = new sqlconnectionclass();
                DR = selecttousers.ReadDB("select * from Credit_Customers ");
                if (DR.HasRows)
                {
                    while (DR.Read())
                    {
                        string BusinessName = DR.GetString(1);
                        cmbBusinessname.Items.Add(BusinessName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void cmbBusinessname_DropDown(object sender, EventArgs e)
        {
        fill_combo();
        }

        private void Credit_Payment_Load(object sender, EventArgs e)
        {
            //
        }



        private void balancetxt_TextChanged(object sender, EventArgs e)
        {
        }

        private void cmbBusinessname_SelectedIndexChanged(object sender, EventArgs e)
        {
             sqlconnectionclass selectpid = new sqlconnectionclass();
             DR1 = selectpid.ReadDB("select  BussinessName,credit_customerID from Credit_Customers where BussinessName= '" + cmbBusinessname.Text + "'");
            if (DR1.HasRows)
            {
                DR1.Read();
                pid = DR1["credit_customerID"].ToString();
                sqlconnectionclass selecttousers = new sqlconnectionclass();
                DR = selecttousers.ReadDB("select ((select ISNULL(SUM(amount), 0)as availab from Credit_sales where credit_customerID= '" + pid + "')-(select ISNULL(SUM(amount), 0)as qty from creditPayment where credit_customerID= '" + pid + "')) As available from Credit_Customers where credit_customerID='" + pid + "'");
                //DR = selecttousers.ReadDB("(select ISNULL(SUM(amount), 0) from credit_sales)-(select ISNULL(SUM(amount), 0) from creditPayment)");
                if (DR.Read())
                {
                    
                    balancetxt.Text = DR[0].ToString();
                } 
            }
           
        }
        private void buttonPay_Click(object sender, EventArgs e)
        {
            string paymode = "";
                
                if (radioButton1.Checked == true)
                {
                    paymode = "Cash";
                }
                else if (radioButton2.Checked == true)
                {
                    paymode = "Cheque";
                }
                string pay = "INSERT INTO [creditPayment]([credit_customerID],[BussinessName],[paymentmode],[amount],[balance],[description],[chequeno],[datepay],[duedate],[date],[user])VALUES('" + pid + "','" + cmbBusinessname.Text + "','" + paymode + "','" + textBoxAmount.Text + "','" + txtRemaining.Text + "','Payment of Credit','" + textBoxChequeNo.Text + "','" + datePay.Text + "','" + Duedate.Text + "','" + System.DateTime.Now + "','" + Form1.UserName + "')";
            new sqlconnectionclass().WriteDB(pay);
            string gledger = "INSERT INTO [GLedger]([credit_customerID],[Credit],[Balance],[Date],[user],[Naration])VALUES('" + pid + "','" + textBoxAmount.Text + "','" + txtRemaining.Text + "','" + System.DateTime.Now + "','" + Form1.UserName + "','Credit Payment')";
            new sqlconnectionclass().WriteDB(gledger);
            MessageBox.Show("success");
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
            BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes("CREDIT PAYMENT RECEIPT\n"));
           // BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Left());
           // BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes("Receipt No  : " + ReceiptNo + "\n"));
            BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes("Date        : " + System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss", CultureInfo.InvariantCulture) + "\n"));
            //BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes("PIN.        :A001204489T \n"));
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Separator());
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Right());
            BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes("  MEMBER NAME        TOTAL Balance    CASH Paid       REMAINING\n"));
            ////BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Center());
            BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes("  Name                       KES      KES          KES\n"));
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Separator());
            //foreach (DataGridViewRow dgv in dataGridView1.Rows)
            //{
                BytesValue = PrintExtensions.AddBytes(BytesValue, string.Format("{0,19}{1,9}{2,10}{3,16:N2}\n", cmbBusinessname.Text,  balancetxt.Text,textBoxAmount.Text, txtRemaining.Text));
            //}
            //BytesValue = PrintExtensions.AddBytes(BytesValue, string.Format("{0,-40}{1,6}{2,9}{3,9:N2}\n", "item 1", 12, 11, 144.00));
            //BytesValue = PrintExtensions.AddBytes(BytesValue, string.Format("{0,-40}{1,6}{2,9}{3,9:N2}\n", "item 2", 12, 11, 144.00));
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Right());
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Separator());
            BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes("Total Balance: "));
            BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes(balancetxt.Text + "\n"));
            BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes("Cash: "));
            BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes(textBoxAmount.Text + "\n"));
            BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes("Remaining: "));
            BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes(txtRemaining.Text + "\n"));
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
           // BytesValue = PrintExtensions.AddBytes(BytesValue, "Goods Once sold cannot be returned\n");
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
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //this.CancelButton();
        }


        

        private void txtRemaining_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                balance = Convert.ToInt32(balancetxt.Text);
                amount1 = Convert.ToInt32(textBoxAmount.Text);
                balance1 = balance - amount1;
                txtRemaining.Text = balance1.ToString();             
            }
            catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
        }

        private void radioButton1_Click_1(object sender, EventArgs e)
        {
            textBoxChequeNo.Visible = false; datePay.Visible = false; Duedate.Visible = false; label7.Visible = false; label8.Visible = false; label9.Visible = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBoxChequeNo.Visible = true; datePay.Visible = true; Duedate.Visible = true; label7.Visible = true; label8.Visible = true; label9.Visible = true;
        }
        }
    }

