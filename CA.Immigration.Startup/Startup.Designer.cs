namespace CA.Immigration.Startup
{
    partial class Startup
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
            this.lMIAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lMIAToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.bCPNPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qIIPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lMIAToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1103, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // lMIAToolStripMenuItem
            // 
            this.lMIAToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lMIAToolStripMenuItem1,
            this.bCPNPToolStripMenuItem,
            this.qIIPToolStripMenuItem});
            this.lMIAToolStripMenuItem.Name = "lMIAToolStripMenuItem";
            this.lMIAToolStripMenuItem.Size = new System.Drawing.Size(114, 29);
            this.lMIAToolStripMenuItem.Text = "Application";
            // 
            // lMIAToolStripMenuItem1
            // 
            this.lMIAToolStripMenuItem1.Name = "lMIAToolStripMenuItem1";
            this.lMIAToolStripMenuItem1.Size = new System.Drawing.Size(211, 30);
            this.lMIAToolStripMenuItem1.Text = "LMIA";
            this.lMIAToolStripMenuItem1.Click += new System.EventHandler(this.lMIAToolStripMenuItem1_Click);
            // 
            // bCPNPToolStripMenuItem
            // 
            this.bCPNPToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eIToolStripMenuItem,
            this.sWToolStripMenuItem});
            this.bCPNPToolStripMenuItem.Name = "bCPNPToolStripMenuItem";
            this.bCPNPToolStripMenuItem.Size = new System.Drawing.Size(211, 30);
            this.bCPNPToolStripMenuItem.Text = "BCPNP";
            // 
            // eIToolStripMenuItem
            // 
            this.eIToolStripMenuItem.Name = "eIToolStripMenuItem";
            this.eIToolStripMenuItem.Size = new System.Drawing.Size(211, 30);
            this.eIToolStripMenuItem.Text = "EI";
            // 
            // sWToolStripMenuItem
            // 
            this.sWToolStripMenuItem.Name = "sWToolStripMenuItem";
            this.sWToolStripMenuItem.Size = new System.Drawing.Size(211, 30);
            this.sWToolStripMenuItem.Text = "SW";
            // 
            // qIIPToolStripMenuItem
            // 
            this.qIIPToolStripMenuItem.Name = "qIIPToolStripMenuItem";
            this.qIIPToolStripMenuItem.Size = new System.Drawing.Size(211, 30);
            this.qIIPToolStripMenuItem.Text = "QIIP";
            // 
            // Startup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 628);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Startup";
            this.Text = "Canada Immigration Advisor & Processing System";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem lMIAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lMIAToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem bCPNPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sWToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem qIIPToolStripMenuItem;
    }
}

