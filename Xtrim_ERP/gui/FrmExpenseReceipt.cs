using C1.Win.C1FlexGrid;
using C1.Win.C1SuperTooltip;
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
    public partial class FrmExpenseReceipt : Form
    {
        XtrimControl xC;
        JobImport jim;
        ExpensesDraw expnD;
        //MainMenu4 menu;

        Font fEdit, fEditB;
        Color bg, fc, cgrfOld;
        Font ff, ffB;
        C1FlexGrid grfExpnD;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;

        int colDid = 1, colDItemNamet = 2, colDQty = 3, colDUnitNameT = 4, colDPrice = 5, colDamt = 6, colDwatx1 = 7, colDwatx3 = 8, colDvat = 9;
        int colDtotal = 10, colDremark = 11, colDItemId = 12, colDUnitId = 13, colDpaytocusnamet = 14, colDpaytocusaddr = 15, colDapaytocustax = 16, colDreceiptno = 17;
        int colDreceiptdate = 18, colDpaytocusid = 19, colDedit = 20, colDstatuspage = 21;

        public FrmExpenseReceipt(XtrimControl x)
        {
            InitializeComponent();
            xC = x;
            //menu = m;
            initConfig();
        }
        private void initConfig()
        {
            jim = new JobImport();
            expnD = new ExpensesDraw();
            xC.xtDB.stfDB.setCboStaff(cboStaff, "");
            initGrfExpnD();

            txtJobCode.KeyUp += TxtJobCode_KeyUp;
        }

        private void TxtJobCode_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.KeyCode == Keys.Enter)
            {
                txtJobCode.Text = txtJobCode.Text.Replace(xC.FixJobCode, "");
                jim = xC.xtDB.jimDB.selectByJobCode(txtJobCode.Text);
                txtID.Value = jim.job_import_id;
                setGrfExpnD(txtID.Text);
            }
        }

        private void initGrfExpnD()
        {
            grfExpnD = new C1FlexGrid();
            grfExpnD.Dock = DockStyle.Fill;
            TextBox txt = new TextBox();

            //grfExpnD.Cols[colContainId].Editor = txt;
            //grfExpnD.Cols[colContainQty].Editor = txt;
            //grfExpnD.Cols[colContainContainId].Editor = txt;
            //grfExpnD.Cols[colContainQty].Caption = "qty";
            //grfExpnD.Cols[colContainContainId].Caption = "TYPE";

            panel3.Controls.Add(grfExpnD);

            grfExpnD.Rows.Count = 1;
            grfExpnD.Cols.Count = 22;
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

            //grfExpnD.CellChanged += GrfContain_CellChanged;

            ContextMenu menuJclExp = new ContextMenu();
            menuJclExp.MenuItems.Add("&ป้อนใบเสร็จรับเงิน", new EventHandler(ContextMenu_JclExp_new));

            grfExpnD.ContextMenu = menuJclExp;
        }
        private void setGrfExpnD(String jobid)
        {
            grfExpnD.Clear();
            grfExpnD.Rows.Count = 1;
            DataTable dt = new DataTable();
            dt = xC.xtDB.expnddDB.selectByJobId(jobid);

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

            Color color = ColorTranslator.FromHtml(xC.iniC.grfRowColor);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                String hide = "";
                hide = dt.Rows[i][xC.xtDB.expnddDB.expnC.status_hide] != null ? dt.Rows[i][xC.xtDB.expnddDB.expnC.status_hide].ToString() : "";
                if (hide.Equals("2")) continue;
                Row row = grfExpnD.Rows.Add();
                row[0] = i + 1;
                if (i % 2 == 0)
                    grfExpnD.Rows[i].StyleNew.BackColor = color;
                row[colDid] = dt.Rows[i][xC.xtDB.expnddDB.expnC.expenses_draw_detail_id].ToString();
                row[colDItemNamet] = dt.Rows[i][xC.xtDB.expnddDB.expnC.item_name_t].ToString();
                row[colDQty] = dt.Rows[i][xC.xtDB.expnddDB.expnC.qty].ToString();
                row[colDUnitNameT] = dt.Rows[i][xC.xtDB.expnddDB.expnC.unit_name_t].ToString();
                row[colDamt] = dt.Rows[i][xC.xtDB.expnddDB.expnC.amount].ToString();
                row[colDPrice] = dt.Rows[i][xC.xtDB.expnddDB.expnC.price].ToString();
                row[colDwatx1] = dt.Rows[i][xC.xtDB.expnddDB.expnC.wtax1].ToString();
                row[colDwatx3] = dt.Rows[i][xC.xtDB.expnddDB.expnC.wtax3].ToString();
                row[colDvat] = dt.Rows[i][xC.xtDB.expnddDB.expnC.vat].ToString();
                row[colDtotal] = dt.Rows[i][xC.xtDB.expnddDB.expnC.total].ToString();
                row[colDremark] = dt.Rows[i][xC.xtDB.expnddDB.expnC.remark].ToString();
                row[colDItemId] = dt.Rows[i][xC.xtDB.expnddDB.expnC.item_id].ToString();
                //if (flagfom2 == flagForm2.Cheque)
                //{
                row[colDpaytocusnamet] = dt.Rows[i][xC.xtDB.expnddDB.expnC.pay_to_cus_name_t].ToString();
                row[colDpaytocusaddr] = dt.Rows[i][xC.xtDB.expnddDB.expnC.pay_to_cus_addr].ToString();
                row[colDapaytocustax] = dt.Rows[i][xC.xtDB.expnddDB.expnC.pay_to_cus_tax].ToString();
                row[colDreceiptno] = dt.Rows[i][xC.xtDB.expnddDB.expnC.receipt_no].ToString();
                row[colDreceiptdate] = dt.Rows[i][xC.xtDB.expnddDB.expnC.receipt_date].ToString();
                row[colDpaytocusid] = dt.Rows[i][xC.xtDB.expnddDB.expnC.pay_to_cus_id].ToString();
                row[colDedit] = "-";
                row[colDstatuspage] = dt.Rows[i][xC.xtDB.expnddDB.expnC.status_page].ToString();
                if (dt.Rows[i][xC.xtDB.expnddDB.expnC.status_page].ToString().Equals("2"))
                {
                    grfExpnD.Rows[i].StyleNew.BackColor = xC.cTxtFocus;
                }
            }
            grfExpnD.Cols[colDid].Visible = false;
            grfExpnD.Cols[colDstatuspage].Visible = false;
            grfExpnD.Cols[colDedit].Visible = false;
            grfExpnD.Cols[colDpaytocusid].Visible = false;
            grfExpnD.Cols[colDItemId].Visible = false;
            grfExpnD.Cols[colDUnitId].Visible = false;
            calDamount();
        }
        private void setExpensesDraw()
        {
            expnD.expenses_draw_id = "";
            expnD.expenses_draw_code = "";  //ไม่ได้ เบิกเงิน ไม่ต้องอนุมัติ ไม่ต้อง gen doc
            expnD.desc1 = "";
            expnD.remark = "";

            //expnD.expenses_draw_date = xC.datetoDB(txtJobDate.Text);
            //expnD.draw_date = xC.datetoDB(txtJobDate.Text);
            expnD.staff_id = cboStaff.SelectedItem != null ? ((ComboBoxItem)(cboStaff.SelectedItem)).Value : "";
            expnD.job_code = txtJobCode.Text.Replace("IMP", "");
            expnD.job_id = txtID.Text;
            expnD.amount = txtAmt.Value.ToString();
            expnD.year = DateTime.Now.Year.ToString();
            //imp = xC.xtDB.cusDB.selectIdByNameTLike(txtImpNameT.Text.Trim());
            //expnD.payer_id = xC.xtDB.cusDB.selectImpIdByNameTLike1(txtImpNameT.Text.Trim());
            //if (label8.Text.Equals("..."))
            //{
            //    expnD.status_appv = "0";
            //}
            //else if (label8.Text.Equals("รออนุมัติ"))
            //{
            //    expnD.status_appv = "1";
            //}
            //else if (label8.Text.Equals("อนุมัติแล้ว"))
            //{
            //    expnD.status_appv = "2";
            //}

            expnD.status_pay_type = "1";        // cash  fix ไปเลย เพราะ ป้อนเก็บข้อมูล ไม่ได้ทำเบิก

            expnD.status_pay = "1";
            expnD.status_page = "2";
        }
        private Boolean setExpensesDrawDetail(String expnid, String cusid)
        {
            Boolean re = false;
            int chk = 0, chkD = 0, chkD1 = 0;
            for (int i = 1; i < grfExpnD.Rows.Count; i++)
            {
                if (grfExpnD.Row <= 0) continue;
                if (!grfExpnD[i, colDedit].ToString().Equals("1")) continue;
                chkD1++;
                ExpensesDrawDatail expndd = new ExpensesDrawDatail();
                expndd.expense_draw_id = expnid;
                expndd.expenses_draw_detail_id = grfExpnD[i, colDid] == null ? "" : grfExpnD[i, colDid].ToString();

                expndd.qty = grfExpnD[i, colDQty] == null ? "" : grfExpnD[i, colDQty].ToString();
                expndd.unit_id = grfExpnD[i, colDUnitNameT] == null ? "" : xC.xtDB.utpDB.getIdByName(grfExpnD[i, colDUnitNameT].ToString().Trim());
                expndd.unit_name_t = grfExpnD[i, colDUnitNameT] == null ? "" : grfExpnD[i, colDUnitNameT].ToString();
                expndd.amount = grfExpnD[i, colDamt] == null ? "" : grfExpnD[i, colDamt].ToString();
                expndd.remark = grfExpnD[i, colDremark] == null ? "" : grfExpnD[i, colDremark].ToString();
                expndd.item_id = grfExpnD[i, colDItemNamet] == null ? "" : xC.xtDB.itmDB.getIdByName(grfExpnD[i, colDItemNamet].ToString().Trim());
                expndd.item_name_t = grfExpnD[i, colDItemNamet] == null ? "" : grfExpnD[i, colDItemNamet].ToString();
                expndd.price = grfExpnD[i, colDPrice] == null ? "" : grfExpnD[i, colDPrice].ToString();
                expndd.wtax1 = grfExpnD[i, colDwatx1] == null ? "" : grfExpnD[i, colDwatx1].ToString();
                expndd.wtax3 = grfExpnD[i, colDwatx3] == null ? "" : grfExpnD[i, colDwatx3].ToString();
                expndd.vat = grfExpnD[i, colDvat] == null ? "" : grfExpnD[i, colDvat].ToString();
                expndd.total = grfExpnD[i, colDtotal] == null ? "" : grfExpnD[i, colDtotal].ToString();
                expndd.job_code = txtJobCode.Text;
                expndd.job_id = txtID.Text;
                //if (flagfom2 == flagForm2.Cheque)
                //{
                expndd.pay_to_cus_name_t = grfExpnD[i, colDpaytocusnamet] == null ? "" : grfExpnD[i, colDpaytocusnamet].ToString();
                expndd.pay_to_cus_addr = grfExpnD[i, colDpaytocusaddr] == null ? "" : grfExpnD[i, colDpaytocusaddr].ToString();
                expndd.pay_to_cus_tax = grfExpnD[i, colDapaytocustax] == null ? "" : grfExpnD[i, colDapaytocustax].ToString();
                expndd.receipt_no = grfExpnD[i, colDreceiptno] == null ? "" : grfExpnD[i, colDreceiptno].ToString();
                expndd.receipt_date = grfExpnD[i, colDreceiptdate] == null ? "" : grfExpnD[i, colDreceiptdate].ToString();
                expndd.pay_to_cus_id = grfExpnD[i, colDpaytocusid] == null ? "" : grfExpnD[i, colDpaytocusid].ToString();
                //}
                expndd.status_pay_type = "1";   // cash  fix ไปเลย เพราะ ป้อนเก็บข้อมูล ไม่ได้ทำเบิก
                expndd.status_page = "2";
                expndd.status_hide = "2";
                //expndd.job_id = jobId;
                //expndd.cust_id = cusid;
                if (!expndd.amount.Equals(""))
                {
                    String re1 = "";
                    re1 = xC.xtDB.expnddDB.insertExpenseDrawDetail(expndd, xC.userId);
                    if (int.TryParse(re1, out chk))
                    {
                        chkD++;
                        grfExpnD[i, colDedit] = "-";
                        grfExpnD.Rows[i].StyleNew.BackColor = xC.cTxtFocus;
                    }
                }
            }
            if (chkD == chkD1)
            {
                re = true;
            }
            return re;
        }
        private void calDamount()
        {
            Decimal amt = 0, amt2 = 0;
            for (int i = 1; i < grfExpnD.Rows.Count; i++)
            {
                Decimal amt1 = 0;
                if (grfExpnD[i, colDamt] == null) continue;
                if (Decimal.TryParse(grfExpnD[i, colDamt].ToString(), out amt1))
                {
                    amt += amt1;
                }
                if (grfExpnD[i, colDstatuspage].ToString().Equals("2"))
                {
                    amt2 += amt1;
                }
            }
            txtAmt.Value = amt;
            txtddAmt1.Value = amt2;
        }
        private void ContextMenu_JclExp_new(object sender, System.EventArgs e)
        {
            FrmJobImpCheckListExp frm = new FrmJobImpCheckListExp(xC);
            frm.ShowDialog(this);
        }
        private void FrmExpenseReceipt_Load(object sender, EventArgs e)
        {

        }
    }
}
