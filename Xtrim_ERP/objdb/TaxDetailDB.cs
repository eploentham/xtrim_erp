using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xtrim_ERP.object1;

namespace Xtrim_ERP.objdb
{
    public class TaxDetailDB
    {
        public TaxDetail taxD;
        ConnectDB conn;
        public List<TaxDetail> lexpn;
        public TaxDetailDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            taxD = new TaxDetail();
            taxD.tax_detail_id = "tax_detail_id";
            taxD.tax_id = "tax_id";
            taxD.item_id = "item_id";
            taxD.b_tax_id = "b_tax_id";
            taxD.b_tax_name_t = "b_tax_name_t";
            taxD.amount = "amount";
            taxD.active = "active";
            taxD.remark = "remark";
            taxD.date_create = "date_create";
            taxD.date_modi = "date_modi";
            taxD.date_cancel = "date_cancel";
            taxD.user_create = "user_create";
            taxD.user_modi = "user_modi";
            taxD.user_cancel = "user_cancel";
            taxD.item_name_t = "item_name_t";
            taxD.rate1 = "rate1";
            taxD.tax_date = "tax_date";
            //taxD.amount = "amount";
            taxD.tax_amount = "tax_amount";

            taxD.table = "t_billing";
            taxD.pkField = "tax_detail_id";

