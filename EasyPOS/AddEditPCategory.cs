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
    public partial class AddEditPCategory : Form
    {
        public AddEditPCategory()
        {
            InitializeComponent();
        }

        private const int WM_NCHITTEST = 0x84;// declarations of variables used in the draggable method fxn
        private const int HT_CLIENT = 0x1;// declarations of variables used in the draggable method fxn
        private const int HT_CAPTION = 0x2;// declarations of variables used in the draggable method fxn
        protected override void WndProc(ref Message m)//method to make form draggable when mouse^hold
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }
        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (btnsave.Text =="&Save")
            {
                if (txtname.TextLength > 0 && txtdesc.TextLength > 0)
                {
                    try
                    {
                        string insertcat = ("INSERT INTO P_Category(Name,Description,created_at)values('" + txtname.Text + "','" + txtdesc.Text + "','" + System.DateTime.Now.ToString() + "')");
                        new sqlconnectionclass().WriteDB(insertcat);
                        MessageBox.Show("Category added Successfully!");
                        txtdesc.Text = ""; txtname.Text = ""; txtno.Text = "";
                    }
                    catch (NotImplementedException) { }
                }
                else
                {
                    MessageBox.Show("Category name and description required!");
                }
            }
            else if (btnsave.Text == "Update") {
                string Updatecat = ("UPDATE P_Category SET Name='" + txtname.Text + "',Description='" + txtdesc.Text + "',created_at='" + System.DateTime.Now.ToString() + "' where Cat_ID='" + txtno.Text+ "'");
                new sqlconnectionclass().WriteDB(Updatecat);
                MessageBox.Show("User Updated successfully!");
                txtno.Text = ""; txtname.Text = ""; txtdesc.Text = ""; btnsave.Text = "Save";
            }
        }
        private void formVisibleChanged(object sender, EventArgs e)
        {
            EditPCategory epc = (EditPCategory)sender;
            if (!epc.Visible)
            {
                this.txtno.Text = epc.ReturnText;
                this.txtname.Text = epc.ReturnName;
                this.txtdesc.Text = epc.ReturnDesc;
                btnsave.Text = "Update";
                epc.Dispose();
            }


        }

        private void Button3_Click(object sender, EventArgs e)
        {
            EditPCategory epc = new EditPCategory();
            epc.Show();
            epc.VisibleChanged += formVisibleChanged;
        }

        private void txtdesc_TextChanged(object sender, EventArgs e)
        {

        }

       

    }
}
