namespace Xtrim_ERP.gui
{
    partial class FrmImages
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
            this.txtTableId = new C1.Win.C1Input.C1TextBox();
            this.btnUpload = new C1.Win.C1Input.C1Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnImages = new C1.Win.C1Input.C1Button();
            this.txtModule = new C1.Win.C1Input.C1TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtId = new C1.Win.C1Input.C1TextBox();
            this.txtItmNameT = new C1.Win.C1Input.C1TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.txtJobId = new C1.Win.C1Input.C1TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.theme1)).BeginInit();
            this.sB.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTableId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpload)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnImages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtModule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItmNameT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtJobId)).BeginInit();
            this.SuspendLayout();
            // 
            // theme1
            // 
            this.theme1.Theme = "Office2013Red";
            // 
            // sB
            // 
            this.sB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.sB.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sB1});
            this.sB.Location = new System.Drawing.Point(0, 295);
            this.sB.Name = "sB";
            this.sB.Size = new System.Drawing.Size(793, 22);
            this.sB.TabIndex = 6;
            this.sB.Text = "statusStrip1";
            this.theme1.SetTheme(this.sB, "(default)");
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
            this.panel1.Controls.Add(this.txtJobId);
            this.panel1.Controls.Add(this.txtTableId);
            this.panel1.Controls.Add(this.btnUpload);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnImages);
            this.panel1.Controls.Add(this.txtModule);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtId);
            this.panel1.Controls.Add(this.txtItmNameT);
            this.panel1.Controls.Add(this.label34);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(793, 295);
            this.panel1.TabIndex = 7;
            this.theme1.SetTheme(this.panel1, "(default)");
            // 
            // txtTableId
            // 
            this.txtTableId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTableId.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtTableId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtTableId.Location = new System.Drawing.Point(251, 38);
            this.txtTableId.Name = "txtTableId";
            this.txtTableId.Size = new System.Drawing.Size(36, 20);
            this.txtTableId.TabIndex = 504;
            this.txtTableId.Tag = null;
            this.theme1.SetTheme(this.txtTableId, "(default)");
            this.txtTableId.Visible = false;
            this.txtTableId.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // btnUpload
            // 
            this.btnUpload.Image = global::Xtrim_ERP.Properties.Resources.accept_database24;
            this.btnUpload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpload.Location = new System.Drawing.Point(689, 73);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(88, 39);
            this.btnUpload.TabIndex = 503;
            this.btnUpload.Text = "Upload";
            this.btnUpload.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.theme1.SetTheme(this.btnUpload, "(default)");
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel2.Location = new System.Drawing.Point(108, 73);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(575, 207);
            this.panel2.TabIndex = 502;
            this.theme1.SetTheme(this.panel2, "(default)");
            // 
            // btnImages
            // 
            this.btnImages.Image = global::Xtrim_ERP.Properties.Resources.PrintPreview_large;
            this.btnImages.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImages.Location = new System.Drawing.Point(14, 73);
            this.btnImages.Name = "btnImages";
            this.btnImages.Size = new System.Drawing.Size(88, 39);
            this.btnImages.TabIndex = 501;
            this.btnImages.Text = "รูปใบเสร็จ";
            this.btnImages.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.theme1.SetTheme(this.btnImages, "(default)");
            this.btnImages.UseVisualStyleBackColor = true;
            this.btnImages.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // txtModule
            // 
            this.txtModule.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtModule.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtModule.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtModule.Location = new System.Drawing.Point(80, 38);
            this.txtModule.Name = "txtModule";
            this.txtModule.Size = new System.Drawing.Size(165, 20);
            this.txtModule.TabIndex = 500;
            this.txtModule.Tag = null;
            this.theme1.SetTheme(this.txtModule, "(default)");
            this.txtModule.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label1.Location = new System.Drawing.Point(11, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 16);
            this.label1.TabIndex = 499;
            this.label1.Text = "module :";
            this.theme1.SetTheme(this.label1, "(default)");
            // 
            // txtId
            // 
            this.txtId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtId.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtId.Location = new System.Drawing.Point(56, 12);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(18, 20);
            this.txtId.TabIndex = 498;
            this.txtId.Tag = null;
            this.theme1.SetTheme(this.txtId, "(default)");
            this.txtId.Visible = false;
            this.txtId.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // txtItmNameT
            // 
            this.txtItmNameT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtItmNameT.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtItmNameT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtItmNameT.Location = new System.Drawing.Point(80, 12);
            this.txtItmNameT.Name = "txtItmNameT";
            this.txtItmNameT.Size = new System.Drawing.Size(165, 20);
            this.txtItmNameT.TabIndex = 497;
            this.txtItmNameT.Tag = null;
            this.theme1.SetTheme(this.txtItmNameT, "(default)");
            this.txtItmNameT.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label34.Location = new System.Drawing.Point(11, 14);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(39, 16);
            this.label34.TabIndex = 496;
            this.label34.Text = "ลำดับ :";
            this.theme1.SetTheme(this.label34, "(default)");
            // 
            // txtJobId
            // 
            this.txtJobId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtJobId.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtJobId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtJobId.Location = new System.Drawing.Point(251, 12);
            this.txtJobId.Name = "txtJobId";
            this.txtJobId.Size = new System.Drawing.Size(18, 20);
            this.txtJobId.TabIndex = 505;
            this.txtJobId.Tag = null;
            this.theme1.SetTheme(this.txtJobId, "(default)");
            this.txtJobId.Visible = false;
            this.txtJobId.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // FrmImages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 317);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.sB);
            this.Name = "FrmImages";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmImages";
            this.Load += new System.EventHandler(this.FrmImages_Load);
            ((System.ComponentModel.ISupportInitialize)(this.theme1)).EndInit();
            this.sB.ResumeLayout(false);
            this.sB.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTableId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpload)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnImages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtModule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItmNameT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtJobId)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1Themes.C1ThemeController theme1;
        private System.Windows.Forms.StatusStrip sB;
        private System.Windows.Forms.ToolStripStatusLabel sB1;
        private System.Windows.Forms.Panel panel1;
        private C1.Win.C1Input.C1TextBox txtModule;
        private System.Windows.Forms.Label label1;
        private C1.Win.C1Input.C1TextBox txtId;
        private C1.Win.C1Input.C1TextBox txtItmNameT;
        private System.Windows.Forms.Label label34;
        private C1.Win.C1Input.C1Button btnImages;
        private C1.Win.C1Input.C1Button btnUpload;
        private System.Windows.Forms.Panel panel2;
        private C1.Win.C1Input.C1TextBox txtTableId;
        private C1.Win.C1Input.C1TextBox txtJobId;
    }
}