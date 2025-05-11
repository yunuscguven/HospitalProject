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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HospitalProject
{
    public partial class Doctor : Form
    {
        public Doctor()
        {
            InitializeComponent();
        }
        string connection = @"Data Source=dinm5CG2161MC2\SQLEXPRESS;Initial Catalog=HospitalDB;Integrated Security=True;Encrypt=False";

        private void Doctor_Load(object sender, EventArgs e)
        {

        }
        private void loadData()
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                string query = "SELECT * FROM Doctors";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                string query = "INSERT INTO Doctors (Name, Specialization, Contact, Email) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox5.Text + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
            loadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                int id = Convert.ToInt32(textBox6.Text);

                string query = "UPDATE Doctors SET Name='" + textBox1.Text + "',Specialization='" + textBox2.Text + "',Contact='" + textBox3.Text + "',Email='" + textBox5.Text + "' WHERE DoctorID='" + id + "'";
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
                int id = Convert.ToInt32(textBox6.Text);
                string query = "DELETE FROM Doctors WHERE DoctorID='" + id + "'";
                SqlCommand cmd = new SqlCommand(query, con);
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
