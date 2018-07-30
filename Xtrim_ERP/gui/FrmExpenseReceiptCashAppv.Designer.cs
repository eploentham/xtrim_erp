namespace Xtrim_ERP.gui
{
    partial class FrmExpenseReceiptCashAppv
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gbEcc = new System.Windows.Forms.Panel();
            this.gbPd = new System.Windows.Forms.Panel();
            this.cboYear = new C1.Win.C1Input.C1ComboBox();
            this.label36 = new System.Windows.Forms.Label();
            this.cboStaff = new C1.Win.C1Input.C1ComboBox();
            this.label105 = new System.Windows.Forms.Label();
            this.btnRefund = new C1.Win.C1Input.C1Button();
            this.btnSave = new C1.Win.C1Input.C1Button();
            this.btnDNew = new C1.Win.C1Input.C1Button();
            this.chkAll = new System.Windows.Forms.RadioButton();
            this.chkAppvWait = new System.Windows.Forms.RadioButton();
            this.sB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.theme1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStaff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefund)).BeginInit();
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
            this.sB.Size = new System.Drawing.Size(955, 22);
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
            this.splitContainer1.Panel1.Controls.Add(this.gbEcc);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.theme1.SetTheme(this.splitContainer1.Panel1, "(default)");
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.splitContainer1.Panel2.Controls.Add(this.gbPd);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.theme1.SetTheme(this.splitContainer1.Panel2, "(default)");
            this.splitContainer1.Size = new System.Drawing.Size(955, 650);
            this.splitContainer1.SplitterDistance = 483;
            this.splitContainer1.TabIndex = 12;
            this.theme1.SetTheme(this.splitContainer1, "(default)");
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel1.Controls.Add(this.chkAll);
            this.panel1.Controls.Add(this.chkAppvWait);
            this.panel1.Controls.Add(this.cboStaff);
            this.panel1.Controls.Add(this.label105);
            this.panel1.Controls.Add(this.cboYear);
            this.panel1.Controls.Add(this.label36);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(483, 88);
            this.panel1.TabIndex = 0;
            this.theme1.SetTheme(this.panel1, "(default)");
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel2.Controls.Add(this.btnDNew);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnRefund);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(468, 88);
            this.panel2.TabIndex = 0;
            this.theme1.SetTheme(this.panel2, "(default)");
            // 
            // gbEcc
            // 
            this.gbEcc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.gbEcc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbEcc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.gbEcc.Location = new System.Drawing.Point(0, 88);
            this.gbEcc.Name = "gbEcc";
            this.gbEcc.Size = new System.Drawing.Size(483, 562);
            this.gbEcc.TabIndex = 1;
            this.theme1.SetTheme(this.gbEcc, "(default)");
            // 
            // gbPd
            // 
            this.gbPd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.gbPd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbPd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.gbPd.Location = new System.Drawing.Point(0, 88);
            this.gbPd.Name = "gbPd";
            this.gbPd.Size = new System.Drawing.Size(468, 562);
            this.gbPd.TabIndex = 1;
            this.theme1.SetTheme(this.gbPd, "(default)");
            // 
            // cboYear
            // 
            this.cboYear.AllowSpinLoop = false;
            this.cboYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cboYear.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.cboYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboYear.GapHeight = 0;
            this.cboYear.ImagePadding = new System.Windows.Forms.Padding(0);
            this.cboYear.ItemsDisplayMember = "";
            this.cboYear.ItemsValueMember = "";
            this.cboYear.Location = new System.Drawing.Point(37, 12);
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(81, 20);
            this.cboYear.Style.DropDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cboYear.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro;
            this.cboYear.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboYear.TabIndex = 488;
            this.cboYear.Tag = null;
            this.theme1.SetTheme(this.cboYear, "(default)");
            this.cboYear.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label36.Location = new System.Drawing.Point(10, 14);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(21, 16);
            this.label36.TabIndex = 489;
            this.label36.Text = "ปี :";
            this.theme1.SetTheme(this.label36, "(default)");
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
            this.cboStaff.Location = new System.Drawing.Point(231, 12);
            this.cboStaff.Name = "cboStaff";
            this.cboStaff.Size = new System.Drawing.Size(169, 20);
            this.cboStaff.Style.DropDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cboStaff.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro;
            this.cboStaff.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboStaff.TabIndex = 490;
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
            this.label105.Location = new System.Drawing.Point(175, 14);
            this.label105.Name = "label105";
            this.label105.Size = new System.Drawing.Size(50, 16);
            this.label105.TabIndex = 491;
            this.label105.Text = "ผู้ขอเบิก :";
            this.theme1.SetTheme(this.label105, "(default)");
            // 
            // btnRefund
            // 
            this.btnRefund.Image = global::Xtrim_ERP.Properties.Resources.custom_reports24;
            this.btnRefund.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefund.Location = new System.Drawing.Point(16, 12);
            this.btnRefund.Name = "btnRefund";
            this.btnRefund.Size = new System.Drawing.Size(83, 32);
            this.btnRefund.TabIndex = 548;
            this.btnRefund.Text = "ป้อนคืนเงิน";
            this.btnRefund.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.theme1.SetTheme(this.btnRefund, "(default)");
            this.btnRefund.UseVisualStyleBackColor = true;
            this.btnRefund.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // btnSave
            // 
            this.btnSave.Image = global::Xtrim_ERP.Properties.Resources.download_database24;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(338, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(83, 31);
            this.btnSave.TabIndex = 549;
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
            this.btnDNew.Location = new System.Drawing.Point(129, 12);
            this.btnDNew.Name = "btnDNew";
            this.btnDNew.Size = new System.Drawing.Size(83, 32);
            this.btnDNew.TabIndex = 550;
            this.btnDNew.Text = "ป้อนเบิกเงิน";
            this.btnDNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.theme1.SetTheme(this.btnDNew, "(default)");
            this.btnDNew.UseVisualStyleBackColor = true;
            this.btnDNew.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.BackColor = System.Drawing.Color.Transparent;
            this.chkAll.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.chkAll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(189)))), ((int)(((byte)(182)))));
            this.chkAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(189)))), ((int)(((byte)(182)))));
            this.chkAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.chkAll.Location = new System.Drawing.Point(107, 38);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(58, 17);
            this.chkAll.TabIndex = 495;
            this.chkAll.TabStop = true;
            this.chkAll.Text = "ทั้งหมด";
            this.theme1.SetTheme(this.chkAll, "(default)");
            this.chkAll.UseVisualStyleBackColor = false;
            // 
            // chkAppvWait
            // 
            this.chkAppvWait.AutoSize = true;
            this.chkAppvWait.BackColor = System.Drawing.Color.Transparent;
            this.chkAppvWait.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.chkAppvWait.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(189)))), ((int)(((byte)(182)))));
            this.chkAppvWait.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(189)))), ((int)(((byte)(182)))));
            this.chkAppvWait.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.chkAppvWait.Location = new System.Drawing.Point(19, 38);
            this.chkAppvWait.Name = "chkAppvWait";
            this.chkAppvWait.Size = new System.Drawing.Size(62, 17);
            this.chkAppvWait.TabIndex = 494;
            this.chkAppvWait.TabStop = true;
            this.chkAppvWait.Text = "รอตรวจ";
            this.theme1.SetTheme(this.chkAppvWait, "(default)");
            this.chkAppvWait.UseVisualStyleBackColor = false;
            // 
            // FrmExpenseReceiptCashAppv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 672);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.sB);
            this.Name = "FrmExpenseReceiptCashAppv";
            this.Text = "FrmExpenseReceiptCashAppv";
            this.Load += new System.EventHandler(this.FrmExpenseReceiptCashAppv_Load);
            this.sB.ResumeLayout(false);
            this.sB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.theme1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStaff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefund)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDNew)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip sB;
        private System.Windows.Forms.ToolStripStatusLabel sB1;
        private C1.Win.C1Themes.C1ThemeController theme1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel gbEcc;
        private System.Windows.Forms.Panel gbPd;
        private C1.Win.C1Input.C1ComboBox cboYear;
        private System.Windows.Forms.Label label36;
        private C1.Win.C1Input.C1ComboBox cboStaff;
        private System.Windows.Forms.Label label105;
        private C1.Win.C1Input.C1Button btnRefund;
        private C1.Win.C1Input.C1Button btnSave;
        private C1.Win.C1Input.C1Button btnDNew;
        private System.Windows.Forms.RadioButton chkAll;
        private System.Windows.Forms.RadioButton chkAppvWait;
    }
}