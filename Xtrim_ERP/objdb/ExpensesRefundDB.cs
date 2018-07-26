using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xtrim_ERP.object1;

namespace Xtrim_ERP.objdb
{
    public class ExpensesRefundDB
    {
        public ExpensesRefund erf;
        ConnectDB conn;
        public List<ExpensesRefund> lexpn;
        public ExpensesRefundDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            erf = new ExpensesRefund();
            erf.expenses_refund_id = "expenses_refund_id";
            erf.expense_clear_cash_id = "expense_clear_cash_id";
            erf.expenses_pay_detail_id = "expenses_pay_detail_id";
            erf.job_id = "job_id";
            erf.desc1 = "desc1";
            erf.amount = "amount";
            erf.active = "active";
            erf.remark = "remark";
            erf.date_create = "date_create";
            erf.date_modi = "date_modi";
            erf.date_cancel = "date_cancel";
            erf.user_create = "user_create";
            erf.user_modi = "user_modi";
            erf.user_cancel = "user_cancel";
            erf.status_page = "status_page";
            erf.status_appv = "status_appv";
            erf.status_doc = "status_doc";
            erf.expenses_refund_date = "expenses_refund_date";
            erf.ecc_doc = "ecc_doc";
            erf.job_code = "job_code";

            erf.table = "t_expenses_refund";
            erf.pkField = "expenses_refund_id";

