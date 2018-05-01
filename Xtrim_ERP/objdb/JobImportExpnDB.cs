using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xtrim_ERP.object1;

namespace Xtrim_ERP.objdb
{
    public class JobImportExpnDB
    {
        public JobImportExpn jie;
        ConnectDB conn;

        public JobImportExpnDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            jie = new JobImportExpn();
            jie.job_import_expenses_id = "job_import_expenses_id";
            jie.job_import_id = "job_import_id";
            jie.expenses_id = "expenses_id";
            jie.row_no = "row_no";
            jie.expenses_date = "expenses_date";
            jie.method_payment_id = "method_payment_id";
            jie.tax_date = "tax_date";
            jie.tax_amount = "tax_amount";
            jie.amount = "amount";
            jie.cost_amount = "cost_amount";
            jie.status_deposit = "status_deposit";
            jie.remark = "remark";
            jie.receipt_no = "receipt_no";
            jie.receipt_date = "receipt_date";
            jie.status_receipt = "status_receipt";
            jie.status_billing = "status_billing";
            jie.cheque_no = "cheque_no";
            jie.cheque_amount = "cheque_amount";
            jie.xtrim_is_no = "xtrim_is_no";
            jie.tax_card = "tax_card";
            jie.enter_inv_no = "enter_inv_no";
            jie.tax_gkn_id = "tax_gkn_id";
            jie.amount_pay = "amount_pay";
            jie.cheque_pay_amount = "cheque_pay_amount";
            jie.cheque_pay_no = "cheque_pay_no";
            jie.cheque_date = "cheque_date";
            jie.active = "active";
            jie.date_create = "date_create";
            jie.date_modi = "date_modi";
            jie.date_cancel = "date_cancel";
            jie.user_create = "user_create";
            jie.user_modi = "user_modi";
            jie.user_cancel = "user_cancel";

            jie.table = "t_job_import_expenses";
            jie.pkField = "job_import_expenses_id";
        }
        public String insert(JobImportExpn p)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;
            Decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            p.remark = p.remark == null ? "" : p.remark;
            //p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            //p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            //p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            //p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            //p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            p.job_import_id = int.TryParse(p.job_import_id, out chk) ? chk.ToString() : "0";
            p.expenses_id = int.TryParse(p.expenses_id, out chk) ? chk.ToString() : "0";
            p.row_no = int.TryParse(p.row_no, out chk) ? chk.ToString() : "0";
            p.method_payment_id = int.TryParse(p.method_payment_id, out chk) ? chk.ToString() : "0";
            //p.job_import_id1 = int.TryParse(p.job_import_id1, out chk) ? chk.ToString() : "0";
            p.tax_amount = Decimal.TryParse(p.tax_amount, out chk1) ? chk1.ToString() : "0";
            p.amount = Decimal.TryParse(p.amount, out chk1) ? chk1.ToString() : "0";
            p.cost_amount = Decimal.TryParse(p.cost_amount, out chk1) ? chk1.ToString() : "0";
            p.cheque_amount = Decimal.TryParse(p.cheque_amount, out chk1) ? chk1.ToString() : "0";
            p.amount_pay = Decimal.TryParse(p.amount_pay, out chk1) ? chk1.ToString() : "0";
            p.cheque_pay_amount = Decimal.TryParse(p.cheque_pay_amount, out chk1) ? chk1.ToString() : "0";
            //p.amount1 = Decimal.TryParse(p.amount1, out chk1) ? chk1.ToString() : "0";
            //p.amount1 = Decimal.TryParse(p.amount1, out chk1) ? chk1.ToString() : "0";
            //p.amount1 = Decimal.TryParse(p.amount1, out chk1) ? chk1.ToString() : "0";
            //p.amount1 = Decimal.TryParse(p.amount1, out chk1) ? chk1.ToString() : "0";

