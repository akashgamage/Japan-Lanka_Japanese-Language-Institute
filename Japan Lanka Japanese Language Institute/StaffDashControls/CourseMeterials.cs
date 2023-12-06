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
         SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-FETG8PP;Initial Catalog=JapanLanka;Integrated Security=True");
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

  
    

        private void button2_Click(object sender, EventArgs e)
        {

            /*using (OpenFileDialog dlg = new OpenFileDialog() { Filter = "PDF Documnets(*.pdf)|*.pdf", ValidateNames = true })
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    DialogResult dialog = MessageBox.Show("Do you want tO Upload this file?", "Upload File", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == DialogResult.Yes)
                    {
                        String filename = dlg.FileName;
                        UploadFile();

                    }
                }

            }*/

        }

        private void button3_Click(object sender, EventArgs e)
        {

           /* using (OpenFileDialog dlg = new OpenFileDialog() { Filter = "PDF Documnets(*.pdf)|*.pdf", ValidateNames = true })
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    DialogResult dialog = MessageBox.Show("Do you want tO Upload this file?", "Upload File", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == DialogResult.Yes)
                    {
                        String filename = dlg.FileName;
                        UploadFile();

                    }
                }

            }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog() { Filter = "PDF Documnets(*.pdf)|*.pdf", ValidateNames = true })
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    DialogResult dialog = MessageBox.Show("Do you want tO Upload this file?", "Upload File", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == DialogResult.Yes)
                    {
                        String filename = dlg.FileName;
                        UploadFile(filename);

                    }
                }

            }
        }

        public void UploadFile(string file)
        {
            con.Open();
            FileStream fs = File.OpenRead(file);
            byte[] contents = new byte[fs.Length];
            fs.Read(contents, 0, (int)fs.Length);
            fs.Close();

            using (SqlCommand cmd = new SqlCommand("INSERT INTO course_material(course_type,documents,recording,past_papers) VALUES(@course_type,@material_doc,@material_rec,@material_pp)", con))
            {
                cmd.Parameters.AddWithValue("@course_type", comboBox1.Text);
                cmd.Parameters.AddWithValue("@material_doc", file);
                cmd.Parameters.AddWithValue("@material_rec", textBox2.Text);
               
                cmd.Parameters.AddWithValue("@material_pp", textBox3.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Saved");
                con.Close();
            }



            
            
            
            
            /*byte[] file;
            using (Stream stream = File.OpenRead(textBox1.Text))
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    stream.CopyTo(memory);
                    file = memory.ToArray();
                }
            }
            cmd.Parameters.AddWithValue("@material", file);
           
            MessageBox.Show("File Uploaded Successfully");*/
        }

        private void button5_Click(object sender, EventArgs e)
        {
           /* try
            {
                con.Open();
                cmd = new SqlCommand("insert into course_materials values(@course_id,@material_name,@material)", con);
                cmd.Parameters.AddWithValue("@course_id", comboBox1.Text);
                cmd.Parameters.AddWithValue("@material_name", textBox2.Text);
                
                UploadFile();

                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Saved");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/

        }
    }
}
