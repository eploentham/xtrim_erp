using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xtrim_ERP.object1;

namespace Xtrim_ERP.objdb
{
    public class ReserveCashDB
    {
        public ReserveCash rsc;
        ConnectDB conn;
        public List<ReserveCash> lexpn;
        public ReserveCashDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            rsc = new ReserveCash();
            rsc.reserve_cash_id = "reserve_cash_id";
            rsc.reserve_pay_id = "reserve_pay_id";
            rsc.expenses_pay_detail_id = "expenses_pay_detail_id";            
            rsc.amount = "amount";
            rsc.active = "active";
            rsc.remark = "remark";
            rsc.date_create = "date_create";
            rsc.date_modi = "date_modi";
            rsc.date_cancel = "date_cancel";
            rsc.user_create = "user_create";
            rsc.user_modi = "user_modi";
            rsc.user_cancel = "user_cancel";            

            rsc.table = "t_reserve_cash";
            rsc.pkField = "reserve_cash_id";

            lexpn = new List<ReserveCash>();
        }
        public String getIdByName(String name)
        {
            String id = "";
            foreach (ReserveCash utp1 in lexpn)
            {
                if (name.Trim().Equals(utp1.reserve_pay_id))
                {
                    id = utp1.reserve_cash_id;
                    break;
                }
            }
            return id;
        }
        private void chkNull(ReserveCash p)
        {
            int chk = 0;
            Decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;            
            p.remark = p.remark == null ? "" : p.remark;

            p.expenses_pay_detail_id = int.TryParse(p.expenses_pay_detail_id, out chk) ? chk.ToString() : "0";
            p.reserve_pay_id = int.TryParse(p.reserve_pay_id, out chk) ? chk.ToString() : "0";
            //p.billing_cover_id = int.TryParse(p.billing_cover_id, out chk) ? chk.ToString() : "0";

            p.amount = Decimal.TryParse(p.amount, out chk1) ? chk1.ToString() : "0";
        }
        public String insert(ReserveCash p, String userId)
        {
            String re = "", sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            chkNull(p);
            sql = "Insert Into " + rsc.table + "(" + rsc.expenses_pay_detail_id + "," + rsc.reserve_pay_id + "," + 
                rsc.active + "," + rsc.remark + ", " + 
                rsc.date_create + ", " + rsc.date_modi + ", " + rsc.date_cancel + ", " +
                rsc.user_create + ", " + rsc.user_modi + ", " + rsc.user_cancel + "," +
                rsc.amount + " " + 
                ") " +
                "Values ('" + p.expenses_pay_detail_id + "','" + p.reserve_pay_id + "'," + 
                "'" + p.active + "','" + p.remark + "'," + 
                "now(),'" + p.date_modi + "','" + p.date_cancel + "', " +
                "'" + userId + "','" + p.user_modi + "','" + p.user_cancel + "'," +
                "'" + p.amount + "' " + 
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
        public String update(ReserveCash p, String userId)
        {
            String re = "", sql = "";
            chkNull(p);
            sql = "Update " + rsc.table + " Set " +
                " " + rsc.expenses_pay_detail_id + "='" + p.expenses_pay_detail_id + "' " +
                "," + rsc.reserve_pay_id + "='" + p.reserve_pay_id.Replace("'", "''") + "' " +
                "," + rsc.remark + "='" + p.remark.Replace("'", "''") + "' " +
                "," + rsc.date_modi + "=now() " +
                "," + rsc.user_modi + "='" + userId.Replace("'", "''") + "' " +
                "," + rsc.amount + "='" + p.amount.Replace("'", "''") + "' " +
                "Where " + rsc.pkField + "='" + p.reserve_cash_id + "' ";

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
        public String insertReserveCash(ReserveCash p, String userId)
        {
            String re = "";

            if (p.reserve_cash_id.Equals(""))
            {
                re = insert(p, userId);
            }
            else
            {
                re = update(p, userId);
            }
            return re;
        }
        public String voidReserveCash(String id)
        {
            String re = "", sql = "";
            sql = "Update " + rsc.table + " Set " +
                " " + rsc.active + "='3' " +
                "," + rsc.date_cancel + "=now() " +
                "Where " + rsc.reserve_cash_id + "='" + id + "'";
            re = conn.ExecuteNonQuery(conn.conn, sql);

            return re;
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select rsc.*  " +
                "From " + rsc.table + " rsc " +
                " " +
                "Where rsc." + rsc.active + " ='1' " +
                "Order By rsc."+rsc.reserve_cash_id;
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        //public String updateBillingCover(String id, String coverid)
        //{
        //    String re = "", sql = "";
        //    sql = "Update " + rsc.table + " Set " +
        //        " " + rsc.billing_cover_id + "='" + coverid + "' " +
        //        "Where " + rsc.reserve_cash_id + "='" + id + "'";
        //    re = conn.ExecuteNonQuery(conn.conn, sql);

        //    return re;
        //}
        //public DataTable selectByCusId(String copId)
        //{
        //    DataTable dt = new DataTable();
        //    String sql = "select bll.* " +
        //        "From " + rsc.table + " bll " +
        //        //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
        //        "Where bll." + rsc.cust_id + " ='" + copId + "' and " + rsc.active + "='1' ";
        //    dt = conn.selectData(conn.conn, sql);
        //    return dt;
        //}
        //public DataTable selectByJobId(String copId)
        //{
        //    DataTable dt = new DataTable();
        //    String sql = "select bll.* " +
        //        "From " + rsc.table + " bll " +
        //        //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
        //        "Where bll." + rsc.job_id + " ='" + copId + "' and " + rsc.active + "='1' ";
        //    dt = conn.selectData(conn.conn, sql);
        //    return dt;
        //}
        public ReserveCash selectByBillCode1(String copId)
        {
            ReserveCash cop1 = new ReserveCash();
            DataTable dt = new DataTable();
            String sql = "select bll.* " +
                "From " + rsc.table + " bll " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where bll." + rsc.reserve_pay_id + " ='" + copId + "' and " + rsc.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setReserveCash(dt);
            return cop1;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select bll.* " +
                "From " + rsc.table + " bll " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where bll." + rsc.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public ReserveCash selectByPk1(String copId)
        {
            ReserveCash cop1 = new ReserveCash();
            DataTable dt = new DataTable();
            String sql = "select bll.* " +
                "From " + rsc.table + " bll " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where bll." + rsc.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setReserveCash(dt);
            return cop1;
        }
        public ReserveCash setReserveCash(DataTable dt)
        {
            ReserveCash bll1 = new ReserveCash();
            if (dt.Rows.Count > 0)
            {
                bll1.reserve_cash_id = dt.Rows[0][rsc.reserve_cash_id].ToString();
                bll1.reserve_pay_id = dt.Rows[0][rsc.reserve_pay_id].ToString();
                bll1.expenses_pay_detail_id = dt.Rows[0][rsc.expenses_pay_detail_id].ToString();
                bll1.active = dt.Rows[0][rsc.active].ToString();
                bll1.date_cancel = dt.Rows[0][rsc.date_cancel].ToString();
                bll1.date_create = dt.Rows[0][rsc.date_create].ToString();
                bll1.date_modi = dt.Rows[0][rsc.date_modi].ToString();
                bll1.user_cancel = dt.Rows[0][rsc.user_cancel].ToString();
                bll1.user_create = dt.Rows[0][rsc.user_create].ToString();
                bll1.user_modi = dt.Rows[0][rsc.user_modi].ToString();
                bll1.remark = dt.Rows[0][rsc.remark].ToString();
                bll1.amount = dt.Rows[0][rsc.amount].ToString();
                
            }
            else
            {
                bll1.reserve_cash_id = "";
                bll1.reserve_pay_id = "";
                bll1.expenses_pay_detail_id = "";
                bll1.amount = "";
                bll1.active = "";
                bll1.remark = "";
                bll1.date_create = "";
                bll1.date_modi = "";
                bll1.date_cancel = "";
                bll1.user_create = "";
                bll1.user_modi = "";
                bll1.user_cancel = "";
            }

            return bll1;
        }
    }
}
