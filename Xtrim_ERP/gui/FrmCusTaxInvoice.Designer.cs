namespace Xtrim_ERP.gui
{
    partial class FrmCusTaxInvoice
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkVoid = new C1.Win.C1Input.C1CheckBox();
            this.btnVoid = new C1.Win.C1Input.C1Button();
            this.txtID = new C1.Win.C1Input.C1TextBox();
            this.btnEdit = new C1.Win.C1Input.C1Button();
            this.btnSave = new C1.Win.C1Input.C1Button();
            this.txtTaxId = new C1.Win.C1Input.C1TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTaxInvoiceNameT = new C1.Win.C1Input.C1TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRemark = new C1.Win.C1Input.C1TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTaxInvoiceNameE = new C1.Win.C1Input.C1TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.sB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.theme1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkVoid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnVoid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaxId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaxInvoiceNameT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaxInvoiceNameE)).BeginInit();
            this.SuspendLayout();
            // 
            // sB
            // 
            this.sB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.sB.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sB1});
            this.sB.Location = new System.Drawing.Point(0, 313);
            this.sB.Name = "sB";
            this.sB.Size = new System.Drawing.Size(800, 22);
            this.sB.TabIndex = 3;
            this.sB.Text = "statusStrip1";
            this.theme1.SetTheme(this.sB, "(default)");
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel1.Controls.Add(this.txtTaxInvoiceNameE);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtRemark);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.chkVoid);
            this.panel1.Controls.Add(this.btnVoid);
            this.panel1.Controls.Add(this.txtID);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.txtTaxId);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtTaxInvoiceNameT);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 313);
            this.panel1.TabIndex = 4;
            this.theme1.SetTheme(this.panel1, "(default)");
            // 
            // chkVoid
            // 
            this.chkVoid.BackColor = System.Drawing.Color.Transparent;
            this.chkVoid.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.chkVoid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chkVoid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkVoid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.chkVoid.Location = new System.Drawing.Point(205, 255);
            this.chkVoid.Name = "chkVoid";
            this.chkVoid.Padding = new System.Windows.Forms.Padding(4, 1, 1, 1);
            this.chkVoid.Size = new System.Drawing.Size(155, 24);
            this.chkVoid.TabIndex = 235;
            this.chkVoid.Text = "ต้องการยกเลิกรายการ";
            this.theme1.SetTheme(this.chkVoid, "(default)");
            this.chkVoid.UseVisualStyleBackColor = true;
            this.chkVoid.Value = null;
            this.chkVoid.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // btnVoid
            // 
            this.btnVoid.Image = global::Xtrim_ERP.Properties.Resources.trash24;
            this.btnVoid.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVoid.Location = new System.Drawing.Point(522, 240);
            this.btnVoid.Name = "btnVoid";
            this.btnVoid.Size = new System.Drawing.Size(83, 39);
            this.btnVoid.TabIndex = 234;
            this.btnVoid.Text = "ยกเลิกช้อมูล";
            this.btnVoid.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.theme1.SetTheme(this.btnVoid, "(default)");
            this.btnVoid.UseVisualStyleBackColor = true;
            this.btnVoid.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            this.btnVoid.Click += new System.EventHandler(this.btnVoid_Click);
            // 
            // txtID
            // 
            this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtID.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtID.Location = new System.Drawing.Point(57, 33);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(30, 20);
            this.txtID.TabIndex = 233;
            this.txtID.Tag = null;
            this.theme1.SetTheme(this.txtID, "(default)");
            this.txtID.Visible = false;
            this.txtID.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(645, 197);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(118, 37);
            this.btnEdit.TabIndex = 232;
            this.btnEdit.Text = "แก้ไขช้อมูล";
            this.theme1.SetTheme(this.btnEdit, "(default)");
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(645, 240);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(118, 37);
            this.btnSave.TabIndex = 231;
            this.btnSave.Text = "บันทึกช้อมูล";
            this.theme1.SetTheme(this.btnSave, "(default)");
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtTaxId
            // 
            this.txtTaxId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTaxId.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtTaxId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtTaxId.Location = new System.Drawing.Point(116, 81);
            this.txtTaxId.Name = "txtTaxId";
            this.txtTaxId.Size = new System.Drawing.Size(647, 20);
            this.txtTaxId.TabIndex = 230;
            this.txtTaxId.Tag = null;
            this.theme1.SetTheme(this.txtTaxId, "(default)");
            this.txtTaxId.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label1.Location = new System.Drawing.Point(6, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 16);
            this.label1.TabIndex = 229;
            this.label1.Text = "Tax ID :";
            this.theme1.SetTheme(this.label1, "(default)");
            // 
            // txtTaxInvoiceNameT
            // 
            this.txtTaxInvoiceNameT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTaxInvoiceNameT.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtTaxInvoiceNameT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtTaxInvoiceNameT.Location = new System.Drawing.Point(116, 14);
            this.txtTaxInvoiceNameT.Name = "txtTaxInvoiceNameT";
            this.txtTaxInvoiceNameT.Size = new System.Drawing.Size(647, 20);
            this.txtTaxInvoiceNameT.TabIndex = 228;
            this.txtTaxInvoiceNameT.Tag = null;
            this.theme1.SetTheme(this.txtTaxInvoiceNameT, "(default)");
            this.txtTaxInvoiceNameT.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label8.Location = new System.Drawing.Point(6, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 16);
            this.label8.TabIndex = 227;
            this.label8.Text = "ชื่อผู้ออกใบกำกับภาษี :";
            this.theme1.SetTheme(this.label8, "(default)");
            // 
            // txtRemark
            // 
            this.txtRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemark.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtRemark.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtRemark.Location = new System.Drawing.Point(116, 107);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(647, 20);
            this.txtRemark.TabIndex = 237;
            this.txtRemark.Tag = null;
            this.theme1.SetTheme(this.txtRemark, "(default)");
            this.txtRemark.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label2.Location = new System.Drawing.Point(6, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 236;
            this.label2.Text = "หมาบเหตุ :";
            this.theme1.SetTheme(this.label2, "(default)");
            // 
            // txtTaxInvoiceNameE
            // 
            this.txtTaxInvoiceNameE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTaxInvoiceNameE.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtTaxInvoiceNameE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtTaxInvoiceNameE.Location = new System.Drawing.Point(116, 55);
            this.txtTaxInvoiceNameE.Name = "txtTaxInvoiceNameE";
            this.txtTaxInvoiceNameE.Size = new System.Drawing.Size(647, 20);
            this.txtTaxInvoiceNameE.TabIndex = 239;
            this.txtTaxInvoiceNameE.Tag = null;
            this.theme1.SetTheme(this.txtTaxInvoiceNameE, "(default)");
            this.txtTaxInvoiceNameE.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label3.Location = new System.Drawing.Point(6, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 16);
            this.label3.TabIndex = 238;
            this.label3.Text = "ชื่อผู้ออกใบกำกับภาษี :";
            this.theme1.SetTheme(this.label3, "(default)");
            // 
            // FrmCusTaxInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 335);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.sB);
            this.Name = "FrmCusTaxInvoice";
            this.Text = "FrmCustomerTaxInvoice";
            this.Load += new System.EventHandler(this.FrmCustTaxInvoice_Load);
            this.sB.ResumeLayout(false);
            this.sB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.theme1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkVoid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnVoid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaxId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaxInvoiceNameT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaxInvoiceNameE)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip sB;
        private System.Windows.Forms.ToolStripStatusLabel sB1;
        private C1.Win.C1Themes.C1ThemeController theme1;
        private System.Windows.Forms.Panel panel1;
        private C1.Win.C1Input.C1CheckBox chkVoid;
        private C1.Win.C1Input.C1Button btnVoid;
        private C1.Win.C1Input.C1TextBox txtID;
        private C1.Win.C1Input.C1Button btnEdit;
        private C1.Win.C1Input.C1Button btnSave;
        private C1.Win.C1Input.C1TextBox txtTaxId;
        private System.Windows.Forms.Label label1;
        private C1.Win.C1Input.C1TextBox txtTaxInvoiceNameT;
        private System.Windows.Forms.Label label8;
        private C1.Win.C1Input.C1TextBox txtTaxInvoiceNameE;
        private System.Windows.Forms.Label label3;
        private C1.Win.C1Input.C1TextBox txtRemark;
        private System.Windows.Forms.Label label2;
    }
}