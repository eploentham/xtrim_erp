using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xtrim_ERP.object1;

namespace Xtrim_ERP.objdb
{
    public class CustomerTaxInvoiceDB
    {
        public CustomerTaxInvoice cusT;
        ConnectDB conn;

        public List<CustomerTaxInvoice> lAddrT;
        public DataTable dtAddrT;

        public CustomerTaxInvoiceDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            cusT = new CustomerTaxInvoice();
            cusT.tax_invoice_id = "tax_invoice_id";
            cusT.cust_id = "cust_id";
            cusT.tax_invoice_name_e = "tax_invoice_name_e";
            cusT.tax_invoice_name_t = "tax_invoice_name_t";
            cusT.tax_id = "tax_id";

            cusT.date_create = "date_create";
            cusT.date_modi = "date_modi";
            cusT.date_cancel = "date_cancel";
            cusT.user_create = "user_create";
            cusT.user_modi = "user_modi";
            cusT.user_cancel = "user_cancel";
            cusT.active = "active";
            cusT.remark = "remark";
            cusT.sort1 = "sort1";

            cusT.table = "b_customer_tax_invoice";
            cusT.pkField = "tax_invoice_id";
        }
        public void getlAddr()
        {
            //lDept = new List<Department>();

            lAddrT.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            dtAddrT = dt;
            foreach (DataRow row in dt.Rows)
            {
                CustomerTaxInvoice addrT1 = new CustomerTaxInvoice();
                addrT1.tax_invoice_id = row[cusT.tax_invoice_id].ToString();
                addrT1.tax_invoice_name_t = row[cusT.tax_invoice_name_t].ToString();
                addrT1.cust_id = row[addrT1.cust_id].ToString();
                //addrT1.line_e1 = row[addrT1.line_e1].ToString();

                lAddrT.Add(addrT1);
            }
        }
        public void setCboCus(ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectWard();
            foreach (CustomerTaxInvoice cus1 in lAddrT)
            {
                item = new ComboBoxItem();
                item.Value = cus1.tax_invoice_id;
                item.Text = cus1.cust_id;
                c.Items.Add(item);
                if (item.Value.Equals(selected))
                {
                    c.SelectedItem = item;
                }
            }
        }
        public String getIdByName(String name)
        {
            String id = "";
            foreach (CustomerTaxInvoice cus1 in lAddrT)
            {
                if (name.Trim().Equals(cus1.cust_id.Trim()))
                {
                    id = cus1.tax_invoice_id;
                    break;
                }
            }
            return id;
        }
        private void chkNull(CustomerTaxInvoice p)
        {
            int chk = 0;
            Decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            p.tax_invoice_id = p.tax_invoice_id == null ? "" : p.tax_invoice_id;

            p.cust_id = p.cust_id == null ? "" : p.cust_id;
            p.tax_id = p.tax_id == null ? "" : p.tax_id;
            p.tax_invoice_name_e = p.tax_invoice_name_e == null ? "" : p.tax_invoice_name_e;
            p.tax_invoice_name_t = p.tax_invoice_name_t == null ? "" : p.tax_invoice_name_t;
            p.active = p.active == null ? "" : p.active;
            p.remark = p.remark == null ? "" : p.remark;
            p.cust_id = int.TryParse(p.cust_id, out chk) ? chk.ToString() : "0";

        }
        public String insert(CustomerTaxInvoice p)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            sql = "Insert Into " + cusT.table + "(" + cusT.cust_id + "," + cusT.tax_invoice_name_e + "," + cusT.tax_invoice_name_t + "," +
                cusT.date_create + "," + cusT.date_modi + ", " + cusT.date_cancel + ", " +
                cusT.user_create + "," + cusT.user_modi + ", " + cusT.user_cancel + ", " +
                cusT.active + ", " + cusT.tax_id + ", " + cusT.sort1 + " " +
                cusT.remark + ", " +
                ") " +
                "Values ('" + p.cust_id.Replace("'", "''") + "','" + p.tax_invoice_name_e.Replace("'", "''") + "','" + p.tax_invoice_name_t.Replace("'", "''") + "','" +
                "'" + p.date_create + "','" + p.date_modi + "','" + p.date_cancel + "', " +
                "'" + p.user_create + "','" + p.user_modi + "','" + p.user_cancel + "', " +
                "'" + p.active + "','" + p.tax_id + "','" + p.sort1 + "', " +
                 "'" + p.remark + "' " +
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
        public String update(CustomerTaxInvoice p)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);
            sql = "Update " + cusT.table + " Set " +
                " " + cusT.cust_id + " = '" + p.cust_id.Replace("'", "''") + "'" +
                "," + cusT.tax_invoice_name_e + " = '" + p.tax_invoice_name_e.Replace("'", "''") + "'" +
                "," + cusT.tax_invoice_name_t + " = '" + p.tax_invoice_name_t.Replace("'", "''") + "'" +
                "," + cusT.tax_id + " = '" + p.tax_id.Replace("'", "''") + "'" +
                "," + cusT.sort1 + " = '" + p.sort1.Replace("'", "''") + "'" +
                "," + cusT.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + cusT.date_modi + " = now()" +

                "Where " + cusT.pkField + "='" + p.tax_invoice_id + "'"
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
        public String insertCustomerTaxInvoice(CustomerTaxInvoice p)
        {
            String re = "";

            if (p.tax_invoice_id.Equals(""))
            {
                re = insert(p);
            }
            else
            {
                re = update(p);
            }

            return re;
        }
        public String deleteAll()
        {
            DataTable dt = new DataTable();
            String sql = "Delete From  " + cusT.table;
            conn.ExecuteNonQuery(conn.conn, sql);

            return "";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select cop.*  " +
                "From " + cusT.table + " cop " +
                " " +
                "Where cop." + cusT.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        private CustomerTaxInvoice setCustomerRemark(DataTable dt)
        {
            CustomerTaxInvoice cusR1 = new CustomerTaxInvoice();
            if (dt.Rows.Count > 0)
            {
                cusR1.tax_invoice_id = dt.Rows[0][cusT.tax_invoice_id].ToString();
                cusR1.cust_id = dt.Rows[0][cusT.cust_id].ToString();
                cusR1.date_create = dt.Rows[0][cusT.date_create].ToString();
                cusR1.date_modi = dt.Rows[0][cusT.date_modi].ToString();
                cusR1.date_cancel = dt.Rows[0][cusT.date_cancel].ToString();
                cusR1.user_create = dt.Rows[0][cusT.user_create].ToString();
                cusR1.user_modi = dt.Rows[0][cusT.user_modi].ToString();
                cusR1.remark = dt.Rows[0][cusT.remark].ToString();
                cusR1.user_cancel = dt.Rows[0][cusT.user_cancel].ToString();

                cusR1.active = dt.Rows[0][cusT.active].ToString();
                cusR1.tax_id = dt.Rows[0][cusT.tax_id].ToString();
                cusR1.sort1 = dt.Rows[0][cusT.sort1].ToString();
                cusR1.tax_invoice_name_e = dt.Rows[0][cusT.tax_invoice_name_e].ToString();
                cusR1.tax_invoice_name_t = dt.Rows[0][cusT.tax_invoice_name_t].ToString();

            }

            return cusR1;
        }
    }
}