            sql = "Insert Into " + jie.table + "(" + jie.job_import_id + "," + jie.expenses_id + "," + jie.row_no + "," +
                jie.expenses_date + "," + jie.method_payment_id + "," + jie.tax_date + "," +
                jie.tax_amount + "," + jie.amount + "," + jie.cost_amount + "," +
                jie.status_deposit + "," + jie.remark + ", " + jie.receipt_no + ", " +
                jie.receipt_date + "," + jie.status_receipt + ", " + jie.status_billing + ", " +
                jie.cheque_no + "," + jie.cheque_amount + ", " + jie.xtrim_is_no + ", " +
                jie.tax_card + "," + jie.enter_inv_no + ", " + jie.tax_gkn_id + ", " +
                jie.amount_pay + "," + jie.cheque_pay_amount + ", " + jie.cheque_pay_no + ", " +
                jie.cheque_date + "," + jie.active + ", " + jie.date_create + ", " +
                jie.date_modi + "," + jie.date_cancel + ", " + jie.user_create + ", " +
                jie.user_modi + "," + jie.user_cancel + " "+
                ") " +
                "Values ('" + p.job_import_id + "','" + p.expenses_id + "','" + p.row_no + "'," +
                "'" +p.expenses_date + "','" + p.method_payment_id + "','" + p.tax_date + "'," +
                "'" + p.tax_amount + "','" + p.amount + "','" + p.cost_amount + "'," +
                "'" + p.status_deposit + "','" + p.remark.Replace("'", "''") + "','" + p.receipt_no + "'," +
                "'" + p.receipt_date + "','" + p.status_receipt + "','" + p.status_billing + "', " +
                "'" + p.cheque_no + "','" + p.cheque_amount + "','" + p.xtrim_is_no + "', " +
                "'" + p.tax_card + "','" + p.enter_inv_no + "','" + p.tax_gkn_id + "', " +
                "'" + p.amount_pay + "','" + p.cheque_pay_amount + "','" + p.cheque_pay_no + "', " +
                "'" + p.cheque_date + "','" + p.active + "',now(), " +
                "'" + p.date_modi + "','" + p.date_cancel + "','" + p.user_create + "', " +
                "'" + p.user_modi.Replace("'", "''") + "','" + p.user_cancel + "' "+
                ")";
            try
            {
                re = conn.ExecuteNonQuery(conn.conn, sql);
            }
            catch (Exception ex)
            {
                sql = ex.Message + " " + ex.InnerException;
            }

