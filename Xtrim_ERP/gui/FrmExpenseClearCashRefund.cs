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
    public partial class FrmExpenseClearCashRefund : Form
    {
        XtrimControl xC;
        JobImport jim;
        ExpensesPayDetail expnpd;
        ExpensesClearCash ecc;
        ExpensesRefund erf;
        String jobId = "", userId = "", erfId = "", pdid = "";

        public FrmExpenseClearCashRefund(XtrimControl x, String userId, String erfId)
        {
            InitializeComponent();
            xC = x;
            this.userId = userId;
            this.erfId = erfId;
            initConfig();
        }
        private void initConfig()
        {
            jim = new JobImport();
            expnpd = new ExpensesPayDetail();
            ecc = new ExpensesClearCash();
            erf = new ExpensesRefund();
            xC.xtDB.stfDB.setCboStaff(cboStaff, userId);
            
            jim = xC.xtDB.jimDB.selectByPk1(jobId);
            ecc = xC.xtDB.eccDB.selectByPk1(erfId);
            txtJobCode.Value = jim.job_import_code;

            DateTime erfDate = DateTime.Now;
            txtErfDate.Value = erfDate.Year.ToString() + "-" + erfDate.ToString("MM-dd");

            btnSave.Click += BtnSave_Click;
            setControl(erfId);
            
        }
        private void setErf()
        {
            jim = xC.xtDB.jimDB.selectByPk1(jobId);
            erf.expenses_refund_id = txtId.Text;
            erf.expense_clear_cash_id = "";
            erf.expenses_pay_detail_id = pdid;
            erf.job_id = jim.job_import_id;
            erf.desc1 = txtDesc.Text;
            erf.amount = txtRefund.Text.Replace("$", "").Replace(",", "");
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
            erf.ecc_doc = erfId;
            erf.job_code = jim.job_import_code;
            erf.pay_staff_id = cboStaff.SelectedItem != null ? ((ComboBoxItem)(cboStaff.SelectedItem)).Value : "";
            erf.expenses_refund_date = xC.datetoDB(txtErfDate.Text);
        }
        private void setControl(String erfId)
        {
            erf = xC.xtDB.erfDB.selectByPk1(erfId);
            txtId.Value = erf.expenses_refund_id;
            jobId = erf.job_id;
            this.erfId = erf.expense_clear_cash_id;
            pdid = erf.expenses_pay_detail_id;
            txtRefund.Value = erf.amount;
            txtErfDate.Value = erf.expenses_refund_date;
            txtDesc.Value = erf.desc1;
            txtRemark.Value = erf.remark;
            xC.setCboC1(cboStaff, erf.pay_staff_id);
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
            }
        }
        private void FrmExpenseClearCashRefund_Load(object sender, EventArgs e)
        {

        }
    }
}
