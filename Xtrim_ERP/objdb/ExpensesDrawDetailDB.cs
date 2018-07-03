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
    public class ExpensesDrawDetailDB
    {
        public ExpensesDrawDatail expnC;
        ConnectDB conn;

        public List<ExpensesDrawDatail> lexpnC;
        public ExpensesDrawDetailDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            expnC = new ExpensesDrawDatail();
            expnC.expenses_draw_detail_id = "expenses_draw_detail_id";
            expnC.desc1 = "desc1";
            expnC.desc2 = "desc2";
            expnC.amount = "amount";
            //tmn.status_app = "status_app";
            expnC.sort1 = "sort1";

            expnC.active = "active";
            expnC.date_create = "date_create";
            expnC.date_modi = "date_modi";
            expnC.date_cancel = "date_cancel";
            expnC.user_create = "user_create";
            expnC.user_modi = "user_modi";
            expnC.user_cancel = "user_cancel";
            expnC.expense_draw_id = "expenses_draw_id";
            expnC.remark = "remark";
            expnC.expense_type_id = "expenses_type_id";

            expnC.status_pay = "status_pay";
            expnC.status_pay_type = "status_pay_type";
            expnC.pay_amount = "pay_amount";
            expnC.pay_date = "pay_date";
            expnC.pay_cheque_no = "pay_cheque_no";
            expnC.comp_bank_id = "comp_bank_id";
            expnC.pay_staff_id = "pay_staff_id";
            expnC.item_id = "item_id";
            expnC.pay_bank_date = "pay_bank_date";
            expnC.job_id = "job_id";
            expnC.job_code = "job_code";
            expnC.qty = "qty";
            expnC.price = "price";
            expnC.unit_id = "unit_id";
            expnC.wtax1 = "wtax1";
            expnC.wtax3 = "wtax3";
            expnC.vat = "vat";
            expnC.total = "total";
            expnC.item_name_t = "item_name_t";
            expnC.unit_name_t = "unit_name_t";
            expnC.pay_to_cus_id = "pay_to_cus_id";
            expnC.pay_to_cus_name_t = "pay_to_cus_name_t";
            expnC.pay_to_cus_addr = "pay_to_cus_addr";
            expnC.pay_to_cus_tax = "pay_to_cus_tax";
            expnC.receipt_no = "receipt_no";
            expnC.receipt_date = "receipt_date";
            expnC.expenses_pay_detail_id = "expenses_pay_detail_id";

            expnC.table = "t_expenses_draw_detail";
            expnC.pkField = "expenses_draw_detail_id";

            lexpnC = new List<ExpensesDrawDatail>();
        }
        public void getlexpnC()
        {
            //lDept = new List<Department>();

            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                ExpensesDrawDatail curr1 = new ExpensesDrawDatail();
                curr1.expenses_draw_detail_id = row[expnC.expenses_draw_detail_id].ToString();
                curr1.desc1 = row[expnC.desc1].ToString();
                curr1.desc2 = row[expnC.desc2].ToString();
                curr1.amount = row[expnC.amount].ToString();
                lexpnC.Add(curr1);
            }
        }
        public String getIdByCode(String code)
        {
            String id = "";
            foreach (ExpensesDrawDatail curr1 in lexpnC)
            {
                if (code.Trim().Equals(curr1.desc1))
                {
                    id = curr1.expenses_draw_detail_id;
                    break;
                }
            }
            return id;
        }
        public String getIdByName(String name)
        {
            String id = "";
            foreach (ExpensesDrawDatail curr1 in lexpnC)
            {
                if (name.Trim().Equals(curr1.amount))
                {
                    id = curr1.expenses_draw_detail_id;
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
            foreach (ExpensesDrawDatail cus1 in lexpnC)
            {
                item = new ComboBoxItem();
                item.Value = cus1.expenses_draw_detail_id;
                item.Text = cus1.amount;
                c.Items.Add(item);
                if (item.Value.Equals(selected))
                {
                    c.SelectedText = item.Text;
                }
            }
        }
        private void chkNull(ExpensesDrawDatail p)
        {
            int chk = 0;
            Decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            p.desc1 = p.desc1 == null ? "" : p.desc1;
            p.desc2 = p.desc2 == null ? "" : p.desc2;
            //p.amount = p.amount == null ? "" : p.amount;
            p.remark = p.remark == null ? "" : p.remark;
            p.sort1 = p.sort1 == null ? "" : p.sort1;
            p.status_pay = p.status_pay == null ? "" : p.status_pay;
            p.status_pay_type = p.status_pay_type == null ? "" : p.status_pay_type;
            p.pay_date = p.pay_date == null ? "" : p.pay_date;
            p.pay_cheque_no = p.pay_cheque_no == null ? "" : p.pay_cheque_no;
            p.pay_bank_date = p.pay_bank_date == null ? "" : p.pay_bank_date;
            p.job_code = p.job_code == null ? "" : p.job_code;
            p.item_name_t = p.item_name_t == null ? "" : p.item_name_t;
            p.unit_name_t = p.unit_name_t == null ? "" : p.unit_name_t;
            p.pay_to_cus_name_t = p.pay_to_cus_name_t == null ? "" : p.pay_to_cus_name_t;
            p.pay_to_cus_addr = p.pay_to_cus_addr == null ? "" : p.pay_to_cus_addr;
            p.pay_to_cus_tax = p.pay_to_cus_tax == null ? "" : p.pay_to_cus_tax;
            p.receipt_no = p.receipt_no == null ? "" : p.receipt_no;
            p.receipt_date = p.receipt_date == null ? "" : p.receipt_date;

            p.expense_draw_id = int.TryParse(p.expense_draw_id, out chk) ? chk.ToString() : "0";
            p.expense_type_id = int.TryParse(p.expense_type_id, out chk) ? chk.ToString() : "0";
            p.comp_bank_id = int.TryParse(p.comp_bank_id, out chk) ? chk.ToString() : "0";
            p.item_id = int.TryParse(p.item_id, out chk) ? chk.ToString() : "0";
            p.pay_staff_id = int.TryParse(p.pay_staff_id, out chk) ? chk.ToString() : "0";
            p.job_id = int.TryParse(p.job_id, out chk) ? chk.ToString() : "0";
            p.unit_id = int.TryParse(p.unit_id, out chk) ? chk.ToString() : "0";
            p.pay_to_cus_id = int.TryParse(p.pay_to_cus_id, out chk) ? chk.ToString() : "0";
            p.expenses_pay_detail_id = int.TryParse(p.expenses_pay_detail_id, out chk) ? chk.ToString() : "0";

            p.amount = Decimal.TryParse(p.amount, out chk1) ? chk1.ToString() : "0";
            p.pay_amount = Decimal.TryParse(p.pay_amount, out chk1) ? chk1.ToString() : "0";
            p.qty = Decimal.TryParse(p.qty, out chk1) ? chk1.ToString() : "0";
            p.price = Decimal.TryParse(p.price, out chk1) ? chk1.ToString() : "0";
            p.wtax1 = Decimal.TryParse(p.wtax1, out chk1) ? chk1.ToString() : "0";
            p.wtax3 = Decimal.TryParse(p.wtax3, out chk1) ? chk1.ToString() : "0";
            p.vat = Decimal.TryParse(p.vat, out chk1) ? chk1.ToString() : "0";
            p.total = Decimal.TryParse(p.total, out chk1) ? chk1.ToString() : "0";
        }
        public String insert(ExpensesDrawDatail p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            //p.prefix_id = int.TryParse(p.prefix_id, out chk) ? chk.ToString() : "0";
            //p.dept_id = int.TryParse(p.dept_id, out chk) ? chk.ToString() : "0";
            p.status_pay = "1";

            sql = "Insert Into " + expnC.table + "(" + expnC.desc1 + "," + expnC.desc2 + "," + expnC.amount + "," +
                expnC.date_create + "," + expnC.date_modi + "," + expnC.date_cancel + "," +
                expnC.user_create + "," + expnC.user_modi + "," + expnC.user_cancel + "," +
                expnC.active + "," + expnC.remark + ", " + expnC.sort1 + "," +
                expnC.expense_draw_id + "," + expnC.expense_type_id + "," + expnC.status_pay + "," +
                expnC.status_pay_type + "," + expnC.pay_amount + "," + expnC.pay_date + ", " +
                expnC.pay_cheque_no + "," + expnC.comp_bank_id + "," + expnC.pay_staff_id + ", " +
                expnC.item_id + "," + expnC.pay_bank_date + "," + expnC.job_id + "," +
                expnC.job_code + "," + expnC.qty + "," + expnC.price + "," +
                expnC.unit_id + "," + expnC.wtax1 + "," + expnC.wtax3 + "," +
                expnC.vat + "," + expnC.total + "," + expnC.item_name_t + "," +
                expnC.unit_name_t + ", " + expnC.expenses_pay_detail_id + ", " +
                expnC.pay_to_cus_id + "," + expnC.pay_to_cus_name_t + "," + expnC.pay_to_cus_addr + "," +
                expnC.pay_to_cus_tax + "," + expnC.receipt_no + "," + expnC.receipt_date + " " +
                ") " +
                "Values ('" + p.desc1.Replace("'", "''") + "','" + p.desc2.Replace("'", "''") + "','" + p.amount + "'," +
                "'" + p.date_create + "','" + p.date_modi + "','" + p.date_cancel + "'," +
                "'" + userId + "','" + p.user_modi + "','" + p.user_cancel + "'," +
                "'" + p.active + "','" + p.remark.Replace("'", "''") + "','" + p.sort1 + "', " +
                "'" + p.expense_draw_id + "','" + p.expense_type_id.Replace("'", "''") + "','" + p.status_pay + "'," +
                "'" + p.status_pay_type + "','" + p.pay_amount.Replace("'", "''") + "','" + p.pay_date + "', " +
                "'" + p.pay_cheque_no + "','" + p.comp_bank_id.Replace("'", "''") + "','" + p.pay_staff_id + "', " +
                "'" + p.item_id + "','" + p.pay_bank_date.Replace("'", "''") + "','" + p.job_id + "', " +
                "'" + p.job_code + "','" + p.qty + "','" + p.price + "'," +
                "'" + p.unit_id + "','" + p.wtax1 + "','" + p.wtax3 + "'," +
                "'" + p.vat + "','" + p.total + "','" + p.item_name_t + "'," +
                "'" + p.unit_name_t + "','" + p.expenses_pay_detail_id + "'," +
                "'" + p.pay_to_cus_id + "','" + p.pay_to_cus_name_t + "','" + p.pay_to_cus_addr + "'," +
                "'" + p.pay_to_cus_tax + "','" + p.receipt_no + "','" + p.receipt_date + "' " +
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
        public String update(ExpensesDrawDatail p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);

            sql = "Update " + expnC.table + " Set " +
                " " + expnC.desc1 + " = '" + p.desc1.Replace("'", "''") + "'" +
                "," + expnC.desc2 + " = '" + p.desc2.Replace("'", "''") + "'" +
                "," + expnC.amount + " = '" + p.amount + "'" +
                "," + expnC.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + expnC.date_modi + " = now()" +
                "," + expnC.user_modi + " = '" + userId + "' " +
                "," + expnC.sort1 + " = '" + p.sort1 + "' " +
                "," + expnC.expense_draw_id + " = '" + p.expense_draw_id + "' " +
                "," + expnC.expense_type_id + " = '" + p.expense_type_id + "' " +
                "," + expnC.job_code + " = '" + p.job_code + "' " +
                "," + expnC.job_id + " = '" + p.job_id + "' " +
                "," + expnC.qty + " = '" + p.qty + "' " +
                "," + expnC.price + " = '" + p.price + "' " +
                "," + expnC.unit_id + " = '" + p.unit_id + "' " +
                "," + expnC.wtax1 + " = '" + p.wtax1 + "' " +
                "," + expnC.wtax3 + " = '" + p.wtax3 + "' " +
                "," + expnC.vat + " = '" + p.vat + "' " +
                "," + expnC.total + " = '" + p.total + "' " +
                "," + expnC.item_name_t + " = '" + p.item_name_t + "' " +
                "," + expnC.unit_name_t + " = '" + p.unit_name_t + "' " +
                "," + expnC.pay_to_cus_id + " = '" + p.pay_to_cus_id + "' " +
                "," + expnC.pay_to_cus_name_t + " = '" + p.pay_to_cus_name_t + "' " +
                "," + expnC.pay_to_cus_addr + " = '" + p.pay_to_cus_addr + "' " +
                "," + expnC.pay_to_cus_tax + " = '" + p.pay_to_cus_tax + "' " +
                "," + expnC.receipt_no + " = '" + p.receipt_no + "' " +
                "," + expnC.receipt_date + " = '" + p.receipt_date + "' " +
                "Where " + expnC.pkField + "='" + p.expenses_draw_detail_id + "'"
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
        public String updatePay(ExpensesDrawDatail p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);

            sql = "Update " + expnC.table + " Set " +
                //" " + expnC.status_pay_type + " = '" + p.status_pay_type + "'" +
                " " + expnC.pay_amount + " = '" + p.pay_amount.Replace("'", "''") + "'" +
                "," + expnC.pay_date + " = '" + p.pay_date.Replace("'", "''") + "'" +
                "," + expnC.pay_cheque_no + " = '" + p.pay_cheque_no.Replace("'", "''") + "'" +
                "," + expnC.date_modi + " = now()" +
                "," + expnC.user_modi + " = '" + userId + "' " +
                "," + expnC.comp_bank_id + " = '" + p.comp_bank_id + "' " +
                "," + expnC.pay_staff_id + " = '" + p.pay_staff_id + "' " +
                //"," + expnC.item_id + " = '" + p.item_id + "' " +
                "," + expnC.pay_bank_date + " = '" + p.pay_bank_date + "' " +
                "," + expnC.expenses_pay_detail_id + " = '" + p.expenses_pay_detail_id + "' " +
                "," + expnC.status_pay + " = '2' " +
                "Where " + expnC.pkField + "='" + p.expenses_draw_detail_id + "'";

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
        public String insertExpenseDrawDetail(ExpensesDrawDatail p, String userId)
        {
            String re = "";

            if (p.expenses_draw_detail_id.Equals(""))
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
                "Where LOWER(expC." + expnC.desc1 + ") like '%" + copId.ToLower() + "%' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByDrawId(String copId)
        {
            String currId = "";
            DataTable dt = new DataTable();
            String sql = "select expC.* " +
                "From " + expnC.table + " expC " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where expC." + expnC.expense_draw_id + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);            
            return dt;
        }
        public DataTable selectChequeByDrawId1(String copId)
        {
            String currId = "";
            DataTable dt = new DataTable();
            String sql = "select expC."+expnC.expenses_draw_detail_id+","+expnC.item_id+","+expnC.item_name_t+","+expnC.qty+","+expnC.unit_id+","+expnC.unit_name_t+","+expnC.price+
                ","+expnC.amount+","+expnC.wtax1+","+expnC.wtax3+","+expnC.vat+","+expnC.remark+","+expnC.total+","+expnC.pay_to_cus_id+","+expnC.pay_to_cus_name_t+","+expnC.pay_to_cus_addr +
                ","+expnC.pay_to_cus_tax+","+expnC.receipt_date+","+expnC.receipt_no+" "+
                "From " + expnC.table + " expC " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where expC." + expnC.expense_draw_id + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectCashByDrawId1(String copId)
        {
            String currId = "";
            DataTable dt = new DataTable();
            String sql = "select expC." + expnC.expenses_draw_detail_id + "," + expnC.item_id + "," + expnC.item_name_t + "," + expnC.qty + "," + expnC.unit_id + "," + expnC.unit_name_t + "," + expnC.price +
                "," + expnC.amount + "," + expnC.wtax1 + "," + expnC.wtax3 + "," + expnC.vat + "," + expnC.remark + "," + expnC.total + " " + 
                "From " + expnC.table + " expC " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where expC." + expnC.expense_draw_id + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
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
        public String selectStatusPayByDrawId(String copId)
        {
            DataTable dt = new DataTable();
            String re = "";
            String sql = "select expC.* " +
                "From " + expnC.table + " expC " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where expC." + expnC.expense_draw_id + " ='" + copId + "' and "+expnC.status_pay+"='1'";
            dt = conn.selectData(conn.conn, sql);
            re = dt.Rows.Count.ToString();
            return re;
        }
        public DataTable selectByChequeAppv(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select edd.expenses_draw_detail_id, itmts.item_type_sub_name_t, fmtp.f_method_payment_name_t, itm.item_name_t, ed.draw_date , edd.amount " +
                "from t_expenses_draw_detail edd " +
                "inner join t_expenses_draw ed on ed.expenses_draw_id = edd.expenses_draw_id " +
                "inner join b_items itm on edd.item_id = itm.item_id " +
                "inner join b_items_type_sub itmts on itm.item_type_sub_id = itmts.item_type_sub_id " +
                "inner join f_method_payment fmtp on itm.f_method_payment_id = fmtp.f_method_payment_id " +
                "where fmtp.f_method_payment_id = '1560000000' and ed.status_appv = '"+ copId + "' and edd.status_pay <> '2' " +
                "Order By edd.expenses_draw_detail_id ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByCashAppv(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select edd.expenses_draw_detail_id, itmts.item_type_sub_name_t, fmtp.f_method_payment_name_t, itm.item_name_t, ed.draw_date , edd.amount " +
                "from t_expenses_draw_detail edd " +
                "inner join t_expenses_draw ed on ed.expenses_draw_id = edd.expenses_draw_id " +
                "inner join b_items itm on edd.item_id = itm.item_id " +
                "inner join b_items_type_sub itmts on itm.item_type_sub_id = itmts.item_type_sub_id " +
                "inner join f_method_payment fmtp on itm.f_method_payment_id = fmtp.f_method_payment_id " +
                "where fmtp.f_method_payment_id = '1560000001' and ed.status_appv = '" + copId + "' and edd.status_pay <> '2' " +
                "Order By edd.expenses_draw_detail_id ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public ExpensesDrawDatail selectByPk1(String copId)
        {
            ExpensesDrawDatail cop1 = new ExpensesDrawDatail();
            DataTable dt = new DataTable();
            String sql = "select expC.* " +
                "From " + expnC.table + " expC " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where expC." + expnC.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setExpenseDrawDetail(dt);
            return cop1;
        }
        public ExpensesDrawDatail setExpenseDrawDetail(DataTable dt)
        {
            ExpensesDrawDatail curr1 = new ExpensesDrawDatail();
            if (dt.Rows.Count > 0)
            {
                curr1.expenses_draw_detail_id = dt.Rows[0][expnC.expenses_draw_detail_id].ToString();
                curr1.desc1 = dt.Rows[0][expnC.desc1].ToString();
                curr1.desc2 = dt.Rows[0][expnC.desc2].ToString();
                curr1.amount = dt.Rows[0][expnC.amount].ToString();
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
                curr1.expense_draw_id = dt.Rows[0][expnC.expense_draw_id].ToString();
                curr1.expense_type_id = dt.Rows[0][expnC.expense_type_id].ToString();

                curr1.status_pay = dt.Rows[0][expnC.status_pay].ToString();
                curr1.status_pay_type = dt.Rows[0][expnC.status_pay_type].ToString();
                curr1.pay_amount = dt.Rows[0][expnC.pay_amount].ToString();
                curr1.pay_date = dt.Rows[0][expnC.pay_date].ToString();
                curr1.pay_cheque_no = dt.Rows[0][expnC.pay_cheque_no].ToString();
                curr1.comp_bank_id = dt.Rows[0][expnC.comp_bank_id].ToString();
                curr1.pay_staff_id = dt.Rows[0][expnC.pay_staff_id].ToString();
                curr1.item_id = dt.Rows[0][expnC.item_id].ToString();
                curr1.pay_bank_date = dt.Rows[0][expnC.pay_bank_date].ToString();
                curr1.job_id = dt.Rows[0][expnC.job_id].ToString();
                curr1.job_code = dt.Rows[0][expnC.job_code].ToString();
                curr1.qty = dt.Rows[0][expnC.qty].ToString();
                curr1.price = dt.Rows[0][expnC.price].ToString();
                curr1.unit_id = dt.Rows[0][expnC.unit_id].ToString();
                curr1.wtax1 = dt.Rows[0][expnC.wtax1].ToString();
                curr1.wtax3 = dt.Rows[0][expnC.wtax3].ToString();
                curr1.vat = dt.Rows[0][expnC.vat].ToString();
                curr1.total = dt.Rows[0][expnC.total].ToString();
                curr1.item_name_t = dt.Rows[0][expnC.item_name_t].ToString();
                curr1.unit_name_t = dt.Rows[0][expnC.unit_name_t].ToString();
                curr1.pay_to_cus_id = dt.Rows[0][expnC.pay_to_cus_id].ToString();
                curr1.pay_to_cus_name_t = dt.Rows[0][expnC.pay_to_cus_name_t].ToString();
                curr1.pay_to_cus_addr = dt.Rows[0][expnC.pay_to_cus_addr].ToString();
                curr1.pay_to_cus_tax = dt.Rows[0][expnC.pay_to_cus_tax].ToString();
                curr1.receipt_no = dt.Rows[0][expnC.receipt_no].ToString();
                curr1.receipt_date = dt.Rows[0][expnC.receipt_date].ToString();
            }
            else
            {
                curr1.expenses_draw_detail_id = "";
                curr1.desc1 = "";
                curr1.desc2 = "";
                curr1.amount = "";
                //tmn.status_app = "status_app";
                curr1.sort1 = "";

                curr1.active = "";
                curr1.date_create = "";
                curr1.date_modi = "";
                curr1.date_cancel = "";
                curr1.user_create = "";
                curr1.user_modi = "";
                curr1.user_cancel = "";
                curr1.expense_draw_id = "";
                curr1.remark = "";
                curr1.expense_type_id = "";

                curr1.status_pay = "";
                curr1.status_pay_type = "";
                curr1.pay_amount = "";
                curr1.pay_date = "";
                curr1.pay_cheque_no = "";
                curr1.comp_bank_id = "";
                curr1.pay_staff_id = "";
                curr1.item_id = "";
                curr1.pay_bank_date = "";
                curr1.job_id = "";
                curr1.job_code = "";
                curr1.qty = "";
                curr1.price = "";
                curr1.unit_id = "";
                curr1.wtax1 = "";
                curr1.wtax3 = "";
                curr1.vat = "";
                curr1.total = "";
                curr1.item_name_t = "";
                curr1.unit_name_t = "";
                curr1.pay_to_cus_id = "";
                curr1.pay_to_cus_name_t = "";
                curr1.pay_to_cus_addr = "";
                curr1.pay_to_cus_tax = "";
                curr1.receipt_no = "";
                curr1.receipt_date = "";
            }

            return curr1;
        }
    }
}
