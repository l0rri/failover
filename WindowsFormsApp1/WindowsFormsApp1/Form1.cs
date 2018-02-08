using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            addStates();
        }

        private string buildConnString()
        {
            return "Host=localhost; Username=postgres; Password=1qazXSW@; Database = postgres";
        }

        public void addStates()
        {
            using (var conn = new NpgsqlConnection(buildConnString()))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT distinct b_state FROM business ORDER BY b_state";
                    using (var reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            bState.Items.Add(reader.GetString(0));
                        }
                    }
                }
                conn.Close();
            }
        }


        private void bState_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var conn = new NpgsqlConnection(buildConnString()))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT b_name,b_state FROM business WHERE b_state ='" + bState.SelectedItem.ToString() + "';";
                    using (var reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            bState.Items.Add(reader.GetString(0));
                        }
                    }
                }
                conn.Close();
            }
        }
    }
   }
