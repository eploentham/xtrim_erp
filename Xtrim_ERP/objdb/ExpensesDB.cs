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
    public class ExpensesDB
    {
        public Expenses expn;
        ConnectDB conn;

        public List<Expenses> lexpn;

        public ExpensesDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            expn = new Expenses();
            expn.expenses_id = "expenses_id";
            expn.expenses_code = "expenses_code";
            expn.expenses_name_e = "expenses_name_e";
            expn.expenses_name_t = "expenses_name_t";
            expn.status_app = "status_app";
            expn.sort1 = "sort1";

            expn.active = "active";
            expn.date_create = "date_create";
            expn.date_modi = "date_modi";
            expn.date_cancel = "date_cancel";
            expn.user_create = "user_create";
            expn.user_modi = "user_modi";
            expn.user_cancel = "user_cancel";
            //tmn.status_app = "status_app";
            expn.remark = "remark";

            expn.table = "b_expenses";
            expn.pkField = "expenses_id";

            lexpn = new List<Expenses>();

            //getlExpn();
        }
        public void getlExpn()
        {
            //lDept = new List<Department>();

            lexpn.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                Expenses expn1 = new Expenses();
                expn1.expenses_id = row[expn.expenses_id].ToString();
                expn1.expenses_code = row[expn.expenses_code].ToString();
                expn1.expenses_name_e = row[expn.expenses_name_e].ToString();
                expn1.expenses_name_t = row[expn.expenses_name_t].ToString();

                lexpn.Add(expn1);
            }
        }
        public String getIdByCode(String code)
        {
            String id = "";
            foreach (Expenses expn1 in lexpn)
            {
                if (code.Trim().Equals(expn1.expenses_code))
                {
                    id = expn1.expenses_id;
                    break;
                }
            }
            return id;
        }
        public String getIdByName(String name)
        {
            String id = "";
            foreach (Expenses expn1 in lexpn)
            {
                if (name.Trim().Equals(expn1.expenses_name_t))
                {
                    id = expn1.expenses_id;
                    break;
                }
            }
            return id;
        }
        public String insert(Expenses p, String userId)
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

            sql = "Insert Into " + expn.table + "(" + expn.expenses_code + "," + expn.expenses_name_e + "," + expn.expenses_name_t + "," +
                expn.date_create + "," + expn.date_modi + "," + expn.date_cancel + "," +
                expn.user_create + "," + expn.user_modi + "," + expn.user_cancel + "," +
                expn.active + "," + expn.remark + ", " + expn.sort1 + " " +
                ") " +
                "Values ('" + p.expenses_code + "','" + p.expenses_name_e.Replace("'", "''") + "','" + p.expenses_name_t.Replace("'", "''") + "'," +
                "'" + p.date_create + "','" + p.date_modi + "','" + p.date_cancel + "'," +
                "'" + userId + "','" + p.user_modi + "','" + p.user_cancel + "'," +
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
        public String update(Expenses p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            sql = "Update " + expn.table + " Set " +
                " " + expn.expenses_code + " = '" + p.expenses_code + "'" +
                "," + expn.expenses_name_e + " = '" + p.expenses_name_e.Replace("'", "''") + "'" +
                "," + expn.expenses_name_t + " = '" + p.expenses_name_t.Replace("'", "''") + "'" +
                "," + expn.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + expn.date_modi + " = now()" +
                "," + expn.user_modi + " = '" + userId + "' " +
                "," + expn.sort1 + " = '" + p.sort1 + "' " +
                //"," + tmn.status_app + " = '" + p.status_app + "' " +
                "Where " + expn.pkField + "='" + p.expenses_id + "'"
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
        public String insertExpnes(Expenses p, String userId)
        {
            String re = "";

            if (p.expenses_id.Equals(""))
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
            String sql = "Delete From  " + expn.table;
            conn.ExecuteNonQuery(conn.conn, sql);

            return "";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select expn.*  " +
                "From " + expn.table + " expn " +
                " " +
                "Where expn." + expn.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select expn.* " +
                "From " + expn.table + " expn " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where expn." + expn.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public Expenses selectByPk1(String copId)
        {
            Expenses cop1 = new Expenses();
            DataTable dt = new DataTable();
            String sql = "select expn.* " +
                "From " + expn.table + " expn " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where expn." + expn.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setExpn(dt);
            return cop1;
        }
        private Expenses setExpn(DataTable dt)
        {
            Expenses expn1 = new Expenses();
            if (dt.Rows.Count > 0)
            {
                expn1.expenses_id = dt.Rows[0][expn.expenses_id].ToString();
                expn1.expenses_code = dt.Rows[0][expn.expenses_code].ToString();
                expn1.expenses_name_e = dt.Rows[0][expn.expenses_name_e].ToString();
                expn1.expenses_name_t = dt.Rows[0][expn.expenses_name_t].ToString();
                expn1.active = dt.Rows[0][expn.active].ToString();
                expn1.date_cancel = dt.Rows[0][expn.date_cancel].ToString();
                expn1.date_create = dt.Rows[0][expn.date_create].ToString();
                expn1.date_modi = dt.Rows[0][expn.date_modi].ToString();
                expn1.user_cancel = dt.Rows[0][expn.user_cancel].ToString();
                expn1.user_create = dt.Rows[0][expn.user_create].ToString();
                expn1.user_modi = dt.Rows[0][expn.user_modi].ToString();
                //pti1.status_app = dt.Rows[0][tmn.status_app].ToString();
                expn1.remark = dt.Rows[0][expn.remark].ToString();
                expn1.sort1 = dt.Rows[0][expn.sort1].ToString();
            }

            return expn1;
        }
        public C1ComboBox setCboExpen(C1ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectAll();
            //String aaa = "";
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "000";
            c.Items.Clear();
            c.Items.Add(item1);
            //for (int i = 0; i < dt.Rows.Count; i++)
            foreach (DataRow row in dt.Rows)
            {
                item = new ComboBoxItem();
                item.Text = row[expn.expenses_name_t].ToString();
                item.Value = row[expn.expenses_id].ToString();

                c.Items.Add(item);
            }
            return c;
        }
    }
}
