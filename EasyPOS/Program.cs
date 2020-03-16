using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EasyPOS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Data.SqlClient.SqlDataReader DR;
            //Application.Run(new Sales());
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            sqlconnectionclass read4login = new sqlconnectionclass();
            DR = read4login.ReadDB("select * from [users]");
            if (DR.HasRows)
            {
                while (DR.Read())
                {
                    Form1 L = new Form1();
                    DialogResult dr = L.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        Home F = new Home();
                        F.Text = "EasyPOS" + "                       " + "You are login as: " + Form1.UserName;
                        Application.Run(F);
                    }
                }
            }
            else
            {
                try
                {
                    string datet = System.DateTime.Now.ToString();
                    string password = Encryptordecrypt.Decript_String("admin123");// Decryptor.Decript_String(textBox1.Text);
                    string username = "admin";
                    string userlevel = "super_admin";
                    string inserttousers = ("INSERT INTO users(username,password,userlevel,created_at)values('" + username + "','" + password + "','" + userlevel + "','" + datet + "')");
                    new sqlconnectionclass().WriteDB(inserttousers);
                }
                catch (Exception)
                {

                }
                finally
                {
                    Form1 L = new Form1();
                    DialogResult dr = L.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        Home F = new Home();
                        F.Text = "EasyPOS" + "" + "You are login as: " + Form1.UserName;
                        Application.Run(F);
                    }
                }
            }
        }
    }
}
