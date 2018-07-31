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

        int colPdId = 1, colPdItmNameT = 2, colPdPayamt = 3;
        int colEccChk=1, colEccId = 2, colEccDoc = 3, colItmNameT = 4, colAmt = 5, colReceiptNo = 6, colReceiptDate = 7, colJobCode = 8, colexpnDdId = 9;

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
            grfPd.Cols.Count = 4;
            grfPd.Cols[colPdItmNameT].Width = 200;
            grfPd.Cols[colPdPayamt].Width = 100;

            grfPd.ShowCursor = true;
            grfPd.Cols[colPdItmNameT].Caption = "รายการ";
            grfPd.Cols[colPdPayamt].Caption = "จำนวนเงิน";

            grfPd.AfterRowColChange += GrfPd_AfterRowColChange;

            grfPd.Cols[colPdId].Visible = false;
        }
        private void setGrfPd(String stfId)
        {
            grfPd.Clear();
            grfPd.Rows.Count = 1;
            grfPd.Cols.Count = 4;
            DataTable dt = new DataTable();
            dt = xC.xtDB.expnpdDB.selectByStfIdEccDocNo(stfId);

            grfPd.Cols[colPdItmNameT].Width = 200;
            grfPd.Cols[colPdPayamt].Width = 100;

            grfPd.ShowCursor = true;
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
            grfPd.Cols[colPdId].Visible = false;
        }
        private void initGrfEcc()
        {
            grfEcc = new C1FlexGrid();
            grfEcc.Dock = DockStyle.Fill;
            TextBox txt = new TextBox();
            CheckBox chk = new CheckBox();

            gbEcc.Controls.Add(grfEcc);

            grfEcc.Rows.Count = 1;
            grfEcc.Cols.Count = 10;

            grfEcc.Cols[colEccChk].Editor = chk;

            grfEcc.Cols[colEccDoc].Width = 80;
            grfEcc.Cols[colItmNameT].Width = 200;
            grfEcc.Cols[colAmt].Width = 80;
            grfEcc.Cols[colReceiptNo].Width = 80;
            grfEcc.Cols[colReceiptDate].Width = 100;
            grfEcc.Cols[colJobCode].Width = 80;
            //grfEcc.Cols[colId].Width = 80;

            grfEcc.ShowCursor = true;
            grfEcc.Cols[colEccDoc].Caption = "เลขที่เอกสาร";
            grfEcc.Cols[colItmNameT].Caption = "รายการ";
            grfEcc.Cols[colAmt].Caption = "ยอดเงิน";
            grfEcc.Cols[colReceiptNo].Caption = "เลขที่ใบเสร็จ";
            grfEcc.Cols[colReceiptDate].Caption = "วันที่ในใบเวร็จ";
            grfEcc.Cols[colJobCode].Caption = "job no";

            grfEcc.AfterRowColChange += GrfEcc_AfterRowColChange;
            grfEcc.CellChecked += GrfEcc_CellChecked;

            grfEcc.Cols[colEccId].Visible = false;
        }
        
        private void setGrfEcc(String stfId)
        {
            grfEcc.Clear();
            grfEcc.Rows.Count = 1;
            grfEcc.Cols.Count = 10;
            DataTable dt = new DataTable();
            dt = xC.xtDB.eccDB.selectByStfIdStatusAppv(stfId, chkAppvWait.Checked ? objdb.ExpensesClearCashDB.StatusAppv.sendtoAppv : objdb.ExpensesClearCashDB.StatusAppv.All);

            CellStyle cs = grfEcc.Styles.Add("emp");
            cs = grfEcc.Styles.Add("bool");
            cs.DataType = typeof(bool);
            cs.ImageAlign = ImageAlignEnum.LeftCenter;

            grfEcc.Cols[colEccChk].Style = cs;

            grfEcc.Cols[colEccDoc].Width = 80;
            grfEcc.Cols[colItmNameT].Width = 200;
            grfEcc.Cols[colAmt].Width = 80;
            grfEcc.Cols[colReceiptNo].Width = 80;
            grfEcc.Cols[colReceiptDate].Width = 100;
            grfEcc.Cols[colJobCode].Width = 80;

            grfEcc.ShowCursor = true;
            grfEcc.Cols[colEccDoc].Caption = "เลขที่เอกสาร";
            grfEcc.Cols[colItmNameT].Caption = "รายการ";
            grfEcc.Cols[colAmt].Caption = "ยอดเงิน";
            grfEcc.Cols[colReceiptNo].Caption = "เลขที่ใบเสร็จ";
            grfEcc.Cols[colReceiptDate].Caption = "วันที่ในใบเวร็จ";
            grfEcc.Cols[colJobCode].Caption = "job no";

            Color color = ColorTranslator.FromHtml(xC.iniC.grfRowColor);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Row row = grfEcc.Rows.Add();
                row[0] = i + 1;
                if (i % 2 == 0)
                    grfEcc.Rows[i + 1].StyleNew.BackColor = color;
                row[colEccId] = dt.Rows[i][xC.xtDB.eccDB.ecc.expense_clear_cash_id].ToString();
                row[colEccDoc] = xC.FixEccCode + dt.Rows[i][xC.xtDB.eccDB.ecc.ecc_doc].ToString();
                row[colItmNameT] = dt.Rows[i][xC.xtDB.eccDB.ecc.item_name_t].ToString();
                row[colAmt] = dt.Rows[i][xC.xtDB.eccDB.ecc.pay_amount].ToString();
                row[colReceiptNo] = dt.Rows[i][xC.xtDB.eccDB.ecc.receipt_no].ToString();
                row[colReceiptDate] = dt.Rows[i][xC.xtDB.eccDB.ecc.receipt_date].ToString();
                row[colJobCode] = dt.Rows[i][xC.xtDB.eccDB.ecc.job_code].ToString();
                //row[colexpnDdId] = dt.Rows[i][xC.xtDB.eccDB.ecc.expenses_draw_detail_id].ToString();
                //if (dt.Rows[i][xC.xtDB.eccDB.ecc.status_appv].ToString().Equals("0"))
                //{
                //    row.StyleNew.BackColor = Color.Gray;
                //}
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
            if (grfPd[grfEcc.Row, colPdId] == null) return;

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

            //MessageBox.Show("aa " + grfEcc[grfEcc.Row, colEccId].ToString(), ""+ grfEcc[grfEcc.Row, colEccChk].ToString());
        }
        private void CboStaff_SelectedItemChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            setGrfEcc(cboStaff.SelectedItem != null ? ((ComboBoxItem)(cboStaff.SelectedItem)).Value : "");
            setGrfPd(cboStaff.SelectedItem != null ? ((ComboBoxItem)(cboStaff.SelectedItem)).Value : "");
        }
        private void FrmExpenseReceiptCashAppv_Load(object sender, EventArgs e)
        {

        }
    }
}
