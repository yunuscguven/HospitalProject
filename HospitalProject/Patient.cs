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
    public partial class Patient : Form
    {
        public Patient()
        {
            InitializeComponent();
        }

        private void Patient_Load(object sender, EventArgs e)
        {

        }
        string connection = @"Data Source=dinm5CG2161MC2\SQLEXPRESS;Initial Catalog=HospitalDB;Integrated Security=True;Encrypt=False";
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void loadData()
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                string query = "SELECT * FROM Patients";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int age = Convert.ToInt32(textBox2.Text);

            using(SqlConnection con= new SqlConnection(connection))
            {
                string query = "INSERT INTO Patients (Name, Gender, Age, Contact, Address, Email) VALUES('" + textBox1.Text + "','" + comboBox1.Text + "','" + age + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
            loadData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                int id=Convert.ToInt32(textBox6.Text);
                string query = "DELETE FROM Patients WHERE PatientID='" + id + "'";
                SqlCommand cmd= new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            loadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection con= new SqlConnection(connection))
            {
                int age=Convert.ToInt32(textBox2.Text), id=Convert.ToInt32(textBox6.Text);

                string query = "UPDATE Patients SET Name='" + textBox1.Text + "',Gender='" + comboBox1.Text + "',Age='" + age + "',Contact='" + textBox3.Text + "',Address='" + textBox4.Text + "',Email='" + textBox5.Text + "' WHERE PatientID='" + id + "'";
                SqlCommand cmd= new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            loadData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
