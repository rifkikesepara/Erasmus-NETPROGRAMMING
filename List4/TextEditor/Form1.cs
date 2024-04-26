using System.Diagnostics;

namespace TextEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Console.WriteLine("saaaaa");
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.ShowDialog();
            if (!File.Exists(dialog.FileName))
            {
                var file = File.Create(dialog.FileName);
                file.Close();
                richTextBox1.Visible = true;
            }

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string line = "";
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.ShowDialog();
            if (File.Exists(dialog.FileName))
            {
                StreamReader sr = new StreamReader(dialog.FileName);
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the line to console window
                    richTextBox1.Text += line + "\n";
                    //Read the next line
                    line = sr.ReadLine();
                }
                //close the file
                sr.Close();
            }

        }
    }
}
