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
    public class ExpensesDrawTypeDB
    {
        public ExpensesDrawType expndT;
        ConnectDB conn;

        public List<ExpensesDrawType> lexpnC;
        public ExpensesDrawTypeDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            expndT = new ExpensesDrawType();
            expndT.expenses_draw_type_id = "expenses_draw_type_id";
            expndT.expenses_draw_type_name_t = "expenses_draw_type_name_t";
            expndT.expenses_draw_type_name_e = "expenses_draw_type_name_e";
            expndT.expenses_draw_type_code = "expenses_draw_type_code";
            //tmn.status_app = "status_app";
            expndT.sort1 = "sort1";

            expndT.active = "active";
            expndT.date_create = "date_create";
            expndT.date_modi = "date_modi";
            expndT.date_cancel = "date_cancel";
            expndT.user_create = "user_create";
            expndT.user_modi = "user_modi";
            expndT.user_cancel = "user_cancel";
            //tmn.status_app = "status_app";
            expndT.remark = "remark";

            expndT.table = "b_expense_cat";
            expndT.pkField = "expenses_draw_type_id";

            lexpnC = new List<ExpensesDrawType>();
        }
        public void getlexpnC()
        {
            //lDept = new List<Department>();

            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                ExpensesDrawType curr1 = new ExpensesDrawType();
                curr1.expenses_draw_type_id = row[expndT.expenses_draw_type_id].ToString();
                curr1.expenses_draw_type_name_t = row[expndT.expenses_draw_type_name_t].ToString();
                curr1.expenses_draw_type_name_e = row[expndT.expenses_draw_type_name_e].ToString();
                curr1.expenses_draw_type_code = row[expndT.expenses_draw_type_code].ToString();
                lexpnC.Add(curr1);
            }
        }
        public String getIdByCode(String code)
        {
            String id = "";
            foreach (ExpensesDrawType curr1 in lexpnC)
            {
                if (code.Trim().Equals(curr1.expenses_draw_type_name_t))
                {
                    id = curr1.expenses_draw_type_id;
                    break;
                }
            }
            return id;
        }
        public String getIdByName(String name)
        {
            String id = "";
            foreach (ExpensesDrawType curr1 in lexpnC)
            {
                if (name.Trim().Equals(curr1.expenses_draw_type_code))
                {
                    id = curr1.expenses_draw_type_id;
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
            foreach (ExpensesDrawType cus1 in lexpnC)
            {
                item = new ComboBoxItem();
                item.Value = cus1.expenses_draw_type_id;
                item.Text = cus1.expenses_draw_type_code;
                c.Items.Add(item);
                if (item.Value.Equals(selected))
                {
                    c.SelectedText = item.Text;
                }
            }
        }
        private void chkNull(ExpensesDrawType p)
        {
            int chk = 0;
            Decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            p.expenses_draw_type_name_t = p.expenses_draw_type_name_t == null ? "" : p.expenses_draw_type_name_t;
            p.expenses_draw_type_name_e = p.expenses_draw_type_name_e == null ? "" : p.expenses_draw_type_name_e;
            p.expenses_draw_type_code = p.expenses_draw_type_code == null ? "" : p.expenses_draw_type_code;
            p.remark = p.remark == null ? "" : p.remark;
            p.sort1 = p.sort1 == null ? "" : p.sort1;
        }
        public String insert(ExpensesDrawType p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            //p.prefix_id = int.TryParse(p.prefix_id, out chk) ? chk.ToString() : "0";
            //p.dept_id = int.TryParse(p.dept_id, out chk) ? chk.ToString() : "0";

            sql = "Insert Into " + expndT.table + "(" + expndT.expenses_draw_type_name_t + "," + expndT.expenses_draw_type_name_e + "," + expndT.expenses_draw_type_code + "," +
                expndT.date_create + "," + expndT.date_modi + "," + expndT.date_cancel + "," +
                expndT.user_create + "," + expndT.user_modi + "," + expndT.user_cancel + "," +
                expndT.active + "," + expndT.remark + ", " + expndT.sort1 + " " +
                ") " +
                "Values ('" + p.expenses_draw_type_name_t + "','" + p.expenses_draw_type_name_e.Replace("'", "''") + "','" + p.expenses_draw_type_code.Replace("'", "''") + "'," +
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
        public String update(ExpensesDrawType p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);

            sql = "Update " + expndT.table + " Set " +
                " " + expndT.expenses_draw_type_name_t + " = '" + p.expenses_draw_type_name_t + "'" +
                "," + expndT.expenses_draw_type_name_e + " = '" + p.expenses_draw_type_name_e.Replace("'", "''") + "'" +
                "," + expndT.expenses_draw_type_code + " = '" + p.expenses_draw_type_code.Replace("'", "''") + "'" +
                "," + expndT.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + expndT.date_modi + " = now()" +
                "," + expndT.user_modi + " = '" + userId + "' " +
                "," + expndT.sort1 + " = '" + p.sort1 + "' " +
                //"," + tmn.status_app + " = '" + p.status_app + "' " +
                "Where " + expndT.pkField + "='" + p.expenses_draw_type_id + "'"
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
        public String insertExpenseDrawType(ExpensesDrawType p, String userId)
        {
            String re = "";

            if (p.expenses_draw_type_id.Equals(""))
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
            String sql = "Delete From  " + expndT.table;
            conn.ExecuteNonQuery(conn.conn, sql);

            return "";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select expC.*  " +
                "From " + expndT.table + " expC " +
                " " +
                "Where expC." + expndT.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByCodeLike(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select expC.* " +
                "From " + expndT.table + " expC " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where LOWER(expC." + expndT.expenses_draw_type_name_t + ") like '%" + copId.ToLower() + "%' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public String selectByNameTLike(String copId)
        {
            String currId = "";
            DataTable dt = new DataTable();
            String sql = "select expC.* " +
                "From " + expndT.table + " expC " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where expC." + expndT.expenses_draw_type_code + " like '%" + copId.ToLower() + "%' ";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count == 1)
            {
                currId = dt.Rows[0][expndT.expenses_draw_type_id].ToString();
            }
            return currId;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select expC.* " +
                "From " + expndT.table + " expC " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where expC." + expndT.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public ExpensesDrawType selectByPk1(String copId)
        {
            ExpensesDrawType cop1 = new ExpensesDrawType();
            DataTable dt = new DataTable();
            String sql = "select expC.* " +
                "From " + expndT.table + " expC " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where expC." + expndT.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setExpenseDrawType(dt);
            return cop1;
        }
        public ExpensesDrawType setExpenseDrawType(DataTable dt)
        {
            ExpensesDrawType curr1 = new ExpensesDrawType();
            if (dt.Rows.Count > 0)
            {
                curr1.expenses_draw_type_id = dt.Rows[0][expndT.expenses_draw_type_id].ToString();
                curr1.expenses_draw_type_name_t = dt.Rows[0][expndT.expenses_draw_type_name_t].ToString();
                curr1.expenses_draw_type_name_e = dt.Rows[0][expndT.expenses_draw_type_name_e].ToString();
                curr1.expenses_draw_type_code = dt.Rows[0][expndT.expenses_draw_type_code].ToString();
                curr1.active = dt.Rows[0][expndT.active].ToString();
                curr1.date_cancel = dt.Rows[0][expndT.date_cancel].ToString();
                curr1.date_create = dt.Rows[0][expndT.date_create].ToString();
                curr1.date_modi = dt.Rows[0][expndT.date_modi].ToString();
                curr1.user_cancel = dt.Rows[0][expndT.user_cancel].ToString();
                curr1.user_create = dt.Rows[0][expndT.user_create].ToString();
                curr1.user_modi = dt.Rows[0][expndT.user_modi].ToString();
                //pti1.status_app = dt.Rows[0][tmn.status_app].ToString();
                curr1.remark = dt.Rows[0][expndT.remark].ToString();
                curr1.sort1 = dt.Rows[0][expndT.sort1].ToString();
            }

            return curr1;
        }
    }
}
