using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MobileSoftC_
{
    public partial class Mobile : Form
    {
        public Mobile()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Documents\MobileShop.mdf;Integrated Security=True;Connect Timeout=30");


        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            
            //MobileDGV.MultiSelect = true;
            //MessageBox.Show(MobileDGV.SelectedRows.Count.ToString());
            id.Text = MobileDGV.SelectedRows[0].Cells[0].Value.ToString();
            brand.Text = MobileDGV.SelectedRows[0].Cells[1].Value.ToString();
            modele.Text = MobileDGV.SelectedRows[0].Cells[2].Value.ToString();
            price.Text = MobileDGV.SelectedRows[0].Cells[3].Value.ToString();
            stock.Text = MobileDGV.SelectedRows[0].Cells[4].Value.ToString();
            ram.Text = MobileDGV.SelectedRows[0].Cells[5].Value.ToString();
            rom.Text = MobileDGV.SelectedRows[0].Cells[6].Value.ToString();
            camera.Text = MobileDGV.SelectedRows[0].Cells[7].Value.ToString();

        }
        private void populate()
        {
            Con.Open();
            String query = "SELECT * FROM mobileTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            MobileDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(modele.Text == "" || brand.Text == "" || price.Text == "" || stock.Text == "" ||  ram.Text == "" || rom.Text == "" || camera.Text== "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    
                    string a = id.Text;
                    string b = brand.Text;
                    string c = modele.Text;
                    string d = price.Text;
                    string ef = stock.Text;
                    string f = ram.SelectedItem.ToString();
                    string g = rom.SelectedItem.ToString();
                    string h = camera.Text;

                    string sql = "INSERT INTO MobileTbl VALUES ('" +
                                 id.Text + "', '" +
                                 brand.Text + "', '" +
                                 modele.Text + "', '" +
                                 price.Text + "', '" +
                                 stock.Text + "', '" +
                                 ram.SelectedItem.ToString() + "', '" +
                                 rom.SelectedItem.ToString() + "', '" +
                                 camera.Text + "') ";


                    SqlCommand cmd = new SqlCommand(sql, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Mobile Added Succsesfully ");                    
                    Con.Close();
                    populate();
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void id_TextChanged(object sender, EventArgs e)
        {

        }
  

        private void button4_Click(object sender, EventArgs e)
        {
            id.Text="";
            brand.Text="";
            modele.Text = "";
            price.Text = "";
            stock.Text="";
            ram.Text = "";
            rom.Text = "";
            camera.Text="";
        }
        private void Mobile_Load(object sender, EventArgs e)
        {
            MobileDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            populate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (id.Text == "")
            {
                MessageBox.Show("Enter the mobile to be deleted");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "DELETE  FROM MobileTbl WHERE Mobid="+id.Text+ "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Mobile Deleted");
                    Con.Close();
                    populate();
                }
                catch(Exception Ex)
                {

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (modele.Text == "" || brand.Text == "" || price.Text == "" || stock.Text == "" || ram.Text == "" || rom.Text == "" || camera.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    /*
                    string a = id.Text;
                    string b = brand.Text;
                    string c = modele.Text;
                    string d = price.Text;
                    string ef = stock.Text;
                    string f = ram.SelectedItem.ToString();
                    string g = rom.SelectedItem.ToString();
                    string h = camera.Text;*/

                    string updateQuery = "UPDATE MobileTbl SET " +
                     "Mbrand = '" + brand.Text + "', " +
                     "MModel = '" + modele.Text + "', " +
                     "MPrice = '" + price.Text + "', " +
                     "MStock = '" + stock.Text + "', " +
                     "MRam = '" + ram.Text + "', " +
                     "MRom = '" + rom.Text+ "', " +
                     "MCam = '" + camera.Text + "' " +
                     "WHERE Mobid = '" + id.Text + "'";



                    SqlCommand cmd = new SqlCommand(updateQuery, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Mobile Updated Succsesfully ");
                    Con.Close();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }
    }
    }

