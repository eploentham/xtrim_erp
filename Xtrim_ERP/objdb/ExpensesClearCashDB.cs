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
    public class ExpensesClearCashDB
    {
        public ExpensesClearCash ecc;
        ConnectDB conn;

        public List<ExpensesClearCash> lecc;
        public enum StatusPay { waitappv, appv, all };
        public enum StatusAppv { sendtoAppv, Appv, All };
        public enum StatusPage { AppvPay, SaveViewOnly };
        public ExpensesClearCashDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            ecc = new ExpensesClearCash();
            ecc.expense_clear_cash_id = "expense_clear_cash_id";
            ecc.expenses_pay_detail_id = "expenses_pay_detail_id";
            ecc.job_id = "job_id";
            ecc.job_code = "job_code";
            ecc.expenses_draw_detail_id = "expenses_draw_detail_id";
            ecc.staff_id = "staff_id";

            ecc.active = "active";
            ecc.date_create = "date_create";
            ecc.date_modi = "date_modi";
            ecc.date_cancel = "date_cancel";
            ecc.user_create = "user_create";
            ecc.user_modi = "user_modi";
            ecc.user_cancel = "user_cancel";

            ecc.expenses_draw_id = "expenses_draw_id";
            ecc.remark = "remark";
            ecc.ecc_doc = "ecc_doc";
            ecc.expense_clear_cash_date = "expense_clear_cash_date";
            ecc.item_id = "item_id";
            ecc.item_name_t = "item_name_t";
            ecc.pay_amount = "pay_amount";
            ecc.pay_date = "pay_date";
            ecc.qty = "qty";
            ecc.price = "price";
            ecc.unit_id = "unit_id";
            ecc.unit_name_t = "unit_name_t";
            ecc.vat = "vat";
            ecc.total = "total";
            ecc.receipt_date = "receipt_date";
            ecc.receipt_no = "receipt_no";
            ecc.pay_to_cus_id = "pay_to_cus_id";
            ecc.pay_to_cus_name_t = "pay_to_cus_name_t";
            ecc.pay_to_cus_addr = "pay_to_cus_addr";
            ecc.pay_to_cus_tax = "pay_to_cus_tax";
            ecc.pay_staff_id = "pay_staff_id";
            ecc.row1 = "row1";
            ecc.item_code = "item_code";
            ecc.status_appv = "status_appv";
            ecc.status_doc = "status_doc";
            ecc.appv_staff_id = "appv_staff_id";
            ecc.doc_staff_id = "doc_staff_id";

            ecc.table = "t_expenses_clear_cash";
            ecc.pkField = "expense_clear_cash_id";

            lecc = new List<ExpensesClearCash>();
        }
        public void getlexpnC()
        {
            //lDept = new List<Department>();

            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                ExpensesClearCash curr1 = new ExpensesClearCash();
                curr1.expense_clear_cash_id = row[ecc.expense_clear_cash_id].ToString();
                curr1.expenses_pay_detail_id = row[ecc.expenses_pay_detail_id].ToString();
                curr1.expenses_draw_id = row[ecc.expenses_draw_id].ToString();
                curr1.job_code = row[ecc.job_code].ToString();
                lecc.Add(curr1);
            }
        }
        public String getIdByCode(String code)
        {
            String id = "";
            foreach (ExpensesClearCash curr1 in lecc)
            {
                if (code.Trim().Equals(curr1.expenses_draw_id))
                {
                    id = curr1.expense_clear_cash_id;
                    break;
                }
            }
            return id;
        }
        public String getIdByName(String name)
        {
            String id = "";
            foreach (ExpensesClearCash curr1 in lecc)
            {
                if (name.Trim().Equals(curr1.expenses_draw_id))
                {
                    id = curr1.expense_clear_cash_id;
                    break;
                }
            }
            return id;
        }
        public void setC1CboExpnC(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            if (lecc.Count <= 0) getlexpnC();
            //DataTable dt = selectWard();
            foreach (ExpensesClearCash cus1 in lecc)
            {
                item = new ComboBoxItem();
                item.Value = cus1.expense_clear_cash_id;
                item.Text = cus1.expenses_draw_id;
                c.Items.Add(item);
                if (item.Value.Equals(selected))
                {
                    c.SelectedText = item.Text;
                }
            }
        }
        private void chkNull(ExpensesClearCash p)
        {
            int chk = 0;
            Decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            //p.expenses_pay_detail_id = p.expenses_pay_detail_id == null ? "" : p.expenses_pay_detail_id;
            p.job_code = p.job_code == null ? "" : p.job_code;
            //p.expenses_draw_detail_id = p.expenses_draw_detail_id == null ? "" : p.expenses_draw_detail_id;
            p.remark = p.remark == null ? "" : p.remark;
            //p.ecc_doc = p.ecc_doc == null ? "" : p.ecc_doc;
            p.ecc_doc = p.ecc_doc == null ? "" : p.ecc_doc;
            p.expense_clear_cash_date = p.expense_clear_cash_date == null ? "0" : p.expense_clear_cash_date;
            p.item_name_t = p.item_name_t == null ? "" : p.item_name_t;
            p.pay_date = p.pay_date == null ? "" : p.pay_date;

            p.receipt_no = p.receipt_no == null ? "" : p.receipt_no;
            p.qty = p.qty == null ? "" : p.qty;
            p.unit_name_t = p.unit_name_t == null ? "0" : p.unit_name_t;
            p.total = p.total == null ? "0" : p.total;
            p.receipt_date = p.receipt_date == null ? "" : p.receipt_date;
            p.pay_to_cus_name_t = p.pay_to_cus_name_t == null ? "" : p.pay_to_cus_name_t;
            p.pay_to_cus_addr = p.pay_to_cus_addr == null ? "" : p.pay_to_cus_addr;
            p.pay_to_cus_tax = p.pay_to_cus_tax == null ? "" : p.pay_to_cus_tax;
            p.item_code = p.item_code == null ? "" : p.item_code;
            p.status_appv = p.status_appv == null ? "0" : p.status_appv;
            p.status_doc = p.status_doc == null ? "0" : p.status_doc;

            p.job_id = int.TryParse(p.job_id, out chk) ? chk.ToString() : "0";
            p.staff_id = int.TryParse(p.staff_id, out chk) ? chk.ToString() : "0";
            p.pay_to_cus_id = int.TryParse(p.pay_to_cus_id, out chk) ? chk.ToString() : "0";
            p.item_id = int.TryParse(p.item_id, out chk) ? chk.ToString() : "0";
            p.unit_id = int.TryParse(p.unit_id, out chk) ? chk.ToString() : "0";
            p.expenses_pay_detail_id = int.TryParse(p.expenses_pay_detail_id, out chk) ? chk.ToString() : "0";
            p.expenses_draw_detail_id = int.TryParse(p.expenses_draw_detail_id, out chk) ? chk.ToString() : "0";
            p.expenses_draw_id = int.TryParse(p.expenses_draw_id, out chk) ? chk.ToString() : "0";
            p.pay_staff_id = int.TryParse(p.pay_staff_id, out chk) ? chk.ToString() : "0";
            p.row1 = int.TryParse(p.row1, out chk) ? chk.ToString() : "0";
            p.appv_staff_id = int.TryParse(p.appv_staff_id, out chk) ? chk.ToString() : "0";
            p.doc_staff_id = int.TryParse(p.doc_staff_id, out chk) ? chk.ToString() : "0";

            p.total = Decimal.TryParse(p.total, out chk1) ? chk1.ToString() : "0";
            p.qty = Decimal.TryParse(p.qty, out chk1) ? chk1.ToString() : "0";
            p.price = Decimal.TryParse(p.price, out chk1) ? chk1.ToString() : "0";
            p.vat = Decimal.TryParse(p.vat, out chk1) ? chk1.ToString() : "0";
            p.pay_amount = Decimal.TryParse(p.pay_amount, out chk1) ? chk1.ToString() : "0";
            p.vat = Decimal.TryParse(p.vat, out chk1) ? chk1.ToString() : "0";
        }
        public String insert(ExpensesClearCash p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "0";     // ให้ insert ไปก่อน แล้วค่อย update active = 1 อีกที
            p.status_appv = "0";
            p.status_doc = "0";
            int chk = 0;

            chkNull(p);
            //p.prefix_id = int.TryParse(p.prefix_id, out chk) ? chk.ToString() : "0";
            //p.dept_id = int.TryParse(p.dept_id, out chk) ? chk.ToString() : "0";

            sql = "Insert Into " + ecc.table + "(" + ecc.expenses_pay_detail_id + "," + ecc.expenses_draw_id + "," + ecc.job_id + "," +
                ecc.date_create + "," + ecc.date_modi + "," + ecc.date_cancel + "," +
                ecc.user_create + "," + ecc.user_modi + "," + ecc.user_cancel + "," +
                ecc.active + "," + ecc.remark + ", " + ecc.job_code + "," +
                ecc.expenses_draw_detail_id + "," + ecc.staff_id + "," + ecc.ecc_doc + "," +
                ecc.item_id + "," + ecc.expense_clear_cash_date + "," + ecc.item_name_t + "," +
                ecc.pay_amount + "," + ecc.unit_id + "," + ecc.unit_name_t + "," +
                ecc.vat + "," + ecc.total + "," + //ecc.receipt_date + "," +
                ecc.receipt_no + "," + ecc.receipt_date + "," + ecc.pay_date + "," +
                ecc.price + "," + ecc.pay_to_cus_name_t + "," + ecc.pay_to_cus_addr + "," +
                ecc.pay_to_cus_tax + "," + ecc.pay_to_cus_id + "," + ecc.pay_staff_id + "," +
                ecc.row1 + "," + ecc.item_code + "," + ecc.status_appv + "," +
                ecc.status_doc + "," + ecc.appv_staff_id + "," + ecc.doc_staff_id + " " +
                ") " +
                "Values ('" + p.expenses_pay_detail_id + "','" + p.expenses_draw_id.Replace("'", "''") + "','" + p.job_id.Replace("'", "''") + "'," +
                "'" + p.date_create + "','" + p.date_modi + "','" + p.date_cancel + "'," +
                "'" + userId + "','" + p.user_modi + "','" + p.user_cancel + "'," +
                "'" + p.active + "','" + p.remark.Replace("'", "''") + "','" + p.job_code + "'," +
                "'" + p.expenses_draw_detail_id + "','" + p.staff_id.Replace("'", "''") + "','" + p.ecc_doc.Replace("'", "''") + "'," +
                "'" + p.item_id + "','" + p.expense_clear_cash_date.Replace("'", "''") + "','" + p.item_name_t.Replace("'", "''") + "'," +
                "'" + p.pay_amount + "','" + p.unit_id + "','" + p.unit_name_t.Replace("'", "''") + "'," +
                "'" + p.vat + "','" + p.total + "'," + //p.receipt_date + "'," +
                "'" + p.receipt_no + "','" + p.receipt_date + "','" + p.pay_date + "', " +
                "'" + p.price + "','" + p.pay_to_cus_name_t.Replace("'", "''") + "','" + p.pay_to_cus_addr.Replace("'", "''") + "', " +
                "'" + p.pay_to_cus_tax + "','" + p.pay_to_cus_id + "','" + p.pay_staff_id + "'," +
                "'" + p.row1 + "','" + p.item_code + "','" + p.status_appv + "', " +
                "'" + p.status_doc + "','" + p.appv_staff_id + "','" + p.doc_staff_id + "' " +
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
        public String update(ExpensesClearCash p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);

            sql = "Update " + ecc.table + " Set " +
                " " + ecc.expenses_pay_detail_id + " = '" + p.expenses_pay_detail_id + "'" +
                "," + ecc.job_id + " = '" + p.job_id.Replace("'", "''") + "'" +
                "," + ecc.job_code + " = '" + p.job_code.Replace("'", "''") + "'" +
                "," + ecc.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + ecc.date_modi + " = now()" +
                "," + ecc.user_modi + " = '" + userId + "' " +
                "," + ecc.expenses_draw_detail_id + " = '" + p.expenses_draw_detail_id + "' " +
                "," + ecc.staff_id + " = '" + p.staff_id + "' " +
                "," + ecc.expenses_draw_id + " = '" + p.expenses_draw_id + "' " +
                "," + ecc.ecc_doc + " = '" + p.ecc_doc + "' " +
                "," + ecc.item_id + " = '" + p.item_id + "' " +
                "," + ecc.expense_clear_cash_date + " = '" + p.expense_clear_cash_date + "' " +
                "," + ecc.item_name_t + " = '" + p.item_name_t.Replace("'", "''") + "' " +
                "," + ecc.pay_amount + " = '" + p.pay_amount + "' " +
                "," + ecc.unit_id + " = '" + p.unit_id + "' " +
                "," + ecc.unit_name_t + " = '" + p.unit_name_t.Replace("'", "''") + "' " +
                "," + ecc.vat + " = '" + p.vat + "' " +
                "," + ecc.pay_date + " = '" + p.pay_date + "' " +
                "," + ecc.qty + " = '" + p.qty + "' " +
                "," + ecc.price + " = '" + p.price + "' " +
                "," + ecc.total + " = '" + p.total + "' " +
                "," + ecc.receipt_date + " = '" + p.receipt_date + "' " +
                "," + ecc.receipt_no + " = '" + p.receipt_no + "' " +
                "," + ecc.pay_to_cus_name_t + " = '" + p.pay_to_cus_name_t.Replace("'", "''") + "' " +
                "," + ecc.pay_to_cus_addr + " = '" + p.pay_to_cus_addr.Replace("'", "''") + "' " +
                "," + ecc.pay_to_cus_id + " = '" + p.pay_to_cus_id + "' " +
                "," + ecc.pay_staff_id + " = '" + p.pay_staff_id + "' " +
                "," + ecc.pay_to_cus_tax + " = '" + p.pay_to_cus_tax + "' " +
                "," + ecc.item_code + " = '" + p.item_code + "' " +
                "," + ecc.row1 + " = '" + p.row1 + "' " +
                "Where " + ecc.pkField + "='" + p.expense_clear_cash_id + "'"
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

        public String insertExpenseReceiptCash(ExpensesClearCash p, String userId)
        {
            String re = "";

            if (p.expense_clear_cash_id.Equals(""))
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
            String sql = "Delete From  " + ecc.table;
            conn.ExecuteNonQuery(conn.conn, sql);

            return "";
        }
        public String updateActive(String pdid)
        {
            String re = "";

            String sql = "update " + ecc.table + " Set " +
                "" + ecc.active + "='1' " +                
                "Where " + ecc.active + " = '0' and " + ecc.expenses_pay_detail_id + "='" + pdid + "' ";
            re = conn.ExecuteNonQuery(conn.conn, sql);

            return re;
        }
        public String updateComplete(String doc, String pdid, String userid)
        {
            DataTable dt = new DataTable();
            String re = "";

            String sql = "update " + ecc.table + " Set " +
                "" + ecc.status_doc + "='1' " +
                "," + ecc.ecc_doc + "='"+ doc.Replace("CC","") + "' " +
                "," + ecc.doc_staff_id + "='" + userid + "' " +
                "Where " + ecc.expenses_pay_detail_id + "='" + pdid + "'";
            re = conn.ExecuteNonQuery(conn.conn, sql);

            return re;
        }
        public String updateStatusApprove(String id)
        {
            DataTable dt = new DataTable();
            String re = "";

            String sql = "update " + ecc.table + " Set " +
                "" + ecc.expense_clear_cash_date + "='2' " +
                "Where " + ecc.pkField + "='" + id + "'";
            re = conn.ExecuteNonQuery(conn.conn, sql);

            return re;
        }
        public String updateStatusPay(String id)
        {
            DataTable dt = new DataTable();
            String re = "", sql = "";

            sql = "update " + ecc.table + " Set " +
                "" + ecc.unit_id + "='2' " +
                "Where " + ecc.pkField + "='" + id + "'";
            re = conn.ExecuteNonQuery(conn.conn, sql);

            return re;
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select expC.*  " +
                "From " + ecc.table + " expC " +
                " " +
                "Where expC." + ecc.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectAll(String pay_amount)
        {
            DataTable dt = new DataTable();
            String sql = "select expC.*  " +
                "From " + ecc.table + " expC " +
                " " +
                "Where expC." + ecc.active + " ='1' and " + ecc.pay_amount + "='" + pay_amount + "'";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectToPayDetailId(String pdid)
        {
            DataTable dt = new DataTable();
            String wherestatuspay = "", wherestatuspaytype = "", wherestatuspage = "";
            
            //wherestatuspage = " and " + ecc.total + "='1' ";
            String sql = "select expC.* "  +
                "From " + ecc.table + " expC " +
                " " +
                "Where expC." + ecc.active + " in ('0', '1') and " + ecc.expenses_pay_detail_id + "='" + pdid + "' " ;
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataSet selectAllFmtp(String pay_amount, StatusPay spay)
        {
            DataSet ds = new DataSet();
            String wherestatuspay = "";
            if (spay == StatusPay.waitappv)
            {
                wherestatuspay = " and ed." + ecc.expense_clear_cash_date + "='1'";
            }
            else if (spay == StatusPay.appv)
            {
                wherestatuspay = " and ed." + ecc.expense_clear_cash_date + "='2'";
            }
            else if (spay == StatusPay.all)
            {
                wherestatuspay = "";
            }
            String sql = "select fmtp.f_method_payment_name_t,  itmts.item_type_sub_name_t, sum(edd.item_name_t) as amt " +
                    "from t_expenses_draw_detail edd " +
                    "inner join t_expenses_draw ed on edd.expense_clear_cash_id = ed.expense_clear_cash_id " +
                    "inner join b_items itm on edd.item_id = itm.item_id " +
                    "inner join b_items_type_sub itmts on itm.item_type_sub_id = itmts.item_type_sub_id " +
                    "inner join f_method_payment fmtp on itm.f_method_payment_id = fmtp.f_method_payment_id " +
                    "Where edd." + ecc.active + " ='1' and ed." + ecc.pay_amount + "='" + pay_amount + "' " + wherestatuspay + " " +
                    "group by itmts.item_type_sub_name_t, fmtp.f_method_payment_name_t ";
            ds = conn.selectDataDS(conn.conn, sql);

            return ds;
        }
        public DataTable selectAllFmtp1(String pay_amount, StatusPay spay)
        {
            DataTable dt = new DataTable();
            String wherestatuspay = "";
            if (spay == StatusPay.waitappv)
            {
                wherestatuspay = " and ed." + ecc.expense_clear_cash_date + "='1'";
            }
            else if (spay == StatusPay.appv)
            {
                wherestatuspay = " and ed." + ecc.expense_clear_cash_date + "='2'";
            }
            else if (spay == StatusPay.all)
            {
                wherestatuspay = "";
            }
            String sql = "select fmtp.f_method_payment_name_t,  itmts.item_type_sub_name_t, sum(edd.item_name_t) as amt " +
                    "from t_expenses_draw_detail edd " +
                    "inner join t_expenses_draw ed on edd.expense_clear_cash_id = ed.expense_clear_cash_id " +
                    "inner join b_items itm on edd.item_id = itm.item_id " +
                    "inner join b_items_type_sub itmts on itm.item_type_sub_id = itmts.item_type_sub_id " +
                    "inner join f_method_payment fmtp on itm.f_method_payment_id = fmtp.f_method_payment_id " +
                    "Where edd." + ecc.active + " ='1' and ed." + ecc.pay_amount + "='" + pay_amount + "' " + wherestatuspay + " " +
                    "group by itmts.item_type_sub_name_t, fmtp.f_method_payment_name_t ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByJobCode(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select expC.* " +
                "From " + ecc.table + " expC " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where expC." + ecc.job_code + " = '" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByStatusAppv(String eccdoc, StatusAppv statusappv)
        {
            DataTable dt = new DataTable();
            String sql = "", wherestatusappv="", whereeccdoc="";
            if(statusappv == StatusAppv.sendtoAppv)
            {
                wherestatusappv = " and "+ecc.status_appv+" = '0' ";
            }
            else if (statusappv == StatusAppv.Appv)
            {
                wherestatusappv = " and " + ecc.status_appv + " = '1' ";
            }
            if (!eccdoc.Equals(""))
            {
                whereeccdoc = " and "+ecc.ecc_doc+" = '"+eccdoc+"' ";
            }
            sql = "select * " +
                "From " + ecc.table + "  " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where " + ecc.active + " = '1' "+wherestatusappv+ whereeccdoc;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectSumEccDocByStatusAppv(StatusAppv statusappv)
        {
            DataTable dt = new DataTable();
            String sql = "", wherestatusappv = "";
            if (statusappv == StatusAppv.sendtoAppv)
            {
                wherestatusappv = " and " + ecc.status_appv + " = '0' ";
            }
            else if (statusappv == StatusAppv.Appv)
            {
                wherestatusappv = " and " + ecc.status_appv + " = '1' ";
            }
            sql = "select "+ecc.ecc_doc+",sum("+ecc.pay_amount+") as "+ecc.pay_amount + " " +
                "From " + ecc.table + "  " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where " + ecc.active + " = '1' " + wherestatusappv;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public String selectByNameTLike(String copId)
        {
            String currId = "";
            DataTable dt = new DataTable();
            String sql = "select expC.* " +
                "From " + ecc.table + " expC " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where expC." + ecc.expenses_draw_id + " like '%" + copId.ToLower() + "%' ";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count == 1)
            {
                currId = dt.Rows[0][ecc.expense_clear_cash_id].ToString();
            }
            return currId;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select expC.* " +
                "From " + ecc.table + " expC " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where expC." + ecc.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public ExpensesClearCash selectByPk1(String copId)
        {
            ExpensesClearCash cop1 = new ExpensesClearCash();
            DataTable dt = new DataTable();
            String sql = "select expC.* " +
                "From " + ecc.table + " expC " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where expC." + ecc.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setExpenseReceiptCash(dt);
            return cop1;
        }
        public ExpensesClearCash selectByEccDoc(String copId)
        {
            ExpensesClearCash cop1 = new ExpensesClearCash();
            DataTable dt = new DataTable();
            String sql = "select expC.* " +
                "From " + ecc.table + " expC " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where expC." + ecc.ecc_doc + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setExpenseReceiptCash(dt);
            return cop1;
        }
        public ExpensesClearCash setExpenseReceiptCash(DataTable dt)
        {
            ExpensesClearCash ecc1 = new ExpensesClearCash();
            if (dt.Rows.Count > 0)
            {
                ecc1.expense_clear_cash_id = dt.Rows[0][ecc.expense_clear_cash_id].ToString();
                ecc1.expenses_pay_detail_id = dt.Rows[0][ecc.expenses_pay_detail_id].ToString();
                ecc1.job_id = dt.Rows[0][ecc.job_id].ToString();
                ecc1.job_code = dt.Rows[0][ecc.job_code].ToString();
                ecc1.active = dt.Rows[0][ecc.active].ToString();
                ecc1.date_cancel = dt.Rows[0][ecc.date_cancel].ToString();
                ecc1.date_create = dt.Rows[0][ecc.date_create].ToString();
                ecc1.date_modi = dt.Rows[0][ecc.date_modi].ToString();
                ecc1.user_cancel = dt.Rows[0][ecc.user_cancel].ToString();
                ecc1.user_create = dt.Rows[0][ecc.user_create].ToString();
                ecc1.user_modi = dt.Rows[0][ecc.user_modi].ToString();
                ecc1.ecc_doc = dt.Rows[0][ecc.ecc_doc].ToString();
                ecc1.remark = dt.Rows[0][ecc.remark].ToString();
                ecc1.expenses_draw_detail_id = dt.Rows[0][ecc.expenses_draw_detail_id].ToString();
                ecc1.staff_id = dt.Rows[0][ecc.staff_id].ToString();
                ecc1.expenses_draw_id = dt.Rows[0][ecc.expenses_draw_id].ToString();
                ecc1.expense_clear_cash_date = dt.Rows[0][ecc.expense_clear_cash_date].ToString();
                ecc1.item_id = dt.Rows[0][ecc.item_id].ToString();
                ecc1.item_name_t = dt.Rows[0][ecc.item_name_t].ToString();
                ecc1.pay_amount = dt.Rows[0][ecc.pay_amount].ToString();
                ecc1.unit_id = dt.Rows[0][ecc.unit_id].ToString();
                ecc1.unit_name_t = dt.Rows[0][ecc.unit_name_t].ToString();
                ecc1.vat = dt.Rows[0][ecc.vat].ToString();
                ecc1.total = dt.Rows[0][ecc.total].ToString();
                ecc1.receipt_date = dt.Rows[0][ecc.receipt_date].ToString();
                ecc1.receipt_no = dt.Rows[0][ecc.receipt_no].ToString();
                ecc1.price = dt.Rows[0][ecc.price].ToString();
                ecc1.qty = dt.Rows[0][ecc.qty].ToString();
                ecc1.pay_date = dt.Rows[0][ecc.pay_date].ToString();
                ecc1.pay_to_cus_id = dt.Rows[0][ecc.pay_to_cus_id].ToString();
                ecc1.pay_to_cus_name_t = dt.Rows[0][ecc.pay_to_cus_name_t].ToString();
                ecc1.pay_to_cus_addr = dt.Rows[0][ecc.pay_to_cus_addr].ToString();
                ecc1.pay_to_cus_tax = dt.Rows[0][ecc.pay_to_cus_tax].ToString();
                ecc1.pay_staff_id = dt.Rows[0][ecc.pay_staff_id].ToString();
                ecc1.row1 = dt.Rows[0][ecc.row1].ToString();
                ecc1.item_code = dt.Rows[0][ecc.item_code].ToString();
                ecc1.status_appv = dt.Rows[0][ecc.status_appv].ToString();
                ecc1.status_doc = dt.Rows[0][ecc.status_doc].ToString();
                ecc1.appv_staff_id = dt.Rows[0][ecc.appv_staff_id].ToString();
                ecc1.doc_staff_id = dt.Rows[0][ecc.doc_staff_id].ToString();
            }
            else
            {
                ecc1.expense_clear_cash_id = "";
                ecc1.expenses_pay_detail_id = "";
                ecc1.job_id = "";
                ecc1.job_code = "";
                ecc1.expenses_draw_detail_id = "";
                ecc1.staff_id = "";

                ecc1.active = "";
                ecc1.date_create = "";
                ecc1.date_modi = "";
                ecc1.date_cancel = "";
                ecc1.user_create = "";
                ecc1.user_modi = "";
                ecc1.user_cancel = "";
                ecc1.expenses_draw_id = "";
                ecc1.remark = "";
                ecc1.ecc_doc = "";
                ecc1.expense_clear_cash_date = "";
                ecc1.item_id = "";
                ecc1.item_name_t = "";
                ecc1.pay_amount = "";
                ecc1.pay_date = "";
                ecc1.qty = "";
                ecc1.unit_id = "";
                ecc1.unit_name_t = "";
                ecc1.vat = "";
                ecc1.total = "";
                ecc1.receipt_date = "";
                ecc1.receipt_no = "";
                ecc1.price = "";
                ecc1.pay_to_cus_name_t = "";
                ecc1.pay_to_cus_id = "";
                ecc1.pay_to_cus_addr = "";
                ecc1.pay_to_cus_tax = "";
                ecc1.pay_staff_id = "";
                ecc1.row1 = "";
                ecc1.item_code = "";
                ecc1.status_appv = "";
                ecc1.status_doc = "";
                ecc1.appv_staff_id = "";
                ecc1.doc_staff_id = "";
            }

            return ecc1;
        }
    }
}
