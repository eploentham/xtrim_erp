namespace Xtrim_ERP.gui
{
    partial class ImJView
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImJView));
            this.grdView = new FarPoint.Win.Spread.FpSpread();
            this.fpSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.c1InputPanel1 = new C1.Win.C1InputPanel.C1InputPanel();
            this.c1SuperLabel1 = new C1.Win.C1SuperTooltip.C1SuperLabel();
            this.c1SuperTooltip1 = new C1.Win.C1SuperTooltip.C1SuperTooltip(this.components);
            this.c1Combo1 = new C1.Win.C1List.C1Combo();
            this.btnOk = new C1.Win.C1Input.C1Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1InputPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Combo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            this.SuspendLayout();
            // 
            // grdView
            // 
            this.grdView.AccessibleDescription = "";
            this.grdView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grdView.Location = new System.Drawing.Point(0, 91);
            this.grdView.Name = "grdView";
            this.grdView.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSpread1_Sheet1});
            this.grdView.Size = new System.Drawing.Size(932, 632);
            this.grdView.TabIndex = 0;
            // 
            // fpSpread1_Sheet1
            // 
            this.fpSpread1_Sheet1.Reset();
            this.fpSpread1_Sheet1.SheetName = "Sheet1";
            // 
            // c1InputPanel1
            // 
            this.c1InputPanel1.AutoSizeElement = C1.Framework.AutoSizeElement.Both;
            this.c1InputPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.c1InputPanel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.c1InputPanel1.Location = new System.Drawing.Point(0, 0);
            this.c1InputPanel1.Name = "c1InputPanel1";
            this.c1InputPanel1.Size = new System.Drawing.Size(932, 85);
            this.c1InputPanel1.TabIndex = 1;
            // 
            // c1SuperLabel1
            // 
            this.c1SuperLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c1SuperLabel1.Location = new System.Drawing.Point(23, 29);
            this.c1SuperLabel1.Name = "c1SuperLabel1";
            this.c1SuperLabel1.Size = new System.Drawing.Size(75, 23);
            this.c1SuperLabel1.TabIndex = 2;
            this.c1SuperLabel1.Text = "ปี";
            this.c1SuperLabel1.UseMnemonic = true;
            // 
            // c1SuperTooltip1
            // 
            this.c1SuperTooltip1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.c1SuperTooltip1.RightToLeft = System.Windows.Forms.RightToLeft.Inherit;
            // 
            // c1Combo1
            // 
            this.c1Combo1.AddItemSeparator = ';';
            this.c1Combo1.Caption = "";
            this.c1Combo1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.c1Combo1.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.c1Combo1.EditorBackColor = System.Drawing.SystemColors.Window;
            this.c1Combo1.EditorFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c1Combo1.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.c1Combo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c1Combo1.Images.Add(((System.Drawing.Image)(resources.GetObject("c1Combo1.Images"))));
            this.c1Combo1.Location = new System.Drawing.Point(104, 29);
            this.c1Combo1.MatchEntryTimeout = ((long)(2000));
            this.c1Combo1.MaxDropDownItems = ((short)(5));
            this.c1Combo1.MaxLength = 32767;
            this.c1Combo1.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.c1Combo1.Name = "c1Combo1";
            this.c1Combo1.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.c1Combo1.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.c1Combo1.Size = new System.Drawing.Size(146, 27);
            this.c1Combo1.TabIndex = 3;
            this.c1Combo1.Text = "c1Combo1";
            this.c1Combo1.PropBag = resources.GetString("c1Combo1.PropBag");
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Location = new System.Drawing.Point(789, 16);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(131, 53);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "ดึงข้อมูลใหม่";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.VisualStyle = C1.Win.C1Input.VisualStyle.System;
            // 
            // ImJView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 723);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.c1Combo1);
            this.Controls.Add(this.c1SuperLabel1);
            this.Controls.Add(this.c1InputPanel1);
            this.Controls.Add(this.grdView);
            this.Name = "ImJView";
            this.Text = "ImJView";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ImJView_Load);
            this.ResizeEnd += new System.EventHandler(this.ImJView_ResizeEnd);
            this.Resize += new System.EventHandler(this.ImJView_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.grdView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1InputPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Combo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FarPoint.Win.Spread.FpSpread grdView;
        private FarPoint.Win.Spread.SheetView fpSpread1_Sheet1;
        private C1.Win.C1InputPanel.C1InputPanel c1InputPanel1;
        private C1.Win.C1SuperTooltip.C1SuperLabel c1SuperLabel1;
        private C1.Win.C1SuperTooltip.C1SuperTooltip c1SuperTooltip1;
        private C1.Win.C1List.C1Combo c1Combo1;
        private C1.Win.C1Input.C1Button btnOk;
    }
}