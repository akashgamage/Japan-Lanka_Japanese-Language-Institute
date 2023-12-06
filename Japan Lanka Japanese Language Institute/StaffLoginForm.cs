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
    public partial class StaffLoginForm : Form
    {
        public StaffLoginForm()
        {
            InitializeComponent();
        }

        private void label_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label_Exit_MouseEnter(object sender, EventArgs e)
        {
            label_Exit.ForeColor = Color.Red;
        }

        private void label_Exit_MouseLeave(object sender, EventArgs e)
        {
            label_Exit.ForeColor = Color.DarkBlue;
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

        private void label_Back_MouseEnter(object sender, EventArgs e)
        {
            label_Back.ForeColor = Color.DeepPink;
        }

        private void label_Back_MouseLeave(object sender, EventArgs e)
        {
            label_Back.ForeColor = Color.DarkBlue;
        }

        private void Button_StaffLogin_Click(object sender, EventArgs e)
        {
            StaffDashboard ss=new StaffDashboard();
            ss.Show();
        }

        private void Button_StaffLogin_Click_1(object sender, EventArgs e)
        {
            if (TextBox_StaffID.Text == "")
            {                 MessageBox.Show("Please enter your Staff ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                           TextBox_StaffID.Focus();
                           return;
                       }
            else if(TextBox_StaffPassword.Text == "")
            {
                MessageBox.Show("Please enter your Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TextBox_StaffPassword.Focus();
                return;
            }
            else
            {
                try
                {
                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-FETG8PP;Initial Catalog=JapanLanka;Integrated Security=True");
                    SqlCommand cmd =  new SqlCommand("select * from Staff where stid=@stid and password=@password", con);
                    cmd.Parameters.AddWithValue("@stid", TextBox_StaffID.Text);
                    cmd.Parameters.AddWithValue("@password", TextBox_StaffPassword.Text);
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
            }
            
            /*StaffDashboard ss = new StaffDashboard();
            ss.Show();
            this.Hide();*/
        }

        private void label4_Click(object sender, EventArgs e)
        {
            // Create an instance of the StartingForm
            StartingForm startingForm = new StartingForm();

            // Show the StartingForm
            startingForm.Show();

            // Close or hide the current form as needed
            this.Close(); // or this.Hide() if you want to hide it
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            label4.ForeColor = Color.DeepPink;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.ForeColor = Color.DarkBlue;
        }
    }
}
