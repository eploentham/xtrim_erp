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
    public class ExpensesDrawDB
    {
        public ExpensesDraw expnC;
        ConnectDB conn;

        public List<ExpensesDraw> lexpnC;
        public ExpensesDrawDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            expnC = new ExpensesDraw();
            expnC.expenses_draw_id = "expenses_draw_id";
            expnC.expenses_draw_date = "expenses_draw_date";
            expnC.job_id = "job_id";
            expnC.job_code = "job_code";
            expnC.draw_date = "draw_date";
            expnC.staff_id = "staff_id";

            expnC.active = "active";
            expnC.date_create = "date_create";
            expnC.date_modi = "date_modi";
            expnC.date_cancel = "date_cancel";
            expnC.user_create = "user_create";
            expnC.user_modi = "user_modi";
            expnC.user_cancel = "user_cancel";
            expnC.expenses_draw_code = "expenses_draw_code";
            expnC.remark = "remark";
            expnC.desc1 = "desc1";
            expnC.status_appv = "status_appv";
            expnC.status_email = "status_email";
            expnC.amount = "amount";
            expnC.year = "year";
            expnC.appv_amount = "appv_amount";
            expnC.appv_desc = "appv_desc";
            expnC.status_pay = "status_pay";


            expnC.table = "t_expenses_draw";
            expnC.pkField = "expenses_draw_id";

            lexpnC = new List<ExpensesDraw>();
        }
        public void getlexpnC()
        {
            //lDept = new List<Department>();

            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                ExpensesDraw curr1 = new ExpensesDraw();
                curr1.expenses_draw_id = row[expnC.expenses_draw_id].ToString();
                curr1.expenses_draw_date = row[expnC.expenses_draw_date].ToString();
                curr1.expenses_draw_code = row[expnC.expenses_draw_code].ToString();
                curr1.job_code = row[expnC.job_code].ToString();
                lexpnC.Add(curr1);
            }
        }
        public String getIdByCode(String code)
        {
            String id = "";
            foreach (ExpensesDraw curr1 in lexpnC)
            {
                if (code.Trim().Equals(curr1.expenses_draw_code))
                {
                    id = curr1.expenses_draw_id;
                    break;
                }
            }
            return id;
        }
        public String getIdByName(String name)
        {
            String id = "";
            foreach (ExpensesDraw curr1 in lexpnC)
            {
                if (name.Trim().Equals(curr1.expenses_draw_code))
                {
                    id = curr1.expenses_draw_id;
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
            foreach (ExpensesDraw cus1 in lexpnC)
            {
                item = new ComboBoxItem();
                item.Value = cus1.expenses_draw_id;
                item.Text = cus1.expenses_draw_code;
                c.Items.Add(item);
                if (item.Value.Equals(selected))
                {
                    c.SelectedText = item.Text;
                }
            }
        }
        private void chkNull(ExpensesDraw p)
        {
            int chk = 0;
            Decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            p.expenses_draw_date = p.expenses_draw_date == null ? "" : p.expenses_draw_date;
            p.job_code = p.job_code == null ? "" : p.job_code;
            p.draw_date = p.draw_date == null ? "" : p.draw_date;
            p.remark = p.remark == null ? "" : p.remark;
            p.expenses_draw_code = p.expenses_draw_code == null ? "" : p.expenses_draw_code;
            p.desc1 = p.desc1 == null ? "" : p.desc1;
            p.status_appv = p.status_appv == null ? "" : p.status_appv;
            p.status_email = p.status_email == null ? "" : p.status_email;
            p.status_pay = p.status_pay == null ? "" : p.status_pay;

            p.year = p.year == null ? "" : p.year;
            p.appv_desc = p.appv_desc == null ? "" : p.appv_desc;
            

            p.job_id = int.TryParse(p.job_id, out chk) ? chk.ToString() : "0";
            p.staff_id = int.TryParse(p.staff_id, out chk) ? chk.ToString() : "0";
            //p.job_code = int.TryParse(p.job_code, out chk) ? chk.ToString() : "0";
            

            p.amount = Decimal.TryParse(p.amount, out chk1) ? chk1.ToString() : "0";
            p.appv_amount = Decimal.TryParse(p.appv_amount, out chk1) ? chk1.ToString() : "0";
            
        }
        public String insert(ExpensesDraw p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            //p.prefix_id = int.TryParse(p.prefix_id, out chk) ? chk.ToString() : "0";
            //p.dept_id = int.TryParse(p.dept_id, out chk) ? chk.ToString() : "0";

            sql = "Insert Into " + expnC.table + "(" + expnC.expenses_draw_date + "," + expnC.expenses_draw_code + "," + expnC.job_id + "," +
                expnC.date_create + "," + expnC.date_modi + "," + expnC.date_cancel + "," +
                expnC.user_create + "," + expnC.user_modi + "," + expnC.user_cancel + "," +
                expnC.active + "," + expnC.remark + ", " + expnC.job_code + ", " +
                expnC.draw_date + "," + expnC.staff_id + "," + expnC.desc1 + ", " +
                expnC.status_email + "," + expnC.status_appv + "," + expnC.amount + ", " +
                expnC.year + "," + expnC.status_pay + " " +

                ") " +
                "Values ('" + p.expenses_draw_date + "','" + p.expenses_draw_code.Replace("'", "''") + "','" + p.job_id.Replace("'", "''") + "'," +
                "'" + p.date_create + "','" + p.date_modi + "','" + p.date_cancel + "'," +
                "'" + userId + "','" + p.user_modi + "','" + p.user_cancel + "'," +
                "'" + p.active + "','" + p.remark.Replace("'", "''") + "','" + p.job_code + "', " +
                "'" + p.draw_date + "','" + p.staff_id.Replace("'", "''") + "','" + p.desc1.Replace("'", "''") + "', " +
                "'" + p.status_email + "','" + p.status_appv.Replace("'", "''") + "','" + p.amount + "', " +
                "'" + p.year + "','" + p.status_pay + "' " +
                
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
        public String update(ExpensesDraw p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);

            sql = "Update " + expnC.table + " Set " +
                " " + expnC.expenses_draw_date + " = '" + p.expenses_draw_date + "'" +
                "," + expnC.job_id + " = '" + p.job_id.Replace("'", "''") + "'" +
                "," + expnC.job_code + " = '" + p.job_code.Replace("'", "''") + "'" +
                "," + expnC.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + expnC.date_modi + " = now()" +
                "," + expnC.user_modi + " = '" + userId + "' " +
                "," + expnC.draw_date + " = '" + p.draw_date + "' " +
                "," + expnC.staff_id + " = '" + p.staff_id + "' " +
                "," + expnC.expenses_draw_code + " = '" + p.expenses_draw_code + "' " +
                "," + expnC.desc1 + " = '" + p.desc1 + "' " +
                "," + expnC.status_email + " = '" + p.status_email + "' " +
                "," + expnC.status_appv + " = '" + p.status_appv + "' " +
                "," + expnC.amount + " = '" + p.amount + "' " +
                "," + expnC.year + " = '" + p.year + "' " +
                "," + expnC.status_pay + " = '" + p.status_pay + "' " +
                "Where " + expnC.pkField + "='" + p.expenses_draw_id + "'"
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
        
        public String insertExpenseDraw(ExpensesDraw p, String userId)
        {
            String re = "";

            if (p.expenses_draw_id.Equals(""))
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
        public String updateSendToApprove(String doc ,String id)
        {
            DataTable dt = new DataTable();
            String re = "";
            
            String sql = "update " + expnC.table+" Set " +
                ""+expnC.expenses_draw_code+"='"+doc+"' " +
                "," + expnC.status_appv + "='1' " +
                "Where " +expnC.pkField+"='"+id+"'";
            re = conn.ExecuteNonQuery(conn.conn, sql);

            return re;
        }
        public String updateStatusApprove(String id)
        {
            DataTable dt = new DataTable();
            String re = "";

            String sql = "update " + expnC.table + " Set " +                
                "" + expnC.status_appv + "='2' " +
                "Where " + expnC.pkField + "='" + id + "'";
            re = conn.ExecuteNonQuery(conn.conn, sql);

            return re;
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
        public DataTable selectAll(String year)
        {
            DataTable dt = new DataTable();
            String sql = "select expC.*  " +
                "From " + expnC.table + " expC " +
                " " +
                "Where expC." + expnC.active + " ='1' and "+expnC.year + "='"+year+"'";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectAll1(String year)
        {
            DataTable dt = new DataTable();
            String sql = "select expC."+expnC.expenses_draw_id+","+expnC.expenses_draw_code+","+expnC.desc1+","+expnC.remark+","+expnC.amount+","+expnC.status_appv+ " " +
                "From " + expnC.table + " expC " +
                " " +
                "Where expC." + expnC.active + " ='1' and " + expnC.year + "='" + year + "'";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByJobCode(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select expC.* " +
                "From " + expnC.table + " expC " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where expC." + expnC.job_code + " = '" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByJobCode2(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select expC."+expnC.expenses_draw_id + ",expC." + expnC.expenses_draw_code + ",expC." + expnC.desc1 + ",expC." + expnC.amount+ ",expC." + expnC.remark +" "+
                "From " + expnC.table + " expC " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where expC." + expnC.job_code + " = '" + copId + "' ";
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
                "Where expC." + expnC.expenses_draw_code + " like '%" + copId.ToLower() + "%' ";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count == 1)
            {
                currId = dt.Rows[0][expnC.expenses_draw_id].ToString();
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
        public ExpensesDraw selectByPk1(String copId)
        {
            ExpensesDraw cop1 = new ExpensesDraw();
            DataTable dt = new DataTable();
            String sql = "select expC.* " +
                "From " + expnC.table + " expC " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where expC." + expnC.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setExpenseDraw(dt);
            return cop1;
        }
        public ExpensesDraw setExpenseDraw(DataTable dt)
        {
            ExpensesDraw curr1 = new ExpensesDraw();
            if (dt.Rows.Count > 0)
            {
                curr1.expenses_draw_id = dt.Rows[0][expnC.expenses_draw_id].ToString();
                curr1.expenses_draw_date = dt.Rows[0][expnC.expenses_draw_date].ToString();
                curr1.job_id = dt.Rows[0][expnC.job_id].ToString();
                curr1.job_code = dt.Rows[0][expnC.job_code].ToString();
                curr1.active = dt.Rows[0][expnC.active].ToString();
                curr1.date_cancel = dt.Rows[0][expnC.date_cancel].ToString();
                curr1.date_create = dt.Rows[0][expnC.date_create].ToString();
                curr1.date_modi = dt.Rows[0][expnC.date_modi].ToString();
                curr1.user_cancel = dt.Rows[0][expnC.user_cancel].ToString();
                curr1.user_create = dt.Rows[0][expnC.user_create].ToString();
                curr1.user_modi = dt.Rows[0][expnC.user_modi].ToString();
                curr1.desc1 = dt.Rows[0][expnC.desc1].ToString();
                curr1.remark = dt.Rows[0][expnC.remark].ToString();
                curr1.draw_date = dt.Rows[0][expnC.draw_date].ToString();
                curr1.staff_id = dt.Rows[0][expnC.staff_id].ToString();
                curr1.expenses_draw_code = dt.Rows[0][expnC.expenses_draw_code].ToString();
                curr1.status_appv = dt.Rows[0][expnC.status_appv].ToString();
                curr1.status_email = dt.Rows[0][expnC.status_email].ToString();
                curr1.amount = dt.Rows[0][expnC.amount].ToString();
                curr1.year = dt.Rows[0][expnC.year].ToString();
                curr1.status_pay = dt.Rows[0][expnC.status_pay].ToString();

            }
            else
            {
                curr1.expenses_draw_id = "";
                curr1.expenses_draw_date = "";
                curr1.job_id = "";
                curr1.job_code = "";
                curr1.draw_date = "";
                curr1.staff_id = "";

                curr1.active = "";
                curr1.date_create = "";
                curr1.date_modi = "";
                curr1.date_cancel = "";
                curr1.user_create = "";
                curr1.user_modi = "";
                curr1.user_cancel = "";
                curr1.expenses_draw_code = "";
                curr1.remark = "";
                curr1.desc1 = "";
                curr1.status_appv = "";
                curr1.status_email = "";
                curr1.amount = "";
                curr1.year = "";
                curr1.appv_amount = "";
                curr1.appv_desc = "";
                curr1.status_pay = "";
            }

            return curr1;
        }
    }
}
