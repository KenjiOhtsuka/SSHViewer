namespace SSHViewer {
    partial class ServerSettingForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.serverSettingListBox = new System.Windows.Forms.ListBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.saveAsNewButton = new System.Windows.Forms.Button();
            this.serverTextBox = new System.Windows.Forms.TextBox();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.passphraseTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.openFileDialogButton = new System.Windows.Forms.Button();
            this.fileNameLabel = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.passwordRadioButton = new System.Windows.Forms.RadioButton();
            this.keyRadioButton = new System.Windows.Forms.RadioButton();
            this.noAuthRadioButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.userNameTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // serverSettingListBox
            // 
            this.serverSettingListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.serverSettingListBox.FormattingEnabled = true;
            this.serverSettingListBox.ItemHeight = 12;
            this.serverSettingListBox.Location = new System.Drawing.Point(12, 12);
            this.serverSettingListBox.Name = "serverSettingListBox";
            this.serverSettingListBox.Size = new System.Drawing.Size(238, 280);
            this.serverSettingListBox.TabIndex = 0;
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(444, 299);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(75, 23);
            this.connectButton.TabIndex = 1;
            this.connectButton.Text = "&Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // saveAsNewButton
            // 
            this.saveAsNewButton.Location = new System.Drawing.Point(12, 298);
            this.saveAsNewButton.Name = "saveAsNewButton";
            this.saveAsNewButton.Size = new System.Drawing.Size(103, 23);
            this.saveAsNewButton.TabIndex = 2;
            this.saveAsNewButton.Text = "Save as &New";
            this.saveAsNewButton.UseVisualStyleBackColor = true;
            this.saveAsNewButton.Click += new System.EventHandler(this.saveAsNewButton_Click);
            // 
            // serverTextBox
            // 
            this.serverTextBox.Location = new System.Drawing.Point(297, 12);
            this.serverTextBox.Name = "serverTextBox";
            this.serverTextBox.Size = new System.Drawing.Size(147, 19);
            this.serverTextBox.TabIndex = 3;
            // 
            // portTextBox
            // 
            this.portTextBox.Location = new System.Drawing.Point(297, 37);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(50, 19);
            this.portTextBox.TabIndex = 4;
            this.portTextBox.Text = "22";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.passphraseTextBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.openFileDialogButton);
            this.groupBox1.Controls.Add(this.fileNameLabel);
            this.groupBox1.Controls.Add(this.passwordTextBox);
            this.groupBox1.Controls.Add(this.passwordRadioButton);
            this.groupBox1.Controls.Add(this.keyRadioButton);
            this.groupBox1.Controls.Add(this.noAuthRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(256, 93);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(263, 199);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Authentication";
            // 
            // passphraseTextBox
            // 
            this.passphraseTextBox.Location = new System.Drawing.Point(21, 119);
            this.passphraseTextBox.Name = "passphraseTextBox";
            this.passphraseTextBox.PasswordChar = '*';
            this.passphraseTextBox.Size = new System.Drawing.Size(205, 19);
            this.passphraseTextBox.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "PassPhrase";
            // 
            // openFileDialogButton
            // 
            this.openFileDialogButton.Location = new System.Drawing.Point(232, 79);
            this.openFileDialogButton.Name = "openFileDialogButton";
            this.openFileDialogButton.Size = new System.Drawing.Size(23, 23);
            this.openFileDialogButton.TabIndex = 6;
            this.openFileDialogButton.Text = "...";
            this.openFileDialogButton.UseVisualStyleBackColor = true;
            this.openFileDialogButton.Click += new System.EventHandler(this.openFileDialogButton_Click);
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fileNameLabel.Location = new System.Drawing.Point(21, 81);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(205, 18);
            this.fileNameLabel.TabIndex = 5;
            this.fileNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(82, 39);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(166, 19);
            this.passwordTextBox.TabIndex = 4;
            // 
            // passwordRadioButton
            // 
            this.passwordRadioButton.AutoSize = true;
            this.passwordRadioButton.Location = new System.Drawing.Point(6, 40);
            this.passwordRadioButton.Name = "passwordRadioButton";
            this.passwordRadioButton.Size = new System.Drawing.Size(72, 16);
            this.passwordRadioButton.TabIndex = 2;
            this.passwordRadioButton.TabStop = true;
            this.passwordRadioButton.Text = "Password";
            this.passwordRadioButton.UseVisualStyleBackColor = true;
            // 
            // keyRadioButton
            // 
            this.keyRadioButton.AutoSize = true;
            this.keyRadioButton.Location = new System.Drawing.Point(6, 62);
            this.keyRadioButton.Name = "keyRadioButton";
            this.keyRadioButton.Size = new System.Drawing.Size(78, 16);
            this.keyRadioButton.TabIndex = 1;
            this.keyRadioButton.TabStop = true;
            this.keyRadioButton.Text = "PrivateKey";
            this.keyRadioButton.UseVisualStyleBackColor = true;
            // 
            // noAuthRadioButton
            // 
            this.noAuthRadioButton.AutoSize = true;
            this.noAuthRadioButton.Checked = true;
            this.noAuthRadioButton.Location = new System.Drawing.Point(6, 18);
            this.noAuthRadioButton.Name = "noAuthRadioButton";
            this.noAuthRadioButton.Size = new System.Drawing.Size(115, 16);
            this.noAuthRadioButton.TabIndex = 0;
            this.noAuthRadioButton.TabStop = true;
            this.noAuthRadioButton.Text = "No Authentication";
            this.noAuthRadioButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(256, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "サーバ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(256, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "ポート";
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.Location = new System.Drawing.Point(297, 62);
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.Size = new System.Drawing.Size(147, 19);
            this.userNameTextBox.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(256, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "ユーザ";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(256, 298);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 10;
            this.saveButton.Text = "&Save";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "ssh key|*.pem";
            // 
            // ServerSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 334);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.userNameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.portTextBox);
            this.Controls.Add(this.serverTextBox);
            this.Controls.Add(this.saveAsNewButton);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.serverSettingListBox);
            this.Name = "ServerSettingForm";
            this.Text = "ServerSettingForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ServerSettingForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox serverSettingListBox;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Button saveAsNewButton;
        private System.Windows.Forms.TextBox serverTextBox;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.RadioButton passwordRadioButton;
        private System.Windows.Forms.RadioButton keyRadioButton;
        private System.Windows.Forms.RadioButton noAuthRadioButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox userNameTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button openFileDialogButton;
        private System.Windows.Forms.Label fileNameLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox passphraseTextBox;
        private System.Windows.Forms.Label label4;
    }
}