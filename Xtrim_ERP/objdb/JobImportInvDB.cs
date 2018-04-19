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
            jin.inco_teams_id  = "inco_teams_id";
            jin.term_pay_id  = "term_pay_id";
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

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            //p.prefix_id = int.TryParse(p.prefix_id, out chk) ? chk.ToString() : "0";
            //p.dept_id = int.TryParse(p.dept_id, out chk) ? chk.ToString() : "0";

            sql = "Insert Into " + jin.table + "(" + jin.job_import_id + "," + jin.invoice_date + "," + jin.cons_id + "," +
                jin.date_create + "," + jin.date_modi + "," + jin.date_cancel + "," +
                jin.user_create + "," + jin.user_modi + "," + jin.user_cancel + "," +
                jin.active + "," + jin.remark + ", " + jin.curr_id + ", " +
                jin.amount + "," + jin.term_pay_id + ", " + jin.inco_teams_id + ", " +
                jin.inv_no + " " +
                ") " +
                "Values ('" + p.job_import_id + "','" + p.invoice_date + "','" + p.cons_id + "'," +
                "'" + p.date_create + "','" + p.date_modi + "','" + p.date_cancel + "'," +
                "'" + p.user_create + "','" + p.user_modi + "','" + p.user_cancel + "'," +
                "'" + p.active + "','" + p.remark.Replace("'", "''") + "','" + p.curr_id + "'," +
                "'" + p.amount + "','" + p.term_pay_id + "','" + p.inco_teams_id + "', " + 
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
                "," + jin.inco_teams_id + " = '" + p.inco_teams_id + "' " +
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
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select jin.* " +
                "From " + jin.table + " jin " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where jin." + jin.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public JobImportInv selectByPk1(String copId)
        {
            JobImportInv cop1 = new JobImportInv();
            DataTable dt = new DataTable();
            String sql = "select jin.* " +
                "From " + jin.table + " jin " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where jin." + jin.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setJobImportInv(dt);
            return cop1;
        }
        private JobImportInv setJobImportInv(DataTable dt)
        {
            JobImportInv pti1 = new JobImportInv();
            if (dt.Rows.Count > 0)
            {
                pti1.job_import_inv_id = dt.Rows[0][jin.job_import_inv_id].ToString();
                pti1.job_import_id = dt.Rows[0][jin.job_import_id].ToString();
                pti1.invoice_date = dt.Rows[0][jin.invoice_date].ToString();
                pti1.cons_id = dt.Rows[0][jin.cons_id].ToString();
                pti1.inco_teams_id = dt.Rows[0][jin.inco_teams_id].ToString();
                pti1.date_cancel = dt.Rows[0][jin.date_cancel].ToString();
                pti1.date_create = dt.Rows[0][jin.date_create].ToString();
                pti1.date_modi = dt.Rows[0][jin.date_modi].ToString();
                pti1.user_cancel = dt.Rows[0][jin.user_cancel].ToString();
                pti1.user_create = dt.Rows[0][jin.user_create].ToString();
                pti1.user_modi = dt.Rows[0][jin.user_modi].ToString();
                pti1.term_pay_id = dt.Rows[0][jin.term_pay_id].ToString();
                pti1.amount = dt.Rows[0][jin.amount].ToString();
                pti1.curr_id = dt.Rows[0][jin.curr_id].ToString();
                pti1.remark = dt.Rows[0][jin.remark].ToString();
                pti1.active = dt.Rows[0][jin.active].ToString();
                //pti1.sort1 = dt.Rows[0][jin.sort1].ToString();
                //pti1.sort1 = dt.Rows[0][jin.sort1].ToString();
            }

            return pti1;
        }
    }
}
