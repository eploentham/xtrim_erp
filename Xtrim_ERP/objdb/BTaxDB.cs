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
    public class BTaxDB
    {
        public BTax btax;
        ConnectDB conn;
        public List<BTax> lexpn;
        public BTaxDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            btax = new BTax();
            btax.b_tax_id = "b_tax_id";
            btax.b_tax_code = "b_tax_code";
            btax.b_tax_name_t = "b_tax_name_t";
            btax.b_tax_name_e = "b_tax_name_e";
            //tax.payment_detail_id = "payment_detail_id";
            //tax.job_id = "job_id";
            btax.active = "active";
            btax.remark = "remark";
            btax.date_create = "date_create";
            btax.date_modi = "date_modi";
            btax.date_cancel = "date_cancel";
            btax.user_create = "user_create";
            btax.user_modi = "user_modi";
            btax.user_cancel = "user_cancel";
            btax.rate1 = "rate1";
            btax.f_tax_type_id = "f_tax_type_id";

            btax.table = "b_tax";
            btax.pkField = "b_tax_id";

            lexpn = new List<BTax>();
        }
        public String getIdByName(String name)
        {
            String id = "";
            foreach (BTax utp1 in lexpn)
            {
                if (name.Trim().Equals(utp1.b_tax_code))
                {
                    id = utp1.b_tax_id;
                    break;
                }
            }
            return id;
        }
        private void chkNull(BTax p)
        {
            int chk = 0;
            Decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            p.b_tax_name_t = p.b_tax_name_t == null ? "" : p.b_tax_name_t;
            p.rate1 = p.rate1 == null ? "0" : p.rate1;
            p.b_tax_code = p.b_tax_code == null ? "" : p.b_tax_code;
            p.remark = p.remark == null ? "" : p.remark;
            p.b_tax_name_e = p.b_tax_name_e == null ? "" : p.b_tax_name_e;
            //p.remark = p.remark == null ? "" : p.remark;

            p.f_tax_type_id = int.TryParse(p.f_tax_type_id, out chk) ? chk.ToString() : "0";
            //p.payment_detail_id = int.TryParse(p.payment_detail_id, out chk) ? chk.ToString() : "0";
            //p.job_id = int.TryParse(p.job_id, out chk) ? chk.ToString() : "0";
            //p.tax_code = int.TryParse(p.tax_code, out chk) ? chk.ToString() : "0";
            //p.comp_id = int.TryParse(p.comp_id, out chk) ? chk.ToString() : "0";

            //p.tax_name_t = Decimal.TryParse(p.tax_name_t, out chk1) ? chk1.ToString() : "0";
            //p.amount_income = Decimal.TryParse(p.amount_income, out chk1) ? chk1.ToString() : "0";
        }
        public String insert(BTax p, String userId)
        {
            String re = "", sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            chkNull(p);
            sql = "Insert Into " + btax.table + "(" + btax.b_tax_name_t + "," + btax.b_tax_code + "," + btax.rate1 + "," +
                btax.active + "," + btax.remark + ", " + btax.b_tax_name_e + ", " +
                btax.date_create + ", " + btax.date_modi + ", " + btax.date_cancel + ", " +
                btax.user_create + ", " + btax.user_modi + ", " + btax.user_cancel + "," +
                btax.rate1 + "," + btax.f_tax_type_id + " " +
                ") " +
                "Values ('" + p.b_tax_name_t.Replace("'", "''") + "','" + p.b_tax_code + "','" + p.rate1.Replace("'", "''") + "'," +
                "'" + p.active + "','" + p.remark.Replace("'", "''") + "','" + p.b_tax_name_e + "', " +
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
        public String update(BTax p, String userId)
        {
            String re = "", sql = "";
            chkNull(p);
            sql = "Update " + btax.table + " Set " +
                " " + btax.b_tax_name_t + "='" + p.b_tax_name_t.Replace("'", "''") + "' " +
                "," + btax.b_tax_name_e + "='" + p.b_tax_name_e.Replace("'", "''") + "' " +
                "," + btax.b_tax_id + "='" + p.b_tax_id.Replace("'", "''") + "' " +
                "," + btax.remark + "='" + p.remark.Replace("'", "''") + "' " +
                "," + btax.date_modi + "=now() " +
                "," + btax.user_modi + "='" + userId.Replace("'", "''") + "' " +
                "," + btax.b_tax_name_e + "='" + p.b_tax_name_e.Replace("'", "''") + "' " +
                "," + btax.b_tax_code + "='" + p.b_tax_code.Replace("'", "''") + "' " +
                "," + btax.rate1 + "='" + p.rate1.Replace("'", "''") + "' " +
                "," + btax.f_tax_type_id + "='" + p.f_tax_type_id.Replace("'", "''") + "' " +
                "Where " + btax.pkField + "='" + p.b_tax_id + "'";

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
        public String insertBTax(BTax p, String userId)
        {
            String re = "";

            if (p.b_tax_id.Equals(""))
            {
                re = insert(p, userId);
            }
            else
            {
                re = update(p, userId);
            }
            return re;
        }
        public String voidBTax(String id)
        {
            String re = "", sql = "";

            sql = "Update " + btax.table + " Set " +
                " " + btax.active + "='3' " +
                "," + btax.date_cancel + "=now() " +
                "Where " + btax.b_tax_code + "='" + id + "'"
                ;
            re = conn.ExecuteNonQuery(conn.conn, sql);

            return re;
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select btax.*  " +
                "From " + btax.table + " btax " +
                " " +
                "Where btax." + btax.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select btax.* " +
                "From " + btax.table + " btax " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where btax." + btax.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public BTax selectByPk1(String copId)
        {
            BTax cop1 = new BTax();
            DataTable dt = new DataTable();
            String sql = "select btax.* " +
                "From " + btax.table + " btax " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where btax." + btax.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setBTax(dt);
            return cop1;
        }
        public DataTable selectTax()
        {
            DataTable dt = new DataTable();
            String sql = "select tax." + btax.b_tax_code + ", sum(" + btax.b_tax_name_t + ") as " + btax.b_tax_name_t + ",cus.cust_name_t " +
                "From " + btax.table + " tax " +
                "Left Join b_customer cus On bill.tax_code = cus.cust_id " +
                "Where tax." + btax.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public BTax setBTax(DataTable dt)
        {
            BTax tax1 = new BTax();
            if (dt.Rows.Count > 0)
            {
                tax1.b_tax_id = dt.Rows[0][btax.b_tax_id].ToString();
                tax1.b_tax_code = dt.Rows[0][btax.b_tax_code].ToString();
                tax1.b_tax_name_t = dt.Rows[0][btax.b_tax_name_t].ToString();
                tax1.b_tax_name_e = dt.Rows[0][btax.b_tax_name_e].ToString();                
                tax1.active = dt.Rows[0][btax.active].ToString();
                tax1.date_cancel = dt.Rows[0][btax.date_cancel].ToString();
                tax1.date_create = dt.Rows[0][btax.date_create].ToString();
                tax1.date_modi = dt.Rows[0][btax.date_modi].ToString();
                tax1.user_cancel = dt.Rows[0][btax.user_cancel].ToString();
                tax1.user_create = dt.Rows[0][btax.user_create].ToString();
                tax1.user_modi = dt.Rows[0][btax.user_modi].ToString();
                
                tax1.remark = dt.Rows[0][btax.remark].ToString();
                tax1.f_tax_type_id = dt.Rows[0][btax.f_tax_type_id].ToString();
                tax1.rate1 = dt.Rows[0][btax.rate1].ToString();
                
            }
            else
            {
                tax1.b_tax_id = "";
                tax1.b_tax_code = "";
                tax1.b_tax_name_t = "";
                tax1.b_tax_name_e = "";
                
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
                item.Text = row[btax.b_tax_name_t].ToString();
                item.Value = row[btax.b_tax_id].ToString();
                c.Items.Add(item);

                BTax tax1 = new BTax();
                tax1.b_tax_id = row[btax.b_tax_id].ToString();
                tax1.b_tax_code = row[btax.b_tax_code].ToString();
                tax1.b_tax_name_e = row[btax.b_tax_name_e].ToString();
                tax1.b_tax_name_t = row[btax.b_tax_name_t].ToString();

                lexpn.Add(tax1);
            }
            return c;
        }
    }
}
