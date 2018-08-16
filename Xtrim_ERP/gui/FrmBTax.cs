using C1.Win.C1FlexGrid;
using C1.Win.C1Input;
using C1.Win.C1SuperTooltip;
using C1.Win.C1Themes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xtrim_ERP.control;
using Xtrim_ERP.object1;
using Xtrim_ERP.Properties;

namespace Xtrim_ERP.gui
{
    public partial class FrmBTax : Form
    {
        XtrimControl xC;
        BTax tax;
        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;
        int colID = 1, colCode = 2, colName = 3, colRemark = 4;
        C1FlexGrid grfItemT;
        //C1TextBox txtPassword = new C1.Win.C1Input.C1TextBox();
        Boolean flagEdit = false;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        String userIdVoid = "";
        MainMenu4 menu;
        public FrmBTax(XtrimControl x, MainMenu4 m)
        {
            InitializeComponent();
            xC = x;
            menu = m;
            initConfig();
        }
        private void initConfig()
        {
            tax = new BTax();
            fEdit = new Font(xC.iniC.grdViewFontName, xC.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(xC.iniC.grdViewFontName, xC.grdViewFontSize, FontStyle.Bold);

            C1ThemeController.ApplicationTheme = xC.iniC.themeApplication;
            theme1.Theme = C1ThemeController.ApplicationTheme;
            theme1.SetTheme(sB, "BeigeOne");
            foreach (Control c in panel3.Controls)
            {
                theme1.SetTheme(c, "Office2013Red");
            }

            bg = txtCode.BackColor;
            fc = txtCode.ForeColor;
            ff = txtCode.Font;

            txtPasswordVoid.KeyUp += TxtPasswordVoid_KeyUp;
            btnNew.Click += BtnNew_Click;
            btnEdit.Click += BtnEdit_Click;
            btnSave.Click += BtnSave_Click;

            xC.iniDB.fttDB.setC1CboFTax(cboFTax, "");
            initGrfDept();
            setGrfDeptH();
            setControlEnable(false);
            setFocusColor();
            sB1.Text = "";
            btnVoid.Hide();
            txtPasswordVoid.Hide();
            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            //stt.BackgroundGradient = C1.Win.C1SuperTooltip.BackgroundGradient.Gold;
        }

        private void initGrfDept()
        {
            grfItemT = new C1FlexGrid();
            grfItemT.Font = fEdit;
            grfItemT.Dock = System.Windows.Forms.DockStyle.Fill;
            grfItemT.Location = new System.Drawing.Point(0, 0);

            FilterRow fr = new FilterRow(grfItemT);

            grfItemT.AfterRowColChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.GrfItemT_AfterRowColChange);
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);

            panel2.Controls.Add(grfItemT);

            theme1.SetTheme(grfItemT, "Office2013Red");
        }
        private void setGrfDeptH()
        {
            //grfDept.Rows.Count = 7;
            grfItemT.DataSource = xC.iniDB.btaxDB.selectAll();
            grfItemT.Cols.Count = 5;
            TextBox txt = new TextBox();

            grfItemT.Cols[colCode].Editor = txt;
            grfItemT.Cols[colName].Editor = txt;
            grfItemT.Cols[colRemark].Editor = txt;

            grfItemT.Cols[colCode].Width = 60;
            grfItemT.Cols[colName].Width = 200;
            grfItemT.Cols[colRemark].Width = 100;

            grfItemT.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfItemT.Cols[colCode].Caption = "รหัส";
            grfItemT.Cols[colName].Caption = "ชื่อ ประเภทหลัก";
            grfItemT.Cols[colRemark].Caption = "หมายเหตุ";
            Color color = ColorTranslator.FromHtml(xC.iniC.grfRowColor);
            for (int i = 1; i < grfItemT.Rows.Count; i++)
            {
                grfItemT[i, 0] = i;
                if (i % 2 == 0)
                    grfItemT.Rows[i].StyleNew.BackColor = color;
            }
            grfItemT.AfterRowColChange += GrfItemT_AfterRowColChange;
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            grfItemT.Cols[colID].Visible = false;
        }

