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
using System.IO;
using System.Net;

namespace Japan_Lanka_Japanese_Language_Institute.StaffDashControls
{
    public partial class CourseMeterials : UserControl
    {
         SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-F2O073A4\SQLEXPRESS;Initial Catalog=final4;Integrated Security=True");
         SqlCommand cmd;
        public CourseMeterials()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = -1;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog dlg = new OpenFileDialog() {Filter = "PDF Documnets(*.pdf)|*.pdf",ValidateNames = true })
            {
                if(dlg.ShowDialog() == DialogResult.OK)
                {
                    DialogResult dialog = MessageBox.Show("Do you want tO Upload this file?", "Upload File", MessageBoxButtons.YesNo , MessageBoxIcon.Question);
                    if(dialog == DialogResult.Yes)
                    {
                        String filename= dlg.FileName;
                        UploadFile();
                       
                    }
                }
                
            }
        }

        public void UploadFile()
        {
            byte[] file;
            using (Stream stream = File.OpenRead(textBox1.Text))
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    stream.CopyTo(memory);
                    file = memory.ToArray();
                }
            }
            cmd = new SqlCommand("INSERT INTO course_materials VALUES(@course_id,@material_name,@material_description,@material)", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@course_id", comboBox1.Text);
            cmd.Parameters.AddWithValue("@material_name", textBox2.Text);
            cmd.Parameters.AddWithValue("@material_description", textBox3.Text);
            cmd.Parameters.AddWithValue("@material", file);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("File Uploaded Successfully");
        }
    }
}
