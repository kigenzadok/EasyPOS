using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;


namespace EasyPOS
{
    public partial class StockReplenishment : Form
    {
        #region Member Variables
        StringFormat strFormat; //Used to format the grid rows.
        ArrayList arrColumnLefts = new ArrayList();//Used to save left coordinates of columns
        ArrayList arrColumnWidths = new ArrayList();//Used to save column widths
        int iCellHeight = 0; //Used to get/set the datagridview cell height
        int iTotalWidth = 0; //
        int iRow = 0;//Used as counter
        bool bFirstPage = false; //Used to check whether we are printing first page
        bool bNewPage = false;// Used to check whether we are printing a new page
        int iHeaderHeight = 0; //Used for the header height
        #endregion

        System.Data.SqlClient.SqlDataReader DR, DR1;
        private double Vatrate, cost;
        private double totalvat;
        private string pid;
        DataTable table = new DataTable();
        private double sum = 0;
        public StockReplenishment()
        {
            InitializeComponent();
            listprodu();
        }

        private void listprodu()
        {
            //throw new NotImplementedException();
            List<String> productlist = new List<string>();
            sqlconnectionclass selecttousers = new sqlconnectionclass();
            DR = selecttousers.ReadDB("select * from Products where itemtype='SI'");
            while (DR.Read())
            {
                productlist.Add(DR[0] + ":" + DR[1]);
            }
            listBox1.DataSource = productlist;
        }

        private void StockReplenishment_Load(object sender, EventArgs e)
        {
            DeliveryModeComboBox.Items.Add("Cash");
            DeliveryModeComboBox.Items.Add("Invoice");
            tableheaders();
        }

