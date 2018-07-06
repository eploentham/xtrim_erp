using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xtrim_ERP.object1;

namespace Xtrim_ERP.objdb
{
    public class ReceiptDB
    {
        public Receipt rcp;
        ConnectDB conn;
        public List<Receipt> lexpn;
        public ReceiptDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            rcp = new Receipt();
            rcp.receipt_id = "receipt_id";
            rcp.receipt_code = "receipt_code";
            rcp.receipt_date = "receipt_date";
            rcp.job_id = "job_id";
            rcp.job_code = "job_code";
            rcp.billing_id = "billing_id";
            rcp.active = "active";
            rcp.remark = "remark";
            rcp.date_create = "date_create";
            rcp.date_modi = "date_modi";
            rcp.date_cancel = "date_cancel";
            rcp.user_create = "user_create";
            rcp.user_modi = "user_modi";
            rcp.user_cancel = "user_cancel";
            rcp.payment_id = "payment_id";
            rcp.payment_detail_id = "payment_detail_id";

            rcp.table = "t_receipt";
            rcp.pkField = "receipt_id";

            lexpn = new List<Receipt>();
        }
        public String getIdByName(String name)
        {
            String id = "";
            foreach (Receipt utp1 in lexpn)
            {
                if (name.Trim().Equals(utp1.receipt_code))
                {
                    id = utp1.receipt_id;
                    break;
                }
            }
            return id;
        }
        private void chkNull(Receipt p)
        {
            int chk = 0;
            Decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            p.receipt_date = p.receipt_date == null ? "" : p.receipt_date;
            p.receipt_code = p.receipt_code == null ? "" : p.receipt_code;
            p.job_code = p.job_code == null ? "" : p.job_code;
            p.remark = p.remark == null ? "" : p.remark;

            p.payment_id = int.TryParse(p.payment_id, out chk) ? chk.ToString() : "0";
            p.job_id = int.TryParse(p.job_id, out chk) ? chk.ToString() : "0";
            p.billing_id = int.TryParse(p.billing_id, out chk) ? chk.ToString() : "0";
            p.payment_detail_id = int.TryParse(p.payment_detail_id, out chk) ? chk.ToString() : "0";
        }
        public String insert(Receipt p, String userId)
        {
            String re = "", sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            chkNull(p);
            sql = "Insert Into " + rcp.table + "(" + rcp.receipt_date + "," + rcp.receipt_code + "," + rcp.job_code + "," +
                rcp.active + "," + rcp.remark + ", " + rcp.job_id + ", " +
                rcp.date_create + ", " + rcp.date_modi + ", " + rcp.date_cancel + ", " +
                rcp.user_create + ", " + rcp.user_modi + ", " + rcp.user_cancel + "," +
                rcp.billing_id + "," + rcp.payment_id + "," + rcp.payment_detail_id + " " +
                ") " +
                "Values ('" + p.receipt_date + "','" + p.receipt_code + "','" + p.job_code + "'," +
                "'" + p.active + "','" + p.remark + "','" + p.job_id + "', " +
                "now(),'" + p.date_modi + "','" + p.date_cancel + "', " +
                "'" + userId + "','" + p.user_modi + "','" + p.user_cancel + "'," +
                "'" + p.billing_id + "','" + p.payment_id + "','" + p.payment_detail_id + "' " +
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
        public String update(Receipt p, String userId)
        {
            String re = "", sql = "";
            chkNull(p);
            sql = "Update " + rcp.table + " Set " +
                " " + rcp.receipt_date + "='" + p.receipt_date + "' " +
                "," + rcp.job_code + "='" + p.job_code.Replace("'", "''") + "' " +
                "," + rcp.receipt_code + "='" + p.receipt_code.Replace("'", "''") + "' " +
                "," + rcp.remark + "='" + p.remark.Replace("'", "''") + "' " +
                "," + rcp.date_modi + "=now() " +
                "," + rcp.user_modi + "='" + userId.Replace("'", "''") + "' " +
                "," + rcp.job_id + "='" + p.job_id.Replace("'", "''") + "' " +
                "," + rcp.billing_id + "='" + p.billing_id.Replace("'", "''") + "' " +
                "," + rcp.payment_id + "='" + p.payment_id.Replace("'", "''") + "' " +
                "," + rcp.payment_detail_id + "='" + p.payment_detail_id.Replace("'", "''") + "' " +
                "Where " + rcp.pkField + "='" + p.receipt_id + "'"
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
        public String insertReceipt(Receipt p, String userId)
        {
            String re = "";

            if (p.receipt_id.Equals(""))
            {
                re = insert(p, userId);
            }
            else
            {
                re = update(p, userId);
            }
            return re;
        }
        public String voidBilling(String id)
        {
            String re = "", sql = "";

            sql = "Update " + rcp.table + " Set " +
                " " + rcp.active + "='3' " +
                "," + rcp.date_cancel + "=now() " +
                "Where " + rcp.receipt_id + "='" + id + "'"
                ;
            re = conn.ExecuteNonQuery(conn.conn, sql);

            return re;
        }
        public DataTable selectByCusId(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select bll.* " +
                "From " + rcp.table + " bll " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where bll." + rcp.job_id + " ='" + copId + "' and " + rcp.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByJobId(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select bll.* " +
                "From " + rcp.table + " bll " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where bll." + rcp.job_id + " ='" + copId + "' and " + rcp.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select bll.* " +
                "From " + rcp.table + " bll " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where bll." + rcp.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public Receipt selectByPk1(String copId)
        {
            Receipt cop1 = new Receipt();
            DataTable dt = new DataTable();
            String sql = "select bll.* " +
                "From " + rcp.table + " bll " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where bll." + rcp.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setReceipt(dt);
            return cop1;
        }
        public Receipt setReceipt(DataTable dt)
        {
            Receipt bll1 = new Receipt();
            if (dt.Rows.Count > 0)
            {
                bll1.receipt_id = dt.Rows[0][rcp.receipt_id].ToString();
                bll1.receipt_code = dt.Rows[0][rcp.receipt_code].ToString();
                bll1.receipt_date = dt.Rows[0][rcp.receipt_date].ToString();
                bll1.job_id = dt.Rows[0][rcp.job_id].ToString();
                bll1.active = dt.Rows[0][rcp.active].ToString();
                bll1.date_cancel = dt.Rows[0][rcp.date_cancel].ToString();
                bll1.date_create = dt.Rows[0][rcp.date_create].ToString();
                bll1.date_modi = dt.Rows[0][rcp.date_modi].ToString();
                bll1.user_cancel = dt.Rows[0][rcp.user_cancel].ToString();
                bll1.user_create = dt.Rows[0][rcp.user_create].ToString();
                bll1.user_modi = dt.Rows[0][rcp.user_modi].ToString();
                bll1.job_code = dt.Rows[0][rcp.job_code].ToString();
                bll1.remark = dt.Rows[0][rcp.remark].ToString();
                bll1.billing_id = dt.Rows[0][rcp.billing_id].ToString();
                bll1.payment_id = dt.Rows[0][rcp.payment_id].ToString();
                bll1.payment_detail_id = dt.Rows[0][rcp.payment_detail_id].ToString();
            }
            else
            {
                bll1.receipt_id = "";
                bll1.receipt_code = "";
                bll1.receipt_date = "";
                bll1.job_id = "";
                bll1.job_code = "";
                bll1.billing_id = "";
                bll1.active = "";
                bll1.remark = "";
                bll1.date_create = "";
                bll1.date_modi = "";
                bll1.date_cancel = "";
                bll1.user_create = "";
                bll1.user_modi = "";
                bll1.user_cancel = "";
                bll1.payment_id = "";
                bll1.payment_detail_id = "";
            }

            return bll1;
        }
    }
}
