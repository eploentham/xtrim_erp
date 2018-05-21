using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xtrim_ERP.object1;

namespace Xtrim_ERP.objdb
{
    public class ConsigneeDB
    {
        public Consignee cons;
        ConnectDB conn;

        public List<Consignee> lCons;
        public List<Consignee> lSupp;

        public ConsigneeDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            cons = new Consignee();
            cons.cons_id = "cons_id";
            cons.cons_code = "cons_code";
            cons.cons_name_t = "cons_name_t";
            cons.cons_name_e = "cons_name_e";
            cons.active = "active";
            cons.address_t = "address_t";
            cons.address_e = "address_e";
            cons.addr = "addr";
            cons.amphur_id = "amphur_id";
            cons.district_id = "district_id";
            cons.province_id = "province_id";
            cons.zipcode = "zipcode";
            cons.sale_id = "sale_id";
            cons.sale_name_t = "sale_name_t";
            cons.fax = "fax";
            cons.tele = "tele";
            cons.email = "email";
            cons.tax_id = "tax_id";
            cons.remark = "remark";
            cons.contact_name1 = "contact_name1";
            cons.contact_name2 = "contact_name2";
            cons.contact_name1_tel = "contact_name1_tel";
            cons.contact_name2_tel = "contact_name2_tel";
            cons.status_company = "status_company";
            cons.status_vendor = "status_vendor";
            cons.date_create = "date_create";
            cons.date_modi = "date_modi";
            cons.date_cancel = "date_cancel";
            cons.user_create = "user_create";
            cons.user_modi = "user_modi";
            cons.user_cancel = "user_cancel";
            cons.remark2 = "remark2";
            cons.po_due_period = "po_due_period";
            cons.taddr1 = "taddr1";
            cons.taddr2 = "taddr2";
            cons.taddr3 = "taddr3";
            cons.taddr4 = "taddr4";
            cons.eaddr1 = "eaddr1";
            cons.eaddr2 = "eaddr2";
            cons.eaddr3 = "eaddr3";
            cons.eaddr4 = "eaddr4";
            cons.status_cons = "status_cons";

            cons.table = "b_consignee";
            cons.pkField = "cons_id";
            lCons = new List<Consignee>();
            lSupp = new List<Consignee>();
            //getlCons();
            //getlSupp();
        }
        public String getSuppIdByCode(String code)
        {
            String id = "";
            foreach (Consignee cons1 in lSupp)
            {
                if (code.Trim().Equals(cons1.cons_code))
                {
                    id = cons1.cons_id;
                    break;
                }
            }
            return id;
        }
        public void getlCons()
        {
            //lDept = new List<Department>();

            lCons.Clear();
            DataTable dt = new DataTable();
            dt = selectConsigneeAll();
            foreach (DataRow row in dt.Rows)
            {
                Consignee jim1 = new Consignee();
                jim1.cons_id = row[cons.cons_id].ToString();
                jim1.cons_code = row[cons.cons_code].ToString();

                lCons.Add(jim1);

            }
        }
        public void getlSupp()
        {
            //lDept = new List<Department>();

            lSupp.Clear();
            DataTable dt = new DataTable();
            dt = selectSupplierAll();
            foreach (DataRow row in dt.Rows)
            {
                Consignee jim1 = new Consignee();
                jim1.cons_id = row[cons.cons_id].ToString();
                jim1.cons_code = row[cons.cons_code].ToString();

                lSupp.Add(jim1);

            }
        }
        public String insert(Consignee p)
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

            sql = "Insert Into " + cons.table + "(" + cons.cons_code + "," + cons.cons_name_t + "," + cons.cons_name_e + "," +
                cons.active + "," + cons.address_t + "," + cons.address_e + "," +
                cons.addr + "," + cons.amphur_id + "," + cons.district_id + "," +
                cons.province_id + "," + cons.zipcode + "," + cons.sale_id + "," +
                cons.sale_name_t + "," + cons.fax + "," + cons.tele + "," +
                cons.email + "," + cons.tax_id + "," + cons.remark + "," +
                cons.contact_name1 + "," + cons.contact_name2 + "," + cons.contact_name1_tel + "," +
                cons.contact_name2_tel + "," + cons.status_company + ", " + cons.status_vendor + ", " +
                cons.date_create + "," + cons.date_modi + ", " + cons.date_cancel + ", " +
                cons.user_create + "," + cons.user_modi + ", " + cons.user_cancel + ", " +
                cons.remark2 + "," + cons.po_due_period + ", " + cons.taddr1 + ", " +
                cons.taddr2 + "," + cons.taddr3 + ", " + cons.taddr4 + ", " +
                cons.eaddr1 + "," + cons.eaddr2 + ", " + cons.eaddr3 + ", " +
                cons.eaddr4 + "," + cons.status_cons + " " +
                ") " +
                "Values ('" + p.cons_code.Replace("'", "''") + "','" + p.cons_name_t.Replace("'", "''") + "','" + p.cons_name_e.Replace("'", "''") + "'," +
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
                "'" + p.eaddr4.Replace("'", "''") + "', '" + p.status_cons + "' " +
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
        public String update(Consignee p)
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

