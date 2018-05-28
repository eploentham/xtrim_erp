namespace Xtrim_ERP.RichTextEditor.AppMenuTabs.Items
{
    partial class AppMenuTabFileList
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.c1InputPanel1 = new C1.Win.C1InputPanel.C1InputPanel();
            this.c1ThemeController1 = new C1.Win.C1Themes.C1ThemeController();
            this.appMenuTabButton1 = new RichTextEditor.AppMenuTabs.Items.AppMenuTabButton();
            this.lblCaption = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.c1InputPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1ThemeController1)).BeginInit();
            this.SuspendLayout();
            // 
            // c1InputPanel1
            // 
            this.c1InputPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.c1InputPanel1.AutoSizeElement = C1.Framework.AutoSizeElement.Both;
            this.c1InputPanel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.c1InputPanel1.Location = new System.Drawing.Point(22, 121);
            this.c1InputPanel1.Name = "c1InputPanel1";
            this.c1InputPanel1.Size = new System.Drawing.Size(540, 167);
            this.c1InputPanel1.TabIndex = 2;
            this.c1ThemeController1.SetTheme(this.c1InputPanel1, "(default)");
            this.c1InputPanel1.VisualStyle = C1.Win.C1InputPanel.VisualStyle.Custom;
            // 
            // c1ThemeController1
            // 
            this.c1ThemeController1.Theme = "Office2016DarkGray";
            // 
            // appMenuTabButton1
            // 
            this.appMenuTabButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.appMenuTabButton1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.appMenuTabButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.appMenuTabButton1.ItemImage = null;
            this.appMenuTabButton1.ItemText = "label1";
            this.appMenuTabButton1.Location = new System.Drawing.Point(32, 75);
            this.appMenuTabButton1.Name = "appMenuTabButton1";
            this.appMenuTabButton1.Size = new System.Drawing.Size(380, 40);
            this.appMenuTabButton1.TabIndex = 0;
            this.c1ThemeController1.SetTheme(this.appMenuTabButton1, "(default)");
            this.appMenuTabButton1.Click += new System.EventHandler(this.menuButton1_Click);
            // 
            // lblCaption
            // 
            this.lblCaption.AutoSize = true;
            this.lblCaption.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.lblCaption.Location = new System.Drawing.Point(21, 7);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(155, 65);
            this.lblCaption.TabIndex = 2;
            this.lblCaption.Text = "label1";
            // 
            // AppMenuTabFileList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.Controls.Add(this.lblCaption);
            this.Controls.Add(this.c1InputPanel1);
            this.Controls.Add(this.appMenuTabButton1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.Name = "AppMenuTabFileList";
            this.Size = new System.Drawing.Size(579, 291);
            this.c1ThemeController1.SetTheme(this, "(default)");
            ((System.ComponentModel.ISupportInitialize)(this.c1InputPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1ThemeController1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AppMenuTabButton appMenuTabButton1;
        private C1.Win.C1InputPanel.C1InputPanel c1InputPanel1;
        private C1.Win.C1Themes.C1ThemeController c1ThemeController1;
        private System.Windows.Forms.Label lblCaption;
    }
}
