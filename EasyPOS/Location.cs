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
    public partial class Location : Form
    {
        public Location()
        {
            InitializeComponent();
        }

        private void Location_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //string insertLoc = ("INSERT INTO Packaging(mode)VALUES('" + txtParkageMode.Text + "')");
            //new sqlconnectionclass().WriteDB(insertLoc);
            //MessageBox.Show("Parkage Mode added Successfully!");
            //txtParkageMode.Text = "";
        }
    }
}
