namespace CA.Immigration.LMIA
{
    partial class ApplicationSteam
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
            this.grbApplicationType = new System.Windows.Forms.GroupBox();
            this.txtProgram = new System.Windows.Forms.TextBox();
            this.txtAnotherEmployer = new System.Windows.Forms.TextBox();
            this.cmbStream = new System.Windows.Forms.ComboBox();
            this.ckbOtherEmployer = new System.Windows.Forms.CheckBox();
            this.lblSubCategory = new System.Windows.Forms.Label();
            this.lblAnotherEmployer = new System.Windows.Forms.Label();
            this.lblProgram = new System.Windows.Forms.Label();
            this.grbApplicationType.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbApplicationType
            // 
            this.grbApplicationType.Controls.Add(this.txtProgram);
            this.grbApplicationType.Controls.Add(this.txtAnotherEmployer);
            this.grbApplicationType.Controls.Add(this.cmbStream);
            this.grbApplicationType.Controls.Add(this.ckbOtherEmployer);
            this.grbApplicationType.Controls.Add(this.lblSubCategory);
            this.grbApplicationType.Controls.Add(this.lblAnotherEmployer);
            this.grbApplicationType.Controls.Add(this.lblProgram);
            this.grbApplicationType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbApplicationType.Location = new System.Drawing.Point(0, 0);
            this.grbApplicationType.Name = "grbApplicationType";
            this.grbApplicationType.Size = new System.Drawing.Size(1455, 106);
            this.grbApplicationType.TabIndex = 1;
            this.grbApplicationType.TabStop = false;
            this.grbApplicationType.Text = "LMIA Application Type";
            // 
            // txtProgram
            // 
            this.txtProgram.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtProgram.Location = new System.Drawing.Point(222, 46);
            this.txtProgram.Name = "txtProgram";
            this.txtProgram.Size = new System.Drawing.Size(210, 26);
            this.txtProgram.TabIndex = 0;
            // 
            // txtAnotherEmployer
            // 
            this.txtAnotherEmployer.BackColor = System.Drawing.SystemColors.Window;
            this.txtAnotherEmployer.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtAnotherEmployer.Location = new System.Drawing.Point(1268, 43);
            this.txtAnotherEmployer.Name = "txtAnotherEmployer";
            this.txtAnotherEmployer.Size = new System.Drawing.Size(120, 26);
            this.txtAnotherEmployer.TabIndex = 5;
            // 
            // cmbStream
            // 
            this.cmbStream.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.cmbStream.FormattingEnabled = true;
            this.cmbStream.Items.AddRange(new object[] {
            "High Wage Stream",
            "Low Wage Stream"});
            this.cmbStream.Location = new System.Drawing.Point(620, 46);
            this.cmbStream.Name = "cmbStream";
            this.cmbStream.Size = new System.Drawing.Size(198, 28);
            this.cmbStream.TabIndex = 1;
            // 
            // ckbOtherEmployer
            // 
            this.ckbOtherEmployer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ckbOtherEmployer.AutoSize = true;
            this.ckbOtherEmployer.Location = new System.Drawing.Point(860, 46);
            this.ckbOtherEmployer.Name = "ckbOtherEmployer";
            this.ckbOtherEmployer.Size = new System.Drawing.Size(203, 24);
            this.ckbOtherEmployer.TabIndex = 2;
            this.ckbOtherEmployer.Text = "More Than 1 Employer?";
            this.ckbOtherEmployer.UseVisualStyleBackColor = true;
            this.ckbOtherEmployer.CheckedChanged += new System.EventHandler(this.ckbOtherEmployer_CheckedChanged);
            // 
            // lblSubCategory
            // 
            this.lblSubCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSubCategory.AutoSize = true;
            this.lblSubCategory.Location = new System.Drawing.Point(474, 49);
            this.lblSubCategory.Name = "lblSubCategory";
            this.lblSubCategory.Size = new System.Drawing.Size(110, 20);
            this.lblSubCategory.TabIndex = 1;
            this.lblSubCategory.Text = "Select Stream";
            // 
            // lblAnotherEmployer
            // 
            this.lblAnotherEmployer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAnotherEmployer.AutoSize = true;
            this.lblAnotherEmployer.Location = new System.Drawing.Point(1084, 49);
            this.lblAnotherEmployer.Name = "lblAnotherEmployer";
            this.lblAnotherEmployer.Size = new System.Drawing.Size(165, 20);
            this.lblAnotherEmployer.TabIndex = 4;
            this.lblAnotherEmployer.Text = "Other Employer Name";
            // 
            // lblProgram
            // 
            this.lblProgram.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProgram.AutoSize = true;
            this.lblProgram.Location = new System.Drawing.Point(6, 49);
            this.lblProgram.Name = "lblProgram";
            this.lblProgram.Size = new System.Drawing.Size(151, 20);
            this.lblProgram.TabIndex = 2;
            this.lblProgram.Text = "Application Program";
            // 
            // ApplicationSteam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grbApplicationType);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ApplicationSteam";
            this.Size = new System.Drawing.Size(1455, 106);
            this.grbApplicationType.ResumeLayout(false);
            this.grbApplicationType.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbApplicationType;
        private System.Windows.Forms.Label lblSubCategory;
        private System.Windows.Forms.Label lblProgram;
        public System.Windows.Forms.TextBox txtProgram;
        public System.Windows.Forms.TextBox txtAnotherEmployer;
        public System.Windows.Forms.ComboBox cmbStream;
        public System.Windows.Forms.CheckBox ckbOtherEmployer;
        public System.Windows.Forms.Label lblAnotherEmployer;
    }
}
