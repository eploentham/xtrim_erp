namespace Xtrim_ERP.gui
{
    partial class FrmExpense
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.cboExpnG = new C1.Win.C1Input.C1ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.c1CheckBox1 = new C1.Win.C1Input.C1CheckBox();
            this.txtPasswordVoid = new C1.Win.C1Input.C1TextBox();
            this.chkVoid = new C1.Win.C1Input.C1CheckBox();
            this.btnNew = new C1.Win.C1Input.C1Button();
            this.btnVoid = new C1.Win.C1Input.C1Button();
            this.btnEdit = new C1.Win.C1Input.C1Button();
            this.btnSave = new C1.Win.C1Input.C1Button();
            this.chkTax = new C1.Win.C1Input.C1CheckBox();
            this.txtAccCode = new C1.Win.C1Input.C1TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboExpnT = new C1.Win.C1Input.C1ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboExpnC = new C1.Win.C1Input.C1ComboBox();
            this.label36 = new System.Windows.Forms.Label();
            this.txtRemark = new C1.Win.C1Input.C1TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNameT = new C1.Win.C1Input.C1TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtID = new C1.Win.C1Input.C1TextBox();
            this.txtCode = new C1.Win.C1Input.C1TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cboMtp = new C1.Win.C1Input.C1ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.sB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.theme1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboExpnG)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1CheckBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswordVoid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkVoid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnVoid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboExpnT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboExpnC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMtp)).BeginInit();
            this.SuspendLayout();
            // 
            // sB
            // 
            this.sB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.sB.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sB1});
            this.sB.Location = new System.Drawing.Point(0, 503);
            this.sB.Name = "sB";
            this.sB.Size = new System.Drawing.Size(987, 22);
            this.sB.TabIndex = 5;
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
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(987, 503);
            this.panel1.TabIndex = 6;
            this.theme1.SetTheme(this.panel1, "(default)");
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel3.Controls.Add(this.cboMtp);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.cboExpnG);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Controls.Add(this.c1CheckBox1);
            this.panel3.Controls.Add(this.txtPasswordVoid);
            this.panel3.Controls.Add(this.chkVoid);
            this.panel3.Controls.Add(this.btnNew);
            this.panel3.Controls.Add(this.btnVoid);
            this.panel3.Controls.Add(this.btnEdit);
            this.panel3.Controls.Add(this.btnSave);
            this.panel3.Controls.Add(this.chkTax);
            this.panel3.Controls.Add(this.txtAccCode);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.cboExpnT);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.cboExpnC);
            this.panel3.Controls.Add(this.label36);
            this.panel3.Controls.Add(this.txtRemark);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.txtNameT);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.txtID);
            this.panel3.Controls.Add(this.txtCode);
            this.panel3.Controls.Add(this.label34);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel3.Location = new System.Drawing.Point(469, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(518, 503);
            this.panel3.TabIndex = 1;
            this.theme1.SetTheme(this.panel3, "(default)");
            // 
            // cboExpnG
            // 
            this.cboExpnG.AllowSpinLoop = false;
            this.cboExpnG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cboExpnG.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.cboExpnG.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboExpnG.GapHeight = 0;
            this.cboExpnG.ImagePadding = new System.Windows.Forms.Padding(0);
            this.cboExpnG.ItemsDisplayMember = "";
            this.cboExpnG.ItemsValueMember = "";
            this.cboExpnG.Location = new System.Drawing.Point(130, 142);
            this.cboExpnG.Name = "cboExpnG";
            this.cboExpnG.Size = new System.Drawing.Size(223, 20);
            this.cboExpnG.Style.DropDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cboExpnG.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro;
            this.cboExpnG.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboExpnG.TabIndex = 557;
            this.cboExpnG.Tag = null;
            this.theme1.SetTheme(this.cboExpnG, "(default)");
            this.cboExpnG.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label5.Location = new System.Drawing.Point(8, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 16);
            this.label5.TabIndex = 558;
            this.label5.Text = "กลุ่มค่าใช้จ่าย :";
            this.theme1.SetTheme(this.label5, "(default)");
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.groupBox1.Controls.Add(this.panel4);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.groupBox1.Location = new System.Drawing.Point(116, 297);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(364, 100);
            this.groupBox1.TabIndex = 556;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ให้แสดงใน หน้าจอค่าใช้จ่าย";
            this.theme1.SetTheme(this.groupBox1, "(default)");
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel4.Controls.Add(this.radioButton1);
            this.panel4.Controls.Add(this.radioButton2);
            this.panel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel4.Location = new System.Drawing.Point(15, 19);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(332, 70);
            this.panel4.TabIndex = 559;
            this.theme1.SetTheme(this.panel4, "(default)");
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.BackColor = System.Drawing.Color.Transparent;
            this.radioButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.radioButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(189)))), ((int)(((byte)(182)))));
            this.radioButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(189)))), ((int)(((byte)(182)))));
            this.radioButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.radioButton1.Location = new System.Drawing.Point(7, 35);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(191, 17);
            this.radioButton1.TabIndex = 121;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "เป็นรายจ่ายของบริษัท เก็บเงินลูกค้า";
            this.theme1.SetTheme(this.radioButton1, "(default)");
            this.radioButton1.UseVisualStyleBackColor = false;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.BackColor = System.Drawing.Color.Transparent;
            this.radioButton2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.radioButton2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(189)))), ((int)(((byte)(182)))));
            this.radioButton2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(189)))), ((int)(((byte)(182)))));
            this.radioButton2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.radioButton2.Location = new System.Drawing.Point(7, 12);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(204, 17);
            this.radioButton2.TabIndex = 120;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "เป็นรายจ่ายของบริษัท ไม่เก็บเงินลูกค้า";
            this.theme1.SetTheme(this.radioButton2, "(default)");
            this.radioButton2.UseVisualStyleBackColor = false;
            // 
            // c1CheckBox1
            // 
            this.c1CheckBox1.BackColor = System.Drawing.Color.Transparent;
            this.c1CheckBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.c1CheckBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.c1CheckBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.c1CheckBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.c1CheckBox1.Location = new System.Drawing.Point(130, 267);
            this.c1CheckBox1.Name = "c1CheckBox1";
            this.c1CheckBox1.Padding = new System.Windows.Forms.Padding(4, 1, 1, 1);
            this.c1CheckBox1.Size = new System.Drawing.Size(153, 24);
            this.c1CheckBox1.TabIndex = 555;
            this.c1CheckBox1.Text = "ใช้ออกใบภาษี หัก ณ ที่จ่าย";
            this.theme1.SetTheme(this.c1CheckBox1, "(default)");
            this.c1CheckBox1.UseVisualStyleBackColor = true;
            this.c1CheckBox1.Value = null;
            this.c1CheckBox1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // txtPasswordVoid
            // 
            this.txtPasswordVoid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPasswordVoid.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtPasswordVoid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtPasswordVoid.Location = new System.Drawing.Point(187, 435);
            this.txtPasswordVoid.Name = "txtPasswordVoid";
            this.txtPasswordVoid.PasswordChar = '*';
            this.txtPasswordVoid.Size = new System.Drawing.Size(78, 20);
            this.txtPasswordVoid.TabIndex = 554;
            this.txtPasswordVoid.Tag = null;
            this.theme1.SetTheme(this.txtPasswordVoid, "(default)");
            this.txtPasswordVoid.Visible = false;
            this.txtPasswordVoid.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // chkVoid
            // 
            this.chkVoid.BackColor = System.Drawing.Color.Transparent;
            this.chkVoid.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.chkVoid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chkVoid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkVoid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.chkVoid.Location = new System.Drawing.Point(187, 406);
            this.chkVoid.Name = "chkVoid";
            this.chkVoid.Padding = new System.Windows.Forms.Padding(4, 1, 1, 1);
            this.chkVoid.Size = new System.Drawing.Size(155, 24);
            this.chkVoid.TabIndex = 553;
            this.chkVoid.Text = "ต้องการยกเลิกรายการ";
            this.theme1.SetTheme(this.chkVoid, "(default)");
            this.chkVoid.UseVisualStyleBackColor = true;
            this.chkVoid.Value = null;
            this.chkVoid.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // btnNew
            // 
            this.btnNew.Image = global::Xtrim_ERP.Properties.Resources.custom_reports24;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(399, 12);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(83, 39);
            this.btnNew.TabIndex = 552;
            this.btnNew.Text = "เพิ่มช้อมูล";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.theme1.SetTheme(this.btnNew, "(default)");
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // btnVoid
            // 
            this.btnVoid.Image = global::Xtrim_ERP.Properties.Resources.trash24;
            this.btnVoid.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVoid.Location = new System.Drawing.Point(399, 406);
            this.btnVoid.Name = "btnVoid";
            this.btnVoid.Size = new System.Drawing.Size(83, 39);
            this.btnVoid.TabIndex = 551;
            this.btnVoid.Text = "ยกเลิกช้อมูล";
            this.btnVoid.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.theme1.SetTheme(this.btnVoid, "(default)");
            this.btnVoid.UseVisualStyleBackColor = true;
            this.btnVoid.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // btnEdit
            // 
            this.btnEdit.Image = global::Xtrim_ERP.Properties.Resources.lock24;
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(399, 57);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(83, 39);
            this.btnEdit.TabIndex = 550;
            this.btnEdit.Text = "แก้ไขช้อมูล";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.theme1.SetTheme(this.btnEdit, "(default)");
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // btnSave
            // 
            this.btnSave.Image = global::Xtrim_ERP.Properties.Resources.accept_database24;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(399, 451);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(83, 30);
            this.btnSave.TabIndex = 549;
            this.btnSave.Text = "บันทึกช้อมูล";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.theme1.SetTheme(this.btnSave, "(default)");
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // chkTax
            // 
            this.chkTax.BackColor = System.Drawing.Color.Transparent;
            this.chkTax.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.chkTax.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chkTax.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkTax.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.chkTax.Location = new System.Drawing.Point(130, 231);
            this.chkTax.Name = "chkTax";
            this.chkTax.Padding = new System.Windows.Forms.Padding(4, 1, 1, 1);
            this.chkTax.Size = new System.Drawing.Size(153, 24);
            this.chkTax.TabIndex = 500;
            this.chkTax.Text = "ใช้ออกใบกำกับภาษี";
            this.theme1.SetTheme(this.chkTax, "(default)");
            this.chkTax.UseVisualStyleBackColor = true;
            this.chkTax.Value = null;
            this.chkTax.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // txtAccCode
            // 
            this.txtAccCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAccCode.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtAccCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtAccCode.Location = new System.Drawing.Point(130, 194);
            this.txtAccCode.Name = "txtAccCode";
            this.txtAccCode.Size = new System.Drawing.Size(245, 20);
            this.txtAccCode.TabIndex = 485;
            this.txtAccCode.Tag = null;
            this.theme1.SetTheme(this.txtAccCode, "(default)");
            this.txtAccCode.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label4.Location = new System.Drawing.Point(8, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 16);
            this.label4.TabIndex = 484;
            this.label4.Text = "รหัสบัญชี :";
            this.theme1.SetTheme(this.label4, "(default)");
            // 
            // cboExpnT
            // 
            this.cboExpnT.AllowSpinLoop = false;
            this.cboExpnT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cboExpnT.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.cboExpnT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboExpnT.GapHeight = 0;
            this.cboExpnT.ImagePadding = new System.Windows.Forms.Padding(0);
            this.cboExpnT.ItemsDisplayMember = "";
            this.cboExpnT.ItemsValueMember = "";
            this.cboExpnT.Location = new System.Drawing.Point(130, 116);
            this.cboExpnT.Name = "cboExpnT";
            this.cboExpnT.Size = new System.Drawing.Size(223, 20);
            this.cboExpnT.Style.DropDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cboExpnT.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro;
            this.cboExpnT.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboExpnT.TabIndex = 482;
            this.cboExpnT.Tag = null;
            this.theme1.SetTheme(this.cboExpnT, "(default)");
            this.cboExpnT.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label3.Location = new System.Drawing.Point(8, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 16);
            this.label3.TabIndex = 483;
            this.label3.Text = "ประเภทค่าใช้จ่าย :";
            this.theme1.SetTheme(this.label3, "(default)");
            // 
            // cboExpnC
            // 
            this.cboExpnC.AllowSpinLoop = false;
            this.cboExpnC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cboExpnC.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.cboExpnC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboExpnC.GapHeight = 0;
            this.cboExpnC.ImagePadding = new System.Windows.Forms.Padding(0);
            this.cboExpnC.ItemsDisplayMember = "";
            this.cboExpnC.ItemsValueMember = "";
            this.cboExpnC.Location = new System.Drawing.Point(130, 90);
            this.cboExpnC.Name = "cboExpnC";
            this.cboExpnC.Size = new System.Drawing.Size(223, 20);
            this.cboExpnC.Style.DropDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cboExpnC.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro;
            this.cboExpnC.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboExpnC.TabIndex = 480;
            this.cboExpnC.Tag = null;
            this.theme1.SetTheme(this.cboExpnC, "(default)");
            this.cboExpnC.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label36.Location = new System.Drawing.Point(8, 92);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(83, 16);
            this.label36.TabIndex = 481;
            this.label36.Text = "หมวดค่าใช้จ่าย :";
            this.theme1.SetTheme(this.label36, "(default)");
            // 
            // txtRemark
            // 
            this.txtRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemark.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtRemark.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtRemark.Location = new System.Drawing.Point(130, 64);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(245, 20);
            this.txtRemark.TabIndex = 450;
            this.txtRemark.Tag = null;
            this.theme1.SetTheme(this.txtRemark, "(default)");
            this.txtRemark.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label2.Location = new System.Drawing.Point(8, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 16);
            this.label2.TabIndex = 449;
            this.label2.Text = "หมายเหตุ :";
            this.theme1.SetTheme(this.label2, "(default)");
            // 
            // txtNameT
            // 
            this.txtNameT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNameT.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtNameT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtNameT.Location = new System.Drawing.Point(130, 38);
            this.txtNameT.Name = "txtNameT";
            this.txtNameT.Size = new System.Drawing.Size(245, 20);
            this.txtNameT.TabIndex = 448;
            this.txtNameT.Tag = null;
            this.theme1.SetTheme(this.txtNameT, "(default)");
            this.txtNameT.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label1.Location = new System.Drawing.Point(8, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 447;
            this.label1.Text = "ชื่อค่าใช้จ่าย :";
            this.theme1.SetTheme(this.label1, "(default)");
            // 
            // txtID
            // 
            this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtID.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtID.Location = new System.Drawing.Point(87, 12);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(24, 20);
            this.txtID.TabIndex = 446;
            this.txtID.Tag = null;
            this.theme1.SetTheme(this.txtID, "(default)");
            this.txtID.Visible = false;
            this.txtID.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // txtCode
            // 
            this.txtCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCode.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtCode.Location = new System.Drawing.Point(130, 12);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(245, 20);
            this.txtCode.TabIndex = 445;
            this.txtCode.Tag = null;
            this.theme1.SetTheme(this.txtCode, "(default)");
            this.txtCode.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label34.Location = new System.Drawing.Point(8, 14);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(35, 16);
            this.label34.TabIndex = 444;
            this.label34.Text = "รหัส :";
            this.theme1.SetTheme(this.label34, "(default)");
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(469, 503);
            this.panel2.TabIndex = 0;
            this.theme1.SetTheme(this.panel2, "(default)");
            // 
            // cboMtp
            // 
            this.cboMtp.AllowSpinLoop = false;
            this.cboMtp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cboMtp.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.cboMtp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboMtp.GapHeight = 0;
            this.cboMtp.ImagePadding = new System.Windows.Forms.Padding(0);
            this.cboMtp.ItemsDisplayMember = "";
            this.cboMtp.ItemsValueMember = "";
            this.cboMtp.Location = new System.Drawing.Point(130, 168);
            this.cboMtp.Name = "cboMtp";
            this.cboMtp.Size = new System.Drawing.Size(223, 20);
            this.cboMtp.Style.DropDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cboMtp.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro;
            this.cboMtp.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboMtp.TabIndex = 559;
            this.cboMtp.Tag = null;
            this.theme1.SetTheme(this.cboMtp, "(default)");
            this.cboMtp.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label6.Location = new System.Drawing.Point(8, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 16);
            this.label6.TabIndex = 560;
            this.label6.Text = "วิธีการจ่ายเงิน :";
            this.theme1.SetTheme(this.label6, "(default)");
            // 
            // FrmExpense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 525);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.sB);
            this.Name = "FrmExpense";
            this.Text = "FrmExpense";
            this.Load += new System.EventHandler(this.FrmExpense_Load);
            this.sB.ResumeLayout(false);
            this.sB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.theme1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboExpnG)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1CheckBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswordVoid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkVoid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnVoid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboExpnT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboExpnC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMtp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip sB;
        private System.Windows.Forms.ToolStripStatusLabel sB1;
        private C1.Win.C1Themes.C1ThemeController theme1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private C1.Win.C1Input.C1TextBox txtCode;
        private System.Windows.Forms.Label label34;
        private C1.Win.C1Input.C1TextBox txtID;
        private C1.Win.C1Input.C1TextBox txtRemark;
        private System.Windows.Forms.Label label2;
        private C1.Win.C1Input.C1TextBox txtNameT;
        private System.Windows.Forms.Label label1;
        private C1.Win.C1Input.C1TextBox txtAccCode;
        private System.Windows.Forms.Label label4;
        private C1.Win.C1Input.C1ComboBox cboExpnT;
        private System.Windows.Forms.Label label3;
        private C1.Win.C1Input.C1ComboBox cboExpnC;
        private System.Windows.Forms.Label label36;
        private C1.Win.C1Input.C1CheckBox chkTax;
        private C1.Win.C1Input.C1Button btnSave;
        private C1.Win.C1Input.C1Button btnNew;
        private C1.Win.C1Input.C1Button btnVoid;
        private C1.Win.C1Input.C1Button btnEdit;
        private C1.Win.C1Input.C1TextBox txtPasswordVoid;
        private C1.Win.C1Input.C1CheckBox chkVoid;
        private C1.Win.C1Input.C1CheckBox c1CheckBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private C1.Win.C1Input.C1ComboBox cboExpnG;
        private System.Windows.Forms.Label label5;
        private C1.Win.C1Input.C1ComboBox cboMtp;
        private System.Windows.Forms.Label label6;
    }
}