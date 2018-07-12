using C1.Win.C1FlexGrid;
using C1.Win.C1Input;
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

namespace Xtrim_ERP.gui
{
    public partial class FrmExpenseDrawD : Form
    {
        XtrimControl xC;
        ExpensesDrawDatail expnDd;

        Color bg, fc;
        Font ff, ffB;
        Font fEdit, fEditB;

        String drawdId = "";
        C1FlexGrid grfExpnD;
        int colID = 1, colCode = 2, colNameT = 3, colPrice1 = 4, colPrice2 = 5, colPrice3 = 6, colTypeSub = 7, colFmp=8;
        String cusId = "", cusNameT = "", cusAddr = "", cusTax = "";
        Boolean flagPage = false;
        public enum StatusPage { AppvPay, SaveViewOnly };
        StatusPage statusPage;
        public enum StatusPayType { Cash, Cheque, All, ItmServe };
        StatusPayType statuspaytype;
        public FrmExpenseDrawD(XtrimControl x, String id, String cusid, String cusnamet, String cusaddr, String custax, StatusPage statuspage, StatusPayType statuspaytype)
        {
            InitializeComponent();
            xC = x;
            drawdId = id;
            cusId = cusid;
            cusNameT = cusnamet;
            cusAddr = cusaddr;
            cusTax = custax;
            this.statusPage = statuspage;
            this.statuspaytype = statuspaytype;
            initConfig();
        }
        private void initConfig()
        {
            flagPage = true;
            xC.sItm = new Items();
            fEdit = new Font(xC.iniC.grdViewFontName, xC.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(xC.iniC.grdViewFontName, xC.grdViewFontSize, FontStyle.Bold);

            C1ThemeController.ApplicationTheme = xC.iniC.themeApplication;
            theme1.Theme = C1ThemeController.ApplicationTheme;
            theme1.SetTheme(sB, "BeigeOne");
            foreach (Control c in panel1.Controls)
            {
                theme1.SetTheme(c, "Office2013Red");
            }

            bg = txtQty.BackColor;
            fc = txtQty.ForeColor;
            ff = txtQty.Font;
            txtQty.KeyPress += TxtQty_KeyPress;
            txtQty.KeyUp += TxtQty_KeyUp;
            txtPrice.KeyUp += TxtPrice_KeyUp;
            btnSave.Click += BtnSave_Click;
            chkAll.Click += ChkAll_Click;
            chkCash.Click += ChkCash_Click;
            chkCheque.Click += ChkCheque_Click;
            chkItmServe.Click += ChkItmServe_Click;

            //xC.xtDB.itmDB.setC1CboItem(cboItm);
            xC.xtDB.utpDB.setC1CboUtp(cboUtp, "");

            setControlD();
            setFocusColor();
            
            if(statusPage == StatusPage.AppvPay)
            {
                label15.Text = "ป้อนค่าใช้จ่าย";
            }
            else
            {
                label15.Text = "ไม่มีการเบิกค่าใช้จ่าย ป้อนเพื่อเก็บข้อมูล";
            }
            chkAll.Checked = true;
            if (statuspaytype == StatusPayType.Cash)
            {
                chkCash.Checked = true;
            }else if(statuspaytype == StatusPayType.Cheque)
            {
                chkCheque.Checked = true;
            }
            initGrfDept();
            setGrfDeptH();
            flagPage = false;
        }

        private void ChkItmServe_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            setGrfDeptH();
        }

        private void ChkCheque_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            setGrfDeptH();
        }

