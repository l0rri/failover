using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ConnectionConfigurator : Form
    {
        public string ConnectionStringResult;

        public ConnectionConfigurator(string ConnectionString) : this()
        {
            previousConnString = ConnectionString;
            CSBuilder = new Npgsql.NpgsqlConnectionStringBuilder(ConnectionString);
            
        }

        private Npgsql.NpgsqlConnectionStringBuilder CSBuilder;
        private string previousConnString;
        public ConnectionConfigurator()
        {
            CSBuilder = new Npgsql.NpgsqlConnectionStringBuilder();
            InitializeComponent();
            propertyGrid1.SelectedObject = CSBuilder;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {

        }

        private void ConnectionConfigurator_Load(object sender, EventArgs e)
        {
            if (CSBuilder != null) {

                HostnameTextbox.Text = CSBuilder.Host;
                DBTextbox.Text = CSBuilder.Database;
                UsernameTextbox.Text = CSBuilder.Username;
                PasswordTextbox.Text = CSBuilder.Password;

            }
        }


        private void OKButton_Click(object sender, EventArgs e)
        {
            
            ConnectionStringResult = CSBuilder.ToString();

            Close();
        }    




        private void DBTextbox_TextChanged(object sender, EventArgs e)
        {
            CSBuilder.Database = DBTextbox.Text;

        }

        private void HostnameTextbox_TextChanged(object sender, EventArgs e)
        {
            CSBuilder.Host = HostnameTextbox.Text;
        }

        private void UsernameTextbox_TextChanged(object sender, EventArgs e)
        {
            CSBuilder.Username = UsernameTextbox.Text;
        }

        private void PasswordTextbox_TextChanged(object sender, EventArgs e)
        {
            CSBuilder.Password = PasswordTextbox.Text;
        }

        private void ConnectionConfigurator_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((previousConnString != "") && (previousConnString != null))
            {
                ConnectionStringResult = previousConnString;

            } else if ((e.CloseReason == CloseReason.None || e.CloseReason == CloseReason.UserClosing) && (ConnectionStringResult == "" || ConnectionStringResult == null)) {

                e.Cancel = true;

            }
        }
    }
}
