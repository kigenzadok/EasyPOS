using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EasyPOS
{
    public partial class AddEditMembers : Form
    {
        public AddEditMembers()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            {
                if (txtBusinessname.Text != "" && txtPhysicalAddress.Text != "" && textBoxPostralad.Text != "" && textBoxTel.Text != ""  && txtCtcPerson.Text != "" && textContactN.Text != "" && textBoxPostralad.Text != "")
                {
                    string insertmembers = ("INSERT INTO Credit_Customers([BussinessName],[Physical_address],[PostralAdress],[Telephone],[Email],[Contact Person],[ContactPersonNo],[OpenningBalance],[Pin_No],[VAT_No],[Card_No])VALUES( '" + txtBusinessname.Text + "','" + txtPhysicalAddress.Text + "','" + textBoxPostralad.Text + "','" + textBoxTel.Text + "','" + textBoxEmail.Text + "','" + txtCtcPerson.Text + "','" + textContactN.Text + "','" + textBoxOpenningBal.Text + "','" + textBoxPin.Text + "','" + textBoxVat.Text + "','" + textBoxCard.Text + "')");
                    new sqlconnectionclass().WriteDB(insertmembers);
                    MessageBox.Show("Memberss added Successfully!");
                     textBoxPostralad.Text = ""; textBoxTel.Text = ""; txtBusinessname.Text = "";
                    txtCtcPerson.Text = ""; textContactN.Text = "";
                    txtPhysicalAddress.Text = "";
                    txtBusinessname.Text = ""; 
                }
                else
                {
                    MessageBox.Show("Fill the Empty Fields");
                }
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
                //if (txtBusinessname.Text != "" && txtPhysicalAddress.Text != "" && textBoxPostralad.Text != "" && textBoxTel.Text != "" && txtCtcPerson.Text != "" && textContactN.Text != "" && textBoxPostralad.Text != "")
                //{
                ////TO DO UPDATE
                //string UpdateStock = ("UPDATE Credit_Customers SET BussinessName='" + txtBusinessname.Text + "',Physical_address='" + txtPhysicalAddress.Text + "',PostralAdress='" + textBoxPostralad.Text + "',Telephone='" + textBoxTel.Text + "',Email='" + textBoxEmail.Text + "',Contact Person='" + txtCtcPerson.Text + "',ContactPersonNo='" + textContactN.Text + "',OpenningBalance='" + textBoxOpenningBal.Text + "',Pin_No='" + textBoxPin.Text + "',VAT_No='" + textBoxVat.Text + "',Card_No='" + textBoxCard.Text + "')");
                //new sqlconnectionclass().WriteDB(UpdateStock);
                //MessageBox.Show("Product Updated successfully!");
                //EditButton.Text = "Save"; txtBusinessname.Text = ""; txtPhysicalAddress.Text = ""; textBoxPostralad.Text = ""; textBoxTel.Text = ""; txtCtcPerson.Text = ""; textContactN.Text = ""; textBoxEmail.Text = "";textBoxOpenningBal.Text = ""; textBoxPin.Text = ""; textBoxVat.Text = "";
                //}
                //else
                //{
                //    MessageBox.Show("Choose the Member To Edit");
                //}
           
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            txtBusinessname.Text = ""; txtPhysicalAddress.Text = ""; textBoxPostralad.Text = ""; textBoxTel.Text = ""; txtCtcPerson.Text = ""; textContactN.Text = ""; textBoxEmail.Text = ""; textBoxOpenningBal.Text = ""; textBoxPin.Text = ""; textBoxVat.Text = "";
                                                                        
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddEditMembers_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'easyposDataSet.Credit_Customers' table. You can move, or remove it, as needed.
            this.credit_CustomersTableAdapter.Fill(this.easyposDataSet.Credit_Customers);
            // TODO: This line of code loads data into the 'easyposDataSet9.Credit_Customers' table. You can move, or remove it, as needed.
           // this.credit_CustomersTableAdapter.Fill(this.easyposDataSet9.Credit_Customers);

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {

        }

        }

        
       
    }