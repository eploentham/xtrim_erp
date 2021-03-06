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
    public partial class FrmExpenseDraw : Form
    {
        XtrimControl xC;
        ExpensesDraw expnD;
        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;
        int colID = 1, colCode = 2, colDesc = 3, colAmt=4, colRemark = 5;
        int colDid = 1, colDItemNamet = 2, colDQty = 3, colDUnitNameT = 4, colDPrice = 5, colDamt = 6, colDwatx1 = 7, colDamtwtax1=8, colDwatx3 = 9, colDamtwtax3= 10, colDwatx5= 11, colDamtwtax5=12, colDvat = 13;
        int colDtotal = 14, colDremark = 15, colDItemId = 16, colDUnitId = 17, colDpaytocusnamet = 18, colDpaytocusaddr = 19, colDapaytocustax = 20, colDreceiptno = 21;
        int colDreceiptdate=18,colDpaytocusid=19, colDedit=20;
        C1FlexGrid grfExpnD, grfExpnD1;
        //C1TextBox txtPassword = new C1.Win.C1Input.C1TextBox();
        Boolean flagEdit = false;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        String userIdVoid = "", jobId="";
        public String drawId="", flagForm="", flagNew="";
        int flagshow = 0;
        public enum flagForm2 { Cash, Cheque };
        flagForm2 flagfom2;
        public enum flagAction {draw, appv, pay, autoappv};
        flagAction flagaction;
        //String impId = "";
        Customer imp;
        public FrmExpenseDraw(XtrimControl x, String drawid, flagForm2 flagform, flagAction flaga)
        {
            InitializeComponent();
            xC = x;
            drawId = drawid;
            if (drawid.Equals(""))
            {
                flagNew = "new";
            }
            flagfom2 = flagform;
            flagaction = flaga;
            initConfig();
        }
        private void initConfig()
        {
            expnD = new ExpensesDraw();
            fEdit = new Font(xC.iniC.grdViewFontName, xC.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(xC.iniC.grdViewFontName, xC.grdViewFontSize, FontStyle.Bold);

            C1ThemeController.ApplicationTheme = xC.iniC.themeApplication;
            theme1.Theme = C1ThemeController.ApplicationTheme;
            theme1.SetTheme(sB, "BeigeOne");
            foreach (Control c in panel3.Controls)
            {
                theme1.SetTheme(c, "Office2013Red");
            }
            foreach (Control c in panel2.Controls)
            {
                theme1.SetTheme(c, "Office2013Red");
            }
            theme1.SetTheme(panel2, "Office2013Red");
            bg = txtCode.BackColor;
            fc = txtCode.ForeColor;
            ff = txtCode.Font;
            xC.xtDB.stfDB.setCboStaff(cboStaff,xC.userId);
            xC.xtDB.stfDB.setCboStaff(cboDraw, "");
            xC.iniDB.issDB.setCboCusC1(cboIssue, "");
            DateTime jobDate = DateTime.Now;
            txtExpndDrawDate.Value = jobDate.Year.ToString() + "-" + jobDate.ToString("MM-dd");
            jobDate = jobDate.AddDays(7);
            txtDrawDate.Value = jobDate.Year.ToString() + "-" + jobDate.ToString("MM-dd");

            txtPasswordVoid.KeyUp += TxtPasswordVoid_KeyUp;
            txtJobCode.KeyUp += TxtJobCode_KeyUp;
            btnNew.Click += BtnNew_Click;
            btnEdit.Click += BtnEdit_Click;
            btnSave.Click += BtnSave_Click;
            btnDoc.Click += BtnDoc_Click;
            btnAppv.Click += BtnAppv_Click;
            c1Button1.Click += C1Button1_Click;
            btnDNew.Click += BtnDNew_Click;
            btnDEdit.Click += BtnDEdit_Click;
            cboStaff.DropDownClosed += CboStaff_DropDownClosed;
            txtImpNameT.KeyUp += TxtImpNameT_KeyUp;
            chkVoid.Click += ChkVoid_Click;            
            btnVoid.Click += BtnVoid_Click;
            
            initGrfDept();
            initGrfDept1();
            setGrfDeptH();
            setGrfDeptH1();
            
            //setFocusColor();
            
            setControl(drawId);
            setControlEnable(false);
            setControlAppv();

            sB1.Text = "";
            btnVoid.Hide();
            txtPasswordVoid.Hide();
            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            //stt.BackgroundGradient = C1.Win.C1SuperTooltip.BackgroundGradient.Gold;
            imp = new Customer();
            txtAmtOnhand.Value = xC.accDB.expnddDB.selectPayAmountByStf(xC.userId);
        }
        private void BtnVoid_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ ยกเลิกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                String re = xC.accDB.expndDB.VoidExpensesDraw(txtID.Text, userIdVoid);
                MessageBox.Show(re, "");
                //setGrfStfH();
            }
        }
        private void TxtPasswordVoid_KeyUp1(object sender, KeyEventArgs e)
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

        private void ChkVoid_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //new Boolead chkVoid.Checked ? txtPasswordVoid.Show() : txtPasswordVoid.Hide();

            if (chkVoid.Checked)
            {
                txtPasswordVoid.Show();
                txtPasswordVoid.Focus();
                //stt.Show("<p><b>ต้องการยกเลิก</b></p> <br> กรุณาป้อนรหัสผ่าน", txtPasswordVoid);
            }
            else
            {
                txtPasswordVoid.Hide();
            }
        }

        private void TxtImpNameT_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.KeyCode == Keys.F2)
            {
                setKeyUpF2Imp();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                setKeyEnterImp();
            }
        }

        private void CboStaff_DropDownClosed(object sender, DropDownClosedEventArgs e)
        {
            //throw new NotImplementedException();
            setAmtOnhand();
        }
        private void setAmtOnhand()
        {
            String stfid = "";
            stfid = cboStaff.SelectedItem != null ? ((ComboBoxItem)(cboStaff.SelectedItem)).Value : "";

        }

        private void BtnDEdit_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfExpnD[grfExpnD.Row, colDid] == null) return;
            String did = "";
            did = grfExpnD[grfExpnD.Row, colDid]!= null ? grfExpnD[grfExpnD.Row, colDid].ToString() : "";
            FrmExpenseDrawD frm = new FrmExpenseDrawD(xC, did, imp.cust_id, txtImpNameT.Text, imp.taddr1, imp.tax_id, FrmExpenseDrawD.StatusPage.AppvPay, FrmExpenseDrawD.StatusPayType.Cash);
            frm.ShowDialog(this);
            setExpnDD(grfExpnD.Row, grfExpnD[grfExpnD.Row, colDid].ToString());
        }

        private void BtnDNew_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmExpenseDrawD frm;
            if(flagfom2 == flagForm2.Cash)
            {
                frm = new FrmExpenseDrawD(xC, "", imp.cust_id, txtImpNameT.Text, imp.taddr1, imp.tax_id, FrmExpenseDrawD.StatusPage.AppvPay, FrmExpenseDrawD.StatusPayType.Cash);
            }
            else
            {
                frm = new FrmExpenseDrawD(xC, "", imp.cust_id, txtImpNameT.Text, imp.taddr1, imp.tax_id, FrmExpenseDrawD.StatusPage.AppvPay, FrmExpenseDrawD.StatusPayType.Cheque);
            }
            
            frm.ShowDialog(this);
            setExpnDD(0,"");
        }
        private void setExpnDD(int row1, String ddid)
        {
            if (xC.sItm.item_id == null) return;
            if (!xC.sItm.item_id.Equals(""))
            {
                for(int i = 1; i < grfExpnD.Rows.Count; i++)
                {
                    if (grfExpnD[i, colDItemNamet] == null) grfExpnD.RemoveItem(i);
                }
                int row = 0;
                if (row1 > 0)
                {
                    row = row1;
                    grfExpnD[row, colDid] = ddid;
                    grfExpnD.Rows[grfExpnD.Row].StyleNew.BackColor = Color.Gray;
                }
                else
                {
                    row = grfExpnD.Rows.Count++;
                    grfExpnD[row, colDid] = "";
                }
                grfExpnD[row, colDItemId] = xC.sItm.item_id;
                grfExpnD[row, colDItemNamet] = xC.sItm.item_name_t;
                grfExpnD[row, colDQty] = xC.sItm.qty;
                grfExpnD[row, colDUnitNameT] = xC.sItm.unit_name_t;
                grfExpnD[row, colDPrice] = xC.sItm.price1;
                grfExpnD[row, colDamt] = xC.sItm.amt;
                grfExpnD[row, colDwatx1] = xC.sItm.wtax1;
                grfExpnD[row, colDwatx3] = xC.sItm.wtax3;
                grfExpnD[row, colDvat] = xC.sItm.vat;
                grfExpnD[row, colDUnitId] = xC.sItm.unit_id;
                grfExpnD[row, colDtotal] = xC.sItm.total;
                grfExpnD[row, colDpaytocusnamet] = xC.sItm.cust_name_t;
                grfExpnD[row, colDpaytocusaddr] = xC.sItm.cust_addr;
                grfExpnD[row, colDapaytocustax] = xC.sItm.cust_tax;
                grfExpnD[row, colDreceiptno] = xC.sItm.receipt_no;
                grfExpnD[row, colDreceiptdate] = xC.sItm.receipt_date;
                grfExpnD[row, colDpaytocusid] = xC.sItm.cust_id;
                grfExpnD[row, colDremark] = xC.sItm.vat;
                grfExpnD[row, colDedit] = "1";
                grfExpnD[row, colDwatx5] = xC.sItm.wtax5;
                grfExpnD[row, colDamtwtax1] = xC.sItm.amt_wtax1;
                grfExpnD[row, colDamtwtax3] = xC.sItm.amt_wtax3;
                grfExpnD[row, colDamtwtax5] = xC.sItm.amt_wtax5;
                calAmount();
            }
        }
        private void C1Button1_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            txtRemark.Value = xC.datetoDB(txtDrawDate.Text);
        }

        private void TxtJobCode_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if(e.KeyCode== Keys.Enter)
            {
                JobImport jim = xC.manDB.jimDB.selectByJobCode(txtJobCode.Text.Replace(xC.FixJobCode, ""));
                if (!jim.job_import_id.Equals(""))
                {
                    jobId = jim.job_import_id;
                    imp = xC.iniDB.cusDB.selectByPk1(jim.imp_id);
                    setKeyUpF2Imp1(imp);
                    txtJobCode.Value = "IMP"+jim.job_import_code;
                    setGrfDeptH1();
                    txtAmtOnhandJob.Value = xC.accDB.expnddDB.selectPayAmountByStf(xC.userId, jim.job_import_id);
                }
            }
        }
        private void setKeyEnterImp()
        {
            if (txtImpNameT.Text.Length >= 2)
            {
                DataTable dt = new DataTable();
                dt = xC.iniDB.cusDB.selectImpIdByCodeLike(txtImpNameT.Text);
                if (dt.Rows.Count == 1)
                {
                    xC.sImp = new Customer();
                    xC.sImp = xC.iniDB.cusDB.setCustomer(dt);
                    setKeyUpF2Imp1(xC.sImp);
                    imp = xC.sImp;
                }
                else if (dt.Rows.Count > 1)
                {
                    setKeyUpF2Imp();
                }
            }
        }
        private void setKeyUpF2Imp()
        {
            Point pp = txtImpNameT.Location;
            pp.Y = pp.Y + 120 + 20;
            pp.X = pp.X - 20 ;

            FrmSearch frm = new FrmSearch(xC, FrmSearch.Search.Importer, pp);
            frm.ShowDialog(this);
            setKeyUpF2Imp1(xC.sImp);
            imp = xC.sImp;
        }
        private void setKeyUpF2Imp1(Customer imp)
        {
            txtImpAddr.Value = imp.taddr1 + Environment.NewLine + imp.taddr2 + Environment.NewLine + imp.taddr3 + Environment.NewLine + imp.taddr4 + Environment.NewLine + imp.cust_code + Environment.NewLine + imp.remark;
            txtImpNameT.Value = imp.cust_name_t;
            //txtImpContactNameT.Value = imp.contact_name1 + " " + imp.contact_name1_tel;
            //impId = imp.cust_id;
        }
        private void calAmt()
        {
            Decimal chk = 0, amt = 0, price=0, qty=0;
            if (grfExpnD[grfExpnD.Row, colDPrice] == null) return;
            if (grfExpnD[grfExpnD.Row, colDQty] == null) return;

            if (Decimal.TryParse(grfExpnD[grfExpnD.Row, colDPrice].ToString(), out chk))
            {
                price = chk;
            }
            if (Decimal.TryParse(grfExpnD[grfExpnD.Row, colDQty].ToString(), out chk))
            {
                qty = chk;
            }
            amt = price * qty;
            grfExpnD[grfExpnD.Row, colDamt] = amt;
        }
        private void initGrfDept()
        {
            grfExpnD = new C1FlexGrid();
            grfExpnD.Font = fEdit;
            grfExpnD.Dock = System.Windows.Forms.DockStyle.Fill;
            grfExpnD.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpnD);

            grfExpnD.AfterRowColChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.grfExpnD_AfterRowColChange);
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            grfExpnD.CellChanged += GrfExpnD_CellChanged;

            grfExpnD.RowColChange += GrfExpnD_RowColChange;
            grfExpnD.ComboCloseUp += GrfExpnD_ComboCloseUp;
            //grfExpnD.KeyUpEdit += GrfExpnD_KeyUpEdit;
            grfExpnD.KeyUp += GrfExpnD_KeyUp;

            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("&ยกเลิก รายการ", new EventHandler(ContextMenu_cancel));
            grfExpnD.ContextMenu = menuGw;

            panel4.Controls.Add(grfExpnD);

            theme1.SetTheme(grfExpnD, "Office2013Red");            
        }
        private void ContextMenu_cancel(object sender, System.EventArgs e)
        {
            String chk = "";
            chk = grfExpnD[grfExpnD.Row, colDItemNamet] != null ? grfExpnD[grfExpnD.Row, colDItemNamet].ToString() : "";
            if (MessageBox.Show("ต้องการ ยกเลิกรายการ  \n  " + chk, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                grfExpnD.Rows.Remove(grfExpnD.Row);
            }
        }
        private void initGrfDept1()
        {
            grfExpnD1 = new C1FlexGrid();
            grfExpnD1.Font = fEdit;
            grfExpnD1.Dock = System.Windows.Forms.DockStyle.Fill;
            grfExpnD1.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpnD1);

            grfExpnD1.AfterRowColChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.grfExpnD1_AfterRowColChange);
            //grfExpnD1.RowColChange += GrfExpnD1_RowColChange;
            //grfExpnD1.CellChanged += GrfExpnD1_CellChanged;

            panel3.Controls.Add(grfExpnD1);
            
            theme1.SetTheme(grfExpnD1, "VS2013Red");            
        }

        private void GrfExpnD_CellChanged(object sender, RowColEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.Row <= 0) return;
            
            if ((grfExpnD.Col == colDQty))
            {
                //grfExpnD. = colDdesc2;
                calAmt();
                calAmount();
                
            }
            else if ((grfExpnD.Col == colDUnitNameT))
            {

            }
            else if ((grfExpnD.Col == colDPrice))
            {
                calAmt();
                calAmount();
                //grfExpnD[e.Row, colDedit] = "1";
                //grfExpnD.Rows[e.Row].StyleNew.BackColor = Color.Gray;
            }
            if ((grfExpnD.Col == colDPrice) && (grfExpnD.Rows.Count == (grfExpnD.Row + 1))) grfExpnD.Rows.Count++;
        }

        private void GrfExpnD1_RowColChange(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //if (e.r1 < 0) return;
            
            //if ((grfExpnD.Col == colDamt) && (grfExpnD.Rows.Count == (grfExpnD.Row + 1))) grfExpnD.Rows.Count++;
        }
        private void calAmount()
        {
            Decimal amt = 0;
            for(int i = 1; i < grfExpnD.Rows.Count; i++)
            {
                Decimal amt1 = 0;
                if (grfExpnD[i, colDamt] == null) continue;
                if(Decimal.TryParse(grfExpnD[i, colDamt].ToString(), out amt1))
                {
                    amt += amt1;
                }
            }
            txtAmt.Value = amt;
        }
        private void setGrfDeptH()
        {
            grfExpnD.Clear();
            //if (txtID.Text.Equals("")) return;
            DataTable dt = new DataTable();
            
            //if (flagfom2 ==flagForm2.Cash)
            //{
            //    dt = xC.xtDB.expnddDB.selectCashByDrawId1(txtID.Text);
            //    if (dt.Rows.Count <= 1) grfExpnD.Rows.Count = dt.Rows.Count + 2;
            //    else grfExpnD.Rows.Count = dt.Rows.Count + 1;
            //    grfExpnD.Cols.Count = dt.Columns.Count+1;
            //}
            //else
            //{
            dt = xC.accDB.expnddDB.selectChequeByDrawId1(txtID.Text);
            if (dt.Rows.Count <= 1) grfExpnD.Rows.Count = dt.Rows.Count + 2;
            else grfExpnD.Rows.Count = dt.Rows.Count+1;
            grfExpnD.Cols.Count = dt.Columns.Count + 2;
            //}
            //grfExpnD.Rows.Count = 2;
            CellStyle cs = grfExpnD.Styles.Add("date");
            cs.DataType = typeof(DateTime);
            cs.Format = "dd-MM-yyyy";
            
            //cs.ForeColor = Color.DarkGoldenrod;

            C1TextBox txt = new C1TextBox();
            txt.DataType = txtCode.DataType;
            C1TextBox txt1 = new C1TextBox();
            txt1.DataType = txtAmt.DataType;
            C1ComboBox cbo = new C1ComboBox();
            ComboBox cbo1 = new ComboBox();
            xC.iniDB.itmDB.setC1CboItem(cbo);
            xC.iniDB.itmDB.setCboItem(cbo1);
            C1ComboBox cbou = new C1ComboBox();
            C1TextBox txt2 = new C1TextBox();
            txt2.DataType = txtExpndDrawDate.DataType;
            xC.iniDB.utpDB.setC1CboUtp(cbou,"");
            grfExpnD.Cols[colDItemNamet].Editor = cbo1;
            grfExpnD.Cols[colDQty].Editor = txt1;
            grfExpnD.Cols[colDUnitNameT].Editor = cbou;
            grfExpnD.Cols[colDamt].Editor = txt1;
            grfExpnD.Cols[colDPrice].Editor = txt1;
            grfExpnD.Cols[colDwatx1].Editor = txt1;
            grfExpnD.Cols[colDwatx3].Editor = txt1;
            grfExpnD.Cols[colDvat].Editor = txt1;
            grfExpnD.Cols[colDtotal].Editor = txt1;
            grfExpnD.Cols[colDremark].Editor = txt;
            grfExpnD.Cols[colDItemId].Editor = txt;
            grfExpnD.Cols[colDUnitId].Editor = txt;
            //if(flagfom2 == flagForm2.Cheque)
            //{ 
            grfExpnD.Cols[colDpaytocusnamet].Editor = txt;
            grfExpnD.Cols[colDpaytocusaddr].Editor = txt;
            grfExpnD.Cols[colDapaytocustax].Editor = txt;
            grfExpnD.Cols[colDreceiptno].Editor = txt;
            grfExpnD.Cols[colDreceiptdate].Style = cs;
            grfExpnD.Cols[colDpaytocusid].Editor = txt;
            //}

            grfExpnD.Cols[colDQty].Width = 80;
            grfExpnD.Cols[colDUnitNameT].Width = 140;
            grfExpnD.Cols[colDamt].Width = 100;
            grfExpnD.Cols[colDPrice].Width = 80;
            grfExpnD.Cols[colDItemNamet].Width = 220;
            grfExpnD.Cols[colDwatx1].Width = 80;
            grfExpnD.Cols[colDwatx3].Width = 80;
            grfExpnD.Cols[colDvat].Width = 80;
            grfExpnD.Cols[colDtotal].Width = 100;
            grfExpnD.Cols[colDremark].Width = 200;
            //if (flagfom2 == flagForm2.Cheque)
            //{
            grfExpnD.Cols[colDpaytocusnamet].Width = 200;
            grfExpnD.Cols[colDpaytocusaddr].Width = 200;
            grfExpnD.Cols[colDapaytocustax].Width = 80;
            grfExpnD.Cols[colDreceiptno].Width = 100;
            grfExpnD.Cols[colDreceiptdate].Width = 100;
            //}
            

            grfExpnD.ShowCursor = true;
            grfExpnD.Cols[colDItemNamet].Caption = "รายการ";
            grfExpnD.Cols[colDQty].Caption = "QTY";
            grfExpnD.Cols[colDUnitNameT].Caption = "หน่วย";
            grfExpnD.Cols[colDPrice].Caption = "ราคา";
            grfExpnD.Cols[colDamt].Caption = "รวมราคา";
            grfExpnD.Cols[colDwatx1].Caption = "WTAX 1%";
            grfExpnD.Cols[colDwatx3].Caption = "WTAX 3%"; 
            grfExpnD.Cols[colDvat].Caption = "VAT";
            grfExpnD.Cols[colDtotal].Caption = "รวมทั้งหมด";
            grfExpnD.Cols[colDremark].Caption = "หมายเหตุ";
            //if (flagfom2 == flagForm2.Cheque)
            //{
            grfExpnD.Cols[colDpaytocusnamet].Caption = "ชื่อลูกค้า";
            grfExpnD.Cols[colDpaytocusaddr].Caption = "ที่อยู่ลูกค้า";
            grfExpnD.Cols[colDapaytocustax].Caption = "tax id";
            grfExpnD.Cols[colDreceiptno].Caption = "เลขที่ใบเสร็จ";
            grfExpnD.Cols[colDreceiptdate].Caption = "วันที่ในใบเสร็จ";
            //}            
            
            Color color = ColorTranslator.FromHtml(xC.iniC.grfRowColor);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                grfExpnD[i + 1, 0] = i + 1;
                if (i % 2 == 0)
                    grfExpnD.Rows[i+1].StyleNew.BackColor = color;
                grfExpnD[i + 1, colDid] = dt.Rows[i][xC.accDB.expnddDB.expnC.expenses_draw_detail_id].ToString();
                grfExpnD[i + 1, colDItemNamet] = dt.Rows[i][xC.accDB.expnddDB.expnC.item_name_t].ToString();
                grfExpnD[i + 1, colDQty] = dt.Rows[i][xC.accDB.expnddDB.expnC.qty].ToString();
                grfExpnD[i + 1, colDUnitNameT] = dt.Rows[i][xC.accDB.expnddDB.expnC.unit_name_t].ToString();
                grfExpnD[i + 1, colDamt] = dt.Rows[i][xC.accDB.expnddDB.expnC.amount].ToString();
                grfExpnD[i + 1, colDPrice] = dt.Rows[i][xC.accDB.expnddDB.expnC.price].ToString();
                grfExpnD[i + 1, colDwatx1] = dt.Rows[i][xC.accDB.expnddDB.expnC.wtax1].ToString();
                grfExpnD[i + 1, colDwatx3] = dt.Rows[i][xC.accDB.expnddDB.expnC.wtax3].ToString();
                grfExpnD[i + 1, colDvat] = dt.Rows[i][xC.accDB.expnddDB.expnC.vat].ToString();
                grfExpnD[i + 1, colDtotal] = dt.Rows[i][xC.accDB.expnddDB.expnC.total].ToString();
                grfExpnD[i + 1, colDremark] = dt.Rows[i][xC.accDB.expnddDB.expnC.remark].ToString();
                grfExpnD[i + 1, colDItemId] = dt.Rows[i][xC.accDB.expnddDB.expnC.item_id].ToString();
                //if (flagfom2 == flagForm2.Cheque)
                //{
                grfExpnD[i + 1, colDpaytocusnamet] = dt.Rows[i][xC.accDB.expnddDB.expnC.pay_to_cus_name_t].ToString();
                grfExpnD[i + 1, colDpaytocusaddr] = dt.Rows[i][xC.accDB.expnddDB.expnC.pay_to_cus_addr].ToString();
                grfExpnD[i + 1, colDapaytocustax] = dt.Rows[i][xC.accDB.expnddDB.expnC.pay_to_cus_tax].ToString();
                grfExpnD[i + 1, colDreceiptno] = dt.Rows[i][xC.accDB.expnddDB.expnC.receipt_no].ToString();
                grfExpnD[i + 1, colDreceiptdate] = dt.Rows[i][xC.accDB.expnddDB.expnC.receipt_date].ToString();
                grfExpnD[i + 1, colDpaytocusid] = dt.Rows[i][xC.accDB.expnddDB.expnC.pay_to_cus_id].ToString();
                grfExpnD[i + 1, colDedit] = "-";
                //}
            }
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //if (grfPic.Rows.Count == (grfPic.Row + 1)) grfPic.Rows.Count++;
            //grfExpnD.AfterRowColChange += GrfExpnD_AfterRowColChange;
            
            if (flagForm.Equals("pay"))
            {
                ContextMenu menuGw = new ContextMenu();
                menuGw.MenuItems.Add("&จ่ายเงิน รายการเบิก", new EventHandler(ContextMenu_pay));
                //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
                //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
                grfExpnD.ContextMenu = menuGw;
            }
            grfExpnD.Cols[colDid].Visible = false;
            grfExpnD.Cols[colDItemId].Visible = false;
            grfExpnD.Cols[colDUnitId].Visible = false;
            grfExpnD.Cols[colDedit].Visible = false;
            if (flagfom2 == flagForm2.Cheque)
            {
                grfExpnD.Cols[colDpaytocusid].Visible = false;
            }
        }

        private void GrfExpnD_ComboCloseUp(object sender, RowColEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.Col == colDItemNamet)
            {
                //MessageBox.Show("aaaa", "");
            }
        }

        private void GrfExpnD_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if (grfExpnD.Col == colDpaytocusnamet)
            {
                if (e.KeyCode == Keys.F4)
                {
                    flagshow++;
                    if (flagshow > 1) return;
                    int yy = grfExpnD.Rows[grfExpnD.Row].Height * grfExpnD.Rows.Count;
                    Point pp = grfExpnD.Location;
                    pp.Y = pp.Y + yy;
                    pp.X = pp.X + 240;

                    FrmSearch frm = new FrmSearch(xC, FrmSearch.Search.Customer, pp);
                    frm.ShowDialog(this);
                    grfExpnD[grfExpnD.Row, colDpaytocusnamet] = xC.sCus.cust_name_t;
                    grfExpnD[grfExpnD.Row, colDpaytocusid] = xC.sCus.cust_id;
                    grfExpnD[grfExpnD.Row, colDpaytocusaddr] = xC.sCus.taddr1;
                }
            }
        }

        private void GrfExpnD_KeyUpEdit(object sender, KeyEditEventArgs e)
        {
            //throw new NotImplementedException();
            
        }

        private void GrfExpnD_RowColChange(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            flagshow = 0;
            if (grfExpnD.Col == colDItemNamet)
            {
                //grfExpnD.Col = colDQty;
                //MessageBox.Show("aaaa","");
            }
            else if (grfExpnD.Col == colDPrice)
            {
                if (grfExpnD.Rows.Count == (grfExpnD.Row)) grfExpnD.Rows.Count++;
            }
            else if (grfExpnD.Col == colDpaytocusnamet)
            {
                
            }
        }

        private void GrfExpnD_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.OldRange.c1 == colDPrice)
            {
                if (grfExpnD.Rows.Count == (grfExpnD.Row + 1)) grfExpnD.Rows.Count++;
                grfExpnD.Col = colDQty;
            }
            //else if (e.OldRange.c1 == colDItemNamet)
            //{

            //}
        }

        private void setGrfDeptH1()
        {
            grfExpnD1.DataSource = null;
            grfExpnD1.Rows.Count = 2;
            grfExpnD1.Clear();
            if (txtJobCode.Text.Equals("")) return;
            grfExpnD1.DataSource = xC.accDB.expndDB.selectByJobCode2(txtJobCode.Text.Replace("IMP",""));

            grfExpnD1.Cols.Count = 6;
            TextBox txt = new TextBox();

            grfExpnD1.Cols[colCode].Editor = txt;
            grfExpnD1.Cols[colDesc].Editor = txt;
            grfExpnD1.Cols[colRemark].Editor = txt;
            grfExpnD1.Cols[colAmt].Editor = txt;

            grfExpnD1.Cols[colAmt].Width = 80;
            grfExpnD1.Cols[colCode].Width = 60;
            grfExpnD1.Cols[colDesc].Width = 200;
            grfExpnD1.Cols[colRemark].Width = 100;

            grfExpnD1.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";
            grfExpnD1.Cols[colAmt].Caption = "ยอดเงิน";
            grfExpnD1.Cols[colCode].Caption = "เลขที่ใบเบิก";
            grfExpnD1.Cols[colDesc].Caption = "รายละเอียด";
            grfExpnD1.Cols[colRemark].Caption = "หมายเหตุ";
            Color color = ColorTranslator.FromHtml(xC.iniC.grfRowColor);
            for (int i = 1; i < grfExpnD1.Rows.Count; i++)
            {
                grfExpnD1[i, 0] = i;
                if (i % 2 == 0)
                    grfExpnD1.Rows[i].StyleNew.BackColor = color;
            }
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            grfExpnD1.Cols[colID].Visible = false;
            
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

            this.txtDesc.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtDesc.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtRemark.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtRemark.Enter += new System.EventHandler(this.textBox_Enter);
        }
        private void setControl(String deptId)
        {
            expnD = xC.accDB.expndDB.selectByPk1(deptId);
            if (expnD.expenses_draw_id.Equals(""))
            {
                txtID.Value = "";
                txtCode.Value = "";
                txtJobCode.Value = "IMP" + expnD.job_code;
                txtDesc.Value = "";
                txtRemark.Value = "";
                DateTime jobDate = DateTime.Now;
                txtExpndDrawDate.Value = jobDate.Year.ToString() + "-" + jobDate.ToString("MM-dd");
                jobDate = jobDate.AddDays(7);
                txtDrawDate.Value = jobDate.Year.ToString() + "-" + jobDate.ToString("MM-dd");
                txtAmt.Value = 0;
            }
            else
            {
                txtID.Value = expnD.expenses_draw_id;
                txtCode.Value = expnD.expenses_draw_code;
                txtJobCode.Value = "IMP" + expnD.job_code;
                txtDesc.Value = expnD.desc1;
                txtRemark.Value = expnD.remark;
                txtExpndDrawDate.Value = expnD.expenses_draw_date;
                txtDrawDate.Value = expnD.draw_date;
                txtAmt.Value = expnD.amount;
                xC.setC1Combo(cboStaff, expnD.staff_id);
                imp = xC.iniDB.cusDB.selectByPk1(expnD.payer_id);
                setKeyUpF2Imp1(imp);
                xC.xtDB.stfDB.setCboStaff(cboStaff, expnD.staff_id);
            }

            setGrfDeptH();
            setGrfDeptH1();
            if (expnD.status_appv.Equals("0"))
            {
                label8.Text = "...";
            }
            else if (expnD.status_appv.Equals("1"))
            {
                label8.Text = "รออนุมัติ";
                label8.ForeColor = Color.Red;
            }
            else if (expnD.status_appv.Equals("2"))
            {
                label8.Text = "อนุมัติแล้ว";
                label8.ForeColor = Color.SaddleBrown;
            }
            if (expnD.status_pay.Equals("2"))
            {
                label8.Text = "จ่ายเงินแล้ว";
                label8.ForeColor = Color.Gray;
                setControlAppv();
                setControlEnablePay();
            }
            if (flagfom2 == flagForm2.Cash)
            {
                label9.Show();
                txtAmtOnhand.Show();
            }
            else
            {
                label9.Hide();
                txtAmtOnhand.Hide();
            }
        }
        private void setControlEnablePay()
        {
            btnDoc.Enabled = false;
            btnNew.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = false;
        }
        private void setControlEnable(Boolean flag)
        {
            //txtID.Enabled = flag;
            txtCode.Enabled = flag;
            txtDesc.Enabled = flag;
            txtRemark.Enabled = flag;
            chkVoid.Enabled = flag;
            txtExpndDrawDate.Enabled = flag;
            txtDrawDate.Enabled = flag;
            txtImpAddr.Enabled = flag;
            txtImpNameT.Enabled = flag;
            txtDesc.Enabled = flag;
            txtRemark.Enabled = flag;
            txtAmt.Enabled = false;
            txtAmtOnhand.Enabled = false;
            txtAmtOnhandJob.Enabled = false;
            txtAppvAmt.Enabled = flag;
            btnDNew.Enabled = flag;
            btnDEdit.Enabled = flag;
            txtJobCode.Enabled = flag;
            cboStaff.Enabled = flag;
            grfExpnD.Enabled = flag;
            cboDraw.Enabled = flag;
            btnEdit.Image = !flag ? Resources.lock24 : Resources.open24;
        }
        private void setControlAppv()
        {
            if (flagaction == flagAction.draw)
            {
                btnDoc.Show();
                btnNew.Show();
                btnSave.Show();
                btnVoid.Show();
                btnEdit.Show();
                btnAppv.Hide();
                label7.Hide();
                txtAppvAmt.Hide();
            }
            //else if (flagForm.Equals("view"))
            //{
            //    btnDoc.Show();
            //    btnNew.Show();
            //    btnSave.Show();
            //    btnVoid.Show();
            //    btnEdit.Show();
            //    btnAppv.Hide();
            //    label7.Hide();
            //    txtAppvAmt.Hide();
            //}
            else if (flagaction == flagAction.appv)
            {
                btnDoc.Hide();
                btnNew.Hide();
                btnSave.Hide();
                btnVoid.Hide();
                btnEdit.Hide();
                btnAppv.Show();
                label7.Show();
                if (txtCode.Text.Equals(""))
                {
                    btnAppv.Enabled = false;
                }
                else{
                    btnAppv.Enabled = true;
                }
                txtAppvAmt.Show();
                flagEdit = true;
                setControlEnable(flagEdit);
                txtAppvAmt.Value = txtAmt.Text.Replace("$","").Replace(",", "");
            }
            else if (flagaction == flagAction.pay)
            {
                btnDoc.Hide();
                btnNew.Hide();
                btnSave.Hide();
                btnVoid.Hide();
                btnEdit.Hide();
                btnAppv.Hide();
                label7.Show();
                txtAppvAmt.Show();
            }
            else if (flagaction == flagAction.autoappv)
            {
                btnDoc.Hide();
                btnNew.Hide();
                btnSave.Show();
                btnVoid.Show();
                btnEdit.Hide();
                btnAppv.Hide();
                label7.Show();
                txtAppvAmt.Show();
                flagEdit = true;
                setControlEnable(flagEdit);
                xC.setC1Combo(cboStaff, xC.userIderc);
            }
        }
        private void setExpensesDraw()
        {
            expnD.expenses_draw_id = txtID.Text;
            expnD.expenses_draw_code = txtCode.Text;
            expnD.desc1 = txtDesc.Text;
            expnD.remark = txtRemark.Text;
            expnD.expenses_draw_date = xC.datetoDB(txtExpndDrawDate.Text);
            expnD.draw_date = xC.datetoDB(txtDrawDate.Text);
            expnD.staff_id = cboStaff.SelectedItem != null ? ((ComboBoxItem)(cboStaff.SelectedItem)).Value : "";
            expnD.job_code = txtJobCode.Text.Replace("IMP","");
            expnD.job_id = jobId;
            expnD.amount = txtAmt.Value.ToString();
            expnD.year = (DateTime.Parse(txtDrawDate.Text)).Year.ToString();
            //imp = xC.xtDB.cusDB.selectIdByNameTLike(txtImpNameT.Text.Trim());
            expnD.payer_id = xC.iniDB.cusDB.selectImpIdByNameTLike1(txtImpNameT.Text.Trim());
            if (label8.Text.Equals("..."))
            {
                expnD.status_appv = "0";
            }
            else if (label8.Text.Equals("รออนุมัติ"))
            {
                expnD.status_appv = "1";
            }
            else if (label8.Text.Equals("อนุมัติแล้ว"))
            {
                expnD.status_appv = "2";
            }
            if(flagfom2 == flagForm2.Cash)
            {
                expnD.status_pay_type = "1";
            }
            else
            {
                expnD.status_pay_type = "2";
            }
            expnD.status_pay = "1";
            expnD.status_page = "1";
            expnD.status_doc = "0";
        }
        private void setExpensesDrawDetail(String expnid, String cusid)
        {
            for (int i = 1; i < grfExpnD.Rows.Count; i++)
            {
                if (grfExpnD.Row <= 0) continue;
                if (grfExpnD[i, colDedit] == null) continue;
                if (!grfExpnD[i, colDedit].ToString().Equals("1")) continue;

                ExpensesDrawDatail expndd = new ExpensesDrawDatail();
                expndd.expense_draw_id = expnid;
                expndd.expenses_draw_detail_id = grfExpnD[i, colDid] == null ? "" : grfExpnD[i, colDid].ToString();

                expndd.qty = grfExpnD[i, colDQty] == null ? "" : grfExpnD[i, colDQty].ToString();
                expndd.unit_id = grfExpnD[i, colDUnitNameT] == null ? "" : xC.iniDB.utpDB.getIdByName(grfExpnD[i, colDUnitNameT].ToString().Trim());
                expndd.unit_name_t = grfExpnD[i, colDUnitNameT] == null ? "" : grfExpnD[i, colDUnitNameT].ToString();
                expndd.amount = grfExpnD[i, colDamt] == null ? "" : grfExpnD[i, colDamt].ToString();
                expndd.remark = grfExpnD[i, colDremark] == null ? "" : grfExpnD[i, colDremark].ToString();
                expndd.item_id = grfExpnD[i, colDItemNamet] == null ? "" : xC.iniDB.itmDB.getIdByName(grfExpnD[i, colDItemNamet].ToString().Trim());
                expndd.item_name_t = grfExpnD[i, colDItemNamet] == null ? "" : grfExpnD[i, colDItemNamet].ToString();
                expndd.price = grfExpnD[i, colDPrice] == null ? "" : grfExpnD[i, colDPrice].ToString();
                expndd.wtax1 = grfExpnD[i, colDwatx1] == null ? "" : grfExpnD[i, colDwatx1].ToString();
                expndd.wtax3 = grfExpnD[i, colDwatx3] == null ? "" : grfExpnD[i, colDwatx3].ToString();
                expndd.vat = grfExpnD[i, colDvat] == null ? "" : grfExpnD[i, colDvat].ToString();
                expndd.total = grfExpnD[i, colDtotal] == null ? "" : grfExpnD[i, colDtotal].ToString();
                expndd.job_code = txtJobCode.Text;
                expndd.job_id = jobId;
                if (flagfom2 == flagForm2.Cheque)
                {
                    expndd.pay_to_cus_name_t = grfExpnD[i, colDpaytocusnamet] == null ? "" : grfExpnD[i, colDpaytocusnamet].ToString();
                    expndd.pay_to_cus_addr = grfExpnD[i, colDpaytocusaddr] == null ? "" : grfExpnD[i, colDpaytocusaddr].ToString();
                    expndd.pay_to_cus_tax = grfExpnD[i, colDapaytocustax] == null ? "" : grfExpnD[i, colDapaytocustax].ToString();
                    expndd.receipt_no = grfExpnD[i, colDreceiptno] == null ? "" : grfExpnD[i, colDreceiptno].ToString();
                    expndd.receipt_date = grfExpnD[i, colDreceiptdate] == null ? "" : grfExpnD[i, colDreceiptdate].ToString();
                    expndd.pay_to_cus_id = grfExpnD[i, colDpaytocusid] == null ? "" : grfExpnD[i, colDpaytocusid].ToString();
                }
                if (flagfom2==flagForm2.Cash)
                {
                    expndd.status_pay_type = "1";
                }
                else
                {
                    expndd.status_pay_type = "2";
                }
                expndd.status_page = "1";
                expndd.status_hide = "1";
                expndd.job_id = jobId;
                expndd.status_doc = "0";
                if(flagaction == flagAction.autoappv)
                {
                    expndd.status_erc = "1";
                    expndd.pay_amount = expndd.amount;
                    expndd.pay_staff_id = cboStaff.SelectedItem != null ? ((ComboBoxItem)(cboStaff.SelectedItem)).Value : "";
                }
                else
                {
                    expndd.status_erc = "0";
                }
                
                if (!expndd.amount.Equals(""))
                {
                    xC.accDB.expnddDB.insertExpenseDrawDetail(expndd, xC.userId);
                }
            }
        }
        private void grfExpnD_AfterRowColChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {
            if (e.NewRange.r1 < 0) return;
            if (e.NewRange.Data == null) return;
            //if (e.NewRange.Data == null) return;

            //String deptId = "";
            //deptId = grfExpnD[e.NewRange.r1, colID] != null ? grfExpnD[e.NewRange.r1, colID].ToString() : "";
            //setControl(deptId);
            //setControlEnable(false);
            //if(grfExpnD[e.OldRange.r1, e.OldRange.c1].ToString().Equals(grfExpnD[e.NewRange.r1, e.NewRange.c1].ToString()))
            //{
            //    grfExpnD[e.OldRange.r1, colDedit] = "1";
            //    grfExpnD.Rows[e.OldRange.r1].StyleNew.BackColor = Color.Gray;
            //}
            
            //setControlAddr(addrId);
            //setControlAddrEnable(false);
        }
        private void grfExpnD1_AfterRowColChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {
            if (e.NewRange.r1 < 0) return;
            if (e.NewRange.Data == null) return;
            

        }
        private void ContextMenu_pay(object sender, System.EventArgs e)
        {
            if (grfExpnD.Row == null) return;
            if (grfExpnD.Row < 0) return;

            String drawdId = "";
            drawdId = grfExpnD[grfExpnD.Row, colID] != null ? grfExpnD[grfExpnD.Row, colID].ToString() : "";
            FrmExpenseDrawPay frm = new FrmExpenseDrawPay(xC, drawdId, "pay");
            //frm.drawId = xC.drawID;
            //frm.flagForm = "appv";
            frm.WindowState = FormWindowState.Normal;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog(this);
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
        private void BtnAppv_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ อนุมัติ  \n การเบิกเงิน  ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                String re = xC.accDB.expndDB.updateStatusApprove(txtID.Text);
                int chk = 0;
                if (int.TryParse(re, out chk))
                {
                    setControl(drawId);
                }
            }
        }
        private void BtnDoc_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ ออกเลขที่เอกสาร  \n การเบิกเงิน และส่งข้อมูล ขออนุมัติ ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                String re = xC.updateDrawSendToApprove(txtID.Text);
                int chk = 0;
                if(int.TryParse(re, out chk))
                {
                    //ExpensesDraw expnd = new ExpensesDraw();
                    //expnd = xC.xtDB.expndDB.selectByPk1(txtID.Text);
                    //txtCode.Value = expnd.expenses_draw_code;
                    setControl(txtID.Text);
                    setControlEnable(false);
                }
            }
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                setExpensesDraw();
                String re = xC.accDB.expndDB.insertExpenseDraw(expnD, xC.user.staff_id);
                int chk = 0;
                if (int.TryParse(re, out chk))
                {
                    JobImport jim = new JobImport();
                    jim = xC.manDB.jimDB.selectByPk1(jobId);
                    if (flagNew.Equals("new"))
                    {
                        setExpensesDrawDetail(re, jim.cust_id);
                    }
                    else
                    {
                        setExpensesDrawDetail(txtID.Text, jim.cust_id);
                    }
                    txtID.Value = re;
                    if(flagaction == flagAction.autoappv)
                    {
                        re = "";
                        re = xC.updateDrawSendToApprove(txtID.Text);
                        if (int.TryParse(re, out chk))
                        {
                            re = "";
                            re = xC.accDB.expndDB.updateStatusApprove(txtID.Text);
                            if (int.TryParse(re, out chk))
                            {
                                Close();
                            }
                        }
                    }
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
            txtDesc.Value = "";
            txtRemark.Value = "";
            chkVoid.Checked = false;
            btnVoid.Hide();
            setControlEnable(true);
        }
        private void FrmExpenseDraw_Load(object sender, EventArgs e)
        {

        }
    }
}
