using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xtrim_ERP.object1;

namespace Xtrim_ERP.objdb
{
    public class BillingDetailDB
    {
        public BillingDetail blld;
        ConnectDB conn;
        public List<BillingDetail> lexpn;
        public BillingDetailDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            blld = new BillingDetail();
            blld.billing_id = "billing_id";
            blld.billing_detail_id = "billing_detail_id";
            blld.expenses_draw_detail_id = "expenses_draw_detail_id";
            blld.item_id = "item_id";
            blld.item_name_t = "item_name_t";
            blld.amount_draw = "amount_draw";
            blld.active = "active";
            blld.remark = "remark";
            blld.date_create = "date_create";
            blld.date_modi = "date_modi";
            blld.date_cancel = "date_cancel";
            blld.user_create = "user_create";
            blld.user_modi = "user_modi";
            blld.user_cancel = "user_cancel";
            blld.amount_income = "amount_income";

            blld.table = "t_billing";
            blld.pkField = "billing_id";

            lexpn = new List<BillingDetail>();
        }
        public String getIdByName(String name)
        {
            String id = "";
            foreach (BillingDetail utp1 in lexpn)
            {
                if (name.Trim().Equals(utp1.billing_detail_id))
                {
                    id = utp1.billing_detail_id;
                    break;
                }
            }
            return id;
        }
        private void chkNull(BillingDetail p)
        {
            int chk = 0;
            Decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            p.expenses_draw_detail_id = p.expenses_draw_detail_id == null ? "" : p.expenses_draw_detail_id;
            //p.billing_detail_id = p.billing_detail_id == null ? "" : p.billing_detail_id;
            p.item_name_t = p.item_name_t == null ? "" : p.item_name_t;
            p.remark = p.remark == null ? "" : p.remark;
            //p.item_name_t = p.item_name_t == null ? "" : p.item_name_t;
            //p.remark = p.remark == null ? "" : p.remark;

            p.item_id = int.TryParse(p.item_id, out chk) ? chk.ToString() : "0";
            p.expenses_draw_detail_id = int.TryParse(p.expenses_draw_detail_id, out chk) ? chk.ToString() : "0";
            p.billing_id = int.TryParse(p.billing_id, out chk) ? chk.ToString() : "0";
            p.item_id = int.TryParse(p.item_id, out chk) ? chk.ToString() : "0";

            p.amount_draw = Decimal.TryParse(p.amount_draw, out chk1) ? chk1.ToString() : "0";
            p.amount_income = Decimal.TryParse(p.amount_income, out chk1) ? chk1.ToString() : "0";
        }
        public String insert(BillingDetail p, String userId)
        {
            String re = "", sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            chkNull(p);
            sql = "Insert Into " + blld.table + "(" + blld.expenses_draw_detail_id + "," + blld.billing_id + "," + blld.item_name_t + "," +
                blld.active + "," + blld.remark + ", " + blld.item_id + ", " +
                blld.date_create + ", " + blld.date_modi + ", " + blld.date_cancel + ", " +
                blld.user_create + ", " + blld.user_modi + ", " + blld.user_cancel + "," +
                blld.amount_draw + "," + blld.amount_income + " " +
                ") " +
                "Values ('" + p.expenses_draw_detail_id + "','" + p.billing_id + "','" + p.item_name_t.Replace("'","''") + "'," +
                "'" + p.active + "','" + p.remark + "','" + p.item_id + "', " +
                "now(),'" + p.date_modi + "','" + p.date_cancel + "', " +
                "'" + userId + "','" + p.user_modi + "','" + p.user_cancel + "'," +
                "'" + p.amount_draw + "','" + p.amount_income + "' " +
                ")";
            re = conn.ExecuteNonQuery(conn.conn, sql);

            return re;
        }
        public String update(BillingDetail p, String userId)
        {
            String re = "", sql = "";
            chkNull(p);
            sql = "Update " + blld.table + " Set " +
                " " + blld.expenses_draw_detail_id + "='" + p.expenses_draw_detail_id + "' " +
                "," + blld.item_name_t + "='" + p.item_name_t.Replace("'", "''") + "' " +
                "," + blld.billing_id + "='" + p.billing_id.Replace("'", "''") + "' " +
                "," + blld.remark + "='" + p.remark.Replace("'", "''") + "' " +
                "," + blld.date_modi + "=now() " +
                "," + blld.user_modi + "='" + userId.Replace("'", "''") + "' " +
                "," + blld.item_id + "='" + p.item_id.Replace("'", "''") + "' " +
                "," + blld.amount_draw + "='" + p.amount_draw.Replace("'", "''") + "' " +
                "," + blld.amount_income + "='" + p.amount_income.Replace("'", "''") + "' " +
                "Where " + blld.pkField + "='" + p.billing_detail_id + "'"
                ;
            re = conn.ExecuteNonQuery(conn.conn, sql);

            return re;
        }
        public String insertBillingDetail(BillingDetail p, String userId)
        {
            String re = "";

            if (p.billing_detail_id.Equals(""))
            {
                re = insert(p, userId);
            }
            else
            {
                re = update(p, userId);
            }
            return re;
        }
        public String voidBillingDetail(String id)
        {
            String re = "", sql = "";

            sql = "Update " + blld.table + " Set " +
                " " + blld.active + "='3' " +
                "," + blld.date_cancel + "=now() " +
                "Where " + blld.billing_detail_id + "='" + id + "'"
                ;
            re = conn.ExecuteNonQuery(conn.conn, sql);

            return re;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select bill.* " +
                "From " + blld.table + " bill " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where ett." + blld.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public BillingDetail selectByPk1(String copId)
        {
            BillingDetail cop1 = new BillingDetail();
            DataTable dt = new DataTable();
            String sql = "select bill.* " +
                "From " + blld.table + " bill " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where bill." + blld.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setBillingDetail(dt);
            return cop1;
        }
        public BillingDetail setBillingDetail(DataTable dt)
        {
            BillingDetail bill1 = new BillingDetail();
            if (dt.Rows.Count > 0)
            {
                bill1.billing_id = dt.Rows[0][blld.billing_id].ToString();
                bill1.billing_detail_id = dt.Rows[0][blld.billing_detail_id].ToString();
                bill1.expenses_draw_detail_id = dt.Rows[0][blld.expenses_draw_detail_id].ToString();
                bill1.item_id = dt.Rows[0][blld.item_id].ToString();
                bill1.item_name_t = dt.Rows[0][blld.item_name_t].ToString();
                bill1.active = dt.Rows[0][blld.active].ToString();
                bill1.date_cancel = dt.Rows[0][blld.date_cancel].ToString();
                bill1.date_create = dt.Rows[0][blld.date_create].ToString();
                bill1.date_modi = dt.Rows[0][blld.date_modi].ToString();
                bill1.user_cancel = dt.Rows[0][blld.user_cancel].ToString();
                bill1.user_create = dt.Rows[0][blld.user_create].ToString();
                bill1.user_modi = dt.Rows[0][blld.user_modi].ToString();
                bill1.item_name_t = dt.Rows[0][blld.item_name_t].ToString();
                bill1.remark = dt.Rows[0][blld.remark].ToString();
                bill1.amount_draw = dt.Rows[0][blld.amount_draw].ToString();
                bill1.amount_income = dt.Rows[0][blld.amount_income].ToString();
            }

            return bill1;
        }
    }
}
