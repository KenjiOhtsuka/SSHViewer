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
    public partial class ServerSettingForm : Form {
        public ConnectionInfo connectionInfo;

        public ServerSettingForm() {
            InitializeComponent();
        }

        private void connectButton_Click(object sender, EventArgs e) {
            AuthenticationMethod am = null;
            if (noAuthRadioButton.Checked) {
                am = new KeyboardInteractiveAuthenticationMethod(userNameTextBox.Text);
            }
            if (passwordRadioButton.Checked) {
                am = new PasswordAuthenticationMethod(
                    userNameTextBox.Text, passwordTextBox.Text);
            }
            if (keyRadioButton.Checked) {
                PrivateKeyFile pkf;
                if (passphraseTextBox.Text == "") {
                    pkf = new PrivateKeyFile(fileNameLabel.Text);
                } else {
                    pkf = new PrivateKeyFile(fileNameLabel.Text, passphraseTextBox.Text);
                }
                am = new PrivateKeyAuthenticationMethod(
                    userNameTextBox.Text,
                    new PrivateKeyFile[] {pkf});
            }
            // set connection info
            this.connectionInfo = new ConnectionInfo(
                serverTextBox.Text, 
                Int32.Parse(portTextBox.Text), 
                userNameTextBox.Text, 
                new AuthenticationMethod[] {am});
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void openFileDialogButton_Click(object sender, EventArgs e) {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                fileNameLabel.Text = openFileDialog1.InitialDirectory + openFileDialog1.FileName;
            }
        }
/*        
        public override System.Windows.Forms.DialogResult ShowDialog() {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            return base.ShowDialog();
        }
 */
    }
}