            sql = "Update " + cons.table + " Set " +
                " " + cons.cons_code + " = '" + p.cons_code.Replace("'", "''") + "'" +
                "," + cons.cons_name_t + " = '" + p.cons_name_t.Replace("'", "''") + "'" +
                "," + cons.cons_name_e + " = '" + p.cons_name_e + "'" +
                "," + cons.address_t + " = '" + p.address_t.Replace("'", "''") + "'" +
                "," + cons.address_e + " = '" + p.address_e.Replace("'", "''") + "'" +
                "," + cons.addr + " = '" + p.addr.Replace("'", "''") + "'" +
                "," + cons.amphur_id + " = '" + p.amphur_id.Replace("'", "''") + "'" +
                "," + cons.district_id + " = '" + p.district_id.Replace("'", "''") + "'" +
                "," + cons.province_id + " = '" + p.province_id.Replace("'", "''") + "'" +
                "," + cons.zipcode + " = '" + p.zipcode + "'" +
                "," + cons.sale_id + " = '" + p.sale_id + "'" +
                "," + cons.sale_name_t + " = '" + p.sale_name_t + "'" +
                "," + cons.fax + " = '" + p.fax + "'" +
                "," + cons.tele + " = '" + p.tele + "'" +
                "," + cons.email + " = '" + p.email + "'" +
                "," + cons.tax_id + " = '" + p.tax_id.Replace("'", "''") + "'" +
                "," + cons.date_modi + " = now()" +
                "," + cons.remark + " = '" + p.remark + "'" +
                "," + cons.contact_name1 + " = '" + p.contact_name1 + "' " +
                "," + cons.contact_name2 + " = '" + p.contact_name2 + "' " +
                "," + cons.contact_name1_tel + " = '" + p.contact_name1_tel + "' " +
                "," + cons.contact_name2_tel + " = '" + p.contact_name2_tel + "' " +
                "," + cons.status_company + " = '" + p.status_company + "' " +
                "," + cons.status_vendor + " = '" + p.status_vendor + "' " +
                "," + cons.user_modi + " = '" + p.user_modi + "' " +
                "," + cons.remark2 + " = '" + p.remark2 + "' " +
                "," + cons.po_due_period + " = '" + p.po_due_period + "' " +
                "," + cons.taddr1 + " = '" + p.taddr1 + "' " +
                "," + cons.taddr2 + " = '" + p.taddr2 + "' " +
                "," + cons.taddr3 + " = '" + p.taddr3 + "' " +
                "," + cons.taddr4 + " = '" + p.taddr4 + "' " +
                "," + cons.eaddr1 + " = '" + p.eaddr1 + "' " +
                "," + cons.eaddr2 + " = '" + p.eaddr2 + "' " +
                "," + cons.eaddr3 + " = '" + p.eaddr3 + "' " +
                "," + cons.eaddr4 + " = '" + p.eaddr4 + "' " +
                //"," + cons.user_modi + " = '" + p.user_modi + "' " +
                "Where " + cons.pkField + "='" + p.cons_id + "'"
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
        public String insertConsignee(Consignee p)
        {
            String re = "";

            if (p.cons_id.Equals(""))
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
            String sql = "Delete From  " + cons.table;
            conn.ExecuteNonQuery(conn.conn, sql);

            return "";
        }
        public String deleteConsigneeAll()
        {
            DataTable dt = new DataTable();
            String sql = "Delete From  " + cons.table + " Where " + cons.status_cons + "='1'";
            conn.ExecuteNonQuery(conn.conn, sql);

            return "";
        }
        public String deleteExpConsigneeAll()
        {
            DataTable dt = new DataTable();
            String sql = "Delete From  " + cons.table + " Where " + cons.status_cons + "='2'";
            conn.ExecuteNonQuery(conn.conn, sql);

            return "";
        }
        public String deleteImpSupplierAll()
        {
            DataTable dt = new DataTable();
            String sql = "Delete From  " + cons.table + " Where " + cons.status_cons + "='4'";
            conn.ExecuteNonQuery(conn.conn, sql);

            return "";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select cons.*  " +
                "From " + cons.table + " cons " +
                " " +
                "Where cons." + cons.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectConsigneeAll()
        {
            DataTable dt = new DataTable();
            String sql = "select cons.*  " +
                "From " + cons.table + " cons " +
                " " +
                "Where cons." + cons.active + " ='1' and cons." + cons.status_cons + "='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectSupplierAll()
        {
            DataTable dt = new DataTable();
            String sql = "select cons.*  " +
                "From " + cons.table + " cons " +
                " " +
                "Where cons." + cons.active + " ='1' and cons." + cons.status_cons + "='4' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectExConsigneeAll()
        {
            DataTable dt = new DataTable();
            String sql = "select cons.*  " +
                "From " + cons.table + " cons " +
                " " +
                "Where cons." + cons.active + " ='1' and cons." + cons.status_cons + "='2' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select cons.* " +
                "From " + cons.table + " cons " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where cons." + cons.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public Consignee selectByPk1(String copId)
        {
            Consignee cop1 = new Consignee();
            DataTable dt = new DataTable();
            String sql = "select cons.* " +
                "From " + cons.table + " cons " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where cons." + cons.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setConsignee(dt);
            return cop1;
        }
        private Consignee setConsignee(DataTable dt)
        {
            Consignee cons1 = new Consignee();
            if (dt.Rows.Count > 0)
            {
                //stf1.staff_id = dt.Rows[0][cus.staff_id].ToString();
                cons1.cons_id = dt.Rows[0][cons.cons_id].ToString();
                cons1.cons_code = dt.Rows[0][cons.cons_code].ToString();
                cons1.cons_name_t = dt.Rows[0][cons.cons_name_t].ToString();
                cons1.cons_name_e = dt.Rows[0][cons.cons_name_e].ToString();
                cons1.active = dt.Rows[0][cons.active].ToString();

                cons1.address_t = dt.Rows[0][cons.address_t].ToString();
                cons1.address_e = dt.Rows[0][cons.address_e].ToString();
                cons1.addr = dt.Rows[0][cons.addr].ToString();
                cons1.amphur_id = dt.Rows[0][cons.amphur_id].ToString();
                cons1.district_id = dt.Rows[0][cons.district_id].ToString();

                cons1.province_id = dt.Rows[0][cons.province_id].ToString();
                cons1.zipcode = dt.Rows[0][cons.zipcode].ToString();
                cons1.sale_id = dt.Rows[0][cons.sale_id].ToString();
                cons1.sale_name_t = dt.Rows[0][cons.sale_name_t].ToString();
                cons1.fax = dt.Rows[0][cons.fax].ToString();

                cons1.tele = dt.Rows[0][cons.tele].ToString();
                cons1.email = dt.Rows[0][cons.email].ToString();
                cons1.tax_id = dt.Rows[0][cons.tax_id].ToString();
                cons1.remark = dt.Rows[0][cons.remark].ToString();
                cons1.contact_name1 = dt.Rows[0][cons.contact_name1].ToString();

                cons1.contact_name2 = dt.Rows[0][cons.contact_name2].ToString();
                cons1.contact_name1_tel = dt.Rows[0][cons.contact_name1_tel].ToString();
                cons1.contact_name2_tel = dt.Rows[0][cons.contact_name2_tel].ToString();
                cons1.status_company = dt.Rows[0][cons.status_company].ToString();
                cons1.status_vendor = dt.Rows[0][cons.status_vendor].ToString();

                cons1.date_create = dt.Rows[0][cons.date_create].ToString();
                cons1.date_modi = dt.Rows[0][cons.date_modi].ToString();
                cons1.date_cancel = dt.Rows[0][cons.date_cancel].ToString();
                cons1.user_create = dt.Rows[0][cons.user_create].ToString();
                cons1.user_modi = dt.Rows[0][cons.user_modi].ToString();

                cons1.user_cancel = dt.Rows[0][cons.user_cancel].ToString();
                cons1.remark2 = dt.Rows[0][cons.remark2].ToString();
                cons1.po_due_period = dt.Rows[0][cons.po_due_period].ToString();
                cons1.taddr1 = dt.Rows[0][cons.taddr1].ToString();
                cons1.taddr2 = dt.Rows[0][cons.taddr2].ToString();

                cons1.taddr3 = dt.Rows[0][cons.taddr3].ToString();
                cons1.taddr4 = dt.Rows[0][cons.taddr4].ToString();
                cons1.eaddr1 = dt.Rows[0][cons.eaddr1].ToString();
                cons1.eaddr2 = dt.Rows[0][cons.eaddr2].ToString();
                cons1.eaddr3 = dt.Rows[0][cons.eaddr3].ToString();

                cons1.eaddr4 = dt.Rows[0][cons.eaddr4].ToString();
            }

            return cons1;
        }
    }
}
