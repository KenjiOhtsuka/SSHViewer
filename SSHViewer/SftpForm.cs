using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using Renci.SshNet;
using Renci.SshNet.Sftp;

namespace SSHViewer
{
    public partial class SftpForm : Form
    {
        private ConnectionInfo connectionInfo;
        private SftpClient sftpClient;
     
        public SftpForm(ConnectionInfo connectionInfo)
        {
            InitializeComponent();
            this.connectionInfo = connectionInfo;
            this.sftpClient = new SftpClient(this.connectionInfo);
            this.sftpClient.Connect();
            refresh();
        }

        private void listView1_DoubleClick(object sender, EventArgs e) {
            if (listView1.SelectedIndices.Count == 1) {
                ListViewItem listViewItem = listView1.SelectedItems[0];
                if (listViewItem.Text == "D") {
                    cd(listViewItem.SubItems[1].Text);
                }
            }            
        }

        private void listView1_ItemDrag(object sender, ItemDragEventArgs e) {
            //listView1.DoDragDrop((IDataObject)e.Item, DragDropEffects.Copy);
        }
        
        private void listView1_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                rightClickContextMenuStrip.Show(
                    this.Left + this.listView1.Left + e.X,
                    this.Top + this.listView1.Top + e.Y);
            }
        }

        private void refresh() {
            updateList();
            updateStatusBar();
        }

        private void cd(string target) {
            this.sftpClient.ChangeDirectory(target);
            refresh();
        }

        private void updateList() {
            IEnumerable<SftpFile> sftpFiles = 
                this.sftpClient.ListDirectory(
                this.sftpClient.WorkingDirectory);
            listView1.Items.Clear();
            foreach (SftpFile sftpFile in sftpFiles) {
                ListViewItem ilistViewItem = new ListViewItem();
                if (sftpFile.IsDirectory) {
                    if (sftpFile.Name == ".") continue;
                    ilistViewItem.Text = "D";
                    ilistViewItem.SubItems.Add(sftpFile.Name);
                    ilistViewItem.SubItems.Add("");
                } else {
                    ilistViewItem.Text = "F";
                    ilistViewItem.SubItems.Add(sftpFile.Name);
                    ilistViewItem.SubItems.Add(sftpFile.Length.ToString());
                }
                this.listView1.Items.Add(ilistViewItem);
            }
        }

        private void updateStatusBar() {
            userNameStripStatusLabel.Text = 
                this.sftpClient.ConnectionInfo.Username;
            workingDirectoryStripStatusLabel.Text =
                this.sftpClient.WorkingDirectory;
        }

        private bool download() {
            /*);
            if (true) {
                scp.Download("dir name", new System.IO.DirectoryInfo(""));
            } else {
                scp.Download("file name", new System.IO.FileInfo(""));
            }*/
        }
    }
}
