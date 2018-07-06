using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xtrim_ERP.object1;

namespace Xtrim_ERP.objdb
{
    public class ReceiptDetailDB
    {
        public ReceiptDetail rcpD;
        ConnectDB conn;
        public List<ReceiptDetail> lexpn;
        public ReceiptDetailDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            rcpD = new ReceiptDetail();
            rcpD.receipt_detail_id = "receipt_detail_id";
            rcpD.receipt_id = "receipt_id";
            rcpD.item_id = "item_id";
            rcpD.job_id = "job_id";
            rcpD.job_code = "job_code";
            rcpD.amount = "amount";
            rcpD.active = "active";
            rcpD.remark = "remark";
            rcpD.date_create = "date_create";
            rcpD.date_modi = "date_modi";
            rcpD.date_cancel = "date_cancel";
            rcpD.user_create = "user_create";
            rcpD.user_modi = "user_modi";
            rcpD.user_cancel = "user_cancel";
            rcpD.item_name_t = "item_name_t";
            rcpD.qty = "qty";
            rcpD.price = "price";
            rcpD.billing_detail_id = "billing_detail_id";
            //rcpD.price = "price";

            rcpD.table = "t_receipt_detail";
            rcpD.pkField = "receipt_detail_id";

            lexpn = new List<ReceiptDetail>();
        }
        public String getIdByName(String name)
        {
            String id = "";
            foreach (ReceiptDetail utp1 in lexpn)
            {
                if (name.Trim().Equals(utp1.receipt_id))
                {
                    id = utp1.receipt_detail_id;
                    break;
                }
            }
            return id;
        }
        private void chkNull(ReceiptDetail p)
        {
            int chk = 0;
            Decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            p.item_id = p.item_id == null ? "" : p.item_id;
            p.item_name_t = p.item_name_t == null ? "" : p.item_name_t;
            p.job_code = p.job_code == null ? "" : p.job_code;
            p.remark = p.remark == null ? "" : p.remark;

            p.receipt_id = int.TryParse(p.receipt_id, out chk) ? chk.ToString() : "0";
            p.item_id = int.TryParse(p.item_id, out chk) ? chk.ToString() : "0";
            p.job_id = int.TryParse(p.job_id, out chk) ? chk.ToString() : "0";
            p.item_id = int.TryParse(p.item_id, out chk) ? chk.ToString() : "0";
            p.billing_detail_id = int.TryParse(p.billing_detail_id, out chk) ? chk.ToString() : "0";

            p.amount = Decimal.TryParse(p.amount, out chk1) ? chk1.ToString() : "0";
            p.qty = Decimal.TryParse(p.qty, out chk1) ? chk1.ToString() : "0";
            p.price = Decimal.TryParse(p.price, out chk1) ? chk1.ToString() : "0";
        }
        public String insert(ReceiptDetail p, String userId)
        {
            String re = "", sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            chkNull(p);
            sql = "Insert Into " + rcpD.table + "(" + rcpD.item_id + "," + rcpD.receipt_id + "," + rcpD.job_code + "," +
                rcpD.active + "," + rcpD.remark + ", " + rcpD.job_id + ", " +
                rcpD.date_create + ", " + rcpD.date_modi + ", " + rcpD.date_cancel + ", " +
                rcpD.user_create + ", " + rcpD.user_modi + ", " + rcpD.user_cancel + "," +
                rcpD.amount + "," + rcpD.item_name_t + "," + rcpD.item_name_t + "," +
                rcpD.qty + "," + rcpD.price + "," + rcpD.billing_detail_id + " " +
                ") " +
                "Values ('" + p.item_id + "','" + p.receipt_id + "','" + p.job_code + "'," +
                "'" + p.active + "','" + p.remark + "','" + p.job_id + "', " +
                "now(),'" + p.date_modi + "','" + p.date_cancel + "', " +
                "'" + userId + "','" + p.user_modi + "','" + p.user_cancel + "'," +
                "'" + p.amount + "','" + p.item_name_t + "','" + p.item_name_t + "', " +
                "'" + p.qty + "','" + p.price + "','" + p.billing_detail_id + "', " +
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
        public String update(ReceiptDetail p, String userId)
        {
            String re = "", sql = "";
            chkNull(p);
            sql = "Update " + rcpD.table + " Set " +
                " " + rcpD.item_id + "='" + p.item_id + "' " +
                "," + rcpD.job_code + "='" + p.job_code.Replace("'", "''") + "' " +
                "," + rcpD.receipt_id + "='" + p.receipt_id.Replace("'", "''") + "' " +
                "," + rcpD.remark + "='" + p.remark.Replace("'", "''") + "' " +
                "," + rcpD.date_modi + "=now() " +
                "," + rcpD.user_modi + "='" + userId.Replace("'", "''") + "' " +
                "," + rcpD.job_id + "='" + p.job_id.Replace("'", "''") + "' " +
                "," + rcpD.amount + "='" + p.amount.Replace("'", "''") + "' " +
                "," + rcpD.item_name_t + "='" + p.item_name_t.Replace("'", "''") + "' " +
                "," + rcpD.billing_detail_id + "='" + p.billing_detail_id.Replace("'", "''") + "' " +
                "," + rcpD.price + "='" + p.price.Replace("'", "''") + "' " +
                "," + rcpD.qty + "='" + p.qty.Replace("'", "''") + "' " +
                //"," + rcpD.item_name_t + "='" + p.item_name_t.Replace("'", "''") + "' " +
                "Where " + rcpD.pkField + "='" + p.receipt_detail_id + "'"
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
        public String insertReceiptDetail(ReceiptDetail p, String userId)
        {
            String re = "";

            if (p.receipt_detail_id.Equals(""))
            {
                re = insert(p, userId);
            }
            else
            {
                re = update(p, userId);
            }
            return re;
        }
        public String voidReceiptDetail(String id)
        {
            String re = "", sql = "";

            sql = "Update " + rcpD.table + " Set " +
                " " + rcpD.active + "='3' " +
                "," + rcpD.date_cancel + "=now() " +
                "Where " + rcpD.receipt_detail_id + "='" + id + "'"
                ;
            re = conn.ExecuteNonQuery(conn.conn, sql);

            return re;
        }
        public DataTable selectByCusId(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select bll.* " +
                "From " + rcpD.table + " bll " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where bll." + rcpD.item_name_t + " ='" + copId + "' and " + rcpD.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByJobId(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select bll.* " +
                "From " + rcpD.table + " bll " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where bll." + rcpD.job_id + " ='" + copId + "' and " + rcpD.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select bll.* " +
                "From " + rcpD.table + " bll " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where bll." + rcpD.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public ReceiptDetail selectByPk1(String copId)
        {
            ReceiptDetail cop1 = new ReceiptDetail();
            DataTable dt = new DataTable();
            String sql = "select bll.* " +
                "From " + rcpD.table + " bll " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where bll." + rcpD.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setReceiptDetail(dt);
            return cop1;
        }
        public ReceiptDetail setReceiptDetail(DataTable dt)
        {
            ReceiptDetail bll1 = new ReceiptDetail();
            if (dt.Rows.Count > 0)
            {
                bll1.receipt_detail_id = dt.Rows[0][rcpD.receipt_detail_id].ToString();
                bll1.receipt_id = dt.Rows[0][rcpD.receipt_id].ToString();
                bll1.item_id = dt.Rows[0][rcpD.item_id].ToString();
                bll1.job_id = dt.Rows[0][rcpD.job_id].ToString();
                bll1.active = dt.Rows[0][rcpD.active].ToString();
                bll1.date_cancel = dt.Rows[0][rcpD.date_cancel].ToString();
                bll1.date_create = dt.Rows[0][rcpD.date_create].ToString();
                bll1.date_modi = dt.Rows[0][rcpD.date_modi].ToString();
                bll1.user_cancel = dt.Rows[0][rcpD.user_cancel].ToString();
                bll1.user_create = dt.Rows[0][rcpD.user_create].ToString();
                bll1.user_modi = dt.Rows[0][rcpD.user_modi].ToString();
                bll1.job_code = dt.Rows[0][rcpD.job_code].ToString();
                bll1.remark = dt.Rows[0][rcpD.remark].ToString();
                bll1.amount = dt.Rows[0][rcpD.amount].ToString();
                bll1.item_name_t = dt.Rows[0][rcpD.item_name_t].ToString();
                bll1.qty = dt.Rows[0][rcpD.qty].ToString();
                bll1.price = dt.Rows[0][rcpD.price].ToString();
                bll1.billing_detail_id = dt.Rows[0][rcpD.billing_detail_id].ToString();
            }
            else
            {
                bll1.receipt_detail_id = "";
                bll1.receipt_id = "";
                bll1.item_id = "";
                bll1.job_id = "";
                bll1.job_code = "";
                bll1.amount = "";
                bll1.active = "";
                bll1.remark = "";
                bll1.date_create = "";
                bll1.date_modi = "";
                bll1.date_cancel = "";
                bll1.user_create = "";
                bll1.user_modi = "";
                bll1.user_cancel = "";
                bll1.item_name_t = "";
                bll1.qty = "";
                bll1.price = "";
                bll1.billing_detail_id = "";
            }

            return bll1;
        }
    }
}
