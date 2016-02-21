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
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.lMIAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lMIAToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.bCPNPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qIIPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.MainStatus = new System.Windows.Forms.StatusStrip();
            this.stsSystem = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.MainStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lMIAToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(1665, 33);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "Main Menu";
            // 
            // lMIAToolStripMenuItem
            // 
            this.lMIAToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lMIAToolStripMenuItem1,
            this.bCPNPToolStripMenuItem,
            this.qIIPToolStripMenuItem,
            this.getValueToolStripMenuItem,
            this.toolStripMenuItem2});
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
            this.eIToolStripMenuItem.Size = new System.Drawing.Size(124, 30);
            this.eIToolStripMenuItem.Text = "EI";
            // 
            // sWToolStripMenuItem
            // 
            this.sWToolStripMenuItem.Name = "sWToolStripMenuItem";
            this.sWToolStripMenuItem.Size = new System.Drawing.Size(124, 30);
            this.sWToolStripMenuItem.Text = "SW";
            // 
            // qIIPToolStripMenuItem
            // 
            this.qIIPToolStripMenuItem.Name = "qIIPToolStripMenuItem";
            this.qIIPToolStripMenuItem.Size = new System.Drawing.Size(211, 30);
            this.qIIPToolStripMenuItem.Text = "QIIP";
            this.qIIPToolStripMenuItem.Click += new System.EventHandler(this.qIIPToolStripMenuItem_Click);
            // 
            // getValueToolStripMenuItem
            // 
            this.getValueToolStripMenuItem.Name = "getValueToolStripMenuItem";
            this.getValueToolStripMenuItem.Size = new System.Drawing.Size(211, 30);
            this.getValueToolStripMenuItem.Text = "GetValue";
            this.getValueToolStripMenuItem.Click += new System.EventHandler(this.getValueToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 33);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1665, 943);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.MainStatus);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1657, 910);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // MainStatus
            // 
            this.MainStatus.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.MainStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stsSystem});
            this.MainStatus.Location = new System.Drawing.Point(3, 877);
            this.MainStatus.Name = "MainStatus";
            this.MainStatus.Size = new System.Drawing.Size(1651, 30);
            this.MainStatus.TabIndex = 0;
            this.MainStatus.Text = "Status";
            // 
            // stsSystem
            // 
            this.stsSystem.Name = "stsSystem";
            this.stsSystem.Size = new System.Drawing.Size(179, 25);
            this.stsSystem.Text = "toolStripStatusLabel1";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1657, 910);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(211, 30);
            this.toolStripMenuItem2.Text = "5476";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // Startup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1665, 976);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.MainMenu);
            this.MainMenuStrip = this.MainMenu;
            this.Name = "Startup";
            this.Text = "Canada Immigration Advisor & Processing System";
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.MainStatus.ResumeLayout(false);
            this.MainStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem lMIAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lMIAToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem bCPNPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sWToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem qIIPToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.StatusStrip MainStatus;
        private System.Windows.Forms.ToolStripStatusLabel stsSystem;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolStripMenuItem getValueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
    }
}

