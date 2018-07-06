using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xtrim_ERP.object1;

namespace Xtrim_ERP.objdb
{
    public class PaymentDetailDB
    {
        public PaymentDetail pytd;
        ConnectDB conn;
        public List<PaymentDetail> lexpn;
        public PaymentDetailDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            pytd = new PaymentDetail();
            pytd.payment_detail_id = "payment_detail_id";
            pytd.payment_id = "payment_id";
            pytd.billing_id = "billing_id";
            pytd.job_id = "job_id";
            pytd.job_code = "job_code";
            pytd.amount = "amount";
            pytd.active = "active";
            pytd.remark = "remark";
            pytd.date_create = "date_create";
            pytd.date_modi = "date_modi";
            pytd.date_cancel = "date_cancel";
            pytd.user_create = "user_create";
            pytd.user_modi = "user_modi";
            pytd.user_cancel = "user_cancel";
            pytd.billing_detail_id = "billing_detail_id";

            pytd.table = "t_payment_detail";
            pytd.pkField = "payment_detail_id";

            lexpn = new List<PaymentDetail>();
        }
        public String getIdByName(String name)
        {
            String id = "";
            foreach (PaymentDetail utp1 in lexpn)
            {
                if (name.Trim().Equals(utp1.payment_detail_id))
                {
                    id = utp1.payment_detail_id;
                    break;
                }
            }
            return id;
        }
        private void chkNull(PaymentDetail p)
        {
            int chk = 0;
            Decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            //p.billing_id = p.billing_id == null ? "" : p.billing_id;
            p.payment_detail_id = p.payment_detail_id == null ? "" : p.payment_detail_id;
            p.job_code = p.job_code == null ? "" : p.job_code;
            p.remark = p.remark == null ? "" : p.remark;
            //p.status_pay_type = p.status_pay_type == null ? "0" : p.status_pay_type;
            //p.status_pay_type = p.status_pay_type == null ? "0" : p.status_pay_type;

            p.billing_detail_id = int.TryParse(p.billing_detail_id, out chk) ? chk.ToString() : "0";
            p.billing_id = int.TryParse(p.billing_id, out chk) ? chk.ToString() : "0";
            p.payment_id = int.TryParse(p.payment_id, out chk) ? chk.ToString() : "0";
            p.job_id = int.TryParse(p.job_id, out chk) ? chk.ToString() : "0";
            p.amount = Decimal.TryParse(p.amount, out chk1) ? chk1.ToString() : "0";
        }
        public String insert(PaymentDetail p, String userId)
        {
            String re = "", sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            chkNull(p);
            sql = "Insert Into " + pytd.table + "(" + pytd.billing_id + "," + pytd.payment_id + "," + pytd.job_code + "," +
                pytd.active + "," + pytd.remark + ", " + pytd.job_id + ", " +
                pytd.date_create + ", " + pytd.date_modi + ", " + pytd.date_cancel + ", " +
                pytd.user_create + ", " + pytd.user_modi + ", " + pytd.user_cancel + "," +
                pytd.amount + "," + pytd.billing_detail_id + " " +
                ") " +
                "Values ('" + p.billing_id + "','" + p.payment_id + "','" + p.job_code + "'," +
                "'" + p.active + "','" + p.remark + "','" + p.job_id + "', " +
                "now(),'" + p.date_modi + "','" + p.date_cancel + "', " +
                "'" + userId + "','" + p.user_modi + "','" + p.user_cancel + "'," +
                "'" + p.amount + "','" + p.billing_detail_id + "' " +
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
        public String update(PaymentDetail p, String userId)
        {
            String re = "", sql = "";
            chkNull(p);
            sql = "Update " + pytd.table + " Set " +
                " " + pytd.billing_id + "='" + p.billing_id + "' " +
                "," + pytd.job_code + "='" + p.job_code.Replace("'", "''") + "' " +
                "," + pytd.payment_id + "='" + p.payment_id.Replace("'", "''") + "' " +
                "," + pytd.remark + "='" + p.remark.Replace("'", "''") + "' " +
                "," + pytd.date_modi + "=now() " +
                "," + pytd.user_modi + "='" + userId.Replace("'", "''") + "' " +
                "," + pytd.job_id + "='" + p.job_id.Replace("'", "''") + "' " +
                "," + pytd.amount + "='" + p.amount.Replace("'", "''") + "' " +
                "," + pytd.billing_detail_id + "='" + p.billing_detail_id.Replace("'", "''") + "' " +
                "Where " + pytd.pkField + "='" + p.payment_detail_id + "'"
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
        public String insertPaymentDetail(PaymentDetail p, String userId)
        {
            String re = "";

            if (p.payment_detail_id.Equals(""))
            {
                re = insert(p, userId);
            }
            else
            {
                re = update(p, userId);
            }
            return re;
        }
        public String voidPaymentDetail(String id)
        {
            String re = "", sql = "";

            sql = "Update " + pytd.table + " Set " +
                " " + pytd.active + "='3' " +
                "," + pytd.date_cancel + "=now() " +
                "Where " + pytd.payment_detail_id + "='" + id + "'"
                ;
            re = conn.ExecuteNonQuery(conn.conn, sql);

            return re;
        }
        public DataTable selectByJobId(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select bll.* " +
                "From " + pytd.table + " bll " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where bll." + pytd.job_id + " ='" + copId + "' and " + pytd.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select bll.* " +
                "From " + pytd.table + " bll " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where bll." + pytd.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public PaymentDetail selectByPk1(String copId)
        {
            PaymentDetail cop1 = new PaymentDetail();
            DataTable dt = new DataTable();
            String sql = "select bll.* " +
                "From " + pytd.table + " bll " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where bll." + pytd.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setPaymentDetail(dt);
            return cop1;
        }
        public PaymentDetail setPaymentDetail(DataTable dt)
        {
            PaymentDetail pytd1 = new PaymentDetail();
            if (dt.Rows.Count > 0)
            {
                pytd1.payment_detail_id = dt.Rows[0][this.pytd.payment_detail_id].ToString();
                pytd1.payment_id = dt.Rows[0][this.pytd.payment_id].ToString();
                pytd1.billing_id = dt.Rows[0][this.pytd.billing_id].ToString();
                pytd1.job_id = dt.Rows[0][this.pytd.job_id].ToString();
                pytd1.active = dt.Rows[0][this.pytd.active].ToString();
                pytd1.date_cancel = dt.Rows[0][this.pytd.date_cancel].ToString();
                pytd1.date_create = dt.Rows[0][this.pytd.date_create].ToString();
                pytd1.date_modi = dt.Rows[0][this.pytd.date_modi].ToString();
                pytd1.user_cancel = dt.Rows[0][this.pytd.user_cancel].ToString();
                pytd1.user_create = dt.Rows[0][this.pytd.user_create].ToString();
                pytd1.user_modi = dt.Rows[0][this.pytd.user_modi].ToString();
                pytd1.job_code = dt.Rows[0][this.pytd.job_code].ToString();
                pytd1.remark = dt.Rows[0][this.pytd.remark].ToString();
                pytd1.amount = dt.Rows[0][this.pytd.amount].ToString();
                pytd1.billing_detail_id = dt.Rows[0][this.pytd.billing_detail_id].ToString();
            }
            else
            {
                pytd1.payment_detail_id = "";
                pytd1.payment_id = "";
                pytd1.billing_id = "";
                pytd1.job_id = "";
                pytd1.job_code = "";
                pytd1.amount = "";
                pytd1.active = "";
                pytd1.remark = "";
                pytd1.date_create = "";
                pytd1.date_modi = "";
                pytd1.date_cancel = "";
                pytd1.user_create = "";
                pytd1.user_modi = "";
                pytd1.user_cancel = "";
                pytd1.billing_detail_id = "";
            }

            return pytd;
        }
    }
}
