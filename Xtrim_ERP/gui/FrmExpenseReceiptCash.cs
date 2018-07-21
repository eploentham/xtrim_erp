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
    public partial class FrmExpenseReceiptCash : Form
    {
        XtrimControl xC;
        JobImport jim;
        ExpensesPayDetail expnpd;
        C1FlexGrid grfExpnD, grfEcc;

        int colId = 1, colItemNameT = 2, colPayAmt = 3, colExpnDdesc1 = 4, colExpnDDdesc1 = 5;
        int coleccId = 1, coleccItemet = 2, colerrprice=3, coleccqty = 4, coleccamt = 5, coleccreceiptno = 6, coleccreceiptdate = 7, colecccusnamet = 8, coleccremark = 9;

        public FrmExpenseReceiptCash(XtrimControl x)
        {
            InitializeComponent();
            xC = x;
            initConfig();
        }
        private void initConfig()
        {
            jim = new JobImport();
            expnpd = new ExpensesPayDetail();
            xC.xtDB.stfDB.setCboStaff(cboStaff, "");

            initGrfExpnD();
            initGrfEcc();

            btnDNew.Click += BtnDNew_Click;
            cboStaff.SelectedItemChanged += CboStaff_SelectedItemChanged;
            txtJobCode.KeyUp += TxtJobCode_KeyUp;

        }
        
        private void initGrfExpnD()
        {
            grfExpnD = new C1FlexGrid();
            grfExpnD.Dock = DockStyle.Fill;
            TextBox txt = new TextBox();

            panel3.Controls.Add(grfExpnD);

            grfExpnD.Rows.Count = 1;
            grfExpnD.Cols.Count = 6;

            grfExpnD.Cols[colItemNameT].Width = 200;
            grfExpnD.Cols[colPayAmt].Width = 100;
            grfExpnD.Cols[colExpnDdesc1].Width = 200;
            grfExpnD.Cols[colExpnDDdesc1].Width = 200;
            //grfExpnD.Cols[colDItemNamet].Width = 220;

            grfExpnD.ShowCursor = true;
            grfExpnD.Cols[colItemNameT].Caption = "รายการ";
            grfExpnD.Cols[colPayAmt].Caption = "จำนวนเงิน";
            grfExpnD.Cols[colExpnDdesc1].Caption = "รายละเอียด";
            grfExpnD.Cols[colExpnDDdesc1].Caption = "รายละเอียด";

            grfExpnD.AfterRowColChange += GrfExpnD_AfterRowColChange;
            grfExpnD.Cols[colId].Visible = false;
        }
        
        private void setGrfExpnD(String jobid, String stfid)
        {
            grfExpnD.Clear();
            grfExpnD.Rows.Count = 1;
            DataTable dt = new DataTable();
            dt = xC.xtDB.expnpdDB.selectByJobIdStfId(jobid, stfid);

            grfExpnD.Cols[colItemNameT].Width = 200;
            grfExpnD.Cols[colPayAmt].Width = 100;
            grfExpnD.Cols[colExpnDdesc1].Width = 200;
            grfExpnD.Cols[colExpnDDdesc1].Width = 200;

            grfExpnD.ShowCursor = true;
            grfExpnD.Cols[colItemNameT].Caption = "รายการ";
            grfExpnD.Cols[colPayAmt].Caption = "จำนวนเงิน";
            grfExpnD.Cols[colExpnDdesc1].Caption = "รายละเอียดH";
            grfExpnD.Cols[colExpnDDdesc1].Caption = "รายละเอียดD";

            Color color = ColorTranslator.FromHtml(xC.iniC.grfRowColor);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Row row = grfExpnD.Rows.Add();
                row[0] = i + 1;
                if (i % 2 == 0)
                    grfExpnD.Rows[i].StyleNew.BackColor = color;
                row[colId] = dt.Rows[i][xC.xtDB.expnpdDB.expnP.expenses_pay_detail_id].ToString();
                row[colItemNameT] = dt.Rows[i][xC.xtDB.expnpdDB.expnP.item_name_t].ToString();
                row[colPayAmt] = dt.Rows[i][xC.xtDB.expnpdDB.expnP.pay_amount].ToString();
                row[colExpnDdesc1] = dt.Rows[i][xC.xtDB.expnpdDB.expnP.desc_d].ToString();
                row[colExpnDDdesc1] = dt.Rows[i][xC.xtDB.expnpdDB.expnP.desc_dd].ToString();
            }
            grfExpnD.Cols[colId].Visible = false;
        }
        private void initGrfEcc()
        {
            grfEcc = new C1FlexGrid();
            grfEcc.Dock = DockStyle.Fill;
            TextBox txt = new TextBox();

            panel4.Controls.Add(grfEcc);

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
        private void setGrfEcc(String pdid)
        {
            grfEcc.Clear();
            grfEcc.Rows.Count = 1;
            DataTable dt = new DataTable();
            dt = xC.xtDB.eccDB.selectToPayDetailId(pdid);

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
                    grfEcc.Rows[i].StyleNew.BackColor = color;
                row[coleccId] = dt.Rows[i][xC.xtDB.eccDB.ecc.expense_clear_cash_id].ToString();
                row[coleccItemet] = dt.Rows[i][xC.xtDB.eccDB.ecc.item_name_t].ToString();
                row[colerrprice] = dt.Rows[i][xC.xtDB.eccDB.ecc.price].ToString();
                row[coleccqty] = dt.Rows[i][xC.xtDB.eccDB.ecc.qty].ToString();
                row[coleccamt] = dt.Rows[i][xC.xtDB.eccDB.ecc.pay_amount].ToString();
                row[coleccreceiptno] = dt.Rows[i][xC.xtDB.eccDB.ecc.receipt_no].ToString();
                row[coleccreceiptdate] = dt.Rows[i][xC.xtDB.eccDB.ecc.receipt_date].ToString();
                row[colecccusnamet] = dt.Rows[i][xC.xtDB.eccDB.ecc.pay_to_cus_name_t].ToString();
                row[coleccremark] = dt.Rows[i][xC.xtDB.eccDB.ecc.remark].ToString();
            }

            
            grfEcc.Cols[coleccId].Visible = false;
        }
        private void ContextMenu_GrfEcc_edit(object sender, System.EventArgs e)
        {
            String expnddid = "";
            if (grfEcc[grfEcc.Row, coleccId] == null) return;
            if (grfEcc.Row < 0) return;

            String eccid = "";
            eccid = grfEcc[grfEcc.Row, coleccId].ToString();
            if (eccid.Equals("")) return;
            txtID.Value = eccid;
            FrmExpenseClearCash frm = new FrmExpenseClearCash(xC, txtID.Text, txtPdId.Text, txtItmNameT.Text, txtJobCode.Text);
            frm.WindowState = FormWindowState.Normal;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog(this);
            setGrfEcc(txtPdId.Text);
        }
        private void CboStaff_SelectedItemChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            setGrfExpnD(txtJobId.Text, cboStaff.SelectedItem != null ? ((ComboBoxItem)(cboStaff.SelectedItem)).Value : "");
        }
        private void TxtJobCode_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.KeyCode == Keys.Enter)
            {
                txtJobCode.Text = txtJobCode.Text.Replace(xC.FixJobCode, "");
                jim = xC.xtDB.jimDB.selectByJobCode(txtJobCode.Text);
                txtJobId.Value = jim.job_import_id;
                setGrfExpnD(txtJobId.Text, cboStaff.SelectedItem != null ? ((ComboBoxItem)(cboStaff.SelectedItem)).Value : "");
            }
        }
        private void BtnDNew_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (txtPdId.Text.Equals(""))
            {
                MessageBox.Show("ไม่พบ รายการ เบิกค่าใช้จ่าย เงินสด", "");
                return;
            }
            FrmExpenseClearCash frm = new FrmExpenseClearCash(xC, "", txtPdId.Text, txtItmNameT.Text, txtJobCode.Text);
            frm.WindowState = FormWindowState.Normal;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog(this);
            setGrfEcc(txtPdId.Text);
        }
        private void GrfExpnD_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            if (grfExpnD[grfExpnD.Row, colId] == null) return;
            String pdid = "";
            pdid = grfExpnD[grfExpnD.Row, colId].ToString();
            expnpd = xC.xtDB.expnpdDB.selectByPk1(pdid);
            txtID.Value = "";
            txtPdId.Value = pdid;
            txtItmNameT.Value = expnpd.item_name_t;
            setGrfEcc(pdid);
        }
        private void GrfEcc_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            if (grfEcc.Row < 0) return;
            if (grfEcc[grfEcc.Row, coleccId] == null) return;
            
            
        }
        private void FrmExpenseReceiptCash_Load(object sender, EventArgs e)
        {

        }
    }
}
