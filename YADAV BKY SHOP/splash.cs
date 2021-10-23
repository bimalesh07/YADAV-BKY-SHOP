using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YADAV_BKY_SHOP
{
    public partial class splash : Form
    {
        public splash()
        {
            InitializeComponent();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void splash_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void guna2ProgressBar1_ValueChanged(object sender, EventArgs e)
        {

        }
        int startpoint = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startpoint += 1;
            Myprogres.Value = startpoint;
            lblload.Text = startpoint + "%";
            if (startpoint == 100)
            {
                Myprogres.Value = 0;
                
                this.Hide();
                timer1.Stop();
                login l = new login();
                l.Show();
            }
        }
    }
}
