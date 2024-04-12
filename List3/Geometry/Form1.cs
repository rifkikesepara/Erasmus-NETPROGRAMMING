using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Geometry
{
    public partial class Form1 : Form
    {
        public static bool Draw = false;
        public class Point
        {
            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }
    

            public int X { get; set; }
            public int Y { get; set; }

        }

        abstract class Shape
        {
            public Point[] Points { get; set; }
            public System.Drawing.Point[] GetPointsForDrawing(Panel p)
            {
                System.Drawing.Point[] temp=new System.Drawing.Point[Points.Length];

                for (int i = 0; i < Points.Length; i++)
                {
                    temp[i] = new System.Drawing.Point(p.Width / 2 - Points[i].X, p.Height / 2 + Points[i].Y);
                }

                return temp;
            }

            public abstract void Write();
            public abstract void Draw(Panel p, Graphics g);
            
        }

        class Rectangle : Shape
        {
            public Rectangle(Point p1, Point p2, Point p3, Point p4)
            {
                Points=new Point[4];

                Points[0] = p1;
                Points[1] = p2;
                Points[2] = p3;
                Points[3] = p4;
            }

            public override void Draw(Panel p,Graphics g)
            {
                g.FillPolygon(new SolidBrush(Color.FromArgb(0, Color.Black)), GetPointsForDrawing(p));
                Pen pen = new Pen(Color.DarkGreen);
                g.DrawPolygon(pen, GetPointsForDrawing(p));
            }
            public override void Write()
            {
                Console.WriteLine("Type: Rectangle");
            }
        }
        
        class Triangle : Shape
        {
            public Triangle(Point p1, Point p2, Point p3)
            {
                Points=new Point[3];

                Points[0] = p1;
                Points[1] = p2;
                Points[2] = p3;
            }

            public override void Draw(Panel p, Graphics g)
            {
               g.FillPolygon(new SolidBrush(Color.FromArgb(0, Color.Black)), GetPointsForDrawing(p));
               Pen pen = new Pen(Color.DarkGreen);
               g.DrawPolygon(pen, GetPointsForDrawing(p));
            }

            public override void Write()
            {
                Console.WriteLine("Type: Triangle");
            }
        }
        
        class Circle : Shape
        {
            public int Radius;
            public Circle(Point center, int radius)
            {
                Points=new Point[1];
                Points[0] = center;
                Radius = radius;
            }

            public override void Draw(Panel p, Graphics g)
            {
                //g.FillEllipse(new SolidBrush(Color.FromArgb(0, Color.Black)), p.Width / 2 - Points[0].X, p.Height / 2 + Points[0].Y, Radius, Radius);
                Pen pen = new Pen(Color.DarkGreen);
                g.DrawEllipse(pen, p.Width / 2 + Points[0].X-Radius/2, p.Height / 2 + Points[0].Y-Radius/2, Radius, Radius);
            }

            public override void Write()
            {
                Console.WriteLine("Type: Circle");
            }
        } 
        class Polygon : Shape
        {
            public Polygon(DataGridViewRowCollection points)
            {
                Points = new Point[points.Count-1];
                for(int i=0;i<points.Count-1;i++)
                {
                    Point temp = new Point(Convert.ToInt32(points[i].Cells[0].Value), Convert.ToInt32(points[i].Cells[1].Value));
                    Points[i] = temp;
                }
            }

            public override void Draw(Panel p, Graphics g)
            {
                g.FillPolygon(new SolidBrush(Color.FromArgb(0, Color.Black)), GetPointsForDrawing(p));
                Pen pen = new Pen(Color.DarkGreen);
                g.DrawPolygon(pen, GetPointsForDrawing(p));
            }

            public override void Write()
            {
                Console.WriteLine("Type: Polygon");
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            p1group.Visible = false;
            p2group.Visible = false;
            p3group.Visible = false;
            p4group.Visible = false;
            dataGridView1.Visible = false;
        }

        public void ResetPointGroups()
        {
            p1group.Text = "p1";
            p2group.Text = "p2";
            p2Y.Visible = true;
            dataGridView1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Refresh();

            Shape shape = null;
            switch(comboBox1.SelectedItem.ToString())
            {
                case "Triangle":shape = new Triangle(new Point((int)p1X.Value,(int)p1Y.Value),new Point((int)p2X.Value,(int)p2Y.Value),new Point((int)p3X.Value,(int)p3Y.Value));break;
                case "Rectangle":shape = new Rectangle(new Point((int)p1X.Value,(int)p1Y.Value),new Point((int)p2X.Value,(int)p2Y.Value),new Point((int)p3X.Value,(int)p3Y.Value),new Point((int)p4X.Value,(int)p4Y.Value));break;
                case "Circle":shape = new Circle(new Point((int)p1X.Value,(int)p1Y.Value),(int)p2X.Value); break;
                case "Polygon":shape = new Polygon(dataGridView1.Rows);break;
            }
            //Rectangle rect = new Rectangle(new Point(0, 0), new Point(0, 50), new Point(50, 50), new Point(50, 50));
            //Triangle rect = new Triangle(new Point(0, 0), new Point(-20, 50), new Point(20, 50));
            //Triangle rect = new Triangle(new Point(0, 0), new Point(-1, -5), new Point(1, -5));
            shape.Draw(panel1, panel1.CreateGraphics());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString()!="")
                button1.Enabled = true;
            else
                button1.Enabled = false;

            switch(comboBox1.SelectedItem.ToString())
            {
                case "Triangle":
                    ResetPointGroups();
                    p1group.Visible = true;
                    p2group.Visible = true;
                    p3group.Visible = true;
                    p4group.Visible = false;
                    break;
                case "Rectangle":
                    ResetPointGroups();
                    p1group.Visible = true;
                    p2group.Visible = true;
                    p3group.Visible = true;
                    p4group.Visible = true;
                    break;
                case "Circle":
                    p1group.Text = "Center";
                    p2group.Text = "Radius";
                    p2Y.Visible = false;
                    p1group.Visible = true;
                    p2group.Visible = true;
                    p3group.Visible = false;
                    p4group.Visible = false;
                    break;
                case "Polygon":
                    p1group.Visible = false;
                    p2group.Visible = false;
                    p3group.Visible = false;
                    p4group.Visible = false;
                    dataGridView1.Visible = true;
                    break ;
            }
        }
    }
}
