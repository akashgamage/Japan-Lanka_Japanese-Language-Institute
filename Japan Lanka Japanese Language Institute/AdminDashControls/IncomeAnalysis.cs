using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Japan_Lanka_Japanese_Language_Institute.AdminDashControls
{
    public partial class IncomeAnalysis : UserControl
    {
        List<String> XValues1 = new List<String>();
        List<int> YValues1 = new List<int>();

        List<String> XValues2 = new List<String>();
        List<int> YValues2 = new List<int>();

        List<String> XValues3 = new List<String>();
        List<int> YValues3 = new List<int>();

        public IncomeAnalysis()
        {
            InitializeComponent();
            XValues1.Add("N5");
            YValues1.Add(48);

            XValues1.Add("N4");
            YValues1.Add(61);

            XValues1.Add("N3");
            YValues1.Add(53);

            XValues1.Add("N2");
            YValues1.Add(50);

            XValues1.Add("N1");
            YValues1.Add(45);


            XValues2.Add("N5");
            YValues2.Add(54);

            XValues2.Add("N4");
            YValues2.Add(43);

            XValues2.Add("N3");
            YValues2.Add(60);

            XValues2.Add("N2");
            YValues2.Add(35);

            XValues2.Add("N1");
            YValues2.Add(41);


            XValues3.Add("N5");
            YValues3.Add(40);

            XValues3.Add("N4");
            YValues3.Add(69);

            XValues3.Add("N3");
            YValues3.Add(43);

            XValues3.Add("N2");
            YValues3.Add(50);

            XValues3.Add("N1");
            YValues3.Add(57);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            chart1.Series["Income"].Points.DataBindXY(XValues1, YValues1);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            chart2.Series["Enrollments"].Points.DataBindXY(XValues2, YValues2);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            chart3.Series["Enrollments"].Points.DataBindXY(XValues3, YValues3);
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
