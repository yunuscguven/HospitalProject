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
    public partial class MedicalRecords : Form
    {
        public MedicalRecords()
        {
            InitializeComponent();
        }
        string connection = @"Data Source=dinm5CG2161MC2\SQLEXPRESS;Initial Catalog=HospitalDB;Integrated Security=True;Encrypt=False";
        private void loadData()
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                string query = "SELECT * FROM MedicalRecords";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }
        private void MedicalRecords_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                string query = "INSERT INTO MedicalRecords (PatientID, Diagnosis, Treatment, Prescriptions) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
            loadData();
            MessageBox.Show("Medical Record is Saved !", "Caution");
        }
    }
}
