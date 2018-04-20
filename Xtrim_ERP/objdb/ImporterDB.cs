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
    public class ImporterDB
    {
        public Importer imp;
        ConnectDB conn;

        public List<Importer> lImp;

        public ImporterDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            imp = new Importer();
            imp.imp_id = "imp_id";
            imp.cust_id = "cust_id";
            imp.imp_code = "imp_code";
            imp.imp_name_t = "imp_name_t";
            imp.imp_name_e = "imp_name_e";
            imp.active = "active";

            imp.address_t = "address_t";
            imp.address_e = "address_e";
            imp.addr = "addr";
            imp.amphur_id = "amphur_id";
            imp.district_id = "district_id";

            imp.province_id = "province_id";
            imp.zipcode = "zipcode";
            imp.sale_id = "sale_id";
            imp.sale_name_t = "sale_name_t";
            imp.fax = "fax";

            imp.tele = "tele";
            imp.email = "email";
            imp.tax_id = "tax_id";
            imp.remark = "remark";
            imp.contact_name1 = "contact_name1";

            imp.contact_name2 = "contact_name2";
            imp.contact_name1_tel = "contact_name1_tel";
            imp.contact_name2_tel = "contact_name2_tel";
            imp.status_company = "status_company";
            imp.status_vendor = "status_vendor";

            imp.date_create = "date_create";
            imp.date_modi = "date_modi";
            imp.date_cancel = "date_cancel";
            imp.user_create = "user_create";
            imp.user_modi = "user_modi";

            imp.user_cancel = "user_cancel";
            imp.remark2 = "remark2";
            imp.po_due_period = "po_due_period";
            imp.taddr1 = "taddr1";
            imp.taddr2 = "taddr2";

            imp.taddr3 = "taddr3";
            imp.taddr4 = "taddr4";
            imp.eaddr1 = "eaddr1";
            imp.eaddr2 = "eaddr2";
            imp.eaddr3 = "eaddr3";

            imp.eaddr4 = "eaddr4";
            imp.remark3 = "remark3";
            imp.payerorg = "payerorg";
            imp.payerprofile = "payerprofile";
            imp.payeruser = "payeruser";

            imp.table = "b_importer";
            imp.pkField = "imp_id";

            lImp = new List<Importer>();
            getlImp();
        }
        public void setCboImp(ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectWard();
            foreach (Importer cus1 in lImp)
            {
                item = new ComboBoxItem();
                item.Value = cus1.imp_id;
                item.Text = cus1.imp_name_t;
                c.Items.Add(item);
                if (item.Value.Equals(selected))
                {
                    c.SelectedItem = item;
                }
            }
        }
        public void getlImp()
        {
            //lDept = new List<Department>();

            lImp.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                Importer imp1 = new Importer();
                imp1.imp_id = row[imp.imp_id].ToString();
                imp1.imp_code = row[imp.imp_code].ToString();
                imp1.imp_name_t = row[imp.imp_name_t].ToString();
                imp1.imp_name_e = row[imp.imp_name_e].ToString();
                //cus1.c = row[dept.dept_parent_id].ToString();
                //cus1.remark = row[dept.remark].ToString();
                //cus1.date_create = row[dept.date_create].ToString();
                //cus1.date_modi = row[dept.date_modi].ToString();
                //cus1.date_cancel = row[dept.date_cancel].ToString();
                //cus1.user_create = row[dept.user_create].ToString();
                //cus1.user_modi = row[dept.user_modi].ToString();
                //cus1.user_cancel = row[dept.user_cancel].ToString();
                //cus1.active = row[dept.active].ToString();
                lImp.Add(imp1);
            }
        }
        public String getIdByCode(String code)
        {
            String id = "";
            foreach (Importer imp1 in lImp)
            {
                if (code.Trim().Equals(imp1.imp_code))
                {
                    id = imp1.imp_id;
                    break;
                }
            }
            return id;
        }
        public String getIdByName(String name)
        {
            String id = "";
            foreach (Importer imp1 in lImp)
            {
                if (name.Trim().Equals(imp1.imp_name_t))
                {
                    id = imp1.imp_id;
                    break;
                }
            }
            return id;
        }
        public String getNameTById(String id)
        {
            String ret = "";
            foreach (Importer imp1 in lImp)
            {
                if (id.Trim().Equals(imp1.imp_name_t.Trim()))
                {
                    ret = imp1.imp_id;
                    break;
                }
            }
            return ret;
        }
        public String insert(Importer p)
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
            p.status_vendor = p.status_vendor == null ? "" : p.status_vendor;
            p.status_vendor = p.status_vendor == null ? "" : p.status_vendor;
            p.remark3 = p.remark3 == null ? "" : p.remark3;
            p.payerorg = p.payerorg == null ? "" : p.payerorg;
            p.payerprofile = p.payerprofile == null ? "" : p.payerprofile;
            p.payeruser = p.payeruser == null ? "" : p.payeruser;
            p.cust_id = int.TryParse(p.cust_id, out chk) ? chk.ToString() : "0";

            sql = "Insert Into " + imp.table + "(" + imp.imp_code + "," + imp.imp_name_t + "," + imp.imp_name_e + "," +
                imp.active + "," + imp.address_t + "," + imp.address_e + "," +
                imp.addr + "," + imp.amphur_id + "," + imp.district_id + "," +
                imp.province_id + "," + imp.zipcode + "," + imp.sale_id + "," +
                imp.sale_name_t + "," + imp.fax + "," + imp.tele + "," +
                imp.email + "," + imp.tax_id + "," + imp.remark + "," +
                imp.contact_name1 + "," + imp.contact_name2 + "," + imp.contact_name1_tel + "," +
                imp.contact_name2_tel + "," + imp.status_company + ", " + imp.status_vendor + ", " +
                imp.date_create + "," + imp.date_modi + ", " + imp.date_cancel + ", " +
                imp.user_create + "," + imp.user_modi + ", " + imp.user_cancel + ", " +
                imp.remark2 + "," + imp.po_due_period + ", " + imp.taddr1 + ", " +
                imp.taddr2 + "," + imp.taddr3 + ", " + imp.taddr4 + ", " +
                imp.eaddr1 + "," + imp.eaddr2 + ", " + imp.eaddr3 + ", " +
                imp.eaddr4 + ", " + imp.cust_id + ", "+ imp.remark3 + ", " +
                imp.payerorg + ", " + imp.payerprofile + ", " + imp.payeruser + " " +
                ") " +
                "Values ('" + p.imp_code + "','" + p.imp_name_t.Replace("'", "''") + "','" + p.imp_name_e.Replace("'", "''") + "'," +
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
                "'" + p.eaddr4.Replace("'", "''") + "','" + p.cust_id + "','" + p.remark3.Replace("'", "''") + "', " +
                "'" + p.payerorg.Replace("'", "''") + "','" + p.payerprofile.Replace("'", "''") + "','" + p.payeruser.Replace("'", "''") + "' " +
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
        public String update(Importer p)
        {
            String re = "";
            String sql = "";
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
            p.remark3 = p.remark3 == null ? "" : p.remark3;
            p.payerorg = p.payerorg == null ? "" : p.payerorg;
            p.payerprofile = p.payerprofile == null ? "" : p.payerprofile;
            p.payeruser = p.payeruser == null ? "" : p.payeruser;
            p.cust_id = int.TryParse(p.cust_id, out chk) ? chk.ToString() : "0";

            sql = "Update " + imp.table + " Set " +
                " " + imp.imp_code + " = '" + p.imp_code + "'" +
                "," + imp.imp_name_t + " = '" + p.imp_name_t.Replace("'", "''") + "'" +
                "," + imp.imp_name_e + " = '" + p.imp_name_e + "'" +
                "," + imp.address_t + " = '" + p.address_t.Replace("'", "''") + "'" +
                "," + imp.address_e + " = '" + p.address_e.Replace("'", "''") + "'" +
                "," + imp.addr + " = '" + p.addr.Replace("'", "''") + "'" +
                "," + imp.amphur_id + " = '" + p.amphur_id.Replace("'", "''") + "'" +
                "," + imp.district_id + " = '" + p.district_id.Replace("'", "''") + "'" +
                "," + imp.province_id + " = '" + p.province_id.Replace("'", "''") + "'" +
                "," + imp.zipcode + " = '" + p.zipcode + "'" +
                "," + imp.sale_id + " = '" + p.sale_id + "'" +
                "," + imp.sale_name_t + " = '" + p.sale_name_t + "'" +
                "," + imp.fax + " = '" + p.fax + "'" +
                "," + imp.tele + " = '" + p.tele + "'" +
                "," + imp.email + " = '" + p.email + "'" +
                "," + imp.tax_id + " = '" + p.tax_id.Replace("'", "''") + "'" +
                "," + imp.date_modi + " = now()" +
                "," + imp.remark + " = '" + p.remark + "'" +
                "," + imp.contact_name1 + " = '" + p.contact_name1 + "' " +
                "," + imp.contact_name2 + " = '" + p.contact_name2 + "' " +
                "," + imp.contact_name1_tel + " = '" + p.contact_name1_tel + "' " +
                "," + imp.contact_name2_tel + " = '" + p.contact_name2_tel + "' " +
                "," + imp.status_company + " = '" + p.status_company + "' " +
                "," + imp.status_vendor + " = '" + p.status_vendor + "' " +
                "," + imp.user_modi + " = '" + p.user_modi + "' " +
                "," + imp.remark2 + " = '" + p.remark2 + "' " +
                "," + imp.po_due_period + " = '" + p.po_due_period + "' " +
                "," + imp.taddr1 + " = '" + p.taddr1 + "' " +
                "," + imp.taddr2 + " = '" + p.taddr2 + "' " +
                "," + imp.taddr3 + " = '" + p.taddr3 + "' " +
                "," + imp.taddr4 + " = '" + p.taddr4 + "' " +
                "," + imp.eaddr1 + " = '" + p.eaddr1 + "' " +
                "," + imp.eaddr2 + " = '" + p.eaddr2 + "' " +
                "," + imp.eaddr3 + " = '" + p.eaddr3 + "' " +
                "," + imp.eaddr4 + " = '" + p.eaddr4 + "' " +
                "," + imp.cust_id + " = '" + p.cust_id + "' " +
                "," + imp.remark3 + " = '" + p.remark3 + "' " +
                "," + imp.payerorg + " = '" + p.payerorg + "' " +
                "," + imp.payerprofile + " = '" + p.payerprofile + "' " +
                "," + imp.payeruser + " = '" + p.payeruser + "' " +
                "Where " + imp.pkField + "='" + p.imp_id + "'"
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
        public String insertImporter(Importer p)
        {
            String re = "";

            if (p.imp_id.Equals(""))
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
            String sql = "Delete From  " + imp.table;                
            conn.ExecuteNonQuery(conn.conn, sql);

            return "";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select cop.*  " +
                "From " + imp.table + " cop " +
                " " +
                "Where cop." + imp.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select cus.* " +
                "From " + imp.table + " cus " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where cus." + imp.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public Importer selectByPk1(String copId)
        {
            Importer cop1 = new Importer();
            DataTable dt = new DataTable();
            String sql = "select cus.* " +
                "From " + imp.table + " cus " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where cus." + imp.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setImport(dt);
            return cop1;
        }
        private Importer setImport(DataTable dt)
        {
            Importer imp1 = new Importer();
            if (dt.Rows.Count > 0)
            {
                imp1.imp_id = dt.Rows[0][imp.imp_id].ToString();
                imp1.cust_id = dt.Rows[0][imp.cust_id].ToString();
                imp1.imp_code = dt.Rows[0][imp.imp_code].ToString();
                imp1.imp_name_t = dt.Rows[0][imp.imp_name_t].ToString();
                imp1.imp_name_e = dt.Rows[0][imp.imp_name_e].ToString();
                imp1.active = dt.Rows[0][imp.active].ToString();

                imp1.address_t = dt.Rows[0][imp.address_t].ToString();
                imp1.address_e = dt.Rows[0][imp.address_e].ToString();
                imp1.addr = dt.Rows[0][imp.addr].ToString();
                imp1.amphur_id = dt.Rows[0][imp.amphur_id].ToString();
                imp1.district_id = dt.Rows[0][imp.district_id].ToString();

                imp1.province_id = dt.Rows[0][imp.province_id].ToString();
                imp1.zipcode = dt.Rows[0][imp.zipcode].ToString();
                imp1.sale_id = dt.Rows[0][imp.sale_id].ToString();
                imp1.sale_name_t = dt.Rows[0][imp.sale_name_t].ToString();
                imp1.fax = dt.Rows[0][imp.fax].ToString();

                imp1.tele = dt.Rows[0][imp.tele].ToString();
                imp1.email = dt.Rows[0][imp.email].ToString();
                imp1.tax_id = dt.Rows[0][imp.tax_id].ToString();
                imp1.remark = dt.Rows[0][imp.remark].ToString();
                imp1.contact_name1 = dt.Rows[0][imp.contact_name1].ToString();

                imp1.contact_name2 = dt.Rows[0][imp.contact_name2].ToString();
                imp1.contact_name1_tel = dt.Rows[0][imp.contact_name1_tel].ToString();
                imp1.contact_name2_tel = dt.Rows[0][imp.contact_name2_tel].ToString();
                imp1.status_company = dt.Rows[0][imp.status_company].ToString();
                imp1.status_vendor = dt.Rows[0][imp.status_vendor].ToString();

                imp1.date_create = dt.Rows[0][imp.date_create].ToString();
                imp1.date_modi = dt.Rows[0][imp.date_modi].ToString();
                imp1.date_cancel = dt.Rows[0][imp.date_cancel].ToString();
                imp1.user_create = dt.Rows[0][imp.user_create].ToString();
                imp1.user_modi = dt.Rows[0][imp.user_modi].ToString();

                imp1.user_cancel = dt.Rows[0][imp.user_cancel].ToString();
                imp1.remark2 = dt.Rows[0][imp.remark2].ToString();
                imp1.po_due_period = dt.Rows[0][imp.po_due_period].ToString();
                imp1.taddr1 = dt.Rows[0][imp.taddr1].ToString();
                imp1.taddr2 = dt.Rows[0][imp.taddr2].ToString();

                imp1.taddr3 = dt.Rows[0][imp.taddr3].ToString();
                imp1.taddr4 = dt.Rows[0][imp.taddr4].ToString();
                imp1.eaddr1 = dt.Rows[0][imp.eaddr1].ToString();
                imp1.eaddr2 = dt.Rows[0][imp.eaddr2].ToString();
                imp1.eaddr3 = dt.Rows[0][imp.eaddr3].ToString();

                imp1.eaddr4 = dt.Rows[0][imp.eaddr4].ToString();
                imp1.remark3 = dt.Rows[0][imp.remark3].ToString();
                imp1.payerorg = dt.Rows[0][imp.payerorg].ToString();
                imp1.payerprofile = dt.Rows[0][imp.payerprofile].ToString();
                imp1.payeruser = dt.Rows[0][imp.payeruser].ToString();
            }

            return imp1;
        }

    }
}
