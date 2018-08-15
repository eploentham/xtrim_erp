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
using Xtrim_ERP.Properties;

namespace Xtrim_ERP.gui
{
    public partial class FrmExpenseReceiptCash1 : Form
    {
        XtrimControl xC;
        JobImport jim;
        ExpensesPayDetail expnpd;
        C1FlexGrid grfPd, grfEcc, grfRefund;

        int colId = 1, colItemNameT = 2, colPayAmt = 3, colExpnDdesc1 = 4, colExpnDDdesc1 = 5;
        int coleccId = 1, coleccItemet = 2, colerrprice = 3, coleccqty = 4, coleccamt = 5, coleccreceiptno = 6, coleccreceiptdate = 7, colecccusnamet = 8, coleccremark = 9;
        int colRefundId = 1, colRefundDesc = 2, colRefundAmt = 3, colRefundRemark=4;

        public FrmExpenseReceiptCash1(XtrimControl x)
        {
            InitializeComponent();
            xC = x;
            initConfig();
        }
        private void initConfig()
        {
            jim = new JobImport();
            expnpd = new ExpensesPayDetail();
            xC.xtDB.stfDB.setCboStaff(cboStaff, xC.userId);

            initGrfExpnPd();
            initGrfEcc();
            initGrfRefund();

            txtUserAmt.Value = xC.accDB.expnpdDB.selectSumPayAmtByJobIdStfIdNoClear("", xC.userId);

            btnDNew.Click += BtnDNew_Click;
            btnDoc.Click += BtnDoc_Click;
            btnSave.Click += BtnSave_Click;
            btnRefund.Click += BtnRefund_Click;
            cboStaff.SelectedItemChanged += CboStaff_SelectedItemChanged;
            //txtJobCode.KeyUp += TxtJobCode_KeyUp;

            setGrfExpnPd(cboStaff.SelectedItem != null ? ((ComboBoxItem)(cboStaff.SelectedItem)).Value : "");
            setGrfEcc(cboStaff.SelectedItem != null ? ((ComboBoxItem)(cboStaff.SelectedItem)).Value : "");
            setGrfRefund(cboStaff.SelectedItem != null ? ((ComboBoxItem)(cboStaff.SelectedItem)).Value : "");
        }
        private void initGrfExpnPd()
        {
            grfPd = new C1FlexGrid();
            grfPd.Dock = DockStyle.Fill;
            TextBox txt = new TextBox();

            gbPd.Controls.Add(grfPd);

            grfPd.Rows.Count = 1;
            grfPd.Cols.Count = 6;

            grfPd.Cols[colItemNameT].Width = 200;
            grfPd.Cols[colPayAmt].Width = 100;
            grfPd.Cols[colExpnDdesc1].Width = 200;
            grfPd.Cols[colExpnDDdesc1].Width = 200;
            //grfExpnD.Cols[colDItemNamet].Width = 220;

            grfPd.ShowCursor = true;
            grfPd.Cols[colItemNameT].Caption = "รายการ";
            grfPd.Cols[colPayAmt].Caption = "จำนวนเงิน";
            grfPd.Cols[colExpnDdesc1].Caption = "รายละเอียด";
            grfPd.Cols[colExpnDDdesc1].Caption = "รายละเอียด";

            //grfExpnD.AfterRowColChange += GrfExpnD_AfterRowColChange;
            grfPd.Cols[colId].Visible = false;
        }

