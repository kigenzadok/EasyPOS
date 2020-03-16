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
    public partial class AddEditSuppliers : Form
    {
        public AddEditSuppliers()
        {
            InitializeComponent();
            bindgrid();
        }

        private void bindgrid()
        {
            //throw new NotImplementedException();
            using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connectme"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM suppliers", con))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            dataGridView1.DataSource = dt;
                            dataGridView1.AutoGenerateColumns = false;
                            dataGridView1.Refresh();
                        }
                    }
                }
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            string inserttousers = ("INSERT INTO Suppliers(sname,details,created_at)values('" + txtscontactperson.Text + "','" + txtscontact.Text + "','" + System.DateTime.Now.ToString() + "')");
            new sqlconnectionclass().WriteDB(inserttousers);
            bindgrid();
            MessageBox.Show("Supplier added successfully!");
            txtscontact.Text = ""; txtscontactperson.Text = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtsname_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
