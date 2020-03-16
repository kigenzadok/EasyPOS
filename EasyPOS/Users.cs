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
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
        }

        private void Bindgridview()
        {
            //throw new NotImplementedException();
            using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connectme"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT user_id as Sno,username as Username,password,userlevel,status,created_at FROM users", con))
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
            dataGridView1.Columns[2].Visible = false;
        }

        private void Users_Load(object sender, EventArgs e)
        {
            Bindgridview();

            //Edit link

            DataGridViewLinkColumn Editlink = new DataGridViewLinkColumn();
            Editlink.UseColumnTextForLinkValue = true;
            Editlink.HeaderText = "Edit";
            Editlink.DataPropertyName = "lnkColumn";
            Editlink.LinkBehavior = LinkBehavior.SystemDefault;
            Editlink.Text = "Edit";
            dataGridView1.Columns.Add(Editlink);

            //Delete link

            DataGridViewLinkColumn Deletelink = new DataGridViewLinkColumn();
            Deletelink.UseColumnTextForLinkValue = true;
            Deletelink.HeaderText = "delete";
            Deletelink.DataPropertyName = "lnkColumn";
            Deletelink.LinkBehavior = LinkBehavior.SystemDefault;
            Deletelink.Text = "Delete";
            dataGridView1.Columns.Add(Deletelink);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex ==7) {
                DialogResult d = MessageBox.Show("Are you sure you want to delete this User?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (d == DialogResult.Yes)
                {
                    using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connectme"].ConnectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("delete from users where user_id = '" + Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Sno"].Value) + "'", con))
                        {
                            cmd.CommandType = CommandType.Text;
                            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                            {
                                using (DataTable dt = new DataTable())
                                {
                                    MessageBox.Show("User deleted successfully!");
                                    sda.Fill(dt);
                                }
                            }
                        }
                    }
                }
                else if (d == DialogResult.No)
                {
                    //   
                }
            }
            else if (e.ColumnIndex == 6) {
                label1.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Sno"].Value);
                txtusername.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Username"].Value);
                txtpassword.Hint = "Enter New Password";
                comboBox1.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["userlevel"].Value);
                btnadd.Text = "Update";
            }
            Bindgridview();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (txtpassword.TextLength > 0 && txtusername.TextLength > 0)
            {
                String datet = System.DateTime.Now.ToString();
                if (btnadd.Text == "Add User")
                {
                    string password = Encryptordecrypt.Decript_String(txtpassword.Text);// Decryptor.Decript_String(textBox1.Text);
                    string username = txtusername.Text;
                    string userlevel = comboBox1.Text;
                    string inserttousers = ("INSERT INTO users(username,password,userlevel,created_at)values('" + username + "','" + password + "','" + userlevel + "','" + datet + "')");
                    new sqlconnectionclass().WriteDB(inserttousers);
                    MessageBox.Show("User added successfully!");
                    txtpassword.Text = "";
                    txtusername.Text = "";
                    comboBox1.Text = "Select User Level";
                    Bindgridview();
                }
                else if (btnadd.Text == "Update")
                {
                    string password = Encryptordecrypt.Decript_String(txtpassword.Text);// Decryptor.Decript_String(textBox1.Text);
                    string username = txtusername.Text;
                    string userlevel = comboBox1.Text;
                    string Updateusers = ("UPDATE users SET username='" + username + "',password='" + password + "',userlevel='" + userlevel + "',created_at='" + datet + "' where user_id='"+label1.Text+"'");
                    new sqlconnectionclass().WriteDB(Updateusers);
                    MessageBox.Show("User Updated successfully!");
                    txtpassword.Text = "";
                    txtusername.Text = "";
                    comboBox1.Text = "Select User Level";
                    Bindgridview();
                }
            }
            else { MessageBox.Show("Username and password cannot be empty!"); }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
