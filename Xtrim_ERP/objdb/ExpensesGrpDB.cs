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
    public class ExpensesGrpDB
    {
        public ExpensesGrp expC;
        ConnectDB conn;

        public List<ExpensesGrp> lexpnC;
        public ExpensesGrpDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            expC = new ExpensesGrp();
            expC.expense_grp_id = "expense_grp_id";
            expC.expense_grp_code = "expense_grp_code";
            expC.expense_grp_name_e = "expense_grp_name_e";
            expC.expense_grp_name_t = "expense_grp_name_t";
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

            expC.table = "b_expense_grp";
            expC.pkField = "expense_grp_id";

            lexpnC = new List<ExpensesGrp>();
        }
        public void getlexpnC()
        {
            //lDept = new List<Department>();

            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                ExpensesGrp curr1 = new ExpensesGrp();
                curr1.expense_grp_id = row[expC.expense_grp_id].ToString();
                curr1.expense_grp_code = row[expC.expense_grp_code].ToString();
                curr1.expense_grp_name_e = row[expC.expense_grp_name_e].ToString();
                curr1.expense_grp_name_t = row[expC.expense_grp_name_t].ToString();
                lexpnC.Add(curr1);
            }
        }
        public String getIdByCode(String code)
        {
            String id = "";
            foreach (ExpensesGrp curr1 in lexpnC)
            {
                if (code.Trim().Equals(curr1.expense_grp_code))
                {
                    id = curr1.expense_grp_id;
                    break;
                }
            }
            return id;
        }
        public String getIdByName(String name)
        {
            String id = "";
            foreach (ExpensesGrp curr1 in lexpnC)
            {
                if (name.Trim().Equals(curr1.expense_grp_name_t))
                {
                    id = curr1.expense_grp_id;
                    break;
                }
            }
            return id;
        }
        public void setC1CboExpnG(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            if (lexpnC.Count <= 0) getlexpnC();
            //DataTable dt = selectWard();
            foreach (ExpensesGrp cus1 in lexpnC)
            {
                item = new ComboBoxItem();
                item.Value = cus1.expense_grp_id;
                item.Text = cus1.expense_grp_name_t;
                c.Items.Add(item);
                if (item.Value.Equals(selected))
                {
                    c.SelectedText = item.Text;
                }
            }
        }
        private void chkNull(ExpensesGrp p)
        {
            int chk = 0;
            Decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            p.expense_grp_code = p.expense_grp_code == null ? "" : p.expense_grp_code;
            p.expense_grp_name_e = p.expense_grp_name_e == null ? "" : p.expense_grp_name_e;
            p.expense_grp_name_t = p.expense_grp_name_t == null ? "" : p.expense_grp_name_t;
            p.remark = p.remark == null ? "" : p.remark;
            p.sort1 = p.sort1 == null ? "" : p.sort1;
        }
        public String insert(ExpensesGrp p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            //p.prefix_id = int.TryParse(p.prefix_id, out chk) ? chk.ToString() : "0";
            //p.dept_id = int.TryParse(p.dept_id, out chk) ? chk.ToString() : "0";

            sql = "Insert Into " + expC.table + "(" + expC.expense_grp_code + "," + expC.expense_grp_name_e + "," + expC.expense_grp_name_t + "," +
                expC.date_create + "," + expC.date_modi + "," + expC.date_cancel + "," +
                expC.user_create + "," + expC.user_modi + "," + expC.user_cancel + "," +
                expC.active + "," + expC.remark + ", " + expC.sort1 + " " +
                ") " +
                "Values ('" + p.expense_grp_code + "','" + p.expense_grp_name_e.Replace("'", "''") + "','" + p.expense_grp_name_t.Replace("'", "''") + "'," +
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
        public String update(ExpensesGrp p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);

            sql = "Update " + expC.table + " Set " +
                " " + expC.expense_grp_code + " = '" + p.expense_grp_code + "'" +
                "," + expC.expense_grp_name_e + " = '" + p.expense_grp_name_e.Replace("'", "''") + "'" +
                "," + expC.expense_grp_name_t + " = '" + p.expense_grp_name_t.Replace("'", "''") + "'" +
                "," + expC.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + expC.date_modi + " = now()" +
                "," + expC.user_modi + " = '" + userId + "' " +
                "," + expC.sort1 + " = '" + p.sort1 + "' " +
                //"," + tmn.status_app + " = '" + p.status_app + "' " +
                "Where " + expC.pkField + "='" + p.expense_grp_id + "'"
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
        public String insertExpenseGrp(ExpensesGrp p, String userId)
        {
            String re = "";

            if (p.expense_grp_id.Equals(""))
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
                "Where LOWER(expC." + expC.expense_grp_code + ") like '%" + copId.ToLower() + "%' ";
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
                "Where expC." + expC.expense_grp_name_t + " like '%" + copId.ToLower() + "%' ";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count == 1)
            {
                currId = dt.Rows[0][expC.expense_grp_id].ToString();
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
        public ExpensesGrp selectByPk1(String copId)
        {
            ExpensesGrp cop1 = new ExpensesGrp();
            DataTable dt = new DataTable();
            String sql = "select expC.* " +
                "From " + expC.table + " expC " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where expC." + expC.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setExpenseGrp(dt);
            return cop1;
        }
        public ExpensesGrp setExpenseGrp(DataTable dt)
        {
            ExpensesGrp curr1 = new ExpensesGrp();
            if (dt.Rows.Count > 0)
            {
                curr1.expense_grp_id = dt.Rows[0][expC.expense_grp_id].ToString();
                curr1.expense_grp_code = dt.Rows[0][expC.expense_grp_code].ToString();
                curr1.expense_grp_name_e = dt.Rows[0][expC.expense_grp_name_e].ToString();
                curr1.expense_grp_name_t = dt.Rows[0][expC.expense_grp_name_t].ToString();
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
