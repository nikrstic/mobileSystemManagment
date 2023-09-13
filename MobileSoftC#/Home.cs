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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           Mobile mobile= new Mobile();
            mobile.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Accessoires accessoires= new Accessoires();
            accessoires.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Selling selling = new Selling();
            selling.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();

        }
    }
}