        private void setGrfExpnPd(String stfid)
        {
            grfPd.Clear();
            grfPd.Rows.Count = 1;
            DataTable dt = new DataTable();
            dt = xC.accDB.expnpdDB.selectByJobIdStfId("", stfid);

            grfPd.Cols[colItemNameT].Width = 200;
            grfPd.Cols[colPayAmt].Width = 100;
            grfPd.Cols[colExpnDdesc1].Width = 200;
            grfPd.Cols[colExpnDDdesc1].Width = 200;

            grfPd.ShowCursor = true;
            grfPd.Cols[colItemNameT].Caption = "รายการ";
            grfPd.Cols[colPayAmt].Caption = "จำนวนเงิน";
            grfPd.Cols[colExpnDdesc1].Caption = "รายละเอียดH";
            grfPd.Cols[colExpnDDdesc1].Caption = "รายละเอียดD";

            Color color = ColorTranslator.FromHtml(xC.iniC.grfRowColor);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int chk = 0;
                Row row = grfPd.Rows.Add();
                row[0] = i + 1;
                if (i % 2 == 0)
                    row.StyleNew.BackColor = color;
                row[colId] = dt.Rows[i][xC.accDB.expnpdDB.expnP.expenses_pay_detail_id].ToString();
                row[colItemNameT] = dt.Rows[i][xC.accDB.expnpdDB.expnP.item_name_t].ToString();
                row[colPayAmt] = dt.Rows[i][xC.accDB.expnpdDB.expnP.pay_amount].ToString();
                row[colExpnDdesc1] = dt.Rows[i][xC.accDB.expnpdDB.expnP.desc_d].ToString();
                row[colExpnDDdesc1] = dt.Rows[i][xC.accDB.expnpdDB.expnP.desc_dd].ToString();
                if (int.TryParse(dt.Rows[i][xC.accDB.expnpdDB.expnP.expense_clear_cash_id].ToString(), out chk))
                {
                    if (chk > 0)
                    {
                        row.StyleNew.BackColor = Color.PeachPuff;
                    }
                }
            }
            grfPd.Cols[colId].Visible = false;
        }
        private void initGrfEcc()
        {
            grfEcc = new C1FlexGrid();
            grfEcc.Dock = DockStyle.Fill;
            TextBox txt = new TextBox();

            gbEcc.Controls.Add(grfEcc);

            grfEcc.Rows.Count = 1;
            grfEcc.Cols.Count = 10;

            grfEcc.Cols[coleccItemet].Width = 200;
            grfEcc.Cols[colerrprice].Width = 100;
            grfEcc.Cols[coleccqty].Width = 200;
            grfEcc.Cols[coleccamt].Width = 200;
            grfEcc.Cols[coleccreceiptno].Width = 220;
            grfEcc.Cols[coleccreceiptdate].Width = 220;
            grfEcc.Cols[colecccusnamet].Width = 220;
            grfEcc.Cols[coleccremark].Width = 220;

            grfEcc.ShowCursor = true;
            grfEcc.Cols[coleccItemet].Caption = "รายการ";
            grfEcc.Cols[colerrprice].Caption = "ราคา";
            grfEcc.Cols[coleccqty].Caption = "qty";
            grfEcc.Cols[coleccamt].Caption = "จำนวนเงิน";
            grfEcc.Cols[coleccreceiptno].Caption = "เลขที่ใบเสร็จ";
            grfEcc.Cols[coleccreceiptdate].Caption = "วันที่ในใบเสร็จ";
            grfEcc.Cols[colecccusnamet].Caption = "ลูกค้า";
            grfEcc.Cols[coleccremark].Caption = "มหายเหตุ";

            grfEcc.AfterRowColChange += GrfEcc_AfterRowColChange;
            grfEcc.Cols[coleccId].Visible = false;

            ContextMenu menuGrfEcc = new ContextMenu();
            menuGrfEcc.MenuItems.Add("&แก้ไข ยกเลิก", new EventHandler(ContextMenu_GrfEcc_edit));
            grfEcc.ContextMenu = menuGrfEcc;
        }
        private void setGrfEcc(String stfid)
        {
            Decimal eccamt = 0, chk = 0, refund = 0, paymat = 0;
            grfEcc.Clear();
            grfEcc.Rows.Count = 1;
            DataTable dt = new DataTable();
            dt = xC.accDB.eccDB.selectByStfIdClearCash(stfid);

            grfEcc.Cols[coleccItemet].Width = 200;
            grfEcc.Cols[colerrprice].Width = 100;
            grfEcc.Cols[coleccqty].Width = 60;
            grfEcc.Cols[coleccamt].Width = 100;
            grfEcc.Cols[coleccreceiptno].Width = 100;
            grfEcc.Cols[coleccreceiptdate].Width = 100;
            grfEcc.Cols[colecccusnamet].Width = 200;
            grfEcc.Cols[coleccremark].Width = 200;

            grfEcc.ShowCursor = true;
            grfEcc.Cols[coleccItemet].Caption = "รายการ";
            grfEcc.Cols[colerrprice].Caption = "ราคา";
            grfEcc.Cols[coleccqty].Caption = "qty";
            grfEcc.Cols[coleccamt].Caption = "ยอดเงิน";
            grfEcc.Cols[coleccreceiptno].Caption = "เลขที่ใบเสร็จ";
            grfEcc.Cols[coleccreceiptdate].Caption = "วันที่ในใบเสร็จ";
            grfEcc.Cols[colecccusnamet].Caption = "ลูกค้า";
            grfEcc.Cols[coleccremark].Caption = "หมายเหตุ";

            Color color = ColorTranslator.FromHtml(xC.iniC.grfRowColor);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Row row = grfEcc.Rows.Add();
                row[0] = i + 1;
                if (i % 2 == 0)
                    row.StyleNew.BackColor = color;
                row[coleccId] = dt.Rows[i][xC.accDB.eccDB.ecc.expense_clear_cash_id].ToString();
                row[coleccItemet] = dt.Rows[i][xC.accDB.eccDB.ecc.item_name_t].ToString();
                row[colerrprice] = dt.Rows[i][xC.accDB.eccDB.ecc.price].ToString();
                row[coleccqty] = dt.Rows[i][xC.accDB.eccDB.ecc.qty].ToString();
                row[coleccamt] = dt.Rows[i][xC.accDB.eccDB.ecc.pay_amount].ToString();
                row[coleccreceiptno] = dt.Rows[i][xC.accDB.eccDB.ecc.receipt_no].ToString();
                row[coleccreceiptdate] = dt.Rows[i][xC.accDB.eccDB.ecc.receipt_date].ToString();
                row[colecccusnamet] = dt.Rows[i][xC.accDB.eccDB.ecc.pay_to_cus_name_t].ToString();
                row[coleccremark] = dt.Rows[i][xC.accDB.eccDB.ecc.remark].ToString();
                if (Decimal.TryParse(dt.Rows[i][xC.accDB.eccDB.ecc.pay_amount].ToString(), out chk))
                {
                    eccamt += chk;
                }
                if (dt.Rows[i][xC.accDB.eccDB.ecc.active].ToString().Equals("0"))
                {
                    row.StyleNew.BackColor = Color.Gray;
                }
                else
                {
                    if (dt.Rows[i][xC.accDB.eccDB.ecc.status_doc].ToString().Equals("1"))
                    {
                        row.StyleNew.BackColor = Color.PeachPuff;
                    }
                }

            }
            txtEccAmt.Value = eccamt;
            //Decimal.TryParse(txtPayAmt.Text.Replace("$", "").Replace(",", ""), out paymat);
            txtRefundPay.Value = paymat - eccamt;
            grfEcc.Cols[coleccId].Visible = false;
        }
        private void ContextMenu_GrfEcc_edit(object sender, System.EventArgs e)
        {
            if (grfEcc[grfEcc.Row, coleccId] == null) return;
            if (grfEcc.Row < 0) return;
            String eccid = "";
            eccid = grfEcc[grfEcc.Row, coleccId].ToString();
            if (eccid.Equals("")) return;

            int row = 0;
            row = grfEcc != null ? grfEcc.Rows.Count : 0;
            FrmExpenseClearCash frm = new FrmExpenseClearCash(xC, eccid, "", "", "", row.ToString());
            frm.WindowState = FormWindowState.Normal;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog(this);
            setGrfEcc(cboStaff.SelectedItem != null ? ((ComboBoxItem)(cboStaff.SelectedItem)).Value : "");
        }
        private void initGrfRefund()
        {
            grfRefund = new C1FlexGrid();
            grfRefund.Dock = DockStyle.Fill;
            TextBox txt = new TextBox();

            gbRefund.Controls.Add(grfRefund);

            grfRefund.Rows.Count = 1;
            grfRefund.Cols.Count = 5;

            grfRefund.Cols[colRefundDesc].Width = 200;
            grfRefund.Cols[colRefundAmt].Width = 100;
            grfRefund.Cols[colRefundRemark].Width = 200;

            grfRefund.ShowCursor = true;
            grfRefund.Cols[colRefundDesc].Caption = "รายละเอียด";
            grfRefund.Cols[colRefundAmt].Caption = "จำนวนเงิน";
            grfRefund.Cols[colRefundRemark].Caption = "หมายเหตุ";

            //grfRefund.AfterRowColChange += GrfRefund_AfterRowColChange;
            grfRefund.Cols[colRefundId].Visible = false;

            ContextMenu menuGrfRefund = new ContextMenu();
            menuGrfRefund.MenuItems.Add("&แก้ไข ยกเลิก", new EventHandler(ContextMenu_GrfRefund_edit));
            grfRefund.ContextMenu = menuGrfRefund;
        }
        private void ContextMenu_GrfRefund_edit(object sender, System.EventArgs e)
        {
            if (grfRefund[grfRefund.Row, coleccId] == null) return;
            if (grfRefund.Row < 0) return;
            String erfid = "";
            erfid = grfRefund[grfRefund.Row, coleccId].ToString();
            if (erfid.Equals("")) return;

            int row = 0;
            row = grfRefund != null ? grfRefund.Rows.Count : 0;
            FrmExpenseClearCashRefund frm = new FrmExpenseClearCashRefund(xC, cboStaff.SelectedItem != null ? ((ComboBoxItem)(cboStaff.SelectedItem)).Value : "", erfid);
            frm.WindowState = FormWindowState.Normal;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog(this);
            setGrfEcc(cboStaff.SelectedItem != null ? ((ComboBoxItem)(cboStaff.SelectedItem)).Value : "");
        }
        private void setGrfRefund(String stfid)
        {
            grfRefund.Clear();
            grfRefund.Rows.Count = 1;
            grfRefund.Cols.Count = 5;
            DataTable dt = new DataTable();
            dt = xC.accDB.erfDB.selectByStfId(stfid);

            grfRefund.Cols[colRefundDesc].Width = 200;
            grfRefund.Cols[colRefundAmt].Width = 100;
            grfRefund.Cols[colRefundRemark].Width = 200;

            grfRefund.ShowCursor = true;
            grfRefund.Cols[colRefundDesc].Caption = "รายละเอียด";
            grfRefund.Cols[colRefundAmt].Caption = "จำนวนเงิน";
            grfRefund.Cols[colRefundRemark].Caption = "หมายเหตุ";

            Color color = ColorTranslator.FromHtml(xC.iniC.grfRowColor);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int chk = 0;
                Row row = grfRefund.Rows.Add();
                row[0] = i + 1;
                if (i % 2 == 0)
                    row.StyleNew.BackColor = color;
                row[colRefundDesc] = dt.Rows[i][xC.accDB.erfDB.erf.desc1].ToString();
                row[colRefundAmt] = dt.Rows[i][xC.accDB.erfDB.erf.amount].ToString();
                row[colRefundRemark] = dt.Rows[i][xC.accDB.erfDB.erf.remark].ToString();
                row[colRefundId] = dt.Rows[i][xC.accDB.erfDB.erf.expenses_refund_id].ToString();
                if (int.TryParse(dt.Rows[i][xC.accDB.erfDB.erf.expenses_refund_id].ToString(), out chk))
                {
                    if (chk > 0)
                    {
                        row.StyleNew.BackColor = Color.PeachPuff;
                    }
                }
            }
            grfRefund.Cols[colId].Visible = false;
        }
        private void CboStaff_SelectedItemChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            setGrfExpnPd(cboStaff.SelectedItem != null ? ((ComboBoxItem)(cboStaff.SelectedItem)).Value : "");
        }
        private void BtnRefund_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmExpenseClearCashRefund frm = new FrmExpenseClearCashRefund(xC, cboStaff.SelectedItem != null ? ((ComboBoxItem)(cboStaff.SelectedItem)).Value : "",  "");
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog(this);
            setGrfRefund(cboStaff.SelectedItem != null ? ((ComboBoxItem)(cboStaff.SelectedItem)).Value : "");
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                String stfid = "";
                stfid = cboStaff.SelectedItem != null ? ((ComboBoxItem)(cboStaff.SelectedItem)).Value : "";
                if (stfid.Equals(""))
                {
                    MessageBox.Show("ไม่พบ ชื่อผู้ทำเคลีย์เงินสด", "");
                    return;
                }
                String re = xC.accDB.eccDB.updateActive(stfid);
                int chk = 0;
                if (int.TryParse(re, out chk))
                {
                    btnSave.Image = Resources.accept_database24;
                }
                else
                {
                    btnSave.Image = Resources.accept_database24;
                }
                setGrfEcc(cboStaff.SelectedItem != null ? ((ComboBoxItem)(cboStaff.SelectedItem)).Value : "");
            }
        }
        private void BtnDoc_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ ยืนยันช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                String re = xC.updateClearCashComplete(cboStaff.SelectedItem != null ? ((ComboBoxItem)(cboStaff.SelectedItem)).Value : "");
                int chk = 0;
                if (int.TryParse(re.Replace("CC", ""), out chk))
                {
                    txtEccDoc.Value = re;
                    btnSave.Image = Resources.accept_database24;
                }
                else
                {
                    btnSave.Image = Resources.accept_database24;
                }
            }
        }
        private void BtnDNew_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //if (txtPdId.Text.Equals(""))
            //{
            //    //MessageBox.Show("ไม่พบ รายการ เบิกค่าใช้จ่าย เงินสด", "");
            //    //return;
            //}
            int row = 0;
            row = grfEcc != null ? grfEcc.Rows.Count : 0;
            FrmExpenseClearCash frm = new FrmExpenseClearCash(xC, "", "", "", "", row.ToString());
            frm.WindowState = FormWindowState.Normal;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog(this);
            setGrfEcc(cboStaff.SelectedItem != null ? ((ComboBoxItem)(cboStaff.SelectedItem)).Value : "");
        }
        private void GrfEcc_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            if (grfEcc.Row < 0) return;
            if (grfEcc[grfEcc.Row, coleccId] == null) return;


        }
        private void FrmExpenseReceiptCash1_Load(object sender, EventArgs e)
        {

        }
    }
}
