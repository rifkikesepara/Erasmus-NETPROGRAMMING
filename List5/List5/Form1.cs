using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace List5
{

    public partial class Form1 : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        static extern uint SendMessage(IntPtr hWnd, uint Msg, uint wParam, uint lParam);

        private List<ListViewItem> leftItems = new List<ListViewItem>();
        private List<ListViewItem> rightItems = new List<ListViewItem>();

        public static Form1 Instance;
        private string currentPathLeft;
        private string currentPathRight;
        private bool leftDir = false;
        public Form1()
        {
            Instance = this;
            InitializeComponent();
            InitializeFileManager();
            RenameLabels();
            InitDiskProgressBar();
        }


        private void InitDiskProgressBar()
        {
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady && drive.Name == "C:\\")
                {
                    Debug.WriteLine(drive.TotalSize);
                    progressBar1.Maximum = (int)(drive.TotalSize / 10000);
                    progressBar1.Value = (int)((drive.TotalSize - drive.TotalFreeSpace) / 10000);
                    label3.Text = "C:\\   Size: " + (float)(drive.TotalSize - drive.TotalFreeSpace) / 1000000000 + " GB/" + (float)drive.TotalSize / 1000000000+" GB";
                }
            }
            SendMessage(progressBar1.Handle,
              0x400 + 16, //WM_USER + PBM_SETSTATE
              0x0002, //PBST_ERROR
              0);

        }
        private void InitializeFileManager()
        {
            // Set initial paths for left and right panels
            currentPathLeft = @"C:\Repos\Erasmus-NETPROGRAMMING\List5\List5\directory1";
            currentPathRight = @"C:\Repos\Erasmus-NETPROGRAMMING\List5\List5\directory2";


            // Populate the panels with directory contents
            PopulatePanel(leftListView, currentPathLeft);
            PopulatePanel(rightListView, currentPathRight);
        }

        private bool IsDirectory(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            if ((fileInfo.Attributes & FileAttributes.Directory) == FileAttributes.Directory) return true;
            else return false;
        }

        private void RenameLabels()
        {
            label1.Text = Path.GetFullPath(currentPathLeft);
            label2.Text = Path.GetFullPath(currentPathRight);
        }

        private void PopulatePanel(System.Windows.Forms.ListView listView, string path)
        {
            listView.Items.Clear();
            RenameLabels();
            if (listView.Name == "leftListView") leftItems.Clear();
            else rightItems.Clear();
            try
            {
                foreach (var directory in Directory.GetDirectories(path))
                {
                    FileInfo fileInfo = new FileInfo(directory);
                    var item = new ListViewItem(new[] { fileInfo.Name, "<DIR>",fileInfo.CreationTime.ToString()});
                    item.ImageIndex = 0; // Set folder icon index
                    listView.Items.Add(item);

                    if (listView.Name == "leftListView") leftItems.Add(item);
                    else rightItems.Add(item);
                }
                foreach (var file in Directory.GetFiles(path))
                {
                    FileInfo fileInfo = new FileInfo(file);
                    var item = new ListViewItem(new[] { fileInfo.Name, fileInfo.Length.ToString(),fileInfo.CreationTime.ToString(),fileInfo.FullName.ToString() });
                    item.ImageIndex = 1; // Set file icon index
                    listView.Items.Add(item);

                    if (listView.Name == "leftListView") leftItems.Add(item);
                    else rightItems.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading directory: {ex.Message}");
            }

        }

        private void leftListView_DoubleClick(object sender, EventArgs e)
        {
            FileInfo fileInfo = new FileInfo(Path.Combine(currentPathLeft, leftListView.SelectedItems[0].Text));
            var selectedItem = leftListView.SelectedItems[0];
            if (selectedItem.SubItems[1].Text == "<DIR>")
            {
                currentPathLeft = Path.Combine(currentPathLeft, selectedItem.Text);
                PopulatePanel(leftListView, currentPathLeft);
            }
            else if(fileInfo.Extension==".txt")
            {
                InspectAndEdit inspectAndEdit = new InspectAndEdit();
                inspectAndEdit.currentFile = selectedItem.SubItems[3].Text;
                inspectAndEdit.ShowDialog();
            }
        }

        private void rightListView_DoubleClick(object sender, EventArgs e)
        {
            FileInfo fileInfo = new FileInfo(Path.Combine(currentPathLeft, rightListView.SelectedItems[0].Text));
            var selectedItem = rightListView.SelectedItems[0];
            if (selectedItem.SubItems[1].Text == "<DIR>")
            {
                currentPathRight = Path.Combine(currentPathRight, selectedItem.Text);
                PopulatePanel(rightListView, currentPathRight);
            }
            else if (fileInfo.Extension == ".txt")
            {
                InspectAndEdit inspectAndEdit = new InspectAndEdit();
                inspectAndEdit.currentFile = Path.Combine(currentPathRight, selectedItem.Text);
                inspectAndEdit.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            currentPathLeft = Path.Combine(currentPathLeft, "..");
            RenameLabels();
            PopulatePanel(leftListView, currentPathLeft);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (rightListView.SelectedItems.Count > 0)
            {
                Rename rename = new Rename();
                rename.currentFileName = rightListView.SelectedItems[0].Text;
                rename.currentPath = currentPathRight;
                rename.state = Rename.State.Rename;
                rename.ShowDialog();
                PopulatePanel(rightListView, currentPathRight);
            }
            else
                MessageBox.Show("You must select a file to rename it!", "A file is not selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (leftListView.SelectedItems.Count > 0)
            {
                Rename rename = new Rename();
                rename.currentFileName = leftListView.SelectedItems[0].Text;
                rename.currentPath = currentPathLeft;
                rename.state = Rename.State.Rename;
                rename.ShowDialog();
                PopulatePanel(leftListView, currentPathLeft);
            }
            else
                MessageBox.Show("You must select a file to rename it!", "A file is not selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in leftListView.SelectedItems)
            {
                if (IsDirectory(Path.Combine(currentPathLeft, item.Text)))
                    Directory.Delete(Path.Combine(currentPathLeft, item.Text), true);
                else
                    File.Delete(Path.Combine(currentPathLeft, item.Text));

            }
            PopulatePanel(leftListView, currentPathLeft);
        }

        private void denemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rename rename = new Rename();
            rename.state = Rename.State.CreateFile;

            if (leftDir)
            {
                rename.currentPath = currentPathLeft;
                rename.ShowDialog();
                PopulatePanel(leftListView, currentPathLeft);
            }
            else
            {
                rename.currentPath = currentPathRight;
                rename.ShowDialog();
                PopulatePanel(rightListView, currentPathRight);
            }


        }

        private void folderToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Rename rename = new Rename();
            rename.state = Rename.State.CreateFolder;

            if (leftDir)
            {
                rename.currentPath = currentPathLeft;
                rename.ShowDialog();
                PopulatePanel(leftListView, currentPathLeft);
            }
            else
            {
                rename.currentPath = currentPathRight;
                rename.ShowDialog();
                PopulatePanel(rightListView, currentPathRight);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Point ptLowerLeft = new Point(0, button7.Height);
            ptLowerLeft = button7.PointToScreen(ptLowerLeft);
            contextMenuStrip1.Show(ptLowerLeft);
            leftDir = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in rightListView.SelectedItems)
            {
                if (IsDirectory(Path.Combine(currentPathRight, item.Text)))
                    Directory.Delete(Path.Combine(currentPathRight, item.Text),true);
                else
                    File.Delete(Path.Combine(currentPathRight, item.Text));

            }
            PopulatePanel(rightListView, currentPathRight);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Point ptLowerLeft = new Point(0, button3.Height);
            ptLowerLeft = button3.PointToScreen(ptLowerLeft);
            contextMenuStrip1.Show(ptLowerLeft);
            leftDir = false;
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            currentPathRight = Path.Combine(currentPathRight, "..");
            RenameLabels();
            PopulatePanel(rightListView, currentPathRight);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in leftListView.SelectedItems)
            {
                if (IsDirectory(Path.Combine(currentPathLeft, item.Text)))
                    Directory.Move(Path.Combine(Path.GetFullPath(currentPathLeft), item.Text), Path.Combine(Path.GetFullPath(currentPathRight), item.Text));
                else
                    File.Move(Path.Combine(Path.GetFullPath(currentPathLeft), item.Text), Path.Combine(Path.GetFullPath(currentPathRight), item.Text));
            }
            PopulatePanel(leftListView, currentPathLeft);
            PopulatePanel(rightListView, currentPathRight);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in rightListView.SelectedItems)
            {
                if (IsDirectory(Path.Combine(currentPathRight, item.Text)))
                    Directory.Move(Path.Combine(Path.GetFullPath(currentPathRight), item.Text), Path.Combine(Path.GetFullPath(currentPathLeft), item.Text));
                else
                    File.Move(Path.Combine(Path.GetFullPath(currentPathRight), item.Text), Path.Combine(Path.GetFullPath(currentPathLeft), item.Text));
            }
            PopulatePanel(leftListView, currentPathLeft);
            PopulatePanel(rightListView, currentPathRight);
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Prop prop = new Prop();
            if (leftListView.SelectedItems.Count > 0&&leftDir)
            {
                prop.path = Path.Combine(currentPathLeft, leftListView.SelectedItems[0].Text);
                if (IsDirectory(Path.Combine(currentPathLeft, leftListView.SelectedItems[0].Text)))
                    prop.fileType = Prop.FileType.Folder;
                else
                    prop.fileType = Prop.FileType.File;
            }
            else if(rightListView.SelectedItems.Count>0&&!leftDir)
            {
                prop.path = Path.Combine(currentPathRight, rightListView.SelectedItems[0].Text);
                if (IsDirectory(Path.Combine(currentPathRight, rightListView.SelectedItems[0].Text)))
                    prop.fileType = Prop.FileType.Folder;
                else
                    prop.fileType = Prop.FileType.File;
            }
            else if(leftDir)
            {
                prop.path = currentPathLeft;
                prop.fileType = Prop.FileType.Folder;
            }
            else if(!leftDir)
            {
                prop.path = currentPathRight;
                prop.fileType = Prop.FileType.Folder;
            }

            prop.ShowDialog();
        }

        private void leftListView_Enter(object sender, EventArgs e)
        {
            leftDir = true;
        }

        private void rightListView_Enter(object sender, EventArgs e)
        {
            leftDir = false;
        }

        private void revealİnFileExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath="";
            if (leftListView.SelectedItems.Count > 0 && leftDir)
            {
                filePath = Path.Combine(currentPathLeft, leftListView.SelectedItems[0].Text);
            }
            else if (rightListView.SelectedItems.Count > 0 && !leftDir)
            {
                filePath = Path.Combine(currentPathRight, rightListView.SelectedItems[0].Text);
            }
            else if (leftDir)
            {
                filePath = currentPathLeft;
            }
            else if (!leftDir)
            {
                filePath = currentPathRight;
            }
            string argument = "/select, \"" + filePath + "\"";
            System.Diagnostics.Process.Start("explorer.exe", argument);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            leftListView.Items.Clear();
            if (textBox1.Text=="")
            {
                leftListView.Items.AddRange(leftItems.ToArray());
            }
            else if (!checkBox1.Checked)
            {
                foreach (var item in Directory.GetFiles(currentPathLeft, "*.*", SearchOption.AllDirectories))
                {
                    FileInfo fileInfo = new FileInfo(item);
                    if (fileInfo.Name.ToLower().Contains(textBox1.Text.ToLower()))
                    {
                        ListViewItem listViewItem = new ListViewItem(new[] { fileInfo.Name, fileInfo.Length.ToString(), fileInfo.CreationTime.ToString(),fileInfo.FullName });
                        listViewItem.ImageIndex = 1;
                        leftListView.Items.Add(listViewItem);
                    }
                }
            }
            else
            {
                foreach (var item in Directory.GetFiles(currentPathLeft, "*.*", SearchOption.AllDirectories))
                {
                    FileInfo fileInfo = new FileInfo(item);
                    if (fileInfo.Extension == ".txt")
                    {
                        if(File.ReadAllText(fileInfo.FullName).ToLower().Contains(textBox1.Text.ToLower()))
                        {
                            ListViewItem listViewItem = new ListViewItem(new[] { fileInfo.Name, fileInfo.Length.ToString(), fileInfo.CreationTime.ToString(), fileInfo.FullName });
                            listViewItem.ImageIndex = 1;
                            leftListView.Items.Add(listViewItem);
                        }
                    }
                }

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            rightListView.Items.Clear();
            if (textBox2.Text == "")
            {
                rightListView.Items.AddRange(rightItems.ToArray());
            }
            else if (!checkBox2.Checked)
            {
                foreach (var item in Directory.GetFiles(currentPathRight, "*.*", SearchOption.AllDirectories))
                {
                    FileInfo fileInfo = new FileInfo(item);
                    if (fileInfo.Name.ToLower().Contains(textBox2.Text.ToLower()))
                    {
                        ListViewItem listViewItem = new ListViewItem(new[] { fileInfo.Name, fileInfo.Length.ToString(), fileInfo.CreationTime.ToString(), fileInfo.FullName });
                        listViewItem.ImageIndex = 1;
                        rightListView.Items.Add(listViewItem);
                    }
                }
            }
            else
            {
                foreach (var item in Directory.GetFiles(currentPathRight, "*.*", SearchOption.AllDirectories))
                {
                    FileInfo fileInfo = new FileInfo(item);
                    if (fileInfo.Extension == ".txt")
                    {
                        if (File.ReadAllText(fileInfo.FullName).ToLower().Contains(textBox2.Text.ToLower()))
                        {
                            ListViewItem listViewItem = new ListViewItem(new[] { fileInfo.Name, fileInfo.Length.ToString(), fileInfo.CreationTime.ToString(), fileInfo.FullName });
                            listViewItem.ImageIndex = 1;
                            rightListView.Items.Add(listViewItem);
                        }
                    }
                }

            }
        }

        private void SearchContent()
        {

        }
    }
}