            return re;
        }
        public String update(JobImportExpn p)
        {
            String re = "";
            String sql = "";
            int chk = 0;
            Decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            p.remark = p.remark == null ? "" : p.remark;
            //p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            //p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            //p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            //p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            //p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            p.job_import_id = int.TryParse(p.job_import_id, out chk) ? chk.ToString() : "0";
            p.expenses_id = int.TryParse(p.expenses_id, out chk) ? chk.ToString() : "0";
            p.row_no = int.TryParse(p.row_no, out chk) ? chk.ToString() : "0";
            p.method_payment_id = int.TryParse(p.method_payment_id, out chk) ? chk.ToString() : "0";
            //p.job_import_id1 = int.TryParse(p.job_import_id1, out chk) ? chk.ToString() : "0";
            p.tax_amount = Decimal.TryParse(p.tax_amount, out chk1) ? chk1.ToString() : "0";
            p.amount = Decimal.TryParse(p.amount, out chk1) ? chk1.ToString() : "0";
            p.cost_amount = Decimal.TryParse(p.cost_amount, out chk1) ? chk1.ToString() : "0";
            p.cheque_amount = Decimal.TryParse(p.cheque_amount, out chk1) ? chk1.ToString() : "0";
            p.amount_pay = Decimal.TryParse(p.amount_pay, out chk1) ? chk1.ToString() : "0";
            p.cheque_pay_amount = Decimal.TryParse(p.cheque_pay_amount, out chk1) ? chk1.ToString() : "0";

            sql = "Update " + jie.table + " Set " +
                " " + jie.job_import_id + " = '" + p.job_import_id + "'" +
                "," + jie.expenses_id + " = '" + p.expenses_id.Replace("'", "''") + "'" +
                "," + jie.row_no + " = '" + p.row_no.Replace("'", "''") + "'" +
                "," + jie.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + jie.date_modi + " = now()" +
                "," + jie.user_modi + " = '" + p.user_modi + "' " +
                "," + jie.expenses_date + " = '" + p.expenses_date + "' " +
                "," + jie.method_payment_id + " = '" + p.method_payment_id + "' " +
                "," + jie.tax_date + " = '" + p.tax_date + "' " +
                "," + jie.tax_amount + " = '" + p.tax_amount + "' " +
                "," + jie.amount + " = '" + p.amount.Replace("'", "''") + "' " +
                "," + jie.cost_amount + " = '" + p.cost_amount.Replace("'", "''") + "' " +
                "," + jie.status_deposit + " = '" + p.status_deposit.Replace("'", "''") + "' " +
                "," + jie.receipt_no + " = '" + p.receipt_no.Replace("'", "''") + "' " +
                "," + jie.receipt_date + " = '" + p.receipt_date.Replace("'", "''") + "' " +
                "," + jie.status_receipt + " = '" + p.status_receipt.Replace("'", "''") + "' " +
                "," + jie.status_billing + " = '" + p.status_billing.Replace("'", "''") + "' " +
                "," + jie.cheque_no + " = '" + p.cheque_no.Replace("'", "''") + "' " +
                "," + jie.cheque_amount + " = '" + p.cheque_amount.Replace("'", "''") + "' " +
                "," + jie.xtrim_is_no + " = '" + p.xtrim_is_no.Replace("'", "''") + "' " +
                "," + jie.tax_card + " = '" + p.tax_card.Replace("'", "''") + "' " +
                "," + jie.enter_inv_no + " = '" + p.enter_inv_no.Replace("'", "''") + "' " +
                "," + jie.tax_gkn_id + " = '" + p.tax_gkn_id.Replace("'", "''") + "' " +
                "," + jie.amount_pay + " = '" + p.amount_pay.Replace("'", "''") + "' " +
                "," + jie.cheque_pay_amount + " = '" + p.cheque_pay_amount.Replace("'", "''") + "' " +
                "," + jie.cheque_pay_no + " = '" + p.cheque_pay_no.Replace("'", "''") + "' " +
                "," + jie.cheque_date + " = '" + p.cheque_date.Replace("'", "''") + "' " +
                
                "Where " + jie.pkField + "='" + p.job_import_expenses_id + "'"
                ;

            try
            {
                re = conn.ExecuteNonQuery(conn.conn, sql);
            }
            catch (Exception ex)
            {
                sql = ex.Message + " " + ex.InnerException;
            }

            return re;
        }
        public String insertJobImportExpn(JobImportExpn p)
        {
            String re = "";

            if (p.job_import_expenses_id.Equals(""))
            {
                re = insert(p);
            }
            else
            {
                re = update(p);
            }

            return re;
        }
        public String deleteAll()
        {
            DataTable dt = new DataTable();
            String sql = "Delete From  " + jie.table;
            conn.ExecuteNonQuery(conn.conn, sql);

            return "";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select jie.*  " +
                "From " + jie.table + " jie " +
                " " +
                "Where jie." + jie.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String invId)
        {
            DataTable dt = new DataTable();
            String sql = "select jie.* " +
                "From " + jie.table + " jie " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where jie." + jie.pkField + " ='" + invId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByJobId(String jobid)
        {
            //JobImportInv cop1 = new JobImportInv();
            DataTable dt = new DataTable();
            String sql = "select jie.* " +
                ", IFNULL(expn.expenses_code, '') as expenses_code, IFNULL(expn.expenses_name_t, '') as expenses_name_t " +
                ", IFNULL(mtp.method_payment_code, '') as method_payment_code, IFNULL(mtp.method_payment_name_t, '') as method_payment_name_t " +                
                "From " + jie.table + " jie " +
                "Left Join b_expenses expn On jie.expenses_id = expn.expenses_id " +
                "Left Join b_method_payment mtp On jie.method_payment_id = mtp.method_payment_id " +                
                "Where jie." + jie.job_import_id + " ='" + jobid + "' ";
            dt = conn.selectData(conn.conn, sql);
            //cop1 = setJobImportInv(dt);
            return dt;
        }
        private JobImportExpn setJobImportExpn(DataTable dt)
        {
            JobImportExpn jie1 = new JobImportExpn();
            if (dt.Rows.Count > 0)
            {
                jie1.job_import_expenses_id = dt.Rows[0][jie.job_import_expenses_id].ToString();
                jie1.job_import_id = dt.Rows[0][jie.job_import_id].ToString();
                jie1.expenses_id = dt.Rows[0][jie.expenses_id].ToString();
                jie1.row_no = dt.Rows[0][jie.row_no].ToString();
                jie1.expenses_date = dt.Rows[0][jie.expenses_date].ToString();
                jie1.date_cancel = dt.Rows[0][jie.date_cancel].ToString();
                jie1.date_create = dt.Rows[0][jie.date_create].ToString();
                jie1.date_modi = dt.Rows[0][jie.date_modi].ToString();
                jie1.user_cancel = dt.Rows[0][jie.user_cancel].ToString();
                jie1.user_create = dt.Rows[0][jie.user_create].ToString();
                jie1.user_modi = dt.Rows[0][jie.user_modi].ToString();
                jie1.method_payment_id = dt.Rows[0][jie.method_payment_id].ToString();
                jie1.tax_date = dt.Rows[0][jie.tax_date].ToString();
                jie1.tax_amount = dt.Rows[0][jie.tax_amount].ToString();
                jie1.amount = dt.Rows[0][jie.amount].ToString();
                jie1.cost_amount = dt.Rows[0][jie.cost_amount].ToString();
                jie1.status_deposit = dt.Rows[0][jie.status_deposit].ToString();
                jie1.remark = dt.Rows[0][jie.remark].ToString();
                jie1.receipt_no = dt.Rows[0][jie.receipt_no].ToString();
                jie1.receipt_date = dt.Rows[0][jie.receipt_date].ToString();
                jie1.status_receipt = dt.Rows[0][jie.status_receipt].ToString();
                jie1.status_billing = dt.Rows[0][jie.status_billing].ToString();
                jie1.cheque_no = dt.Rows[0][jie.cheque_no].ToString();
                jie1.cheque_amount = dt.Rows[0][jie.cheque_amount].ToString();
                jie1.xtrim_is_no = dt.Rows[0][jie.xtrim_is_no].ToString();
                jie1.tax_card = dt.Rows[0][jie.tax_card].ToString();
                jie1.enter_inv_no = dt.Rows[0][jie.enter_inv_no].ToString();
                jie1.tax_gkn_id = dt.Rows[0][jie.tax_gkn_id].ToString();
                jie1.amount_pay = dt.Rows[0][jie.amount_pay].ToString();
                jie1.cheque_pay_amount = dt.Rows[0][jie.cheque_pay_amount].ToString();
                jie1.cheque_pay_no = dt.Rows[0][jie.cheque_pay_no].ToString();
                jie1.cheque_date = dt.Rows[0][jie.cheque_date].ToString();
                jie1.active = dt.Rows[0][jie.active].ToString();
                //jie1.inv_no = dt.Rows[0][jie.inv_no].ToString();
                //jie1.inv_no = dt.Rows[0][jie.inv_no].ToString();
                //jie1.inv_no = dt.Rows[0][jie.inv_no].ToString();
                //jie1.inv_no = dt.Rows[0][jie.inv_no].ToString();
                //jie1.inv_no = dt.Rows[0][jie.inv_no].ToString();
                //jie1.inv_no = dt.Rows[0][jie.inv_no].ToString();


                //jie1.suppCode = dt.Rows[0]["supp_code"].ToString();
                //jie1.SuppNameT = dt.Rows[0]["supp_name_t"].ToString();
                //jie1.ictCode = dt.Rows[0]["inco_terms_code"].ToString();
                //jie1.ictNameT = dt.Rows[0]["inco_terms_name_t"].ToString();
                //jie1.currCode = dt.Rows[0]["curr_code"].ToString();
                //jie1.currNameT = dt.Rows[0]["curr_name_t"].ToString();
            }

            return jie1;
        }
    }
}
