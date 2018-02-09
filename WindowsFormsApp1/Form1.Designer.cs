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
            this.bState = new System.Windows.Forms.ComboBox();
            this.bCity = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.BusinessName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.City = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // bState
            // 
            this.bState.FormattingEnabled = true;
            this.bState.Location = new System.Drawing.Point(61, 38);
            this.bState.Name = "bState";
            this.bState.Size = new System.Drawing.Size(402, 21);
            this.bState.TabIndex = 0;
            this.bState.SelectedIndexChanged += new System.EventHandler(this.bState_SelectedIndexChanged);
            // 
            // bCity
            // 
            this.bCity.FormattingEnabled = true;
            this.bCity.Location = new System.Drawing.Point(61, 65);
            this.bCity.Name = "bCity";
            this.bCity.Size = new System.Drawing.Size(402, 21);
            this.bCity.TabIndex = 1;
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
            this.City});
            this.dataGridView1.Location = new System.Drawing.Point(12, 120);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(495, 150);
            this.dataGridView1.TabIndex = 2;
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 294);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.bCity);
            this.Controls.Add(this.bState);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox bState;
        private System.Windows.Forms.ComboBox bCity;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn BusinessName;
        private System.Windows.Forms.DataGridViewTextBoxColumn State;
        private System.Windows.Forms.DataGridViewTextBoxColumn City;
    }
}