        private void GrfItemT_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.NewRange.r1 < 0) return;
            if (e.NewRange.Data == null) return;

            String deptId = "";
            deptId = grfItemT[e.NewRange.r1, colID] != null ? grfItemT[e.NewRange.r1, colID].ToString() : "";
            setControl(deptId);
            flagEdit = false;
            setControlEnable(flagEdit);
        }

        private void textBox_Enter(object sender, EventArgs e)
        {
            C1TextBox a = (C1TextBox)sender;
            a.BackColor = xC.cTxtFocus;
            a.Font = new Font(ff, FontStyle.Bold);
        }
        private void textBox_Leave(object sender, EventArgs e)
        {
            C1TextBox a = (C1TextBox)sender;
            a.BackColor = bg;
            a.ForeColor = fc;
            a.Font = new Font(ff, FontStyle.Regular);
        }
        private void setFocusColor()
        {
            this.txtCode.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtCode.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtNameT.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtNameT.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtRemark.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtRemark.Enter += new System.EventHandler(this.textBox_Enter);
        }
        private void setControl(String deptId)
        {
            tax = xC.iniDB.btaxDB.selectByPk1(deptId);
            txtID.Value = tax.b_tax_id;
            txtCode.Value = tax.b_tax_code;
            txtNameT.Value = tax.b_tax_name_t;
            txtRemark.Value = tax.remark;
            txtRate1.Value = tax.rate1;
            xC.setC1Combo(cboFTax, tax.f_tax_type_id);
        }
        private void setControlEnable(Boolean flag)
        {
            //txtID.Enabled = flag;
            txtCode.Enabled = flag;
            txtNameT.Enabled = flag;
            txtRemark.Enabled = flag;
            chkVoid.Enabled = flag;
            cboFTax.Enabled = flag;
            txtRate1.Enabled = flag;
            btnEdit.Image = !flag ? Resources.lock24 : Resources.open24;
        }
        private void setTax()
        {
            tax.b_tax_id = txtID.Text;
            tax.b_tax_code = txtCode.Text;
            tax.b_tax_name_t = txtNameT.Text;
            tax.remark = txtRemark.Text;
            tax.rate1 = txtRate1.Text;
            tax.f_tax_type_id = cboFTax.SelectedItem != null ? ((ComboBoxItem)(cboFTax.SelectedItem)).Value : "";
        }
        private void TxtPasswordVoid_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.KeyCode == Keys.Enter)
            {
                userIdVoid = xC.xtDB.stfDB.selectByPasswordAdmin(txtPasswordVoid.Text.Trim());
                if (userIdVoid.Length > 0)
                {
                    txtPasswordVoid.Hide();
                    btnVoid.Show();
                    //stt.Show("<p><b>ต้องการยกเลิก</b></p> <br> รหัสผ่านถูกต้อง", btnVoid);
                }
                else
                {
                    sep.SetError(txtPasswordVoid, "333");
                }
            }
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                setTax();
                String re = xC.iniDB.btaxDB.insertBTax(tax, xC.user.staff_id);
                int chk = 0;
                if (int.TryParse(re, out chk))
                {
                    btnSave.Image = Resources.accept_database24;
                }
                else
                {
                    btnSave.Image = Resources.accept_database24;
                }
                setGrfDeptH();
                //setGrdView();
                //this.Dispose();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            flagEdit = flagEdit ? false : true;
            setControlEnable(flagEdit);
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            txtID.Value = "";
            txtCode.Value = "";
            txtNameT.Value = "";
            txtRemark.Value = "";
            chkVoid.Checked = false;
            btnVoid.Hide();
            flagEdit = true;
            setControlEnable(flagEdit);
        }
        private void FrmBTax_Load(object sender, EventArgs e)
        {

        }
    }
}
