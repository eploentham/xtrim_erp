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
    public class ExpensesTypeDB
    {
        public ExpensesType expC;
        ConnectDB conn;

        public List<ExpensesType> lExpnT;
        public ExpensesTypeDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            expC = new ExpensesType();
            expC.expenses_type_id = "expenses_type_id";
            expC.expenses_type_code = "expenses_type_code";
            expC.expenses_type_name_e = "expenses_type_name_e";
            expC.expenses_type_name_t = "expenses_type_name_t";
            //tmn.status_app = "status_app";
            expC.sort1 = "sort1";

            expC.active = "active";
            expC.date_create = "date_create";
            expC.date_modi = "date_modi";
            expC.date_cancel = "date_cancel";
            expC.user_create = "user_create";
            expC.user_modi = "user_modi";
            expC.user_cancel = "user_cancel";
            //tmn.status_app = "status_app";
            expC.remark = "remark";

            expC.table = "b_expenses_type";
            expC.pkField = "expenses_type_id";

            lExpnT = new List<ExpensesType>();

        }
        public void getlExpnT()
        {
            //lDept = new List<Department>();

            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                ExpensesType curr1 = new ExpensesType();
                curr1.expenses_type_id = row[expC.expenses_type_id].ToString();
                curr1.expenses_type_code = row[expC.expenses_type_code].ToString();
                curr1.expenses_type_name_e = row[expC.expenses_type_name_e].ToString();
                curr1.expenses_type_name_t = row[expC.expenses_type_name_t].ToString();
                lExpnT.Add(curr1);
            }
        }
        public String getIdByCode(String code)
        {
            String id = "";
            foreach (ExpensesType curr1 in lExpnT)
            {
                if (code.Trim().Equals(curr1.expenses_type_code))
                {
                    id = curr1.expenses_type_id;
                    break;
                }
            }
            return id;
        }
        public String getIdByName(String name)
        {
            String id = "";
            foreach (ExpensesType curr1 in lExpnT)
            {
                if (name.Trim().Equals(curr1.expenses_type_name_t))
                {
                    id = curr1.expenses_type_id;
                    break;
                }
            }
            return id;
        }
        public void setC1CboExpnT(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            if (lExpnT.Count <= 0) getlExpnT();
            //DataTable dt = selectWard();
            foreach (ExpensesType cus1 in lExpnT)
            {
                item = new ComboBoxItem();
                item.Value = cus1.expenses_type_id;
                item.Text = cus1.expenses_type_name_t;
                c.Items.Add(item);
                if (item.Value.Equals(selected))
                {
                    c.SelectedText = item.Text;
                }
            }
        }
        private void chkNull(ExpensesType p)
        {
            int chk = 0;
            Decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            p.expenses_type_code = p.expenses_type_code == null ? "" : p.expenses_type_code;
            p.expenses_type_name_e = p.expenses_type_name_e == null ? "" : p.expenses_type_name_e;
            p.expenses_type_name_t = p.expenses_type_name_t == null ? "" : p.expenses_type_name_t;
            p.remark = p.remark == null ? "" : p.remark;
            p.sort1 = p.sort1 == null ? "" : p.sort1;
        }
        public String insert(ExpensesType p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            //p.prefix_id = int.TryParse(p.prefix_id, out chk) ? chk.ToString() : "0";
            //p.dept_id = int.TryParse(p.dept_id, out chk) ? chk.ToString() : "0";

            sql = "Insert Into " + expC.table + "(" + expC.expenses_type_code + "," + expC.expenses_type_name_e + "," + expC.expenses_type_name_t + "," +
                expC.date_create + "," + expC.date_modi + "," + expC.date_cancel + "," +
                expC.user_create + "," + expC.user_modi + "," + expC.user_cancel + "," +
                expC.active + "," + expC.remark + ", " + expC.sort1 + " " +
                ") " +
                "Values ('" + p.expenses_type_code + "','" + p.expenses_type_name_e.Replace("'", "''") + "','" + p.expenses_type_name_t.Replace("'", "''") + "'," +
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
        public String update(ExpensesType p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);

            sql = "Update " + expC.table + " Set " +
                " " + expC.expenses_type_code + " = '" + p.expenses_type_code + "'" +
                "," + expC.expenses_type_name_e + " = '" + p.expenses_type_name_e.Replace("'", "''") + "'" +
                "," + expC.expenses_type_name_t + " = '" + p.expenses_type_name_t.Replace("'", "''") + "'" +
                "," + expC.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + expC.date_modi + " = now()" +
                "," + expC.user_modi + " = '" + userId + "' " +
                "," + expC.sort1 + " = '" + p.sort1 + "' " +
                //"," + tmn.status_app + " = '" + p.status_app + "' " +
                "Where " + expC.pkField + "='" + p.expenses_type_id + "'"
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
        public String insertExpenseType(ExpensesType p, String userId)
        {
            String re = "";

            if (p.expenses_type_id.Equals(""))
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
            String sql = "Delete From  " + expC.table;
            conn.ExecuteNonQuery(conn.conn, sql);

            return "";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select expC.*  " +
                "From " + expC.table + " expC " +
                " " +
                "Where expC." + expC.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByCodeLike(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select expC.* " +
                "From " + expC.table + " expC " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where LOWER(expC." + expC.expenses_type_code + ") like '%" + copId.ToLower() + "%' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public String selectByNameTLike(String copId)
        {
            String currId = "";
            DataTable dt = new DataTable();
            String sql = "select expC.* " +
                "From " + expC.table + " expC " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where expC." + expC.expenses_type_name_t + " like '%" + copId.ToLower() + "%' ";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count == 1)
            {
                currId = dt.Rows[0][expC.expenses_type_id].ToString();
            }
            return currId;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select expC.* " +
                "From " + expC.table + " expC " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where expC." + expC.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public ExpensesType selectByPk1(String copId)
        {
            ExpensesType cop1 = new ExpensesType();
            DataTable dt = new DataTable();
            String sql = "select expC.* " +
                "From " + expC.table + " expC " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where expC." + expC.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setExpenseType(dt);
            return cop1;
        }
        public ExpensesType setExpenseType(DataTable dt)
        {
            ExpensesType curr1 = new ExpensesType();
            if (dt.Rows.Count > 0)
            {
                curr1.expenses_type_id = dt.Rows[0][expC.expenses_type_id].ToString();
                curr1.expenses_type_code = dt.Rows[0][expC.expenses_type_code].ToString();
                curr1.expenses_type_name_e = dt.Rows[0][expC.expenses_type_name_e].ToString();
                curr1.expenses_type_name_t = dt.Rows[0][expC.expenses_type_name_t].ToString();
                curr1.active = dt.Rows[0][expC.active].ToString();
                curr1.date_cancel = dt.Rows[0][expC.date_cancel].ToString();
                curr1.date_create = dt.Rows[0][expC.date_create].ToString();
                curr1.date_modi = dt.Rows[0][expC.date_modi].ToString();
                curr1.user_cancel = dt.Rows[0][expC.user_cancel].ToString();
                curr1.user_create = dt.Rows[0][expC.user_create].ToString();
                curr1.user_modi = dt.Rows[0][expC.user_modi].ToString();
                //pti1.status_app = dt.Rows[0][tmn.status_app].ToString();
                curr1.remark = dt.Rows[0][expC.remark].ToString();
                curr1.sort1 = dt.Rows[0][expC.sort1].ToString();
            }

            return curr1;
        }
    }
}