        private void tableheaders()
        {
            //throw new NotImplementedException();
            table.Columns.Add("PNo.", typeof(int));
            table.Columns.Add("Product Name", typeof(string));
            table.Columns.Add("Delivery Mode", typeof(string));
            table.Columns.Add("Note no.", typeof(string));
            table.Columns.Add("Supplier", typeof(string));
            table.Columns.Add("Order No", typeof(string));
            table.Columns.Add("Vehicle", typeof(string));
            table.Columns.Add("Quantity", typeof(int));
            table.Columns.Add("Unit Price", typeof(int));
            table.Columns.Add("Total VAT", typeof(string));
            table.Columns.Add("Total Cost", typeof(string));

            dataGridView1.DataSource = table;

            DataGridViewLinkColumn Editlink = new DataGridViewLinkColumn();
            Editlink.UseColumnTextForLinkValue = true;
            Editlink.HeaderText = "Remove";
            Editlink.DataPropertyName = "lnkColumn";
            Editlink.LinkBehavior = LinkBehavior.SystemDefault;
            Editlink.Text = "Remove";
            dataGridView1.Columns.Add(Editlink);
        }
        void fill_combo()
        {
            try
            {
                sqlconnectionclass selecttousers = new sqlconnectionclass();
                DR = selecttousers.ReadDB("select * from Suppliers");
                while (DR.Read())
                {
                    string sname = DR.GetString(1);
                    comboSupplier.Items.Add(sname);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void DeliveryModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonSupplier_Click(object sender, EventArgs e)
        {
            AddEditSuppliers Aes = new AddEditSuppliers();
            Aes.ShowDialog();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboSupplier_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Close();

        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                List<String> productlist = new List<string>();
                sqlconnectionclass selecttousers = new sqlconnectionclass();
                DR = selecttousers.ReadDB("select * from Products where ProductName like '%" + textBoxSearch.Text + "%' and itemtype='SI'");
                while (DR.Read())
                {
                    productlist.Add(DR[0] + ":" + DR[1]);
                }
                listBox1.DataSource = productlist;
            }
            else if (radioButton3.Checked == true)
            {
                List<String> productlist = new List<string>();
                sqlconnectionclass selecttousers = new sqlconnectionclass();
                DR = selecttousers.ReadDB("select * from Products where ProductNo like '%" + textBoxSearch.Text + "%' and itemtype='SI'");
                while (DR.Read())
                {
                    productlist.Add(DR[0] + ":" + DR[1]);
                }
                listBox1.DataSource = productlist;
            }
            else if (radioButton2.Checked == true)
            {
                List<String> productlist = new List<string>();
                sqlconnectionclass selecttousers = new sqlconnectionclass();
                DR = selecttousers.ReadDB("select * from Products where barcode like '%" + textBoxSearch.Text + "%' and itemtype='SI'");
                while (DR.Read())
                {
                    productlist.Add(DR[0] + ":" + DR[1]);
                }
                listBox1.DataSource = productlist;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            listBox1.DataSource = null;
            listBox1.Items.Clear();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            listBox1.DataSource = null;
            listBox1.Items.Clear();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            listBox1.DataSource = null;
            listBox1.Items.Clear();
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            //throw new NotImplementedException();
            textBoxSearch.Text = listBox1.SelectedValue.ToString();
            sqlconnectionclass selectpid = new sqlconnectionclass();
            DR = selectpid.ReadDB("select ProductNo from Products where productno='" + textBoxSearch.Text.Split(':')[0] + "'");
            if (DR.HasRows)
            {
                DR.Read();
                pid = DR["ProductNo"].ToString();
                sqlconnectionclass selectpd = new sqlconnectionclass();
                DR1 = selectpd.ReadDB("select (select top 1 unitprice from stockin where productno = '" + pid + "' ORDER BY rep_no DESC ) as currentprice,vat_rate,((select isnull(sum(qty),0)as availab from stockin where ProductNo= '" + pid + "')-(select isnull(sum(sqty),0)as qty from sales where ProductNo= '" + pid + "')) As available from Products where ProductNo= '" + pid + "'");
                if (DR1.HasRows)
                {
                    DR1.Read();
                    textBox2.Text = DR1[0].ToString();
                    textBox8.Text = DR1[2].ToString();
                    //textBox4.Text = DR1[0].ToString();
                    Vatrate = Convert.ToDouble(DR1[1]);
                }
            }
        }

        private void comboSupplier_DropDown(object sender, EventArgs e)
        {
            comboSupplier.Items.Clear();
            fill_combo();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.TextLength > 0 && textBox6.TextLength > 0)
            {
                cost = Convert.ToDouble(textBox4.Text) * Convert.ToDouble(textBox6.Text);
                textBox5.Text = cost.ToString();
            }
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton8.Checked == true)
            {
                totalvat = 0;
                textBox7.Text = cost.ToString();
            }
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton7.Checked == true)
            {
                totalvat = Vatrate / 100 * cost;
                textBox7.Text = cost.ToString();
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked == true)
            {
                totalvat = Vatrate / 100 * cost;
                textBox7.Text = (cost + totalvat).ToString();
            }
        }

