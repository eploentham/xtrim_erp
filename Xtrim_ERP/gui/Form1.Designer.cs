namespace Xtrim_ERP.gui
{
    partial class Form1
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
            this.c1FlexGrid1 = new C1.Win.C1FlexGrid.C1FlexGrid();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // c1FlexGrid1
            // 
            this.c1FlexGrid1.ColumnInfo = "10,1,0,0,0,95,Columns:";
            this.c1FlexGrid1.Location = new System.Drawing.Point(0, 0);
            this.c1FlexGrid1.Name = "c1FlexGrid1";
            this.c1FlexGrid1.Rows.DefaultSize = 19;
            this.c1FlexGrid1.Size = new System.Drawing.Size(240, 150);
            this.c1FlexGrid1.TabIndex = 0;
            this.c1FlexGrid1.AfterRowColChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.c1FlexGrid1_AfterRowColChange);
            this.c1FlexGrid1.RowColChange += new System.EventHandler(this.c1FlexGrid1_RowColChange);
            this.c1FlexGrid1.LeaveCell += new System.EventHandler(this.c1FlexGrid1_LeaveCell);
            this.c1FlexGrid1.EnterCell += new System.EventHandler(this.c1FlexGrid1_EnterCell);
            this.c1FlexGrid1.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.c1FlexGrid1_CellChanged);
            this.c1FlexGrid1.CursorChanged += new System.EventHandler(this.c1FlexGrid1_CursorChanged);
            this.c1FlexGrid1.Click += new System.EventHandler(this.c1FlexGrid1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.c1FlexGrid1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.C1FlexGrid.C1FlexGrid c1FlexGrid1;
    }
}