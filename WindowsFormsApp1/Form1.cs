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
        private string connString;
        public Form1()
        {
            InitializeComponent();
            addStates();
        }

        private string buildConnString()
        {
            if (connString == null) {

                var configdialog = new ConnectionConfigurator();
                configdialog.ShowDialog();

                connString = configdialog.ConnectionStringResult;

            }

            return connString;
        }

        public void addStates()
        {
            using (var conn = new NpgsqlConnection(buildConnString()))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT DISTINCT state FROM yelp_business ORDER BY state";
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
                    cmd.CommandText = "SELECT DISTINCT city FROM yelp_business WHERE state='" + bState.SelectedItem.ToString() + "' ORDER BY city";
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

        public void addZipcodes(String selectedCity)
        {
            bZip.Items.Clear();
            using (var conn = new NpgsqlConnection(buildConnString()))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT DISTINCT postal_code FROM yelp_business WHERE city='" + bCity.SelectedItem.ToString() + "' ORDER BY postal_code";
                    using (var reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            bZip.Items.Add(reader.GetString(0));
                        }
                    }
                }
                conn.Close();
            }
        }

        public void addCategories(String selectedZip) //Change this
        {
            bCategory.Items.Clear();
            using (var conn = new NpgsqlConnection(buildConnString()))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT DISTINCT category_name FROM yelp_business_categories,yelp_business WHERE yelp_business.business_id=yelp_business_categories.business_id AND postal_code='" + bZip.SelectedItem.ToString() + "'ORDER BY category_name"; //hmmm
                    using (var reader = cmd.ExecuteReader())
                    {
                        //We may need another loop?
                        while (reader.Read())
                        {
                            bCategory.Items.Add(reader.GetString(0));
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
                bZip.Items.Clear();
                addZipcodes(bCity.SelectedItem.ToString());

            }
        }

        private void bZip_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (this.bZip.SelectedIndex > -1)
            {
                bCategory.Items.Clear();
                addCategories(bZip.SelectedItem.ToString());

            }
        }

        private void bCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.bCategory.SelectedIndex > -1)
            {
                //clear previous contents
                dataGridView1.Rows.Clear();
                using (var conn = new NpgsqlConnection(buildConnString()))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT name FROM yelp_business_categories, yelp_business WHERE yelp_business.business_id = yelp_business_categories.business_id AND postal_code='" + bZip.SelectedItem.ToString() + "' AND category_name='" + bCategory.SelectedItem.ToString() + "'"; //this too
                        using (var reader = cmd.ExecuteReader())
                        {            
                            while (reader.Read())
                            {

                                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                                row.Cells[0].Value = reader.GetString(0);
                                row.Cells[1].Value = bState.SelectedItem.ToString();
                                row.Cells[2].Value = bCity.SelectedItem.ToString();
                                row.Cells[3].Value = bZip.SelectedItem.ToString();
                                row.Cells[4].Value = bCategory.SelectedItem.ToString();
                                dataGridView1.Rows.Add(row);
                            }
                        }
                    }
                    conn.Close();
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var configdialog = new ConnectionConfigurator(connString);
            configdialog.ShowDialog();

            connString = configdialog.ConnectionStringResult;
        }

    }
}
