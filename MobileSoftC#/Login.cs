using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobileSoftC_
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text=="")
            {
                MessageBox.Show("Enter username and password");
            }
            else if(textBox1.Text == "admin" || textBox2.Text == "admin")
            {
                Home home= new Home();
                home.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong username or password");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {
            // Postavi svojstvo UseSystemPasswordChar na true
            textBox2.UseSystemPasswordChar = true;

        }
    }
}
