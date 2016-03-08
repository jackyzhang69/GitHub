namespace CA.Immigration.Startup
{
    partial class EmployerSelector
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
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblEmployerName = new System.Windows.Forms.Label();
            this.grpEmployer = new System.Windows.Forms.GroupBox();
            this.dgvEmployer = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.grpEmployer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployer)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(456, 37);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(89, 26);
            this.textBox2.TabIndex = 9;
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(393, 37);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(35, 20);
            this.lblCity.TabIndex = 7;
            this.lblCity.Text = "City";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(136, 37);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(230, 26);
            this.textBox1.TabIndex = 10;
            // 
            // lblEmployerName
            // 
            this.lblEmployerName.AutoSize = true;
            this.lblEmployerName.Location = new System.Drawing.Point(9, 37);
            this.lblEmployerName.Name = "lblEmployerName";
            this.lblEmployerName.Size = new System.Drawing.Size(121, 20);
            this.lblEmployerName.TabIndex = 8;
            this.lblEmployerName.Text = "Employer Name";
            // 
            // grpEmployer
            // 
            this.grpEmployer.Controls.Add(this.dgvEmployer);
            this.grpEmployer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpEmployer.Location = new System.Drawing.Point(3, 93);
            this.grpEmployer.Name = "grpEmployer";
            this.grpEmployer.Size = new System.Drawing.Size(899, 650);
            this.grpEmployer.TabIndex = 6;
            this.grpEmployer.TabStop = false;
            this.grpEmployer.Text = "Select Employer";
            // 
            // dgvEmployer
            // 
            this.dgvEmployer.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvEmployer.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvEmployer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEmployer.Location = new System.Drawing.Point(3, 22);
            this.dgvEmployer.Name = "dgvEmployer";
            this.dgvEmployer.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvEmployer.RowHeadersVisible = false;
            this.dgvEmployer.RowTemplate.Height = 28;
            this.dgvEmployer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmployer.Size = new System.Drawing.Size(893, 625);
            this.dgvEmployer.TabIndex = 0;
            this.dgvEmployer.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvEmployer_MouseDoubleClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.grpFilter, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.grpEmployer, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.06434F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.93565F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(905, 746);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // grpFilter
            // 
            this.grpFilter.Controls.Add(this.lblEmployerName);
            this.grpFilter.Controls.Add(this.textBox2);
            this.grpFilter.Controls.Add(this.textBox1);
            this.grpFilter.Controls.Add(this.lblCity);
            this.grpFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFilter.Location = new System.Drawing.Point(3, 3);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Size = new System.Drawing.Size(899, 84);
            this.grpFilter.TabIndex = 0;
            this.grpFilter.TabStop = false;
            this.grpFilter.Text = "Filter";
            // 
            // EmployerSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 746);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "EmployerSelector";
            this.Text = "EmployerSelector";
            this.Load += new System.EventHandler(this.EmployerSelector_Load);
            this.grpEmployer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployer)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.grpFilter.ResumeLayout(false);
            this.grpFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblEmployerName;
        private System.Windows.Forms.GroupBox grpEmployer;
        private System.Windows.Forms.DataGridView dgvEmployer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox grpFilter;
    }
}