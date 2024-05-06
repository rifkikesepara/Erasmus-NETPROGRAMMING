using System.Diagnostics;

namespace TextEditor
{
    public partial class Form1 : Form
    {
        private string? OpenedFilePath;
        private string currentWindowTitle;
        public Form1()
        {
            InitializeComponent();
            richTextBox1.Visible = false;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "New File";
            dialog.InitialDirectory = Directory.GetCurrentDirectory();
            dialog.ShowDialog();
            if (!File.Exists(dialog.FileName) && dialog.FileName != "")
            {
                var file = File.Create(dialog.FileName);
                file.Close();
                richTextBox1.Visible = true;
                richTextBox1.Text = "";
            }
            OpenedFilePath = dialog.FileName;

            this.Text = "TextEditor | File: " + dialog.FileName;
            currentWindowTitle = Text;
            richTextBox1.Visible = true;

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string line = "";
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Open File";
            dialog.InitialDirectory = Directory.GetCurrentDirectory();
            dialog.ShowDialog();
            if (File.Exists(dialog.FileName))
            {
                richTextBox1.Text = "";
                OpenedFilePath = dialog.FileName;
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
            richTextBox1.Visible = true;
            this.Text = "TextEditor | File: " + dialog.FileName;
            currentWindowTitle = Text;
        }

        private void SaveFile()
        {
            File.WriteAllText(OpenedFilePath, richTextBox1.Text);
            Text = "TextEditor | File: " + OpenedFilePath;
            Debug.WriteLine("saved");
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            Text = "TextEditor | File: " + OpenedFilePath + "*";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int index = 0;
            richTextBox1.SelectAll();
            richTextBox1.SelectionBackColor = Color.White;
            while (index < richTextBox1.Text.LastIndexOf(textBox1.Text) && textBox1.Text.Length > 1)
            {
                richTextBox1.Find(textBox1.Text, index, richTextBox1.TextLength, RichTextBoxFinds.MatchCase);
                richTextBox1.SelectionBackColor = Color.Yellow;
                index = richTextBox1.Text.IndexOf(textBox1.Text, index) + 1;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text= richTextBox1.Text.Replace(textBox1.Text,textBox2.Text);
        }
    }
}
