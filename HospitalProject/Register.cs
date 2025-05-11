using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalProject
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        string connection = @"Data Source=dinm5CG2161MC2\SQLEXPRESS;Initial Catalog=HospitalDB;Integrated Security=True;Encrypt=False";
        private void Registercs_Load(object sender, EventArgs e)
        {

        }
        bool pcheck = false;
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text==textBox3.Text)
            {
                pcheck = true;
            }
            else
            {
                MessageBox.Show("Not same 'Passwords' !", "Caution");
            }

            if (pcheck==true)
            {
                using (SqlConnection con = new SqlConnection(connection))
                {
                    string query = "INSERT INTO USERS (Username, Password, Role) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("User Registered !", "Info");
            }
            else
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 main = new Form1();
            main.Show();
            this.Hide();
        }
    }
}
