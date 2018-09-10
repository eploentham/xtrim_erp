namespace Xtrim_ERP.gui
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.c1ThemeController1 = new C1.Win.C1Themes.C1ThemeController();
            this.c1CommandDock1 = new C1.Win.C1Command.C1CommandDock();
            this.c1SuperTooltip1 = new C1.Win.C1SuperTooltip.C1SuperTooltip(this.components);
            this.c1SuperTooltip2 = new C1.Win.C1SuperTooltip.C1SuperTooltip(this.components);
            this.c1SuperErrorProvider1 = new C1.Win.C1SuperTooltip.C1SuperErrorProvider(this.components);
            this.c1Combo1 = new C1.Win.C1List.C1Combo();
            this.c1ThemeController2 = new C1.Win.C1Themes.C1ThemeController();
            this.c1SuperTooltip3 = new C1.Win.C1SuperTooltip.C1SuperTooltip(this.components);
            this.c1SuperErrorProvider2 = new C1.Win.C1SuperTooltip.C1SuperErrorProvider(this.components);
            this.c1FlexGrid1 = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.c1Button1 = new C1.Win.C1Input.C1Button();
            this.c1CommandDock2 = new C1.Win.C1Command.C1CommandDock();
            this.c1DockingTab1 = new C1.Win.C1Command.C1DockingTab();
            this.c1DockingTabPage1 = new C1.Win.C1Command.C1DockingTabPage();
            ((System.ComponentModel.ISupportInitialize)(this.c1ThemeController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1CommandDock1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1SuperErrorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Combo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1ThemeController2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1SuperErrorProvider2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Button1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1CommandDock2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1DockingTab1)).BeginInit();
            this.c1DockingTab1.SuspendLayout();
            this.SuspendLayout();
            // 
            // c1CommandDock1
            // 
            this.c1CommandDock1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(87)))), ((int)(((byte)(87)))));
            this.c1CommandDock1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.c1CommandDock1.Id = 1;
            this.c1CommandDock1.Location = new System.Drawing.Point(0, 0);
            this.c1CommandDock1.Name = "c1CommandDock1";
            this.c1CommandDock1.Size = new System.Drawing.Size(800, 32);
            this.c1ThemeController1.SetTheme(this.c1CommandDock1, "(default)");
            // 
            // c1SuperTooltip1
            // 
            this.c1SuperTooltip1.BackgroundGradient = C1.Win.C1SuperTooltip.BackgroundGradient.None;
            this.c1SuperTooltip1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.c1SuperTooltip1.RightToLeft = System.Windows.Forms.RightToLeft.Inherit;
            this.c1ThemeController1.SetTheme(this.c1SuperTooltip1, "(default)");
            // 
            // c1SuperTooltip2
            // 
            this.c1SuperTooltip2.BackgroundGradient = C1.Win.C1SuperTooltip.BackgroundGradient.None;
            this.c1SuperTooltip2.Font = new System.Drawing.Font("Tahoma", 8F);
            this.c1SuperTooltip2.RightToLeft = System.Windows.Forms.RightToLeft.Inherit;
            this.c1ThemeController1.SetTheme(this.c1SuperTooltip2, "(default)");
            // 
            // c1SuperErrorProvider1
            // 
            this.c1SuperErrorProvider1.ContainerControl = this;
            this.c1ThemeController1.SetTheme(this.c1SuperErrorProvider1, "(default)");
            this.c1SuperErrorProvider1.ToolTip = this.c1SuperTooltip1;
            // 
            // c1Combo1
            // 
            this.c1Combo1.AddItemSeparator = ';';
            this.c1Combo1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.c1Combo1.Caption = "";
            this.c1Combo1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.c1Combo1.DeadAreaBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.c1Combo1.EditorBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(87)))), ((int)(((byte)(87)))));
            this.c1Combo1.EditorFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c1Combo1.EditorForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.c1Combo1.FlatStyle = C1.Win.C1List.FlatModeEnum.Flat;
            this.c1Combo1.Images.Add(((System.Drawing.Image)(resources.GetObject("c1Combo1.Images"))));
            this.c1Combo1.Location = new System.Drawing.Point(12, 105);
            this.c1Combo1.MatchEntryTimeout = ((long)(2000));
            this.c1Combo1.MaxDropDownItems = ((short)(5));
            this.c1Combo1.MaxLength = 32767;
            this.c1Combo1.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.c1Combo1.Name = "c1Combo1";
            this.c1Combo1.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.c1Combo1.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.c1Combo1.Size = new System.Drawing.Size(121, 19);
            this.c1Combo1.TabIndex = 0;
            this.c1Combo1.Text = "c1Combo1";
            this.c1ThemeController1.SetTheme(this.c1Combo1, "(default)");
            this.c1Combo1.PropBag = resources.GetString("c1Combo1.PropBag");
            // 
            // c1SuperTooltip3
            // 
            this.c1SuperTooltip3.BackgroundGradient = C1.Win.C1SuperTooltip.BackgroundGradient.None;
            this.c1SuperTooltip3.Font = new System.Drawing.Font("Tahoma", 8F);
            this.c1SuperTooltip3.RightToLeft = System.Windows.Forms.RightToLeft.Inherit;
            this.c1ThemeController2.SetTheme(this.c1SuperTooltip3, "(default)");
            this.c1ThemeController1.SetTheme(this.c1SuperTooltip3, "(default)");
            // 
            // c1SuperErrorProvider2
            // 
            this.c1SuperErrorProvider2.ContainerControl = this;
            this.c1ThemeController2.SetTheme(this.c1SuperErrorProvider2, "(default)");
            this.c1ThemeController1.SetTheme(this.c1SuperErrorProvider2, "(default)");
            this.c1SuperErrorProvider2.ToolTip = this.c1SuperTooltip1;
            // 
            // c1FlexGrid1
            // 
            this.c1FlexGrid1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.c1FlexGrid1.ColumnInfo = "10,1,0,0,0,95,Columns:";
            this.c1FlexGrid1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.c1FlexGrid1.Location = new System.Drawing.Point(274, 55);
            this.c1FlexGrid1.Name = "c1FlexGrid1";
            this.c1FlexGrid1.Rows.DefaultSize = 19;
            this.c1FlexGrid1.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None;
            this.c1FlexGrid1.Size = new System.Drawing.Size(240, 150);
            this.c1FlexGrid1.StyleInfo = resources.GetString("c1FlexGrid1.StyleInfo");
            this.c1FlexGrid1.TabIndex = 12;
            this.c1ThemeController1.SetTheme(this.c1FlexGrid1, "(default)");
            this.c1ThemeController2.SetTheme(this.c1FlexGrid1, "(default)");
            this.c1FlexGrid1.Tree.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            // 
            // c1Button1
            // 
            this.c1Button1.Location = new System.Drawing.Point(12, 130);
            this.c1Button1.Name = "c1Button1";
            this.c1Button1.Size = new System.Drawing.Size(75, 23);
            this.c1Button1.TabIndex = 13;
            this.c1Button1.Text = "c1Button1";
            this.c1ThemeController2.SetTheme(this.c1Button1, "(default)");
            this.c1ThemeController1.SetTheme(this.c1Button1, "(default)");
            this.c1Button1.UseVisualStyleBackColor = true;
            this.c1Button1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // c1CommandDock2
            // 
            this.c1CommandDock2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(87)))), ((int)(((byte)(87)))));
            this.c1CommandDock2.Dock = System.Windows.Forms.DockStyle.Left;
            this.c1CommandDock2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.c1CommandDock2.Id = 2;
            this.c1CommandDock2.Location = new System.Drawing.Point(0, 32);
            this.c1CommandDock2.Name = "c1CommandDock2";
            this.c1CommandDock2.Size = new System.Drawing.Size(300, 418);
            this.c1ThemeController2.SetTheme(this.c1CommandDock2, "(default)");
            this.c1ThemeController1.SetTheme(this.c1CommandDock2, "(default)");
            // 
            // c1DockingTab1
            // 
            this.c1DockingTab1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.c1DockingTab1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(87)))), ((int)(((byte)(87)))));
            this.c1DockingTab1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.c1DockingTab1.CanAutoHide = true;
            this.c1DockingTab1.CanCloseTabs = true;
            this.c1DockingTab1.CanMoveTabs = true;
            this.c1DockingTab1.Controls.Add(this.c1DockingTabPage1);
            this.c1DockingTab1.HotTrack = true;
            this.c1DockingTab1.Location = new System.Drawing.Point(0, 0);
            this.c1DockingTab1.Name = "c1DockingTab1";
            this.c1DockingTab1.ShowCaption = true;
            this.c1DockingTab1.Size = new System.Drawing.Size(300, 418);
            this.c1DockingTab1.TabIndex = 0;
            this.c1DockingTab1.TabSizeMode = C1.Win.C1Command.TabSizeModeEnum.Fit;
            this.c1DockingTab1.TabsShowFocusCues = false;
            this.c1DockingTab1.TabsSpacing = 2;
            this.c1DockingTab1.TabStyle = C1.Win.C1Command.TabStyleEnum.Office2007;
            this.c1ThemeController1.SetTheme(this.c1DockingTab1, "(default)");
            this.c1ThemeController2.SetTheme(this.c1DockingTab1, "(default)");
            // 
            // c1DockingTabPage1
            // 
            this.c1DockingTabPage1.CaptionVisible = true;
            this.c1DockingTabPage1.Location = new System.Drawing.Point(0, 0);
            this.c1DockingTabPage1.Name = "c1DockingTabPage1";
            this.c1DockingTabPage1.Size = new System.Drawing.Size(300, 394);
            this.c1DockingTabPage1.TabIndex = 0;
            this.c1DockingTabPage1.Text = "Page1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.c1DockingTab1);
            this.Controls.Add(this.c1CommandDock2);
            this.Controls.Add(this.c1Button1);
            this.Controls.Add(this.c1FlexGrid1);
            this.Controls.Add(this.c1Combo1);
            this.Controls.Add(this.c1CommandDock1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.c1ThemeController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1CommandDock1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1SuperErrorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Combo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1ThemeController2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1SuperErrorProvider2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Button1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1CommandDock2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1DockingTab1)).EndInit();
            this.c1DockingTab1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private C1.Win.C1Themes.C1ThemeController c1ThemeController1;
        private C1.Win.C1Command.C1CommandDock c1CommandDock1;
        private C1.Win.C1SuperTooltip.C1SuperTooltip c1SuperTooltip1;
        private C1.Win.C1SuperTooltip.C1SuperTooltip c1SuperTooltip2;
        private C1.Win.C1SuperTooltip.C1SuperErrorProvider c1SuperErrorProvider1;
        private C1.Win.C1List.C1Combo c1Combo1;
        private C1.Win.C1Themes.C1ThemeController c1ThemeController2;
        private C1.Win.C1SuperTooltip.C1SuperTooltip c1SuperTooltip3;
        private C1.Win.C1SuperTooltip.C1SuperErrorProvider c1SuperErrorProvider2;
        private C1.Win.C1Input.C1Button c1Button1;
        private C1.Win.C1FlexGrid.C1FlexGrid c1FlexGrid1;
        private C1.Win.C1Command.C1DockingTab c1DockingTab1;
        private C1.Win.C1Command.C1DockingTabPage c1DockingTabPage1;
        private C1.Win.C1Command.C1CommandDock c1CommandDock2;
    }
}