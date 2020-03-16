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
    public partial class PackageMode : Form
    {
        public PackageMode()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string insertVat = ("INSERT INTO Packaging(mode)VALUES('" + txtParkageMode.Text + "')");
            new sqlconnectionclass().WriteDB(insertVat);
            MessageBox.Show("Parkage Mode added Successfully!");
            txtParkageMode.Text = "";
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
