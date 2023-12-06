using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Globalization;

namespace Japan_Lanka_Japanese_Language_Institute.StaffDashControls
{
    
    public partial class Course : UserControl
    {
        string selectedgender;
        string al; 
        public Course()
        {
            InitializeComponent();
        }
        private void Course_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            comboBox1.SelectedIndex = -1;
            textBox2.Clear();
            checkBox1.Checked = false;
            checkBox2.Checked = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog Open = new OpenFileDialog();
            Open.Filter = "Image Files(*.jpg;*.jpeg;*.gif;*.bmp;*.png;)|*.jpeg;*.gif;*.bpm;*.png;";
            if(Open.ShowDialog() == DialogResult.OK) 
            {
                textBox7.Text = Open.FileName;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                selectedgender = "Male";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                selectedgender = "Female";
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                al = "Yes";
            }
            else
            {
                al = "No";
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                al = "NO";
            }
            else
            {
                al = "No";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String fullname = textBox1.Text;
            String dob = dateTimePicker1.Text;
            String Age = textBox3.Text;
            String address = textBox4.Text;
            String email = textBox5.Text;
            String nic = textBox6.Text;
            String classes = comboBox1.Text;
            string alvel = al;
            String gender = selectedgender;
            String intake = comboBox2.Text;
            String ambassador = textBox2.Text;



            DateTime parsedDate;

            if (DateTime.TryParseExact(dob, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
            {
                
            }
            else
            {
             
            }


            
            string connectionString = "Data Source=DESKTOP-FETG8PP;Initial Catalog=JapanLanka;Integrated Security=True";
            string insertQuery = "insert into course (full_name,dob,age,gender,address,email,nic,class,al_exam,intake,ambassad_name) values (@Fullname,@DOB,@AGE,@Gender,@Address,@Email,@NIC,@Classes,@ALvel,@Intake,@Ambassador)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@Fullname", fullname);
                    cmd.Parameters.AddWithValue("@DOB", dob);
                    cmd.Parameters.AddWithValue("@Age", Age);
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@NIC", nic);
                    cmd.Parameters.AddWithValue("@Classes", classes);
                    cmd.Parameters.AddWithValue("@ALvel", alvel);
                    cmd.Parameters.AddWithValue("@Intake", intake);
                    cmd.Parameters.AddWithValue("@Ambassador", ambassador);


                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Data inserted successfully.");
                        MessageBox.Show("Data Insert Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        Console.WriteLine("Data insertion failed.");
                        MessageBox.Show("Data inserted Unsuccessfully");
                    }

                }
            }



        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
