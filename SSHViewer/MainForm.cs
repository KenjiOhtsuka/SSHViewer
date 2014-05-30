using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Renci.SshNet;

namespace SSHViewer {
    public partial class MainForm : Form {
        ServerSettingForm serverSettingForm = new ServerSettingForm(); 

        public MainForm() {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            if (!connectNew()) {
                Application.Exit();
            }
        }

        private void connectNewToolStripMenuItem_Click(object sender, EventArgs e) {
            connectNew();
        }

        private bool connectNew() {
            if (serverSettingForm.ShowDialog() == DialogResult.OK) {
                addSftpTab(serverSettingForm.connectionInfo);
                return true;
            } else {
                return false;
            }
        }

        private void addSftpTab(ConnectionInfo connectionInfo) {
            TabPage t = new TabPage(connectionInfo.Host);
            SftpForm f = new SftpForm(connectionInfo);
            f.Location = new Point(10, 10);
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            f.Visible = true;
            t.Controls.Add(f);
            sftpTabControl.TabPages.Add(t);
        }
    }
}
