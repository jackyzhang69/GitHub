namespace CA.Immigration.LMIA
{
    partial class Indicators
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
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grbQualification = new System.Windows.Forms.GroupBox();
            this.dgvQualificationIndicator = new System.Windows.Forms.DataGridView();
            this.CheckPoint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbQualification.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQualificationIndicator)).BeginInit();
            this.SuspendLayout();
            // 
            // grbQualification
            // 
            this.grbQualification.Controls.Add(this.dgvQualificationIndicator);
            this.grbQualification.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbQualification.Location = new System.Drawing.Point(0, 0);
            this.grbQualification.Margin = new System.Windows.Forms.Padding(2);
            this.grbQualification.Name = "grbQualification";
            this.grbQualification.Padding = new System.Windows.Forms.Padding(2);
            this.grbQualification.Size = new System.Drawing.Size(317, 271);
            this.grbQualification.TabIndex = 2;
            this.grbQualification.TabStop = false;
            this.grbQualification.Text = "Qualification Indicators";
            // 
            // dgvQualificationIndicator
            // 
            this.dgvQualificationIndicator.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvQualificationIndicator.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvQualificationIndicator.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQualificationIndicator.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CheckPoint,
            this.Result});
            this.dgvQualificationIndicator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvQualificationIndicator.EnableHeadersVisualStyles = false;
            this.dgvQualificationIndicator.Location = new System.Drawing.Point(2, 15);
            this.dgvQualificationIndicator.Margin = new System.Windows.Forms.Padding(2);
            this.dgvQualificationIndicator.Name = "dgvQualificationIndicator";
            this.dgvQualificationIndicator.RowTemplate.Height = 28;
            this.dgvQualificationIndicator.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQualificationIndicator.Size = new System.Drawing.Size(313, 254);
            this.dgvQualificationIndicator.TabIndex = 0;
            // 
            // CheckPoint
            // 
            this.CheckPoint.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CheckPoint.FillWeight = 200F;
            this.CheckPoint.HeaderText = "Check Point";
            this.CheckPoint.Name = "CheckPoint";
            this.CheckPoint.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Result
            // 
            this.Result.FillWeight = 50F;
            this.Result.HeaderText = "Result";
            this.Result.Name = "Result";
            // 
            // Indicators
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grbQualification);
            this.Name = "Indicators";
            this.Size = new System.Drawing.Size(317, 271);
            this.grbQualification.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQualificationIndicator)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbQualification;
        private System.Windows.Forms.DataGridView dgvQualificationIndicator;
        private System.Windows.Forms.DataGridViewTextBoxColumn CheckPoint;
        private System.Windows.Forms.DataGridViewTextBoxColumn Result;
    }
}
