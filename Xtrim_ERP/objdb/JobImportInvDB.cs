using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xtrim_ERP.object1;

namespace Xtrim_ERP.objdb
{
    public class JobImportInvDB
    {
        public JobImportInv jin;
        ConnectDB conn;

        public JobImportInvDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            jin = new JobImportInv();
            jin.job_import_inv_id  = "job_import_inv_id";
            jin.job_import_id  = "job_import_id";
            jin.invoice_date  = "invoice_date";
            //jin.t_job_import_invcol  = "t_job_import_invcol";
            jin.cons_id  = "cons_id";
            jin.inco_terms_id  = "inco_terms_id";
            jin.term_pay_id  = "term_payment_id";
            jin.amount  = "amount";
            jin.curr_id  = "curr_id";
            jin.date_create  = "date_create";
            jin.date_modi  = "date_modi";
            jin.date_cancel  = "date_cancel";
            jin.user_create  = "user_create";
            jin.user_modi  = "user_modi";
            jin.user_cancel  = "user_cancel";
            jin.remark = "remark";
            jin.active = "active";
            jin.inv_no = "inv_no";

            jin.suppCode = "supp_code";
            jin.SuppNameT = "supp_name_t";
            jin.ictCode = "";
            jin.ictNameT = "";
            jin.currCode = "curr_code";
            jin.currNameT = "curr_name_t";
            jin.tpmCode = "";
            jin.tpmNameT = "";

            jin.table = "t_job_import_inv";
            jin.pkField = "job_import_inv_id";
        }
        public String insert(JobImportInv p)
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
            p.term_pay_id = int.TryParse(p.term_pay_id, out chk) ? chk.ToString() : "0";
            p.inco_terms_id = int.TryParse(p.inco_terms_id, out chk) ? chk.ToString() : "0";
            p.curr_id = int.TryParse(p.curr_id, out chk) ? chk.ToString() : "0";
            p.cons_id = int.TryParse(p.cons_id, out chk) ? chk.ToString() : "0";
            p.job_import_id = int.TryParse(p.job_import_id, out chk) ? chk.ToString() : "0";
            p.amount = Decimal.TryParse(p.amount, out chk1) ? chk1.ToString() : "0";

