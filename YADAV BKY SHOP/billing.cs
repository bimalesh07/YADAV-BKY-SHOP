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

namespace YADAV_BKY_SHOP
{
    public partial class billing : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\C#\shop y\yadavbhai.mdf;Integrated Security=True;Connect Timeout=30");

        public billing()
        {
            InitializeComponent();
            populate();
        }

        private void billing_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (itemtb.Text == "" || Qtytb.Text == "" || ptb.Text == "" || icat.Text == "")
            {

            }
        }
        private void populate()
        {
            Con.Open();
            string Query = "select * from ItemTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            itemsgdv.DataSource = ds.Tables[0];
            Con.Close();
        }
        int key = 0;
        private void itemsgdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            itemtb.Text = itemsgdv.SelectedRows[0].Cells[1].Value.ToString();
            Qtytb.Text = itemsgdv.SelectedRows[0].Cells[2].Value.ToString();
            // = itemsgdv.SelectedRows[0].Cells[3].Value.ToString();
            ptb.Text = itemsgdv.SelectedRows[0].Cells[3].Value.ToString();
            if (itemtb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(itemsgdv.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void itemmtb_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
