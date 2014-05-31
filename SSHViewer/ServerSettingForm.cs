using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Renci.SshNet;

namespace SSHViewer {
    public partial class ServerSettingForm : Form {
        private string configFileName = "connection.config";
        private DataTable connectionTable = new DataTable();
        private DataView connectionView;
        private enum AuthType {None, Password, PrivateKey};

        public ConnectionInfo connectionInfo;

        public ServerSettingForm() {
            InitializeComponent();

            connectionTable.Columns.Add("name", typeof(string));
            connectionTable.Columns.Add("host", typeof(string));
            connectionTable.Columns.Add("port", typeof(int));
            connectionTable.Columns.Add("user", typeof(string));
            connectionTable.Columns.Add("authtype", typeof(AuthType));
            connectionTable.Columns.Add("password", typeof(string));
            connectionTable.Columns.Add("privatekey", typeof(string));
            connectionTable.Columns.Add("passphrase", typeof(string));

            if (System.IO.File.Exists(configFileName)) {
                try {
                    XDocument x = XDocument.Load(configFileName);
                    IEnumerable<XElement> connections = 
                        from el in x.Elements() select el;
                    foreach (XElement el in x.Element("setting").Elements()) {
                        DataRow r = connectionTable.NewRow();
                        r["name"] = el.Element("name").Value;
                        r["host"] = el.Element("host").Value;
                        r["port"] = Int32.Parse(el.Element("port").Value);
                        r["user"] = el.Element("user").Value;
                        XElement authElement = el.Element("auth");
                        r["authtype"] = Int32.Parse(authElement.Element("type").Value);
                        switch ((AuthType)(r["authtype"])) {
                            case AuthType.None:
                                break;
                            case AuthType.Password:
                                r["password"] = authElement.Element("password").Value;
                                break;
                            case AuthType.PrivateKey:
                                r["privatekey"] = authElement.Element("privatekey").Value;
                                XElement passphraseElement =
                                    authElement.Element("passphrase");
                                if (passphraseElement != null) {
                                    r["passphrase"] = passphraseElement.Value;
                                }
                                break;
                        }
                        this.connectionTable.Rows.Add(r);
                    }
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message + "\r\n\r\n" + ex.StackTrace);
                }
            }
            this.connectionView  = new DataView(this.connectionTable);
            this.connectionView.Sort = "name";
            serverSettingListBox.DataSource = this.connectionView;
            serverSettingListBox.DisplayMember = "name";
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

        private void saveAsNewButton_Click(object sender, EventArgs e) {
            DataRow r = this.connectionTable.NewRow();
            r["name"] = connectionNameTextBox.Text;
            r["host"] = serverTextBox.Text;
            r["port"] = Int32.Parse(portTextBox.Text);
            r["user"] = userNameTextBox.Text;
            if (noAuthRadioButton.Checked) {
                r["authtype"] = AuthType.None;
            }
            if (passwordRadioButton.Checked) {
                r["authtype"] = AuthType.Password;
            }
            if (keyRadioButton.Checked) {
                r["authtype"] = AuthType.PrivateKey;
                r["privatekey"] = fileNameLabel.Text;
                r["passphrase"] = passphraseTextBox.Text;
            }
            this.connectionTable.Rows.Add(r);
        }

        private void ServerSettingForm_FormClosing(object sender, FormClosingEventArgs e) {
            exportSettings();
        }

        private XDocument makeSkeletom() {
            XDocument xDoc = new XDocument(
                new XDeclaration("1.0", "utf-8", "true"));
            XElement root = new XElement("setting");
            xDoc.Add(root);
            return xDoc;
        }

        private void exportSettings() {
            if (this.connectionTable.Rows.Count > 0) {
                XDocument xDoc = makeSkeletom();
                XElement root = xDoc.Element("setting");
                foreach (DataRow r in this.connectionView.ToTable().Rows) {
                    XElement connection = new XElement("connection");
                    connection.Add(
                        new XElement("name", r["name"]),
                        new XElement("host", r["host"]),
                        new XElement("port", r["port"]),
                        new XElement("user", r["user"]));
                    XElement authElement = new XElement(
                        "auth", new XElement("type", r["authtype"]));
                    switch ((AuthType)r["authtype"]) {
                        case AuthType.None:
                            break;
                        case AuthType.Password:
                            authElement.Add(
                                new XElement("password", r["password"]));
                            break;
                        case AuthType.PrivateKey:
                            authElement.Add(
                                new XElement("privatekey", r["privatekey"]));
                            authElement.Add(
                                new XElement("passphrase", r["passphrase"]));
                            break;
                    }
                    connection.Add(authElement);
                    root.Add(connection);
                }
                xDoc.Save(this.configFileName);
            }
        }

        private void serverSettingListBox_Click(object sender, EventArgs e) {
            if (serverSettingListBox.SelectedIndex > -1) {
                loadConnection(serverSettingListBox.SelectedIndex);
            }
        }

        private void loadConnection(int targetIndex) {
            DataRowView selectedRow = this.connectionView[targetIndex];
            connectionNameTextBox.Text = selectedRow["name"].ToString();
            serverTextBox.Text = selectedRow["host"].ToString();
            portTextBox.Text = selectedRow["port"].ToString();
            userNameTextBox.Text = selectedRow["user"].ToString();
            switch ((AuthType)selectedRow["authtype"]) {
                case AuthType.Password:
                    passwordRadioButton.Checked = true;
                    passwordTextBox.Text = selectedRow["password"].ToString();
                    break;
                case AuthType.PrivateKey:
                    keyRadioButton.Checked = true;
                    fileNameLabel.Text = selectedRow["privatekey"].ToString();
                    passphraseTextBox.Text = 
                        selectedRow["passphrase"].ToString();
                    break;
                default:
                    noAuthRadioButton.Checked = true;
                    break;
            }
        }

        private void saveButton_Click(object sender, EventArgs e) {
            if (serverSettingListBox.SelectedIndex > -1) {
                DataRowView selectedRow = 
                    this.connectionView[serverSettingListBox.SelectedIndex];
                selectedRow["name"] = connectionNameTextBox.Text;
                selectedRow["host"] = serverTextBox.Text;
                selectedRow["port"] = portTextBox.Text;
                selectedRow["user"] = userNameTextBox.Text;
                if (passwordRadioButton.Checked) {
                    selectedRow["authtype"] = AuthType.Password;
                    selectedRow["password"] = passwordTextBox.Text;
                } else {
                    if (keyRadioButton.Checked) {
                        selectedRow["authtype"] = AuthType.PrivateKey;
                        selectedRow["passphrase"] = passphraseTextBox.Text;
                    } else {
                        selectedRow["authtype"] = AuthType.None;
                    }
                }
            }
        }

        private void validateInput() {


        }

        private void Remove_Click(object sender, EventArgs e) {
            if (serverSettingListBox.SelectedIndex > -1) {
                this.connectionView[serverSettingListBox.SelectedIndex].Delete();
            }
        }

        private void clear() {
            connectionNameTextBox.Clear();
            serverTextBox.Clear();
            portTextBox.Clear();
            userNameTextBox.Clear();
            noAuthRadioButton.Checked = true;
            fileNameLabel.Text = "";
            passwordTextBox.Clear();
            passphraseTextBox.Clear();
        }
    }
}
