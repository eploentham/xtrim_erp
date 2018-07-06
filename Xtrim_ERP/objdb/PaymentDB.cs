using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xtrim_ERP.object1;

namespace Xtrim_ERP.objdb
{
    public class PaymentDB
    {
        public Payment pyt;
        ConnectDB conn;
        public List<Payment> lexpn;
        public PaymentDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            pyt = new Payment();
            pyt.payment_id = "payment_id";
            pyt.payment_code = "payment_code";
            pyt.payment_date = "payment_date";
            pyt.job_id = "job_id";
            pyt.job_code = "job_code";
            pyt.amount = "amount";
            pyt.active = "active";
            pyt.remark = "remark";
            pyt.date_create = "date_create";
            pyt.date_modi = "date_modi";
            pyt.date_cancel = "date_cancel";
            pyt.user_create = "user_create";
            pyt.user_modi = "user_modi";
            pyt.user_cancel = "user_cancel";
            pyt.status_pay_type = "status_pay_type";
            pyt.cust_id = "cust_id";

            pyt.table = "t_payment";
            pyt.pkField = "payment_id";

            lexpn = new List<Payment>();
        }
        public String getIdByName(String name)
        {
            String id = "";
            foreach (Payment utp1 in lexpn)
            {
                if (name.Trim().Equals(utp1.payment_code))
                {
                    id = utp1.payment_id;
                    break;
                }
            }
            return id;
        }
        private void chkNull(Payment p)
        {
            int chk = 0;
            Decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            p.payment_date = p.payment_date == null ? "" : p.payment_date;
            p.payment_code = p.payment_code == null ? "" : p.payment_code;
            p.job_code = p.job_code == null ? "" : p.job_code;
            p.remark = p.remark == null ? "" : p.remark;
            p.status_pay_type = p.status_pay_type == null ? "0" : p.status_pay_type;
            //p.status_pay_type = p.status_pay_type == null ? "0" : p.status_pay_type;

            p.cust_id = int.TryParse(p.cust_id, out chk) ? chk.ToString() : "0";
            p.job_id = int.TryParse(p.job_id, out chk) ? chk.ToString() : "0";
            p.amount = Decimal.TryParse(p.amount, out chk1) ? chk1.ToString() : "0";
        }
        public String insert(Payment p, String userId)
        {
            String re = "", sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            chkNull(p);
            sql = "Insert Into " + pyt.table + "(" + pyt.payment_date + "," + pyt.payment_code + "," + pyt.job_code + "," +
                pyt.active + "," + pyt.remark + ", " + pyt.job_id + ", " +
                pyt.date_create + ", " + pyt.date_modi + ", " + pyt.date_cancel + ", " +
                pyt.user_create + ", " + pyt.user_modi + ", " + pyt.user_cancel + "," +
                pyt.amount + "," + pyt.status_pay_type + "," + pyt.cust_id + " " +
                ") " +
                "Values ('" + p.payment_date + "','" + p.payment_code + "','" + p.job_code + "'," +
                "'" + p.active + "','" + p.remark + "','" + p.job_id + "', " +
                "now(),'" + p.date_modi + "','" + p.date_cancel + "', " +
                "'" + userId + "','" + p.user_modi + "','" + p.user_cancel + "'," +
                "'" + p.amount + "','" + p.amount + "','" + p.cust_id + "' " +
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
        public String update(Payment p, String userId)
        {
            String re = "", sql = "";
            chkNull(p);
            sql = "Update " + pyt.table + " Set " +
                " " + pyt.payment_date + "='" + p.payment_date + "' " +
                "," + pyt.job_code + "='" + p.job_code.Replace("'", "''") + "' " +
                "," + pyt.payment_code + "='" + p.payment_code.Replace("'", "''") + "' " +
                "," + pyt.remark + "='" + p.remark.Replace("'", "''") + "' " +
                "," + pyt.date_modi + "=now() " +
                "," + pyt.user_modi + "='" + userId.Replace("'", "''") + "' " +
                "," + pyt.job_id + "='" + p.job_id.Replace("'", "''") + "' " +
                "," + pyt.amount + "='" + p.amount.Replace("'", "''") + "' " +
                "," + pyt.status_pay_type + "='" + p.status_pay_type.Replace("'", "''") + "' " +
                "," + pyt.cust_id + "='" + p.cust_id.Replace("'", "''") + "' " +
                "Where " + pyt.pkField + "='" + p.payment_id + "'"
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
        public String insertPayment(Payment p, String userId)
        {
            String re = "";

            if (p.payment_id.Equals(""))
            {
                re = insert(p, userId);
            }
            else
            {
                re = update(p, userId);
            }
            return re;
        }
        public String voidPayment(String id)
        {
            String re = "", sql = "";

            sql = "Update " + pyt.table + " Set " +
                " " + pyt.active + "='3' " +
                "," + pyt.date_cancel + "=now() " +
                "Where " + pyt.payment_id + "='" + id + "'"
                ;
            re = conn.ExecuteNonQuery(conn.conn, sql);

            return re;
        }
        public DataTable selectByJobId(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select bll.* " +
                "From " + pyt.table + " bll " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where bll." + pyt.job_id + " ='" + copId + "' and " + pyt.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select bll.* " +
                "From " + pyt.table + " bll " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where bll." + pyt.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public Payment selectByPk1(String copId)
        {
            Payment cop1 = new Payment();
            DataTable dt = new DataTable();
            String sql = "select bll.* " +
                "From " + pyt.table + " bll " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where bll." + pyt.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setPayment(dt);
            return cop1;
        }
        public Payment setPayment(DataTable dt)
        {
            Payment pyt1 = new Payment();
            if (dt.Rows.Count > 0)
            {
                pyt1.payment_id = dt.Rows[0][this.pyt.payment_id].ToString();
                pyt1.payment_code = dt.Rows[0][this.pyt.payment_code].ToString();
                pyt1.payment_date = dt.Rows[0][this.pyt.payment_date].ToString();
                pyt1.job_id = dt.Rows[0][this.pyt.job_id].ToString();
                pyt1.active = dt.Rows[0][this.pyt.active].ToString();
                pyt1.date_cancel = dt.Rows[0][this.pyt.date_cancel].ToString();
                pyt1.date_create = dt.Rows[0][this.pyt.date_create].ToString();
                pyt1.date_modi = dt.Rows[0][this.pyt.date_modi].ToString();
                pyt1.user_cancel = dt.Rows[0][this.pyt.user_cancel].ToString();
                pyt1.user_create = dt.Rows[0][this.pyt.user_create].ToString();
                pyt1.user_modi = dt.Rows[0][this.pyt.user_modi].ToString();
                pyt1.job_code = dt.Rows[0][this.pyt.job_code].ToString();
                pyt1.remark = dt.Rows[0][this.pyt.remark].ToString();
                pyt1.amount = dt.Rows[0][this.pyt.amount].ToString();
                pyt1.cust_id = dt.Rows[0][this.pyt.cust_id].ToString();
            }
            else
            {
                pyt.payment_id = "";
                pyt.payment_code = "";
                pyt.payment_date = "";
                pyt.job_id = "";
                pyt.job_code = "";
                pyt.amount = "";
                pyt.active = "";
                pyt.remark = "";
                pyt.date_create = "";
                pyt.date_modi = "";
                pyt.date_cancel = "";
                pyt.user_create = "";
                pyt.user_modi = "";
                pyt.user_cancel = "";
                pyt.status_pay_type = "";
                pyt.cust_id = "";
            }

            return pyt;
        }
    }
}
