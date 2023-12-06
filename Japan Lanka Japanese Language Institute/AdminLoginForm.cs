using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace Japan_Lanka_Japanese_Language_Institute
{
    public partial class AdminLoginForm : Form
    {
        public AdminLoginForm()
        {
            InitializeComponent();
        }

        private void label_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label_Back_Click(object sender, EventArgs e)
        {
            // Create an instance of the StartingForm
            StartingForm startingForm = new StartingForm();

            // Show the StartingForm
            startingForm.Show();

            // Close or hide the current form as needed
            this.Close(); // or this.Hide() if you want to hide it
        }

        private void label_Exit_MouseEnter(object sender, EventArgs e)
        {
            label_Exit.ForeColor = Color.Red;
        }

        private void label_Exit_MouseLeave(object sender, EventArgs e)
        {
            label_Exit.ForeColor = Color.DarkBlue;
        }

        private void label_Back_MouseEnter(object sender, EventArgs e)
        {
            label_Back.ForeColor = Color.DeepPink;
        }

        private void label_Back_MouseLeave(object sender, EventArgs e)
        {
            label_Back.ForeColor = Color.DarkBlue;
        }

        private void Button_AdminLogin_Click_1(object sender, EventArgs e)
        {
            if (TextBox_AdminID.Text == "")
            {
                MessageBox.Show("Please enter your Staff ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (TextBox_AdminPassword.Text == "")
            {
                MessageBox.Show("Please enter your Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (TextBox_AdminID.Text == "Admin" && TextBox_AdminPassword.Text == "Admin")
            {
                MessageBox.Show("Login Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AdminDashboard ss = new AdminDashboard();
                ss.Show();
                this.Hide();

                
            }

            else
            {
                MessageBox.Show("Login Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // wait for admin dashborad and admin table of databse in the project 
            /* if (TextBox_AdminID.Text == "")
            {                 MessageBox.Show("Please enter your Staff ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                           TextBox_AdminID.Focus();
                           return;
                       }
            else if(TextBox_AdminPassword.Text == "")
            {
                MessageBox.Show("Please enter your Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TextBox_AdminPassword.Focus();
                return;
            }
            else
            {
                try
                {
                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-FETG8PP;Initial Catalog=Japan_Lanka;Integrated Security=True");
                    SqlCommand cmd =  new SqlCommand("select * from Staff where stid=@stid and password=@password", con); // change admin table name from the database
                    cmd.Parameters.AddWithValue("@stid", TextBox_AdminID.Text);
                    cmd.Parameters.AddWithValue("@password", TextBox_AdminPassword.Text);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("Login Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        StaffDashboard ss = new StaffDashboard();
                        ss.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Login Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }*/

            /*AdminDashboard ss = new AdminDashboard();
            ss.Show();
            this.Hide();*/
        }
    }
}
