using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace online_kupovina
{
    public partial class Grocery : Form
    {

        String query;
        int current;
        int total;
        
        List<String> GroceryType = new List<String>();
        List<String> price = new List<String>();
        List<String> description = new List<String>();
        
        public Grocery(String query)
        {
            InitializeComponent();
            this.query = query;
            ExecuteQuery(query);
            if (total > 0) setWindow(0);
        }


        public void ExecuteQuery(String query)
        {
            MySqlConnection con = new MySqlConnection("server = localhost; database = online_kupovina; username = root; password =; SSL Mode = None");
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    current = 0;
                    total = 0;
                    while (dr.Read())
                    {
                        total++;                       
                        GroceryType.Add(dr[1].ToString());
                        price.Add(dr[2].ToString());
                        description.Add(dr[3].ToString());                   
                    }
                }
                else
                {
                    MessageBox.Show("Can't find that grocery!");
                    Search srch = new Search();
                    srch.Show();
                    this.Close();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void setWindow(int n)
        {           
            label3.Text = "Grocery: " + GroceryType[n];
            label4.Text = " Price: " + price[n];
            label5.Text = "Description: " + description[n];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login frm1 = new Login();
            frm1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int previous;
            if (current == 0)
            {
                previous = total - 1;
            }
            else previous = current - 1;
            setWindow(previous);
            current = previous;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int next;
            if (current == total - 1)
            {
                next = 0;
            }
            else next = current + 1;
            setWindow(next);
            current = next;
        }
    }
}
