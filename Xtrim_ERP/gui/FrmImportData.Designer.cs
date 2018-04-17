namespace Xtrim_ERP.gui
{
    partial class FrmImportData
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.btnOk = new C1.Win.C1Input.C1Button();
            this.c1CheckBox1 = new C1.Win.C1Input.C1CheckBox();
            this.pB1 = new System.Windows.Forms.ProgressBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.c1CheckBox2 = new C1.Win.C1Input.C1CheckBox();
            this.btnCus = new C1.Win.C1Input.C1Button();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.btnPath = new C1.Win.C1Input.C1Button();
            this.txtPathA = new C1.Win.C1Input.C1TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chk32 = new System.Windows.Forms.RadioButton();
            this.chk64 = new System.Windows.Forms.RadioButton();
            this.btnTest = new C1.Win.C1Input.C1Button();
            this.pic1 = new C1.Win.C1Input.C1PictureBox();
            this.c1ThemeController1 = new C1.Win.C1Themes.C1ThemeController();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1CheckBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1CheckBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPathA)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnTest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1ThemeController1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(118)))), ((int)(((byte)(135)))));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(635, 132);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "รายชื่อ ผู้นำเข้า meiosys";
            this.c1ThemeController1.SetTheme(this.groupBox1, "(default)");
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.c1CheckBox1);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(118)))), ((int)(((byte)(135)))));
            this.panel1.Location = new System.Drawing.Point(6, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(371, 100);
            this.panel1.TabIndex = 0;
            this.c1ThemeController1.SetTheme(this.panel1, "(default)");
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.BackColor = System.Drawing.Color.Transparent;
            this.radioButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.radioButton1.Location = new System.Drawing.Point(3, 3);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(192, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "นำเข้าข้อมูลใหม่ทั้งหมด ลบข้อมูลเดิม";
            this.c1ThemeController1.SetTheme(this.radioButton1, "(default)");
            this.radioButton1.UseVisualStyleBackColor = false;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.BackColor = System.Drawing.Color.Transparent;
            this.radioButton2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.radioButton2.Location = new System.Drawing.Point(3, 39);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(117, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "นำเข้า แต่ข้อมูลใหม่";
            this.c1ThemeController1.SetTheme(this.radioButton2, "(default)");
            this.radioButton2.UseVisualStyleBackColor = false;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(184, 29);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(118, 37);
            this.btnOk.TabIndex = 60;
            this.btnOk.Text = "นำเข้าช้อมูล";
            this.c1ThemeController1.SetTheme(this.btnOk, "(default)");
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // c1CheckBox1
            // 
            this.c1CheckBox1.BackColor = System.Drawing.Color.Transparent;
            this.c1CheckBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.c1CheckBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.c1CheckBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.c1CheckBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.c1CheckBox1.Location = new System.Drawing.Point(28, 62);
            this.c1CheckBox1.Name = "c1CheckBox1";
            this.c1CheckBox1.Padding = new System.Windows.Forms.Padding(4, 1, 1, 1);
            this.c1CheckBox1.Size = new System.Drawing.Size(104, 24);
            this.c1CheckBox1.TabIndex = 1;
            this.c1CheckBox1.Text = "c1CheckBox1";
            this.c1ThemeController1.SetTheme(this.c1CheckBox1, "(default)");
            this.c1CheckBox1.UseVisualStyleBackColor = true;
            this.c1CheckBox1.Value = null;
            this.c1CheckBox1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // pB1
            // 
            this.pB1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pB1.Location = new System.Drawing.Point(0, 767);
            this.pB1.Name = "pB1";
            this.pB1.Size = new System.Drawing.Size(990, 23);
            this.pB1.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(118)))), ((int)(((byte)(135)))));
            this.groupBox2.Location = new System.Drawing.Point(12, 159);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(635, 132);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "รายชื่อ ลูกค้า openjob";
            this.c1ThemeController1.SetTheme(this.groupBox2, "(default)");
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.btnTest);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.txtPathA);
            this.panel2.Controls.Add(this.btnPath);
            this.panel2.Controls.Add(this.c1CheckBox2);
            this.panel2.Controls.Add(this.btnCus);
            this.panel2.Controls.Add(this.radioButton3);
            this.panel2.Controls.Add(this.radioButton4);
            this.panel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(118)))), ((int)(((byte)(135)))));
            this.panel2.Location = new System.Drawing.Point(6, 19);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(623, 100);
            this.panel2.TabIndex = 0;
            this.c1ThemeController1.SetTheme(this.panel2, "(default)");
            // 
            // c1CheckBox2
            // 
            this.c1CheckBox2.BackColor = System.Drawing.Color.Transparent;
            this.c1CheckBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.c1CheckBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.c1CheckBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.c1CheckBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.c1CheckBox2.Location = new System.Drawing.Point(28, 62);
            this.c1CheckBox2.Name = "c1CheckBox2";
            this.c1CheckBox2.Padding = new System.Windows.Forms.Padding(4, 1, 1, 1);
            this.c1CheckBox2.Size = new System.Drawing.Size(104, 24);
            this.c1CheckBox2.TabIndex = 1;
            this.c1CheckBox2.Text = "c1CheckBox2";
            this.c1ThemeController1.SetTheme(this.c1CheckBox2, "(default)");
            this.c1CheckBox2.UseVisualStyleBackColor = true;
            this.c1CheckBox2.Value = null;
            this.c1CheckBox2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // btnCus
            // 
            this.btnCus.Location = new System.Drawing.Point(184, 29);
            this.btnCus.Name = "btnCus";
            this.btnCus.Size = new System.Drawing.Size(118, 37);
            this.btnCus.TabIndex = 60;
            this.btnCus.Text = "นำเข้าช้อมูล";
            this.c1ThemeController1.SetTheme(this.btnCus, "(default)");
            this.btnCus.UseVisualStyleBackColor = true;
            this.btnCus.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            this.btnCus.Click += new System.EventHandler(this.btnCus_Click);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.BackColor = System.Drawing.Color.Transparent;
            this.radioButton3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.radioButton3.Location = new System.Drawing.Point(3, 39);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(117, 17);
            this.radioButton3.TabIndex = 1;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "นำเข้า แต่ข้อมูลใหม่";
            this.c1ThemeController1.SetTheme(this.radioButton3, "(default)");
            this.radioButton3.UseVisualStyleBackColor = false;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.BackColor = System.Drawing.Color.Transparent;
            this.radioButton4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.radioButton4.Location = new System.Drawing.Point(3, 3);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(192, 17);
            this.radioButton4.TabIndex = 0;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "นำเข้าข้อมูลใหม่ทั้งหมด ลบข้อมูลเดิม";
            this.c1ThemeController1.SetTheme(this.radioButton4, "(default)");
            this.radioButton4.UseVisualStyleBackColor = false;
            // 
            // btnPath
            // 
            this.btnPath.Location = new System.Drawing.Point(138, 29);
            this.btnPath.Name = "btnPath";
            this.btnPath.Size = new System.Drawing.Size(37, 37);
            this.btnPath.TabIndex = 61;
            this.btnPath.Text = "...";
            this.c1ThemeController1.SetTheme(this.btnPath, "(default)");
            this.btnPath.UseVisualStyleBackColor = true;
            this.btnPath.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            this.btnPath.Click += new System.EventHandler(this.btnPath_Click);
            // 
            // txtPathA
            // 
            this.txtPathA.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.txtPathA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPathA.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtPathA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtPathA.Location = new System.Drawing.Point(138, 72);
            this.txtPathA.Name = "txtPathA";
            this.txtPathA.Size = new System.Drawing.Size(482, 20);
            this.txtPathA.TabIndex = 62;
            this.txtPathA.Tag = null;
            this.c1ThemeController1.SetTheme(this.txtPathA, "(default)");
            this.txtPathA.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.chk64);
            this.panel3.Controls.Add(this.chk32);
            this.panel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(118)))), ((int)(((byte)(135)))));
            this.panel3.Location = new System.Drawing.Point(327, 29);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(155, 30);
            this.panel3.TabIndex = 3;
            this.c1ThemeController1.SetTheme(this.panel3, "(default)");
            // 
            // chk32
            // 
            this.chk32.AutoSize = true;
            this.chk32.BackColor = System.Drawing.Color.Transparent;
            this.chk32.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.chk32.Location = new System.Drawing.Point(3, 10);
            this.chk32.Name = "chk32";
            this.chk32.Size = new System.Drawing.Size(37, 17);
            this.chk32.TabIndex = 2;
            this.chk32.TabStop = true;
            this.chk32.Text = "32";
            this.c1ThemeController1.SetTheme(this.chk32, "(default)");
            this.chk32.UseVisualStyleBackColor = false;
            // 
            // chk64
            // 
            this.chk64.AutoSize = true;
            this.chk64.BackColor = System.Drawing.Color.Transparent;
            this.chk64.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.chk64.Location = new System.Drawing.Point(78, 10);
            this.chk64.Name = "chk64";
            this.chk64.Size = new System.Drawing.Size(37, 17);
            this.chk64.TabIndex = 3;
            this.chk64.TabStop = true;
            this.chk64.Text = "64";
            this.c1ThemeController1.SetTheme(this.chk64, "(default)");
            this.chk64.UseVisualStyleBackColor = false;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(488, 29);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(82, 37);
            this.btnTest.TabIndex = 62;
            this.btnTest.Text = "Test Connection";
            this.c1ThemeController1.SetTheme(this.btnTest, "(default)");
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // pic1
            // 
            this.pic1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pic1.ErrorImage = global::Xtrim_ERP.Properties.Resources.images;
            this.pic1.Image = global::Xtrim_ERP.Properties.Resources.images;
            this.pic1.InitialImage = global::Xtrim_ERP.Properties.Resources.images;
            this.pic1.Location = new System.Drawing.Point(594, 207);
            this.pic1.Name = "pic1";
            this.pic1.Size = new System.Drawing.Size(44, 37);
            this.pic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic1.TabIndex = 63;
            this.pic1.TabStop = false;
            // 
            // FrmImportData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 790);
            this.Controls.Add(this.pic1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pB1);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(118)))), ((int)(((byte)(135)))));
            this.Name = "FrmImportData";
            this.Text = "FrmImportData";
            this.c1ThemeController1.SetTheme(this, "(default)");
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmImportData_Load);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1CheckBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1CheckBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPathA)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnTest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1ThemeController1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private C1.Win.C1Input.C1Button btnOk;
        private C1.Win.C1Input.C1CheckBox c1CheckBox1;
        private System.Windows.Forms.ProgressBar pB1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel2;
        private C1.Win.C1Input.C1CheckBox c1CheckBox2;
        private C1.Win.C1Input.C1Button btnCus;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private C1.Win.C1Input.C1Button btnPath;
        private C1.Win.C1Input.C1TextBox txtPathA;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton chk64;
        private System.Windows.Forms.RadioButton chk32;
        private C1.Win.C1Input.C1Button btnTest;
        private C1.Win.C1Input.C1PictureBox pic1;
        private C1.Win.C1Themes.C1ThemeController c1ThemeController1;
    }
}