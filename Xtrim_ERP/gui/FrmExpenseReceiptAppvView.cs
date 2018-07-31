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
    public partial class FrmExpenseReceiptAppvView : Form
    {
        XtrimControl xC;
        JobImport jim;
        ExpensesClearCash ecc;

        C1FlexGrid grfEcc, grfPd, grfDd, grfEccD, grfErf;
        int colId = 1, colEccDoc = 2, colItmNameT = 3, colAmt = 4, colReceiptNo = 5, colReceiptDate = 6, colJobCode = 7, colexpnDdId=8;
        int colPdId = 1, colPdItmNameT = 2, colPdPayamt = 3;
        int colDdId = 1, colDdItmNameT = 2, colDdPayamt = 3;
        int colEccDeccdoc = 1, colEccDpayamt = 2, colEccRefund=3;
        int colErfId = 1, colErfDesc = 2, colErfAmt = 3, colErfJobCode = 4, colErfRemark = 5;

        public FrmExpenseReceiptAppvView(XtrimControl x)
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
            chkAppvWait.Checked = true;

            initGrfEcc();
            initGrfEccD();
            initGrPd();
            initGrDd();
            initGrfRefund();
            setGrfEcc();
        }
        private void initGrfEcc()
        {
            grfEcc = new C1FlexGrid();
            grfEcc.Dock = DockStyle.Fill;
            TextBox txt = new TextBox();

            gbEccH.Controls.Add(grfEcc);

            grfEcc.Rows.Count = 1;
            grfEcc.Cols.Count = 4;
            grfEcc.Cols[colEccDeccdoc].Width = 100;
            grfEcc.Cols[colEccDpayamt].Width = 200;
            grfEcc.Cols[colEccRefund].Width = 200;

            grfEcc.ShowCursor = true;
            grfEcc.Cols[colEccDeccdoc].Caption = "เลขที่เอกสาร";
            grfEcc.Cols[colEccDpayamt].Caption = "จำนวนเงิน มีใบเสร็จ";
            grfEcc.Cols[colEccRefund].Caption = "จำนวนเงิน คืนเงินสด";

            grfEcc.AfterRowColChange += GrfEcc_AfterRowColChange;

            //grfEcc.Cols[colId].Visible = false;
        }
        
        private void setGrfEcc()
        {
            grfEcc.Clear();
            grfEcc.Rows.Count = 1;
            DataTable dt = new DataTable();
            dt = xC.xtDB.eccDB.selectSumEccDocByStatusAppv(chkAppvWait.Checked ? objdb.ExpensesClearCashDB.StatusAppv.sendtoAppv : chkAppvOk.Checked ? objdb.ExpensesClearCashDB.StatusAppv.Appv : objdb.ExpensesClearCashDB.StatusAppv.All);

            grfEcc.Cols[colEccDeccdoc].Width = 100;
            grfEcc.Cols[colEccDpayamt].Width = 200;
            grfEcc.Cols[colEccRefund].Width = 200;

            grfEcc.ShowCursor = true;
            grfEcc.Cols[colEccDeccdoc].Caption = "เลขที่เอกสาร";
            grfEcc.Cols[colEccDpayamt].Caption = "จำนวนเงิน";
            grfEcc.Cols[colEccRefund].Caption = "จำนวนเงิน คืนเงินสด";

            Color color = ColorTranslator.FromHtml(xC.iniC.grfRowColor);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                String eccDoc = "", amt="";
                Row row = grfEcc.Rows.Add();
                row[0] = i + 1;
                if (i % 2 == 0)
                    grfEcc.Rows[i+1].StyleNew.BackColor = color;
                eccDoc = xC.FixEccCode + dt.Rows[i][xC.xtDB.eccDB.ecc.ecc_doc].ToString();
                row[colEccDeccdoc] = eccDoc;
                row[colEccDpayamt] = dt.Rows[i][xC.xtDB.eccDB.ecc.pay_amount].ToString();
                amt = xC.xtDB.erfDB.selectSumByEccDoc(eccDoc.Replace(xC.FixEccCode,""));
                row[colEccRefund] = amt;

                //if (dt.Rows[i][xC.xtDB.eccDB.ecc.status_appv].ToString().Equals("0"))
                //{
                //    row.StyleNew.BackColor = Color.Gray;
                //}
            }
            //grfEcc.Cols[colId].Visible = false;
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
        
        private void setGrfPd(String eccid)
        {
            grfPd.Clear();
            grfPd.Rows.Count = 1;
            grfPd.Cols.Count = 4;
            DataTable dt = new DataTable();
            dt = xC.xtDB.expnpdDB.selectByEccDoc(eccid.Replace(xC.FixEccCode,""));

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
        private void initGrfEccD()
        {
            grfEccD = new C1FlexGrid();
            grfEccD.Dock = DockStyle.Fill;
            TextBox txt = new TextBox();

            gbEccD.Controls.Add(grfEccD);

            grfEccD.Rows.Count = 1;
            grfEccD.Cols.Count = 9;
            grfEccD.Cols[colEccDoc].Width = 80;
            grfEccD.Cols[colItmNameT].Width = 200;
            grfEccD.Cols[colAmt].Width = 80;
            grfEccD.Cols[colReceiptNo].Width = 80;
            grfEccD.Cols[colReceiptDate].Width = 100;
            grfEccD.Cols[colJobCode].Width = 80;
            //grfEcc.Cols[colId].Width = 80;

            grfEccD.ShowCursor = true;
            grfEccD.Cols[colEccDoc].Caption = "เลขที่เอกสาร";
            grfEccD.Cols[colItmNameT].Caption = "รายการ";
            grfEccD.Cols[colAmt].Caption = "ยอดเงิน";
            grfEccD.Cols[colReceiptNo].Caption = "เลขที่ใบเสร็จ";
            grfEccD.Cols[colReceiptDate].Caption = "วันที่ในใบเวร็จ";
            grfEccD.Cols[colJobCode].Caption = "job no";

            grfEccD.AfterRowColChange += GrfEccD_AfterRowColChange;

            grfEccD.Cols[colId].Visible = false;
        }
        private void setGrfEccD(String eccdoc)
        {
            grfEccD.Clear();
            grfEccD.Rows.Count = 1;
            grfEccD.Cols.Count = 9;
            DataTable dt = new DataTable();
            dt = xC.xtDB.eccDB.selectByStatusAppv(eccdoc.Replace(xC.FixEccCode,""),chkAppvWait.Checked ? objdb.ExpensesClearCashDB.StatusAppv.sendtoAppv : chkAppvOk.Checked ? objdb.ExpensesClearCashDB.StatusAppv.Appv : objdb.ExpensesClearCashDB.StatusAppv.All);

            grfEccD.Cols[colEccDoc].Width = 80;
            grfEccD.Cols[colItmNameT].Width = 200;
            grfEccD.Cols[colAmt].Width = 80;
            grfEccD.Cols[colReceiptNo].Width = 80;
            grfEccD.Cols[colReceiptDate].Width = 100;
            grfEccD.Cols[colJobCode].Width = 80;

            grfEccD.ShowCursor = true;
            grfEccD.Cols[colEccDoc].Caption = "เลขที่เอกสาร";
            grfEccD.Cols[colItmNameT].Caption = "รายการ";
            grfEccD.Cols[colAmt].Caption = "ยอดเงิน";
            grfEccD.Cols[colReceiptNo].Caption = "เลขที่ใบเสร็จ";
            grfEccD.Cols[colReceiptDate].Caption = "วันที่ในใบเวร็จ";
            grfEccD.Cols[colJobCode].Caption = "job no";

            Color color = ColorTranslator.FromHtml(xC.iniC.grfRowColor);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Row row = grfEccD.Rows.Add();
                row[0] = i + 1;
                if (i % 2 == 0)
                    grfEccD.Rows[i + 1].StyleNew.BackColor = color;
                row[colId] = dt.Rows[i][xC.xtDB.eccDB.ecc.expense_clear_cash_id].ToString();
                row[colEccDoc] = xC.FixEccCode + dt.Rows[i][xC.xtDB.eccDB.ecc.ecc_doc].ToString();
                row[colItmNameT] = dt.Rows[i][xC.xtDB.eccDB.ecc.item_name_t].ToString();
                row[colAmt] = dt.Rows[i][xC.xtDB.eccDB.ecc.pay_amount].ToString();
                row[colReceiptNo] = dt.Rows[i][xC.xtDB.eccDB.ecc.receipt_no].ToString();
                row[colReceiptDate] = dt.Rows[i][xC.xtDB.eccDB.ecc.receipt_date].ToString();
                row[colJobCode] = dt.Rows[i][xC.xtDB.eccDB.ecc.job_code].ToString();
                row[colexpnDdId] = dt.Rows[i][xC.xtDB.eccDB.ecc.expenses_draw_detail_id].ToString();
                if (dt.Rows[i][xC.xtDB.eccDB.ecc.status_appv].ToString().Equals("0"))
                {
                    row.StyleNew.BackColor = Color.Gray;
                }
            }
            grfEccD.Cols[colId].Visible = false;
            grfEccD.Cols[colexpnDdId].Visible = false;
        }
        private void initGrDd()
        {
            grfDd = new C1FlexGrid();
            grfDd.Dock = DockStyle.Fill;
            TextBox txt = new TextBox();

            gbDd.Controls.Add(grfDd);

            grfDd.Rows.Count = 1;
            grfDd.Cols.Count = 4;
            grfDd.Cols[colDdItmNameT].Width = 200;
            grfDd.Cols[colDdPayamt].Width = 100;

            grfDd.ShowCursor = true;
            grfDd.Cols[colDdItmNameT].Caption = "รายการ";
            grfDd.Cols[colDdPayamt].Caption = "จำนวนเงิน";

            grfDd.Cols[colDdId].Visible = false;
        }
        private void setGrfDd(String pdid)
        {
            grfDd.Clear();
            grfDd.Rows.Count = 1;
            grfDd.Cols.Count = 4;
            DataTable dt = new DataTable();
            dt = xC.xtDB.expnddDB.selectByPk(pdid);

            grfDd.Cols[colDdItmNameT].Width = 200;
            grfDd.Cols[colDdPayamt].Width = 100;

            grfDd.ShowCursor = true;
            grfDd.Cols[colDdItmNameT].Caption = "รายการ";
            grfDd.Cols[colDdPayamt].Caption = "จำนวนเงิน";

            Color color = ColorTranslator.FromHtml(xC.iniC.grfRowColor);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Row row = grfDd.Rows.Add();
                row[0] = i + 1;
                if (i % 2 == 0)
                    grfDd.Rows[i + 1].StyleNew.BackColor = color;
                row[colDdId] = dt.Rows[i][xC.xtDB.expnddDB.expnC.expenses_draw_detail_id].ToString();
                row[colDdItmNameT] = dt.Rows[i][xC.xtDB.expnddDB.expnC.item_name_t].ToString();
                row[colDdPayamt] = dt.Rows[i][xC.xtDB.expnddDB.expnC.pay_amount].ToString();
            }
            grfDd.Cols[colDdId].Visible = false;
        }
        private void initGrfRefund()
        {
            grfErf = new C1FlexGrid();
            grfErf.Dock = DockStyle.Fill;
            TextBox txt = new TextBox();

            gbRefund.Controls.Add(grfErf);

            grfErf.Rows.Count = 1;
            grfErf.Cols.Count = 6;
            grfErf.Cols[colErfDesc].Width = 200;
            grfErf.Cols[colErfAmt].Width = 80;
            grfErf.Cols[colErfJobCode].Width = 80;
            grfErf.Cols[colErfRemark].Width = 200;

            grfErf.ShowCursor = true;
            grfErf.Cols[colErfDesc].Caption = "รายละเอียด";
            grfErf.Cols[colErfAmt].Caption = "จำนวนเงิน";
            grfErf.Cols[colErfJobCode].Caption = "job no";
            grfErf.Cols[colErfRemark].Caption = "หมายเหตุ";

            grfErf.AfterRowColChange += GrfErf_AfterRowColChange;

            grfErf.Cols[colErfId].Visible = false;
        }
        private void setGrfErf(String eccid)
        {
            grfErf.Clear();
            grfErf.Rows.Count = 1;
            grfErf.Cols.Count = 6;
            DataTable dt = new DataTable();
            //dt = xC.xtDB.erfDB.selectByEccDoc(eccid.Replace(xC.FixEccCode,""));

            grfErf.Cols[colErfDesc].Width = 200;
            grfErf.Cols[colErfAmt].Width = 80;
            grfErf.Cols[colErfJobCode].Width = 80;
            grfErf.Cols[colErfRemark].Width = 200;


            grfErf.ShowCursor = true;
            grfErf.Cols[colErfDesc].Caption = "รายละเอียด";
            grfErf.Cols[colErfAmt].Caption = "จำนวนเงิน";
            grfErf.Cols[colErfJobCode].Caption = "job no";
            grfErf.Cols[colErfRemark].Caption = "หมายเหตุ";

            Color color = ColorTranslator.FromHtml(xC.iniC.grfRowColor);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Row row = grfErf.Rows.Add();
                row[0] = i + 1;
                if (i % 2 == 0)
                    grfErf.Rows[i + 1].StyleNew.BackColor = color;
                row[colErfId] = dt.Rows[i][xC.xtDB.erfDB.erf.expenses_refund_id].ToString();
                row[colErfDesc] = dt.Rows[i][xC.xtDB.erfDB.erf.desc1].ToString();
                row[colErfAmt] = dt.Rows[i][xC.xtDB.erfDB.erf.amount].ToString();
                row[colErfJobCode] = dt.Rows[i][xC.xtDB.erfDB.erf.job_id].ToString();
                row[colErfRemark] = dt.Rows[i][xC.xtDB.erfDB.erf.remark].ToString();
            }
            grfErf.Cols[colDdId].Visible = false;
        }
        private void setControl(String eccId)
        {
            ExpensesClearCash ecc = new ExpensesClearCash();
            ExpensesPayDetail pd = new ExpensesPayDetail();
            ecc = xC.xtDB.eccDB.selectByPk1(eccId);
            pd = xC.xtDB.expnpdDB.selectByPk1(ecc.expenses_pay_detail_id);
            txtID.Value = ecc.expense_clear_cash_id;
            txtEccDoc.Value = ecc.ecc_doc;
            txtItmNameT.Value = ecc.item_name_t;
            txtReceiptNo.Value = ecc.receipt_no;
            txtReceiptDate.Value = ecc.receipt_date;
            txtRow.Value = ecc.row1;
            txtItmNamePd.Value = pd.item_name_t;
        }
        private void GrfEcc_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            if (grfEcc == null) return;
            if (grfEcc.Row<0) return;
            if (grfEcc[grfEcc.Row, colEccDeccdoc] ==null) return;

            setGrfEccD(grfEcc[grfEcc.Row, colEccDeccdoc].ToString());

        }
        private void GrfEccD_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            if (grfEccD == null) return;
            if (grfEccD.Row < 0) return;
            if (grfEccD[grfEccD.Row, colId] == null) return;
            
            setGrfPd(grfEccD[grfEccD.Row, colEccDoc].ToString());
            setGrfDd(grfEccD[grfEcc.Row, colexpnDdId].ToString());
            setGrfErf(grfEccD[grfEccD.Row, colEccDoc].ToString());
            setControl(grfEccD[grfEccD.Row, colId].ToString());
        }
        private void GrfPd_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            if (grfPd == null) return;
            if (grfPd.Row < 0) return;
            if (grfPd[grfEcc.Row, colPdId] == null) return;
            
        }
        private void GrfErf_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();

        }
        private void FrmExpenseReceiptAppvView_Load(object sender, EventArgs e)
        {

        }
    }
}