        private void ChkCash_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            setGrfDeptH();
        }

        private void ChkAll_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            setGrfDeptH();
        }

        private void TxtPrice_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            calAmt();
        }

        private void TxtQty_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            Decimal qty = 0;
            if (Decimal.TryParse(txtQty.Text, out qty))
            {
                calAmt();
            }
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
            this.txtItmNameT.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtItmNameT.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtAmt.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtAmt.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtQty.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtQty.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtPrice.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtPrice.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtWtax1.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtWtax1.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtWtax3.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtWtax3.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtVat.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtVat.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtCusNameT.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtCusNameT.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtCusAddr.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtCusAddr.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtCusTax.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtCusTax.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtReceipt.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtReceipt.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtRemark.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtRemark.Enter += new System.EventHandler(this.textBox_Enter);
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            Items itm = new Items();
            itm = xC.xtDB.itmDB.selectByPk1(txtID.Text);
            xC.sItm = itm;
            xC.sItm.qty = txtQty.Text;
            xC.sItm.item_name_t = txtItmNameT.Text;
            xC.sItm.unit_id = cboUtp.SelectedItem != null ? ((ComboBoxItem)(cboUtp.SelectedItem)).Value : "";
            xC.sItm.unit_name_t = cboUtp.Text;
            xC.sItm.price1 = txtPrice.Text;
            xC.sItm.amt = txtAmt.Text;
            xC.sItm.wtax1 = txtWtax1.Text;
            xC.sItm.wtax3 = txtWtax3.Text;
            xC.sItm.vat = txtVat.Text;
            xC.sItm.cust_addr = txtCusAddr.Text;
            xC.sItm.cust_id = txtCusId.Text;
            xC.sItm.cust_name_t = txtCusNameT.Text;
            xC.sItm.cust_tax = txtCusTax.Text;
            xC.sItm.receipt_date = xC.datetoDB(txtReceiptDate.Text);
            xC.sItm.receipt_no = txtReceipt.Text;
            xC.sItm.remark = txtRemark.Text;

            Close();
        }

        private void TxtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            //throw new NotImplementedException();
            //Decimal qty = 0;
            //txtQty.
            //if (Decimal.TryParse(txtQty.Text, out qty))
            //{
            //    calAmt();
            //}
        }

        private void initGrfDept()
        {
            grfExpnD = new C1FlexGrid();
            grfExpnD.Font = fEdit;
            grfExpnD.Dock = System.Windows.Forms.DockStyle.Fill;
            grfExpnD.Location = new System.Drawing.Point(0, 0);

            FilterRow fr = new FilterRow(grfExpnD);

            grfExpnD.AfterRowColChange += GrfExpnD_AfterRowColChange;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            //grfExpnD.CellChanged += GrfExpnD_CellChanged;
            panel6.Controls.Add(grfExpnD);

            theme1.SetTheme(grfExpnD, "Office2013Red");
        }

        private void GrfExpnD_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.NewRange.r1 < 0) return;
            if (e.NewRange.Data == null) return;
            if (flagPage) return;
            String cusId = "";
            cusId = grfExpnD[e.NewRange.r1, colID] != null ? grfExpnD[e.NewRange.r1, colID].ToString() : "";
            setControl(cusId);
        }
        private void setControlD()
        {
            if (drawdId.Equals("")) return;
            expnDd = xC.xtDB.expnddDB.selectByPk1(drawdId);
            txtID.Value = expnDd.item_id;
            txtItmNameT.Value = expnDd.item_name_t;
            txtQty.Value = expnDd.qty;
            txtPrice.Value = expnDd.price;
            txtRemark.Value = expnDd.remark;
            txtCusId.Value = expnDd.pay_to_cus_id;
            txtCusNameT.Value = expnDd.pay_to_cus_name_t;
            txtCusAddr.Value = expnDd.pay_to_cus_addr;
            txtCusTax.Value = expnDd.pay_to_cus_tax;
            xC.setC1Combo(cboUtp, expnDd.unit_id);

            txtWtax1.Value = expnDd.wtax1;
            txtWtax3.Value = expnDd.wtax3;
            txtVat.Value = expnDd.vat;
            txtReceipt.Value = expnDd.receipt_no;
            txtReceiptDate.Value = expnDd.receipt_date;
            calAmt();
        }
        private void setControl(String rspid)
        {
            if (rspid.Equals("")) return;
            Items itm = new Items();
            itm = xC.xtDB.itmDB.selectByPk1(rspid);
            txtID.Value = itm.item_id;
            txtItmNameT.Value = itm.item_name_t;
            txtQty.Value = "1";
            txtPrice.Value = itm.price1;
            txtRemark.Value = itm.remark;
            txtCusId.Value = cusId;
            txtCusNameT.Value = cusNameT;
            txtCusAddr.Value = cusAddr;
            txtCusTax.Value = cusTax;
            xC.setC1Combo(cboUtp, itm.unit_id);
            label14.Text = itm.f_method_payment_id.Equals("1560000000") ? "cheque" : itm.f_method_payment_id.Equals("1560000001") ? "cash" : "-";
            calAmt();
        }
        private void calAmt()
        {
            Decimal price = 0, qty = 0, amt = 0;
            if (Decimal.TryParse(txtPrice.Text.ToString(), out price))
            {
                if (Decimal.TryParse(txtQty.Text.ToString(), out qty))
                {
                    txtAmt.Value = price * qty;
                }
            }
        }
        private void setGrfDeptH()
        {
            grfExpnD.Clear();
            //if (txtID.Text.Equals("")) return;

            grfExpnD.DataSource = xC.xtDB.itmDB.selectAll1(chkCash.Checked ? "1" : chkCheque.Checked ? "2" : chkAll.Checked ? "" : chkItmServe.Checked ? "9" : "");
            C1TextBox txt = new C1TextBox();
            txt.DataType = txtID.DataType;

            grfExpnD.Cols[colID].Editor = txt;
            grfExpnD.Cols[colCode].Editor = txt;
            grfExpnD.Cols[colNameT].Editor = txt;
            grfExpnD.Cols[colPrice1].Editor = txt;
            grfExpnD.Cols[colPrice2].Editor = txt;
            grfExpnD.Cols[colPrice3].Editor = txt;
            grfExpnD.Cols[colTypeSub].Editor = txt;

            grfExpnD.Cols[colCode].Width = 80;
            grfExpnD.Cols[colNameT].Width = 200;
            grfExpnD.Cols[colPrice1].Width = 80;
            grfExpnD.Cols[colPrice2].Width = 80;
            grfExpnD.Cols[colPrice3].Width = 80;
            grfExpnD.Cols[colTypeSub].Width = 120;
            grfExpnD.ShowCursor = true;
            grfExpnD.Cols[colCode].Caption = "รหัส";
            grfExpnD.Cols[colNameT].Caption = "ชื่อ";
            grfExpnD.Cols[colPrice1].Caption = "ราคา1";
            grfExpnD.Cols[colPrice2].Caption = "ราคา2";
            grfExpnD.Cols[colPrice3].Caption = "ราคา3";
            grfExpnD.Cols[colTypeSub].Caption = "ประเภทย่อย";
            Color color = ColorTranslator.FromHtml(xC.iniC.grfRowColor);
            for (int i = 1; i < grfExpnD.Rows.Count; i++)
            {
                grfExpnD[i, 0] = i;
                if (i % 2 == 0)
                    grfExpnD.Rows[i].StyleNew.BackColor = color;
            }
            grfExpnD.Cols[colID].Visible = false;
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // ...
            if (keyData == (Keys.Escape))
            {
                Close();
                //if (MessageBox.Show("ต้องการออกจากโปรแกรม1", "ออกจากโปรแกรม", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                //{
                //    Close();
                //    return true;
                //}
            }
            else
            {
                //keyData
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void FrmExpenseDrawD_Load(object sender, EventArgs e)
        {

        }
    }
}

