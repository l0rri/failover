namespace WindowsFormsApp1
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.bState = new System.Windows.Forms.ComboBox();
            this.bCity = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.BusinessName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.City = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ZIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categories = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bZip = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Business = new System.Windows.Forms.TabPage();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.sBus = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkedListBox2 = new System.Windows.Forms.CheckedListBox();
            this.FilterPrice = new System.Windows.Forms.CheckedListBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.bCategory = new System.Windows.Forms.ComboBox();
            this.Users = new System.Windows.Forms.TabPage();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.uvote_funny = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.uvote_useful = new System.Windows.Forms.TextBox();
            this.uvote_cool = new System.Windows.Forms.TextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.p_uname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_business = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_city = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_text = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.rmFriend = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.friend_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.avg_stars = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yelp_since = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.uinfo_stars = new System.Windows.Forms.TextBox();
            this.uinfo_fans = new System.Windows.Forms.TextBox();
            this.uinfo_ys = new System.Windows.Forms.TextBox();
            this.uinfo_name = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.uname = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.Business.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.Users.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1052, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(113, 20);
            this.toolStripMenuItem1.Text = "Edit Connection...";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // bState
            // 
            this.bState.FormattingEnabled = true;
            this.bState.Location = new System.Drawing.Point(6, 6);
            this.bState.Name = "bState";
            this.bState.Size = new System.Drawing.Size(135, 21);
            this.bState.TabIndex = 0;
            this.bState.Text = "Select State";
            this.bState.SelectedIndexChanged += new System.EventHandler(this.bState_SelectedIndexChanged);
            // 
            // bCity
            // 
            this.bCity.FormattingEnabled = true;
            this.bCity.Location = new System.Drawing.Point(147, 6);
            this.bCity.Name = "bCity";
            this.bCity.Size = new System.Drawing.Size(192, 21);
            this.bCity.TabIndex = 1;
            this.bCity.Text = "Select City";
            this.bCity.SelectedIndexChanged += new System.EventHandler(this.bCity_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BusinessName,
            this.State,
            this.City,
            this.ZIP,
            this.Categories});
            this.dataGridView1.Location = new System.Drawing.Point(6, 33);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(745, 243);
            this.dataGridView1.TabIndex = 2;
            // 
            // BusinessName
            // 
            this.BusinessName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.BusinessName.HeaderText = "BusinessName";
            this.BusinessName.Name = "BusinessName";
            this.BusinessName.ReadOnly = true;
            this.BusinessName.Width = 102;
            // 
            // State
            // 
            this.State.HeaderText = "State";
            this.State.Name = "State";
            this.State.ReadOnly = true;
            this.State.Width = 57;
            // 
            // City
            // 
            this.City.HeaderText = "City";
            this.City.Name = "City";
            this.City.ReadOnly = true;
            this.City.Width = 49;
            // 
            // ZIP
            // 
            this.ZIP.HeaderText = "ZIP";
            this.ZIP.Name = "ZIP";
            this.ZIP.ReadOnly = true;
            this.ZIP.Width = 49;
            // 
            // Categories
            // 
            this.Categories.HeaderText = "Categories";
            this.Categories.Name = "Categories";
            this.Categories.ReadOnly = true;
            this.Categories.Width = 82;
            // 
            // bZip
            // 
            this.bZip.FormattingEnabled = true;
            this.bZip.Location = new System.Drawing.Point(345, 6);
            this.bZip.Name = "bZip";
            this.bZip.Size = new System.Drawing.Size(142, 21);
            this.bZip.TabIndex = 4;
            this.bZip.Text = "Select ZIP";
            this.bZip.SelectedIndexChanged += new System.EventHandler(this.bZip_SelectedIndexChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Business);
            this.tabControl1.Controls.Add(this.Users);
            this.tabControl1.Location = new System.Drawing.Point(12, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1036, 472);
            this.tabControl1.TabIndex = 6;
            // 
            // Business
            // 
            this.Business.Controls.Add(this.button6);
            this.Business.Controls.Add(this.button5);
            this.Business.Controls.Add(this.button4);
            this.Business.Controls.Add(this.groupBox3);
            this.Business.Controls.Add(this.groupBox2);
            this.Business.Controls.Add(this.groupBox1);
            this.Business.Controls.Add(this.bState);
            this.Business.Controls.Add(this.bCategory);
            this.Business.Controls.Add(this.bCity);
            this.Business.Controls.Add(this.bZip);
            this.Business.Controls.Add(this.dataGridView1);
            this.Business.Location = new System.Drawing.Point(4, 22);
            this.Business.Name = "Business";
            this.Business.Padding = new System.Windows.Forms.Padding(3);
            this.Business.Size = new System.Drawing.Size(1028, 446);
            this.Business.TabIndex = 0;
            this.Business.Text = "Business";
            this.Business.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(493, 370);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(257, 23);
            this.button6.TabIndex = 19;
            this.button6.Text = "# Business by Zip";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(493, 341);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(257, 23);
            this.button5.TabIndex = 18;
            this.button5.Text = "Show Reviews";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(493, 312);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(257, 23);
            this.button4.TabIndex = 17;
            this.button4.Text = "Show Check-Ins";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox2);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.comboBox5);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.sBus);
            this.groupBox3.Location = new System.Drawing.Point(6, 282);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(449, 152);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Check-in and Review";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(6, 44);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(327, 93);
            this.textBox2.TabIndex = 4;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(339, 114);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(98, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Publish Review";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // comboBox5
            // 
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(339, 87);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(98, 21);
            this.comboBox5.TabIndex = 2;
            this.comboBox5.Text = "Rating...";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(339, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Check-In";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // sBus
            // 
            this.sBus.Location = new System.Drawing.Point(6, 19);
            this.sBus.Name = "sBus";
            this.sBus.Size = new System.Drawing.Size(327, 20);
            this.sBus.TabIndex = 0;
            this.sBus.Text = "sBus";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkedListBox2);
            this.groupBox2.Controls.Add(this.FilterPrice);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.checkedListBox1);
            this.groupBox2.Location = new System.Drawing.Point(764, 91);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(257, 343);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filter by Attributes";
            // 
            // checkedListBox2
            // 
            this.checkedListBox2.FormattingEnabled = true;
            this.checkedListBox2.Items.AddRange(new object[] {
            "Breakfast",
            "Brunch",
            "Lunch",
            "Dinner",
            "Dessert",
            "Late Night"});
            this.checkedListBox2.Location = new System.Drawing.Point(86, 19);
            this.checkedListBox2.Name = "checkedListBox2";
            this.checkedListBox2.Size = new System.Drawing.Size(165, 94);
            this.checkedListBox2.TabIndex = 9;
            // 
            // FilterPrice
            // 
            this.FilterPrice.FormattingEnabled = true;
            this.FilterPrice.Items.AddRange(new object[] {
            "$",
            "$$",
            "$$$",
            "$$$$"});
            this.FilterPrice.Location = new System.Drawing.Point(15, 19);
            this.FilterPrice.Name = "FilterPrice";
            this.FilterPrice.Size = new System.Drawing.Size(65, 94);
            this.FilterPrice.TabIndex = 6;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(14, 279);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(238, 21);
            this.comboBox1.TabIndex = 10;
            this.comboBox1.Text = "Sort results by...";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(14, 306);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(237, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Update Search";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "Accepts Credit Cards",
            "Takes Reservations",
            "Wheelchair Accessible",
            "Outdoor Seating",
            "Good for Kids",
            "Good for Groups",
            "Delivery",
            "Take Out",
            "Free Wi-FI",
            "Bike Parking"});
            this.checkedListBox1.Location = new System.Drawing.Point(15, 119);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(237, 154);
            this.checkedListBox1.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.comboBox4);
            this.groupBox1.Controls.Add(this.comboBox3);
            this.groupBox1.Location = new System.Drawing.Point(764, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(257, 79);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Open Businesses";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(6, 19);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(237, 21);
            this.comboBox2.TabIndex = 11;
            this.comboBox2.Text = "Open on...";
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(116, 46);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(128, 21);
            this.comboBox4.TabIndex = 13;
            this.comboBox4.Text = "To...";
            this.comboBox4.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(6, 46);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(104, 21);
            this.comboBox3.TabIndex = 12;
            this.comboBox3.Text = "From...";
            // 
            // bCategory
            // 
            this.bCategory.FormattingEnabled = true;
            this.bCategory.Location = new System.Drawing.Point(493, 6);
            this.bCategory.Name = "bCategory";
            this.bCategory.Size = new System.Drawing.Size(258, 21);
            this.bCategory.TabIndex = 5;
            this.bCategory.Text = "Choose a Category";
            this.bCategory.SelectedIndexChanged += new System.EventHandler(this.bCategory_SelectedIndexChanged);
            // 
            // Users
            // 
            this.Users.Controls.Add(this.groupBox9);
            this.Users.Controls.Add(this.groupBox8);
            this.Users.Controls.Add(this.groupBox7);
            this.Users.Controls.Add(this.groupBox5);
            this.Users.Controls.Add(this.groupBox4);
            this.Users.Location = new System.Drawing.Point(4, 22);
            this.Users.Name = "Users";
            this.Users.Padding = new System.Windows.Forms.Padding(3);
            this.Users.Size = new System.Drawing.Size(1028, 446);
            this.Users.TabIndex = 1;
            this.Users.Text = "Users";
            this.Users.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.label6);
            this.groupBox9.Controls.Add(this.label7);
            this.groupBox9.Controls.Add(this.uvote_funny);
            this.groupBox9.Controls.Add(this.label5);
            this.groupBox9.Controls.Add(this.uvote_useful);
            this.groupBox9.Controls.Add(this.uvote_cool);
            this.groupBox9.Location = new System.Drawing.Point(272, 62);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(744, 68);
            this.groupBox9.TabIndex = 5;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Votes";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(310, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Cool:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Funny:";
            // 
            // uvote_funny
            // 
            this.uvote_funny.Location = new System.Drawing.Point(60, 15);
            this.uvote_funny.Name = "uvote_funny";
            this.uvote_funny.Size = new System.Drawing.Size(64, 20);
            this.uvote_funny.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(156, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Useful:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // uvote_useful
            // 
            this.uvote_useful.Location = new System.Drawing.Point(202, 18);
            this.uvote_useful.Name = "uvote_useful";
            this.uvote_useful.Size = new System.Drawing.Size(64, 20);
            this.uvote_useful.TabIndex = 13;
            // 
            // uvote_cool
            // 
            this.uvote_cool.Location = new System.Drawing.Point(347, 15);
            this.uvote_cool.Name = "uvote_cool";
            this.uvote_cool.Size = new System.Drawing.Size(64, 20);
            this.uvote_cool.TabIndex = 14;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.dataGridView3);
            this.groupBox8.Location = new System.Drawing.Point(272, 136);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(750, 303);
            this.groupBox8.TabIndex = 4;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Reviews by Friends";
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.p_uname,
            this.p_business,
            this.p_city,
            this.p_text});
            this.dataGridView3.Location = new System.Drawing.Point(6, 19);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowHeadersVisible = false;
            this.dataGridView3.Size = new System.Drawing.Size(738, 257);
            this.dataGridView3.TabIndex = 0;
            // 
            // p_uname
            // 
            this.p_uname.HeaderText = "Name";
            this.p_uname.Name = "p_uname";
            // 
            // p_business
            // 
            this.p_business.HeaderText = "Business";
            this.p_business.Name = "p_business";
            // 
            // p_city
            // 
            this.p_city.HeaderText = "City";
            this.p_city.Name = "p_city";
            // 
            // p_text
            // 
            this.p_text.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.p_text.HeaderText = "Text";
            this.p_text.Name = "p_text";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.textBox1);
            this.groupBox7.Controls.Add(this.rmFriend);
            this.groupBox7.Controls.Add(this.dataGridView2);
            this.groupBox7.Location = new System.Drawing.Point(6, 136);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(260, 303);
            this.groupBox7.TabIndex = 3;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Friends";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 256);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(246, 20);
            this.textBox1.TabIndex = 2;
            // 
            // rmFriend
            // 
            this.rmFriend.Location = new System.Drawing.Point(7, 280);
            this.rmFriend.Name = "rmFriend";
            this.rmFriend.Size = new System.Drawing.Size(247, 23);
            this.rmFriend.TabIndex = 1;
            this.rmFriend.Text = "Remove Friend";
            this.rmFriend.UseVisualStyleBackColor = true;
            this.rmFriend.Click += new System.EventHandler(this.rmFriend_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.friend_name,
            this.avg_stars,
            this.yelp_since});
            this.dataGridView2.Location = new System.Drawing.Point(7, 19);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.Size = new System.Drawing.Size(247, 228);
            this.dataGridView2.TabIndex = 0;
            // 
            // friend_name
            // 
            this.friend_name.FillWeight = 60F;
            this.friend_name.HeaderText = "Name";
            this.friend_name.Name = "friend_name";
            this.friend_name.Width = 60;
            // 
            // avg_stars
            // 
            this.avg_stars.FillWeight = 60F;
            this.avg_stars.HeaderText = "Avg Stars";
            this.avg_stars.Name = "avg_stars";
            this.avg_stars.Width = 60;
            // 
            // yelp_since
            // 
            this.yelp_since.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.yelp_since.HeaderText = "Yelping Since";
            this.yelp_since.Name = "yelp_since";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.uinfo_stars);
            this.groupBox5.Controls.Add(this.uinfo_fans);
            this.groupBox5.Controls.Add(this.uinfo_ys);
            this.groupBox5.Controls.Add(this.uinfo_name);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Location = new System.Drawing.Point(272, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(744, 50);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "User Information";
            // 
            // uinfo_stars
            // 
            this.uinfo_stars.Location = new System.Drawing.Point(202, 19);
            this.uinfo_stars.Name = "uinfo_stars";
            this.uinfo_stars.Size = new System.Drawing.Size(100, 20);
            this.uinfo_stars.TabIndex = 12;
            // 
            // uinfo_fans
            // 
            this.uinfo_fans.Location = new System.Drawing.Point(347, 19);
            this.uinfo_fans.Name = "uinfo_fans";
            this.uinfo_fans.Size = new System.Drawing.Size(100, 20);
            this.uinfo_fans.TabIndex = 11;
            // 
            // uinfo_ys
            // 
            this.uinfo_ys.Location = new System.Drawing.Point(538, 19);
            this.uinfo_ys.Name = "uinfo_ys";
            this.uinfo_ys.Size = new System.Drawing.Size(100, 20);
            this.uinfo_ys.TabIndex = 10;
            // 
            // uinfo_name
            // 
            this.uinfo_name.Location = new System.Drawing.Point(50, 19);
            this.uinfo_name.Name = "uinfo_name";
            this.uinfo_name.Size = new System.Drawing.Size(100, 20);
            this.uinfo_name.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(457, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Yelping Since:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(308, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fans:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(162, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Stars:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.listBox1);
            this.groupBox4.Controls.Add(this.uname);
            this.groupBox4.Location = new System.Drawing.Point(6, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(260, 124);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Set Current User";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(7, 45);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(246, 69);
            this.listBox1.TabIndex = 1;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // uname
            // 
            this.uname.Location = new System.Drawing.Point(6, 19);
            this.uname.Name = "uname";
            this.uname.Size = new System.Drawing.Size(247, 20);
            this.uname.TabIndex = 0;
            this.uname.Text = "Type name here...";
            this.uname.Click += new System.EventHandler(this.uname_Click);
            this.uname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uname_KeyDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 500);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.Business.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.Users.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ComboBox bState;
        private System.Windows.Forms.ComboBox bCity;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox bZip;
        private System.Windows.Forms.DataGridViewTextBoxColumn BusinessName;
        private System.Windows.Forms.DataGridViewTextBoxColumn State;
        private System.Windows.Forms.DataGridViewTextBoxColumn City;
        private System.Windows.Forms.DataGridViewTextBoxColumn ZIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categories;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Business;
        private System.Windows.Forms.TabPage Users;
        private System.Windows.Forms.CheckedListBox FilterPrice;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckedListBox checkedListBox2;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox bCategory;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox sBus;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button rmFriend;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox uname;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox uvote_cool;
        private System.Windows.Forms.TextBox uvote_useful;
        private System.Windows.Forms.TextBox uinfo_stars;
        private System.Windows.Forms.TextBox uinfo_fans;
        private System.Windows.Forms.TextBox uinfo_ys;
        private System.Windows.Forms.TextBox uvote_funny;
        private System.Windows.Forms.TextBox uinfo_name;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_uname;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_business;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_city;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_text;
        private System.Windows.Forms.DataGridViewTextBoxColumn friend_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn avg_stars;
        private System.Windows.Forms.DataGridViewTextBoxColumn yelp_since;
    }
}

