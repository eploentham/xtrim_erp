namespace Xtrim_ERP.gui
{
    partial class MainMenu3
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
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuImpJobView = new System.Windows.Forms.ToolStripMenuItem();
            this.menuImpJobAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTest = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tC1 = new System.Windows.Forms.TabControl();
            this.c1ThemeController1 = new C1.Win.C1Themes.C1ThemeController();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.ขอมลForwarderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ขอมลบรษทประกนToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ขอมลConsigneeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ขอมลEntryTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ขอมลPortImportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ขอมลPortOfLoadingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ขอมลPrivilegesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ขอมลTerminalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuConvertData = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1ThemeController1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(161)))), ((int)(((byte)(106)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuExit,
            this.toolStripMenuItem1,
            this.toolStripMenuItem4,
            this.toolStripMenuItem2});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.c1ThemeController1.SetTheme(this.menuStrip1, "(default)");
            // 
            // menuExit
            // 
            this.menuExit.Image = global::Xtrim_ERP.Properties.Resources.login16;
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(53, 20);
            this.menuExit.Text = "Exit";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuImpJobView,
            this.menuImpJobAdd,
            this.menuTest});
            this.toolStripMenuItem1.Image = global::Xtrim_ERP.Properties.Resources.Forklift_48x48;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(92, 20);
            this.toolStripMenuItem1.Text = "Import Job";
            // 
            // menuImpJobView
            // 
            this.menuImpJobView.Name = "menuImpJobView";
            this.menuImpJobView.Size = new System.Drawing.Size(180, 22);
            this.menuImpJobView.Text = "Open Job Import";
            this.menuImpJobView.Click += new System.EventHandler(this.menuImpJobView_Click);
            // 
            // menuImpJobAdd
            // 
            this.menuImpJobAdd.Name = "menuImpJobAdd";
            this.menuImpJobAdd.Size = new System.Drawing.Size(180, 22);
            this.menuImpJobAdd.Text = "New Job Import";
            this.menuImpJobAdd.Click += new System.EventHandler(this.menuImpJobAdd_Click);
            // 
            // menuTest
            // 
            this.menuTest.Name = "menuTest";
            this.menuTest.Size = new System.Drawing.Size(180, 22);
            this.menuTest.Text = "TestMenu";
            this.menuTest.Click += new System.EventHandler(this.menuTest_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem5,
            this.toolStripMenuItem6});
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(73, 20);
            this.toolStripMenuItem4.Text = "Export Job";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem5.Text = "Open Export Job";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem6.Text = "New Export Job";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(161)))), ((int)(((byte)(106)))));
            this.panel1.Controls.Add(this.tC1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 426);
            this.panel1.TabIndex = 1;
            this.c1ThemeController1.SetTheme(this.panel1, "(default)");
            // 
            // tC1
            // 
            this.tC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tC1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.tC1.Location = new System.Drawing.Point(0, 0);
            this.tC1.Name = "tC1";
            this.tC1.SelectedIndex = 0;
            this.tC1.Size = new System.Drawing.Size(800, 426);
            this.tC1.TabIndex = 2;
            // 
            // c1ThemeController1
            // 
            this.c1ThemeController1.Theme = "BeigeOne";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.toolStripSeparator2,
            this.toolStripMenuItem7,
            this.toolStripMenuItem8,
            this.ขอมลForwarderToolStripMenuItem,
            this.ขอมลบรษทประกนToolStripMenuItem,
            this.ขอมลConsigneeToolStripMenuItem,
            this.toolStripSeparator1,
            this.ขอมลEntryTypeToolStripMenuItem,
            this.ขอมลPortImportToolStripMenuItem,
            this.ขอมลTerminalToolStripMenuItem,
            this.ขอมลPortOfLoadingToolStripMenuItem,
            this.ขอมลPrivilegesToolStripMenuItem,
            this.toolStripSeparator3,
            this.menuConvertData});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(64, 20);
            this.toolStripMenuItem2.Text = "กำหนดค่า";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(185, 22);
            this.toolStripMenuItem3.Text = "ข้อมูลบริษัท";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(185, 22);
            this.toolStripMenuItem7.Text = "ข้อมูลลูกค้า";
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(185, 22);
            this.toolStripMenuItem8.Text = "ข้อมูล Importer";
            // 
            // ขอมลForwarderToolStripMenuItem
            // 
            this.ขอมลForwarderToolStripMenuItem.Name = "ขอมลForwarderToolStripMenuItem";
            this.ขอมลForwarderToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.ขอมลForwarderToolStripMenuItem.Text = "ข้อมูล Forwarder";
            // 
            // ขอมลบรษทประกนToolStripMenuItem
            // 
            this.ขอมลบรษทประกนToolStripMenuItem.Name = "ขอมลบรษทประกนToolStripMenuItem";
            this.ขอมลบรษทประกนToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.ขอมลบรษทประกนToolStripMenuItem.Text = "ข้อมูล บริษัทประกัน";
            // 
            // ขอมลConsigneeToolStripMenuItem
            // 
            this.ขอมลConsigneeToolStripMenuItem.Name = "ขอมลConsigneeToolStripMenuItem";
            this.ขอมลConsigneeToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.ขอมลConsigneeToolStripMenuItem.Text = "ข้อมูล Consignee";
            // 
            // ขอมลEntryTypeToolStripMenuItem
            // 
            this.ขอมลEntryTypeToolStripMenuItem.Name = "ขอมลEntryTypeToolStripMenuItem";
            this.ขอมลEntryTypeToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.ขอมลEntryTypeToolStripMenuItem.Text = "ข้อมูล Entry Type";
            // 
            // ขอมลPortImportToolStripMenuItem
            // 
            this.ขอมลPortImportToolStripMenuItem.Name = "ขอมลPortImportToolStripMenuItem";
            this.ขอมลPortImportToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.ขอมลPortImportToolStripMenuItem.Text = "ข้อมูล Port Import";
            // 
            // ขอมลPortOfLoadingToolStripMenuItem
            // 
            this.ขอมลPortOfLoadingToolStripMenuItem.Name = "ขอมลPortOfLoadingToolStripMenuItem";
            this.ขอมลPortOfLoadingToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.ขอมลPortOfLoadingToolStripMenuItem.Text = "ข้อมูล Port of Loading";
            // 
            // ขอมลPrivilegesToolStripMenuItem
            // 
            this.ขอมลPrivilegesToolStripMenuItem.Name = "ขอมลPrivilegesToolStripMenuItem";
            this.ขอมลPrivilegesToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.ขอมลPrivilegesToolStripMenuItem.Text = "ข้อมูล Privileges";
            // 
            // ขอมลTerminalToolStripMenuItem
            // 
            this.ขอมลTerminalToolStripMenuItem.Name = "ขอมลTerminalToolStripMenuItem";
            this.ขอมลTerminalToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.ขอมลTerminalToolStripMenuItem.Text = "ข้อมูล Terminal";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(182, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(182, 6);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(182, 6);
            // 
            // menuConvertData
            // 
            this.menuConvertData.Name = "menuConvertData";
            this.menuConvertData.Size = new System.Drawing.Size(185, 22);
            this.menuConvertData.Text = "Convert Data";
            this.menuConvertData.Click += new System.EventHandler(this.menuConvertData_Click);
            // 
            // MainMenu3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainMenu3";
            this.Text = "MainMenu3";
            this.c1ThemeController1.SetTheme(this, "(default)");
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainMenu3_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c1ThemeController1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.ToolStripMenuItem menuImpJobView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tC1;
        private System.Windows.Forms.ToolStripMenuItem menuImpJobAdd;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private C1.Win.C1Themes.C1ThemeController c1ThemeController1;
        private System.Windows.Forms.ToolStripMenuItem menuTest;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem ขอมลForwarderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ขอมลบรษทประกนToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ขอมลConsigneeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ขอมลEntryTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ขอมลPortImportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ขอมลTerminalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ขอมลPortOfLoadingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ขอมลPrivilegesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem menuConvertData;
    }
}