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
    public class ExpensesCatDB
    {
        public ExpensesCat expnC;
        ConnectDB conn;

        public List<ExpensesCat> lexpnC;
        public ExpensesCatDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            expnC = new ExpensesCat();
            expnC.expenses_cat_id = "expenses_cat_id";
            expnC.expenses_cat_code = "expenses_cat_code";
            expnC.expenses_cat_name_e = "expenses_cat_name_e";
            expnC.expenses_cat_name_t = "expenses_cat_name_t";
            //tmn.status_app = "status_app";
            expnC.sort1 = "sort1";

            expnC.active = "active";
            expnC.date_create = "date_create";
            expnC.date_modi = "date_modi";
            expnC.date_cancel = "date_cancel";
            expnC.user_create = "user_create";
            expnC.user_modi = "user_modi";
            expnC.user_cancel = "user_cancel";
            //tmn.status_app = "status_app";
            expnC.remark = "remark";

            expnC.table = "b_expense_cat";
            expnC.pkField = "expense_cat_id";

            lexpnC = new List<ExpensesCat>();
        }
        public void getlexpnC()
        {
            //lDept = new List<Department>();
            
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                ExpensesCat curr1 = new ExpensesCat();
                curr1.expenses_cat_id = row[expnC.expenses_cat_id].ToString();
                curr1.expenses_cat_code = row[expnC.expenses_cat_code].ToString();
                curr1.expenses_cat_name_e = row[expnC.expenses_cat_name_e].ToString();
                curr1.expenses_cat_name_t = row[expnC.expenses_cat_name_t].ToString();
                lexpnC.Add(curr1);
            }
        }
        public String getIdByCode(String code)
        {
            String id = "";
            foreach (ExpensesCat curr1 in lexpnC)
            {
                if (code.Trim().Equals(curr1.expenses_cat_code))
                {
                    id = curr1.expenses_cat_id;
                    break;
                }
            }
            return id;
        }
        public String getIdByName(String name)
        {
            String id = "";
            foreach (ExpensesCat curr1 in lexpnC)
            {
                if (name.Trim().Equals(curr1.expenses_cat_name_t))
                {
                    id = curr1.expenses_cat_id;
                    break;
                }
            }
            return id;
        }
        public void setC1CboExpnC(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            if (lexpnC.Count <= 0) getlexpnC();
            //DataTable dt = selectWard();
            foreach (ExpensesCat cus1 in lexpnC)
            {
                item = new ComboBoxItem();
                item.Value = cus1.expenses_cat_id;
                item.Text = cus1.expenses_cat_name_t;
                c.Items.Add(item);
                if (item.Value.Equals(selected))
                {
                    c.SelectedText = item.Text;
                }
            }
        }
        private void chkNull(ExpensesCat p)
        {
            int chk = 0;
            Decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            p.expenses_cat_code = p.expenses_cat_code == null ? "" : p.expenses_cat_code;
            p.expenses_cat_name_e = p.expenses_cat_name_e == null ? "" : p.expenses_cat_name_e;
            p.expenses_cat_name_t = p.expenses_cat_name_t == null ? "" : p.expenses_cat_name_t;
            p.remark = p.remark == null ? "" : p.remark;
            p.sort1 = p.sort1 == null ? "" : p.sort1;
        }
        public String insert(ExpensesCat p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            //p.prefix_id = int.TryParse(p.prefix_id, out chk) ? chk.ToString() : "0";
            //p.dept_id = int.TryParse(p.dept_id, out chk) ? chk.ToString() : "0";

            sql = "Insert Into " + expnC.table + "(" + expnC.expenses_cat_code + "," + expnC.expenses_cat_name_e + "," + expnC.expenses_cat_name_t + "," +
                expnC.date_create + "," + expnC.date_modi + "," + expnC.date_cancel + "," +
                expnC.user_create + "," + expnC.user_modi + "," + expnC.user_cancel + "," +
                expnC.active + "," + expnC.remark + ", " + expnC.sort1 + " " +
                ") " +
                "Values ('" + p.expenses_cat_code + "','" + p.expenses_cat_name_e.Replace("'", "''") + "','" + p.expenses_cat_name_t.Replace("'", "''") + "'," +
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
        public String update(ExpensesCat p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);

            sql = "Update " + expnC.table + " Set " +
                " " + expnC.expenses_cat_code + " = '" + p.expenses_cat_code + "'" +
                "," + expnC.expenses_cat_name_e + " = '" + p.expenses_cat_name_e.Replace("'", "''") + "'" +
                "," + expnC.expenses_cat_name_t + " = '" + p.expenses_cat_name_t.Replace("'", "''") + "'" +
                "," + expnC.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + expnC.date_modi + " = now()" +
                "," + expnC.user_modi + " = '" + userId + "' " +
                "," + expnC.sort1 + " = '" + p.sort1 + "' " +
                //"," + tmn.status_app + " = '" + p.status_app + "' " +
                "Where " + expnC.pkField + "='" + p.expenses_cat_id + "'"
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
        public String insertExpenseCat(ExpensesCat p, String userId)
        {
            String re = "";

            if (p.expenses_cat_id.Equals(""))
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
            String sql = "Delete From  " + expnC.table;
            conn.ExecuteNonQuery(conn.conn, sql);

            return "";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select expC.*  " +
                "From " + expnC.table + " expC " +
                " " +
                "Where expC." + expnC.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByCodeLike(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select expC.* " +
                "From " + expnC.table + " expC " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where LOWER(expC." + expnC.expenses_cat_code + ") like '%" + copId.ToLower() + "%' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public String selectByNameTLike(String copId)
        {
            String currId = "";
            DataTable dt = new DataTable();
            String sql = "select expC.* " +
                "From " + expnC.table + " expC " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where expC." + expnC.expenses_cat_name_t + " like '%" + copId.ToLower() + "%' ";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count == 1)
            {
                currId = dt.Rows[0][expnC.expenses_cat_id].ToString();
            }
            return currId;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select expC.* " +
                "From " + expnC.table + " expC " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where expC." + expnC.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public ExpensesCat selectByPk1(String copId)
        {
            ExpensesCat cop1 = new ExpensesCat();
            DataTable dt = new DataTable();
            String sql = "select expC.* " +
                "From " + expnC.table + " expC " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where expC." + expnC.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setExpenseCat(dt);
            return cop1;
        }
        public ExpensesCat setExpenseCat(DataTable dt)
        {
            ExpensesCat curr1 = new ExpensesCat();
            if (dt.Rows.Count > 0)
            {
                curr1.expenses_cat_id = dt.Rows[0][expnC.expenses_cat_id].ToString();
                curr1.expenses_cat_code = dt.Rows[0][expnC.expenses_cat_code].ToString();
                curr1.expenses_cat_name_e = dt.Rows[0][expnC.expenses_cat_name_e].ToString();
                curr1.expenses_cat_name_t = dt.Rows[0][expnC.expenses_cat_name_t].ToString();
                curr1.active = dt.Rows[0][expnC.active].ToString();
                curr1.date_cancel = dt.Rows[0][expnC.date_cancel].ToString();
                curr1.date_create = dt.Rows[0][expnC.date_create].ToString();
                curr1.date_modi = dt.Rows[0][expnC.date_modi].ToString();
                curr1.user_cancel = dt.Rows[0][expnC.user_cancel].ToString();
                curr1.user_create = dt.Rows[0][expnC.user_create].ToString();
                curr1.user_modi = dt.Rows[0][expnC.user_modi].ToString();
                //pti1.status_app = dt.Rows[0][tmn.status_app].ToString();
                curr1.remark = dt.Rows[0][expnC.remark].ToString();
                curr1.sort1 = dt.Rows[0][expnC.sort1].ToString();
            }

            return curr1;
        }
    }
}
