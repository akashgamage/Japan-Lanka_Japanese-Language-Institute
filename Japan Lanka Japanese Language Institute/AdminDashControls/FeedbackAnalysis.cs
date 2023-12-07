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
    public partial class FeedbackAnalysis : UserControl
    {
        List<String> XValues1 = new List<String>();
        List<int> YValues1 = new List<int>();
        List<int> YValues1_1 = new List<int>();
        List<int> YValues1_2 = new List<int>();

        List<String> XValues2 = new List<String>();
        List<int> YValues2 = new List<int>();
        List<int> YValues2_1 = new List<int>();
        List<int> YValues2_2 = new List<int>();

        List<String> XValues3 = new List<String>();
        List<int> YValues3 = new List<int>();
        List<int> YValues3_1 = new List<int>();
        List<int> YValues3_2 = new List<int>();

        public FeedbackAnalysis()
        {
            InitializeComponent();

            XValues1.Add("N5");
            YValues1.Add(87);
            YValues1_1.Add(10);
            YValues1_2.Add(3);

            XValues1.Add("N4");
            YValues1.Add(81);
            YValues1_1.Add(15);
            YValues1_2.Add(4);

            XValues1.Add("N3");
            YValues1.Add(75);
            YValues1_1.Add(18);
            YValues1_2.Add(7);

            XValues1.Add("N2");
            YValues1.Add(80);
            YValues1_1.Add(18);
            YValues1_2.Add(2);

            XValues1.Add("N1");
            YValues1.Add(91);
            YValues1_1.Add(4);
            YValues1_2.Add(5);


            XValues2.Add("N5");
            YValues2.Add(54);
            YValues2_1.Add(4);
            YValues2_2.Add(3);

            XValues2.Add("N4");
            YValues2.Add(43);
            YValues2_1.Add(11);
            YValues2_2.Add(3);

            XValues2.Add("N3");
            YValues2.Add(60);
            YValues2_1.Add(10);
            YValues2_2.Add(3);

            XValues2.Add("N2");
            YValues2.Add(35);
            YValues2_1.Add(8);
            YValues2_2.Add(3);

            XValues2.Add("N1");
            YValues2.Add(41);
            YValues2_1.Add(3);
            YValues2_2.Add(4);


            XValues3.Add("N5");
            YValues3.Add(40);
            YValues3_1.Add(15);
            YValues3_2.Add(3);

            XValues3.Add("N4");
            YValues3.Add(69);
            YValues3_1.Add(5);
            YValues3_2.Add(3);

            XValues3.Add("N3");
            YValues3.Add(43);
            YValues3_1.Add(8);
            YValues3_2.Add(3);

            XValues3.Add("N2");
            YValues3.Add(50);
            YValues3_1.Add(12);
            YValues3_2.Add(3);

            XValues3.Add("N1");
            YValues3.Add(57);
            YValues3_1.Add(10);
            YValues3_2.Add(3);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            chart1.Series["Good"].Points.DataBindXY(XValues1, YValues1);
            chart1.Series["Normal"].Points.DataBindXY(XValues1, YValues1_1);
            chart1.Series["Bad"].Points.DataBindXY(XValues1, YValues1_2);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            chart2.Series["Good"].Points.DataBindXY(XValues2, YValues2);
            chart2.Series["Normal"].Points.DataBindXY(XValues2, YValues2_1);
            chart2.Series["Bad"].Points.DataBindXY(XValues2, YValues2_2);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            chart3.Series["Good"].Points.DataBindXY(XValues3, YValues3);
            chart3.Series["Normal"].Points.DataBindXY(XValues3, YValues3_1);
            chart3.Series["Bad"].Points.DataBindXY(XValues3, YValues3_2);
        }

        private void label36_Click(object sender, EventArgs e)
        {

        }
    }
}
