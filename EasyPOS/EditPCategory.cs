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
    public partial class EditPCategory : Form
    {
        public EditPCategory()
        {
            InitializeComponent();
        }

        private void EditPCategory_Load(object sender, EventArgs e)
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

        private void Bindgridview()
        {
            using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connectme"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Cat_ID as Category_ID,Name as Category_Name,Description as Category_Description,created_at FROM P_Category", con))
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                DialogResult d = MessageBox.Show("Are you sure you want to delete this Category?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (d == DialogResult.Yes)
                {
                    using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connectme"].ConnectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("delete from P_Category where Cat_ID = '" + Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Category_ID"].Value) + "'", con))
                        {
                            cmd.CommandType = CommandType.Text;
                            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                            {
                                using (DataTable dt = new DataTable())
                                {
                                    MessageBox.Show("Category deleted successfully!");
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
            else if (e.ColumnIndex == 4)
            {
                //DialogResult d = MessageBox.Show("Want to Edit this Category?", "Confirm Edit", MessageBoxButtons.OK, MessageBoxIcon.Question);
                //if (d == DialogResult.OK)
                //{
                this.ReturnText = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Category_ID"].Value);
                this.ReturnName = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Category_name"].Value);
                this.ReturnDesc = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Category_Description"].Value);
                this.Visible = false;
                

                //        _TheValue = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                //        _TheName = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
                //        _TheDesc = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
                //        this.Hide();
                //    }
            }
            Bindgridview();
        }

        public string ReturnText { get; set; }

        public string ReturnName { get; set; }

        public string ReturnDesc { get; set; }
    }
}
