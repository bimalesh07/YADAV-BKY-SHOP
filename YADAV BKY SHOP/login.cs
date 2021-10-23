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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(usernametb.Text == "" || passwordtb.Text == "")
            {
                MessageBox.Show("Enter username and password.");
            }
            else if(usernametb.Text == "Admin" || passwordtb.Text == "password")
            {
                itmes i = new itmes();
                i.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wronng Username or Password");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            billing obj = new billing();
            obj.Show();
            this.Hide();
        }
    }
}
