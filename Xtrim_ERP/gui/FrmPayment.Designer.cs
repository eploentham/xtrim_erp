﻿namespace Xtrim_ERP.gui
{
    partial class FrmPayment
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
            this.c1CommandDock1 = new C1.Win.C1Command.C1CommandDock();
            this.c1DockingTab1 = new C1.Win.C1Command.C1DockingTab();
            this.c1DockingTabPage1 = new C1.Win.C1Command.C1DockingTabPage();
            this.panelJob = new System.Windows.Forms.Panel();
            this.panelBllD = new System.Windows.Forms.Panel();
            this.panelBill = new System.Windows.Forms.Panel();
            this.panelCus = new System.Windows.Forms.Panel();
            this.txtJobId = new C1.Win.C1Input.C1TextBox();
            this.txtJobCode = new C1.Win.C1Input.C1TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCusNameT = new C1.Win.C1Input.C1TextBox();
            this.lbCus = new System.Windows.Forms.Label();
            this.btnCusSF2 = new C1.Win.C1Input.C1Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.sB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.theme1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1CommandDock1)).BeginInit();
            this.c1CommandDock1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1DockingTab1)).BeginInit();
            this.c1DockingTab1.SuspendLayout();
            this.c1DockingTabPage1.SuspendLayout();
            this.panelCus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtJobId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtJobCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCusNameT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCusSF2)).BeginInit();
            this.SuspendLayout();
            // 
            // sB
            // 
            this.sB.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sB1});
            this.sB.Location = new System.Drawing.Point(0, 656);
            this.sB.Name = "sB";
            this.sB.Size = new System.Drawing.Size(1135, 22);
            this.sB.TabIndex = 9;
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panelBill);
            this.panel1.Controls.Add(this.panelCus);
            this.panel1.Controls.Add(this.c1CommandDock1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1135, 656);
            this.panel1.TabIndex = 10;
            this.theme1.SetTheme(this.panel1, "(default)");
            // 
            // c1CommandDock1
            // 
            this.c1CommandDock1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.c1CommandDock1.Controls.Add(this.c1DockingTab1);
            this.c1CommandDock1.Dock = System.Windows.Forms.DockStyle.Left;
            this.c1CommandDock1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.c1CommandDock1.Id = 1;
            this.c1CommandDock1.Location = new System.Drawing.Point(0, 0);
            this.c1CommandDock1.Name = "c1CommandDock1";
            this.c1CommandDock1.Size = new System.Drawing.Size(488, 656);
            this.theme1.SetTheme(this.c1CommandDock1, "(default)");
            // 
            // c1DockingTab1
            // 
            this.c1DockingTab1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.c1DockingTab1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.c1DockingTab1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.c1DockingTab1.CanAutoHide = true;
            this.c1DockingTab1.CanCloseTabs = true;
            this.c1DockingTab1.CanMoveTabs = true;
            this.c1DockingTab1.Controls.Add(this.c1DockingTabPage1);
            this.c1DockingTab1.HotTrack = true;
            this.c1DockingTab1.Location = new System.Drawing.Point(0, 0);
            this.c1DockingTab1.Name = "c1DockingTab1";
            this.c1DockingTab1.ShowCaption = true;
            this.c1DockingTab1.Size = new System.Drawing.Size(300, 656);
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
            this.c1DockingTabPage1.Controls.Add(this.panelJob);
            this.c1DockingTabPage1.Location = new System.Drawing.Point(0, 0);
            this.c1DockingTabPage1.Name = "c1DockingTabPage1";
            this.c1DockingTabPage1.Size = new System.Drawing.Size(297, 632);
            this.c1DockingTabPage1.TabIndex = 0;
            this.c1DockingTabPage1.Text = "Page1";
            // 
            // panelJob
            // 
            this.panelJob.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelJob.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelJob.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panelJob.Location = new System.Drawing.Point(0, 22);
            this.panelJob.Name = "panelJob";
            this.panelJob.Size = new System.Drawing.Size(297, 610);
            this.panelJob.TabIndex = 0;
            this.theme1.SetTheme(this.panelJob, "(default)");
            // 
            // panelBllD
            // 
            this.panelBllD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelBllD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panelBllD.Location = new System.Drawing.Point(454, 449);
            this.panelBllD.Name = "panelBllD";
            this.panelBllD.Size = new System.Drawing.Size(462, 207);
            this.panelBllD.TabIndex = 128;
            this.theme1.SetTheme(this.panelBllD, "(default)");
            // 
            // panelBill
            // 
            this.panelBill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelBill.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBill.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panelBill.Location = new System.Drawing.Point(488, 308);
            this.panelBill.Name = "panelBill";
            this.panelBill.Size = new System.Drawing.Size(647, 348);
            this.panelBill.TabIndex = 129;
            this.theme1.SetTheme(this.panelBill, "(default)");
            // 
            // panelCus
            // 
            this.panelCus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelCus.Controls.Add(this.txtJobId);
            this.panelCus.Controls.Add(this.panelBllD);
            this.panelCus.Controls.Add(this.txtJobCode);
            this.panelCus.Controls.Add(this.label3);
            this.panelCus.Controls.Add(this.txtCusNameT);
            this.panelCus.Controls.Add(this.lbCus);
            this.panelCus.Controls.Add(this.btnCusSF2);
            this.panelCus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panelCus.Location = new System.Drawing.Point(536, 3);
            this.panelCus.Name = "panelCus";
            this.panelCus.Size = new System.Drawing.Size(462, 101);
            this.panelCus.TabIndex = 130;
            this.theme1.SetTheme(this.panelCus, "(default)");
            // 
            // txtJobId
            // 
            this.txtJobId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtJobId.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtJobId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtJobId.Location = new System.Drawing.Point(262, 38);
            this.txtJobId.Name = "txtJobId";
            this.txtJobId.Size = new System.Drawing.Size(30, 20);
            this.txtJobId.TabIndex = 472;
            this.txtJobId.Tag = null;
            this.theme1.SetTheme(this.txtJobId, "(default)");
            this.txtJobId.Visible = false;
            this.txtJobId.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // txtJobCode
            // 
            this.txtJobCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtJobCode.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtJobCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtJobCode.Location = new System.Drawing.Point(87, 38);
            this.txtJobCode.Name = "txtJobCode";
            this.txtJobCode.Size = new System.Drawing.Size(169, 20);
            this.txtJobCode.TabIndex = 469;
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
            this.label3.Location = new System.Drawing.Point(10, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 16);
            this.label3.TabIndex = 470;
            this.label3.Text = "Job No :";
            this.theme1.SetTheme(this.label3, "(default)");
            // 
            // txtCusNameT
            // 
            this.txtCusNameT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCusNameT.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtCusNameT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtCusNameT.Location = new System.Drawing.Point(87, 12);
            this.txtCusNameT.Name = "txtCusNameT";
            this.txtCusNameT.Size = new System.Drawing.Size(297, 20);
            this.txtCusNameT.TabIndex = 119;
            this.txtCusNameT.Tag = null;
            this.theme1.SetTheme(this.txtCusNameT, "(default)");
            this.txtCusNameT.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // lbCus
            // 
            this.lbCus.AutoSize = true;
            this.lbCus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lbCus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.lbCus.Location = new System.Drawing.Point(10, 14);
            this.lbCus.Name = "lbCus";
            this.lbCus.Size = new System.Drawing.Size(76, 16);
            this.lbCus.TabIndex = 121;
            this.lbCus.Text = "*Customer :";
            this.theme1.SetTheme(this.lbCus, "(default)");
            // 
            // btnCusSF2
            // 
            this.btnCusSF2.Image = global::Xtrim_ERP.Properties.Resources.refresh16;
            this.btnCusSF2.Location = new System.Drawing.Point(390, 10);
            this.btnCusSF2.Name = "btnCusSF2";
            this.btnCusSF2.Size = new System.Drawing.Size(22, 22);
            this.btnCusSF2.TabIndex = 120;
            this.btnCusSF2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.theme1.SetTheme(this.btnCusSF2, "(default)");
            this.btnCusSF2.UseVisualStyleBackColor = true;
            this.btnCusSF2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel2.Location = new System.Drawing.Point(935, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 308);
            this.panel2.TabIndex = 131;
            this.theme1.SetTheme(this.panel2, "(default)");
            // 
            // FrmPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 678);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.sB);
            this.Name = "FrmPayment";
            this.Text = "FrmPayment";
            this.Load += new System.EventHandler(this.FrmPayment_Load);
            this.sB.ResumeLayout(false);
            this.sB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.theme1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c1CommandDock1)).EndInit();
            this.c1CommandDock1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c1DockingTab1)).EndInit();
            this.c1DockingTab1.ResumeLayout(false);
            this.c1DockingTabPage1.ResumeLayout(false);
            this.panelCus.ResumeLayout(false);
            this.panelCus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtJobId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtJobCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCusNameT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCusSF2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip sB;
        private System.Windows.Forms.ToolStripStatusLabel sB1;
        private C1.Win.C1Themes.C1ThemeController theme1;
        private System.Windows.Forms.Panel panel1;
        private C1.Win.C1Command.C1CommandDock c1CommandDock1;
        private C1.Win.C1Command.C1DockingTab c1DockingTab1;
        private C1.Win.C1Command.C1DockingTabPage c1DockingTabPage1;
        private System.Windows.Forms.Panel panelJob;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelBill;
        private System.Windows.Forms.Panel panelCus;
        private C1.Win.C1Input.C1TextBox txtJobId;
        private System.Windows.Forms.Panel panelBllD;
        private C1.Win.C1Input.C1TextBox txtJobCode;
        private System.Windows.Forms.Label label3;
        private C1.Win.C1Input.C1TextBox txtCusNameT;
        private System.Windows.Forms.Label lbCus;
        private C1.Win.C1Input.C1Button btnCusSF2;
    }
}