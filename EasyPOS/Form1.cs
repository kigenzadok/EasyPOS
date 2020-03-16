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
    public partial class Form1 : Form
    {
        System.Data.SqlClient.SqlDataReader DR,DR1,DR2; internal static string UserName = "", userlevel = "",userid="";
        public Form1()
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
        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (ValidateTextBoxes())
            {
                verifylogin();
            }
            
        }

        int attempts = 1;
        private void verifylogin()
        {
            string password = Encryptordecrypt.Decript_String(txtpass.Text);

            sqlconnectionclass read4login = new sqlconnectionclass();
            DR = read4login.ReadDB("select [user_id],[username],[password],[userlevel],[status] from [users] where username COLLATE Latin1_General_CS_AS='" + txtusername.Text + "' and [password] COLLATE Latin1_General_CS_AS='" + password + "'");
            if (DR.HasRows)
            {
                sqlconnectionclass checkstatus = new sqlconnectionclass();
                DR1 = checkstatus.ReadDB("select [user_id],[username],[password],[userlevel],[status] from [users] where username COLLATE Latin1_General_CS_AS='" + txtusername.Text + "' and [password] COLLATE Latin1_General_CS_AS='" + password + "'and status = 'active'");
                if (DR1.HasRows)
                {
                    while (DR.Read())
                    {
                        this.DialogResult = DialogResult.OK;
                        //usernamemenu.FindForm(Menu).Text = DR["username"].ToString();
                        userid = DR["user_id"].ToString();
                        UserName = DR["username"].ToString();
                        userlevel = DR["userlevel"].ToString();
                        string user = "User: " + Form1.UserName;

                        //string insert = "insert into usersession(user_id,logintime,logouttime)values('" + Form1.userid + "','" + System.DateTime.Now + "','" + System.DateTime.Now + "')";
                        //new sqlconnectionclass().WriteDB(insert);

                        foreach (Form f in Application.OpenForms) f.Text = user;
                    }
                }
                else
                {
                    MessageBox.Show("User account" + txtusername.Text + " is deactivated \n Contact the administrator");
                    Application.Exit();
                }
            }
            else if (attempts >= 3)
            {
                MessageBox.Show("Maximum number of attempts" + "\r\n the user account is deactivated!", "Attempts Exceeded", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
            }
            else
            {
                sqlconnectionclass checkuserexist = new sqlconnectionclass();
                DR2 = checkuserexist.ReadDB("select user_id,username,password from users where username COLLATE Latin1_General_CS_AS='" + txtusername.Text + "'");
                if (DR.HasRows)
                {
                    MessageBox.Show("Username and password incorrect, Please try again \r\n Current attempts:" + string.Concat(attempts, " of 3"), "Attempts space", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    attempts += 1;
                     //txtusername.Text = "";
                    txtpass.Text = "";
                }
                else
                {
                    MessageBox.Show("Username" +txtusername.Text+" doesn't exist");
                }

            }
        }
        private bool ValidateTextBoxes()
        {
            //throw new NotImplementedException();
            if (txtusername.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(txtusername, "Please Enter User Name");
                return false;
            }
            else
            {
                errorProvider1.SetError(txtusername, "");
            }
            if (txtpass.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(txtpass, "Please Enter the Password");
                return false;
            }
            else
            {
                errorProvider1.SetError(txtpass, "");
            }
            return true;
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Are you sure you want to exit this system", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (d == DialogResult.No)
            {
                //   
            }
        }

        private void txtpass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ValidateTextBoxes())
                {
                    verifylogin();
                }
            }
           
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Users u = new Users();
            u.ShowDialog();
        }

    }

}
