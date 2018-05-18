namespace Xtrim_ERP.gui
{
    partial class FrmCusRemark
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnEdit = new C1.Win.C1Input.C1Button();
            this.btnSave = new C1.Win.C1Input.C1Button();
            this.txtRemark2 = new C1.Win.C1Input.C1TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRemark = new C1.Win.C1Input.C1TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtID = new C1.Win.C1Input.C1TextBox();
            this.chkVoid = new C1.Win.C1Input.C1CheckBox();
            this.btnVoid = new C1.Win.C1Input.C1Button();
            ((System.ComponentModel.ISupportInitialize)(this.theme1)).BeginInit();
            this.sB.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkVoid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnVoid)).BeginInit();
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
            this.sB.Location = new System.Drawing.Point(0, 282);
            this.sB.Name = "sB";
            this.sB.Size = new System.Drawing.Size(800, 22);
            this.sB.TabIndex = 2;
            this.sB.Text = "statusStrip1";
            // 
            // sB1
            // 
            this.sB1.Name = "sB1";
            this.sB1.Size = new System.Drawing.Size(118, 17);
            this.sB1.Text = "toolStripStatusLabel1";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel2.Controls.Add(this.chkVoid);
            this.panel2.Controls.Add(this.btnVoid);
            this.panel2.Controls.Add(this.txtID);
            this.panel2.Controls.Add(this.btnEdit);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.txtRemark2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtRemark);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 282);
            this.panel2.TabIndex = 3;
            this.theme1.SetTheme(this.panel2, "(default)");
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(655, 176);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(118, 37);
            this.btnEdit.TabIndex = 89;
            this.btnEdit.Text = "แก้ไขช้อมูล";
            this.theme1.SetTheme(this.btnEdit, "(default)");
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(655, 219);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(118, 37);
            this.btnSave.TabIndex = 88;
            this.btnSave.Text = "บันทึกช้อมูล";
            this.theme1.SetTheme(this.btnSave, "(default)");
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtRemark2
            // 
            this.txtRemark2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemark2.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtRemark2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtRemark2.Location = new System.Drawing.Point(103, 94);
            this.txtRemark2.Multiline = true;
            this.txtRemark2.Name = "txtRemark2";
            this.txtRemark2.Size = new System.Drawing.Size(670, 76);
            this.txtRemark2.TabIndex = 87;
            this.txtRemark2.Tag = null;
            this.theme1.SetTheme(this.txtRemark2, "(default)");
            this.txtRemark2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label1.Location = new System.Drawing.Point(6, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 86;
            this.label1.Text = "หมายเหตุ 2 :";
            this.theme1.SetTheme(this.label1, "(default)");
            // 
            // txtRemark
            // 
            this.txtRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemark.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtRemark.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtRemark.Location = new System.Drawing.Point(103, 12);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(670, 76);
            this.txtRemark.TabIndex = 85;
            this.txtRemark.Tag = null;
            this.theme1.SetTheme(this.txtRemark, "(default)");
            this.txtRemark.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label8.Location = new System.Drawing.Point(6, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 16);
            this.label8.TabIndex = 84;
            this.label8.Text = "หมายเหตุ :";
            this.theme1.SetTheme(this.label8, "(default)");
            // 
            // txtID
            // 
            this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtID.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtID.Location = new System.Drawing.Point(70, 12);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(30, 20);
            this.txtID.TabIndex = 90;
            this.txtID.Tag = null;
            this.theme1.SetTheme(this.txtID, "(default)");
            this.txtID.Visible = false;
            this.txtID.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // chkVoid
            // 
            this.chkVoid.BackColor = System.Drawing.Color.Transparent;
            this.chkVoid.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.chkVoid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chkVoid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkVoid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.chkVoid.Location = new System.Drawing.Point(215, 234);
            this.chkVoid.Name = "chkVoid";
            this.chkVoid.Padding = new System.Windows.Forms.Padding(4, 1, 1, 1);
            this.chkVoid.Size = new System.Drawing.Size(155, 24);
            this.chkVoid.TabIndex = 226;
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
            this.btnVoid.Location = new System.Drawing.Point(532, 219);
            this.btnVoid.Name = "btnVoid";
            this.btnVoid.Size = new System.Drawing.Size(83, 39);
            this.btnVoid.TabIndex = 225;
            this.btnVoid.Text = "ยกเลิกช้อมูล";
            this.btnVoid.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.theme1.SetTheme(this.btnVoid, "(default)");
            this.btnVoid.UseVisualStyleBackColor = true;
            this.btnVoid.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            this.btnVoid.Click += new System.EventHandler(this.btnVoid_Click);
            // 
            // FrmCusRemark
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 304);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.sB);
            this.Name = "FrmCusRemark";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmCusRemark";
            this.Load += new System.EventHandler(this.FrmCusRemark_Load);
            ((System.ComponentModel.ISupportInitialize)(this.theme1)).EndInit();
            this.sB.ResumeLayout(false);
            this.sB.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkVoid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnVoid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private C1.Win.C1Themes.C1ThemeController theme1;
        private System.Windows.Forms.StatusStrip sB;
        private System.Windows.Forms.ToolStripStatusLabel sB1;
        private System.Windows.Forms.Panel panel2;
        private C1.Win.C1Input.C1Button btnEdit;
        private C1.Win.C1Input.C1Button btnSave;
        private C1.Win.C1Input.C1TextBox txtRemark2;
        private System.Windows.Forms.Label label1;
        private C1.Win.C1Input.C1TextBox txtRemark;
        private System.Windows.Forms.Label label8;
        private C1.Win.C1Input.C1TextBox txtID;
        private C1.Win.C1Input.C1CheckBox chkVoid;
        private C1.Win.C1Input.C1Button btnVoid;
    }
}