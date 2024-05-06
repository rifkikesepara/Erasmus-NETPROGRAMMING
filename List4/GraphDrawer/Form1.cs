using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GraphDrawer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            Series series = new Series("Function");
            chart1.Series.Add(series);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart1.Legends[0].CustomItems.Clear();

            chart1.Series[0].ChartType = SeriesChartType.Line;
            chart1.Series[0].Color = Color.Red;
            chart1.Series[0].BorderWidth = 1;
            chart1.Series[0].MarkerColor = Color.Green;
            chart1.Series[0].MarkerStyle = MarkerStyle.Circle;
            // Set function parameters (a and b)
            double a = double.Parse(textBox1.Text);
            double b = double.Parse(textBox2.Text);

            // Generate function values and add them to the series
            for (double x = -5.0; x <= 5.0; x += 1)
            {
                double y = 0.0;

                if (comboBox1.SelectedIndex == 0)
                    y = a * x * x + b;
                else
                    y = a * x + b;

                chart1.Series[0].Points.AddXY(x, y);
                LegendItem item = new LegendItem();
                item.ImageStyle = LegendImageStyle.Marker;
                item.Color = Color.Green;
                item.Name = "X: " + x + ", Y: " + y;
                chart1.Legends[0].CustomItems.Add(item);
            }

            // Add labels to axes
            chart1.ChartAreas[0].AxisX.Title = "X";
            chart1.ChartAreas[0].AxisY.Title = "Y";
        }
    }
}
