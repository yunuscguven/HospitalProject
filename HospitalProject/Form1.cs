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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace HospitalProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string connection = @"Data Source=dinm5CG2161MC2\SQLEXPRESS;Initial Catalog=HospitalDB;Integrated Security=True;Encrypt=False";
        string result, adminresult, password = "";

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                string query = "SELECT Password FROM Users WHERE Username ='" + textBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    result = reader["Password"].ToString();
                }
                else
                {
                    result = "user not found";

                }
            }
            if (result == textBox2.Text) 
            {   
                Main main = new Main();
                this.Hide();
                main.Show();
            }
            else
            {
                MessageBox.Show("Please do control of Username or Password !", "Caution");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Hide();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) {

                checkBox1.Text = "Hide";
                textBox2.PasswordChar = '\0';
            }
                
            if (checkBox1.Checked == false){

                checkBox1.Text = "Show";
                textBox2.PasswordChar = '*';
            }
                
        }
    }
}