        private void AddtothecartBtn_Click(object sender, EventArgs e)
        {
            if (pid != "" && textBoxSearch.Text != "" && textBox6.Text != "" && textBox4.Text != "" && textBox7.Text != "" && DeliveryModeComboBox.Text != "" && textBox3.Text != "" && comboSupplier.Text != "" && txtorderno.Text!="" && txtvehicleno.Text!="")
            {
                float averageprice;
                if (textBox2.Text != "")
                {

                    averageprice = (((Convert.ToInt32(textBox2.Text) * Convert.ToInt32(textBox8.Text)) + (Convert.ToInt32(textBox4.Text) * Convert.ToInt32(textBox6.Text))) / (Convert.ToInt32(textBox8.Text) + Convert.ToInt32(textBox6.Text)));
                }
                else {
                    averageprice = Convert.ToInt32(textBox4.Text);
                
                }
                table.Rows.Add(pid, textBoxSearch.Text.Split(':')[1], DeliveryModeComboBox.Text, textBox3.Text, comboSupplier.Text, txtorderno.Text, txtvehicleno.Text,textBox6.Text, averageprice, totalvat,textBox7.Text);
                dataGridView1.DataSource = table;
                sum += Convert.ToInt32(textBox7.Text);
                dataGridView1[10, dataGridView1.Rows.Count - 1].Value = sum;

            }
            else
            {
                MessageBox.Show("Fields can't be empty!");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 11)
            {
                dataGridView1.Rows.Remove(dataGridView1.Rows[e.RowIndex]);
                sum -= Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString());
                dataGridView1[10, dataGridView1.Rows.Count - 1].Value = sum;
            }
        }


        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            double total4 = 0;
            if (e.ColumnIndex != 10) return;
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                double t = 0;
                if (r.Cells[10].Value != null)
                    if (double.TryParse(r.Cells[10].Value.ToString(), out t))
                        total4 += t;
            }
            dataGridView1.Rows[e.RowIndex].Cells[10].Value = total4;
            //dataGridView1[4, dataGridView1.Rows.Count - 1].Value = total4;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float available = 0, added = 0, totalqty;
            available = Convert.ToInt32(textBox8.Text);
            added = Convert.ToInt32(textBox6.Text);
            totalqty = available + added;
            //textBoxBalance.Text = Balance.ToString();
            int replenish = 0;
            sqlconnectionclass getrepno = new sqlconnectionclass();
            DR = getrepno.ReadDB("select top 1 greplenishno from stockin ORDER BY greplenishno DESC");
            if (DR.HasRows)
            {
                DR.Read();
                replenish = Convert.ToInt32(DR[0]) + 1;
            }
            else { replenish = 1; }
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    string insertstock = "INSERT INTO [stockin]([ProductNo],[Suppliername],[deliverymode],[note_no],[qty],[VAT],[Totalcost],[unitprice],[greplenishno],[orderno],[vehicleno],[date])VALUES('" + row.Cells[0].Value + "','" + row.Cells[4].Value + "','" + row.Cells[2].Value + "','" + row.Cells[3].Value + "','" + row.Cells[7].Value + "','" + row.Cells[9].Value + "','" + row.Cells[10].Value + "','" + row.Cells[8].Value + "','" + replenish + "','" + row.Cells[5].Value + "','" + row.Cells[6].Value + "','" + System.DateTime.Now + "')";
                    new sqlconnectionclass().WriteDB(insertstock);

                    string insertstockcard = "INSERT INTO [Stockcard]([ProductNo] ,[Transaction_Date],[Naration] ,[Qty_in] ,[Qty_out],[Lacation],[System_User],[New_Stock],[Available_Stock],[DateReport],[Timereport]) VALUES('" + row.Cells[0].Value + "','" + System.DateTime.Now + "','Replenishment of''" + row.Cells[1].Value + "','" + row.Cells[7].Value + "','0','Store','" + Form1.UserName + "','" + totalqty + "','" + textBox8.Text + "','" + System.DateTime.Now + "','" + System.DateTime.Now + "')";
                    new sqlconnectionclass().WriteDB(insertstockcard);
                }
            }
            MessageBox.Show("Replenishment done successfully!");
            dataGridView1.Columns.RemoveAt(11);
            dataGridView1.Columns.RemoveAt(0);
            dataGridView1.Columns.RemoveAt(2);
            dataGridView1.Columns.RemoveAt(3);
            dataGridView1.Columns.RemoveAt(4);
            dataGridView1.Columns.RemoveAt(5);
            //dataGridView1.Columns.RemoveAt(6);
            //dataGridView1.Columns.RemoveAt(8);
            //dataGridView1.Columns.RemoveAt(9);
            //Open the print dialog
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument1;
            printDialog.UseEXDialog = true;

            //Get the document
            if (DialogResult.OK == printDialog.ShowDialog())
            {
                printDocument1.DocumentName = "EasyPOS Print";
                printDocument1.Print();
            }

            //Open the print preview dialog
            PrintPreviewDialog objPPdialog = new PrintPreviewDialog();
            objPPdialog.Document = printDocument1;
            objPPdialog.ShowDialog();
            this.Close();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                //Set the left margin
                int iLeftMargin = e.MarginBounds.Left;
                //Set the top margin
                int iTopMargin = e.MarginBounds.Top;
                //Whether more pages have to print or not
                bool bMorePagesToPrint = false;
                int iTmpWidth = 0;

                //For the first page to print set the cell width and header height
                if (bFirstPage)
                {
                    foreach (DataGridViewColumn GridCol in dataGridView1.Columns)
                    {
                        iTmpWidth = (int)(Math.Floor((double)((double)GridCol.Width /
                                       (double)iTotalWidth * (double)iTotalWidth *
                                       ((double)e.MarginBounds.Width / (double)iTotalWidth))));

                        iHeaderHeight = (int)(e.Graphics.MeasureString(GridCol.HeaderText,
                                    GridCol.InheritedStyle.Font, iTmpWidth).Height) + 11;

                        // Save width and height of headres
                        arrColumnLefts.Add(iLeftMargin);
                        arrColumnWidths.Add(iTmpWidth);
                        iLeftMargin += iTmpWidth;
                    }
                }
                //Loop till all the grid rows not get printed
                while (iRow <= dataGridView1.Rows.Count - 1)
                {
                    DataGridViewRow GridRow = dataGridView1.Rows[iRow];
                    //Set the cell height
                    iCellHeight = GridRow.Height + 5;
                    int iCount = 0;
                    //Check whether the current page settings allo more rows to print
                    if (iTopMargin + iCellHeight >= e.MarginBounds.Height + e.MarginBounds.Top)
                    {
                        bNewPage = true;
                        bFirstPage = false;
                        bMorePagesToPrint = true;
                        break;
                    }
                    else
                    {
                        if (bNewPage)
                        {
                            //Draw Header
                            e.Graphics.DrawString("Jomat General Hardware\nEasyPOS Reports \nReplenishment Summary", new Font(dataGridView1.Font, FontStyle.Bold),
                                    Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top -
                                    e.Graphics.MeasureString("EasyPOS Reports \nReplenishment Summary", new Font(dataGridView1.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            String strDate = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
                            //Draw Date
                            e.Graphics.DrawString(strDate, new Font(dataGridView1.Font, FontStyle.Bold),
                                    Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width -
                                    e.Graphics.MeasureString(strDate, new Font(dataGridView1.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Width), e.MarginBounds.Top -
                                    e.Graphics.MeasureString("EasyPOS Reports \nReplenishment Summary", new Font(new Font(dataGridView1.Font,
                                    FontStyle.Bold), FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            //Draw Columns                 
                            iTopMargin = e.MarginBounds.Top;
                            foreach (DataGridViewColumn GridCol in dataGridView1.Columns)
                            {
                                e.Graphics.FillRectangle(new SolidBrush(Color.LightGray),
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawRectangle(Pens.Black,
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawString(GridCol.HeaderText, GridCol.InheritedStyle.Font,
                                    new SolidBrush(GridCol.InheritedStyle.ForeColor),
                                    new RectangleF((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight), strFormat);
                                iCount++;
                            }
                            bNewPage = false;
                            iTopMargin += iHeaderHeight;
                        }
                        iCount = 0;
                        //Draw Columns Contents                
                        foreach (DataGridViewCell Cel in GridRow.Cells)
                        {
                            if (Cel.Value != null)
                            {
                                e.Graphics.DrawString(Cel.Value.ToString(), Cel.InheritedStyle.Font,
                                            new SolidBrush(Cel.InheritedStyle.ForeColor),
                                            new RectangleF((int)arrColumnLefts[iCount], (float)iTopMargin,
                                            (int)arrColumnWidths[iCount], (float)iCellHeight), strFormat);
                            }
                            //Drawing Cells Borders 
                            e.Graphics.DrawRectangle(Pens.Black, new Rectangle((int)arrColumnLefts[iCount],
                                    iTopMargin, (int)arrColumnWidths[iCount], iCellHeight));

                            iCount++;
                        }
                    }
                    iRow++;
                    iTopMargin += iCellHeight;
                }

                //If more lines exist, print another page.
                if (bMorePagesToPrint)
                    e.HasMorePages = true;
                else
                    e.HasMorePages = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                strFormat = new StringFormat();
                strFormat.Alignment = StringAlignment.Near;
                strFormat.LineAlignment = StringAlignment.Center;
                strFormat.Trimming = StringTrimming.EllipsisCharacter;

                arrColumnLefts.Clear();
                arrColumnWidths.Clear();
                iCellHeight = 0;
                iRow = 0;
                bFirstPage = true;
                bNewPage = true;

                // Calculating Total Widths
                iTotalWidth = 0;
                foreach (DataGridViewColumn dgvGridCol in dataGridView1.Columns)
                {
                    iTotalWidth += dgvGridCol.Width;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddEditProduct aed = new AddEditProduct();
            aed.ShowDialog();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
