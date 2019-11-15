using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// GAMIT SNG MYSQL ---> add sa references ang mysql.data
using MySql.Data.MySqlClient;

namespace POS
{

    public partial class Form1 : Form
    {

        // ANG MGA VARIABLES DIRI, GLOBAL VARIABLE MAN.. PERO DIRI LNG SA SULOG SNG MUNI NGA FORM, WHICH IS: Form1
        // WHILE ANG SA GLOBALVARIABLES, CALLABLE ANYWHERE SA SYSTEM
        MySqlConnection con = new MySqlConnection(global.connectionString);

        string product_id = "", product_code = "", product_description = "", product_quantity = "", product_selling_price = "", product_base_price = "";



        string transaction_id = "";
        string sales_invoice_number = "";


        public Form1()
        {
            InitializeComponent();



            // INTIALIZE DATAGRID AT COMPONENT INITIALIZE
            dtgSale.ColumnCount = 5;
            dtgSale.Columns[0].Name = "#";
            dtgSale.Columns[1].Name = "Item Info";
            dtgSale.Columns[2].Name = "Quantity";
            dtgSale.Columns[3].Name = "Price";
            dtgSale.Columns[4].Name = "Discount";

            dtgSale.Columns[4].Visible = false;

            dtgSale.Columns[1].Width = dtgSale.Width / 3;
            dtgSale.Columns[0].Width = dtgSale.Width / 12;
            dtgSale.Columns[4].Width = dtgSale.Width / 8;


        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // TEXT CHANGED EVENT
            // DETERMINE NINYO DAYUN KUN PILA KA CHARACTERS ANG BARCODE NINYO...
            // KAY ANG BARCODE SCANNER KUMBAGA GINA TYPE MN NA NIYA ANG EVERY CHARACTER PA ISA ISA
            // SO I SET TA NGA KUN ANG TOTAL CHARACTERS NGA NA INPUT OK NA,
            // DIRA NA KITA MA SEARCH SA RECORD..
            // IN THIS CASE LETS SAY, 5... MA SEARCH LNG SA RECORD KUN 5 NA ANG CHARACTERS SA TEXTBOX
            if (txtSearch.Text.Length == 5)
            {
                searchRecordsFromBarcode();
            }
        }

        private void searchRecordsFromBarcode()
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                    con.Open();
                }
                else
                {
                    con.Open();
                }

