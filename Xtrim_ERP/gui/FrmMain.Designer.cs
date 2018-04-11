namespace Xtrim_ERP
{
    partial class FrmMain
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
            this.components = new System.ComponentModel.Container();
            C1.Win.C1Command.C1TopicPage c1TopicPage1 = new C1.Win.C1Command.C1TopicPage();
            C1.Win.C1Command.C1TopicLink c1TopicLink1 = new C1.Win.C1Command.C1TopicLink();
            C1.Win.C1Command.C1TopicLink c1TopicLink2 = new C1.Win.C1Command.C1TopicLink();
            C1.Win.C1Command.C1TopicPage c1TopicPage2 = new C1.Win.C1Command.C1TopicPage();
            C1.Win.C1Command.C1TopicPage c1TopicPage3 = new C1.Win.C1Command.C1TopicPage();
            this.c1CommandDock1 = new C1.Win.C1Command.C1CommandDock();
            this.c1DockingManager1 = new C1.Win.C1Command.C1DockingManager(this.components);
            this.c1DockingTab1 = new C1.Win.C1Command.C1DockingTab();
            this.c1DockingTabPage1 = new C1.Win.C1Command.C1DockingTabPage();
            this.c1TopicBar1 = new C1.Win.C1Command.C1TopicBar();
            this.c1CommandDock2 = new C1.Win.C1Command.C1CommandDock();
            this.c1DockingTab2 = new C1.Win.C1Command.C1DockingTab();
            this.c1DockingTabPage2 = new C1.Win.C1Command.C1DockingTabPage();
            ((System.ComponentModel.ISupportInitialize)(this.c1CommandDock1)).BeginInit();
            this.c1CommandDock1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1DockingManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1DockingTab1)).BeginInit();
            this.c1DockingTab1.SuspendLayout();
            this.c1DockingTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1TopicBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1CommandDock2)).BeginInit();
            this.c1CommandDock2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1DockingTab2)).BeginInit();
            this.c1DockingTab2.SuspendLayout();
            this.SuspendLayout();
            // 
            // c1CommandDock1
            // 
            this.c1CommandDock1.Controls.Add(this.c1DockingTab1);
            this.c1CommandDock1.Dock = System.Windows.Forms.DockStyle.Left;
            this.c1CommandDock1.Id = 1;
            this.c1CommandDock1.Location = new System.Drawing.Point(0, 0);
            this.c1CommandDock1.Name = "c1CommandDock1";
            this.c1CommandDock1.Size = new System.Drawing.Size(300, 718);
            // 
            // c1DockingManager1
            // 
            this.c1DockingManager1.ParentContainer = this;
            // 
            // c1DockingTab1
            // 
            this.c1DockingTab1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.c1DockingTab1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.c1DockingTab1.CanAutoHide = true;
            this.c1DockingTab1.CanCloseTabs = true;
            this.c1DockingTab1.CanMoveTabs = true;
            this.c1DockingTab1.Controls.Add(this.c1DockingTabPage1);
            this.c1DockingTab1.Location = new System.Drawing.Point(0, 0);
            this.c1DockingTab1.Name = "c1DockingTab1";
            this.c1DockingTab1.ShowCaption = true;
            this.c1DockingTab1.Size = new System.Drawing.Size(300, 718);
            this.c1DockingTab1.TabIndex = 0;
            this.c1DockingTab1.TabSizeMode = C1.Win.C1Command.TabSizeModeEnum.Fit;
            this.c1DockingTab1.TabsSpacing = 5;
            // 
            // c1DockingTabPage1
            // 
            this.c1DockingTabPage1.CaptionVisible = true;
            this.c1DockingTabPage1.Controls.Add(this.c1TopicBar1);
            this.c1DockingTabPage1.Location = new System.Drawing.Point(0, 0);
            this.c1DockingTabPage1.Name = "c1DockingTabPage1";
            this.c1DockingTabPage1.Size = new System.Drawing.Size(297, 694);
            this.c1DockingTabPage1.TabIndex = 0;
            this.c1DockingTabPage1.Text = "Page1";
            // 
            // c1TopicBar1
            // 
            this.c1TopicBar1.AutoScrollMinSize = new System.Drawing.Size(0, 213);
            this.c1TopicBar1.ImageList = null;
            this.c1TopicBar1.Location = new System.Drawing.Point(12, 27);
            this.c1TopicBar1.Name = "c1TopicBar1";
            this.c1TopicBar1.PagePadding = new System.Windows.Forms.Padding(10);
            c1TopicPage1.ImageList = null;
            c1TopicLink1.Text = "Link 1";
            c1TopicLink2.Text = "Link 2";
            c1TopicPage1.Links.Add(c1TopicLink1);
            c1TopicPage1.Links.Add(c1TopicLink2);
            c1TopicPage1.Text = "Page 1";
            c1TopicPage2.ImageList = null;
            c1TopicPage2.Text = "Page 2";
            c1TopicPage3.ImageList = null;
            c1TopicPage3.Text = "Page 3";
            this.c1TopicBar1.Pages.Add(c1TopicPage1);
            this.c1TopicBar1.Pages.Add(c1TopicPage2);
            this.c1TopicBar1.Pages.Add(c1TopicPage3);
            this.c1TopicBar1.Size = new System.Drawing.Size(282, 443);
            this.c1TopicBar1.TabIndex = 0;
            // 
            // c1CommandDock2
            // 
            this.c1CommandDock2.Controls.Add(this.c1DockingTab2);
            this.c1CommandDock2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c1CommandDock2.Id = 4;
            this.c1CommandDock2.Location = new System.Drawing.Point(300, 0);
            this.c1CommandDock2.Name = "c1CommandDock2";
            this.c1CommandDock2.Size = new System.Drawing.Size(523, 718);
            // 
            // c1DockingTab2
            // 
            this.c1DockingTab2.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.c1DockingTab2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.c1DockingTab2.CanAutoHide = true;
            this.c1DockingTab2.CanCloseTabs = true;
            this.c1DockingTab2.CanMoveTabs = true;
            this.c1DockingTab2.Controls.Add(this.c1DockingTabPage2);
            this.c1DockingTab2.Location = new System.Drawing.Point(0, 0);
            this.c1DockingTab2.Name = "c1DockingTab2";
            this.c1DockingTab2.ShowCaption = true;
            this.c1DockingTab2.Size = new System.Drawing.Size(523, 718);
            this.c1DockingTab2.TabIndex = 0;
            this.c1DockingTab2.TabSizeMode = C1.Win.C1Command.TabSizeModeEnum.Fit;
            this.c1DockingTab2.TabsSpacing = 5;
            // 
            // c1DockingTabPage2
            // 
            this.c1DockingTabPage2.CaptionVisible = true;
            this.c1DockingTabPage2.Location = new System.Drawing.Point(0, 0);
            this.c1DockingTabPage2.Name = "c1DockingTabPage2";
            this.c1DockingTabPage2.Size = new System.Drawing.Size(523, 694);
            this.c1DockingTabPage2.TabIndex = 0;
            this.c1DockingTabPage2.Text = "Page2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 718);
            this.Controls.Add(this.c1CommandDock2);
            this.Controls.Add(this.c1CommandDock1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.c1CommandDock1)).EndInit();
            this.c1CommandDock1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c1DockingManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1DockingTab1)).EndInit();
            this.c1DockingTab1.ResumeLayout(false);
            this.c1DockingTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c1TopicBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1CommandDock2)).EndInit();
            this.c1CommandDock2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c1DockingTab2)).EndInit();
            this.c1DockingTab2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.C1Command.C1CommandDock c1CommandDock1;
        private C1.Win.C1Command.C1DockingManager c1DockingManager1;
        private C1.Win.C1Command.C1DockingTab c1DockingTab1;
        private C1.Win.C1Command.C1DockingTabPage c1DockingTabPage1;
        private C1.Win.C1Command.C1TopicBar c1TopicBar1;
        private C1.Win.C1Command.C1CommandDock c1CommandDock2;
        private C1.Win.C1Command.C1DockingTab c1DockingTab2;
        private C1.Win.C1Command.C1DockingTabPage c1DockingTabPage2;
    }
}

