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
    public partial class itmes : Form
    {
        public itmes()
        {
            InitializeComponent();
            populate();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\C#\shop y\yadavbhai.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            Con.Open();
            string Query = "select * from ItemTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            Stokcgdv.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void itmes_Load(object sender, EventArgs e)
        {

        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            if(itemmtb.Text==""|| qtytb.Text==""||ptb.Text==""|| icat.SelectedIndex == -1)
            {
                MessageBox.Show("Mising Information...");
            }
            else
            {
                Con.Open();
                string Query = "insert into ItemTbl values('" + itemmtb.Text + "'," + qtytb.Text + ", " + ptb.Text + ",'" + icat.SelectedItem.ToString() + "')";
                SqlCommand cmd = new SqlCommand(Query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Item Saved Successfully.");
                Con.Close();
                populate();
                Reset();
            }
        }

        private void cleartbtn_Click(object sender, EventArgs e)
        {
            itemmtb.Text = "";
            qtytb.Text = "";
            ptb.Text = "";
            icat.SelectedIndex = -1;

        }
        int key = 0;
        private void Stokcgdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            itemmtb.Text = Stokcgdv.SelectedRows[0].Cells[1].Value.ToString();
            qtytb.Text = Stokcgdv.SelectedRows[0].Cells[2].Value.ToString();
            icat.SelectedItem = Stokcgdv.SelectedRows[0].Cells[3].Value.ToString();
            ptb.Text = Stokcgdv.SelectedRows[0].Cells[3].Value.ToString();
            if (itemmtb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(Stokcgdv.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            if (itemmtb.Text == "" || qtytb.Text == "" || ptb.Text == "" || icat.SelectedIndex == -1)
            {
                MessageBox.Show("Mising Informations");
            }
            else
            {
                Con.Open();
                string Query = "update ItemTbl set ItName='" + itemmtb.Text + "',ItQty=" + qtytb.Text + ", ItPrice=" + ptb.Text + ",ItCat='" + icat.SelectedItem.ToString() + "' where InId="+key+";";
                SqlCommand cmd = new SqlCommand(Query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Item Updated Successfully.");
                Con.Close();
                populate();
                Reset();
            }
        }
        private void Reset()
        {
            itemmtb.Text = "";
            qtytb.Text = "";
            ptb.Text = "";
            icat.SelectedIndex = -1;
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            if (itemmtb.Text == "" || qtytb.Text == "" || ptb.Text == "" || icat.SelectedIndex == -1)
            {
                MessageBox.Show("Mising Informations");
            }
            else
            {
                Con.Open();
                string Query = "delete from ItemTbl where InId=" + key + ";";
                SqlCommand cmd = new SqlCommand(Query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Item Deleted Successfully.");
                Con.Close();
                populate();
                Reset();
            }
        }
    }
}
