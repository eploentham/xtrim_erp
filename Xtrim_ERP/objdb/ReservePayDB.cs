using C1.Win.C1Input;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xtrim_ERP.object1;

namespace Xtrim_ERP.objdb
{
    public class ReservePayDB
    {
        public ReservePay rsp;
        ConnectDB conn;

        public List<ReservePay> lRsp;
        public ReservePayDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            rsp = new ReservePay();
            rsp.reserve_pay_id = "reserve_pay_id";
            rsp.status_appv = "status_appv";
            rsp.desc1 = "desc1";
            rsp.active = "active";
            rsp.date_create = "date_create";
            rsp.date_modi = "date_modi";
            rsp.date_cancel = "date_cancel";
            rsp.user_create = "user_create";
            rsp.user_modi = "user_modi";
            rsp.user_cancel = "user_cancel";            
            rsp.remark = "remark";
            rsp.amount_draw = "amount_draw";
            rsp.amount_appv = "amount_appv";
            rsp.amount_reserve = "amount_reserve";
            rsp.date_draw = "date_draw";
            rsp.date_appv = "date_appv";
            rsp.date_reserve = "date_reserve";
            rsp.staff_id = "staff_id";

            rsp.table = "t_reserve_pay";
            rsp.pkField = "reserve_pay_id";

