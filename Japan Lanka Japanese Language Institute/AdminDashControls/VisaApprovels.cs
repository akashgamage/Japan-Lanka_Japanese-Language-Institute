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
    public partial class VisaApprovels : UserControl
    {
        List<String> XValues1 = new List<String>();
        List<int> YValues1 = new List<int>();
        List<int> YValues1_1 = new List<int>();

        List<String> XValues2 = new List<String>();
        List<int> YValues2 = new List<int>();
        List<int> YValues2_1 = new List<int>();

        List<String> XValues3 = new List<String>();
        List<int> YValues3 = new List<int>();
        List<int> YValues3_1 = new List<int>();

        public VisaApprovels()
        {
            InitializeComponent();
            XValues1.Add("N5");
            YValues1.Add(48);
            YValues1_1.Add(14);

            XValues1.Add("N4");
            YValues1.Add(61);
            YValues1_1.Add(11);

            XValues1.Add("N3");
            YValues1.Add(53);
            YValues1_1.Add(7);

            XValues1.Add("N2");
            YValues1.Add(50);
            YValues1_1.Add(9);

            XValues1.Add("N1");
            YValues1.Add(45);
            YValues1_1.Add(5);


            XValues2.Add("N5");
            YValues2.Add(54);
            YValues2_1.Add(4);

            XValues2.Add("N4");
            YValues2.Add(43);
            YValues2_1.Add(11);

            XValues2.Add("N3");
            YValues2.Add(60);
            YValues2_1.Add(10);

            XValues2.Add("N2");
            YValues2.Add(35);
            YValues2_1.Add(8);

            XValues2.Add("N1");
            YValues2.Add(41);
            YValues2_1.Add(3);


            XValues3.Add("N5");
            YValues3.Add(40);
            YValues3_1.Add(15);

            XValues3.Add("N4");
            YValues3.Add(69);
            YValues3_1.Add(5);

            XValues3.Add("N3");
            YValues3.Add(43);
            YValues3_1.Add(8);

            XValues3.Add("N2");
            YValues3.Add(50);
            YValues3_1.Add(12);

            XValues3.Add("N1");
            YValues3.Add(57);
            YValues3_1.Add(10);

        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            chart1.Series["Approved"].Points.DataBindXY(XValues1, YValues1);
            chart1.Series["Rejected"].Points.DataBindXY(XValues1, YValues1_1);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            chart2.Series["Approved"].Points.DataBindXY(XValues2, YValues2);
            chart2.Series["Rejected"].Points.DataBindXY(XValues2, YValues2_1);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            chart3.Series["Approved"].Points.DataBindXY(XValues3, YValues3);
            chart3.Series["Rejected"].Points.DataBindXY(XValues3, YValues3_1);
        }

        private void chart2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
