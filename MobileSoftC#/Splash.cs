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
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
        int startpoint = 15;
        private void Timer_Tick(object sender, EventArgs e)
        {
            startpoint += 1;
            progressBar1.Value = startpoint;
            progressBar2.Value = startpoint;
            if (progressBar1.Value == 100)
            {
                progressBar1.Value = 0;
                progressBar2.Value = 0;
                Timer.Stop();
                Login log = new Login();
                log.Show();
                this.Hide();
            }
        }
    }
}