            lexpn = new List<ExpensesRefund>();
        }
        public String getIdByName(String name)
        {
            String id = "";
            foreach (ExpensesRefund utp1 in lexpn)
            {
                if (name.Trim().Equals(utp1.expense_clear_cash_id))
                {
                    id = utp1.expenses_refund_id;
                    break;
                }
            }
            return id;
        }
        private void chkNull(ExpensesRefund p)
        {
            int chk = 0;
            Decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            p.status_appv = p.status_appv == null ? "0" : p.status_appv;
            p.status_doc = p.status_doc == null ? "0" : p.status_doc;
            p.status_page = p.status_page == null ? "0" : p.status_page;
            p.desc1 = p.desc1 == null ? "" : p.desc1;
            p.remark = p.remark == null ? "" : p.remark;
            p.expenses_refund_date = p.expenses_refund_date == null ? "" : p.expenses_refund_date;
            p.job_code = p.job_code == null ? "" : p.job_code;

            p.expense_clear_cash_id = int.TryParse(p.expense_clear_cash_id, out chk) ? chk.ToString() : "0";
            p.job_id = int.TryParse(p.job_id, out chk) ? chk.ToString() : "0";
            p.expenses_pay_detail_id = int.TryParse(p.expenses_pay_detail_id, out chk) ? chk.ToString() : "0";
            p.ecc_doc = int.TryParse(p.ecc_doc, out chk) ? chk.ToString() : "0";


            p.amount = Decimal.TryParse(p.amount, out chk1) ? chk1.ToString() : "0";
        }
        public String insert(ExpensesRefund p, String userId)
        {
            String re = "", sql = "";
            p.active = "1";
            p.status_appv = "0";
            p.status_doc = "0";
            chkNull(p);
            sql = "Insert Into " + erf.table + "(" + erf.expenses_pay_detail_id + "," + erf.expense_clear_cash_id + "," + erf.desc1 + "," +
                erf.active + "," + erf.remark + ", " + erf.job_id + ", " +
                erf.date_create + ", " + erf.date_modi + ", " + erf.date_cancel + ", " +
                erf.user_create + ", " + erf.user_modi + ", " + erf.user_cancel + "," +
                erf.amount + "," + erf.status_page + "," + erf.status_appv + ", " +
                erf.status_doc + "," + erf.expenses_refund_date + "," + erf.ecc_doc + "," +
                erf.job_code + " " +
                ") " +
                "Values ('" + p.expenses_pay_detail_id + "','" + p.expense_clear_cash_id + "','" + p.desc1 + "'," +
                "'" + p.active + "','" + p.remark + "','" + p.job_id + "', " +
                "now(),'" + p.date_modi + "','" + p.date_cancel + "', " +
                "'" + userId + "','" + p.user_modi + "','" + p.user_cancel + "'," +
                "'" + p.amount + "','" + p.status_page + "','" + p.status_appv + "'," +
                "'" + p.status_doc + "','" + p.expenses_refund_date + "','" + p.ecc_doc + "'," +
                "'" + p.job_code + "' " +
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
        public String update(ExpensesRefund p, String userId)
        {
            String re = "", sql = "";
            chkNull(p);
            sql = "Update " + erf.table + " Set " +
                " " + erf.expenses_pay_detail_id + "='" + p.expenses_pay_detail_id + "' " +
                "," + erf.desc1 + "='" + p.desc1.Replace("'", "''") + "' " +
                "," + erf.expense_clear_cash_id + "='" + p.expense_clear_cash_id.Replace("'", "''") + "' " +
                "," + erf.remark + "='" + p.remark.Replace("'", "''") + "' " +
                "," + erf.date_modi + "=now() " +
                "," + erf.user_modi + "='" + userId.Replace("'", "''") + "' " +
                "," + erf.job_id + "='" + p.job_id.Replace("'", "''") + "' " +
                "," + erf.amount + "='" + p.amount.Replace("'", "''") + "' " +
                "," + erf.status_page + "='" + p.status_page.Replace("'", "''") + "' " +
                "," + erf.status_appv + "='" + p.status_appv.Replace("'", "''") + "' " +
                "," + erf.job_code + "='" + p.job_code.Replace("'", "''") + "' " +
                "," + erf.ecc_doc + "='" + p.ecc_doc.Replace("'", "''") + "' " +
                "Where " + erf.pkField + "='" + p.expenses_refund_id + "'";

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
        public String insertExpensesRefund(ExpensesRefund p, String userId)
        {
            String re = "";

            if (p.expenses_refund_id.Equals(""))
            {
                re = insert(p, userId);
            }
            else
            {
                re = update(p, userId);
            }
            return re;
        }
        public String voidExpensesRefund(String id)
        {
            String re = "", sql = "";
            sql = "Update " + erf.table + " Set " +
                " " + erf.active + "='3' " +
                "," + erf.date_cancel + "=now() " +
                "Where " + erf.expenses_refund_id + "='" + id + "'";
            re = conn.ExecuteNonQuery(conn.conn, sql);

            return re;
        }
        public String updateBillingCover(String id, String coverid)
        {
            String re = "", sql = "";
            sql = "Update " + erf.table + " Set " +
                " " + erf.status_appv + "='" + coverid + "' " +
                "Where " + erf.expenses_refund_id + "='" + id + "'";
            re = conn.ExecuteNonQuery(conn.conn, sql);

            return re;
        }
        public DataTable selectByCusId(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select bll.* " +
                "From " + erf.table + " bll " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where bll." + erf.status_page + " ='" + copId + "' and " + erf.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByEccDoc(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select bll.* " +
                "From " + erf.table + " bll " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where bll." + erf.ecc_doc + " ='" + copId + "' and " + erf.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select bll.* " +
                "From " + erf.table + " bll " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where bll." + erf.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select bll.* " +
                "From " + erf.table + " bll " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where bll." + erf.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public ExpensesRefund selectByPk1(String copId)
        {
            ExpensesRefund cop1 = new ExpensesRefund();
            DataTable dt = new DataTable();
            String sql = "select bll.* " +
                "From " + erf.table + " bll " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where bll." + erf.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setExpensesRefund(dt);
            return cop1;
        }
        public String selectSumByEccDoc(String eccdoc)
        {
            DataTable dt = new DataTable();
            String sql = "", wherestatusappv = "";

            sql = "select sum(" + erf.amount + ") as " + erf.amount + " " +
                "From " + erf.table + "  " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where " + erf.active + " = '1' and " + erf.ecc_doc + "='" + eccdoc + "'";
            dt = conn.selectData(conn.conn, sql);
            String re = "";
            Decimal chk = 0;
            re = dt.Rows[0][erf.amount].ToString();
            Decimal.TryParse(re, out chk);
            
            return chk.ToString();
        }
        public ExpensesRefund setExpensesRefund(DataTable dt)
        {
            ExpensesRefund erf1 = new ExpensesRefund();
            if (dt.Rows.Count > 0)
            {
                erf1.expenses_refund_id = dt.Rows[0][erf.expenses_refund_id].ToString();
                erf1.expense_clear_cash_id = dt.Rows[0][erf.expense_clear_cash_id].ToString();
                erf1.expenses_pay_detail_id = dt.Rows[0][erf.expenses_pay_detail_id].ToString();
                erf1.job_id = dt.Rows[0][erf.job_id].ToString();
                erf1.active = dt.Rows[0][erf.active].ToString();
                erf1.date_cancel = dt.Rows[0][erf.date_cancel].ToString();
                erf1.date_create = dt.Rows[0][erf.date_create].ToString();
                erf1.date_modi = dt.Rows[0][erf.date_modi].ToString();
                erf1.user_cancel = dt.Rows[0][erf.user_cancel].ToString();
                erf1.user_create = dt.Rows[0][erf.user_create].ToString();
                erf1.user_modi = dt.Rows[0][erf.user_modi].ToString();
                erf1.desc1 = dt.Rows[0][erf.desc1].ToString();
                erf1.remark = dt.Rows[0][erf.remark].ToString();
                erf1.amount = dt.Rows[0][erf.amount].ToString();
                erf1.status_page = dt.Rows[0][erf.status_page].ToString();
                erf1.status_appv = dt.Rows[0][erf.status_appv].ToString();
                erf1.status_doc = dt.Rows[0][erf.status_doc].ToString();
                erf1.expenses_refund_date = dt.Rows[0][erf.expenses_refund_date].ToString();
                erf1.ecc_doc = dt.Rows[0][erf.ecc_doc].ToString();
                erf1.job_code = dt.Rows[0][erf.job_code].ToString();
            }
            else
            {
                erf1.expenses_refund_id = "";
                erf1.expense_clear_cash_id = "";
                erf1.expenses_pay_detail_id = "";
                erf1.job_id = "";
                erf1.desc1 = "";
                erf1.amount = "";
                erf1.active = "";
                erf1.remark = "";
                erf1.date_create = "";
                erf1.date_modi = "";
                erf1.date_cancel = "";
                erf1.user_create = "";
                erf1.user_modi = "";
                erf1.user_cancel = "";
                erf1.status_page = "";
                erf1.status_appv = "";
                erf1.status_doc = "";
                erf1.expenses_refund_date = "";
                erf1.ecc_doc = "";
                erf1.job_code = "";
            }

            return erf1;
        }
    }
}
