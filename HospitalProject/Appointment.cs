using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HospitalProject
{
    public partial class Appointment : Form
    {
        public Appointment()
        {
            InitializeComponent();
        }
        string connectionString = @"Data Source=dinm5CG2161MC2\SQLEXPRESS;Initial Catalog=HospitalDB;Integrated Security=True;Encrypt=False";
        string time = "";
        private void Appointment_Load(object sender, EventArgs e)
        {
            string query = "SELECT Name FROM Doctors";
            textBox2.Text = "For Appointmetns Notes ..";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        comboBox1.Items.Add(reader["Name"].ToString());
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }
        int doctorid;
        private void doctorsearch()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT DoctorID FROM Doctors WHERE Name ='" + comboBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    doctorid =Convert.ToInt32( reader["DoctorID"].ToString());
                }
                else
                {
                    doctorid = -1;

                }
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            DateTime secilenTarih = monthCalendar1.SelectionStart.Date;

            int randevuSayisi = 0;
            string query = "SELECT COUNT(*) FROM Appointments WHERE CAST([Date] AS DATE) = @Date";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Date", secilenTarih);

                connection.Open();
                randevuSayisi = (int)command.ExecuteScalar();
            }

            if (randevuSayisi >= 5)
            {
                MessageBox.Show("Bu tarihte maksimum randevuya ulaşıldı. Lütfen başka bir gün seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // for do control maximum can take appointments day "max 5 to 1 day"
            }
            else
            {
                doctorsearch();
                string date = monthCalendar1.SelectionStart.ToString("yyyy-MM-dd");
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query2 = "INSERT INTO Appointments (PatientID, DoctorID, Date, Time, Notes) VALUES('" + textBox1.Text + "','" + doctorid + "','" + date + "','" + time + "','" + textBox2.Text + "')";
                    SqlCommand cmd = new SqlCommand(query2, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                }
                MessageBox.Show("Appointments Created, Date is : "+date+" "+time, "Successfull");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            time = button1.Text;
            button1.BackColor = Color.Green;
            button2.BackColor = Color.White;
            button3.BackColor = Color.White;
            button4.BackColor = Color.White;
            button5.BackColor = Color.White;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            time=button2.Text;
            button1.BackColor = Color.White;
            button2.BackColor = Color.Green;
            button3.BackColor = Color.White;
            button4.BackColor = Color.White;
            button5.BackColor = Color.White;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            time=button3.Text;
            button1.BackColor = Color.White;
            button2.BackColor = Color.White;
            button3.BackColor = Color.Green;
            button4.BackColor = Color.White;
            button5.BackColor = Color.White;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            time = button4.Text;
            button1.BackColor = Color.White;
            button2.BackColor = Color.White;
            button3.BackColor = Color.White;
            button4.BackColor = Color.Green;
            button5.BackColor = Color.White;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            time = button5.Text;
            button1.BackColor = Color.White;
            button2.BackColor = Color.White;
            button3.BackColor = Color.White;
            button4.BackColor = Color.White;
            button5.BackColor = Color.Green;
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }
        
    }
}
