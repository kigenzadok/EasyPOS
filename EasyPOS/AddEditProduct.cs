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
    public partial class AddEditProduct : Form
    {
        System.Data.SqlClient.SqlDataReader DR, DR1;
        public AddEditProduct()
        {
            InitializeComponent();
            fill_combo();
            
            fill_combo2();
            fill_combo3();
        }
        Button btn = new Button();

        void fill_combo1()
        {
            cmbBoxVATCodes.Items.Clear();
            sqlconnectionclass selectusers = new sqlconnectionclass();
            DR1 = selectusers.ReadDB("select * from VAT");
            if (DR1.HasRows)
            {
                while (DR1.Read())
                {
                    cmbBoxVATCodes.Items.Add(DR1[0]);
                }
            }
        }

        void fill_combo2()
        {
            cmbBoxParkageMode.Items.Clear();
            sqlconnectionclass selectusers = new sqlconnectionclass();
            DR1 = selectusers.ReadDB("select * from Packaging");

            if (DR1.HasRows)
            {
                while (DR1.Read())
                {

                    cmbBoxParkageMode.Items.Add(DR1[0]);

                }
            }
        }
        //this is for searchbox(combobox)

        void fill_combo3()
        {
            txtSearch.Items.Clear();
            sqlconnectionclass selectusers = new sqlconnectionclass();
            DR1 = selectusers.ReadDB("select * from Products ");

            if (DR1.HasRows)
            {
                while (DR1.Read())
                {
                    txtSearch.Items.Add(DR1[0]+":"+DR1[1]+"-"+DR1[10]);
                }
            }
        }

        //combobox for Categories
        void fill_combo()
        {
            txtCategory.Items.Clear();
            sqlconnectionclass selecttousers = new sqlconnectionclass();
            DR = selecttousers.ReadDB("select * from P_Category ");
            // DR1 = selecttousers.ReadDB("select * from Suppliers ");


            while (DR.Read())
            {
                string Name = DR.GetString(1);
                txtCategory.Items.Add(Name);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            sqlconnectionclass selecttousers = new sqlconnectionclass();
            DR = selecttousers.ReadDB("select * from Products where ProductNo='" + txtSearch.Text.Split(':')[0]+ "'");

            //DataTable dt = new DataTable();
            while (DR.Read())
            {
                string ProductName = (string)DR["ProductName"].ToString(); ;
                txtDescription.Text = ProductName;

                string ProductNo = (string)DR["ProductNo"].ToString(); ;
                textBoxProductNo.Text = ProductNo;

                string BarCode = (string)DR["BarCode"].ToString();
                txtBarcode.Text = BarCode;

                string Reorderlevel = (string)DR["Reorderlevel"].ToString(); ;
                txtReorderLevel.Text = Reorderlevel;

                string Category = (string)DR["Category"].ToString(); ;
                txtCategory.Text = Category;

                string PackageMode = (string)DR["PackageMode"].ToString();
                cmbBoxParkageMode.Text = PackageMode;

                string PartNo = (string)DR["PartNo"].ToString();
                textBoxPartNo.Text = PartNo;

                string Shelf = (string)DR["Shelf"].ToString();
                textBoxShelf.Text = Shelf;

                

                string Vat_Code = (string)DR["Vat_Code"].ToString();
                cmbBoxVATCodes.Text = Vat_Code;

                string Vat_Rate = (string)DR["Vat_Rate"].ToString();
                textBoxRates.Text = Vat_Rate;
                if (DR[10].ToString() == "OI") { rdoitem.Checked = true; textBox4.Text = DR["baseqty"].ToString(); } else if (DR[10].ToString() == "SI") { rdsitem.Checked = true; }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbBoxParkageMode.Text != "" && txtDescription.Text != "" && textBoxPartNo.Text != "" && textBoxShelf.Text != "" &&  cmbBoxVATCodes.Text != "" && textBoxRates.Text != "" && txtReorderLevel.Text != "")
            {
                string itemtype = "";
                float baseqty = 0;
                if (textBox4.TextLength > 0) { baseqty = Convert.ToInt32(textBox4.Text); } else { baseqty = 0; }
                if (rdsitem.Checked == true)
                {
                    itemtype = "SI";
                }
                else if(rdoitem.Checked==true) {
                    itemtype = "OI";
                }
                string inserttousers = ("INSERT INTO Products(ProductName,BarCode,Reorderlevel,Category,PackageMode,PartNo,Shelf,Vat_Code,Vat_Rate,itemtype,baseqty,date,auditid)VALUES( '" + txtDescription.Text + "','" + txtBarcode.Text + "','" + txtReorderLevel.Text + "','" + txtCategory.Text + "','" + cmbBoxParkageMode.Text + "','" + textBoxPartNo.Text + "','" + textBoxShelf.Text + "','" + cmbBoxVATCodes.Text + "','" + textBoxRates.Text + "','" + itemtype + "','"+baseqty+"','" + System.DateTime.Now.ToShortDateString() + "','" + Form1.UserName + "')");
                new sqlconnectionclass().WriteDB(inserttousers);
                MessageBox.Show("Products added Successfully!");
                txtCategory.Text = "BRUSH"; textBox4.Text = ""; txtReorderLevel.Text = "0"; cmbBoxParkageMode.Text = "PCS"; textBoxPartNo.Text = "0"; textBoxShelf.Text = "0"; cmbBoxVATCodes.Text = "A"; textBoxRates.Text = "16"; textBoxProductNo.Text = ""; txtDescription.Text = ""; txtBarcode.Text = ""; rdsitem.Checked = true;
            }
            else
            {
                MessageBox.Show("Fill the Empty Fields");
            }
        }

        public object ReOrderlevel { get; set; }
        public string insertProducts { get; set; }

        private void txtCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void AddEditProduct_Load(object sender, EventArgs e)
        {
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            AddEditPCategory aepc = new AddEditPCategory();
            aepc.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddEditSuppliers aes = new AddEditSuppliers();
            aes.ShowDialog();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            //TO DO UPDATE
            string itemtype = "";
            if (rdsitem.Checked == true)
            {
                itemtype = "SI";
            }
            else if (rdoitem.Checked == true)
            {
                itemtype = "OI";
            }
            float baseqty = 0;
            if (textBox4.TextLength > 0) { baseqty = Convert.ToInt32(textBox4.Text); } else { baseqty = 0; }
            string UpdateStock = ("UPDATE Products SET ProductName='" + txtDescription.Text + "',BarCode='" + txtBarcode.Text + "',Reorderlevel='" + txtReorderLevel.Text + "',Category='" + txtCategory.Text + "',PackageMode='" + cmbBoxParkageMode.Text + "',PartNo='" + textBoxPartNo.Text + "',Shelf='" + textBoxShelf.Text + "',Vat_Code='" + cmbBoxVATCodes.Text + "',Vat_Rate='" + textBoxRates.Text + "',itemtype='" + itemtype + "',baseqty='"+baseqty+"',date='" + System.DateTime.Now.ToShortDateString() + "',auditid='" +Form1.UserName+ "' where ProductNo='" + textBoxProductNo.Text + "'");
            new sqlconnectionclass().WriteDB(UpdateStock);
            MessageBox.Show("Product Updated successfully!");
            txtCategory.Text = ""; textBox4.Text = ""; txtReorderLevel.Text = "0"; cmbBoxParkageMode.Text = ""; textBoxPartNo.Text = "0"; textBoxShelf.Text = "0";  cmbBoxVATCodes.Text = ""; textBoxRates.Text = ""; textBoxProductNo.Text = ""; txtDescription.Text = ""; txtBarcode.Text = ""; rdsitem.Checked = true;
        }



        private void cmbBoxVATCodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            sqlconnectionclass selectusers = new sqlconnectionclass();
            DR1 = selectusers.ReadDB("select * from VAT where VAT_Codes='" + cmbBoxVATCodes.Text + "'");

            //DataTable dt = new DataTable();
            while (DR1.Read())
            {
                string VAT_Percentage = (string)DR1["VAT_Percentage"].ToString();
                textBoxRates.Text = VAT_Percentage;
            }
        }

        private void buttonVAT_Click(object sender, EventArgs e)
        {
            VatCodes VD = new VatCodes();
            VD.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            PackageMode PM = new PackageMode();
            PM.ShowDialog();

        }

        private void txtSeach_TextChanged(object sender, EventArgs e)
        {

        }

        private void textRetailPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            cmbBoxParkageMode.Text = ""; textBoxPartNo.Text = ""; textBoxShelf.Text = "";  cmbBoxVATCodes.Text = "'"; textBoxRates.Text = "";
             textBoxProductNo.Text = ""; txtDescription.Text = ""; txtBarcode.Text = "";
            txtCategory.Text = "";  txtReorderLevel.Text = "";

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Are you sure you want to delete "+ txtDescription.Text, "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                string del = "delete from products where ProductNo='" + textBoxProductNo.Text + "'";
                new sqlconnectionclass().WriteDB(del);
                MessageBox.Show("Item " + txtDescription.Text + " deleted successfully");
                txtCategory.Text = "";  txtReorderLevel.Text = "0"; cmbBoxParkageMode.Text = ""; textBoxPartNo.Text = "0"; textBoxShelf.Text = "0";  cmbBoxVATCodes.Text = ""; textBoxRates.Text = ""; textBoxProductNo.Text = ""; txtDescription.Text = ""; txtBarcode.Text = ""; rdsitem.Checked = true;
            }
            else if (d == DialogResult.No) { 
            //
            }
        }

        private void cmbBoxVATCodes_DropDown(object sender, EventArgs e)
        {
            fill_combo1();
        }

        private void txtCategory_DropDown(object sender, EventArgs e)
        {
            fill_combo();
        }

        private void cmbBoxParkageMode_DropDown(object sender, EventArgs e)
        {
            fill_combo2();
        }

        private void txtSearch_DropDown(object sender, EventArgs e)
        {
            fill_combo3();
        }

        private void GroupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void rdoitem_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoitem.Checked) { label8.Visible = true; textBox4.Visible = true; } else { label8.Visible =false; textBox4.Visible = false; }
        }

        private void rdsitem_CheckedChanged(object sender, EventArgs e)
        {

        }

    }
}
