namespace WindowsFormsApp1
{
    partial class ConnectionConfigurator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CancelButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.SettingsModeTabs = new System.Windows.Forms.TabControl();
            this.BasicTab = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.HostnameTextbox = new System.Windows.Forms.TextBox();
            this.DBTextbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.UsernameTextbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PasswordTextbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.AdvancedTab = new System.Windows.Forms.TabPage();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.SettingsModeTabs.SuspendLayout();
            this.BasicTab.SuspendLayout();
            this.panel1.SuspendLayout();
            this.AdvancedTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(412, 8);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 0;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OKButton.Location = new System.Drawing.Point(331, 8);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 1;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(283, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Specify PostgreSQL connection settings, then press \"OK\".";
            // 
            // SettingsModeTabs
            // 
            this.SettingsModeTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SettingsModeTabs.Controls.Add(this.BasicTab);
            this.SettingsModeTabs.Controls.Add(this.AdvancedTab);
            this.SettingsModeTabs.Location = new System.Drawing.Point(16, 37);
            this.SettingsModeTabs.Name = "SettingsModeTabs";
            this.SettingsModeTabs.SelectedIndex = 0;
            this.SettingsModeTabs.Size = new System.Drawing.Size(471, 182);
            this.SettingsModeTabs.TabIndex = 9;
            // 
            // BasicTab
            // 
            this.BasicTab.Controls.Add(this.panel1);
            this.BasicTab.Location = new System.Drawing.Point(4, 22);
            this.BasicTab.Name = "BasicTab";
            this.BasicTab.Padding = new System.Windows.Forms.Padding(3);
            this.BasicTab.Size = new System.Drawing.Size(463, 156);
            this.BasicTab.TabIndex = 0;
            this.BasicTab.Text = "Basic";
            this.BasicTab.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.HostnameTextbox);
            this.panel1.Controls.Add(this.DBTextbox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.UsernameTextbox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.PasswordTextbox);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(457, 150);
            this.panel1.TabIndex = 0;
            // 
            // HostnameTextbox
            // 
            this.HostnameTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HostnameTextbox.Location = new System.Drawing.Point(65, 3);
            this.HostnameTextbox.Name = "HostnameTextbox";
            this.HostnameTextbox.Size = new System.Drawing.Size(389, 20);
            this.HostnameTextbox.TabIndex = 4;
            this.HostnameTextbox.TextChanged += new System.EventHandler(this.HostnameTextbox_TextChanged);
            // 
            // DBTextbox
            // 
            this.DBTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DBTextbox.Location = new System.Drawing.Point(65, 29);
            this.DBTextbox.Name = "DBTextbox";
            this.DBTextbox.Size = new System.Drawing.Size(389, 20);
            this.DBTextbox.TabIndex = 5;
            this.DBTextbox.TextChanged += new System.EventHandler(this.DBTextbox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Password:";
            // 
            // UsernameTextbox
            // 
            this.UsernameTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UsernameTextbox.Location = new System.Drawing.Point(65, 55);
            this.UsernameTextbox.Name = "UsernameTextbox";
            this.UsernameTextbox.Size = new System.Drawing.Size(389, 20);
            this.UsernameTextbox.TabIndex = 6;
            this.UsernameTextbox.TextChanged += new System.EventHandler(this.UsernameTextbox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Username:";
            // 
            // PasswordTextbox
            // 
            this.PasswordTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PasswordTextbox.Location = new System.Drawing.Point(65, 81);
            this.PasswordTextbox.Name = "PasswordTextbox";
            this.PasswordTextbox.Size = new System.Drawing.Size(389, 20);
            this.PasswordTextbox.TabIndex = 7;
            this.PasswordTextbox.UseSystemPasswordChar = true;
            this.PasswordTextbox.TextChanged += new System.EventHandler(this.PasswordTextbox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Database:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Host:";
            // 
            // AdvancedTab
            // 
            this.AdvancedTab.Controls.Add(this.propertyGrid1);
            this.AdvancedTab.Location = new System.Drawing.Point(4, 22);
            this.AdvancedTab.Name = "AdvancedTab";
            this.AdvancedTab.Padding = new System.Windows.Forms.Padding(3);
            this.AdvancedTab.Size = new System.Drawing.Size(463, 156);
            this.AdvancedTab.TabIndex = 1;
            this.AdvancedTab.Text = "Advanced";
            this.AdvancedTab.UseVisualStyleBackColor = true;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyGrid1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.propertyGrid1.Location = new System.Drawing.Point(3, 3);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(457, 150);
            this.propertyGrid1.TabIndex = 0;
            // 
            // ConnectionConfigurator
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 231);
            this.Controls.Add(this.SettingsModeTabs);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.CancelButton);
            this.KeyPreview = true;
            this.Name = "ConnectionConfigurator";
            this.Text = "PostgreSQL Connection Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConnectionConfigurator_FormClosing);
            this.Load += new System.EventHandler(this.ConnectionConfigurator_Load);
            this.SettingsModeTabs.ResumeLayout(false);
            this.BasicTab.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.AdvancedTab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabControl SettingsModeTabs;
        private System.Windows.Forms.TabPage BasicTab;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox HostnameTextbox;
        private System.Windows.Forms.TextBox DBTextbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox UsernameTextbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox PasswordTextbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage AdvancedTab;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
    }
}