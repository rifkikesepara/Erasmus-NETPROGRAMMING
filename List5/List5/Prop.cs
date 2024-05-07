using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace List5
{
    public partial class Prop : Form
    {
        public string path;
        public enum FileType
        {
            Folder,File
        }
        public FileType fileType;
        public Prop()
        {
            InitializeComponent();
        }

        private long DirSize(DirectoryInfo d)
        {
            long size = 0;
            // Add file sizes.
            FileInfo[] fis = d.GetFiles();
            foreach (FileInfo fi in fis)
            {
                size += fi.Length;
            }
            // Add subdirectory sizes.
            DirectoryInfo[] dis = d.GetDirectories();
            foreach (DirectoryInfo di in dis)
            {
                size += DirSize(di);
            }
            return size;
        }

        private void Prop_Load(object sender, EventArgs e)
        {
            switch (fileType)
            {
                case FileType.Folder:
                    {
                        pictureBox1.Image = List5.Properties.Resources.folder;
                        DirectoryInfo directoryInfo= new DirectoryInfo(path);
                        fileNameLabel.Text = directoryInfo.Name;
                        sizeLabel.Text = "Size: " + (double)DirSize(directoryInfo)/100 + " kB";
                        dateLabel.Text = "Creation Date: " + directoryInfo.CreationTime;
                        extensionLabel.Text = "Extension: " + (directoryInfo.Extension == "" ? "null" : directoryInfo.Extension);
                        locationLabel.Text = "Location: " + directoryInfo.FullName;
                        break;
                    }
                case FileType.File:
                    {
                        pictureBox1.Image = List5.Properties.Resources.file;
                        FileInfo fileInfo=new FileInfo(path);
                        fileNameLabel.Text = fileInfo.Name;
                        sizeLabel.Text = "Size: " + (double)fileInfo.Length /100+ " kB";
                        dateLabel.Text = "Creation Date: " + fileInfo.CreationTime;
                        extensionLabel.Text = "Extension: " + (fileInfo.Extension == "" ? "null" : fileInfo.Extension);
                        locationLabel.Text = "Location: " + fileInfo.FullName;
                        break;
                    }
            }
        }

        private void Prop_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}