            sql = "Insert Into " + jin.table + "(" + jin.job_import_id + "," + jin.invoice_date + "," + jin.cons_id + "," +
                jin.date_create + "," + jin.date_modi + "," + jin.date_cancel + "," +
                jin.user_create + "," + jin.user_modi + "," + jin.user_cancel + "," +
                jin.active + "," + jin.remark + ", " + jin.curr_id + ", " +
                jin.amount + "," + jin.term_pay_id + ", " + jin.inco_terms_id + ", " +
                jin.inv_no + " " +
                ") " +
                "Values ('" + p.job_import_id + "','" + p.invoice_date + "','" + p.cons_id + "'," +
                "now(),'" + p.date_modi + "','" + p.date_cancel + "'," +
                "'" + p.user_create + "','" + p.user_modi + "','" + p.user_cancel + "'," +
                "'" + p.active + "','" + p.remark.Replace("'", "''") + "','" + p.curr_id + "'," +
                "'" + p.amount + "','" + p.term_pay_id + "','" + p.inco_terms_id + "', " + 
                "'" + p.inv_no.Replace("'", "''") + "' " +
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
        public String update(JobImportInv p)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            sql = "Update " + jin.table + " Set " +
                " " + jin.job_import_id + " = '" + p.job_import_id + "'" +
                "," + jin.invoice_date + " = '" + p.invoice_date.Replace("'", "''") + "'" +
                "," + jin.cons_id + " = '" + p.cons_id.Replace("'", "''") + "'" +
                "," + jin.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + jin.date_modi + " = now()" +
                "," + jin.user_modi + " = '" + p.user_modi + "' " +
                "," + jin.curr_id + " = '" + p.curr_id + "' " +
                "," + jin.amount + " = '" + p.amount + "' " +
                "," + jin.term_pay_id + " = '" + p.term_pay_id + "' " +
                "," + jin.inco_terms_id + " = '" + p.inco_terms_id + "' " +
                "," + jin.inv_no + " = '" + p.inv_no.Replace("'", "''") + "' " +
                "Where " + jin.pkField + "='" + p.job_import_inv_id + "'"
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
        public String insertJobImportInv(JobImportInv p)
        {
            String re = "";

            if (p.job_import_inv_id.Equals(""))
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
            String sql = "Delete From  " + jin.table;
            conn.ExecuteNonQuery(conn.conn, sql);

            return "";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select jin.*  " +
                "From " + jin.table + " jin " +
                " " +
                "Where jin." + jin.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByJobId(String jobid)
        {
            //JobImportInv cop1 = new JobImportInv();
            DataTable dt = new DataTable();
            String sql = "select jin.* " +
                ", IFNULL(cons.cons_code, '') as supp_code, IFNULL(cons.cons_name_t, '') as supp_name_t " +
                ", IFNULL(ict.inco_terms_code, '') as inco_terms_code, IFNULL(ict.inco_terms_name_t, '') as inco_terms_name_t " +
                ", IFNULL(tpm.term_payment_code, '') as term_payment_code, IFNULL(tpm.term_payment_name_t, '') as term_payment_name_t " +
                ", IFNULL(curr.curr_code, '') as curr_code, IFNULL(curr.curr_name_t, '') as curr_name_t " +
                "From " + jin.table + " jin " +
                "Left Join b_consignee cons On jin.cons_id = cons.cons_id " +
                "Left Join b_inco_terms ict On jin.inco_terms_id = ict.inco_terms_id " +
                "Left Join b_term_payment tpm On jin.term_payment_id = tpm.term_payment_id " +
                "Left Join b_currency curr On jin.curr_id = curr.curr_id " +
                "Where jin." + jin.job_import_id + " ='" + jobid + "' ";
            dt = conn.selectData(conn.conn, sql);
            //cop1 = setJobImportInv(dt);
            return dt;
        }
        public DataTable selectByPk(String invId)
        {
            DataTable dt = new DataTable();
            String sql = "select jin.* " +
                "From " + jin.table + " jin " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where jin." + jin.pkField + " ='" + invId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public JobImportInv selectByPk1(String invId)
        {
            JobImportInv cop1 = new JobImportInv();
            DataTable dt = new DataTable();
            String sql = "select jin.* " +
                ", IFNULL(cons.cons_code, '') as supp_code, IFNULL(cons.cons_name_t, '') as supp_name_t " +
                ", IFNULL(ict.inco_terms_code, '') as inco_terms_code, IFNULL(ict.inco_terms_name_t, '') as inco_terms_name_t " +
                ", IFNULL(tpm.term_payment_code, '') as term_payment_code, IFNULL(tpm.term_payment_name_t, '') as term_payment_name_t " +
                ", IFNULL(curr.curr_code, '') as curr_code, IFNULL(curr.curr_name_t, '') as curr_name_t " +
                "From " + jin.table + " jin " +
                "Left Join b_consignee cons On jin.cons_id = cons.cons_id " +
                "Left Join b_inco_terms ict On jin.inco_terms_id = ict.inco_terms_id " +
                "Left Join b_term_payment tpm On jin.term_payment_id = tpm.term_payment_id " +
                "Left Join b_currency curr On jin.curr_id = curr.curr_id " +
                "Where jin." + jin.pkField + " ='" + invId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setJobImportInv(dt);
            return cop1;
        }
        private JobImportInv setJobImportInv(DataTable dt)
        {
            JobImportInv jin1 = new JobImportInv();
            if (dt.Rows.Count > 0)
            {
                jin1.job_import_inv_id = dt.Rows[0][jin.job_import_inv_id].ToString();
                jin1.job_import_id = dt.Rows[0][jin.job_import_id].ToString();
                jin1.invoice_date = dt.Rows[0][jin.invoice_date].ToString();
                jin1.cons_id = dt.Rows[0][jin.cons_id].ToString();
                jin1.inco_terms_id = dt.Rows[0][jin.inco_terms_id].ToString();
                jin1.date_cancel = dt.Rows[0][jin.date_cancel].ToString();
                jin1.date_create = dt.Rows[0][jin.date_create].ToString();
                jin1.date_modi = dt.Rows[0][jin.date_modi].ToString();
                jin1.user_cancel = dt.Rows[0][jin.user_cancel].ToString();
                jin1.user_create = dt.Rows[0][jin.user_create].ToString();
                jin1.user_modi = dt.Rows[0][jin.user_modi].ToString();
                jin1.term_pay_id = dt.Rows[0][jin.term_pay_id].ToString();
                jin1.amount = dt.Rows[0][jin.amount].ToString();
                jin1.curr_id = dt.Rows[0][jin.curr_id].ToString();
                jin1.remark = dt.Rows[0][jin.remark].ToString();
                jin1.active = dt.Rows[0][jin.active].ToString();
                jin1.inv_no = dt.Rows[0][jin.inv_no].ToString();

                jin1.suppCode = dt.Rows[0]["supp_code"].ToString();
                jin1.SuppNameT = dt.Rows[0]["supp_name_t"].ToString();
                jin1.ictCode = dt.Rows[0]["inco_terms_code"].ToString();
                jin1.ictNameT = dt.Rows[0]["inco_terms_name_t"].ToString();
                jin1.currCode = dt.Rows[0]["curr_code"].ToString();
                jin1.currNameT = dt.Rows[0]["curr_name_t"].ToString();
            }

            return jin1;
        }
    }
}
