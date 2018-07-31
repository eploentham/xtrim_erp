namespace Xtrim_ERP.gui
{
    partial class FrmExpenseReceiptCash1
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
            this.sB = new System.Windows.Forms.StatusStrip();
            this.sB1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.theme1 = new C1.Win.C1Themes.C1ThemeController();
            this.cdLeft = new C1.Win.C1Command.C1CommandDock();
            this.c1DockingTab1 = new C1.Win.C1Command.C1DockingTab();
            this.c1DockingTabPage1 = new C1.Win.C1Command.C1DockingTabPage();
            this.gbPd = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtID = new C1.Win.C1Input.C1TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEccDoc = new C1.Win.C1Input.C1TextBox();
            this.btnDoc = new C1.Win.C1Input.C1Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEccAmt = new C1.Win.C1Input.C1TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRefundPay = new C1.Win.C1Input.C1TextBox();
            this.label106 = new System.Windows.Forms.Label();
            this.txtUserAmt = new C1.Win.C1Input.C1TextBox();
            this.cboStaff = new C1.Win.C1Input.C1ComboBox();
            this.label105 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.gbRefund = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnRefund = new C1.Win.C1Input.C1Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.gbEcc = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnSave = new C1.Win.C1Input.C1Button();
            this.btnDNew = new C1.Win.C1Input.C1Button();
            this.sB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.theme1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdLeft)).BeginInit();
            this.cdLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1DockingTab1)).BeginInit();
            this.c1DockingTab1.SuspendLayout();
            this.c1DockingTabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEccDoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEccAmt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRefundPay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserAmt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStaff)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefund)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDNew)).BeginInit();
            this.SuspendLayout();
            // 
            // sB
            // 
            this.sB.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sB1});
            this.sB.Location = new System.Drawing.Point(0, 650);
            this.sB.Name = "sB";
            this.sB.Size = new System.Drawing.Size(1018, 22);
            this.sB.TabIndex = 11;
            this.sB.Text = "statusStrip1";
            // 
            // sB1
            // 
            this.sB1.Name = "sB1";
            this.sB1.Size = new System.Drawing.Size(118, 17);
            this.sB1.Text = "toolStripStatusLabel1";
            // 
            // theme1
            // 
            this.theme1.Theme = "Office2013Red";
            // 
            // cdLeft
            // 
            this.cdLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cdLeft.Controls.Add(this.c1DockingTab1);
            this.cdLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.cdLeft.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.cdLeft.Id = 1;
            this.cdLeft.Location = new System.Drawing.Point(0, 0);
            this.cdLeft.Name = "cdLeft";
            this.cdLeft.Size = new System.Drawing.Size(638, 650);
            this.theme1.SetTheme(this.cdLeft, "(default)");
            // 
            // c1DockingTab1
            // 
            this.c1DockingTab1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.c1DockingTab1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.c1DockingTab1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.c1DockingTab1.CanAutoHide = true;
            this.c1DockingTab1.CanCloseTabs = true;
            this.c1DockingTab1.CanMoveTabs = true;
            this.c1DockingTab1.Controls.Add(this.c1DockingTabPage1);
            this.c1DockingTab1.HotTrack = true;
            this.c1DockingTab1.Location = new System.Drawing.Point(0, 0);
            this.c1DockingTab1.Name = "c1DockingTab1";
            this.c1DockingTab1.ShowCaption = true;
            this.c1DockingTab1.Size = new System.Drawing.Size(638, 650);
            this.c1DockingTab1.TabIndex = 0;
            this.c1DockingTab1.TabSizeMode = C1.Win.C1Command.TabSizeModeEnum.Fit;
            this.c1DockingTab1.TabsShowFocusCues = false;
            this.c1DockingTab1.TabsSpacing = 2;
            this.c1DockingTab1.TabStyle = C1.Win.C1Command.TabStyleEnum.Office2007;
            this.theme1.SetTheme(this.c1DockingTab1, "(default)");
            // 
            // c1DockingTabPage1
            // 
            this.c1DockingTabPage1.CaptionVisible = true;
            this.c1DockingTabPage1.Controls.Add(this.gbPd);
            this.c1DockingTabPage1.Controls.Add(this.panel1);
            this.c1DockingTabPage1.Location = new System.Drawing.Point(1, 1);
            this.c1DockingTabPage1.Name = "c1DockingTabPage1";
            this.c1DockingTabPage1.Size = new System.Drawing.Size(633, 625);
            this.c1DockingTabPage1.TabIndex = 0;
            this.c1DockingTabPage1.Text = "Page1";
            // 
            // gbPd
            // 
            this.gbPd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.gbPd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbPd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.gbPd.Location = new System.Drawing.Point(0, 173);
            this.gbPd.Name = "gbPd";
            this.gbPd.Size = new System.Drawing.Size(633, 452);
            this.gbPd.TabIndex = 1;
            this.theme1.SetTheme(this.gbPd, "(default)");
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel1.Controls.Add(this.txtID);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtEccDoc);
            this.panel1.Controls.Add(this.btnDoc);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtEccAmt);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtRefundPay);
            this.panel1.Controls.Add(this.label106);
            this.panel1.Controls.Add(this.txtUserAmt);
            this.panel1.Controls.Add(this.cboStaff);
            this.panel1.Controls.Add(this.label105);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel1.Location = new System.Drawing.Point(0, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(633, 151);
            this.panel1.TabIndex = 0;
            this.theme1.SetTheme(this.panel1, "(default)");
            // 
            // txtID
            // 
            this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtID.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtID.Location = new System.Drawing.Point(176, 13);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(24, 20);
            this.txtID.TabIndex = 556;
            this.txtID.Tag = null;
            this.theme1.SetTheme(this.txtID, "(default)");
            this.txtID.Visible = false;
            this.txtID.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label1.Location = new System.Drawing.Point(249, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 16);
            this.label1.TabIndex = 555;
            this.label1.Text = "เลขที่ใบเคลีย์เงินสด :";
            this.theme1.SetTheme(this.label1, "(default)");
            // 
            // txtEccDoc
            // 
            this.txtEccDoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEccDoc.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtEccDoc.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.Currency;
            this.txtEccDoc.EditFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) 
            | C1.Win.C1Input.FormatInfoInheritFlags.CalendarType)));
            this.txtEccDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtEccDoc.FormatType = C1.Win.C1Input.FormatTypeEnum.Currency;
            this.txtEccDoc.Location = new System.Drawing.Point(418, 9);
            this.txtEccDoc.Name = "txtEccDoc";
            this.txtEccDoc.Size = new System.Drawing.Size(116, 24);
            this.txtEccDoc.TabIndex = 554;
            this.txtEccDoc.Tag = null;
            this.theme1.SetTheme(this.txtEccDoc, "(default)");
            this.txtEccDoc.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // btnDoc
            // 
            this.btnDoc.Image = global::Xtrim_ERP.Properties.Resources.accept_database24;
            this.btnDoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDoc.Location = new System.Drawing.Point(73, 6);
            this.btnDoc.Name = "btnDoc";
            this.btnDoc.Size = new System.Drawing.Size(83, 32);
            this.btnDoc.TabIndex = 553;
            this.btnDoc.Text = "doc";
            this.btnDoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.theme1.SetTheme(this.btnDoc, "(default)");
            this.btnDoc.UseVisualStyleBackColor = true;
            this.btnDoc.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label5.Location = new System.Drawing.Point(249, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(164, 16);
            this.label5.TabIndex = 550;
            this.label5.Text = "ยอดเงินClearบัญชีของรายการนี้ :";
            this.theme1.SetTheme(this.label5, "(default)");
            // 
            // txtEccAmt
            // 
            this.txtEccAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEccAmt.DataType = typeof(decimal);
            this.txtEccAmt.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtEccAmt.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.Currency;
            this.txtEccAmt.EditFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) 
            | C1.Win.C1Input.FormatInfoInheritFlags.CalendarType)));
            this.txtEccAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtEccAmt.FormatType = C1.Win.C1Input.FormatTypeEnum.Currency;
            this.txtEccAmt.Location = new System.Drawing.Point(418, 87);
            this.txtEccAmt.Name = "txtEccAmt";
            this.txtEccAmt.Size = new System.Drawing.Size(116, 24);
            this.txtEccAmt.TabIndex = 549;
            this.txtEccAmt.Tag = null;
            this.theme1.SetTheme(this.txtEccAmt, "(default)");
            this.txtEccAmt.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label4.Location = new System.Drawing.Point(249, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 16);
            this.label4.TabIndex = 548;
            this.label4.Text = "คงเหลือ :";
            this.theme1.SetTheme(this.label4, "(default)");
            // 
            // txtRefundPay
            // 
            this.txtRefundPay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRefundPay.DataType = typeof(decimal);
            this.txtRefundPay.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtRefundPay.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.Currency;
            this.txtRefundPay.EditFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) 
            | C1.Win.C1Input.FormatInfoInheritFlags.CalendarType)));
            this.txtRefundPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtRefundPay.FormatType = C1.Win.C1Input.FormatTypeEnum.Currency;
            this.txtRefundPay.Location = new System.Drawing.Point(418, 113);
            this.txtRefundPay.Name = "txtRefundPay";
            this.txtRefundPay.Size = new System.Drawing.Size(116, 24);
            this.txtRefundPay.TabIndex = 547;
            this.txtRefundPay.Tag = null;
            this.theme1.SetTheme(this.txtRefundPay, "(default)");
            this.txtRefundPay.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label106
            // 
            this.label106.AutoSize = true;
            this.label106.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label106.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label106.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label106.Location = new System.Drawing.Point(249, 40);
            this.label106.Name = "label106";
            this.label106.Size = new System.Drawing.Size(139, 16);
            this.label106.TabIndex = 515;
            this.label106.Text = "เงินคงค้างทั้งหมดของผู้เบิก :";
            this.theme1.SetTheme(this.label106, "(default)");
            // 
            // txtUserAmt
            // 
            this.txtUserAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserAmt.DataType = typeof(decimal);
            this.txtUserAmt.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtUserAmt.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.Currency;
            this.txtUserAmt.EditFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) 
            | C1.Win.C1Input.FormatInfoInheritFlags.CalendarType)));
            this.txtUserAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtUserAmt.FormatType = C1.Win.C1Input.FormatTypeEnum.Currency;
            this.txtUserAmt.Location = new System.Drawing.Point(418, 35);
            this.txtUserAmt.Name = "txtUserAmt";
            this.txtUserAmt.Size = new System.Drawing.Size(116, 24);
            this.txtUserAmt.TabIndex = 514;
            this.txtUserAmt.Tag = null;
            this.theme1.SetTheme(this.txtUserAmt, "(default)");
            this.txtUserAmt.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // cboStaff
            // 
            this.cboStaff.AllowSpinLoop = false;
            this.cboStaff.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cboStaff.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.cboStaff.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboStaff.GapHeight = 0;
            this.cboStaff.ImagePadding = new System.Windows.Forms.Padding(0);
            this.cboStaff.ItemsDisplayMember = "";
            this.cboStaff.ItemsValueMember = "";
            this.cboStaff.Location = new System.Drawing.Point(73, 42);
            this.cboStaff.Name = "cboStaff";
            this.cboStaff.Size = new System.Drawing.Size(169, 20);
            this.cboStaff.Style.DropDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cboStaff.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro;
            this.cboStaff.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboStaff.TabIndex = 486;
            this.cboStaff.Tag = null;
            this.theme1.SetTheme(this.cboStaff, "(default)");
            this.cboStaff.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label105
            // 
            this.label105.AutoSize = true;
            this.label105.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label105.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label105.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label105.Location = new System.Drawing.Point(6, 44);
            this.label105.Name = "label105";
            this.label105.Size = new System.Drawing.Size(50, 16);
            this.label105.TabIndex = 487;
            this.label105.Text = "ผู้ขอเบิก :";
            this.theme1.SetTheme(this.label105, "(default)");
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel4.Controls.Add(this.gbRefund);
            this.panel4.Controls.Add(this.panel7);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel4.Location = new System.Drawing.Point(638, 369);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(380, 281);
            this.panel4.TabIndex = 14;
            this.theme1.SetTheme(this.panel4, "(default)");
            // 
            // gbRefund
            // 
            this.gbRefund.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.gbRefund.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbRefund.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.gbRefund.Location = new System.Drawing.Point(0, 46);
            this.gbRefund.Name = "gbRefund";
            this.gbRefund.Size = new System.Drawing.Size(380, 235);
            this.gbRefund.TabIndex = 0;
            this.theme1.SetTheme(this.gbRefund, "(default)");
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel7.Controls.Add(this.btnRefund);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(380, 46);
            this.panel7.TabIndex = 0;
            this.theme1.SetTheme(this.panel7, "(default)");
            // 
            // btnRefund
            // 
            this.btnRefund.Image = global::Xtrim_ERP.Properties.Resources.custom_reports24;
            this.btnRefund.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefund.Location = new System.Drawing.Point(6, 6);
            this.btnRefund.Name = "btnRefund";
            this.btnRefund.Size = new System.Drawing.Size(83, 32);
            this.btnRefund.TabIndex = 548;
            this.btnRefund.Text = "ป้อนคืนเงิน";
            this.btnRefund.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.theme1.SetTheme(this.btnRefund, "(default)");
            this.btnRefund.UseVisualStyleBackColor = true;
            this.btnRefund.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel3.Controls.Add(this.gbEcc);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel3.Location = new System.Drawing.Point(638, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(380, 369);
            this.panel3.TabIndex = 0;
            this.theme1.SetTheme(this.panel3, "(default)");
            // 
            // gbEcc
            // 
            this.gbEcc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.gbEcc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbEcc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.gbEcc.Location = new System.Drawing.Point(0, 41);
            this.gbEcc.Name = "gbEcc";
            this.gbEcc.Size = new System.Drawing.Size(380, 328);
            this.gbEcc.TabIndex = 0;
            this.theme1.SetTheme(this.gbEcc, "(default)");
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.btnSave);
            this.panel5.Controls.Add(this.btnDNew);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(380, 41);
            this.panel5.TabIndex = 0;
            this.theme1.SetTheme(this.panel5, "(default)");
            // 
            // btnSave
            // 
            this.btnSave.Image = global::Xtrim_ERP.Properties.Resources.download_database24;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(4, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(83, 31);
            this.btnSave.TabIndex = 539;
            this.btnSave.Text = "บันทึกช้อมูล";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.theme1.SetTheme(this.btnSave, "(default)");
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // btnDNew
            // 
            this.btnDNew.Image = global::Xtrim_ERP.Properties.Resources.ClearFormatting_small;
            this.btnDNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDNew.Location = new System.Drawing.Point(253, 9);
            this.btnDNew.Name = "btnDNew";
            this.btnDNew.Size = new System.Drawing.Size(50, 25);
            this.btnDNew.TabIndex = 516;
            this.btnDNew.Text = "เพิ่ม";
            this.btnDNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.theme1.SetTheme(this.btnDNew, "(default)");
            this.btnDNew.UseVisualStyleBackColor = true;
            this.btnDNew.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // FrmExpenseReceiptCash1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 672);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.cdLeft);
            this.Controls.Add(this.sB);
            this.Name = "FrmExpenseReceiptCash1";
            this.Text = "FrmExpenseReceiptCash1";
            this.Load += new System.EventHandler(this.FrmExpenseReceiptCash1_Load);
            this.sB.ResumeLayout(false);
            this.sB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.theme1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdLeft)).EndInit();
            this.cdLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c1DockingTab1)).EndInit();
            this.c1DockingTab1.ResumeLayout(false);
            this.c1DockingTabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEccDoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEccAmt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRefundPay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserAmt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStaff)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnRefund)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDNew)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip sB;
        private System.Windows.Forms.ToolStripStatusLabel sB1;
        private C1.Win.C1Themes.C1ThemeController theme1;
        private C1.Win.C1Command.C1CommandDock cdLeft;
        private C1.Win.C1Command.C1DockingTab c1DockingTab1;
        private C1.Win.C1Command.C1DockingTabPage c1DockingTabPage1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel gbPd;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel gbRefund;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel gbEcc;
        private System.Windows.Forms.Panel panel5;
        private C1.Win.C1Input.C1ComboBox cboStaff;
        private System.Windows.Forms.Label label105;
        private System.Windows.Forms.Label label106;
        private C1.Win.C1Input.C1TextBox txtUserAmt;
        private System.Windows.Forms.Label label5;
        private C1.Win.C1Input.C1TextBox txtEccAmt;
        private System.Windows.Forms.Label label4;
        private C1.Win.C1Input.C1TextBox txtRefundPay;
        private C1.Win.C1Input.C1Button btnDoc;
        private C1.Win.C1Input.C1Button btnDNew;
        private C1.Win.C1Input.C1Button btnSave;
        private C1.Win.C1Input.C1Button btnRefund;
        private System.Windows.Forms.Label label1;
        private C1.Win.C1Input.C1TextBox txtEccDoc;
        private C1.Win.C1Input.C1TextBox txtID;
    }
}