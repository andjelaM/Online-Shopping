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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        


        MySqlConnection con = new MySqlConnection("server = localhost; database = online_kupovina;  username = root; password=; SSL Mode = None");
        public void button1_Click(object sender, EventArgs e)
        {  
            string username, password;   
            username = txtuser.Text;
            password = txtpass.Text;           
            con.Open();
            try
            {       
                string s = "select * from users where username =  '" + username + "' ";
                MySqlCommand cmd = new MySqlCommand(s, con);
                MySqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    rd.Read();
                    if (rd[2].ToString().Equals(password))
                    { 
                        Main main = new Main();
                        main.Show();
                        this.Hide();
                    }
                    else MessageBox.Show("Check your username or password!");
                }
                else MessageBox.Show("Check your username or password!!");
                if (username == "" && password == "")
                {
                    label4.Text = "Please enter username and password!";
                }
                else if (username.Length >= 50 && password.Length >= 50)
                {
                    label4.Text = "maximum character number:50. Try again.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Register registracija = new Register();
            registracija.Show();
            this.Hide();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void txtuser_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
