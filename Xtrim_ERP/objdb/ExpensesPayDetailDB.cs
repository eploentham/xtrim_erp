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
    public class ExpensesPayDetailDB
    {
        public ExpensesPayDetail expnP;
        ConnectDB conn;

        public List<ExpensesPayDetail> lexpn;
        public ExpensesPayDetailDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            expnP = new ExpensesPayDetail();
            expnP.expenses_pay_detail_id = "expenses_pay_detail_id";
            expnP.expenses_pay_id = "expenses_pay_id";
            expnP.item_id = "item_id";
            expnP.status_pay_type = "status_pay_type";
            expnP.active = "active";
            expnP.remark = "remark";
            expnP.user_cancel = "user_cancel";
            expnP.user_create = "user_create";
            expnP.user_modi = "user_modi";
            expnP.date_cancel = "date_cancel";
            expnP.date_create = "date_create";
            expnP.date_modi = "date_modi";
            
            expnP.item_name_t= "item_name_t";
            expnP.job_id= "job_id";
            expnP.pay_amount= "pay_amount";
            expnP.pay_to_cus_id= "pay_to_cus_id";
            expnP.pay_to_cus_name_t= "pay_to_cus_name_t";
            expnP.pay_to_cus_addr= "pay_to_cus_addr";
            expnP.pay_to_cus_tax= "pay_to_cus_tax";
            expnP.pay_cheque_no= "pay_cheque_no";
            expnP.pay_cheque_bank_id= "pay_cheque_bank_id";
            expnP.pay_staff_id= "pay_staff_id";
            expnP.pay_date= "pay_date";
            expnP.comp_bank_id= "comp_bank_id";
            expnP.pay_bank_date= "pay_bank_date";

            expnP.table = "b_expenses_pay_detail";
            expnP.pkField = "expenses_pay_detail_id";

            lexpn = new List<ExpensesPayDetail>();
        }
        public String getIdByName(String name)
        {
            String id = "";
            foreach (ExpensesPayDetail utp1 in lexpn)
            {
                if (name.Trim().Equals(utp1.item_id))
                {
                    id = utp1.expenses_pay_detail_id;
                    break;
                }
            }
            return id;
        }
        public String insert(ExpensesPayDetail p, String userId)
        {
            String re = "", sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            sql = "Insert Into " + expnP.table + "(" + expnP.expenses_pay_id + "," + expnP.item_id + "," + expnP.status_pay_type + "," +
                expnP.active + "," + expnP.remark + ", " + 
                expnP.date_create + ", " + expnP.date_modi + ", " + expnP.date_cancel + "," +
                expnP.user_create + ", " + expnP.user_modi + ", " + expnP.user_cancel + ", " +
                expnP.item_name_t + ", " + expnP.job_id + ", " + expnP.pay_amount + ", " +
                expnP.pay_to_cus_id + ", " + expnP.pay_to_cus_name_t + ", " + expnP.pay_to_cus_addr + ", " +
                expnP.pay_to_cus_tax + ", " + expnP.pay_cheque_no + ", " + expnP.pay_cheque_bank_id + ", " +
                expnP.pay_staff_id + ", " + expnP.pay_date + ", " + expnP.comp_bank_id + ", " +
                expnP.pay_bank_date + ", " +
                ") " +
                "Values ('" + p.expenses_pay_id + "','" + p.item_id + "','" + p.status_pay_type + "'," +
                "'" + p.active + "','" + p.remark + "', " +
                "now() " + p.date_modi + "','" + p.date_cancel + "', " +
                "'" + p.user_create + "','" + p.user_modi + "', " + p.user_cancel + "', " +
                "'" + p.item_name_t + "','" + p.job_id + "', " + p.pay_amount + "', " +
                "'" + p.pay_to_cus_id + "','" + p.pay_to_cus_name_t + "', " + p.pay_to_cus_addr + "', " +
                "'" + p.pay_to_cus_tax + "','" + p.pay_cheque_no + "', " + p.pay_cheque_bank_id + "', " +
                "'" + p.pay_staff_id + "','" + p.pay_date + "', " + p.comp_bank_id + "', " +
                "'" + p.pay_bank_date + "' " +
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
        public String update(ExpensesPayDetail p, String userId)
        {
            String re = "", sql = "";

            sql = "Update " + expnP.table + " Set " +
                " " + expnP.expenses_pay_id + "='" + p.expenses_pay_id + "' " +
                "," + expnP.status_pay_type + "='" + p.status_pay_type.Replace("'", "''") + "' " +
                "," + expnP.item_id + "='" + p.item_id.Replace("'", "''") + "' " +
                "," + expnP.remark + "='" + p.remark.Replace("'", "''") + "' " +
                "," + expnP.date_modi + "=now() " +
                "," + expnP.user_modi + "='" + userId.Replace("'", "''") + "' " +
                "," + expnP.item_name_t + "='" + p.item_name_t.Replace("'", "''") + "' " +
                "," + expnP.job_id + "='" + p.job_id.Replace("'", "''") + "' " +
                "," + expnP.pay_amount + "='" + p.pay_amount.Replace("'", "''") + "' " +
                "," + expnP.pay_to_cus_id + "='" + p.pay_to_cus_id.Replace("'", "''") + "' " +
                "," + expnP.pay_to_cus_name_t + "='" + p.pay_to_cus_name_t.Replace("'", "''") + "' " +
                "," + expnP.pay_to_cus_addr + "='" + p.pay_to_cus_addr.Replace("'", "''") + "' " +
                "," + expnP.pay_to_cus_tax + "='" + p.pay_to_cus_tax.Replace("'", "''") + "' " +
                "," + expnP.pay_cheque_no + "='" + p.pay_cheque_no.Replace("'", "''") + "' " +
                "," + expnP.pay_cheque_bank_id + "='" + p.pay_cheque_bank_id.Replace("'", "''") + "' " +
                "," + expnP.pay_staff_id + "='" + p.pay_staff_id.Replace("'", "''") + "' " +
                "," + expnP.pay_date + "='" + p.pay_date.Replace("'", "''") + "' " +
                "," + expnP.comp_bank_id + "='" + p.comp_bank_id.Replace("'", "''") + "' " +
                "," + expnP.pay_bank_date + "='" + p.pay_bank_date.Replace("'", "''") + "' " +
                "Where " + expnP.expenses_pay_detail_id + "='" + p.expenses_pay_detail_id + "'"
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
        public String insertExpensesPayDetail(ExpensesPayDetail p, String userId)
        {
            String re = "";

            if (p.expenses_pay_detail_id.Equals(""))
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
                "Where " + expnP.expenses_pay_detail_id + "='" + id + "'"
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
            String sql = "select ban." + expnP.expenses_pay_detail_id + "," + expnP.item_id + "," + expnP.remark + " " +
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
                item.Text = row[expnP.item_id].ToString();
                item.Value = row[expnP.expenses_pay_detail_id].ToString();
                c.Items.Add(item);

                ExpensesPayDetail expn1 = new ExpensesPayDetail();
                expn1.expenses_pay_detail_id = row[expnP.expenses_pay_detail_id].ToString();
                expn1.expenses_pay_id = row[expnP.expenses_pay_id].ToString();
                expn1.status_pay_type = row[expnP.status_pay_type].ToString();
                expn1.item_id = row[expnP.item_id].ToString();

                lexpn.Add(expn1);
            }
            return c;
        }
    }
}
