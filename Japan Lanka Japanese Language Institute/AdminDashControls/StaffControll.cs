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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Japan_Lanka_Japanese_Language_Institute.AdminDashControls
{
    public partial class StaffControll : UserControl
    {
        //CONNECTION
        private string connectionString = "Data Source=DESKTOP-FETG8PP;Initial Catalog=JapanLanka;Integrated Security=True";

        public StaffControll()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //SHOW ERROR IF TEXTBOXES ARE EMPTY
            if 
                (   string.IsNullOrEmpty(textBox6.Text) || string.IsNullOrEmpty(textBox7.Text) ||
                    string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) ||
                    string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text) )
                {
                MessageBox.Show("Please enter data in all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                }

            //ELSE 

            String stid = textBox6.Text;
            String password = textBox7.Text;
            String name = textBox1.Text;
            String mobile_no = textBox2.Text;
            String address = textBox3.Text;
            String nic = textBox4.Text;

            //INSERT QUERY
            string insertQuery = "insert into staff (stid,password,name,mobile_no,address,nic) values (@STID,@PASSWORD,@NAME,@MOBILE_NO,@ADDRESS,@NIC)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@STID", stid);
                    cmd.Parameters.AddWithValue("@PASSWORD", password);
                    cmd.Parameters.AddWithValue("@NAME", name);
                    cmd.Parameters.AddWithValue("@MOBILE_NO", mobile_no);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@NIC", nic);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    //CONSOLE MESSAGE
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Data inserted successfully");
                        MessageBox.Show("Data inserted successfully");
                    }
                    else
                    {
                        Console.WriteLine("Data insertion failed");
                        MessageBox.Show("Data insertion failed");
                    }

                }
            }
            //CLEAR TEXTBOXES
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox6.Clear();
            textBox7.Clear();

            //UPDATE GRIDVIEW WHEN SUBMIT CLICKS
            UpdateDataGridView();

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            // CHECK IF STAFF ID PASSSWORD TEXTBOXES EMPTY
            if (string.IsNullOrEmpty(textBox6.Text) || string.IsNullOrEmpty(textBox7.Text))
            {
                MessageBox.Show("Please enter Staff ID and Password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // CHECK OTHER TEXTBOXES HAVE DATA
            if (!string.IsNullOrEmpty(textBox1.Text) || !string.IsNullOrEmpty(textBox2.Text) || !string.IsNullOrEmpty(textBox3.Text) || !string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Please clear the other text boxes before proceeding.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            string stid = textBox6.Text;
            string password = textBox7.Text;

            // IF DATA EXIST IN DB OR NOT
            if (DoesDataExist(stid, password))
            {
                if (DeleteData(stid))
                {
                    MessageBox.Show("Data deleted successfully");
                    UpdateDataGridView();
                }
                else
                {
                    MessageBox.Show("Data deletion failed");
                }
            }
            else
            {
                MessageBox.Show("Data not found");
            }
            //CLEAR TEXTBOXES
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox6.Clear();
            textBox7.Clear();
        }

        //CHECK DATABASE FOR DATA
        private bool DoesDataExist(string stid, string password)
        {
            string selectQuery = "SELECT stid FROM staff WHERE stid = @STID AND password = @PASSWORD";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@STID", stid);
                    cmd.Parameters.AddWithValue("@PASSWORD", password);

                    object result = cmd.ExecuteScalar();
                    return (result != null);
                }
            }
        }

        //DELETE DATA FROM DATABASE 
        private bool DeleteData(string stid)
        {
            string deleteQuery = "DELETE FROM staff WHERE stid = @STID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(deleteQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@STID", stid);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        private void StaffControll_Load_1(object sender, EventArgs e)
        {
            //UPDATE GRIDVIEW WHEN STAFF CONTROL LOADS
            UpdateDataGridView();
            
        }

        private void UpdateDataGridView()
        {
            string selectQuery = "SELECT stid, password, name, mobile_no, address, nic FROM staff";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // REVERSE ROW ORDER IN GRIDVIEW
                        DataTable reversedTable = dataTable.AsEnumerable().Reverse().CopyToDataTable();

                        dataGridView1.DataSource = reversedTable;
                    }
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
