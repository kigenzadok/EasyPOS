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
    public partial class Price_List : Form
    {
        public Price_List()
        {
            InitializeComponent();
        }

        private void Price_List_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'easyposDataSet1.Products' table. You can move, or remove it, as needed.
            this.ProductsTableAdapter.Fill(this.easyposDataSet1.Products);

            this.reportViewer1.RefreshReport();
        }
    }
}