                MySqlCommand com = new MySqlCommand(
                    @"SELECT 
                        id, 
                        barcode, 
                        description, 
                        quantity,
                        base_price, 
                        selling_price 
                    FROM 
                        yourdatabase.yourtable 
                    WHERE 
                        barcode = @code", con);

                MySqlDataAdapter da = new MySqlDataAdapter();
                com.Parameters.AddWithValue("@code", txtSearch.Text);
                da.SelectCommand = com;
                DataTable dt = new DataTable();
                da.Fill(dt);


                // CHECK IF MAY RESULT ANG SEARCH
                if (dt.Rows.Count > 0)
                {

                    // SAMPLE ON HOW TO GET DATA FROM DATATABLE

                    product_id = dt.Rows[0].Field<int>("id").ToString();
                    product_code = dt.Rows[0].Field<string>("barcode");
                    product_description = dt.Rows[0].Field<string>("description");
                    product_base_price = dt.Rows[0].Field<decimal>("base_price").ToString();
                    product_selling_price = dt.Rows[0].Field<decimal>("selling_price").ToString();
                    product_quantity = dt.Rows[0].Field<int>("quantity").ToString();


                    // ADD RESULT TO SALE

                    addToSale();

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addToSale()
        {
            if (txtSearch.Text == "")
            {

            }
            else
            {
                //this conditio here is to check if may enough pa nga quantity sa inventory
                if (int.Parse(txtQuantity.Text) > int.Parse(product_quantity))
                {
                    MessageBox.Show("Not enough quantity, " + product_description + " only have " + product_quantity + " quantity in stock now.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    int number = dtgSale.Rows.Count + 1;
                    string info = product_code + " @ " + "Php " + product_selling_price + Environment.NewLine + product_description;
                    decimal total_price = decimal.Parse(txtQuantity.Text) * decimal.Parse(product_selling_price);


                    // FILL DATAGRID WITH THE DATA
                    fillDatagrid(number.ToString(), info, txtQuantity.Text, " Php " + total_price.ToString(), "0.00%");
                    
                    
                    addDataToArray();

                    txtSearch.Clear();
                    txtQuantity.Text = "1";
                    txtSearch.Focus();

                }
            }
        }

        private void fillDatagrid(string number, string info, string quantity, string price, string discount)
        {
            string[] row = { number, info, quantity, price, discount };

            dtgSale.Rows.Add(row);
        }


        private void addDataToArray()
        {
            decimal total_price = decimal.Parse(txtQuantity.Text) * decimal.Parse(product_selling_price);
            int index = dtgSale.Rows.Count - 1;


            global.sales_product_id[index] = product_id;
            global.sales_procudt_code[index] = product_code;
            global.sales_product_description[index] = product_description;
            global.sales_product_quantity[index] = txtQuantity.Text;
            global.sales_product_discount[index] = "";
            global.sales_product_old_quantity[index] = product_quantity;
            global.sales_product_base_price[index] = product_base_price;
            global.sales_product_price[index] = product_selling_price;
            global.sales_total[index] = total_price.ToString();


            decimal total_price_label = 0;

            for (int i = 0; i < dtgSale.Rows.Count; i++)
            {
                decimal qty = decimal.Parse(global.sales_product_quantity[i]);
                decimal price = decimal.Parse(global.sales_product_price[i]);


                total_price_label = total_price_label + (qty * price);


                lblTotal.Text = "Php " + total_price_label.ToString();

            }

        }


        // SAMPLE KO LANG NI HA
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int newline = 15;
            int loopline = 30;
            int spacing = 0;
            int lines = dtgSale.Rows.Count + 10;



            // FILL THESE WITH VALUES... ANG SA DALUM, DUMMY LNG INA
            //string payment_amount_formatted = cash_payment.ToString("###,###.00");
            //string change_amount_formatted = final_change.ToString("###,###.00");
            //string payables_amount_formatted = total_bills.ToString("###,###.00");

            string payment_amount_formatted = "1,000.00";
            string change_amount_formatted = "1,000.00";
            string payables_amount_formatted = "1,000.00";
            

            e.Graphics.DrawString("FILAMER CHRISTIAN UNIVERSITY", new Font("Calibri", 8, FontStyle.Regular), Brushes.Black, new Point(20, 30));
            e.Graphics.DrawString("Roxas Avenue, Roxas City", new Font("Calibri", 8, FontStyle.Regular), Brushes.Black, new Point(41, 45));
            e.Graphics.DrawString("UNIVERSITY ENTERPRISE", new Font("Calibri", 8, FontStyle.Regular), Brushes.Black, new Point(40, 60));

            e.Graphics.DrawString("SALES INVOICE", new Font("Calibri", 8, FontStyle.Bold), Brushes.Black, new Point(60, 85));

            e.Graphics.DrawString("Sold To: " + global.customer_name, new Font("Calibri", 8, FontStyle.Regular), Brushes.Black, new Point(0, 110));
            e.Graphics.DrawString("Address: " + global.customer_address, new Font("Calibri", 8, FontStyle.Regular), Brushes.Black, new Point(0, 125));

            Pen blackPen = new Pen(Color.Black, 3);

            PointF point1 = new PointF(0.0F, 50.0F);
            PointF point2 = new PointF(0.0F, 50.0F);
            PointF point3 = new PointF(900.0F, 500.0F);
            PointF point4 = new PointF(900.0F, 500.0F);

            //e.Graphics.DrawLine(blackPen, point1, point2);


            //e.Graphics.DrawString("Description         Quantity     Price     Amount", new Font("Calibri", 8, FontStyle.Regular), Brushes.Black, new Point(0, 115));

            e.Graphics.DrawString("===================================", new Font("Calibri", 8, FontStyle.Regular), Brushes.Black, new Point(0, 145));

            for (int i = 0; i < dtgSale.Rows.Count; i++)
            {
                decimal line_total = decimal.Parse(global.sales_product_price[i]) * decimal.Parse(global.sales_product_quantity[i]);
                e.Graphics.DrawString(global.sales_procudt_code[i] + "  -  " + global.sales_product_description[i], new Font("Calibri", 8, FontStyle.Regular), Brushes.Black, new Point(0, 145 + ((loopline * (i + 1)) - 15)));
                e.Graphics.DrawString("   " + global.sales_product_price[i] + "  X  " + global.sales_product_quantity[i] + "  =  " + line_total.ToString(), new Font("Calibri", 8, FontStyle.Regular), Brushes.Black, new Point(0, 145 + (loopline * (i + 1))));
                spacing = (loopline * (i + 1));
            }

            e.Graphics.DrawString("===================================", new Font("Calibri", 8, FontStyle.Regular), Brushes.Black, new Point(0, 160 + spacing));

            e.Graphics.DrawString("Total:                                    " + payables_amount_formatted, new Font("Calibri", 8, FontStyle.Regular), Brushes.Black, new Point(0, (160 + spacing) + 15));
            e.Graphics.DrawString("Cash:                                     " + payment_amount_formatted, new Font("Calibri", 8, FontStyle.Regular), Brushes.Black, new Point(0, (160 + spacing) + 30));
            e.Graphics.DrawString("Change:                                " + change_amount_formatted, new Font("Calibri", 8, FontStyle.Regular), Brushes.Black, new Point(0, (160 + spacing) + 45));

            e.Graphics.DrawString("===================================", new Font("Calibri", 8, FontStyle.Regular), Brushes.Black, new Point(0, (160 + spacing) + 60));
            e.Graphics.DrawString("This serves as your official reciept.", new Font("Calibri", 8, FontStyle.Regular), Brushes.Black, new Point(15, (160 + spacing) + 75));
            e.Graphics.DrawString("Thank You!", new Font("Calibri", 8, FontStyle.Regular), Brushes.Black, new Point(65, (160 + spacing) + 90));
            e.Graphics.DrawString("===================================", new Font("Calibri", 8, FontStyle.Regular), Brushes.Black, new Point(0, (160 + spacing) + 105));

            e.Graphics.DrawString("Transaction#: " + (int.Parse(transaction_id) - 1).ToString(), new Font("Calibri", 8, FontStyle.Regular), Brushes.Black, new Point(0, (160 + spacing) + 130));
            e.Graphics.DrawString("Cashier: " + global.user, new Font("Calibri", 8, FontStyle.Regular), Brushes.Black, new Point(0, (160 + spacing) + 145));
            e.Graphics.DrawString("Invoice #: " + sales_invoice_number, new Font("Calibri", 8, FontStyle.Regular), Brushes.Black, new Point(0, (160 + spacing) + 160));
            e.Graphics.DrawString("Date: " + DateTime.Now.Date.ToString("MM/dd/yyyy"), new Font("Calibri", 8, FontStyle.Regular), Brushes.Black, new Point(0, (160 + spacing) + 175));
            e.Graphics.DrawString("Time: " + DateTime.Now.ToString("HH:mm tt"), new Font("Calibri", 8, FontStyle.Regular), Brushes.Black, new Point(0, (160 + spacing) + 190));
            e.Graphics.DrawString("   ", new Font("Calibri", 8, FontStyle.Regular), Brushes.Black, new Point(0, (160 + spacing) + 205));
            
        }

        private void btnPayCash_Click(object sender, EventArgs e)
        {
            DialogResult ask = MessageBox.Show("Print receipt?", "Print", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (ask == DialogResult.Yes)
            {
                //printDocument.PrinterSettings.PrinterName = "";

                int PreferredZoomValue = 200;
                PrintPreviewDialog dgl = new PrintPreviewDialog();
                dgl.PrintPreviewControl.Zoom = PreferredZoomValue / 100f;
                dgl.Document = printDocument1;
                dgl.ShowDialog();

            }
        }





        // ARI IS IF MA UBRA KAMO SANG SETTINGS... PWEDE KAMO KA UBRA SNG SETTINGS NGA USABLE SA SYSTEM...
        // YOUTUBE LANG..


        //private void printReciept()
        //{
        //    try
        //    {
        //        start of printing
        //        printDocument.PrinterSettings.PrinterName = Properties.Settings.Default.printer_name_receipt;
        //        if (Properties.Settings.Default.ask_receipt_printing == "y")
        //        {
        //            DialogResult ask = MessageBox.Show("Print receipt?", "Print", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        //            if (ask == DialogResult.Yes)
        //            {
        //                if (Properties.Settings.Default.preview_before_printing == true)
        //                {
        //                    int PreferredZoomValue = 200;
        //                    PrintPreviewDialog dgl = new PrintPreviewDialog();
        //                    dgl.PrintPreviewControl.Zoom = PreferredZoomValue / 100f;
        //                    dgl.Document = printDocument;
        //                    dgl.ShowDialog();
        //                }
        //                else
        //                {
        //                    int count = Properties.Settings.Default.receipt_printing_count;
        //                    if (count > 1)
        //                    {
        //                        for (int i = 0; i < count; i++)
        //                        {
        //                            string message = "Printing " + (i + 1).ToString() + " out of " + count.ToString() + " copies";
        //                            MessageBox.Show(message, "Printing", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                            printDocument.Print();
        //                        }
        //                    }
        //                    else
        //                    {
        //                        printDocument.Print();
        //                    }
        //                }
        //            }
        //        }
        //        else
        //        {
        //            if (Properties.Settings.Default.preview_before_printing == true)
        //            {
        //                int PreferredZoomValue = 200;
        //                PrintPreviewDialog dgl = new PrintPreviewDialog();
        //                dgl.PrintPreviewControl.Zoom = PreferredZoomValue / 100f;
        //                dgl.Document = printDocument;
        //                dgl.ShowDialog();
        //            }
        //            else
        //            {
        //                int count = Properties.Settings.Default.receipt_printing_count;
        //                if (count > 1)
        //                {
        //                    for (int i = 0; i < count; i++)
        //                    {
        //                        string message = "Printing " + (i + 1).ToString() + " out of " + count.ToString() + " copies";
        //                        MessageBox.Show(message, "Printing", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                        printDocument.Print();
        //                    }
        //                }
        //                else
        //                {
        //                    printDocument.Print();
        //                }
        //            }
        //        }
        //        end of printing
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }



        //}




       

        // SAMPLE KO LNG NA KUN PAANO MAG UPDATE INVENTORY KAG MAG SAVE SNG SALE SALES TRANSACTIONS

        private void updateInventoryQuantity()
        {

            for (int i = 0; i < dtgSale.Rows.Count; i++)
            {
                try
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                        con.Open();
                    }
                    else
                    {
                        con.Open();
                    }

                    int old = int.Parse(global.sales_product_old_quantity[i]);
                    int minus = int.Parse(global.sales_product_quantity[i]);
                    int new_quantity = old - minus;

                    string query = @"update 
                    db_fcu_enterprise.tbl_inventory set
                    quantity = @qty
                    where id = @id";

                    MySqlCommand cmd = new MySqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@qty", new_quantity.ToString());
                    cmd.Parameters.AddWithValue("@id", global.sales_product_id[i]);

                    cmd.ExecuteReader();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        // MUNI MAG CALL SANG SAVING....

        //for (int i = 0; i < dtgSale.Rows.Count; i++)
        //                {
        //                    saveSalesData(i);
        //                }


        private void saveSalesData(int loop_index)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                    con.Open();
                }
                else
                {
                    con.Open();
                }

                string query = @"INSERT INTO 
                db_fcu_enterprise.tbl_sales 
                (product_id, transaction_id, product_code, description, quantity, sale_date, sale_time, base_price, price, discount, user, si_number, is_paid) 
                VALUES
                (@pid, @tid, @code, @desc, @qty, @date, @time, @bprice, @price, @discount, @user, @sin, @ispaid)";

                MySqlCommand cmd = new MySqlCommand(query, con);


                cmd.Parameters.AddWithValue("@pid", global.sales_product_id[loop_index]);
                cmd.Parameters.AddWithValue("@tid", transaction_id);
                cmd.Parameters.AddWithValue("@code", global.sales_procudt_code[loop_index]);
                cmd.Parameters.AddWithValue("@desc", global.sales_product_description[loop_index]);
                cmd.Parameters.AddWithValue("@qty", global.sales_product_quantity[loop_index]);
                cmd.Parameters.AddWithValue("@date", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("@time", DateTime.Now.TimeOfDay);
                cmd.Parameters.AddWithValue("@bprice", global.sales_product_base_price[loop_index]);
                cmd.Parameters.AddWithValue("@price", global.sales_product_price[loop_index]);
                cmd.Parameters.AddWithValue("@discount", global.sales_product_discount[loop_index]);
                cmd.Parameters.AddWithValue("@sin", sales_invoice_number);
                cmd.Parameters.AddWithValue("@user", global.user);
                cmd.Parameters.AddWithValue("@ispaid", "y");


                cmd.ExecuteReader();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
