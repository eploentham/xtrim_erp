using C1.Win.C1FlexGrid;
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
    public partial class FrmExpenseReceiptCashAppv : Form
    {
        XtrimControl xC;
        JobImport jim;
        ExpensesClearCash ecc;

        C1FlexGrid grfEcc, grfPd;

        int colPdChk=1, colPdId = 2, colPdItmNameT = 3, colPdPayamt = 4;
        int colEccChk=1, colEccId = 2, colEccDoc = 3, colItmNameT = 4, colEccAmt = 5, colReceiptNo = 6, colReceiptDate = 7, colJobCode = 8, colEccPdId = 9, colflag=10;

        public FrmExpenseReceiptCashAppv(XtrimControl x)
        {
            InitializeComponent();
            xC = x;
            initConfig();
        }
        private void initConfig()
        {
            jim = new JobImport();
            ecc = new ExpensesClearCash();
            xC.setCboYear(cboYear);
            xC.xtDB.stfDB.setCboStaff(cboStaff, "");
            chkAppvWait.Checked = true;

            cboStaff.SelectedItemChanged += CboStaff_SelectedItemChanged;
            btnRefund.Click += BtnRefund_Click;
            btnDNew.Click += BtnDNew_Click;
            btnCal.Click += BtnCal_Click;

            initGrfEcc();
            initGrPd();
        }        

        private void initGrPd()
        {
            grfPd = new C1FlexGrid();
            grfPd.Dock = DockStyle.Fill;
            TextBox txt = new TextBox();

            gbPd.Controls.Add(grfPd);

            grfPd.Rows.Count = 1;
            grfPd.Cols.Count = 5;
            grfPd.Cols[colPdItmNameT].Width = 200;
            grfPd.Cols[colPdPayamt].Width = 100;

            grfPd.ShowCursor = true;
            grfPd.Cols[colPdId].Caption = "เลขที่จ่ายเงิน";
            grfPd.Cols[colPdItmNameT].Caption = "รายการ";
            grfPd.Cols[colPdPayamt].Caption = "จำนวนเงิน";

            grfPd.AfterRowColChange += GrfPd_AfterRowColChange;
            grfPd.CellChecked += GrfPd_CellChecked;

            grfPd.Cols[colPdId].Visible = false;
        }
        
        private void setGrfPd(String stfId)
        {
            grfPd.Clear();
            grfPd.Rows.Count = 1;
            grfPd.Cols.Count = 5;
            DataTable dt = new DataTable();
            dt = xC.xtDB.expnpdDB.selectByStfIdEccDocNo(stfId);

            CellStyle cs = grfEcc.Styles.Add("bool");
            cs.DataType = typeof(bool);
            //cs.ImageAlign = ImageAlignEnum.LeftCenter;
            cs.TextAlign = TextAlignEnum.LeftCenter;
            grfPd.Cols[colPdChk].Style = cs;
            grfPd.Cols[colPdChk].Width = 20;
            grfPd.Cols[colPdItmNameT].Width = 200;
            grfPd.Cols[colPdPayamt].Width = 100;
            //grfPd.Cols[colPdChk].ImageAndText = "aaaa";

            grfPd.ShowCursor = true;
            grfPd.Cols[colPdId].Caption = "เลขที่จ่ายเงิน";
            grfPd.Cols[colPdItmNameT].Caption = "รายการ";
            grfPd.Cols[colPdPayamt].Caption = "จำนวนเงิน";

            Color color = ColorTranslator.FromHtml(xC.iniC.grfRowColor);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Row row = grfPd.Rows.Add();
                row[0] = i + 1;
                if (i % 2 == 0)
                    grfPd.Rows[i + 1].StyleNew.BackColor = color;
                row[colPdId] = dt.Rows[i][xC.xtDB.expnpdDB.expnP.expenses_pay_detail_id].ToString();
                row[colPdItmNameT] = dt.Rows[i][xC.xtDB.expnpdDB.expnP.item_name_t].ToString();
                row[colPdPayamt] = dt.Rows[i][xC.xtDB.expnpdDB.expnP.pay_amount].ToString();
            }
            //grfPd.Cols[colPdId].Visible = false;
        }
        private void initGrfEcc()
        {
            grfEcc = new C1FlexGrid();
            grfEcc.Dock = DockStyle.Fill;
            TextBox txt = new TextBox();
            CheckBox chk = new CheckBox();

            gbEcc.Controls.Add(grfEcc);

            grfEcc.Rows.Count = 1;
            grfEcc.Cols.Count = 11;

            grfEcc.Cols[colEccChk].Editor = chk;

            grfEcc.Cols[colEccDoc].Width = 80;
            grfEcc.Cols[colItmNameT].Width = 200;
            grfEcc.Cols[colEccAmt].Width = 80;
            grfEcc.Cols[colReceiptNo].Width = 80;
            grfEcc.Cols[colReceiptDate].Width = 100;
            grfEcc.Cols[colJobCode].Width = 80;
            //grfEcc.Cols[colId].Width = 80;

            grfEcc.ShowCursor = true;
            grfEcc.Cols[colEccDoc].Caption = "เลขที่เอกสาร";
            grfEcc.Cols[colItmNameT].Caption = "รายการ";
            grfEcc.Cols[colEccAmt].Caption = "ยอดเงิน";
            grfEcc.Cols[colReceiptNo].Caption = "เลขที่ใบเสร็จ";
            grfEcc.Cols[colReceiptDate].Caption = "วันที่ในใบเวร็จ";
            grfEcc.Cols[colJobCode].Caption = "job no";
            grfEcc.Cols[colEccPdId].Caption = "เลขที่จ่ายเงิน";

            grfEcc.AfterRowColChange += GrfEcc_AfterRowColChange;
            grfEcc.CellChecked += GrfEcc_CellChecked;

            grfEcc.Cols[colEccId].Visible = false;

            ContextMenu menuGrfEcc = new ContextMenu();
            menuGrfEcc.MenuItems.Add("&แก้ไข ยกเลิก", new EventHandler(ContextMenu_GrfEcc_edit));
            grfEcc.ContextMenu = menuGrfEcc;
        }
        private void ContextMenu_GrfEcc_edit(object sender, System.EventArgs e)
        {
            if (grfEcc[grfEcc.Row, colEccId] == null) return;
            if (grfEcc.Row < 0) return;
            String eccid = "", flag="";
            eccid = grfEcc[grfEcc.Row, colEccId].ToString();
            flag = grfEcc[grfEcc.Row, colflag].ToString();
            if (eccid.Equals("")) return;

            
            if (flag.Equals("ecc"))
            {
                //int row = 0;
                //row = grfEcc != null ? grfEcc.Rows.Count : 0;
                FrmExpenseClearCash frm = new FrmExpenseClearCash(xC, eccid, "", "", "", "");
                frm.WindowState = FormWindowState.Normal;
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog(this);
            }
            else if (flag.Equals("erf"))
            {
                FrmExpenseClearCashRefund frm = new FrmExpenseClearCashRefund(xC, cboStaff.SelectedItem != null ? ((ComboBoxItem)(cboStaff.SelectedItem)).Value : "", eccid);
                frm.WindowState = FormWindowState.Normal;
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog(this);
            }
            else if (flag.Equals("dd"))
            {
                xC.userIderc = cboStaff.SelectedItem != null ? ((ComboBoxItem)(cboStaff.SelectedItem)).Value : "";
                FrmExpenseDraw frm = new FrmExpenseDraw(xC, eccid, FrmExpenseDraw.flagForm2.Cash, FrmExpenseDraw.flagAction.autoappv);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.WindowState = FormWindowState.Normal;
                frm.ShowDialog(this);
            }
            setGrfEcc(cboStaff.SelectedItem != null ? ((ComboBoxItem)(cboStaff.SelectedItem)).Value : "");
        }
        private void setGrfEcc(String stfId)
        {
            grfEcc.Clear();
            grfEcc.Rows.Count = 1;
            grfEcc.Cols.Count = 11;
            DataTable dt = new DataTable();
            dt = xC.xtDB.eccDB.selectByStfIdStatusAppv(stfId, chkAppvWait.Checked ? objdb.ExpensesClearCashDB.StatusAppv.sendtoAppv : objdb.ExpensesClearCashDB.StatusAppv.All);
            DataTable dtErf = new DataTable();
            dtErf = xC.xtDB.erfDB.selectByEccStfid("",stfId);
            DataTable dtD = new DataTable();
            dtD = xC.xtDB.expnddDB.selectStatusErcByStfId(stfId);

            CellStyle cs = grfEcc.Styles.Add("bool");
            //cs = grfEcc.Styles.Add("bool");
            cs.DataType = typeof(bool);
            cs.ImageAlign = ImageAlignEnum.LeftCenter;

            grfEcc.Cols[colEccChk].Style = cs;
            grfEcc.Cols[colEccChk].Width = 20;
            grfEcc.Cols[colEccDoc].Width = 80;
            grfEcc.Cols[colItmNameT].Width = 200;
            grfEcc.Cols[colEccAmt].Width = 80;
            grfEcc.Cols[colReceiptNo].Width = 80;
            grfEcc.Cols[colReceiptDate].Width = 100;
            grfEcc.Cols[colJobCode].Width = 80;

            grfEcc.ShowCursor = true;
            grfEcc.Cols[colEccDoc].Caption = "เลขที่เอกสาร";
            grfEcc.Cols[colItmNameT].Caption = "รายการ";
            grfEcc.Cols[colEccAmt].Caption = "ยอดเงิน";
            grfEcc.Cols[colReceiptNo].Caption = "เลขที่ใบเสร็จ";
            grfEcc.Cols[colReceiptDate].Caption = "วันที่ในใบเวร็จ";
            grfEcc.Cols[colJobCode].Caption = "job no";
            grfEcc.Cols[colEccPdId].Caption = "เลขที่จ่ายเงิน";

            Color color = ColorTranslator.FromHtml(xC.iniC.grfRowColor);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Row row = grfEcc.Rows.Add();
                row[0] = i + 1;
                if (i % 2 == 0)
                    grfEcc.Rows[i + 1].StyleNew.BackColor = color;
                row[colEccChk] = "เลือก";
                row[colEccId] = dt.Rows[i][xC.xtDB.eccDB.ecc.expense_clear_cash_id].ToString();
                row[colEccDoc] = xC.FixEccCode + dt.Rows[i][xC.xtDB.eccDB.ecc.ecc_doc].ToString();
                row[colItmNameT] = dt.Rows[i][xC.xtDB.eccDB.ecc.item_name_t].ToString();
                row[colEccAmt] = dt.Rows[i][xC.xtDB.eccDB.ecc.pay_amount].ToString();
                row[colReceiptNo] = dt.Rows[i][xC.xtDB.eccDB.ecc.receipt_no].ToString();
                row[colReceiptDate] = dt.Rows[i][xC.xtDB.eccDB.ecc.receipt_date].ToString();
                row[colJobCode] = dt.Rows[i][xC.xtDB.eccDB.ecc.job_code].ToString();
                row[colEccPdId] = dt.Rows[i][xC.xtDB.eccDB.ecc.expenses_pay_detail_id] != null ? dt.Rows[i][xC.xtDB.eccDB.ecc.expenses_pay_detail_id].ToString() : "";
                row[colflag] = "ecc";
                //if (dt.Rows[i][xC.xtDB.eccDB.ecc.status_appv].ToString().Equals("0"))
                //{
                //    row.StyleNew.BackColor = Color.Gray;
                //}
            }
            for(int i = 0; i < dtErf.Rows.Count; i++)
            {
                Row row = grfEcc.Rows.Add();
                row[0] = i + 1;
                row.StyleNew.BackColor = Color.Gold;
                row[colEccId] = dtErf.Rows[i][xC.xtDB.erfDB.erf.expenses_refund_id].ToString();
                row[colEccDoc] = xC.FixEccCode + dtErf.Rows[i][xC.xtDB.erfDB.erf.ecc_doc].ToString();
                row[colItmNameT] = dtErf.Rows[i][xC.xtDB.erfDB.erf.desc1].ToString();
                row[colEccAmt] = dtErf.Rows[i][xC.xtDB.erfDB.erf.amount].ToString();
                row[colEccPdId] = "";
                row[colflag] = "erf";
            }
            for (int i = 0; i < dtD.Rows.Count; i++)
            {
                Row row = grfEcc.Rows.Add();
                row[0] = i + 1;
                row.StyleNew.BackColor = Color.Olive;
                row[colEccId] = dtD.Rows[i][xC.xtDB.expnddDB.expnC.expenses_draw_detail_id].ToString();
                //row[colEccDoc] = xC.FixEccCode + dtD.Rows[i][xC.xtDB.erfDB.erf.ecc_doc].ToString();
                row[colItmNameT] = dtD.Rows[i][xC.xtDB.expnddDB.expnC.item_name_t].ToString();
                row[colEccAmt] = dtD.Rows[i][xC.xtDB.expnddDB.expnC.pay_amount].ToString();
                row[colEccPdId] = "";
                row[colflag] = "dd";
            }
            //CellRange rg = grfEcc.GetCellRange(1, 1);
            grfEcc.Cols[colEccId].Visible = false;
            //grfEcc.Cols[colexpnDdId].Visible = false;
        }
        private void GrfPd_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            if (grfPd == null) return;
            if (grfPd.Row < 0) return;
            if (grfPd[grfPd.Row, colPdId] == null) return;

        }
        private void GrfEcc_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            if (grfEcc == null) return;
            if (grfEcc.Row < 0) return;
            if (grfEcc[grfEcc.Row, colEccId] == null) return;
            
        }
        private void GrfEcc_CellChecked(object sender, RowColEventArgs e)
        {
            //throw new NotImplementedException();
            if (grfEcc == null) return;
            if (grfEcc.Row < 0) return;
            if (grfEcc[grfEcc.Row, colEccId] == null) return;
            calAmtEcc();
            //MessageBox.Show("aa " + grfEcc[grfEcc.Row, colEccId].ToString(), ""+ grfEcc[grfEcc.Row, colEccChk].ToString());
        }
        private void GrfPd_CellChecked(object sender, RowColEventArgs e)
        {
            //throw new NotImplementedException();
            if (grfPd == null) return;
            if (grfPd.Row < 0) return;
            if (grfPd[grfPd.Row, colPdId] == null) return;
            calAmtPd();
        }
        private void calAmtEcc()
        {
            Decimal amt = 0;
            foreach (Row row in grfEcc.Rows)
            {
                Decimal chk = 0;
                if (row[colEccAmt] == null) continue;
                if (row[colEccChk] == null) continue;
                if ((bool)row[colEccChk]==true)
                {
                    Decimal.TryParse(row[colEccAmt].ToString(), out chk);
                    amt += chk;
                }
            }
            txtEccAmt.Value = amt;
        }
        private void calAmtPd()
        {
            Decimal amt = 0;
            foreach (Row row in grfPd.Rows)
            {
                Decimal chk = 0;
                if (row[colPdPayamt] == null) continue;
                if (row[colPdChk] == null) continue;
                if ((bool)row[colPdChk] == true)
                {
                    Decimal.TryParse(row[colPdPayamt].ToString(), out chk);
                    amt += chk;
                }

            }
            txtPdAmt.Value = amt;
        }
        private void calSave()
        {
            calAmtEcc();
            calAmtPd();
            Boolean chk = false;
            Decimal pd = 0, ecc = 0;
            Decimal.TryParse(txtEccAmt.Text.Replace("$", "").Replace(",", ""), out ecc);
            Decimal.TryParse(txtPdAmt.Text.Replace("$", "").Replace(",", ""), out pd);
            if (ecc != pd)
            {
                MessageBox.Show("ยอดเงินที่จ่าย กับเคลีย์เงิน ไม่เท่ากัน", "");
                return;
            }
            foreach(Row rowPd in grfPd.Rows)
            {
                String amt = "";
                Decimal amtPd = 0;
                if(Decimal.TryParse(rowPd[colPdPayamt].ToString(), out amtPd))
                {
                    foreach (Row rowEcc in grfEcc.Rows)
                    {
                        Decimal amtEcc = 0;
                        if (rowEcc[colEccPdId].ToString().Equals(""))
                        {
                            Decimal.TryParse(rowEcc[colEccAmt].ToString(), out amtEcc);
                            if (amtEcc <= amtPd)
                            {
                                rowEcc[colEccPdId] = rowPd[colPdId];
                                amtPd -= amtEcc;
                            }
                        }
                    }
                }
                
            }
        }
        private void CboStaff_SelectedItemChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            setGrfEcc(cboStaff.SelectedItem != null ? ((ComboBoxItem)(cboStaff.SelectedItem)).Value : "");
            setGrfPd(cboStaff.SelectedItem != null ? ((ComboBoxItem)(cboStaff.SelectedItem)).Value : "");
        }
        private void BtnRefund_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmExpenseClearCashRefund frm = new FrmExpenseClearCashRefund(xC, cboStaff.SelectedItem != null ? ((ComboBoxItem)(cboStaff.SelectedItem)).Value : "", "");
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog(this);
            setGrfEcc(cboStaff.SelectedItem != null ? ((ComboBoxItem)(cboStaff.SelectedItem)).Value : "");
        }
        private void BtnDNew_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            xC.userIderc = cboStaff.SelectedItem != null ? ((ComboBoxItem)(cboStaff.SelectedItem)).Value : "";
            FrmExpenseDraw frm = new FrmExpenseDraw(xC, "", FrmExpenseDraw.flagForm2.Cash, FrmExpenseDraw.flagAction.autoappv);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.WindowState = FormWindowState.Normal;
            frm.ShowDialog(this);
            setGrfEcc(cboStaff.SelectedItem != null ? ((ComboBoxItem)(cboStaff.SelectedItem)).Value : "");
        }
        private void BtnCal_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            calSave();
        }
        private void FrmExpenseReceiptCashAppv_Load(object sender, EventArgs e)
        {

        }
    }
}
