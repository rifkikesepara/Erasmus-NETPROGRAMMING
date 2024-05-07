using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace List5
{
    public partial class InspectAndEdit : Form
    {
        public string currentFile;
        public InspectAndEdit()
        {
            InitializeComponent();
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void InspectAndEdit_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = File.ReadAllText(currentFile);
        }
    }
}