            lRsp = new List<ReservePay>();

        }
        public void getlExpnT()
        {
            //lDept = new List<Department>();

            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                ReservePay curr1 = new ReservePay();
                curr1.reserve_pay_id = row[rsp.reserve_pay_id].ToString();
                curr1.desc1 = row[rsp.desc1].ToString();
                
                lRsp.Add(curr1);
            }
        }
        public String getIdByCode(String code)
        {
            String id = "";
            foreach (ReservePay curr1 in lRsp)
            {
                if (code.Trim().Equals(curr1.desc1))
                {
                    id = curr1.reserve_pay_id;
                    break;
                }
            }
            return id;
        }
        public String getIdByName(String name)
        {
            String id = "";
            foreach (ReservePay curr1 in lRsp)
            {
                if (name.Trim().Equals(curr1.desc1))
                {
                    id = curr1.reserve_pay_id;
                    break;
                }
            }
            return id;
        }
        public void setC1CboReservePay(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            if (lRsp.Count <= 0) getlExpnT();
            //DataTable dt = selectWard();
            item = new ComboBoxItem();
            item.Value = "";
            item.Text = "";
            c.Items.Add(item);
            foreach (ReservePay cus1 in lRsp)
            {
                item = new ComboBoxItem();
                item.Value = cus1.reserve_pay_id;
                item.Text = cus1.desc1;
                c.Items.Add(item);
                if (item.Value.Equals(selected))
                {
                    c.SelectedText = item.Text;
                }
            }
        }
        private void chkNull(ReservePay p)
        {
            int chk = 0;
            Decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            p.status_appv = p.status_appv == null ? "0" : p.status_appv;
            p.desc1 = p.desc1 == null ? "" : p.desc1;            
            p.remark = p.remark == null ? "" : p.remark;
            p.date_draw = p.date_draw == null ? "" : p.date_draw;
            p.date_appv = p.date_appv == null ? "" : p.date_appv;
            p.date_reserve = p.date_reserve == null ? "" : p.date_reserve;
            p.staff_id = p.staff_id == null ? "0" : p.staff_id;

            p.amount_draw = Decimal.TryParse(p.amount_draw, out chk1) ? chk1.ToString() : "0";
            p.amount_appv = Decimal.TryParse(p.amount_appv, out chk1) ? chk1.ToString() : "0";
            p.amount_reserve = Decimal.TryParse(p.amount_reserve, out chk1) ? chk1.ToString() : "0";
        }
        public String insert(ReservePay p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            //p.prefix_id = int.TryParse(p.prefix_id, out chk) ? chk.ToString() : "0";
            //p.dept_id = int.TryParse(p.dept_id, out chk) ? chk.ToString() : "0";

            sql = "Insert Into " + rsp.table + "(" + rsp.desc1 + "," + rsp.amount_draw + "," + rsp.amount_appv + "," +
                rsp.date_create + "," + rsp.date_modi + "," + rsp.date_cancel + "," +
                rsp.user_create + "," + rsp.user_modi + "," + rsp.user_cancel + "," +
                rsp.active + "," + rsp.remark + ", " + rsp.amount_reserve + ", " +
                rsp.date_appv + "," + rsp.date_draw + ", " + rsp.date_reserve + ", " +
                rsp.staff_id + " " +
                ") " +
                "Values ('" + p.desc1.Replace("'", "''") + "','" + p.amount_draw.Replace("'", "''") + "','" + p.amount_appv.Replace("'", "''") + "', " +
                "'" + p.date_create + "','" + p.date_modi + "','" + p.date_cancel + "'," +
                "'" + userId + "','" + p.user_modi + "','" + p.user_cancel + "'," +
                "'" + p.active + "','" + p.remark.Replace("'", "''") + "','" + p.amount_reserve.Replace("'", "''") + "', " +
                "'" + p.date_appv + "','" + p.date_draw.Replace("'", "''") + "','" + p.date_reserve.Replace("'", "''") + "', " +
                "'" + p.staff_id + "' " +
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
        public String update(ReservePay p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);

            sql = "Update " + rsp.table + " Set " +
                " " + rsp.desc1 + " = '" + p.desc1.Replace("'", "''") + "'" +
                "," + rsp.amount_draw + " = '" + p.amount_draw.Replace("'", "''") + "'" +                
                "," + rsp.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + rsp.date_modi + " = now()" +
                "," + rsp.user_modi + " = '" + userId + "' " +
                "Where " + rsp.pkField + "='" + p.reserve_pay_id + "'"
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
        public String updateAppv(String id, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            //chkNull(p);

            sql = "Update " + rsp.table + " Set " +
                " " + rsp.amount_appv + " = " + rsp.amount_draw + " " +
                "," + rsp.date_appv + " = now() " +
                "," + rsp.date_modi + " = now()" +
                "," + rsp.user_modi + " = '" + userId + "' " +
                "," + rsp.status_appv + " = '2' " +
                "Where " + rsp.pkField + "='" + id + "'";
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
        public String updateReserve(String id, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            //chkNull(p);

            sql = "Update " + rsp.table + " Set " +
                " " + rsp.amount_reserve + " = " + rsp.amount_appv + " " +
                "," + rsp.date_reserve + " = now() " +
                "," + rsp.date_modi + " = now() " +
                "," + rsp.user_modi + " = '" + userId + "' " +
                "," + rsp.status_appv + " = '2' " +
                "Where " + rsp.pkField + "='" + id + "'";
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
        public String updateReserve(ReservePay p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);

            sql = "Update " + rsp.table + " Set " +
                " " + rsp.amount_reserve + " = '" + p.amount_reserve.Replace("'", "''") + "'" +
                "," + rsp.date_reserve + " = '" + p.date_reserve.Replace("'", "''") + "'" +
                "," + rsp.date_modi + " = now()" +
                "," + rsp.user_modi + " = '" + userId + "' " +
                "Where " + rsp.pkField + "='" + p.reserve_pay_id + "'"
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
        public String insertReservePay(ReservePay p, String userId)
        {
            String re = "";

            if (p.reserve_pay_id.Equals(""))
            {
                re = insert(p, userId);
            }
            else
            {
                re = update(p, userId);
            }

            return re;
        }
        public String deleteAll()
        {
            DataTable dt = new DataTable();
            String sql = "Delete From  " + rsp.table;
            conn.ExecuteNonQuery(conn.conn, sql);

            return "";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select expC.*  " +
                "From " + rsp.table + " expC " +
                " " +
                "Where expC." + rsp.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectAll1()
        {
            DataTable dt = new DataTable();
            String sql = "select rsp." + rsp.reserve_pay_id+","+rsp.amount_draw+","+rsp.date_draw+","+rsp.status_appv+","+rsp.desc1+" " +
                "From " + rsp.table + " rsp " +
                " " +
                "Where rsp." + rsp.active + " ='1' " +
                "Order By "+rsp.reserve_pay_id+" desc";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        //public DataTable selectByCodeLike(String copId)
        //{
        //    DataTable dt = new DataTable();
        //    String sql = "select expC.* " +
        //        "From " + itmT.table + " expC " +
        //        //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
        //        "Where LOWER(expC." + itmT.item_type_code + ") like '%" + copId.ToLower() + "%' ";
        //    dt = conn.selectData(conn.conn, sql);
        //    return dt;
        //}
        public String selectAppvWait()
        {
            String currId = "";
            DataTable dt = new DataTable();
            String sql = "select sum(rsp."+rsp.amount_draw+") as amt " +
                "From " + rsp.table + " rsp " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where rsp." + rsp.status_appv + " = '1' and "+ rsp.active+"='1' ";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count == 1)
            {
                currId = dt.Rows[0]["amt"].ToString();
            }
            return currId;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select expC.* " +
                "From " + rsp.table + " expC " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where expC." + rsp.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public ReservePay selectByPk1(String copId)
        {
            ReservePay cop1 = new ReservePay();
            DataTable dt = new DataTable();
            String sql = "select expC.* " +
                "From " + rsp.table + " expC " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where expC." + rsp.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setReservePay(dt);
            return cop1;
        }
        public ReservePay setReservePay(DataTable dt)
        {
            ReservePay curr1 = new ReservePay();
            if (dt.Rows.Count > 0)
            {
                curr1.reserve_pay_id = dt.Rows[0][rsp.reserve_pay_id].ToString();
                curr1.desc1 = dt.Rows[0][rsp.desc1].ToString();
                curr1.amount_draw = dt.Rows[0][rsp.amount_draw].ToString();
                curr1.active = dt.Rows[0][rsp.active].ToString();
                curr1.date_cancel = dt.Rows[0][rsp.date_cancel].ToString();
                curr1.date_create = dt.Rows[0][rsp.date_create].ToString();
                curr1.date_modi = dt.Rows[0][rsp.date_modi].ToString();
                curr1.user_cancel = dt.Rows[0][rsp.user_cancel].ToString();
                curr1.user_create = dt.Rows[0][rsp.user_create].ToString();
                curr1.user_modi = dt.Rows[0][rsp.user_modi].ToString();
                curr1.remark = dt.Rows[0][rsp.remark].ToString();
                curr1.amount_appv = dt.Rows[0][rsp.amount_appv].ToString();
                curr1.amount_reserve = dt.Rows[0][rsp.amount_reserve].ToString();
                curr1.date_appv = dt.Rows[0][rsp.date_appv].ToString();
                curr1.date_draw = dt.Rows[0][rsp.date_draw].ToString();
                curr1.date_reserve = dt.Rows[0][rsp.date_reserve].ToString();
                curr1.staff_id = dt.Rows[0][rsp.staff_id].ToString();
                curr1.status_appv = dt.Rows[0][rsp.status_appv].ToString();
            }
            else
            {
                curr1.reserve_pay_id = "";
                curr1.desc1 = "";
                curr1.amount_draw = "0";               

                curr1.active = "";
                curr1.date_create = "";
                curr1.date_modi = "";
                curr1.date_cancel = "";
                curr1.user_create = "";
                curr1.user_modi = "";
                curr1.user_cancel = "";                
                curr1.remark = "";
                curr1.amount_appv = "";
                curr1.amount_reserve = "";
                curr1.date_appv = "";
                curr1.date_draw = "";
                curr1.date_reserve = "";
                curr1.staff_id = "";
                curr1.status_appv = "";
                //curr1.amount_draw = "";
            }

            return curr1;
        }
    }
}
