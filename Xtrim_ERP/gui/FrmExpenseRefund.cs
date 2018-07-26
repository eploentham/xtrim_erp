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
    public partial class FrmExpenseRefund : Form
    {
        XtrimControl xC;
        JobImport jim;
        ExpensesPayDetail expnpd;
        ExpensesClearCash ecc;
        ExpensesRefund erf;
        C1FlexGrid grfErf;
        String jobId = "", userId = "", eccDoc="", pdid="";

        int colId = 1, colDesc = 2, colAmt = 3, colDate = 4;

        public FrmExpenseRefund(XtrimControl x, String jobId, String userId, String eccDoc, String pdid)
        {
            InitializeComponent();
            xC = x;
            this.jobId = jobId;
            this.userId = userId;
            this.eccDoc = eccDoc;
            this.pdid = pdid;
            initConfig();
        }
        private void initConfig()
        {
            jim = new JobImport();
            expnpd = new ExpensesPayDetail();
            ecc = new ExpensesClearCash();
            erf = new ExpensesRefund();
            xC.xtDB.stfDB.setCboStaff(cboStaff, userId);
            xC.setCboYear(cboYear);
            jim = xC.xtDB.jimDB.selectByPk1(jobId);
            ecc = xC.xtDB.eccDB.selectByPk1(eccDoc);
            txtJobCode.Value = jim.job_import_code;

            DateTime erfDate = DateTime.Now;
            txtErfDate.Value = erfDate.Year.ToString() + "-" + erfDate.ToString("MM-dd");

            btnSave.Click += BtnSave_Click;

            initGrfErf();
            setGrfErf();
            setControlEcc(eccDoc);
            if (!eccDoc.Equals(""))
            {
                grfErf.Enabled = false;
            }
        }
        
        private void initGrfErf()
        {
            grfErf = new C1FlexGrid();
            grfErf.Dock = DockStyle.Fill;
            TextBox txt = new TextBox();

            panel5.Controls.Add(grfErf);

            grfErf.Rows.Count = 1;
            grfErf.Cols.Count = 6;

            grfErf.Cols[colDesc].Width = 200;
            grfErf.Cols[colAmt].Width = 100;
            grfErf.Cols[colDate].Width = 200;
            //grfErf.Cols[colExpnDDdesc1].Width = 200;
            //grfExpnD.Cols[colDItemNamet].Width = 220;

            grfErf.ShowCursor = true;
            grfErf.Cols[colDesc].Caption = "รายการ";
            grfErf.Cols[colAmt].Caption = "จำนวนเงิน";
            grfErf.Cols[colDate].Caption = "วันที่คืนเงิน";
            //grfErf.Cols[colExpnDDdesc1].Caption = "รายละเอียด";

            grfErf.AfterRowColChange += GrfErf_AfterRowColChange;
            grfErf.Cols[colId].Visible = false;
        }
        private void setGrfErf()
        {
            Decimal eccamt = 0, chk = 0, refund = 0, paymat = 0;
            grfErf.Clear();
            grfErf.Rows.Count = 1;
            DataTable dt = new DataTable();
            dt = xC.xtDB.erfDB.selectAll();

            grfErf.Cols[colDesc].Width = 200;
            grfErf.Cols[colAmt].Width = 100;
            grfErf.Cols[colDate].Width = 200;

            grfErf.ShowCursor = true;
            grfErf.Cols[colDesc].Caption = "รายการ";
            grfErf.Cols[colAmt].Caption = "จำนวนเงิน";
            grfErf.Cols[colDate].Caption = "วันที่คืนเงิน";

            Color color = ColorTranslator.FromHtml(xC.iniC.grfRowColor);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Row row = grfErf.Rows.Add();
                row[0] = i + 1;
                if (i % 2 == 0)
                    row.StyleNew.BackColor = color;
                row[colId] = dt.Rows[i][xC.xtDB.erfDB.erf.expenses_refund_id].ToString();
                row[colDesc] = dt.Rows[i][xC.xtDB.erfDB.erf.desc1].ToString();
                row[colAmt] = dt.Rows[i][xC.xtDB.erfDB.erf.amount].ToString();
                row[colDate] = dt.Rows[i][xC.xtDB.erfDB.erf.expenses_refund_date].ToString();
                
            }
            grfErf.Cols[colId].Visible = false;
        }
        private void setErf()
        {
            jim = xC.xtDB.jimDB.selectByPk1(jobId);
            erf.expenses_refund_id = txtId.Text;
            erf.expense_clear_cash_id = "";
            erf.expenses_pay_detail_id = pdid;
            erf.job_id = jim.job_import_id;
            erf.desc1 = txtDesc.Text;
            erf.amount = txtRefund.Text.Replace("$","").Replace(",","");
            erf.active = "1";
            erf.remark = txtRemark.Text;
            erf.date_create = "";
            erf.date_modi = "";
            erf.date_cancel = "";
            erf.user_create = "";
            erf.user_modi = "";
            erf.user_cancel = "";
            erf.status_page = "1";
            erf.status_appv = "0";
            erf.status_doc = "0";
            erf.ecc_doc = eccDoc;
            erf.job_code = jim.job_import_code;

            erf.expenses_refund_date = xC.datetoDB(txtErfDate.Text);
        }
        private void setControl(String erfId)
        {
            erf = xC.xtDB.erfDB.selectByPk1(erfId);
            txtId.Value = erf.expenses_refund_id;
            jobId = erf.job_id;
            eccDoc = erf.expense_clear_cash_id;
            pdid = erf.expenses_pay_detail_id;
            txtRefund.Value = erf.amount;
            txtErfDate.Value = erf.expenses_refund_date;
            txtDesc.Value = erf.desc1;
            txtRemark.Value = erf.remark;
        }
        private void setControlEcc(String eccDoc)
        {
            ecc = xC.xtDB.eccDB.selectToRefundByEccDoc(eccDoc);
            txtId.Value = "";
            
            jobId = ecc.job_id;
            this.eccDoc = ecc.ecc_doc;
            pdid = ecc.expenses_pay_detail_id;
            txtRefund.Value = ecc.pay_amount;
            DateTime erfDate = DateTime.Now;
            txtErfDate.Value = erfDate.Year.ToString() + "-" + erfDate.ToString("MM-dd");
            txtDesc.Value = "";
            txtRemark.Value = "";
        }
        private void GrfErf_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            if (grfErf.Row < 0) return;
            if (grfErf[grfErf.Row, colId] == null) return;
            String erfid = "";
            erfid = grfErf[grfErf.Row, colId].ToString();
            
            setControl(erfid);
            //txtID.Value = "";
            //txtPdId.Value = pdid;
            //txtItmNameT.Value = expnpd.item_name_t;
            //txtPayAmt.Value = expnpd.pay_amount;
            //setGrfEcc(pdid);
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                setErf();
                String re = xC.xtDB.erfDB.insertExpensesRefund(erf, cboStaff.SelectedItem != null ? ((ComboBoxItem)(cboStaff.SelectedItem)).Value : "");
                int chk = 0;
                if (int.TryParse(re, out chk))
                {
                    txtId.Value = re;
                    btnSave.Image = Resources.accept_database24;
                }
                else
                {
                    btnSave.Image = Resources.accept_database24;
                }
                setGrfErf();
            }
        }
        private void FrmExpenseRefund_Load(object sender, EventArgs e)
        {

        }
    }
}
