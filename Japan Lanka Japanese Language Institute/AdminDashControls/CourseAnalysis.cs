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
using Japan_Lanka_Japanese_Language_Institute.StaffDashControls;
using static System.Windows.Forms.LinkLabel;
using System.Windows.Documents;
using System.Windows.Forms.DataVisualization.Charting;

namespace Japan_Lanka_Japanese_Language_Institute.AdminDashControls
{
    public partial class CourseAnalysis : UserControl
    {
        private string connectionString = "Data Source=DESKTOP-FETG8PP;Initial Catalog=JapanLanka;Integrated Security=True";
        public CourseAnalysis()
        {
            InitializeComponent();
        }

        void FillChartWithSelectedYearAndMonth(int selectedYear, int selectedMonth)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CalculateClassCountByYearMonth", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@SelectedYear", selectedYear);
                cmd.Parameters.AddWithValue("@SelectedMonth", selectedMonth);

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();

                chart1.Titles.Clear();

                chart1.DataSource = dt;
                chart1.Series["Enrollments"].XValueMember = "class";
                chart1.Series["Enrollments"].YValueMembers = "EnrollmentCount";

                chart1.Titles.Add("ANALYZE");
            }
        }

        private void PopulateComboBoxes()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string query = "SELECT DISTINCT YEAR(row_created_at) AS Year FROM course ORDER BY Year DESC";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                comboBox1.Items.Clear();

                while (reader.Read())
                {
                    int year = reader.GetInt32(reader.GetOrdinal("Year"));
                    comboBox1.Items.Add(year);
                }

                con.Close();
            }

            comboBox1.SelectedIndex = 0;
            UpdateComboBox2();
        }

        private void UpdateComboBox2()
        {
            comboBox2.Items.Clear();

            if (comboBox1.SelectedItem != null)
            {
                if (comboBox1.SelectedIndex >= 0)
                {
                    if (comboBox1.SelectedItem is int selectedYear)
                    {
                        using (SqlConnection con = new SqlConnection(connectionString))
                        {
                            con.Open();
                            string query = $"SELECT DISTINCT MONTH(row_created_at) AS Month FROM course WHERE YEAR(row_created_at) = {selectedYear} ORDER BY Month DESC";
                            SqlCommand cmd = new SqlCommand(query, con);
                            SqlDataReader reader = cmd.ExecuteReader();

                            while (reader.Read())
                            {
                                int month = reader.GetInt32(reader.GetOrdinal("Month"));
                                comboBox2.Items.Add(month);
                            }

                            con.Close();
                        }
                    }
                }
            }

            comboBox2.SelectedIndex = 0;
        }

        private void CourseAnalysis_Load_1(object sender, EventArgs e)
        {
            PopulateComboBoxes();

            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;

            FillChartWithSelectedYearAndMonth((int)comboBox1.SelectedItem, (int)comboBox2.SelectedItem);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateComboBox2();
            FillChartWithSelectedYearAndMonth((int)comboBox1.SelectedItem, (int)comboBox2.SelectedItem);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillChartWithSelectedYearAndMonth((int)comboBox1.SelectedItem, (int)comboBox2.SelectedItem);
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}