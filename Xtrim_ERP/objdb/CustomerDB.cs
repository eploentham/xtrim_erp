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
    public class CustomerDB
    {
        public Customer cus;
        ConnectDB conn;

        public List<Customer> lCus;
        public DataTable dtCus;

        public CustomerDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            cus = new Customer();
            cus.cust_id= "cust_id";
            cus.cust_code= "cust_code";
            cus.cust_name_t= "cust_name_t";
            cus.cust_name_e= "cust_name_e";
            cus.active= "active";

            cus.address_t= "address_t";
            cus.address_e= "address_e";
            cus.addr= "addr";
            cus.amphur_id= "amphur_id";
            cus.district_id= "district_id";

            cus.province_id= "province_id";
            cus.zipcode= "zipcode";
            cus.sale_id= "sale_id";
            cus.sale_name_t= "sale_name_t";
            cus.fax= "fax";

            cus.tele= "tele";
            cus.email= "email";
            cus.tax_id= "tax_id";
            cus.remark= "remark";
            cus.contact_name1= "contact_name1";

            cus.contact_name2= "contact_name2";
            cus.contact_name1_tel= "contact_name1_tel";
            cus.contact_name2_tel= "contact_name2_tel";
            cus.status_company= "status_company";
            cus.status_vendor= "status_vendor";

            cus.date_create= "date_create";
            cus.date_modi= "date_modi";
            cus.date_cancel= "date_cancel";
            cus.user_create= "user_create";
            cus.user_modi= "user_modi";

            cus.user_cancel= "user_cancel";
            cus.remark2= "remark2";
            cus.po_due_period= "po_due_period";
            cus.taddr1= "taddr1";
            cus.taddr2= "taddr2";

            cus.taddr3= "taddr3";
            cus.taddr4= "taddr4";
            cus.eaddr1= "eaddr1";
            cus.eaddr2= "eaddr2";
            cus.eaddr3= "eaddr3";

            cus.eaddr4= "eaddr4";
                        

            cus.table = "b_customer";
            cus.pkField = "cust_id";

            lCus = new List<Customer>();
            getlCus();
        }
        public void getlCus()
        {
            //lDept = new List<Department>();

            lCus.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            dtCus = dt;
            foreach (DataRow row in dt.Rows)
            {
                Customer cus1 = new Customer();
                cus1.cust_id = row[cus.cust_id].ToString();
                cus1.cust_code = row[cus.cust_code].ToString();
                cus1.cust_name_t = row[cus.cust_name_t].ToString();
                cus1.cust_name_e = row[cus.cust_name_e].ToString();
                //cus1.c = row[dept.dept_parent_id].ToString();
                //cus1.remark = row[dept.remark].ToString();
                //cus1.date_create = row[dept.date_create].ToString();
                //cus1.date_modi = row[dept.date_modi].ToString();
                //cus1.date_cancel = row[dept.date_cancel].ToString();
                //cus1.user_create = row[dept.user_create].ToString();
                //cus1.user_modi = row[dept.user_modi].ToString();
                //cus1.user_cancel = row[dept.user_cancel].ToString();
                //cus1.active = row[dept.active].ToString();
                lCus.Add(cus1);
            }
        }
        public void setCboCus(ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectWard();
            foreach (Customer cus1 in lCus)
            {
                item = new ComboBoxItem();
                item.Value = cus1.cust_id;
                item.Text = cus1.cust_name_t;
                c.Items.Add(item);
                if (item.Value.Equals(selected))
                {
                    c.SelectedItem = item;
                }
            }
        }
        public String getCodeById(String code)
        {
            String id = "";
            foreach (Customer cus1 in lCus)
            {
                if (code.Trim().Equals(cus1.cust_code.Trim()))
                {
                    id = cus1.cust_id;
                    break;
                }
            }
            return id;
        }
        public String getIdByCode(String code)
        {
            String id = "";
            foreach (Customer cus1 in lCus)
            {
                if (code.Trim().Equals(cus1.cust_code.Trim()))
                {
                    id = cus1.cust_id;
                    break;
                }
            }
            return id;
        }
        public String getIdByName(String name)
        {
            String id = "";
            foreach (Customer cus1 in lCus)
            {
                if (name.Trim().Equals(cus1.cust_name_t.Trim()))
                {
                    id = cus1.cust_id;
                    break;
                }
            }
            return id;
        }
        public String getNameTById(String id)
        {
            String ret = "";
            foreach (Customer cus1 in lCus)
            {
                if (id.Trim().Equals(cus1.cust_id.Trim()))
                {
                    ret = cus1.cust_name_t;
                    break;
                }
            }
            return ret;
        }
        public String insert(Customer p)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            p.eaddr4 = p.eaddr4 == null ? "" : p.eaddr4;
            p.eaddr3 = p.eaddr3 == null ? "" : p.eaddr3;
            p.eaddr2 = p.eaddr2 == null ? "" : p.eaddr2;
            p.eaddr1 = p.eaddr1 == null ? "" : p.eaddr1;
            p.taddr1 = p.taddr1 == null ? "" : p.taddr1;
            p.taddr2 = p.taddr2 == null ? "" : p.taddr2;
            p.taddr3 = p.taddr3 == null ? "" : p.taddr3;
            p.taddr4 = p.taddr4 == null ? "" : p.taddr4;
            p.po_due_period = p.po_due_period == null ? "" : p.po_due_period;
            p.amphur_id = p.amphur_id == null ? "" : p.amphur_id;
            p.district_id = p.district_id == null ? "" : p.district_id;
            p.province_id = p.province_id == null ? "" : p.province_id;
            p.addr = p.addr == null ? "" : p.addr;
            p.address_t = p.address_t == null ? "" : p.address_t;
            p.address_e = p.address_e == null ? "" : p.address_e;
            p.sale_id = p.sale_id == null ? "" : p.sale_id;
            p.sale_name_t = p.sale_name_t == null ? "" : p.sale_name_t;
            p.zipcode = p.zipcode == null ? "" : p.zipcode;
            p.status_company = p.status_company == null ? "" : p.status_company;
            p.status_vendor = p.status_vendor == null ? "" : p.status_vendor;
            //p.status_vendor = p.status_vendor == null ? "" : p.status_vendor;
            //p.status_vendor = p.status_vendor == null ? "" : p.status_vendor;
            
            sql = "Insert Into " + cus.table + "(" + cus.cust_code + "," + cus.cust_name_t + "," + cus.cust_name_e + "," +
                cus.active + "," + cus.address_t + "," + cus.address_e + "," +
                cus.addr + "," + cus.amphur_id + "," + cus.district_id + "," +
                cus.province_id + "," + cus.zipcode + "," + cus.sale_id + "," +
                cus.sale_name_t + "," + cus.fax + "," + cus.tele + "," +
                cus.email + "," + cus.tax_id + "," + cus.remark + "," +
                cus.contact_name1 + "," + cus.contact_name2 + "," + cus.contact_name1_tel + "," +
                cus.contact_name2_tel + "," + cus.status_company + ", " + cus.status_vendor + ", " +
                cus.date_create + "," + cus.date_modi + ", " + cus.date_cancel + ", " +
                cus.user_create + "," + cus.user_modi + ", " + cus.user_cancel + ", " +
                cus.remark2 + "," + cus.po_due_period + ", " + cus.taddr1 + ", " +
                cus.taddr2 + "," + cus.taddr3 + ", " + cus.taddr4 + ", " +
                cus.eaddr1 + "," + cus.eaddr2 + ", " + cus.eaddr3 + ", " +
                cus.eaddr4  + " " +
                ") " +
                "Values ('" + p.cust_code + "','" + p.cust_name_t.Replace("'", "''") + "','" + p.cust_name_e.Replace("'", "''") + "'," +
                "'" + p.active + "','" + p.address_t.Replace("'", "''") + "','" + p.address_e.Replace("'", "''") + "'," +
                "'" + p.addr.Replace("'", "''") + "','" + p.amphur_id + "','" + p.district_id + "'," +
                "'" + p.province_id + "','" + p.zipcode + "','" + p.sale_id + "'," +
                "'" + p.sale_name_t.Replace("'", "''") + "','" + p.fax + "','" + p.tele + "'," +
                "'" + p.email + "','" + p.tax_id + "','" + p.remark.Replace("'", "''") + "'," +
                "'" + p.contact_name1.Replace("'", "''") + "','" + p.contact_name2.Replace("'", "''") + "','" + p.contact_name1_tel + "', " +
                "'" + p.contact_name2_tel + "','" + p.status_company + "','" + p.status_vendor + "', " +
                "'" + p.date_create + "','" + p.date_modi + "','" + p.date_cancel + "', " +
                "'" + p.user_create + "','" + p.user_modi + "','" + p.user_cancel + "', " +
                "'" + p.remark2.Replace("'", "''") + "','" + p.po_due_period + "','" + p.taddr1 + "', " +
                "'" + p.taddr2.Replace("'", "''") + "','" + p.taddr3.Replace("'", "''") + "','" + p.taddr4.Replace("'", "''") + "', " +
                "'" + p.eaddr1.Replace("'", "''") + "','" + p.eaddr2.Replace("'", "''") + "','" + p.eaddr3.Replace("'", "''") + "', " +
                "'" + p.eaddr4.Replace("'", "''") + "' " +
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
        public String update(Customer p)
        {
            String re = "";
            String sql = "";

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            p.eaddr4 = p.eaddr4 == null ? "" : p.eaddr4;
            p.eaddr3 = p.eaddr3 == null ? "" : p.eaddr3;
            p.eaddr2 = p.eaddr2 == null ? "" : p.eaddr2;
            p.eaddr1 = p.eaddr1 == null ? "" : p.eaddr1;
            p.taddr1 = p.taddr1 == null ? "" : p.taddr1;
            p.taddr2 = p.taddr2 == null ? "" : p.taddr2;
            p.taddr3 = p.taddr3 == null ? "" : p.taddr3;
            p.taddr4 = p.taddr4 == null ? "" : p.taddr4;
            p.po_due_period = p.po_due_period == null ? "" : p.po_due_period;
            p.amphur_id = p.amphur_id == null ? "" : p.amphur_id;
            p.district_id = p.district_id == null ? "" : p.district_id;
            p.province_id = p.province_id == null ? "" : p.province_id;
            p.addr = p.addr == null ? "" : p.addr;
            p.address_t = p.address_t == null ? "" : p.address_t;
            p.address_e = p.address_e == null ? "" : p.address_e;
            p.sale_id = p.sale_id == null ? "" : p.sale_id;
            p.sale_name_t = p.sale_name_t == null ? "" : p.sale_name_t;
            p.zipcode = p.zipcode == null ? "" : p.zipcode;
            p.status_company = p.status_company == null ? "" : p.status_company;
            p.status_vendor = p.status_vendor == null ? "" : p.status_vendor;
            //p.status_vendor = p.status_vendor == null ? "" : p.status_vendor;
            //p.status_vendor = p.status_vendor == null ? "" : p.status_vendor;

            sql = "Update " + cus.table + " Set " +
                " " + cus.cust_code + " = '" + p.cust_code + "'" +
                "," + cus.cust_name_t + " = '" + p.cust_name_t.Replace("'", "''") + "'" +
                "," + cus.cust_name_e + " = '" + p.cust_name_e + "'" +
                "," + cus.address_t + " = '" + p.address_t.Replace("'", "''") + "'" +
                "," + cus.address_e + " = '" + p.address_e.Replace("'", "''") + "'" +
                "," + cus.addr + " = '" + p.addr.Replace("'", "''") + "'" +
                "," + cus.amphur_id + " = '" + p.amphur_id.Replace("'", "''") + "'" +
                "," + cus.district_id + " = '" + p.district_id.Replace("'", "''") + "'" +
                "," + cus.province_id + " = '" + p.province_id.Replace("'", "''") + "'" +
                "," + cus.zipcode + " = '" + p.zipcode + "'" +
                "," + cus.sale_id + " = '" + p.sale_id + "'" +
                "," + cus.sale_name_t + " = '" + p.sale_name_t + "'" +
                "," + cus.fax + " = '" + p.fax + "'" +
                "," + cus.tele + " = '" + p.tele + "'" +
                "," + cus.email + " = '" + p.email + "'" +
                "," + cus.tax_id + " = '" + p.tax_id.Replace("'", "''") + "'" +
                "," + cus.date_modi + " = now()" +
                "," + cus.remark + " = '" + p.remark + "'" +
                "," + cus.contact_name1 + " = '" + p.contact_name1 + "' " +
                "," + cus.contact_name2 + " = '" + p.contact_name2 + "' " +
                "," + cus.contact_name1_tel + " = '" + p.contact_name1_tel + "' " +
                "," + cus.contact_name2_tel + " = '" + p.contact_name2_tel + "' " +
                "," + cus.status_company + " = '" + p.status_company + "' " +
                "," + cus.status_vendor + " = '" + p.status_vendor + "' " +
                "," + cus.user_modi + " = '" + p.user_modi + "' " +
                "," + cus.remark2 + " = '" + p.remark2 + "' " +
                "," + cus.po_due_period + " = '" + p.po_due_period + "' " +
                "," + cus.taddr1 + " = '" + p.taddr1 + "' " +
                "," + cus.taddr2 + " = '" + p.taddr2 + "' " +
                "," + cus.taddr3 + " = '" + p.taddr3 + "' " +
                "," + cus.taddr4 + " = '" + p.taddr4 + "' " +
                "," + cus.eaddr1 + " = '" + p.eaddr1 + "' " +
                "," + cus.eaddr2 + " = '" + p.eaddr2 + "' " +
                "," + cus.eaddr3 + " = '" + p.eaddr3 + "' " +
                "," + cus.eaddr4 + " = '" + p.eaddr4 + "' " +
                //"," + cus.user_modi + " = '" + p.user_modi + "' " +
                "Where " + cus.pkField + "='" + p.cust_id + "'"
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
        public String insertCustomer(Customer p)
        {
            String re = "";

            if (p.cust_id.Equals(""))
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
            String sql = "Delete From  " + cus.table;
            conn.ExecuteNonQuery(conn.conn, sql);

            return "";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select cop.*  " +
                "From " + cus.table + " cop " +
                " " +
                "Where cop." + cus.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select cus.* " +
                "From " + cus.table + " cus " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where cus." + cus.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public Customer selectByPk1(String copId)
        {
            Customer cop1 = new Customer();
            DataTable dt = new DataTable();
            String sql = "select cus.* " +
                "From " + cus.table + " cus " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where cus." + cus.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setCustomer(dt);
            return cop1;
        }
        private Customer setCustomer(DataTable dt)
        {
            Customer cus1 = new Customer();
            if (dt.Rows.Count > 0)
            {
                //stf1.staff_id = dt.Rows[0][cus.staff_id].ToString();
                cus1.cust_id = dt.Rows[0][cus.cust_id].ToString();
                cus1.cust_code = dt.Rows[0][cus.cust_code].ToString();
                cus1.cust_name_t = dt.Rows[0][cus.cust_name_t].ToString();
                cus1.cust_name_e = dt.Rows[0][cus.cust_name_e].ToString();
                cus1.active = dt.Rows[0][cus.active].ToString();

                cus1.address_t = dt.Rows[0][cus.address_t].ToString();
                cus1.address_e = dt.Rows[0][cus.address_e].ToString();
                cus1.addr = dt.Rows[0][cus.addr].ToString();
                cus1.amphur_id = dt.Rows[0][cus.amphur_id].ToString();
                cus1.district_id = dt.Rows[0][cus.district_id].ToString();

                cus1.province_id = dt.Rows[0][cus.province_id].ToString();
                cus1.zipcode = dt.Rows[0][cus.zipcode].ToString();
                cus1.sale_id = dt.Rows[0][cus.sale_id].ToString();
                cus1.sale_name_t = dt.Rows[0][cus.sale_name_t].ToString();
                cus1.fax = dt.Rows[0][cus.fax].ToString();

                cus1.tele = dt.Rows[0][cus.tele].ToString();
                cus1.email = dt.Rows[0][cus.email].ToString();
                cus1.tax_id = dt.Rows[0][cus.tax_id].ToString();
                cus1.remark = dt.Rows[0][cus.remark].ToString();
                cus1.contact_name1 = dt.Rows[0][cus.contact_name1].ToString();

                cus1.contact_name2 = dt.Rows[0][cus.contact_name2].ToString();
                cus1.contact_name1_tel = dt.Rows[0][cus.contact_name1_tel].ToString();
                cus1.contact_name2_tel = dt.Rows[0][cus.contact_name2_tel].ToString();
                cus1.status_company = dt.Rows[0][cus.status_company].ToString();
                cus1.status_vendor = dt.Rows[0][cus.status_vendor].ToString();

                cus1.date_create = dt.Rows[0][cus.date_create].ToString();
                cus1.date_modi = dt.Rows[0][cus.date_modi].ToString();
                cus1.date_cancel = dt.Rows[0][cus.date_cancel].ToString();
                cus1.user_create = dt.Rows[0][cus.user_create].ToString();
                cus1.user_modi = dt.Rows[0][cus.user_modi].ToString();

                cus1.user_cancel = dt.Rows[0][cus.user_cancel].ToString();
                cus1.remark2 = dt.Rows[0][cus.remark2].ToString();
                cus1.po_due_period = dt.Rows[0][cus.po_due_period].ToString();
                cus1.taddr1 = dt.Rows[0][cus.taddr1].ToString();
                cus1.taddr2 = dt.Rows[0][cus.taddr2].ToString();

                cus1.taddr3 = dt.Rows[0][cus.taddr3].ToString();
                cus1.taddr4 = dt.Rows[0][cus.taddr4].ToString();
                cus1.eaddr1 = dt.Rows[0][cus.eaddr1].ToString();
                cus1.eaddr2 = dt.Rows[0][cus.eaddr2].ToString();
                cus1.eaddr3 = dt.Rows[0][cus.eaddr3].ToString();

                cus1.eaddr4 = dt.Rows[0][cus.eaddr4].ToString();
            }

            return cus1;
        }
    }
}
