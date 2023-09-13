using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobileSoftC_
{
    public partial class Selling : Form
    {
        public Selling()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Documents\MobileShop.mdf;Integrated Security=True;Connect Timeout=30");
        private void populateAccessoires()
        {
            Con.Open();
            string query = "SELECT ABrand,AModel,Aprice FROM AccessoiresTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            AccessoiresDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void populateMobile()
        {
            Con.Open();
            String query = "SELECT Mbrand,MModel,Mprice FROM mobileTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            MobileDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Selling_Load(object sender, EventArgs e)
        {
            populateMobile();
            populateAccessoires();
            MobileDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            AccessoiresDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        private void MobileDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            productName.Text = MobileDGV.SelectedRows[0].Cells[0].Value.ToString();
            Price.Text = MobileDGV.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        int n = 0, GrdTotal = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (Quantity.Text == "")
            {
                MessageBox.Show("Enter the quantity");

            }
            else
            {
                int total = Convert.ToInt32(Quantity.Text) * Convert.ToInt32(Price.Text);
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(BILLDGV);
                newRow.Cells[0].Value = n+1;
                newRow.Cells[1].Value = productName.Text;
                newRow.Cells[2].Value = Price.Text;
                newRow.Cells[3].Value = Quantity.Text;
                newRow.Cells[4].Value =total;
                BILLDGV.Rows.Add(newRow);
                GrdTotal += total;
                totalPrice.Text = GrdTotal.ToString();
                n++;
            }
        }
        int prodid, prodqty, prodprice, total, pos = 40;

        private void button5_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        string prodname;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Bajtbox", new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Red, new Point(90, 15));
            e.Graphics.DrawString("ID       PRODUCT       PRICE     QUANTITY     TOTAL", new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Red, new Point(26, 40));
            int startX = 26;
            int startY = 70;

            foreach (DataGridViewRow row in BILLDGV.Rows)
            {
                prodid = Convert.ToInt32(row.Cells["Column1"].Value);
                prodname = "" + row.Cells["Column2"].Value;
                prodprice = Convert.ToInt32(row.Cells["Column3"].Value);
                prodqty = Convert.ToInt32(row.Cells["Column4"].Value);
                total = Convert.ToInt32(row.Cells["Column5"].Value);

                // Postavite koordinate za svaku stavku na računu
                int xId = startX;
                int xName = xId + 70;
                int xPrice = xName + 100;
                int xQty = xPrice + 70;
                int xTotal = xQty + 100;

                e.Graphics.DrawString("" + prodid, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Red, new Point(xId, startY));
                e.Graphics.DrawString("" + prodname, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Red, new Point(xName, startY));
                e.Graphics.DrawString("" + prodprice, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Red, new Point(xPrice, startY));
                e.Graphics.DrawString("" + prodqty, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Red, new Point(xQty, startY));
                e.Graphics.DrawString("" + total, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Red, new Point(xTotal, startY));

                startY += 20; // Pomerajte startY za svaku novu stavku na računu
            }

            // Postavite koordinate za ukupnu cenu ispod stavki na računu
            int totalX = startX + 400; // Prilagodite ovu vrednost prema potrebama
            int totalY = startY + 20;  // Prilagodite ovu vrednost prema potrebama

            e.Graphics.DrawString("Total Price: " + GrdTotal, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Red, new Point(totalX, totalY));

            BILLDGV.Rows.Clear();
            BILLDGV.Refresh();
            pos = 100;
            GrdTotal = 0;
            n = 0;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 850,1100);
            if(printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {
            printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 850, 1100);
            /*
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }*/

        }

        private void AccessoiresDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            productName.Text = AccessoiresDGV.SelectedRows[0].Cells[0].Value.ToString();
            Price.Text = AccessoiresDGV.SelectedRows[0].Cells[2].Value.ToString();
        }
    }
}
