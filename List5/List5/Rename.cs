using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace List5
{
    public partial class Rename : Form
    {
        public enum State
        {
            CreateFile,CreateFolder,Rename
        }

        public State state;
        public string currentFileName;
        public string currentPath;
        public Rename()
        {
            InitializeComponent();
        }

        private void Rename_Load(object sender, EventArgs e)
        {
            if (state == State.Rename)
                textBox1.Text = currentFileName;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape) {
                Close();
            }
            else if(e.KeyCode == Keys.Return)
            {
                var ins = Form1.Instance;
                switch (state)
                {
                    case State.Rename:
                        {
                            FileInfo fileInfo = new FileInfo(Path.Combine(currentPath, currentFileName));

                            if ((fileInfo.Attributes & FileAttributes.Directory) == FileAttributes.Directory)
                            {
                                Directory.Move(Path.Combine(currentPath, currentFileName), Path.Combine(currentPath, textBox1.Text));
                            }
                            else
                            {
                                File.Move(Path.Combine(currentPath, currentFileName), Path.Combine(currentPath, textBox1.Text));
                            }
                            Close();
                            break;
                        }
                    case State.CreateFile:
                        {
                            File.Create(Path.Combine(currentPath, textBox1.Text)).Close();
                            Close();
                            break;
                        }
                    case State.CreateFolder:
                        {
                            Directory.CreateDirectory(Path.Combine(currentPath, textBox1.Text));
                            Close();
                            break;
                        }
                }
            }
        }
    }
}
