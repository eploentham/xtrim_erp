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
    public class ExpensesPayDB
    {
        public ExpensesPay expnP;
        ConnectDB conn;
        public enum StatusPayType { Cash, Cheque, all };
        StatusPayType spt;

        public List<ExpensesPay> lexpn;
        public ExpensesPayDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            expnP = new ExpensesPay();
            expnP.expenses_pay_id = "expenses_pay_id";
            expnP.expenses_pay_code = "expenses_pay_code";
            expnP.expenses_pay_date = "expenses_pay_date";
            expnP.status_pay_type = "status_pay_type";
            expnP.active = "active";
            expnP.remark = "remark";
            expnP.user_cancel = "user_cancel";
            expnP.user_create = "user_create";
            expnP.user_modi = "user_modi";
            expnP.date_cancel = "date_cancel";
            expnP.date_create = "date_create";
            expnP.date_modi = "date_modi";

            expnP.table = "b_expenses_pay";
            expnP.pkField = "expenses_pay_id";

            lexpn = new List<ExpensesPay>();
        }
        public String getIdByName(String name)
        {
            String id = "";
            foreach (ExpensesPay utp1 in lexpn)
            {
                if (name.Trim().Equals(utp1.expenses_pay_date))
                {
                    id = utp1.expenses_pay_id;
                    break;
                }
            }
            return id;
        }
        private void chkNull(ExpensesPay p)
        {
            int chk = 0;
            Decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            p.expenses_pay_code = p.expenses_pay_code == null ? "" : p.expenses_pay_code;
            p.expenses_pay_date = p.expenses_pay_date == null ? "" : p.expenses_pay_date;
            p.status_pay_type = p.status_pay_type == null ? "" : p.status_pay_type;
            p.remark = p.remark == null ? "" : p.remark;


            //p.amount_reserve = Decimal.TryParse(p.amount_reserve, out chk1) ? chk1.ToString() : "0";
        }
        public String insert(ExpensesPay p, String userId)
        {
            String re = "", sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            chkNull(p);
            sql = "Insert Into " + expnP.table + "(" + expnP.expenses_pay_code + "," + expnP.expenses_pay_date + "," + expnP.status_pay_type + "," +
                expnP.active + "," + expnP.remark + ", " +
                expnP.date_create + ", " + expnP.date_modi + ", " + expnP.date_cancel + ", " +
                expnP.user_create + ", " + expnP.user_modi + ", " + expnP.user_cancel + " " +
                ") " +
                "Values ('" + p.expenses_pay_code + "','" + p.expenses_pay_date + "','" + p.status_pay_type + "'," +
                "'" + p.active + "','" + p.remark + "',  " +
                "now(),'" + p.date_modi + "','" + p.date_cancel + "', " +
                "'" + userId + "','" + p.user_modi + "','" + p.user_cancel + "' " +
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
        public String update(ExpensesPay p, String userId)
        {
            String re = "", sql = "";
            chkNull(p);
            sql = "Update " + expnP.table + " Set " +
                " " + expnP.expenses_pay_code + "='" + p.expenses_pay_code + "' " +
                "," + expnP.status_pay_type + "='" + p.status_pay_type.Replace("'", "''") + "' " +
                "," + expnP.expenses_pay_date + "='" + p.expenses_pay_date.Replace("'", "''") + "' " +
                "," + expnP.remark + "='" + p.remark.Replace("'", "''") + "' " +
                "," + expnP.date_modi + "=now() " +
                "," + expnP.user_modi + "='" + userId.Replace("'", "''") + "' " +
                "Where " + expnP.expenses_pay_id + "='" + p.expenses_pay_id + "'"
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
        public String insertExpensesPay(ExpensesPay p, String userId)
        {
            String re = "";

            if (p.expenses_pay_id.Equals(""))
            {
                re = insert(p, userId);
            }
            else
            {
                re = update(p, userId);
            }
            return re;
        }
        public String voidBank(String id)
        {
            String re = "", sql = "";

            sql = "Update " + expnP.table + " Set " +
                " " + expnP.active + "='3' " +
                "," + expnP.date_cancel + "=now() " +
                "Where " + expnP.expenses_pay_id + "='" + id + "'"
                ;
            re = conn.ExecuteNonQuery(conn.conn, sql);

            return re;
        }

        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select ban.*  " +
                "From " + expnP.table + " ban " +
                " " +
                "Where ban." + expnP.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectAll1()
        {
            DataTable dt = new DataTable();
            String sql = "select ban." + expnP.expenses_pay_id + "," + expnP.expenses_pay_date + "," + expnP.remark + " " +
                "From " + expnP.table + " ban " +
                " " +
                "Where ban." + expnP.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public C1ComboBox setC1CboItem(C1ComboBox c)
        {
            lexpn.Clear();
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
                item.Text = row[expnP.expenses_pay_date].ToString();
                item.Value = row[expnP.expenses_pay_id].ToString();
                c.Items.Add(item);

                ExpensesPay expn1 = new ExpensesPay();
                expn1.expenses_pay_id = row[expnP.expenses_pay_id].ToString();
                expn1.expenses_pay_code = row[expnP.expenses_pay_code].ToString();
                expn1.status_pay_type = row[expnP.status_pay_type].ToString();
                expn1.expenses_pay_date = row[expnP.expenses_pay_date].ToString();

                lexpn.Add(expn1);
            }
            return c;
        }
    }
}
