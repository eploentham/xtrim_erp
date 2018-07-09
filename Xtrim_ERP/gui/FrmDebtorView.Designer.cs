namespace Xtrim_ERP.gui
{
    partial class FrmDebtorView
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNew = new C1.Win.C1Input.C1Button();
            this.cboYear = new C1.Win.C1Input.C1ComboBox();
            this.label36 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.theme1)).BeginInit();
            this.sB.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboYear)).BeginInit();
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
            this.sB.Location = new System.Drawing.Point(0, 722);
            this.sB.Name = "sB";
            this.sB.Size = new System.Drawing.Size(1034, 22);
            this.sB.TabIndex = 8;
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
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel2.Location = new System.Drawing.Point(0, 71);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1034, 651);
            this.panel2.TabIndex = 11;
            this.theme1.SetTheme(this.panel2, "(default)");
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel1.Controls.Add(this.btnNew);
            this.panel1.Controls.Add(this.cboYear);
            this.panel1.Controls.Add(this.label36);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1034, 71);
            this.panel1.TabIndex = 10;
            this.theme1.SetTheme(this.panel1, "(default)");
            // 
            // btnNew
            // 
            this.btnNew.Image = global::Xtrim_ERP.Properties.Resources.custom_reports24;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(705, 12);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(83, 39);
            this.btnNew.TabIndex = 484;
            this.btnNew.Text = "เพิ่มช้อมูล";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.theme1.SetTheme(this.btnNew, "(default)");
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
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
            this.cboYear.Location = new System.Drawing.Point(39, 12);
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(134, 20);
            this.cboYear.Style.DropDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cboYear.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro;
            this.cboYear.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboYear.TabIndex = 482;
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
            this.label36.Location = new System.Drawing.Point(12, 14);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(21, 16);
            this.label36.TabIndex = 483;
            this.label36.Text = "ปี :";
            this.theme1.SetTheme(this.label36, "(default)");
            // 
            // FrmDebtorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 744);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.sB);
            this.Name = "FrmDebtorView";
            this.Text = "FrmDebtorView";
            this.Load += new System.EventHandler(this.FrmDebtorView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.theme1)).EndInit();
            this.sB.ResumeLayout(false);
            this.sB.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboYear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1Themes.C1ThemeController theme1;
        private System.Windows.Forms.StatusStrip sB;
        private System.Windows.Forms.ToolStripStatusLabel sB1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private C1.Win.C1Input.C1Button btnNew;
        private C1.Win.C1Input.C1ComboBox cboYear;
        private System.Windows.Forms.Label label36;
    }
}