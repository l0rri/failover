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
            return "Host=localhost; Username=postgres; Password=12345; Database = postgres";
        }

        public void addStates()
        {
            using (var conn = new NpgsqlConnection(buildConnString()))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT DISTINCT b_state FROM business ORDER BY b_state";
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

        public void addCities(String selectedState)
        {
            bCity.Items.Clear();
            using (var conn = new NpgsqlConnection(buildConnString()))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT DISTINCT b_city FROM business WHERE b_state='" + bState.SelectedItem.ToString() + "' ORDER BY b_city";
                    using (var reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            bCity.Items.Add(reader.GetString(0));
                        }
                    }
                }
                conn.Close();
            }
        }

        private void bState_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (this.bState.SelectedIndex > -1)
            {
                bCity.Items.Clear();
                addCities(bState.SelectedItem.ToString());
               
            }
        }

        private void bCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.bCity.SelectedIndex > -1)
            {
                //clear previous contents
                dataGridView1.Rows.Clear();
                using (var conn = new NpgsqlConnection(buildConnString()))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT b_name FROM business WHERE b_state ='" + bState.SelectedItem.ToString() + "' AND b_city='" + bCity.SelectedItem.ToString() + "'";
                        using (var reader = cmd.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                            
                                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                                row.Cells[0].Value = reader.GetString(0);
                                row.Cells[1].Value = bState.SelectedItem.ToString();
                                row.Cells[2].Value = bCity.SelectedItem.ToString();
                                dataGridView1.Rows.Add(row);
                            }
                        }
                    }
                    conn.Close();
                }
            }
        }
    }
}
