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
            this.c1FlexGrid1 = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.c1MainMenu1 = new C1.Win.C1Command.C1MainMenu();
            this.c1CommandLink1 = new C1.Win.C1Command.C1CommandLink();
            this.c1CommandLink2 = new C1.Win.C1Command.C1CommandLink();
            this.c1CommandLink3 = new C1.Win.C1Command.C1CommandLink();
            this.c1CommandMenu1 = new C1.Win.C1Command.C1CommandMenu();
            this.c1CommandLink7 = new C1.Win.C1Command.C1CommandLink();
            this.c1Command1 = new C1.Win.C1Command.C1Command();
            this.c1CommandLink4 = new C1.Win.C1Command.C1CommandLink();
            this.c1CommandLink5 = new C1.Win.C1Command.C1CommandLink();
            this.c1CommandMenu2 = new C1.Win.C1Command.C1CommandMenu();
            this.c1CommandLink8 = new C1.Win.C1Command.C1CommandLink();
            this.c1Command2 = new C1.Win.C1Command.C1Command();
            this.c1CommandLink6 = new C1.Win.C1Command.C1CommandLink();
            this.c1CommandHolder1 = new C1.Win.C1Command.C1CommandHolder();
            this.txtContFNameT = new C1.Win.C1Input.C1TextBox();
            this.c1FlexReport1 = new C1.Win.FlexReport.C1FlexReport();
            this.c1DropDownControl1 = new C1.Win.C1Input.C1DropDownControl();
            this.c1DockingManager1 = new C1.Win.C1Command.C1DockingManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1CommandHolder1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContFNameT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1DropDownControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1DockingManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // c1FlexGrid1
            // 
            this.c1FlexGrid1.ColumnInfo = "10,1,0,0,0,95,Columns:";
            this.c1FlexGrid1.Location = new System.Drawing.Point(51, 130);
            this.c1FlexGrid1.Name = "c1FlexGrid1";
            this.c1FlexGrid1.Rows.DefaultSize = 19;
            this.c1FlexGrid1.Size = new System.Drawing.Size(240, 150);
            this.c1FlexGrid1.TabIndex = 0;
            this.c1FlexGrid1.GridChanged += new C1.Win.C1FlexGrid.GridChangedEventHandler(this.c1FlexGrid1_GridChanged);
            this.c1FlexGrid1.AfterRowColChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.c1FlexGrid1_AfterRowColChange);
            this.c1FlexGrid1.RowColChange += new System.EventHandler(this.c1FlexGrid1_RowColChange);
            this.c1FlexGrid1.LeaveCell += new System.EventHandler(this.c1FlexGrid1_LeaveCell);
            this.c1FlexGrid1.EnterCell += new System.EventHandler(this.c1FlexGrid1_EnterCell);
            this.c1FlexGrid1.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.c1FlexGrid1_CellButtonClick);
            this.c1FlexGrid1.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.c1FlexGrid1_CellChanged);
            this.c1FlexGrid1.CursorChanged += new System.EventHandler(this.c1FlexGrid1_CursorChanged);
            this.c1FlexGrid1.LocationChanged += new System.EventHandler(this.c1FlexGrid1_LocationChanged);
            this.c1FlexGrid1.Click += new System.EventHandler(this.c1FlexGrid1_Click);
            this.c1FlexGrid1.DoubleClick += new System.EventHandler(this.c1FlexGrid1_DoubleClick);
            // 
            // c1MainMenu1
            // 
            this.c1MainMenu1.AccessibleName = "Menu Bar";
            this.c1MainMenu1.CommandHolder = null;
            this.c1MainMenu1.CommandLinks.AddRange(new C1.Win.C1Command.C1CommandLink[] {
            this.c1CommandLink1,
            this.c1CommandLink2,
            this.c1CommandLink3,
            this.c1CommandLink5});
            this.c1MainMenu1.Dock = System.Windows.Forms.DockStyle.Top;
            this.c1MainMenu1.Location = new System.Drawing.Point(0, 0);
            this.c1MainMenu1.Name = "c1MainMenu1";
            this.c1MainMenu1.Size = new System.Drawing.Size(1273, 27);
            // 
            // c1CommandLink1
            // 
            this.c1CommandLink1.Text = "Exit";
            // 
            // c1CommandLink2
            // 
            this.c1CommandLink2.SortOrder = 1;
            // 
            // c1CommandLink3
            // 
            this.c1CommandLink3.Command = this.c1CommandMenu1;
            this.c1CommandLink3.SortOrder = 2;
            this.c1CommandLink3.Text = "Import";
            // 
            // c1CommandMenu1
            // 
            this.c1CommandMenu1.CommandLinks.AddRange(new C1.Win.C1Command.C1CommandLink[] {
            this.c1CommandLink7,
            this.c1CommandLink4});
            this.c1CommandMenu1.HideNonRecentLinks = false;
            this.c1CommandMenu1.Name = "c1CommandMenu1";
            this.c1CommandMenu1.ShortcutText = "";
            this.c1CommandMenu1.Text = "New Command";
            // 
            // c1CommandLink7
            // 
            this.c1CommandLink7.Command = this.c1Command1;
            // 
            // c1Command1
            // 
            this.c1Command1.Name = "c1Command1";
            this.c1Command1.ShortcutText = "";
            this.c1Command1.Text = "New Command";
            // 
            // c1CommandLink4
            // 
            this.c1CommandLink4.SortOrder = 1;
            this.c1CommandLink4.Text = "New Command";
            // 
            // c1CommandLink5
            // 
            this.c1CommandLink5.Command = this.c1CommandMenu2;
            this.c1CommandLink5.SortOrder = 3;
            this.c1CommandLink5.Text = "Export";
            // 
            // c1CommandMenu2
            // 
            this.c1CommandMenu2.CommandLinks.AddRange(new C1.Win.C1Command.C1CommandLink[] {
            this.c1CommandLink8,
            this.c1CommandLink6});
            this.c1CommandMenu2.HideNonRecentLinks = false;
            this.c1CommandMenu2.Name = "c1CommandMenu2";
            this.c1CommandMenu2.ShortcutText = "";
            this.c1CommandMenu2.Text = "New Command";
            // 
            // c1CommandLink8
            // 
            this.c1CommandLink8.Command = this.c1Command2;
            // 
            // c1Command2
            // 
            this.c1Command2.Name = "c1Command2";
            this.c1Command2.ShortcutText = "";
            this.c1Command2.Text = "New Command";
            // 
            // c1CommandLink6
            // 
            this.c1CommandLink6.SortOrder = 1;
            this.c1CommandLink6.Text = "New Command";
            // 
            // c1CommandHolder1
            // 
            this.c1CommandHolder1.Commands.Add(this.c1CommandMenu1);
            this.c1CommandHolder1.Commands.Add(this.c1CommandMenu2);
            this.c1CommandHolder1.Commands.Add(this.c1Command1);
            this.c1CommandHolder1.Commands.Add(this.c1Command2);
            this.c1CommandHolder1.Owner = this;
            // 
            // txtContFNameT
            // 
            this.txtContFNameT.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.txtContFNameT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContFNameT.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtContFNameT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtContFNameT.Location = new System.Drawing.Point(32, 51);
            this.txtContFNameT.Name = "txtContFNameT";
            this.txtContFNameT.Size = new System.Drawing.Size(207, 20);
            this.txtContFNameT.TabIndex = 65;
            this.txtContFNameT.Tag = null;
            this.txtContFNameT.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            this.txtContFNameT.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtContFNameT_KeyUp);
            // 
            // c1FlexReport1
            // 
            this.c1FlexReport1.ReportDefinition = resources.GetString("c1FlexReport1.ReportDefinition");
            // 
            // c1DropDownControl1
            // 
            this.c1DropDownControl1.ImagePadding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.c1DropDownControl1.Location = new System.Drawing.Point(276, 53);
            this.c1DropDownControl1.Name = "c1DropDownControl1";
            this.c1DropDownControl1.Size = new System.Drawing.Size(200, 18);
            this.c1DropDownControl1.TabIndex = 67;
            this.c1DropDownControl1.Tag = null;
            // 
            // c1DockingManager1
            // 
            this.c1DockingManager1.ParentContainer = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1273, 736);
            this.Controls.Add(this.c1DropDownControl1);
            this.Controls.Add(this.txtContFNameT);
            this.Controls.Add(this.c1FlexGrid1);
            this.Controls.Add(this.c1MainMenu1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1CommandHolder1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContFNameT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1DropDownControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1DockingManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.C1FlexGrid.C1FlexGrid c1FlexGrid1;
        private C1.Win.C1Command.C1MainMenu c1MainMenu1;
        private C1.Win.C1Command.C1CommandLink c1CommandLink1;
        private C1.Win.C1Command.C1CommandLink c1CommandLink2;
        private C1.Win.C1Command.C1CommandLink c1CommandLink3;
        private C1.Win.C1Command.C1CommandMenu c1CommandMenu1;
        private C1.Win.C1Command.C1CommandLink c1CommandLink7;
        private C1.Win.C1Command.C1Command c1Command1;
        private C1.Win.C1Command.C1CommandLink c1CommandLink4;
        private C1.Win.C1Command.C1CommandLink c1CommandLink5;
        private C1.Win.C1Command.C1CommandMenu c1CommandMenu2;
        private C1.Win.C1Command.C1CommandLink c1CommandLink8;
        private C1.Win.C1Command.C1Command c1Command2;
        private C1.Win.C1Command.C1CommandLink c1CommandLink6;
        private C1.Win.C1Command.C1CommandHolder c1CommandHolder1;
        private C1.Win.C1Input.C1TextBox txtContFNameT;
        private C1.Win.FlexReport.C1FlexReport c1FlexReport1;
        private C1.Win.C1Input.C1DropDownControl c1DropDownControl1;
        private C1.Win.C1Command.C1DockingManager c1DockingManager1;
    }
}