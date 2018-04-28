namespace Xtrim_ERP.gui
{
    partial class FrmForwarder
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
            FarPoint.Win.Spread.FlatFocusIndicatorRenderer flatFocusIndicatorRenderer1 = new FarPoint.Win.Spread.FlatFocusIndicatorRenderer();
            FarPoint.Win.Spread.FlatScrollBarRenderer flatScrollBarRenderer1 = new FarPoint.Win.Spread.FlatScrollBarRenderer();
            FarPoint.Win.Spread.FlatScrollBarRenderer flatScrollBarRenderer2 = new FarPoint.Win.Spread.FlatScrollBarRenderer();
            this.grdView = new FarPoint.Win.Spread.FpSpread();
            this.grdView_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtRemark2 = new C1.Win.C1Input.C1TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtContactName2 = new C1.Win.C1Input.C1TextBox();
            this.txtAddr4 = new C1.Win.C1Input.C1TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtAddr3 = new C1.Win.C1Input.C1TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtAddr2 = new C1.Win.C1Input.C1TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAddr1 = new C1.Win.C1Input.C1TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRemark = new C1.Win.C1Input.C1TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtEmail = new C1.Win.C1Input.C1TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtTaxId = new C1.Win.C1Input.C1TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtFax = new C1.Win.C1Input.C1TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtContactName1 = new C1.Win.C1Input.C1TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTele = new C1.Win.C1Input.C1TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFwdNameE = new C1.Win.C1Input.C1TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFwdNameT = new C1.Win.C1Input.C1TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEdit = new C1.Win.C1Input.C1Button();
            this.btnOk = new C1.Win.C1Input.C1Button();
            this.txtID = new C1.Win.C1Input.C1TextBox();
            this.txtFwdCode = new C1.Win.C1Input.C1TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.c1ThemeController1 = new C1.Win.C1Themes.C1ThemeController();
            ((System.ComponentModel.ISupportInitialize)(this.grdView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdView_Sheet1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContactName2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddr4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddr3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddr2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddr1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaxId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContactName1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTele)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFwdNameE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFwdNameT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFwdCode)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1ThemeController1)).BeginInit();
            this.SuspendLayout();
            // 
            // grdView
            // 
            this.grdView.AccessibleDescription = "";
            this.grdView.Dock = System.Windows.Forms.DockStyle.Left;
            this.grdView.FocusRenderer = flatFocusIndicatorRenderer1;
            this.grdView.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.grdView.HorizontalScrollBar.Name = "";
            flatScrollBarRenderer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdView.HorizontalScrollBar.Renderer = flatScrollBarRenderer1;
            this.grdView.Location = new System.Drawing.Point(0, 0);
            this.grdView.Name = "grdView";
            this.grdView.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.grdView_Sheet1});
            this.grdView.Size = new System.Drawing.Size(495, 738);
            this.grdView.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Office2013;
            this.grdView.TabIndex = 5;
            this.grdView.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.grdView.VerticalScrollBar.Name = "";
            flatScrollBarRenderer2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdView.VerticalScrollBar.Renderer = flatScrollBarRenderer2;
            // 
            // grdView_Sheet1
            // 
            this.grdView_Sheet1.Reset();
            this.grdView_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.grdView_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.grdView_Sheet1.ColumnFooter.DefaultStyle.BackColor = System.Drawing.Color.Empty;
            this.grdView_Sheet1.ColumnFooter.DefaultStyle.ForeColor = System.Drawing.Color.Empty;
            this.grdView_Sheet1.ColumnFooter.DefaultStyle.Parent = "ColumnFooterFlat";
            this.grdView_Sheet1.ColumnFooterSheetCornerStyle.BackColor = System.Drawing.Color.Empty;
            this.grdView_Sheet1.ColumnFooterSheetCornerStyle.ForeColor = System.Drawing.Color.Empty;
            this.grdView_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerFooterFlat";
            this.grdView_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.Empty;
            this.grdView_Sheet1.ColumnHeader.DefaultStyle.ForeColor = System.Drawing.Color.Empty;
            this.grdView_Sheet1.ColumnHeader.DefaultStyle.Parent = "ColumnHeaderFlat";
            this.grdView_Sheet1.FilterBar.DefaultStyle.BackColor = System.Drawing.Color.Empty;
            this.grdView_Sheet1.FilterBar.DefaultStyle.ForeColor = System.Drawing.Color.Empty;
            this.grdView_Sheet1.FilterBar.DefaultStyle.Parent = "FilterBarFlat";
            this.grdView_Sheet1.FilterBarHeaderStyle.BackColor = System.Drawing.Color.Empty;
            this.grdView_Sheet1.FilterBarHeaderStyle.ForeColor = System.Drawing.Color.Empty;
            this.grdView_Sheet1.FilterBarHeaderStyle.Parent = "FilterBarHeaderFlat";
            this.grdView_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.Empty;
            this.grdView_Sheet1.RowHeader.DefaultStyle.ForeColor = System.Drawing.Color.Empty;
            this.grdView_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderFlat";
            this.grdView_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.Empty;
            this.grdView_Sheet1.SheetCornerStyle.ForeColor = System.Drawing.Color.Empty;
            this.grdView_Sheet1.SheetCornerStyle.Parent = "CornerHeaderFlat";
            this.grdView_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.tabControl1.Location = new System.Drawing.Point(489, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(532, 738);
            this.tabControl1.TabIndex = 117;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(118)))), ((int)(((byte)(135)))));
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(524, 712);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.c1ThemeController1.SetTheme(this.tabPage1, "(default)");
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.txtRemark2);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtContactName2);
            this.groupBox1.Controls.Add(this.txtAddr4);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtAddr3);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtAddr2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtAddr1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtRemark);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.txtTaxId);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.txtFax);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtContactName1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtTele);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtFwdNameE);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtFwdNameT);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnEdit);
            this.groupBox1.Controls.Add(this.btnOk);
            this.groupBox1.Controls.Add(this.txtID);
            this.groupBox1.Controls.Add(this.txtFwdCode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(118)))), ((int)(((byte)(135)))));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(518, 706);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            this.c1ThemeController1.SetTheme(this.groupBox1, "(default)");
            // 
            // txtRemark2
            // 
            this.txtRemark2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.txtRemark2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemark2.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtRemark2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtRemark2.Location = new System.Drawing.Point(115, 424);
            this.txtRemark2.Name = "txtRemark2";
            this.txtRemark2.Size = new System.Drawing.Size(207, 20);
            this.txtRemark2.TabIndex = 114;
            this.txtRemark2.Tag = null;
            this.c1ThemeController1.SetTheme(this.txtRemark2, "(default)");
            this.txtRemark2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.White;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(118)))), ((int)(((byte)(135)))));
            this.label12.Location = new System.Drawing.Point(18, 424);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 16);
            this.label12.TabIndex = 113;
            this.label12.Text = "หมายเหตุ 2 :";
            this.c1ThemeController1.SetTheme(this.label12, "(default)");
            // 
            // txtContactName2
            // 
            this.txtContactName2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.txtContactName2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContactName2.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtContactName2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtContactName2.Location = new System.Drawing.Point(115, 497);
            this.txtContactName2.Name = "txtContactName2";
            this.txtContactName2.Size = new System.Drawing.Size(207, 20);
            this.txtContactName2.TabIndex = 112;
            this.txtContactName2.Tag = null;
            this.c1ThemeController1.SetTheme(this.txtContactName2, "(default)");
            this.txtContactName2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // txtAddr4
            // 
            this.txtAddr4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.txtAddr4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddr4.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtAddr4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtAddr4.Location = new System.Drawing.Point(115, 239);
            this.txtAddr4.Name = "txtAddr4";
            this.txtAddr4.Size = new System.Drawing.Size(207, 20);
            this.txtAddr4.TabIndex = 111;
            this.txtAddr4.Tag = null;
            this.c1ThemeController1.SetTheme(this.txtAddr4, "(default)");
            this.txtAddr4.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(118)))), ((int)(((byte)(135)))));
            this.label11.Location = new System.Drawing.Point(18, 239);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 16);
            this.label11.TabIndex = 110;
            this.label11.Text = "ที่อยู่ 4 :";
            this.c1ThemeController1.SetTheme(this.label11, "(default)");
            // 
            // txtAddr3
            // 
            this.txtAddr3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.txtAddr3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddr3.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtAddr3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtAddr3.Location = new System.Drawing.Point(115, 213);
            this.txtAddr3.Name = "txtAddr3";
            this.txtAddr3.Size = new System.Drawing.Size(207, 20);
            this.txtAddr3.TabIndex = 109;
            this.txtAddr3.Tag = null;
            this.c1ThemeController1.SetTheme(this.txtAddr3, "(default)");
            this.txtAddr3.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(118)))), ((int)(((byte)(135)))));
            this.label9.Location = new System.Drawing.Point(18, 213);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 16);
            this.label9.TabIndex = 108;
            this.label9.Text = "ที่อยู่ 3 :";
            this.c1ThemeController1.SetTheme(this.label9, "(default)");
            // 
            // txtAddr2
            // 
            this.txtAddr2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.txtAddr2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddr2.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtAddr2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtAddr2.Location = new System.Drawing.Point(115, 187);
            this.txtAddr2.Name = "txtAddr2";
            this.txtAddr2.Size = new System.Drawing.Size(207, 20);
            this.txtAddr2.TabIndex = 107;
            this.txtAddr2.Tag = null;
            this.c1ThemeController1.SetTheme(this.txtAddr2, "(default)");
            this.txtAddr2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(118)))), ((int)(((byte)(135)))));
            this.label6.Location = new System.Drawing.Point(18, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 16);
            this.label6.TabIndex = 106;
            this.label6.Text = "ที่อยู่ 2 :";
            this.c1ThemeController1.SetTheme(this.label6, "(default)");
            // 
            // txtAddr1
            // 
            this.txtAddr1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.txtAddr1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddr1.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtAddr1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtAddr1.Location = new System.Drawing.Point(115, 161);
            this.txtAddr1.Name = "txtAddr1";
            this.txtAddr1.Size = new System.Drawing.Size(207, 20);
            this.txtAddr1.TabIndex = 105;
            this.txtAddr1.Tag = null;
            this.c1ThemeController1.SetTheme(this.txtAddr1, "(default)");
            this.txtAddr1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(118)))), ((int)(((byte)(135)))));
            this.label4.Location = new System.Drawing.Point(18, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 16);
            this.label4.TabIndex = 104;
            this.label4.Text = "ที่อยู่ 1 :";
            this.c1ThemeController1.SetTheme(this.label4, "(default)");
            // 
            // txtRemark
            // 
            this.txtRemark.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.txtRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemark.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtRemark.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtRemark.Location = new System.Drawing.Point(115, 398);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(207, 20);
            this.txtRemark.TabIndex = 103;
            this.txtRemark.Tag = null;
            this.c1ThemeController1.SetTheme(this.txtRemark, "(default)");
            this.txtRemark.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.White;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(118)))), ((int)(((byte)(135)))));
            this.label22.Location = new System.Drawing.Point(18, 398);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(58, 16);
            this.label22.TabIndex = 102;
            this.label22.Text = "หมายเหตุ :";
            this.c1ThemeController1.SetTheme(this.label22, "(default)");
            // 
            // txtEmail
            // 
            this.txtEmail.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtEmail.Location = new System.Drawing.Point(115, 344);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(207, 20);
            this.txtEmail.TabIndex = 101;
            this.txtEmail.Tag = null;
            this.c1ThemeController1.SetTheme(this.txtEmail, "(default)");
            this.txtEmail.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.White;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(118)))), ((int)(((byte)(135)))));
            this.label23.Location = new System.Drawing.Point(18, 344);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(48, 16);
            this.label23.TabIndex = 100;
            this.label23.Text = "Email :";
            this.c1ThemeController1.SetTheme(this.label23, "(default)");
            // 
            // txtTaxId
            // 
            this.txtTaxId.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.txtTaxId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTaxId.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtTaxId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtTaxId.Location = new System.Drawing.Point(115, 370);
            this.txtTaxId.Name = "txtTaxId";
            this.txtTaxId.Size = new System.Drawing.Size(207, 20);
            this.txtTaxId.TabIndex = 97;
            this.txtTaxId.Tag = null;
            this.c1ThemeController1.SetTheme(this.txtTaxId, "(default)");
            this.txtTaxId.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.White;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(118)))), ((int)(((byte)(135)))));
            this.label20.Location = new System.Drawing.Point(18, 370);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(51, 16);
            this.label20.TabIndex = 96;
            this.label20.Text = "Tax Id :";
            this.c1ThemeController1.SetTheme(this.label20, "(default)");
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.White;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(118)))), ((int)(((byte)(135)))));
            this.label17.Location = new System.Drawing.Point(18, 473);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(58, 16);
            this.label17.TabIndex = 92;
            this.label17.Text = "ผู้ติดต่อ 1 :";
            this.c1ThemeController1.SetTheme(this.label17, "(default)");
            // 
            // txtFax
            // 
            this.txtFax.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.txtFax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFax.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtFax.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtFax.Location = new System.Drawing.Point(115, 318);
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(207, 20);
            this.txtFax.TabIndex = 75;
            this.txtFax.Tag = null;
            this.c1ThemeController1.SetTheme(this.txtFax, "(default)");
            this.txtFax.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(118)))), ((int)(((byte)(135)))));
            this.label10.Location = new System.Drawing.Point(18, 318);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 16);
            this.label10.TabIndex = 74;
            this.label10.Text = "Fax :";
            this.c1ThemeController1.SetTheme(this.label10, "(default)");
            // 
            // txtContactName1
            // 
            this.txtContactName1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.txtContactName1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContactName1.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtContactName1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtContactName1.Location = new System.Drawing.Point(115, 471);
            this.txtContactName1.Name = "txtContactName1";
            this.txtContactName1.Size = new System.Drawing.Size(207, 20);
            this.txtContactName1.TabIndex = 71;
            this.txtContactName1.Tag = null;
            this.c1ThemeController1.SetTheme(this.txtContactName1, "(default)");
            this.txtContactName1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(118)))), ((int)(((byte)(135)))));
            this.label7.Location = new System.Drawing.Point(18, 499);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 16);
            this.label7.TabIndex = 70;
            this.label7.Text = "ผู้ติดต่อ 2 :";
            this.c1ThemeController1.SetTheme(this.label7, "(default)");
            // 
            // txtTele
            // 
            this.txtTele.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.txtTele.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTele.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtTele.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtTele.Location = new System.Drawing.Point(115, 292);
            this.txtTele.Name = "txtTele";
            this.txtTele.Size = new System.Drawing.Size(207, 20);
            this.txtTele.TabIndex = 67;
            this.txtTele.Tag = null;
            this.c1ThemeController1.SetTheme(this.txtTele, "(default)");
            this.txtTele.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(118)))), ((int)(((byte)(135)))));
            this.label5.Location = new System.Drawing.Point(18, 292);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 16);
            this.label5.TabIndex = 66;
            this.label5.Text = "โทรศัพท์ :";
            this.c1ThemeController1.SetTheme(this.label5, "(default)");
            // 
            // txtFwdNameE
            // 
            this.txtFwdNameE.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.txtFwdNameE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFwdNameE.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtFwdNameE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtFwdNameE.Location = new System.Drawing.Point(115, 122);
            this.txtFwdNameE.Name = "txtFwdNameE";
            this.txtFwdNameE.Size = new System.Drawing.Size(207, 20);
            this.txtFwdNameE.TabIndex = 63;
            this.txtFwdNameE.Tag = null;
            this.c1ThemeController1.SetTheme(this.txtFwdNameE, "(default)");
            this.txtFwdNameE.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(118)))), ((int)(((byte)(135)))));
            this.label3.Location = new System.Drawing.Point(18, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 16);
            this.label3.TabIndex = 62;
            this.label3.Text = "ชื่ออังกฤษ :";
            this.c1ThemeController1.SetTheme(this.label3, "(default)");
            // 
            // txtFwdNameT
            // 
            this.txtFwdNameT.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.txtFwdNameT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFwdNameT.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtFwdNameT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtFwdNameT.Location = new System.Drawing.Point(115, 96);
            this.txtFwdNameT.Name = "txtFwdNameT";
            this.txtFwdNameT.Size = new System.Drawing.Size(207, 20);
            this.txtFwdNameT.TabIndex = 61;
            this.txtFwdNameT.Tag = null;
            this.c1ThemeController1.SetTheme(this.txtFwdNameT, "(default)");
            this.txtFwdNameT.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(118)))), ((int)(((byte)(135)))));
            this.label2.Location = new System.Drawing.Point(18, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 16);
            this.label2.TabIndex = 60;
            this.label2.Text = "ชื่อไทย :";
            this.c1ThemeController1.SetTheme(this.label2, "(default)");
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(394, 56);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(118, 37);
            this.btnEdit.TabIndex = 59;
            this.btnEdit.Text = "แก้ไขช้อมูล";
            this.c1ThemeController1.SetTheme(this.btnEdit, "(default)");
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(394, 416);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(118, 37);
            this.btnOk.TabIndex = 58;
            this.btnOk.Text = "บันทึกช้อมูล";
            this.c1ThemeController1.SetTheme(this.btnOk, "(default)");
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtID
            // 
            this.txtID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtID.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtID.Location = new System.Drawing.Point(328, 30);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(66, 20);
            this.txtID.TabIndex = 57;
            this.txtID.Tag = null;
            this.c1ThemeController1.SetTheme(this.txtID, "(default)");
            this.txtID.Visible = false;
            this.txtID.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // txtFwdCode
            // 
            this.txtFwdCode.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.txtFwdCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFwdCode.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtFwdCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtFwdCode.Location = new System.Drawing.Point(115, 30);
            this.txtFwdCode.Name = "txtFwdCode";
            this.txtFwdCode.Size = new System.Drawing.Size(207, 20);
            this.txtFwdCode.TabIndex = 56;
            this.txtFwdCode.Tag = null;
            this.c1ThemeController1.SetTheme(this.txtFwdCode, "(default)");
            this.txtFwdCode.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(118)))), ((int)(((byte)(135)))));
            this.label1.Location = new System.Drawing.Point(18, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 16);
            this.label1.TabIndex = 55;
            this.label1.Text = "รหัส :";
            this.c1ThemeController1.SetTheme(this.label1, "(default)");
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(118)))), ((int)(((byte)(135)))));
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(524, 712);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.c1ThemeController1.SetTheme(this.tabPage2, "(default)");
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(118)))), ((int)(((byte)(135)))));
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(518, 706);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            this.c1ThemeController1.SetTheme(this.groupBox2, "(default)");
            // 
            // FrmForwarder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 738);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.grdView);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(118)))), ((int)(((byte)(135)))));
            this.Name = "FrmForwarder";
            this.Text = "FrmForwarder";
            this.c1ThemeController1.SetTheme(this, "(default)");
            this.Load += new System.EventHandler(this.FrmForwarder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdView_Sheet1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContactName2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddr4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddr3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddr2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddr1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaxId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContactName1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTele)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFwdNameE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFwdNameT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFwdCode)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1ThemeController1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FarPoint.Win.Spread.FpSpread grdView;
        private FarPoint.Win.Spread.SheetView grdView_Sheet1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private C1.Win.C1Input.C1TextBox txtRemark2;
        private System.Windows.Forms.Label label12;
        private C1.Win.C1Input.C1TextBox txtContactName2;
        private C1.Win.C1Input.C1TextBox txtAddr4;
        private System.Windows.Forms.Label label11;
        private C1.Win.C1Input.C1TextBox txtAddr3;
        private System.Windows.Forms.Label label9;
        private C1.Win.C1Input.C1TextBox txtAddr2;
        private System.Windows.Forms.Label label6;
        private C1.Win.C1Input.C1TextBox txtAddr1;
        private System.Windows.Forms.Label label4;
        private C1.Win.C1Input.C1TextBox txtRemark;
        private System.Windows.Forms.Label label22;
        private C1.Win.C1Input.C1TextBox txtEmail;
        private System.Windows.Forms.Label label23;
        private C1.Win.C1Input.C1TextBox txtTaxId;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label17;
        private C1.Win.C1Input.C1TextBox txtFax;
        private System.Windows.Forms.Label label10;
        private C1.Win.C1Input.C1TextBox txtContactName1;
        private System.Windows.Forms.Label label7;
        private C1.Win.C1Input.C1TextBox txtTele;
        private System.Windows.Forms.Label label5;
        private C1.Win.C1Input.C1TextBox txtFwdNameE;
        private System.Windows.Forms.Label label3;
        private C1.Win.C1Input.C1TextBox txtFwdNameT;
        private System.Windows.Forms.Label label2;
        private C1.Win.C1Input.C1Button btnEdit;
        private C1.Win.C1Input.C1Button btnOk;
        private C1.Win.C1Input.C1TextBox txtID;
        private C1.Win.C1Input.C1TextBox txtFwdCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox2;
        private C1.Win.C1Themes.C1ThemeController c1ThemeController1;
    }
}