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
    public partial class FrmItemsTypeSub : Form
    {
        XtrimControl xC;
        ItemsTypeSub itmtS;
        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;
        int colID = 1, colCode = 2, colName = 3, colRemark = 4;
        C1FlexGrid grfItmtS;
        //C1TextBox txtPassword = new C1.Win.C1Input.C1TextBox();
        Boolean flagEdit = false;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        String userIdVoid = "";

        public FrmItemsTypeSub(XtrimControl x)
        {
            InitializeComponent();
            xC = x;
            initConfig();
        }
        private void initConfig()
        {
            itmtS = new ItemsTypeSub();
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
            chkTax53.Click += ChkTax53_Click;

            xC.xtDB.itmtDB.setC1CboItemsT(cboItmT, "");
            xC.xtDB.fmtpDB.setC1CboMtp(cboFMtp, "");
            xC.xtDB.btaxDB.setC1CboItem(cboTax);

            initGrfDept();
            setGrfDeptH();
            setControlEnable(false);
            setFocusColor();
            sB1.Text = "";
            btnVoid.Hide();
            txtPasswordVoid.Hide();
            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            stt.BackgroundGradient = C1.Win.C1SuperTooltip.BackgroundGradient.Gold;
            cboTax.Hide();
        }

        private void ChkTax53_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (chkTax53.Checked)
            {
                cboTax.Show();
            }
            else
            {
                cboTax.Hide();
            }
        }

        private void initGrfDept()
        {
            grfItmtS = new C1FlexGrid();
            grfItmtS.Font = fEdit;
            grfItmtS.Dock = System.Windows.Forms.DockStyle.Fill;
            grfItmtS.Location = new System.Drawing.Point(0, 0);

            FilterRow fr = new FilterRow(grfItmtS);

            grfItmtS.AfterRowColChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.grfDept_AfterRowColChange);
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);

            panel2.Controls.Add(grfItmtS);

            theme1.SetTheme(grfItmtS, "Office2013Red");
        }
        private void setGrfDeptH()
        {
            //grfDept.Rows.Count = 7;
            grfItmtS.DataSource = xC.xtDB.itmtsDB.selectAll1();
            grfItmtS.Cols.Count = 5;
            TextBox txt = new TextBox();

            grfItmtS.Cols[colCode].Editor = txt;
            grfItmtS.Cols[colName].Editor = txt;
            grfItmtS.Cols[colRemark].Editor = txt;

            grfItmtS.Cols[colCode].Width = 60;
            grfItmtS.Cols[colName].Width = 200;
            grfItmtS.Cols[colRemark].Width = 100;

            grfItmtS.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfItmtS.Cols[colCode].Caption = "รหัส";
            grfItmtS.Cols[colName].Caption = "ชื่อ ประเภทย่อย ";
            grfItmtS.Cols[colRemark].Caption = "หมายเหตุ";
            Color color = ColorTranslator.FromHtml(xC.iniC.grfRowColor);
            for (int i = 1; i < grfItmtS.Rows.Count; i++)
            {
                grfItmtS[i, 0] = i;
                if (i % 2 == 0)
                    grfItmtS.Rows[i].StyleNew.BackColor = color;
            }
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            grfItmtS.Cols[colID].Visible = false;
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
            itmtS = xC.xtDB.itmtsDB.selectByPk1(deptId);
            txtID.Value = itmtS.item_type_sub_id;
            txtCode.Value = itmtS.item_type_sub_code;
            txtNameT.Value = itmtS.item_type_sub_name_t;
            txtRemark.Value = itmtS.remark;
            xC.setC1Combo(cboItmT, itmtS.item_type_id);
            xC.setC1Combo(cboFMtp, itmtS.f_method_payment_id);
            cboTax.SelectedIndex = 0;
            xC.setC1Combo(cboTax, itmtS.tax_id);
            chkItmEdit.Checked = itmtS.status_item_edit.Equals("1") ? true : false;
            chkInv.Checked = itmtS.status_invoice.Equals("1") ? true : false;
            chkTax53.Checked = itmtS.status_tax53.Equals("1") ? true : false;
            txtAccCode.Value = itmtS.acc_code;
            if (chkTax53.Checked)
            {
                cboTax.Show();
            }
            else
            {
                cboTax.Hide();
            }
        }
        private void setControlEnable(Boolean flag)
        {
            //txtID.Enabled = flag;
            txtCode.Enabled = flag;
            txtNameT.Enabled = flag;
            txtRemark.Enabled = flag;
            chkVoid.Enabled = flag;
            btnEdit.Image = !flag ? Resources.lock24 : Resources.open24;
        }
        private void setItemTypeSub()
        {
            itmtS.item_type_sub_id = txtID.Text;
            itmtS.item_type_sub_code = txtCode.Text;
            itmtS.item_type_sub_name_t = txtNameT.Text;
            itmtS.remark = txtRemark.Text;
            itmtS.item_type_id = cboItmT.SelectedItem != null ? ((ComboBoxItem)(cboItmT.SelectedItem)).Value : "";
            itmtS.f_method_payment_id = cboFMtp.SelectedItem != null ? ((ComboBoxItem)(cboFMtp.SelectedItem)).Value : "";
            itmtS.status_item_edit = chkItmEdit.Checked ? "1" : "0";
            itmtS.status_invoice = chkInv.Checked ? "1" : "0";
            itmtS.status_tax53 = chkTax53.Checked ? "1" : "0";
            itmtS.acc_code = txtAccCode.Text;
            itmtS.tax_id = cboTax.SelectedItem != null ? ((ComboBoxItem)(cboTax.SelectedItem)).Value : "";
        }
        private void grfDept_AfterRowColChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {
            if (e.NewRange.r1 < 0) return;
            if (e.NewRange.Data == null) return;

            String deptId = "";
            deptId = grfItmtS[e.NewRange.r1, colID] != null ? grfItmtS[e.NewRange.r1, colID].ToString() : "";
            setControl(deptId);
            flagEdit = false;
            setControlEnable(flagEdit);
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
                    stt.Show("<p><b>ต้องการยกเลิก</b></p> <br> รหัสผ่านถูกต้อง", btnVoid);
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
                setItemTypeSub();
                String re = xC.xtDB.itmtsDB.insertItemsTypeSub(itmtS, xC.user.staff_id);
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

        private void FrmExpenseType_Load(object sender, EventArgs e)
        {

        }
    }
}
