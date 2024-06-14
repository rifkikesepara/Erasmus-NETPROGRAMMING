using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace CarDealership
{
    public partial class Main : Form
    {
        public List<Car> CarCollection = new List<Car>();

        public abstract class Car
        {
            //public Car(string brand,string model,string year)
            //{
            //    Brand = brand;
            //    Model = model;
            //    YearOfProduticon = year;
            //}

            public string Brand;
            public string Model;
            public string YearOfProduticon;
            protected string Type;

            public virtual void Write()
            {
                Console.WriteLine("Brand: " + Brand + "\n" + "Model: " + Model + "\n" + "Year Of Production: " + YearOfProduticon);
            }
        }

        public class Sports:Car
        {
            public Sports(string brand,string model,string year)
            {
                Brand = brand;
                Model = model;
                YearOfProduticon = year;
                Type = "Sports";
            }

            public override void Write()
            {
                Console.WriteLine("Brand: " + Brand + "\n" + "Model: " + Model + "\n" + "Year Of Production: " + YearOfProduticon + "\nType: " + Type);
            }
        }
        
        public class Family:Car
        {
            public Family(string brand,string model,string year)
            {
                Brand = brand;
                Model = model;
                YearOfProduticon = year;
                Type = "Family";
            }

            public override void Write()
            {
                Console.WriteLine("Brand: " + Brand + "\n" + "Model: " + Model + "\n" + "Year Of Production: " + YearOfProduticon + "\nType: " + Type);
            }
        }
        
        public class OffRoad:Car
        {
            public OffRoad(string brand,string model,string year)
            {
                Brand = brand;
                Model = model;
                YearOfProduticon = year;
                Type = "OffRoad";
            }

            public override void Write()
            {
                Console.WriteLine("Brand: " + Brand + "\n" + "Model: " + Model + "\n" + "Year Of Production: " + YearOfProduticon + "\nType: " + Type);
            }
        }

        public void InitDatabase()
        {
            var carDatabase = File.ReadAllText("database.txt");

            string model = "", year = "", brand = "";
            string temp = "";
            for (int i = 0; i < carDatabase.Length; i++)
            {
                if (carDatabase[i] != ',' && carDatabase[i] != '\n')
                    temp += carDatabase[i];
                else if (carDatabase[i] == ',')
                {
                    if (brand == "")
                    {
                        brand = temp; temp = "";
                    }
                    else if (model == "")
                    {
                        model = temp; temp = "";
                    }
                }
                else if (carDatabase[i] == '\n')
                {
                    year = temp;
                    int index = dataGridView1.Rows.Add();
                    dataGridView1.Rows[index].Cells[0].Value = brand.ToUpper();
                    dataGridView1.Rows[index].Cells[1].Value = model.ToUpper();
                    dataGridView1.Rows[index].Cells[2].Value = year;
                    model = ""; year = ""; brand = ""; temp = "";
                }
            }
        }

        public Main()
        {
            InitializeComponent();
            InitDatabase();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Car car = null;
            switch(comboBox1.SelectedItem.ToString())
            {
                case "Sports": car = new Sports(textBox1.Text, textBox2.Text, textBox3.Text);break;
                case "Family":car = new Family(textBox1.Text, textBox2.Text, textBox3.Text);break;
                case "Off-Road":car = new OffRoad(textBox1.Text, textBox2.Text, textBox3.Text);break;
            }
             
            CarCollection.Add(car);

            int index = dataGridView1.Rows.Add();
            dataGridView1.Rows[index].Cells[0].Value = car.Brand.ToUpper();
            dataGridView1.Rows[index].Cells[1].Value = car.Model.ToUpper();
            dataGridView1.Rows[index].Cells[2].Value = car.YearOfProduticon;

            var lines = File.ReadAllText("database.txt");
            lines += (car.Brand + "," + car.Model + "," + car.YearOfProduticon + "\n");
            //Console.WriteLine("test");
            car.Write();
            File.WriteAllText("database.txt", lines);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            //making input just numberic
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void SaveDatabase()
        {
            string lines = "";
            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
                lines += dataGridView1.Rows[i].Cells[0].Value;
                lines += "," + dataGridView1.Rows[i].Cells[1].Value;
                lines += "," + dataGridView1.Rows[i].Cells[2].Value + "\n";
            }

            File.WriteAllText("database.txt",lines);
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveDatabase();
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            if (searchBox.Text == "") { dataGridView1.Rows.Clear(); InitDatabase(); }
            else
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells.Count > 0 && row.Index != dataGridView1.Rows.Count - 1)
                    {
                        if (!row.Cells[0].Value.ToString().Contains(searchBox.Text.ToUpper()))
                            dataGridView1.Rows.Remove(row);
                    }
                }
            }
        }

        

        private void dataGridView1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            SaveDatabase();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
