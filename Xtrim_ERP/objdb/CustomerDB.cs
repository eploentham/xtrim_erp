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
            cus.sort1 = "sort1";
            cus.status_cust = "status_cust";
            cus.status_exp = "status_exp";
            cus.status_fwd = "status_fwd";
            cus.status_imp = "status_imp";
            cus.status_cons_imp = "status_cons_imp";
            cus.status_cons_exp = "status_cons_exp";
            cus.status_insr = "status_insr";
            cus.status_supp = "status_supp";
            cus.web_site1 = "web_site1";
            cus.web_site2 = "web_site2";
            cus.web_site3 = "web_site3";

            cus.table = "b_customer";
            cus.pkField = "cust_id";

            lCus = new List<Customer>();
            //getlCus();
        }
        public void getlCus()
        {
            //lDept = new List<Position>();

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
        private void chkNull(Customer p)
        {
            int chk = 0;
            Decimal chk1 = 0;

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

            p.status_cust = p.status_cust == null ? "" : p.status_cust;
            p.status_exp = p.status_exp == null ? "" : p.status_exp;
            p.status_fwd = p.status_fwd == null ? "" : p.status_fwd;
            p.status_imp = p.status_imp == null ? "" : p.status_imp;
            p.status_cons_imp = p.status_cons_imp == null ? "" : p.status_cons_imp;
            p.status_cons_exp = p.status_cons_exp == null ? "" : p.status_cons_exp;
            p.status_supp = p.status_supp == null ? "" : p.status_supp;
            p.status_insr = p.status_insr == null ? "" : p.status_insr;
            p.web_site1 = p.web_site1 == null ? "" : p.web_site1;
            p.web_site2 = p.web_site2 == null ? "" : p.web_site2;
            p.web_site3 = p.web_site3 == null ? "" : p.web_site3;

            p.sort1 = p.sort1 == null ? "" : p.sort1;
        }
        public String insert(Customer p)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;
            
            chkNull(p);
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
                cus.eaddr4  + ", " + cus.status_cust + ", " + cus.status_exp + ", " +
                cus.status_fwd + ", " + cus.status_imp + ", " + cus.sort1 + ", " +
                cus.status_cons_imp + ", " + cus.status_cons_exp + ", " + cus.status_insr + ", " +
                cus.status_supp + ", " + cus.web_site1 + ", " + cus.web_site2 + ", " +
                cus.web_site3 + " " +
                ") " +
                "Values ('" + p.cust_code.Replace("'", "''") + "','" + p.cust_name_t.Replace("'", "''") + "','" + p.cust_name_e.Replace("'", "''") + "'," +
                "'" + p.active + "','" + p.address_t.Replace("'", "''") + "','" + p.address_e.Replace("'", "''") + "'," +
                "'" + p.addr.Replace("'", "''") + "','" + p.amphur_id + "','" + p.district_id + "'," +
                "'" + p.province_id + "','" + p.zipcode + "','" + p.sale_id + "'," +
                "'" + p.sale_name_t.Replace("'", "''") + "','" + p.fax + "','" + p.tele + "'," +
                "'" + p.email + "','" + p.tax_id + "','" + p.remark.Replace("'", "''") + "'," +
                "'" + p.contact_name1.Replace("'", "''") + "','" + p.contact_name2.Replace("'", "''") + "','" + p.contact_name1_tel + "', " +
                "'" + p.contact_name2_tel + "','" + p.status_company + "','" + p.status_vendor + "', " +
                "'" + p.date_create + "','" + p.date_modi + "','" + p.date_cancel + "', " +
                "'" + p.user_create + "','" + p.user_modi + "','" + p.user_cancel + "', " +
                "'" + p.remark2.Replace("'", "''") + "','" + p.po_due_period + "','" + p.taddr1.Replace("'", "''") + "', " +
                "'" + p.taddr2.Replace("'", "''") + "','" + p.taddr3.Replace("'", "''") + "','" + p.taddr4.Replace("'", "''") + "', " +
                "'" + p.eaddr1.Replace("'", "''") + "','" + p.eaddr2.Replace("'", "''") + "','" + p.eaddr3.Replace("'", "''") + "', " +
                "'" + p.eaddr4.Replace("'", "''") + "','" + p.status_cust.Replace("'", "''") + "','" + p.status_exp.Replace("'", "''") + "', " +
                "'" + p.status_fwd.Replace("'", "''") + "','" + p.status_imp.Replace("'", "''") + "','"+ p.sort1.Replace("'", "''") + "', " +
                "'" + p.status_cons_imp.Replace("'", "''") + "','" + p.status_cons_exp.Replace("'", "''") + "','"+ p.status_insr.Replace("'", "''") + "', " +
                "'" + p.status_supp.Replace("'", "''") + "','" + p.status_supp.Replace("'", "''") + "','" + p.status_supp.Replace("'", "''") + "', " +
                "'" + p.status_supp.Replace("'", "''") + "' " +
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

            chkNull(p);
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
                "," + cus.sale_name_t + " = '" + p.sale_name_t.Replace("'", "''") + "'" +
                "," + cus.fax + " = '" + p.fax + "'" +
                "," + cus.tele + " = '" + p.tele + "'" +
                "," + cus.email + " = '" + p.email + "'" +
                "," + cus.tax_id + " = '" + p.tax_id.Replace("'", "''") + "'" +
                "," + cus.date_modi + " = now()" +
                "," + cus.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + cus.contact_name1 + " = '" + p.contact_name1.Replace("'", "''") + "' " +
                "," + cus.contact_name2 + " = '" + p.contact_name2.Replace("'", "''") + "' " +
                "," + cus.contact_name1_tel + " = '" + p.contact_name1_tel + "' " +
                "," + cus.contact_name2_tel + " = '" + p.contact_name2_tel + "' " +
                "," + cus.status_company + " = '" + p.status_company + "' " +
                "," + cus.status_vendor + " = '" + p.status_vendor + "' " +
                "," + cus.user_modi + " = '" + p.user_modi + "' " +
                "," + cus.remark2 + " = '" + p.remark2.Replace("'", "''") + "' " +
                "," + cus.po_due_period + " = '" + p.po_due_period + "' " +
                "," + cus.taddr1 + " = '" + p.taddr1.Replace("'", "''") + "' " +
                "," + cus.taddr2 + " = '" + p.taddr2.Replace("'", "''") + "' " +
                "," + cus.taddr3 + " = '" + p.taddr3.Replace("'", "''") + "' " +
                "," + cus.taddr4 + " = '" + p.taddr4.Replace("'", "''") + "' " +
                "," + cus.eaddr1 + " = '" + p.eaddr1.Replace("'", "''") + "' " +
                "," + cus.eaddr2 + " = '" + p.eaddr2.Replace("'", "''") + "' " +
                "," + cus.eaddr3 + " = '" + p.eaddr3.Replace("'", "''") + "' " +
                "," + cus.eaddr4 + " = '" + p.eaddr4.Replace("'", "''") + "' " +
                "," + cus.status_cust + " = '" + p.status_cust + "' " +
                "," + cus.status_exp + " = '" + p.status_exp + "' " +
                "," + cus.status_fwd + " = '" + p.status_fwd + "' " +
                "," + cus.status_imp + " = '" + p.status_imp + "' " +
                "," + cus.sort1 + " = '" + p.sort1 + "' " +
                "," + cus.status_cons_exp + " = '" + p.status_cons_exp + "' " +
                "," + cus.status_cons_imp + " = '" + p.status_cons_imp + "' " +
                "," + cus.status_insr + " = '" + p.status_insr + "' " +
                "," + cus.status_supp + " = '" + p.status_supp + "' " +
                "," + cus.web_site1 + " = '" + p.web_site1 + "' " +
                "," + cus.web_site2 + " = '" + p.web_site2 + "' " +
                "," + cus.web_site3 + " = '" + p.web_site3 + "' " +
                //"," + cus.user_modi + " = '" + p.user_modi + "' " +
                "Where " + cus.pkField + "='" + p.cust_id + "'";

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
        public String voidCustomer(String cusId)
        {
            String re = "";
            DataTable dt = new DataTable();
            String sql = "Update " + cus.table + " " +
                "Set "+cus.active + "='3' " +
                "Where "+cus.pkField+"='"+cusId+"'";
            re =  conn.ExecuteNonQuery(conn.conn, sql);

            return re;
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
        public DataTable selectAll1()
        {
            DataTable dt = new DataTable();
            String sql = "select cop.cust_id, cop.cust_code, cop.cust_name_t, cop.taddr1, cop.tele, cop.email, cop.remark, cop.remark2, cop.contact_name1, cop.contact_name2 " +
                "From " + cus.table + " cop " +
                " " +
                "Where cop." + cus.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectCusAll()
        {
            DataTable dt = new DataTable();
            String sql = "select cop.cust_id, cop.cust_code, cop.cust_name_t, cop.taddr1, cop.tele, cop.email, cop.remark, cop.remark2, cop.contact_name1, cop.contact_name2 " +
                "From " + cus.table + " cop " +
                " " +
                "Where cop." + cus.active + " ='1' and cop."+cus.status_cust+"='1'";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectImpAll()
        {
            DataTable dt = new DataTable();
            String sql = "select cop.cust_id, cop.cust_code, cop.cust_name_t, cop.taddr1, cop.tele, cop.email, cop.remark, cop.remark2, cop.contact_name1, cop.contact_name2 " +
                "From " + cus.table + " cop " +
                " " +
                "Where cop." + cus.active + " ='1' and cop." + cus.status_imp + "='1'";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectAll2(String flagCus, String flagImp, String flagExp, String flagConsImp, String flagConsExp, String flagInsr, String flagFwd, String flagSupp)
        {
            DataTable dt = new DataTable();
            String where = "", sql = "", whereCus = "", whereImp = "", whereExp = "", whereConsImp = "", whereConsExp="", whereInsr="", whereFwd="", whereSupp="";
            whereCus = flagCus.Equals("1") ? "  (cop." + cus.active + " ='1'  and cop." + cus.status_cust+"='1') " : "  ";
            whereImp = flagImp.Equals("1") ? " or (cop." + cus.active + " ='1'  and cop." + cus.status_imp + "='1') " : "  ";
            whereExp = flagExp.Equals("1") ? " or (cop." + cus.active + " ='1'  and cop." + cus.status_exp + "='1') " : "  ";
            whereConsImp = flagConsImp.Equals("1") ? " or (cop." + cus.active + " ='1'  and cop." + cus.status_cons_imp + "='1') " : "  ";
            whereConsExp = flagConsExp.Equals("1") ? " or (cop." + cus.active + " ='1'  and cop." + cus.status_cons_exp + "='1') " : "  ";
            whereInsr = flagInsr.Equals("1") ? " or (cop." + cus.active + " ='1'  and cop." + cus.status_insr + "='1') " : "  ";
            whereFwd = flagFwd.Equals("1") ? " or (cop." + cus.active + " ='1'  and cop." + cus.status_fwd + "='1') " : "  ";
            whereSupp = flagSupp.Equals("1") ? " or (cop." + cus.active + " ='1'  and cop." + cus.status_supp + "='1') " : "  ";
            where = "";
            if (flagCus.Equals("1") && flagImp.Equals("1") && flagExp.Equals("1") && flagConsImp.Equals("1") &&
                flagConsExp.Equals("1") && flagInsr.Equals("1") && flagFwd.Equals("1") && flagSupp.Equals("1"))
            {
                where = " cop." + cus.active + " ='1' ";     //ให้ดึงมาให้หมด
            }
            else if(whereCus.Trim().Equals("") && whereImp.Trim().Equals("") && whereExp.Trim().Equals("") && whereConsImp.Trim().Equals("") &&
                whereConsExp.Trim().Equals("") && whereInsr.Trim().Equals("") && whereFwd.Trim().Equals("") && whereSupp.Trim().Equals("") )
            {
                where = " cop." + cus.active + " ='1'  and cop." + cus.cust_code+"='*********'";       //ต้องการให้ เป็นค่าว่าง 
            }
            else
            {
                where = whereCus + whereImp + whereExp + whereConsImp + whereConsExp + whereInsr + whereFwd + whereSupp;
            }
            
            if (where.Trim().IndexOf("or") == 0)
            {
                int index = 0;
                index = where.IndexOf("or");
                where = where.Remove(index, 2);
            }
            //where = where.Trim().IndexOf("or") >= 0 ? where = where.re("or", "") : where;
            sql = "select cop.cust_id, cop.cust_code, cop.cust_name_t, cop.taddr1, cop.tele, cop.email, cop.remark, cop.remark2, cop.contact_name1, cop.contact_name2 " +
                "From " + cus.table + " cop " +
                " " +
                "Where "+ where;
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByCodeLike(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select cus.* " +
                "From " + cus.table + " cus " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where LOWER(cus." + cus.cust_code + ") like '" + copId.ToLower() + "%' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectCusByCodeLike(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select cus.* " +
                "From " + cus.table + " cus " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where LOWER(cus." + cus.cust_code + ") like '" + copId.ToLower() + "%' and " + cus.status_cust + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectImpIdByCodeLike(String copId)
        {
            DataTable dt = new DataTable();
            String cusId = "";
            String sql = "select cus.* " +
                "From " + cus.table + " cus " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where LOWER(cus." + cus.cust_code + ") like '" + copId.ToLower() + "%' and " + cus.status_imp + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            
            return dt;
        }
        public String selectImpIdByCodeLike1(String copId)
        {
            DataTable dt = new DataTable();
            String cusId = "";
            String sql = "select cus.* " +
                "From " + cus.table + " cus " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where LOWER(cus." + cus.cust_code + ") like '" + copId.ToLower() + "%' and "+cus.status_imp+"='1' ";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                cusId = dt.Rows[0][cus.cust_id].ToString();
            }
            return cusId;
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
        public Customer setCustomer(DataTable dt)
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
                cus1.status_cust = dt.Rows[0][cus.status_cust].ToString();
                cus1.status_exp = dt.Rows[0][cus.status_exp].ToString();
                cus1.status_fwd = dt.Rows[0][cus.status_fwd].ToString();
                cus1.status_imp = dt.Rows[0][cus.status_imp].ToString();
                cus1.sort1 = dt.Rows[0][cus.sort1].ToString();

                cus1.status_cons_exp = dt.Rows[0][cus.status_cons_exp].ToString();
                cus1.status_cons_imp = dt.Rows[0][cus.status_cons_imp].ToString();
                cus1.status_insr = dt.Rows[0][cus.status_insr].ToString();
                cus1.status_supp = dt.Rows[0][cus.status_supp].ToString();
                cus1.web_site1 = dt.Rows[0][cus.web_site1].ToString();
                cus1.web_site2 = dt.Rows[0][cus.web_site2].ToString();
                cus1.web_site3 = dt.Rows[0][cus.web_site3].ToString();
            }

            return cus1;
        }
    }
}
