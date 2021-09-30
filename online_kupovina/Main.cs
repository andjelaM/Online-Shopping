using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;




namespace online_kupovina
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            setGroceryType();
                   

        }
        public void setGroceryType()
        {
            MySqlConnection con = new MySqlConnection("server = localhost; database = online_kupovina; username = root; password =; SSL Mode = None");
            try
            {
                con.Open();
                String query = "SELECT DISTINCT grocery FROM groceries";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cmbItems.Items.Add(dr[0].ToString());
                }
                dr.Close();

            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally { con.Close(); }

        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblPrice_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBill_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbItems_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Login frm1 = new Login();
            frm1.Show();
            this.Hide();
        }
   

        MySqlConnection con = new MySqlConnection("server = localhost; database = online_kupovina; username = root; password =; SSL Mode = None");
        protected void button2_Click(object sender, EventArgs e)
        {
            string grocery, qty;
            qty = txtQty.Text;
            grocery = cmbItems.Text;
            con.Open();
            MySqlCommand comm = new MySqlCommand("select * from groceries where grocery =  '" + grocery + "' ", con);
            MySqlDataReader srd = comm.ExecuteReader();
            while (srd.Read()) {
                txtPrice.Text = srd.GetValue(2).ToString();
                int value = int.Parse(txtPrice.Text);
                if (!(grocery == "" || qty== ""))
                {
                    int q = int.Parse(txtQty.Text);
                    textBox3.Text = (value * q).ToString();
                }                             
            }
            con.Close();           
            grocery = cmbItems.Text;
            if (grocery == "" || qty == "")
            {
                MessageBox.Show("You have to enter both quantity and grocery!");
            }
            else
            {                   
                ListViewItem item = new ListViewItem(cmbItems.Text);
                item.SubItems.Add(txtQty.Text);
                item.SubItems.Add(txtPrice.Text);
                item.SubItems.Add(textBox3.Text);
                listView1.Items.Add(item); 
            }
            int totalBill = 0;
            for (int i = 0; i < listView1.Items.Count; i++)
            {                
                totalBill += int.Parse(listView1.Items[i].SubItems[3].Text);
                textBill.Text = totalBill.ToString();          
            }           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Your bill is: "+ textBill.Text + "  Thank you!");
            listView1.Items.Clear();
            textBill.Text = "0.0";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int newTotal = int.Parse(textBill.Text);
            foreach (ListViewItem item in listView1.SelectedItems) {
                listView1.Items.Remove(item);
                newTotal-= int.Parse(item.SubItems[3].Text);

            }
            textBill.Text = newTotal.ToString();
            


        }

        private void button6_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            textBill.Text = "0.0";
        }

        

        

        private void Main_Load(object sender, EventArgs e)
        {
            textBill.Text = "0.0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Search srch = new Search();
            srch.Show();
            this.Hide();
        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
