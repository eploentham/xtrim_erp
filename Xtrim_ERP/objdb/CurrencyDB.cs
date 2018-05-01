using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xtrim_ERP.object1;

namespace Xtrim_ERP.objdb
{
    public class CurrencyDB
    {
        public Currency curr;
        ConnectDB conn;

        public List<Currency> lCurr;

        public CurrencyDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            curr = new Currency();
            curr.curr_id = "curr_id";
            curr.curr_code = "curr_code";
            curr.curr_name_e = "curr_name_e";
            curr.curr_name_t = "curr_name_t";
            //tmn.status_app = "status_app";
            curr.sort1 = "sort1";

            curr.active = "active";
            curr.date_create = "date_create";
            curr.date_modi = "date_modi";
            curr.date_cancel = "date_cancel";
            curr.user_create = "user_create";
            curr.user_modi = "user_modi";
            curr.user_cancel = "user_cancel";
            //tmn.status_app = "status_app";
            curr.remark = "remark";

            curr.table = "b_currency";
            curr.pkField = "curr_id";

            lCurr = new List<Currency>();

            getlCurr();
        }
        public void getlCurr()
        {
            //lDept = new List<Department>();

            lCurr.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                Currency curr1 = new Currency();
                curr1.curr_id = row[curr.curr_id].ToString();
                curr1.curr_code = row[curr.curr_code].ToString();
                curr1.curr_name_e = row[curr.curr_name_e].ToString();
                curr1.curr_name_t = row[curr.curr_name_t].ToString();

                lCurr.Add(curr1);
            }
        }
        public String getIdByCode(String code)
        {
            String id = "";
            foreach (Currency curr1 in lCurr)
            {
                if (code.Trim().Equals(curr1.curr_code))
                {
                    id = curr1.curr_id;
                    break;
                }
            }
            return id;
        }
        public String getIdByName(String name)
        {
            String id = "";
            foreach (Currency curr1 in lCurr)
            {
                if (name.Trim().Equals(curr1.curr_name_t))
                {
                    id = curr1.curr_id;
                    break;
                }
            }
            return id;
        }
        public String insert(Currency p)
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

            sql = "Insert Into " + curr.table + "(" + curr.curr_code + "," + curr.curr_name_e + "," + curr.curr_name_t + "," +
                curr.date_create + "," + curr.date_modi + "," + curr.date_cancel + "," +
                curr.user_create + "," + curr.user_modi + "," + curr.user_cancel + "," +
                curr.active + "," + curr.remark + ", " + curr.sort1 + " " +
                ") " +
                "Values ('" + p.curr_code + "','" + p.curr_name_e.Replace("'", "''") + "','" + p.curr_name_t.Replace("'", "''") + "'," +
                "'" + p.date_create + "','" + p.date_modi + "','" + p.date_cancel + "'," +
                "'" + p.user_create + "','" + p.user_modi + "','" + p.user_cancel + "'," +
                "'" + p.active + "','" + p.remark.Replace("'", "''") + "','" + p.sort1 + "' " +
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
        public String update(Currency p)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            sql = "Update " + curr.table + " Set " +
                " " + curr.curr_code + " = '" + p.curr_code + "'" +
                "," + curr.curr_name_e + " = '" + p.curr_name_e.Replace("'", "''") + "'" +
                "," + curr.curr_name_t + " = '" + p.curr_name_t.Replace("'", "''") + "'" +
                "," + curr.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + curr.date_modi + " = now()" +
                "," + curr.user_modi + " = '" + p.user_modi + "' " +
                "," + curr.sort1 + " = '" + p.sort1 + "' " +
                //"," + tmn.status_app + " = '" + p.status_app + "' " +
                "Where " + curr.pkField + "='" + p.curr_id + "'"
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
        public String insertCurrency(Currency p)
        {
            String re = "";

            if (p.curr_id.Equals(""))
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
            String sql = "Delete From  " + curr.table;
            conn.ExecuteNonQuery(conn.conn, sql);

            return "";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select ugw.*  " +
                "From " + curr.table + " ugw " +
                " " +
                "Where ugw." + curr.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select ugw.* " +
                "From " + curr.table + " ugw " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where ugw." + curr.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public Currency selectByPk1(String copId)
        {
            Currency cop1 = new Currency();
            DataTable dt = new DataTable();
            String sql = "select ugw.* " +
                "From " + curr.table + " ugw " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where ugw." + curr.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setCurr(dt);
            return cop1;
        }
        private Currency setCurr(DataTable dt)
        {
            Currency curr1 = new Currency();
            if (dt.Rows.Count > 0)
            {
                curr1.curr_id = dt.Rows[0][curr.curr_id].ToString();
                curr1.curr_code = dt.Rows[0][curr.curr_code].ToString();
                curr1.curr_name_e = dt.Rows[0][curr.curr_name_e].ToString();
                curr1.curr_name_t = dt.Rows[0][curr.curr_name_t].ToString();
                curr1.active = dt.Rows[0][curr.active].ToString();
                curr1.date_cancel = dt.Rows[0][curr.date_cancel].ToString();
                curr1.date_create = dt.Rows[0][curr.date_create].ToString();
                curr1.date_modi = dt.Rows[0][curr.date_modi].ToString();
                curr1.user_cancel = dt.Rows[0][curr.user_cancel].ToString();
                curr1.user_create = dt.Rows[0][curr.user_create].ToString();
                curr1.user_modi = dt.Rows[0][curr.user_modi].ToString();
                //pti1.status_app = dt.Rows[0][tmn.status_app].ToString();
                curr1.remark = dt.Rows[0][curr.remark].ToString();
                curr1.sort1 = dt.Rows[0][curr.sort1].ToString();
            }

            return curr1;
        }
    }
}
