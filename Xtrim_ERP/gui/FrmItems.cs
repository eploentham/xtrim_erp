﻿using C1.Win.C1FlexGrid;
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
    public partial class FrmItems : Form
    {
        XtrimControl xC;
        Items itm;
        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;
        int colID = 1, colCode = 2, colName = 3, colRemark = 4;
        C1FlexGrid grfExpn;
        //C1TextBox txtPassword = new C1.Win.C1Input.C1TextBox();
        Boolean flagEdit = false;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        String userIdVoid = "";

        public FrmItems(XtrimControl x)
        {
            InitializeComponent();
            xC = x;
            initConfig();
        }
        private void initConfig()
        {
            itm = new Items();
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
            cboItmts.SelectedItemChanged += CboItmts_SelectedItemChanged;
            chkTax53.Click += ChkTax53_Click;

            xC.iniDB.itmcDB.setC1CboItmC(cboItmC, "");
            xC.iniDB.itmtsDB.setC1CboItmTypeSub(cboItmts, "");
            xC.iniDB.itmgDB.setC1CboExpnG(cboItmG, "");
            xC.iniDB.fmtpDB.setC1CboMtp(cboFMtp, "");
            xC.iniDB.utpDB.setC1CboUtp(cboUtp, "");
            xC.iniDB.btaxDB.setC1CboItem(cboTax);
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
            grfExpn = new C1FlexGrid();
            grfExpn.Font = fEdit;
            grfExpn.Dock = System.Windows.Forms.DockStyle.Fill;
            grfExpn.Location = new System.Drawing.Point(0, 0);

            FilterRow fr = new FilterRow(grfExpn);

            grfExpn.AfterRowColChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.grfDept_AfterRowColChange);
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);

            panel2.Controls.Add(grfExpn);

            theme1.SetTheme(grfExpn, "Office2013Red");
        }
        private void setGrfDeptH()
        {
            //grfDept.Rows.Count = 7;
            grfExpn.DataSource = xC.iniDB.itmDB.selectAll();
            grfExpn.Cols.Count = 5;
            TextBox txt = new TextBox();

            grfExpn.Cols[colCode].Editor = txt;
            grfExpn.Cols[colName].Editor = txt;
            grfExpn.Cols[colRemark].Editor = txt;

            grfExpn.Cols[colCode].Width = 60;
            grfExpn.Cols[colName].Width = 200;
            grfExpn.Cols[colRemark].Width = 100;

            grfExpn.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfExpn.Cols[colCode].Caption = "รหัส";
            grfExpn.Cols[colName].Caption = "ชื่อ รายการ ";
            grfExpn.Cols[colRemark].Caption = "หมายเหตุ";
            Color color = ColorTranslator.FromHtml(xC.iniC.grfRowColor);
            for (int i = 1; i < grfExpn.Rows.Count; i++)
            {
                grfExpn[i, 0] = i;
                if (i % 2 == 0)
                    grfExpn.Rows[i].StyleNew.BackColor = color;
            }
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            grfExpn.Cols[colID].Visible = false;
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

            this.txtPrice1.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtPrice1.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtPrice2.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtPrice2.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtPrice3.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtPrice3.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtPrice4.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtPrice4.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtPrice5.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtPrice5.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtAccCode.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtAccCode.Enter += new System.EventHandler(this.textBox_Enter);
        }
        private void setControl(String deptId)
        {
            itm = xC.iniDB.itmDB.selectByPk1(deptId);
            txtID.Value = itm.item_id;
            txtItmGroupId.Value = itm.item_group_id;
            txtCode.Value = itm.item_code;
            txtNameT.Value = itm.item_name_t;
            txtRemark.Value = itm.remark;
            xC.setC1Combo(cboItmC, itm.item_cat_id);
            xC.setC1Combo(cboItmG, itm.item_grp_id);
            xC.setC1Combo(cboItmts, itm.item_type_sub_id);
            xC.setC1Combo(cboFMtp, itm.f_method_payment_id);
            xC.setC1Combo(cboUtp, itm.unit_id);
            cboTax.SelectedIndex = 0;
            xC.setC1Combo(cboTax, itm.tax_id);

            txtAccCode.Value = itm.acc_code;
            chkVat.Checked = itm.status_invoice.Equals("1") ? true : false;
            chkTax53.Checked = itm.status_tax53.Equals("1") ? true : false;
            chkStatusServ.Checked = itm.status_hide.Equals("1") ? true : false;
            if (chkTax53.Checked)
            {
                cboTax.Show();
            }
            else
            {
                cboTax.Hide();
            }

            ItemsTypeSub itmts = new ItemsTypeSub();
            itmts = xC.iniDB.itmtsDB.selectByPk1(itm.item_type_sub_id);
            if (itmts.status_item_edit.Equals("1"))
            {
                gBTypeSub.Enabled = true;
            }
            else
            {
                gBTypeSub.Enabled = false;
            }
            if (itm.tax_id.Equals("0") || itm.tax_id.Equals(""))
            {
                if (!itmts.tax_id.Equals(""))
                {
                    itm.tax_id = itmts.tax_id;
                }
                xC.setC1Combo(cboTax, itm.tax_id);
            }
            txtPrice1.Value = itm.price1;
            txtPrice2.Value = itm.price2;
            txtPrice3.Value = itm.price3;
            txtPrice4.Value = itm.price4;
            txtPrice5.Value = itm.price5;

        }
        private void setControlEnable(Boolean flag)
        {
            //txtID.Enabled = flag;
            txtCode.Enabled = flag;
            txtNameT.Enabled = flag;
            txtRemark.Enabled = flag;
            chkVoid.Enabled = flag;
            txtPrice1.Enabled = flag;
            txtPrice2.Enabled = flag;
            txtPrice3.Enabled = flag;
            txtPrice4.Enabled = flag;
            txtPrice5.Enabled = flag;
            cboItmC.Enabled = flag;
            cboItmG.Enabled = flag;
            cboItmts.Enabled = flag;
            cboUtp.Enabled = flag;

            btnEdit.Image = !flag ? Resources.lock24 : Resources.open24;
        }
        private void setItem()
        {
            itm.item_id = txtID.Text;
            itm.item_code = txtCode.Text;
            itm.item_name_t = txtNameT.Text;
            itm.remark = txtRemark.Text;
            itm.item_type_sub_id = cboItmts.SelectedItem != null ? ((ComboBoxItem)(cboItmts.SelectedItem)).Value : "";
            itm.item_cat_id = cboItmC.SelectedItem != null ? ((ComboBoxItem)(cboItmC.SelectedItem)).Value : "";
            itm.item_grp_id = cboItmG.SelectedItem != null ? ((ComboBoxItem)(cboItmG.SelectedItem)).Value : "";
            itm.status_invoice = chkVat.Checked ? "1" : "0";
            itm.status_tax53 = chkTax53.Checked ? "1" : "0";
            itm.acc_code = txtAccCode.Text;
            itm.f_method_payment_id = cboFMtp.SelectedItem != null ? ((ComboBoxItem)(cboFMtp.SelectedItem)).Value : "";
            itm.price1 = txtPrice1.Text;
            itm.price2 = txtPrice2.Text;
            itm.price3 = txtPrice3.Text;
            itm.price4 = txtPrice4.Text;
            itm.price5 = txtPrice5.Text;
            itm.unit_id = cboUtp.SelectedItem != null ? ((ComboBoxItem)(cboUtp.SelectedItem)).Value : "";
            itm.item_group_id = txtItmGroupId.Text;
            if (itm.item_group_id.Equals(""))
            {
                ItemsTypeSub itmts = new ItemsTypeSub();
                ItemsType itmt = new ItemsType();
                itmts = xC.iniDB.itmtsDB.selectByPk1(itm.item_type_sub_id);
                itmt = xC.iniDB.itmtDB.selectByPk1(itmts.item_type_id);
                itm.item_group_id = itmt.item_group_id;
            }
            itm.tax_id = cboTax.SelectedItem != null ? ((ComboBoxItem)(cboTax.SelectedItem)).Value : "";
            itm.status_hide = chkStatusServ.Checked ? "1" : "0";
        }
        private void grfDept_AfterRowColChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {
            if (e.NewRange.r1 < 0) return;
            if (e.NewRange.Data == null) return;

            String deptId = "";
            deptId = grfExpn[e.NewRange.r1, colID] != null ? grfExpn[e.NewRange.r1, colID].ToString() : "";
            setControl(deptId);
            flagEdit = false;
            setControlEnable(false);
            //setControlAddr(addrId);
            //setControlAddrEnable(false);
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
        private void CboItmts_SelectedItemChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            String itmts1 = "";
            itmts1 = cboItmts.SelectedItem != null ? ((ComboBoxItem)(cboItmts.SelectedItem)).Value : "";
            if (itmts1.Equals("")) return;
            ItemsTypeSub itmts = new ItemsTypeSub();
            itmts = xC.iniDB.itmtsDB.selectByPk1(itmts1);
            if (itmts.status_item_edit.Equals("1"))
            {
                gBTypeSub.Enabled = true;
            }
            else
            {
                gBTypeSub.Enabled = false;
            }
            txtAccCode.Value = itmts.acc_code;
            chkVat.Checked = itmts.status_invoice.Equals("1") ? true : false;
            chkTax53.Checked = itmts.status_tax53.Equals("1") ? true : false;
            chkStatusServ.Checked = itmts.status_hide.Equals("1") ? true : false;
            xC.setC1Combo(cboFMtp, itmts.f_method_payment_id);
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                setItem();
                String re = xC.iniDB.itmDB.insertItem(itm, xC.user.staff_id);
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
            txtPrice1.Value = "";
            txtPrice2.Value = "";
            txtPrice3.Value = "";
            txtPrice4.Value = "";
            txtPrice5.Value = "";
            chkVoid.Checked = false;
            btnVoid.Hide();
            setControlEnable(true);
        }
        private void FrmExpense_Load(object sender, EventArgs e)
        {

        }
    }
}