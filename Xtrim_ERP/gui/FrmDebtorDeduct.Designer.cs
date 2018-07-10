namespace Xtrim_ERP.gui
{
    partial class FrmDebtorDeduct
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
            this.theme1 = new C1.Win.C1Themes.C1ThemeController();
            this.sB = new System.Windows.Forms.StatusStrip();
            this.sB1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBllID = new C1.Win.C1Input.C1TextBox();
            this.txtJobCode = new C1.Win.C1Input.C1TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboChkExam = new C1.Win.C1Input.C1ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtOldamt = new C1.Win.C1Input.C1TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtOldnettotal = new C1.Win.C1Input.C1TextBox();
            this.txtOldvat = new C1.Win.C1Input.C1TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBillDate = new C1.Win.Calendar.C1DateEdit();
            this.txtCusNameT = new C1.Win.C1Input.C1TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRcpCode = new C1.Win.C1Input.C1TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBllCode = new C1.Win.C1Input.C1TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.theme1)).BeginInit();
            this.sB.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBllID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtJobCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboChkExam)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldamt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldnettotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldvat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBillDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCusNameT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRcpCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBllCode)).BeginInit();
            this.SuspendLayout();
            // 
            // theme1
            // 
            this.theme1.Theme = "Office2013Red";
            // 
            // sB
            // 
            this.sB.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sB1});
            this.sB.Location = new System.Drawing.Point(0, 615);
            this.sB.Name = "sB";
            this.sB.Size = new System.Drawing.Size(1009, 22);
            this.sB.TabIndex = 11;
            this.sB.Text = "statusStrip1";
            // 
            // sB1
            // 
            this.sB1.Name = "sB1";
            this.sB1.Size = new System.Drawing.Size(118, 17);
            this.sB1.Text = "toolStripStatusLabel1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1009, 207);
            this.panel1.TabIndex = 12;
            this.theme1.SetTheme(this.panel1, "(default)");
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel2.Location = new System.Drawing.Point(0, 207);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1009, 408);
            this.panel2.TabIndex = 13;
            this.theme1.SetTheme(this.panel2, "(default)");
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(595, 408);
            this.panel3.TabIndex = 0;
            this.theme1.SetTheme(this.panel3, "(default)");
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel4.Location = new System.Drawing.Point(595, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(414, 408);
            this.panel4.TabIndex = 1;
            this.theme1.SetTheme(this.panel4, "(default)");
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.groupBox1.Controls.Add(this.txtBllID);
            this.groupBox1.Controls.Add(this.txtJobCode);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cboChkExam);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label31);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtBillDate);
            this.groupBox1.Controls.Add(this.txtCusNameT);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtRcpCode);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtBllCode);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(569, 189);
            this.groupBox1.TabIndex = 481;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ค้นหา";
            this.theme1.SetTheme(this.groupBox1, "(default)");
            // 
            // txtBllID
            // 
            this.txtBllID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBllID.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtBllID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtBllID.Location = new System.Drawing.Point(56, 97);
            this.txtBllID.Name = "txtBllID";
            this.txtBllID.Size = new System.Drawing.Size(30, 20);
            this.txtBllID.TabIndex = 490;
            this.txtBllID.Tag = null;
            this.theme1.SetTheme(this.txtBllID, "(default)");
            this.txtBllID.Visible = false;
            this.txtBllID.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // txtJobCode
            // 
            this.txtJobCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtJobCode.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtJobCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtJobCode.Location = new System.Drawing.Point(92, 71);
            this.txtJobCode.Name = "txtJobCode";
            this.txtJobCode.Size = new System.Drawing.Size(169, 20);
            this.txtJobCode.TabIndex = 484;
            this.txtJobCode.Tag = null;
            this.theme1.SetTheme(this.txtJobCode, "(default)");
            this.txtJobCode.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label3.Location = new System.Drawing.Point(6, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 16);
            this.label3.TabIndex = 485;
            this.label3.Text = "Job No :";
            this.theme1.SetTheme(this.label3, "(default)");
            // 
            // cboChkExam
            // 
            this.cboChkExam.AllowSpinLoop = false;
            this.cboChkExam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cboChkExam.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.cboChkExam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboChkExam.GapHeight = 0;
            this.cboChkExam.ImagePadding = new System.Windows.Forms.Padding(0);
            this.cboChkExam.ItemsDisplayMember = "";
            this.cboChkExam.ItemsValueMember = "";
            this.cboChkExam.Location = new System.Drawing.Point(92, 45);
            this.cboChkExam.Name = "cboChkExam";
            this.cboChkExam.Size = new System.Drawing.Size(316, 20);
            this.cboChkExam.Style.DropDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cboChkExam.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro;
            this.cboChkExam.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboChkExam.TabIndex = 483;
            this.cboChkExam.Tag = null;
            this.theme1.SetTheme(this.cboChkExam, "(default)");
            this.cboChkExam.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.groupBox2.Controls.Add(this.txtOldamt);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtOldnettotal);
            this.groupBox2.Controls.Add(this.txtOldvat);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.groupBox2.Location = new System.Drawing.Point(267, 83);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(268, 100);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ยอดรวมใบเดิม";
            this.theme1.SetTheme(this.groupBox2, "(default)");
            // 
            // txtOldamt
            // 
            this.txtOldamt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOldamt.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtOldamt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtOldamt.Location = new System.Drawing.Point(113, 19);
            this.txtOldamt.Name = "txtOldamt";
            this.txtOldamt.Size = new System.Drawing.Size(131, 20);
            this.txtOldamt.TabIndex = 485;
            this.txtOldamt.Tag = null;
            this.theme1.SetTheme(this.txtOldamt, "(default)");
            this.txtOldamt.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label11.Location = new System.Drawing.Point(28, 73);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 16);
            this.label11.TabIndex = 482;
            this.label11.Text = "NetTotal :";
            this.theme1.SetTheme(this.label11, "(default)");
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label9.Location = new System.Drawing.Point(28, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 16);
            this.label9.TabIndex = 486;
            this.label9.Text = "รวมทั้งหมด :";
            this.theme1.SetTheme(this.label9, "(default)");
            // 
            // txtOldnettotal
            // 
            this.txtOldnettotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOldnettotal.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtOldnettotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtOldnettotal.Location = new System.Drawing.Point(113, 71);
            this.txtOldnettotal.Name = "txtOldnettotal";
            this.txtOldnettotal.Size = new System.Drawing.Size(131, 20);
            this.txtOldnettotal.TabIndex = 481;
            this.txtOldnettotal.Tag = null;
            this.theme1.SetTheme(this.txtOldnettotal, "(default)");
            this.txtOldnettotal.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // txtOldvat
            // 
            this.txtOldvat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOldvat.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtOldvat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtOldvat.Location = new System.Drawing.Point(113, 45);
            this.txtOldvat.Name = "txtOldvat";
            this.txtOldvat.Size = new System.Drawing.Size(131, 20);
            this.txtOldvat.TabIndex = 483;
            this.txtOldvat.Tag = null;
            this.theme1.SetTheme(this.txtOldvat, "(default)");
            this.txtOldvat.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label10.Location = new System.Drawing.Point(28, 47);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 16);
            this.label10.TabIndex = 484;
            this.label10.Text = "VAT :";
            this.theme1.SetTheme(this.label10, "(default)");
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label31.Location = new System.Drawing.Point(7, 149);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(65, 16);
            this.label31.TabIndex = 477;
            this.label31.Text = "วันที่วางบิล :";
            this.theme1.SetTheme(this.label31, "(default)");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 16);
            this.label2.TabIndex = 482;
            this.label2.Text = "*บริษัท ออกบิล :";
            this.theme1.SetTheme(this.label2, "(default)");
            // 
            // txtBillDate
            // 
            this.txtBillDate.AllowSpinLoop = false;
            this.txtBillDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBillDate.Calendar.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.txtBillDate.Calendar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtBillDate.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.txtBillDate.Calendar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.txtBillDate.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit;
            this.txtBillDate.Calendar.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(71)))), ((int)(((byte)(47)))));
            this.txtBillDate.Calendar.SelectionForeColor = System.Drawing.Color.White;
            this.txtBillDate.Calendar.TitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtBillDate.Calendar.TitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.txtBillDate.Calendar.TodayBorderColor = System.Drawing.Color.White;
            this.txtBillDate.Calendar.TrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtBillDate.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            this.txtBillDate.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtBillDate.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate;
            this.txtBillDate.DisplayFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat | C1.Win.C1Input.FormatInfoInheritFlags.NullText) 
            | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) 
            | C1.Win.C1Input.FormatInfoInheritFlags.CalendarType)));
            this.txtBillDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBillDate.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate;
            this.txtBillDate.ImagePadding = new System.Windows.Forms.Padding(0);
            this.txtBillDate.Location = new System.Drawing.Point(92, 149);
            this.txtBillDate.Name = "txtBillDate";
            this.txtBillDate.Size = new System.Drawing.Size(118, 20);
            this.txtBillDate.TabIndex = 476;
            this.txtBillDate.Tag = null;
            this.theme1.SetTheme(this.txtBillDate, "(default)");
            this.txtBillDate.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // txtCusNameT
            // 
            this.txtCusNameT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCusNameT.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtCusNameT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtCusNameT.Location = new System.Drawing.Point(92, 19);
            this.txtCusNameT.Name = "txtCusNameT";
            this.txtCusNameT.Size = new System.Drawing.Size(297, 20);
            this.txtCusNameT.TabIndex = 480;
            this.txtCusNameT.Tag = null;
            this.theme1.SetTheme(this.txtCusNameT, "(default)");
            this.txtCusNameT.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 481;
            this.label1.Text = "*Customer :";
            this.theme1.SetTheme(this.label1, "(default)");
            // 
            // txtRcpCode
            // 
            this.txtRcpCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRcpCode.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtRcpCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtRcpCode.Location = new System.Drawing.Point(92, 123);
            this.txtRcpCode.Name = "txtRcpCode";
            this.txtRcpCode.Size = new System.Drawing.Size(169, 20);
            this.txtRcpCode.TabIndex = 478;
            this.txtRcpCode.Tag = null;
            this.theme1.SetTheme(this.txtRcpCode, "(default)");
            this.txtRcpCode.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label6.Location = new System.Drawing.Point(6, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 16);
            this.label6.TabIndex = 475;
            this.label6.Text = "เลขที่ใบแจ้งหนี้ :";
            this.theme1.SetTheme(this.label6, "(default)");
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label7.Location = new System.Drawing.Point(6, 125);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 16);
            this.label7.TabIndex = 479;
            this.label7.Text = "เลขที่ใบเสร็จ :";
            this.theme1.SetTheme(this.label7, "(default)");
            // 
            // txtBllCode
            // 
            this.txtBllCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBllCode.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtBllCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtBllCode.Location = new System.Drawing.Point(92, 97);
            this.txtBllCode.Name = "txtBllCode";
            this.txtBllCode.Size = new System.Drawing.Size(169, 20);
            this.txtBllCode.TabIndex = 474;
            this.txtBllCode.Tag = null;
            this.theme1.SetTheme(this.txtBllCode, "(default)");
            this.txtBllCode.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // FrmDebtorDeduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 637);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.sB);
            this.Name = "FrmDebtorDeduct";
            this.Text = "FrmDebtorDeduct";
            this.Load += new System.EventHandler(this.FrmDebtorDeduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.theme1)).EndInit();
            this.sB.ResumeLayout(false);
            this.sB.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBllID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtJobCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboChkExam)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldamt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldnettotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldvat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBillDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCusNameT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRcpCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBllCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1Themes.C1ThemeController theme1;
        private System.Windows.Forms.StatusStrip sB;
        private System.Windows.Forms.ToolStripStatusLabel sB1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private C1.Win.C1Input.C1TextBox txtBllID;
        private C1.Win.C1Input.C1TextBox txtJobCode;
        private System.Windows.Forms.Label label3;
        private C1.Win.C1Input.C1ComboBox cboChkExam;
        private System.Windows.Forms.GroupBox groupBox2;
        private C1.Win.C1Input.C1TextBox txtOldamt;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private C1.Win.C1Input.C1TextBox txtOldnettotal;
        private C1.Win.C1Input.C1TextBox txtOldvat;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label2;
        private C1.Win.Calendar.C1DateEdit txtBillDate;
        private C1.Win.C1Input.C1TextBox txtCusNameT;
        private System.Windows.Forms.Label label1;
        private C1.Win.C1Input.C1TextBox txtRcpCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private C1.Win.C1Input.C1TextBox txtBllCode;
    }
}