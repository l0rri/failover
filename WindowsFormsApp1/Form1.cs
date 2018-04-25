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
using System.Windows.Controls.DataVisualization;
using System.Windows.Forms.DataVisualization.Charting;



namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private string connString;

        public Form1()
        {
            InitializeComponent();
            addStates();
            //adduid();
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

        public void adduid()
        {
            using (var conn = new NpgsqlConnection(buildConnString()))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "select distinct user_id from yelp_user where name='"+uname.Text.ToString() +"' order by user_id";
                    using (var reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            listBox1.Items.Add(reader.GetString(0));
                        }
                    }
                }
                conn.Close();
            }
        }

        private void clearTopFrame()
        {
            uname.Clear();
            uinfo_name.Clear();
            uinfo_fans.Clear();
            uinfo_stars.Clear();
            uinfo_ys.Clear();
            uvote_cool.Clear();
            uvote_funny.Clear();
            uvote_useful.Clear();

        }

        private void popTopFrame()
        {
            using (var conn = new NpgsqlConnection(buildConnString()))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT name, avg(stars),fans,yelping_since,sum(funny),sum(useful),sum(cool) FROM yelp_user,yelp_review WHERE yelp_user.user_id = yelp_review.user_id and yelp_user.user_id='" + listBox1.SelectedItem.ToString() + "' GROUP BY name,fans,yelping_since";
                    //SELECT name, sum(stars),fans,yelping_since,sum(funny),sum(useful),sum(cool) FROM yelp_user,yelp_review WHERE yelp_user.user_id='--2HUmLkcNHZp0xw6AMBPg' GROUP BY name,fans,yelping_since

                    using (var reader = cmd.ExecuteReader())
                    {
                        reader.Read();                       
                        uinfo_name.Text = reader.GetString(0);
                        uinfo_stars.Text = reader.GetString(1);
                        uinfo_fans.Text = reader.GetString(2);
                        uinfo_ys.Text = reader.GetDate(3).ToString();
                        uvote_funny.Text = reader.GetString(4);
                        uvote_useful.Text = reader.GetString(5);
                        uvote_cool.Text = reader.GetString(6);

                    }
                }
                conn.Close();
            }
        }

        private void popFriendFrame()
        {
            //clear previous contents
            dataGridView2.Rows.Clear();
            using (var conn = new NpgsqlConnection(buildConnString()))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    //select name, avg(stars),yelping_since from yelp_user,yelp_review where yelp_user.user_id = yelp_review.user_id and yelp_user.user_id=(select distinct friend_id from yelp_friends where user_id ='--2HUmLkcNHZp0xw6AMBPg') group by name,yelping_since
                    cmd.CommandText = "select name, avg(stars),yelping_since from yelp_user,yelp_review where yelp_user.user_id = yelp_review.user_id and yelp_user.user_id in (select distinct friend_id from yelp_friends where user_id='" + listBox1.SelectedItem.ToString() + "') group by name,yelping_since"; //this too
                    using (var reader = cmd.ExecuteReader())
                    {
                        dataGridView2.RowTemplate.CreateCells(dataGridView2);
                        while (reader.Read())
                        {
                            DataGridViewRow row = (DataGridViewRow)dataGridView2.RowTemplate.Clone();
                            row.Cells[0].Value = reader.GetString(0);
                            row.Cells[1].Value = reader.GetString(1);
                            row.Cells[2].Value = reader.GetDate(2).ToString();

                            dataGridView2.Rows.Add(row);
                        }
                    }
                }
                conn.Close();
            }
        }

        private void popFriendReviewFrame()
        {
            //clear previous contents
            dataGridView3.Rows.Clear();
            using (var conn = new NpgsqlConnection(buildConnString()))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    //select name, avg(stars),yelping_since from yelp_user,yelp_review where yelp_user.user_id = yelp_review.user_id and yelp_user.user_id=(select distinct friend_id from yelp_friends where user_id ='--2HUmLkcNHZp0xw6AMBPg') group by name,yelping_since
                    cmd.CommandText = "select yelp_user.name,yelp_business.name, city, text from yelp_user,yelp_review,yelp_business where yelp_user.user_id = yelp_review.user_id and yelp_review.business_id = yelp_business.business_id and yelp_user.user_id in (select friend_id from yelp_friends where user_id= '" + listBox1.SelectedItem.ToString() + "') ORDER BY yelp_user.name"; //this too
                    using (var reader = cmd.ExecuteReader())
                    {
                        dataGridView3.RowTemplate.CreateCells(dataGridView3);
                        while (reader.Read())
                        {
                            DataGridViewRow row = (DataGridViewRow)dataGridView3.RowTemplate.Clone();
                            row.Cells[0].Value = reader.GetString(0);
                            row.Cells[1].Value = reader.GetString(1);
                            row.Cells[2].Value = reader.GetString(2);
                            row.Cells[3].Value = reader.GetString(3);

                            dataGridView3.Rows.Add(row);
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

        public void addCategories(String selectedZip) 
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
                        cmd.CommandText = "SELECT name, address, yelp_business.business_id FROM yelp_business_categories, yelp_business WHERE yelp_business.business_id = yelp_business_categories.business_id AND postal_code='" + bZip.SelectedItem.ToString() + "' AND category_name='" + bCategory.SelectedItem.ToString() + "'"; //this too
                        using (var reader = cmd.ExecuteReader())
                        {
                            dataGridView1.RowTemplate.CreateCells(dataGridView1);            
                            while (reader.Read())
                            {
                                DataGridViewRow row = (DataGridViewRow)dataGridView1.RowTemplate.Clone();
                                row.Cells[0].Value = reader.GetString(0);
                                row.Cells[1].Value = reader.GetString(1);
                                row.Cells[2].Value = bState.SelectedItem.ToString();
                                row.Cells[3].Value = bCity.SelectedItem.ToString();
                                row.Cells[4].Value = bZip.SelectedItem.ToString();
                                row.Cells[5].Value = bCategory.SelectedItem.ToString();
                                row.Cells[6].Value = reader.GetString(2);
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //clear previous contents
            dataGridView1.Rows.Clear();
            using (var conn = new NpgsqlConnection(buildConnString()))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT name, address, yelp_business.business_id FROM yelp_business_categories, yelp_business, yelp_business_hours WHERE yelp_business.business_id = yelp_business_categories.business_id AND postal_code='" + bZip.SelectedItem.ToString() + "' AND category_name='" + bCategory.SelectedItem.ToString() + "' AND day_of_week='"+ comboBox2.SelectedItem.ToString()  +"'"; //this too
                    using (var reader = cmd.ExecuteReader())
                    {
                        dataGridView1.RowTemplate.CreateCells(dataGridView1);
                        while (reader.Read())
                        {
                            DataGridViewRow row = (DataGridViewRow)dataGridView1.RowTemplate.Clone();
                            row.Cells[0].Value = reader.GetString(0);
                            row.Cells[1].Value = reader.GetString(1);
                            row.Cells[2].Value = bState.SelectedItem.ToString();
                            row.Cells[3].Value = bCity.SelectedItem.ToString();
                            row.Cells[4].Value = bZip.SelectedItem.ToString();
                            row.Cells[5].Value = bCategory.SelectedItem.ToString();
                            row.Cells[6].Value = reader.GetString(2);
                            dataGridView1.Rows.Add(row);
                        }
                    }
                }
                conn.Close();
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            sBus.Text = "Triggered";
            DataGridViewRow row = (DataGridViewRow)dataGridView1.RowTemplate.Clone();

            sBus.Text = row.Cells[0].Value.ToString();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedIndex > -1)
            {
                clearTopFrame();
                popTopFrame();
                popFriendFrame();
                popFriendReviewFrame();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void rmFriend_Click(object sender, EventArgs e)
        {
            using (var conn = new NpgsqlConnection(buildConnString()))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "delete from yelp_friends where user_id='"+ listBox1.SelectedItem.ToString() + "' and friend_id in (select user_id from yelp_user where name='"+textBox1.Text.ToString() +"' and user_id in (select friend_id from yelp_friends where user_id='"+ listBox1.SelectedItem.ToString() + "'))";
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            MessageBox.Show("Friend deletion unsuccessful");
                        }
                        MessageBox.Show("Friend deletion successful!");
                    }
                }
                conn.Close();
                clearTopFrame();
                popTopFrame();
                popFriendFrame();
                popFriendReviewFrame();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void uname_Click(object sender, EventArgs e)
        {
            uname.Clear();
        }

        private void uname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //enter key is down
               
                using (var conn = new NpgsqlConnection(buildConnString()))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT user_id FROM yelp_user where name='" + uname.Text.ToString() + "'";
                        using (var reader = cmd.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                int index = listBox1.FindStringExact(reader.GetString(0));
                                if (index < 0)
                                {
                                    //MessageBox.Show("Invalid Name");
                                }
                                else
                                {
                                    listBox1.SetSelected(index, true);
                                }
                            }
                        }
                    }
                    conn.Close();
                    adduid();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //show reviews
            Form2 form2 = new Form2();

            if (this.bCategory.SelectedIndex > -1)
            {

                // clear previous contents

                form2.dataGridView1.Rows.Clear();
                using (var conn = new NpgsqlConnection(buildConnString()))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand())
                    {

                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT date,name,stars,text, funny, useful, cool FROM yelp_review, yelp_user WHERE yelp_review.user_id = yelp_user.user_id AND yelp_review.business_id = (SELECT business_id FROM yelp_business WHERE postal_code ='" + bZip.SelectedItem.ToString() + "' AND name ='" + dataGridView1.SelectedCells[0].Value + "')"; //this too
                        using (var reader = cmd.ExecuteReader())
                        {

                            form2.dataGridView1.RowTemplate.CreateCells(form2.dataGridView1);
                            while (reader.Read())
                            {
                                DataGridViewRow row = (DataGridViewRow)form2.dataGridView1.RowTemplate.Clone();
                                row.Cells[0].Value = reader.GetDate(0);
                                row.Cells[1].Value = reader.GetString(1);
                                row.Cells[2].Value = reader.GetString(2);
                                row.Cells[3].Value = reader.GetString(3);

                                row.Cells[4].Value = reader.GetInt32(4);
                                row.Cells[5].Value = reader.GetInt32(5);
                                row.Cells[6].Value = reader.GetInt32(6);
                                form2.dataGridView1.Rows.Add(row);
                            }
                        }
                    }
                    conn.Close();
                }
                form2.dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                form2.dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                form2.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //business by zip chart
            Form3 form3 = new Form3();



            form3.chart1.Series.Clear();



            if (this.bCategory.SelectedIndex > -1)
            {
                using (var conn = new NpgsqlConnection(buildConnString()))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand())
                    {

                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT morning+afternoon+evening+night FROM yelp_checkin, yelp_business WHERE yelp_checkin.business_id = (SELECT business_id FROM yelp_business WHERE postal_code ='" + bZip.SelectedItem.ToString() + "' AND name ='" + dataGridView1.SelectedCells[0].Value + "') AND yelp_checkin.business_id = yelp_business.business_id GROUP BY yelp_checkin.business_id, day_of_week";
                        using (var reader = cmd.ExecuteReader())
                        {

                            // Data arrays
                            string[] seriesArray = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
                            int[] pointsArray = { 0, 0, 0, 0, 0, 0, 0 };

                            // Set palette
                            form3.chart1.Palette = ChartColorPalette.SeaGreen;

                            // Set title
                            form3.chart1.Titles.Add("Check-ins per Day-of-Week");

                            // Add series.
                            int i = 0;

                            while( reader.Read() )
                            {
                                 //var test = reader.GetValue(0);
                                pointsArray[i] = reader.GetInt32(0);
                                Series series = form3.chart1.Series.Add(seriesArray[i]);
                                series.Points.Add(pointsArray[i]);
                                i++;
                            }

                            form3.Show();

                        }
                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();

            form3.chart1.Series.Clear();


            if (this.bCategory.SelectedIndex > -1)
            {
                using (var conn = new NpgsqlConnection(buildConnString()))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand())
                    {

                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT postal_code,COUNT(business_id) FROM yelp_business WHERE city = '" + bCity.SelectedItem.ToString() + "' AND state='" + bState.SelectedItem.ToString() + "' GROUP BY postal_code ";

                        using (var reader = cmd.ExecuteReader())
                        {

                            // Data arrays
                            IList<string> seriesArray = new List<string>();
                            IList<int> pointsArray = new List<int>();

                            // Set palette
                            form3.chart1.Palette = ChartColorPalette.SeaGreen;

                            

                            // Set title
                            form3.chart1.Titles.Add("Businesses per Zipcode");

                            // Add series.
                            int i = 0;

                            while (reader.Read())
                            {
                                seriesArray.Add(reader.GetString(0));
                                pointsArray.Add(reader.GetInt32(1));
                                Series series = form3.chart1.Series.Add(seriesArray[i]);
                                series.Points.Add(pointsArray[i]);
                                i++;
                            }

                            form3.Show();

                        }
                    }
                }
            }
        }

        private void sBus_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //checkin
            var bname = dataGridView1.SelectedCells[0].Value;
            var bid = dataGridView1.SelectedCells[6].Value;

            var date = DateTime.Today.ToShortDateString();
            var time = DateTime.UtcNow.ToLocalTime();
            var time2 = time.ToShortTimeString();

            int morning=0, afternoon=0, evening=0, night=0;

            if (time < DateTime.Parse("12:00:00.000") && time > DateTime.Parse("06:00:00.000") )
            {
                morning = 1;
               
            }
            else if (time > DateTime.Parse("12:00:00.000") && time < DateTime.Parse("17:00:00.000"))
            {
                afternoon = 1;
            }
            else if (time < DateTime.Parse("23:00:00.000") && time > DateTime.Parse("17:00:00.000"))
            {
                evening = 1;
            }
            else if (time > DateTime.Parse("23:00:00.000") && time < DateTime.Parse("06:00:00.000"))
            {
                night = 1;
            }

            using (var conn = new NpgsqlConnection(buildConnString()))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {

                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO yelp_checkin VALUES( '" + bid + "', '" + time.DayOfWeek.ToString() + "', '" + morning + "', '" + afternoon + "', '" + evening + "', '" + night + "')";

                    using (var reader = cmd.ExecuteReader())
                    {
                    }
                }
            }
            

        }

        private void uAttr_Click(object sender, EventArgs e)
        {
            //checkin
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            sBus.Text = (string)dataGridView1.SelectedCells[0].Value;
        }


    }
 }
