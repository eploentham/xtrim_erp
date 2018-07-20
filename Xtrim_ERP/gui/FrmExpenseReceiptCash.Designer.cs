namespace Xtrim_ERP.gui
{
    partial class FrmExpenseReceiptCash
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDNew = new C1.Win.C1Input.C1Button();
            this.txtddAmt1 = new C1.Win.C1Input.C1TextBox();
            this.label106 = new System.Windows.Forms.Label();
            this.txtAmt = new C1.Win.C1Input.C1TextBox();
            this.txtJobId = new C1.Win.C1Input.C1TextBox();
            this.cboStaff = new C1.Win.C1Input.C1ComboBox();
            this.label105 = new System.Windows.Forms.Label();
            this.txtJobCode = new C1.Win.C1Input.C1TextBox();
            this.btnJobSearch = new C1.Win.C1Input.C1Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.sB = new System.Windows.Forms.StatusStrip();
            this.sB1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtItmNameT = new C1.Win.C1Input.C1TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtID = new C1.Win.C1Input.C1TextBox();
            this.txtPdId = new C1.Win.C1Input.C1TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.theme1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnDNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtddAmt1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtJobId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStaff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtJobCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnJobSearch)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.sB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtItmNameT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPdId)).BeginInit();
            this.SuspendLayout();
            // 
            // theme1
            // 
            this.theme1.Theme = "Office2013Red";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel2.Controls.Add(this.txtPdId);
            this.panel2.Controls.Add(this.txtID);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtItmNameT);
            this.panel2.Controls.Add(this.btnDNew);
            this.panel2.Controls.Add(this.txtddAmt1);
            this.panel2.Controls.Add(this.label106);
            this.panel2.Controls.Add(this.txtAmt);
            this.panel2.Controls.Add(this.txtJobId);
            this.panel2.Controls.Add(this.cboStaff);
            this.panel2.Controls.Add(this.label105);
            this.panel2.Controls.Add(this.txtJobCode);
            this.panel2.Controls.Add(this.btnJobSearch);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1067, 78);
            this.panel2.TabIndex = 11;
            this.theme1.SetTheme(this.panel2, "(default)");
            // 
            // btnDNew
            // 
            this.btnDNew.Image = global::Xtrim_ERP.Properties.Resources.ClearFormatting_small;
            this.btnDNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDNew.Location = new System.Drawing.Point(918, 29);
            this.btnDNew.Name = "btnDNew";
            this.btnDNew.Size = new System.Drawing.Size(50, 25);
            this.btnDNew.TabIndex = 515;
            this.btnDNew.Text = "เพิ่ม";
            this.btnDNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.theme1.SetTheme(this.btnDNew, "(default)");
            this.btnDNew.UseVisualStyleBackColor = true;
            this.btnDNew.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // txtddAmt1
            // 
            this.txtddAmt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtddAmt1.DataType = typeof(decimal);
            this.txtddAmt1.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtddAmt1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.Currency;
            this.txtddAmt1.EditFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) 
            | C1.Win.C1Input.FormatInfoInheritFlags.CalendarType)));
            this.txtddAmt1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtddAmt1.FormatType = C1.Win.C1Input.FormatTypeEnum.Currency;
            this.txtddAmt1.Location = new System.Drawing.Point(796, 15);
            this.txtddAmt1.Name = "txtddAmt1";
            this.txtddAmt1.Size = new System.Drawing.Size(116, 24);
            this.txtddAmt1.TabIndex = 514;
            this.txtddAmt1.Tag = null;
            this.theme1.SetTheme(this.txtddAmt1, "(default)");
            this.txtddAmt1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label106
            // 
            this.label106.AutoSize = true;
            this.label106.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label106.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label106.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label106.Location = new System.Drawing.Point(619, 18);
            this.label106.Name = "label106";
            this.label106.Size = new System.Drawing.Size(49, 16);
            this.label106.TabIndex = 513;
            this.label106.Text = "รวมเงิน :";
            this.theme1.SetTheme(this.label106, "(default)");
            // 
            // txtAmt
            // 
            this.txtAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmt.DataType = typeof(decimal);
            this.txtAmt.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtAmt.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.Currency;
            this.txtAmt.EditFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) 
            | C1.Win.C1Input.FormatInfoInheritFlags.CalendarType)));
            this.txtAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtAmt.FormatType = C1.Win.C1Input.FormatTypeEnum.Currency;
            this.txtAmt.Location = new System.Drawing.Point(674, 15);
            this.txtAmt.Name = "txtAmt";
            this.txtAmt.Size = new System.Drawing.Size(116, 24);
            this.txtAmt.TabIndex = 512;
            this.txtAmt.Tag = null;
            this.theme1.SetTheme(this.txtAmt, "(default)");
            this.txtAmt.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // txtJobId
            // 
            this.txtJobId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtJobId.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtJobId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtJobId.Location = new System.Drawing.Point(89, 15);
            this.txtJobId.Name = "txtJobId";
            this.txtJobId.Size = new System.Drawing.Size(24, 20);
            this.txtJobId.TabIndex = 486;
            this.txtJobId.Tag = null;
            this.theme1.SetTheme(this.txtJobId, "(default)");
            this.txtJobId.Visible = false;
            this.txtJobId.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
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
            this.cboStaff.Location = new System.Drawing.Point(431, 15);
            this.cboStaff.Name = "cboStaff";
            this.cboStaff.Size = new System.Drawing.Size(169, 20);
            this.cboStaff.Style.DropDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cboStaff.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro;
            this.cboStaff.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboStaff.TabIndex = 484;
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
            this.label105.Location = new System.Drawing.Point(375, 17);
            this.label105.Name = "label105";
            this.label105.Size = new System.Drawing.Size(50, 16);
            this.label105.TabIndex = 485;
            this.label105.Text = "ผู้ขอเบิก :";
            this.theme1.SetTheme(this.label105, "(default)");
            // 
            // txtJobCode
            // 
            this.txtJobCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtJobCode.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtJobCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtJobCode.Location = new System.Drawing.Point(119, 12);
            this.txtJobCode.Name = "txtJobCode";
            this.txtJobCode.Size = new System.Drawing.Size(207, 24);
            this.txtJobCode.TabIndex = 416;
            this.txtJobCode.Tag = null;
            this.theme1.SetTheme(this.txtJobCode, "(default)");
            this.txtJobCode.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // btnJobSearch
            // 
            this.btnJobSearch.Image = global::Xtrim_ERP.Properties.Resources.refresh16;
            this.btnJobSearch.Location = new System.Drawing.Point(332, 11);
            this.btnJobSearch.Name = "btnJobSearch";
            this.btnJobSearch.Size = new System.Drawing.Size(22, 22);
            this.btnJobSearch.TabIndex = 418;
            this.btnJobSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.theme1.SetTheme(this.btnJobSearch, "(default)");
            this.btnJobSearch.UseVisualStyleBackColor = true;
            this.btnJobSearch.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label2.Location = new System.Drawing.Point(13, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 16);
            this.label2.TabIndex = 417;
            this.label2.Text = "IMP JOB NO";
            this.theme1.SetTheme(this.label2, "(default)");
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel1.Location = new System.Drawing.Point(0, 78);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1067, 619);
            this.panel1.TabIndex = 515;
            this.theme1.SetTheme(this.panel1, "(default)");
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.splitContainer1.Panel1.Controls.Add(this.panel3);
            this.splitContainer1.Panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.theme1.SetTheme(this.splitContainer1.Panel1, "(default)");
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.splitContainer1.Panel2.Controls.Add(this.panel4);
            this.splitContainer1.Panel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.theme1.SetTheme(this.splitContainer1.Panel2, "(default)");
            this.splitContainer1.Size = new System.Drawing.Size(1067, 619);
            this.splitContainer1.SplitterDistance = 525;
            this.splitContainer1.TabIndex = 0;
            this.theme1.SetTheme(this.splitContainer1, "(default)");
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(525, 619);
            this.panel3.TabIndex = 0;
            this.theme1.SetTheme(this.panel3, "(default)");
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(538, 619);
            this.panel4.TabIndex = 0;
            this.theme1.SetTheme(this.panel4, "(default)");
            // 
            // sB
            // 
            this.sB.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sB1});
            this.sB.Location = new System.Drawing.Point(0, 697);
            this.sB.Name = "sB";
            this.sB.Size = new System.Drawing.Size(1067, 22);
            this.sB.TabIndex = 10;
            this.sB.Text = "statusStrip1";
            // 
            // sB1
            // 
            this.sB1.Name = "sB1";
            this.sB1.Size = new System.Drawing.Size(118, 17);
            this.sB1.Text = "toolStripStatusLabel1";
            // 
            // txtItmNameT
            // 
            this.txtItmNameT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtItmNameT.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtItmNameT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtItmNameT.Location = new System.Drawing.Point(119, 42);
            this.txtItmNameT.Name = "txtItmNameT";
            this.txtItmNameT.Size = new System.Drawing.Size(481, 24);
            this.txtItmNameT.TabIndex = 516;
            this.txtItmNameT.Tag = null;
            this.theme1.SetTheme(this.txtItmNameT, "(default)");
            this.txtItmNameT.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label1.Location = new System.Drawing.Point(13, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 517;
            this.label1.Text = "รายการ";
            this.theme1.SetTheme(this.label1, "(default)");
            // 
            // txtID
            // 
            this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtID.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtID.Location = new System.Drawing.Point(89, 45);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(24, 20);
            this.txtID.TabIndex = 518;
            this.txtID.Tag = null;
            this.theme1.SetTheme(this.txtID, "(default)");
            this.txtID.Visible = false;
            this.txtID.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // txtPdId
            // 
            this.txtPdId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPdId.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtPdId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtPdId.Location = new System.Drawing.Point(61, 45);
            this.txtPdId.Name = "txtPdId";
            this.txtPdId.Size = new System.Drawing.Size(24, 20);
            this.txtPdId.TabIndex = 519;
            this.txtPdId.Tag = null;
            this.theme1.SetTheme(this.txtPdId, "(default)");
            this.txtPdId.Visible = false;
            this.txtPdId.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // FrmExpenseReceiptCash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 719);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.sB);
            this.Name = "FrmExpenseReceiptCash";
            this.Text = "FrmExpenseReceiptCash";
            this.Load += new System.EventHandler(this.FrmExpenseReceiptCash_Load);
            ((System.ComponentModel.ISupportInitialize)(this.theme1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnDNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtddAmt1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtJobId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStaff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtJobCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnJobSearch)).EndInit();
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.sB.ResumeLayout(false);
            this.sB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtItmNameT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPdId)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1Themes.C1ThemeController theme1;
        private System.Windows.Forms.StatusStrip sB;
        private System.Windows.Forms.ToolStripStatusLabel sB1;
        private System.Windows.Forms.Panel panel2;
        private C1.Win.C1Input.C1TextBox txtddAmt1;
        private System.Windows.Forms.Label label106;
        private C1.Win.C1Input.C1TextBox txtAmt;
        private C1.Win.C1Input.C1TextBox txtJobId;
        private C1.Win.C1Input.C1ComboBox cboStaff;
        private System.Windows.Forms.Label label105;
        private C1.Win.C1Input.C1TextBox txtJobCode;
        private C1.Win.C1Input.C1Button btnJobSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private C1.Win.C1Input.C1Button btnDNew;
        private System.Windows.Forms.Label label1;
        private C1.Win.C1Input.C1TextBox txtItmNameT;
        private C1.Win.C1Input.C1TextBox txtID;
        private C1.Win.C1Input.C1TextBox txtPdId;
    }
}