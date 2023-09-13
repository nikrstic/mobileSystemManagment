using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;

namespace MobileSoftC_
{
    public partial class Accessoires : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Documents\MobileShop.mdf;Integrated Security=True;Connect Timeout=30");

        public Accessoires()
        {
            InitializeComponent();
        }
        private void populate()
        {
            Con.Open();
            string query = "SELECT * FROM AccessoiresTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            AccessoiresDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (id.Text == "" || AModele.Text == "" || ABrand.Text == "" || APrice.Text == "" || AStock.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();

                    string sql = "INSERT INTO AccessoiresTbl VALUES ('" +
                                 id.Text + "', '" +
                                 ABrand.Text + "', '" +
                                 AModele.Text + "', '" +
                                 AStock.Text + "', '" +
                                 APrice.Text
                                 + "') ";

                    SqlCommand cmd = new SqlCommand(sql, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Accessoire Added Successfully ");
                    Con.Close();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
       

        private void button3_Click(object sender, EventArgs e)
        {
            if (id.Text == "")
            {
                MessageBox.Show("Enter the accessoire to be deleted");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "DELETE FROM AccessoiresTbl WHERE id = " + id.Text;
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Accessoire Deleted");
                    Con.Close();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (id.Text == "" || AModele.Text == "" || ABrand.Text == "" || APrice.Text == "" || AStock.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();

                    string updateQuery = "UPDATE AccessoiresTbl SET " +
                        "ABrand = '" + ABrand.Text + "', " +
                        "AModel = '" + AModele.Text + "', " +
                        "AStock = '" + AStock.Text + "', " +
                        "APrice = '" + APrice.Text + "' " +
                        "WHERE id = '" + id.Text + "'";

                    SqlCommand cmd = new SqlCommand(updateQuery, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Accessoire Updated Successfully ");
                    Con.Close();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            id.Text = "";
            ABrand.Text = "";
            AModele.Text = "";
            APrice.Text = "";
            AStock.Text = "";
        }

        private void Accessoires_Load(object sender, EventArgs e)
        {
            AccessoiresDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            populate();
        }

        private void AccessoiresDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
   
            id.Text = AccessoiresDGV.SelectedRows[0].Cells[0].Value.ToString();
            ABrand.Text = AccessoiresDGV.SelectedRows[0].Cells[1].Value.ToString();
            AModele.Text = AccessoiresDGV.SelectedRows[0].Cells[2].Value.ToString();
            APrice.Text = AccessoiresDGV.SelectedRows[0].Cells[3].Value.ToString();
            AStock.Text = AccessoiresDGV.SelectedRows[0].Cells[4].Value.ToString();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }
    }
}
