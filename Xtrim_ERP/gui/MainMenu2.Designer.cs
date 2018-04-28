namespace Xtrim_ERP.gui
{
    partial class MainMenu2
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
            this.c1MainMenu1 = new C1.Win.C1Command.C1MainMenu();
            this.c1CommandHolder1 = new C1.Win.C1Command.C1CommandHolder();
            this.c1CommandLink1 = new C1.Win.C1Command.C1CommandLink();
            this.c1ThemeController1 = new C1.Win.C1Themes.C1ThemeController();
            this.c1CommandLink2 = new C1.Win.C1Command.C1CommandLink();
            this.c1CommandLink3 = new C1.Win.C1Command.C1CommandLink();
            ((System.ComponentModel.ISupportInitialize)(this.c1CommandHolder1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1ThemeController1)).BeginInit();
            this.SuspendLayout();
            // 
            // c1MainMenu1
            // 
            this.c1MainMenu1.AccessibleName = "Menu Bar";
            this.c1MainMenu1.BackImageInImageBar = true;
            this.c1MainMenu1.CommandHolder = this.c1CommandHolder1;
            this.c1MainMenu1.CommandLinks.AddRange(new C1.Win.C1Command.C1CommandLink[] {
            this.c1CommandLink1,
            this.c1CommandLink2,
            this.c1CommandLink3});
            this.c1MainMenu1.Dock = System.Windows.Forms.DockStyle.Top;
            this.c1MainMenu1.Location = new System.Drawing.Point(0, 0);
            this.c1MainMenu1.Name = "c1MainMenu1";
            this.c1MainMenu1.Size = new System.Drawing.Size(800, 27);
            this.c1ThemeController1.SetTheme(this.c1MainMenu1, "(default)");
            // 
            // c1CommandHolder1
            // 
            this.c1CommandHolder1.Owner = this;
            // 
            // c1CommandLink1
            // 
            this.c1CommandLink1.Text = "Exit";
            // 
            // c1CommandLink2
            // 
            this.c1CommandLink2.SortOrder = 1;
            this.c1CommandLink2.Text = "Import";
            // 
            // c1CommandLink3
            // 
            this.c1CommandLink3.SortOrder = 2;
            this.c1CommandLink3.Text = "Export";
            // 
            // MainMenu2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.c1MainMenu1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(118)))), ((int)(((byte)(135)))));
            this.Name = "MainMenu2";
            this.Text = "MainMenu2";
            this.c1ThemeController1.SetTheme(this, "(default)");
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.c1CommandHolder1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1ThemeController1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.C1Command.C1MainMenu c1MainMenu1;
        private C1.Win.C1Command.C1CommandHolder c1CommandHolder1;
        private C1.Win.C1Command.C1CommandLink c1CommandLink1;
        private C1.Win.C1Themes.C1ThemeController c1ThemeController1;
        private C1.Win.C1Command.C1CommandLink c1CommandLink2;
        private C1.Win.C1Command.C1CommandLink c1CommandLink3;
    }
}