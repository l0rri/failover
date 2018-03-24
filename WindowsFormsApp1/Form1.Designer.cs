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
            this.bZip = new System.Windows.Forms.ComboBox();
            this.bCategory = new System.Windows.Forms.ComboBox();
            this.BusinessName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.City = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ZIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categories = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1013, 24);
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
            this.bState.Location = new System.Drawing.Point(12, 38);
            this.bState.Name = "bState";
            this.bState.Size = new System.Drawing.Size(135, 21);
            this.bState.TabIndex = 0;
            this.bState.Text = "Select State";
            this.bState.SelectedIndexChanged += new System.EventHandler(this.bState_SelectedIndexChanged);
            // 
            // bCity
            // 
            this.bCity.FormattingEnabled = true;
            this.bCity.Location = new System.Drawing.Point(153, 38);
            this.bCity.Name = "bCity";
            this.bCity.Size = new System.Drawing.Size(192, 21);
            this.bCity.TabIndex = 1;
            this.bCity.Text = "Select City";
            this.bCity.SelectedIndexChanged += new System.EventHandler(this.bCity_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BusinessName,
            this.State,
            this.City,
            this.ZIP,
            this.Categories});
            this.dataGridView1.Location = new System.Drawing.Point(12, 65);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(986, 463);
            this.dataGridView1.TabIndex = 2;
            // 
            // bZip
            // 
            this.bZip.FormattingEnabled = true;
            this.bZip.Location = new System.Drawing.Point(351, 38);
            this.bZip.Name = "bZip";
            this.bZip.Size = new System.Drawing.Size(142, 21);
            this.bZip.TabIndex = 4;
            this.bZip.Text = "Select ZIP";
            this.bZip.SelectedIndexChanged += new System.EventHandler(this.bZip_SelectedIndexChanged);
            // 
            // bCategory
            // 
            this.bCategory.FormattingEnabled = true;
            this.bCategory.Location = new System.Drawing.Point(499, 38);
            this.bCategory.Name = "bCategory";
            this.bCategory.Size = new System.Drawing.Size(499, 21);
            this.bCategory.TabIndex = 5;
            this.bCategory.Text = "Choose a Category";
            this.bCategory.SelectedIndexChanged += new System.EventHandler(this.bCategory_SelectedIndexChanged);
            // 
            // BusinessName
            // 
            this.BusinessName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.BusinessName.HeaderText = "BusinessName";
            this.BusinessName.Name = "BusinessName";
            this.BusinessName.Width = 102;
            // 
            // State
            // 
            this.State.HeaderText = "State";
            this.State.Name = "State";
            // 
            // City
            // 
            this.City.HeaderText = "City";
            this.City.Name = "City";
            // 
            // ZIP
            // 
            this.ZIP.HeaderText = "ZIP";
            this.ZIP.Name = "ZIP";
            // 
            // Categories
            // 
            this.Categories.HeaderText = "Categories";
            this.Categories.Name = "Categories";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 540);
            this.Controls.Add(this.bCategory);
            this.Controls.Add(this.bZip);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.bCity);
            this.Controls.Add(this.bState);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
        private System.Windows.Forms.ComboBox bCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn BusinessName;
        private System.Windows.Forms.DataGridViewTextBoxColumn State;
        private System.Windows.Forms.DataGridViewTextBoxColumn City;
        private System.Windows.Forms.DataGridViewTextBoxColumn ZIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categories;
    }
}

