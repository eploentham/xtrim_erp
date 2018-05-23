namespace Xtrim_ERP.gui
{
    partial class FrmInitial
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
            this.label1 = new System.Windows.Forms.Label();
            this.chkCusCodeAuto = new C1.Win.C1Input.C1CheckBox();
            this.chkStfCodeAuto = new C1.Win.C1Input.C1CheckBox();
            this.btnSave = new C1.Win.C1Input.C1Button();
            this.txtCusCode = new C1.Win.C1Input.C1TextBox();
            this.sB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.theme1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkCusCodeAuto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkStfCodeAuto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCusCode)).BeginInit();
            this.SuspendLayout();
            // 
            // sB
            // 
            this.sB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.sB.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sB1});
            this.sB.Location = new System.Drawing.Point(0, 428);
            this.sB.Name = "sB";
            this.sB.Size = new System.Drawing.Size(800, 22);
            this.sB.TabIndex = 2;
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
            this.panel1.Controls.Add(this.txtCusCode);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.chkStfCodeAuto);
            this.panel1.Controls.Add(this.chkCusCodeAuto);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 428);
            this.panel1.TabIndex = 3;
            this.theme1.SetTheme(this.panel1, "(default)");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 16);
            this.label1.TabIndex = 132;
            this.label1.Text = "ให้runรหัสลูกค้า auto :";
            this.theme1.SetTheme(this.label1, "(default)");
            // 
            // chkCusCodeAuto
            // 
            this.chkCusCodeAuto.BackColor = System.Drawing.Color.Transparent;
            this.chkCusCodeAuto.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.chkCusCodeAuto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chkCusCodeAuto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkCusCodeAuto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.chkCusCodeAuto.Location = new System.Drawing.Point(137, 9);
            this.chkCusCodeAuto.Name = "chkCusCodeAuto";
            this.chkCusCodeAuto.Padding = new System.Windows.Forms.Padding(4, 1, 1, 1);
            this.chkCusCodeAuto.Size = new System.Drawing.Size(127, 24);
            this.chkCusCodeAuto.TabIndex = 152;
            this.chkCusCodeAuto.Text = "ให้runรหัสลูกค้า auto";
            this.theme1.SetTheme(this.chkCusCodeAuto, "(default)");
            this.chkCusCodeAuto.UseVisualStyleBackColor = true;
            this.chkCusCodeAuto.Value = null;
            this.chkCusCodeAuto.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // chkStfCodeAuto
            // 
            this.chkStfCodeAuto.BackColor = System.Drawing.Color.Transparent;
            this.chkStfCodeAuto.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.chkStfCodeAuto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chkStfCodeAuto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkStfCodeAuto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.chkStfCodeAuto.Location = new System.Drawing.Point(137, 39);
            this.chkStfCodeAuto.Name = "chkStfCodeAuto";
            this.chkStfCodeAuto.Padding = new System.Windows.Forms.Padding(4, 1, 1, 1);
            this.chkStfCodeAuto.Size = new System.Drawing.Size(127, 24);
            this.chkStfCodeAuto.TabIndex = 153;
            this.chkStfCodeAuto.Text = "ให้runรหัสพนักงาน auto";
            this.theme1.SetTheme(this.chkStfCodeAuto, "(default)");
            this.chkStfCodeAuto.UseVisualStyleBackColor = true;
            this.chkStfCodeAuto.Value = null;
            this.chkStfCodeAuto.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // btnSave
            // 
            this.btnSave.Image = global::Xtrim_ERP.Properties.Resources.download_database24;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(705, 386);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(83, 39);
            this.btnSave.TabIndex = 154;
            this.btnSave.Text = "บันทึกช้อมูล";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.theme1.SetTheme(this.btnSave, "(default)");
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // txtCusCode
            // 
            this.txtCusCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCusCode.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtCusCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtCusCode.Location = new System.Drawing.Point(283, 13);
            this.txtCusCode.Name = "txtCusCode";
            this.txtCusCode.Size = new System.Drawing.Size(239, 20);
            this.txtCusCode.TabIndex = 155;
            this.txtCusCode.Tag = null;
            this.theme1.SetTheme(this.txtCusCode, "(default)");
            this.txtCusCode.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // FrmInitial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.sB);
            this.Name = "FrmInitial";
            this.Text = "FrmInitial";
            this.Load += new System.EventHandler(this.FrmInitial_Load);
            this.sB.ResumeLayout(false);
            this.sB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.theme1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkCusCodeAuto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkStfCodeAuto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCusCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip sB;
        private System.Windows.Forms.ToolStripStatusLabel sB1;
        private C1.Win.C1Themes.C1ThemeController theme1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private C1.Win.C1Input.C1CheckBox chkStfCodeAuto;
        private C1.Win.C1Input.C1CheckBox chkCusCodeAuto;
        private C1.Win.C1Input.C1Button btnSave;
        private C1.Win.C1Input.C1TextBox txtCusCode;
    }
}