            lexpn = new List<TaxDetail>();
        }
        public String getIdByName(String name)
        {
            String id = "";
            foreach (TaxDetail utp1 in lexpn)
            {
                if (name.Trim().Equals(utp1.tax_id))
                {
                    id = utp1.tax_detail_id;
                    break;
                }
            }
            return id;
        }
        private void chkNull(TaxDetail p)
        {
            int chk = 0;
            Decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            //p.item_id = p.item_id == null ? "" : p.item_id;
            //p.tax_id = p.tax_id == null ? "" : p.tax_id;
            p.b_tax_name_t = p.b_tax_name_t == null ? "" : p.b_tax_name_t;
            p.remark = p.remark == null ? "" : p.remark;
            p.item_name_t = p.item_name_t == null ? "" : p.item_name_t;
            p.tax_date = p.tax_date == null ? "" : p.tax_date;
            //p.item_name_t = p.item_name_t == null ? "" : p.item_name_t;

            p.item_id = int.TryParse(p.item_id, out chk) ? chk.ToString() : "0";
            p.b_tax_id = int.TryParse(p.b_tax_id, out chk) ? chk.ToString() : "0";
            p.tax_id = int.TryParse(p.tax_id, out chk) ? chk.ToString() : "0";

            //p.amount = Decimal.TryParse(p.amount, out chk1) ? chk1.ToString() : "0";
            p.amount = Decimal.TryParse(p.amount, out chk1) ? chk1.ToString() : "0";
            p.rate1 = Decimal.TryParse(p.rate1, out chk1) ? chk1.ToString() : "0";
            p.tax_amount = Decimal.TryParse(p.tax_amount, out chk1) ? chk1.ToString() : "0";
        }
        public String insert(TaxDetail p, String userId)
        {
            String re = "", sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            chkNull(p);
            sql = "Insert Into " + taxD.table + "(" + taxD.item_id + "," + taxD.tax_id + "," + taxD.b_tax_name_t + "," +
                taxD.active + "," + taxD.remark + ", " + taxD.b_tax_id + ", " +
                taxD.date_create + ", " + taxD.date_modi + ", " + taxD.date_cancel + ", " +
                taxD.user_create + ", " + taxD.user_modi + ", " + taxD.user_cancel + "," +
                taxD.amount + "," + taxD.item_name_t + "," + taxD.rate1 + "," +
                taxD.amount + "," + taxD.tax_date + "," + taxD.tax_amount + " " +
                ") " +
                "Values ('" + p.item_id + "','" + p.tax_id + "','" + p.b_tax_name_t + "'," +
                "'" + p.active + "','" + p.remark + "','" + p.b_tax_id + "', " +
                "now(),'" + p.date_modi + "','" + p.date_cancel + "', " +
                "'" + userId + "','" + p.user_modi + "','" + p.user_cancel + "'," +
                "'" + p.amount + "','" + p.item_name_t + "','" + p.rate1 + "'," +
                "'" + p.amount + "','" + p.tax_date + "','" + p.tax_amount + "' " +
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
        public String update(TaxDetail p, String userId)
        {
            String re = "", sql = "";
            chkNull(p);
            sql = "Update " + taxD.table + " Set " +
                " " + taxD.item_id + "='" + p.item_id + "' " +
                "," + taxD.b_tax_name_t + "='" + p.b_tax_name_t.Replace("'", "''") + "' " +
                "," + taxD.tax_id + "='" + p.tax_id.Replace("'", "''") + "' " +
                "," + taxD.remark + "='" + p.remark.Replace("'", "''") + "' " +
                "," + taxD.date_modi + "=now() " +
                "," + taxD.user_modi + "='" + userId.Replace("'", "''") + "' " +
                "," + taxD.b_tax_id + "='" + p.b_tax_id.Replace("'", "''") + "' " +
                "," + taxD.amount + "='" + p.amount.Replace("'", "''") + "' " +
                "," + taxD.item_name_t + "='" + p.item_name_t.Replace("'", "''") + "' " +
                //"," + taxD.billing_cover_id + "='" + p.billing_cover_id.Replace("'", "''") + "' " +
                "Where " + taxD.pkField + "='" + p.tax_detail_id + "'"
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
        public String insertTaxDetail(TaxDetail p, String userId)
        {
            String re = "";

            if (p.tax_detail_id.Equals(""))
            {
                re = insert(p, userId);
            }
            else
            {
                re = update(p, userId);
            }
            return re;
        }
        public String voidTaxDetail(String id)
        {
            String re = "", sql = "";
            sql = "Update " + taxD.table + " Set " +
                " " + taxD.active + "='3' " +
                "," + taxD.date_cancel + "=now() " +
                "Where " + taxD.tax_detail_id + "='" + id + "'";
            re = conn.ExecuteNonQuery(conn.conn, sql);

            return re;
        }
        //public String updateBillingCover(String id, String coverid)
        //{
        //    String re = "", sql = "";
        //    sql = "Update " + taxD.table + " Set " +
        //        " " + taxD.billing_cover_id + "='" + coverid + "' " +
        //        "Where " + taxD.tax_detail_id + "='" + id + "'";
        //    re = conn.ExecuteNonQuery(conn.conn, sql);

        //    return re;
        //}
        public DataTable selectByCusId(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select bll.* " +
                "From " + taxD.table + " bll " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where bll." + taxD.item_name_t + " ='" + copId + "' and " + taxD.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByJobId(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select bll.* " +
                "From " + taxD.table + " bll " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where bll." + taxD.b_tax_id + " ='" + copId + "' and " + taxD.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select bll.* " +
                "From " + taxD.table + " bll " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where bll." + taxD.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public TaxDetail selectByPk1(String copId)
        {
            TaxDetail cop1 = new TaxDetail();
            DataTable dt = new DataTable();
            String sql = "select bll.* " +
                "From " + taxD.table + " bll " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where bll." + taxD.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setTaxDetail(dt);
            return cop1;
        }
        public TaxDetail setTaxDetail(DataTable dt)
        {
            TaxDetail bll1 = new TaxDetail();
            if (dt.Rows.Count > 0)
            {
                bll1.tax_detail_id = dt.Rows[0][taxD.tax_detail_id].ToString();
                bll1.tax_id = dt.Rows[0][taxD.tax_id].ToString();
                bll1.item_id = dt.Rows[0][taxD.item_id].ToString();
                bll1.b_tax_id = dt.Rows[0][taxD.b_tax_id].ToString();
                bll1.active = dt.Rows[0][taxD.active].ToString();
                bll1.date_cancel = dt.Rows[0][taxD.date_cancel].ToString();
                bll1.date_create = dt.Rows[0][taxD.date_create].ToString();
                bll1.date_modi = dt.Rows[0][taxD.date_modi].ToString();
                bll1.user_cancel = dt.Rows[0][taxD.user_cancel].ToString();
                bll1.user_create = dt.Rows[0][taxD.user_create].ToString();
                bll1.user_modi = dt.Rows[0][taxD.user_modi].ToString();
                bll1.b_tax_name_t = dt.Rows[0][taxD.b_tax_name_t].ToString();
                bll1.remark = dt.Rows[0][taxD.remark].ToString();
                bll1.amount = dt.Rows[0][taxD.amount].ToString();
                bll1.item_name_t = dt.Rows[0][taxD.item_name_t].ToString();
                bll1.rate1 = dt.Rows[0][taxD.rate1].ToString();
                bll1.tax_date = dt.Rows[0][taxD.tax_date].ToString();
            }
            else
            {
                bll1.tax_detail_id = "";
                bll1.tax_id = "";
                bll1.item_id = "";
                bll1.b_tax_id = "";
                bll1.b_tax_name_t = "";
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
                bll1.rate1 = "";
                bll1.tax_date = "";
            }

            return bll1;
        }
    }
}
