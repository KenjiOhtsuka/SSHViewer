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
                if (listViewItem.SubItems[1].Text == "D") {
                    cd(listViewItem.Text);
                }
            }            
        }

        private void listView1_ItemDrag(object sender, ItemDragEventArgs e) {
            //listView1.DoDragDrop((IDataObject)e.Item, DragDropEffects.Copy);
        }
        
        private void listView1_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                rightClickContextMenuStrip.Show(MousePosition);
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
                ilistViewItem.Text = sftpFile.Name;
                if (sftpFile.IsDirectory) {
                    if (sftpFile.Name == ".") continue;
                    ilistViewItem.SubItems.Add("D");
                    ilistViewItem.SubItems.Add("");
                } else {
                    if (sftpFile.IsSymbolicLink) {
                        ilistViewItem.SubItems.Add("L");
                        ilistViewItem.SubItems.Add("");
                    } else {
                        ilistViewItem.SubItems.Add("F");
                        ilistViewItem.SubItems.Add
                            (sftpFile.Length.ToString());
                    }
                }
                ilistViewItem.Tag = sftpFile;
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
            folderBrowserDialog.Description = "Choose Where To Download";
            if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                if (listView1.SelectedItems.Count > 0) {
                    ScpClient scpClient =
                        new ScpClient(this.sftpClient.ConnectionInfo);
                    scpClient.Connect();
                    SftpFile sf = (SftpFile)(listView1.SelectedItems[0].Tag);
                    if (sf.IsDirectory) {
                        scpClient.Download(sf.FullName,
                            new System.IO.DirectoryInfo(folderBrowserDialog.SelectedPath));
                    } else {
                        scpClient.Download(sf.FullName,
                            new System.IO.FileInfo(folderBrowserDialog.SelectedPath + "\\" + sf.Name));
                    }
                    scpClient.Disconnect();
                }
            }
            return true;
        }

        private void downloadStripMenuItem_Click(object sender, EventArgs e) {
            download();
        }
    }
}
