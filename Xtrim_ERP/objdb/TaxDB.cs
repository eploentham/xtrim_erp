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
    public class TaxDB
    {
        public Tax tax;
        ConnectDB conn;
        public List<Tax> lexpn;
        public TaxDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            tax = new Tax();
            tax.tax_id = "tax_id";
            tax.tax_code = "tax_code";
            tax.tax_name_t = "tax_name_t";
            tax.tax_name_e = "tax_name_e";
            //tax.payment_detail_id = "payment_detail_id";
            //tax.job_id = "job_id";
            tax.active = "active";
            tax.remark = "remark";
            tax.date_create = "date_create";
            tax.date_modi = "date_modi";
            tax.date_cancel = "date_cancel";
            tax.user_create = "user_create";
            tax.user_modi = "user_modi";
            tax.user_cancel = "user_cancel";
            tax.rate1 = "rate1";
            tax.f_tax_type_id = "f_tax_type_id";

            tax.table = "b_tax";
            tax.pkField = "tax_id";

            lexpn = new List<Tax>();
        }
        public String getIdByName(String name)
        {
            String id = "";
            foreach (Tax utp1 in lexpn)
            {
                if (name.Trim().Equals(utp1.tax_code))
                {
                    id = utp1.tax_id;
                    break;
                }
            }
            return id;
        }
        private void chkNull(Tax p)
        {
            int chk = 0;
            Decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            p.tax_name_t = p.tax_name_t == null ? "" : p.tax_name_t;
            p.rate1 = p.rate1 == null ? "0" : p.rate1;
            p.tax_code = p.tax_code == null ? "" : p.tax_code;
            p.remark = p.remark == null ? "" : p.remark;
            p.tax_name_e = p.tax_name_e == null ? "" : p.tax_name_e;
            //p.remark = p.remark == null ? "" : p.remark;

            p.f_tax_type_id = int.TryParse(p.f_tax_type_id, out chk) ? chk.ToString() : "0";
            //p.payment_detail_id = int.TryParse(p.payment_detail_id, out chk) ? chk.ToString() : "0";
            //p.job_id = int.TryParse(p.job_id, out chk) ? chk.ToString() : "0";
            //p.tax_code = int.TryParse(p.tax_code, out chk) ? chk.ToString() : "0";
            //p.comp_id = int.TryParse(p.comp_id, out chk) ? chk.ToString() : "0";

            //p.tax_name_t = Decimal.TryParse(p.tax_name_t, out chk1) ? chk1.ToString() : "0";
            //p.amount_income = Decimal.TryParse(p.amount_income, out chk1) ? chk1.ToString() : "0";
        }
        public String insert(Tax p, String userId)
        {
            String re = "", sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            chkNull(p);
            sql = "Insert Into " + tax.table + "(" + tax.tax_name_t + "," + tax.tax_code + "," + tax.rate1 + "," +
                tax.active + "," + tax.remark + ", " + tax.tax_name_e + ", " +
                tax.date_create + ", " + tax.date_modi + ", " + tax.date_cancel + ", " +
                tax.user_create + ", " + tax.user_modi + ", " + tax.user_cancel + "," +
                tax.rate1 + "," + tax.f_tax_type_id + " " +
                ") " +
                "Values ('" + p.tax_name_t.Replace("'", "''") + "','" + p.tax_code + "','" + p.rate1.Replace("'", "''") + "'," +
                "'" + p.active + "','" + p.remark.Replace("'", "''") + "','" + p.tax_name_e + "', " +
                "now(),'" + p.date_modi + "','" + p.date_cancel + "', " +
                "'" + userId + "','" + p.user_modi + "','" + p.user_cancel + "'," +
                "'" + p.rate1 + "','" + p.f_tax_type_id + "' " +
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
        public String update(Tax p, String userId)
        {
            String re = "", sql = "";
            chkNull(p);
            sql = "Update " + tax.table + " Set " +
                " " + tax.tax_name_t + "='" + p.tax_name_t.Replace("'", "''") + "' " +
                "," + tax.tax_name_e + "='" + p.tax_name_e.Replace("'", "''") + "' " +
                "," + tax.tax_id + "='" + p.tax_id.Replace("'", "''") + "' " +
                "," + tax.remark + "='" + p.remark.Replace("'", "''") + "' " +
                "," + tax.date_modi + "=now() " +
                "," + tax.user_modi + "='" + userId.Replace("'", "''") + "' " +
                "," + tax.tax_name_e + "='" + p.tax_name_e.Replace("'", "''") + "' " +
                "," + tax.tax_code + "='" + p.tax_code.Replace("'", "''") + "' " +
                "," + tax.rate1 + "='" + p.rate1.Replace("'", "''") + "' " +
                "," + tax.f_tax_type_id + "='" + p.f_tax_type_id.Replace("'", "''") + "' " +
                "Where " + tax.pkField + "='" + p.tax_id + "'";

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
        public String insertTax(Tax p, String userId)
        {
            String re = "";

            if (p.tax_id.Equals(""))
            {
                re = insert(p, userId);
            }
            else
            {
                re = update(p, userId);
            }
            return re;
        }
        public String voidTax(String id)
        {
            String re = "", sql = "";

            sql = "Update " + tax.table + " Set " +
                " " + tax.active + "='3' " +
                "," + tax.date_cancel + "=now() " +
                "Where " + tax.tax_code + "='" + id + "'"
                ;
            re = conn.ExecuteNonQuery(conn.conn, sql);

            return re;
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select tax.*  " +
                "From " + tax.table + " tax " +
                " " +
                "Where tax." + tax.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select tax.* " +
                "From " + tax.table + " tax " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where tax." + tax.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public Tax selectByPk1(String copId)
        {
            Tax cop1 = new Tax();
            DataTable dt = new DataTable();
            String sql = "select tax.* " +
                "From " + tax.table + " tax " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where tax." + tax.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setTax(dt);
            return cop1;
        }
        public DataTable selectTax()
        {
            DataTable dt = new DataTable();
            String sql = "select tax." + tax.tax_code + ", sum(" + tax.tax_name_t + ") as " + tax.tax_name_t + ",cus.cust_name_t " +
                "From " + tax.table + " tax " +
                "Left Join b_customer cus On bill.tax_code = cus.cust_id " +
                "Where tax." + tax.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public Tax setTax(DataTable dt)
        {
            Tax tax1 = new Tax();
            if (dt.Rows.Count > 0)
            {
                tax1.tax_id = dt.Rows[0][tax.tax_id].ToString();
                tax1.tax_code = dt.Rows[0][tax.tax_code].ToString();
                tax1.tax_name_t = dt.Rows[0][tax.tax_name_t].ToString();
                tax1.tax_name_e = dt.Rows[0][tax.tax_name_e].ToString();                
                tax1.active = dt.Rows[0][tax.active].ToString();
                tax1.date_cancel = dt.Rows[0][tax.date_cancel].ToString();
                tax1.date_create = dt.Rows[0][tax.date_create].ToString();
                tax1.date_modi = dt.Rows[0][tax.date_modi].ToString();
                tax1.user_cancel = dt.Rows[0][tax.user_cancel].ToString();
                tax1.user_create = dt.Rows[0][tax.user_create].ToString();
                tax1.user_modi = dt.Rows[0][tax.user_modi].ToString();
                
                tax1.remark = dt.Rows[0][tax.remark].ToString();
                tax1.f_tax_type_id = dt.Rows[0][tax.f_tax_type_id].ToString();
                tax1.rate1 = dt.Rows[0][tax.rate1].ToString();
                
            }
            else
            {
                tax1.tax_id = "";
                tax1.tax_code = "";
                tax1.tax_name_t = "";
                tax1.tax_name_e = "";
                
                tax1.active = "";
                tax1.remark = "";
                tax1.date_create = "";
                tax1.date_modi = "";
                tax1.date_cancel = "";
                tax1.user_create = "";
                tax1.user_modi = "";
                tax1.user_cancel = "";
                tax1.rate1 = "";
                tax1.f_tax_type_id = "";
            }

            return tax1;
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
                item.Text = row[tax.tax_name_t].ToString();
                item.Value = row[tax.tax_id].ToString();
                c.Items.Add(item);

                Tax tax1 = new Tax();
                tax1.tax_id = row[tax.tax_id].ToString();
                tax1.tax_code = row[tax.tax_code].ToString();
                tax1.tax_name_e = row[tax.tax_name_e].ToString();
                tax1.tax_name_t = row[tax.tax_name_t].ToString();

                lexpn.Add(tax1);
            }
            return c;
        }
    }
}
