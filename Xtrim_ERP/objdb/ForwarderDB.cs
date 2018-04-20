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
    public class ForwarderDB
    {
        public Forwarder fwd;
        ConnectDB conn;

        public List<Forwarder> lFwd;

        public ForwarderDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            fwd = new Forwarder();
            fwd.forwarder_id = "forwarder_id";
            //imp.cust_id = "cust_id";
            fwd.forwarder_code = "forwarder_code";
            fwd.forwarder_name_t = "forwarder_name_t";
            fwd.forwarder_name_e = "forwarder_name_e";
            fwd.active = "active";

            fwd.address_t = "address_t";
            fwd.address_e = "address_e";
            fwd.addr = "addr";
            fwd.amphur_id = "amphur_id";
            fwd.district_id = "district_id";

            fwd.province_id = "province_id";
            fwd.zipcode = "zipcode";
            fwd.sale_id = "sale_id";
            fwd.sale_name_t = "sale_name_t";
            fwd.fax = "fax";

            fwd.tele = "tele";
            fwd.email = "email";
            fwd.tax_id = "tax_id";
            fwd.remark = "remark";
            fwd.contact_name1 = "contact_name1";

            fwd.contact_name2 = "contact_name2";
            fwd.contact_name1_tel = "contact_name1_tel";
            fwd.contact_name2_tel = "contact_name2_tel";
            fwd.status_company = "status_company";
            fwd.status_vendor = "status_vendor";

            fwd.date_create = "date_create";
            fwd.date_modi = "date_modi";
            fwd.date_cancel = "date_cancel";
            fwd.user_create = "user_create";
            fwd.user_modi = "user_modi";

            fwd.user_cancel = "user_cancel";
            fwd.remark2 = "remark2";
            fwd.po_due_period = "po_due_period";
            fwd.taddr1 = "taddr1";
            fwd.taddr2 = "taddr2";

            fwd.taddr3 = "taddr3";
            fwd.taddr4 = "taddr4";
            fwd.eaddr1 = "eaddr1";
            fwd.eaddr2 = "eaddr2";
            fwd.eaddr3 = "eaddr3";

            fwd.eaddr4 = "eaddr4";
            fwd.remark3 = "remark3";
            fwd.payerorg = "payerorg";
            fwd.payerprofile = "payerprofile";
            fwd.payeruser = "payeruser";

            fwd.contact_name3 = "contact_name3";
            fwd.contact_name4 = "contact_name4";
            fwd.contact_name5 = "contact_name5";
            fwd.contact_name6 = "contact_name6";
            fwd.contact_name3_tel = "contact_name3_tel";
            fwd.contact_name4_tel = "contact_name4_tel";
            fwd.contact_name5_tel = "contact_name5_tel";
            fwd.contact_name6_tel = "contact_name6_tel";

            fwd.table = "b_forwarder";
            fwd.pkField = "forwarder_id";

            lFwd = new List<Forwarder>();

            getlFwd();
        }
        public void setCboFwd(ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectWard();
            foreach (Forwarder cus1 in lFwd)
            {
                item = new ComboBoxItem();
                item.Value = cus1.forwarder_id;
                item.Text = cus1.forwarder_name_t;
                c.Items.Add(item);
                if (item.Value.Equals(selected))
                {
                    c.SelectedItem = item;
                }
            }
        }
        public void getlFwd()
        {
            //lDept = new List<Department>();

            lFwd.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                Forwarder fwd = new Forwarder();
                fwd.forwarder_id = row[this.fwd.forwarder_id].ToString();
                fwd.forwarder_code = row[this.fwd.forwarder_code].ToString();
                fwd.forwarder_name_t = row[this.fwd.forwarder_name_t].ToString();
                fwd.forwarder_name_e = row[this.fwd.forwarder_name_e].ToString();
                //cus1.c = row[dept.dept_parent_id].ToString();
                //cus1.remark = row[dept.remark].ToString();
                //cus1.date_create = row[dept.date_create].ToString();
                //cus1.date_modi = row[dept.date_modi].ToString();
                //cus1.date_cancel = row[dept.date_cancel].ToString();
                //cus1.user_create = row[dept.user_create].ToString();
                //cus1.user_modi = row[dept.user_modi].ToString();
                //cus1.user_cancel = row[dept.user_cancel].ToString();
                //cus1.active = row[dept.active].ToString();
                lFwd.Add(fwd);
            }
        }
        public String getIdByCode(String code)
        {
            String id = "";
            foreach (Forwarder fwd in lFwd)
            {
                if (code.Equals(fwd.forwarder_code))
                {
                    id = fwd.forwarder_id;
                    break;
                }
            }
            return id;
        }
        public String getIdByName(String name)
        {
            String id = "";
            foreach (Forwarder fwd1 in lFwd)
            {
                if (name.Equals(fwd1.forwarder_name_t))
                {
                    id = fwd1.forwarder_id;
                    break;
                }
            }
            return id;
        }
        private void chkNull(Forwarder p)
        {
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

            p.contact_name1 = p.contact_name1 == null ? "" : p.contact_name1;
            p.contact_name2 = p.contact_name2 == null ? "" : p.contact_name2;
            p.contact_name3 = p.contact_name3 == null ? "" : p.contact_name3;
            p.contact_name4 = p.contact_name4 == null ? "" : p.contact_name4;
            p.contact_name5 = p.contact_name5 == null ? "" : p.contact_name5;
            p.contact_name6 = p.contact_name6 == null ? "" : p.contact_name6;
            p.contact_name1_tel = p.contact_name1_tel == null ? "" : p.contact_name1_tel;
            p.contact_name2_tel = p.contact_name2_tel == null ? "" : p.contact_name2_tel;
            p.contact_name3_tel = p.contact_name3_tel == null ? "" : p.contact_name3_tel;
            p.contact_name4_tel = p.contact_name4_tel == null ? "" : p.contact_name4_tel;
            p.contact_name5_tel = p.contact_name5_tel == null ? "" : p.contact_name5_tel;
            p.contact_name6_tel = p.contact_name6_tel == null ? "" : p.contact_name6_tel;
        }
        public String insert(Forwarder p)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            

            chkNull(p);
            //p.cust_id = int.TryParse(p.cust_id, out chk) ? chk.ToString() : "0";

            sql = "Insert Into " + fwd.table + "(" + fwd.forwarder_code + "," + fwd.forwarder_name_t + "," + fwd.forwarder_name_e + "," +
                fwd.active + "," + fwd.address_t + "," + fwd.address_e + "," +
                fwd.addr + "," + fwd.amphur_id + "," + fwd.district_id + "," +
                fwd.province_id + "," + fwd.zipcode + "," + fwd.sale_id + "," +
                fwd.sale_name_t + "," + fwd.fax + "," + fwd.tele + "," +
                fwd.email + "," + fwd.tax_id + "," + fwd.remark + "," +
                fwd.contact_name1 + "," + fwd.contact_name2 + "," + fwd.contact_name1_tel + "," +
                fwd.contact_name2_tel + "," + fwd.status_company + ", " + fwd.status_vendor + ", " +
                fwd.date_create + "," + fwd.date_modi + ", " + fwd.date_cancel + ", " +
                fwd.user_create + "," + fwd.user_modi + ", " + fwd.user_cancel + ", " +
                fwd.remark2 + "," + fwd.po_due_period + ", " + fwd.taddr1 + ", " +
                fwd.taddr2 + "," + fwd.taddr3 + ", " + fwd.taddr4 + ", " +
                fwd.eaddr1 + "," + fwd.eaddr2 + ", " + fwd.eaddr3 + ", " +
                fwd.eaddr4 + ", " + fwd.remark3 + ", " +
                fwd.payerorg + ", " + fwd.payerprofile + ", " + fwd.payeruser + ", " +
                fwd.contact_name3 + ", " + fwd.contact_name4 + ", " + fwd.contact_name5 + ", " +
                fwd.contact_name6 + ", " + fwd.contact_name3_tel + ", " + fwd.contact_name4_tel + ", " + 
                fwd.contact_name5_tel + ", " + fwd.contact_name6_tel + " " +
                ") " +
                "Values ('" + p.forwarder_code.Replace("'", "''") + "','" + p.forwarder_name_t.Replace("'", "''") + "','" + p.forwarder_name_e.Replace("'", "''") + "'," +
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
                "'" + p.eaddr4.Replace("'", "''") + "','" + p.remark3.Replace("'", "''") + "', " +
                "'" + p.payerorg.Replace("'", "''") + "','" + p.payerprofile.Replace("'", "''") + "','" + p.payeruser.Replace("'", "''") + "', " +
                "'" + p.contact_name3.Replace("'", "''") + "','" + p.contact_name4.Replace("'", "''") + "','" + p.contact_name5.Replace("'", "''") + "', " +
                "'" + p.contact_name6.Replace("'", "''") + "','" + p.contact_name3_tel.Replace("'", "''") + "','" + p.contact_name4_tel.Replace("'", "''") + "'," + 
                "'" + p.contact_name5_tel.Replace("'", "''") + "','" + p.contact_name6_tel.Replace("'", "''") + "' "  +
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
        public String update(Forwarder p)
        {
            String re = "";
            String sql = "";

            chkNull(p);

            sql = "Update " + fwd.table + " Set " +
                " " + fwd.forwarder_code + " = '" + p.forwarder_code + "'" +
                "," + fwd.forwarder_name_t + " = '" + p.forwarder_name_t.Replace("'", "''") + "'" +
                "," + fwd.forwarder_name_e + " = '" + p.forwarder_name_e + "'" +
                "," + fwd.address_t + " = '" + p.address_t.Replace("'", "''") + "'" +
                "," + fwd.address_e + " = '" + p.address_e.Replace("'", "''") + "'" +
                "," + fwd.addr + " = '" + p.addr.Replace("'", "''") + "'" +
                "," + fwd.amphur_id + " = '" + p.amphur_id.Replace("'", "''") + "'" +
                "," + fwd.district_id + " = '" + p.district_id.Replace("'", "''") + "'" +
                "," + fwd.province_id + " = '" + p.province_id.Replace("'", "''") + "'" +
                "," + fwd.zipcode + " = '" + p.zipcode + "'" +
                "," + fwd.sale_id + " = '" + p.sale_id + "'" +
                "," + fwd.sale_name_t + " = '" + p.sale_name_t + "'" +
                "," + fwd.fax + " = '" + p.fax + "'" +
                "," + fwd.tele + " = '" + p.tele + "'" +
                "," + fwd.email + " = '" + p.email + "'" +
                "," + fwd.tax_id + " = '" + p.tax_id.Replace("'", "''") + "'" +
                "," + fwd.date_modi + " = now()" +
                "," + fwd.remark + " = '" + p.remark + "'" +
                "," + fwd.contact_name1 + " = '" + p.contact_name1 + "' " +
                "," + fwd.contact_name2 + " = '" + p.contact_name2 + "' " +
                "," + fwd.contact_name1_tel + " = '" + p.contact_name1_tel + "' " +
                "," + fwd.contact_name2_tel + " = '" + p.contact_name2_tel + "' " +
                "," + fwd.status_company + " = '" + p.status_company + "' " +
                "," + fwd.status_vendor + " = '" + p.status_vendor + "' " +
                "," + fwd.user_modi + " = '" + p.user_modi + "' " +
                "," + fwd.remark2 + " = '" + p.remark2 + "' " +
                "," + fwd.po_due_period + " = '" + p.po_due_period + "' " +
                "," + fwd.taddr1 + " = '" + p.taddr1 + "' " +
                "," + fwd.taddr2 + " = '" + p.taddr2 + "' " +
                "," + fwd.taddr3 + " = '" + p.taddr3 + "' " +
                "," + fwd.taddr4 + " = '" + p.taddr4 + "' " +
                "," + fwd.eaddr1 + " = '" + p.eaddr1 + "' " +
                "," + fwd.eaddr2 + " = '" + p.eaddr2 + "' " +
                "," + fwd.eaddr3 + " = '" + p.eaddr3 + "' " +
                "," + fwd.eaddr4 + " = '" + p.eaddr4 + "' " +
                //"," + imp.cust_id + " = '" + p.cust_id + "' " +
                "," + fwd.remark3 + " = '" + p.remark3 + "' " +
                "," + fwd.payerorg + " = '" + p.payerorg + "' " +
                "," + fwd.payerprofile + " = '" + p.payerprofile + "' " +
                "," + fwd.payeruser + " = '" + p.payeruser + "' " +
                "," + fwd.contact_name3 + " = '" + p.contact_name3 + "' " +
                "," + fwd.contact_name4 + " = '" + p.contact_name4 + "' " +
                "," + fwd.contact_name5 + " = '" + p.contact_name5 + "' " +
                "," + fwd.contact_name6 + " = '" + p.contact_name6 + "' " +
                "," + fwd.contact_name3_tel + " = '" + p.contact_name3_tel + "' " +
                "," + fwd.contact_name4_tel + " = '" + p.contact_name4_tel + "' " +
                "," + fwd.contact_name5_tel + " = '" + p.contact_name5_tel + "' " +
                "," + fwd.contact_name6_tel + " = '" + p.contact_name6_tel + "' " +
                "Where " + fwd.pkField + "='" + p.forwarder_id + "'"
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
        public String insertForwarder(Forwarder p)
        {
            String re = "";

            if (p.forwarder_id.Equals(""))
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
            String sql = "Delete From  " + fwd.table;
            conn.ExecuteNonQuery(conn.conn, sql);

            return "";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select cop.*  " +
                "From " + fwd.table + " cop " +
                " " +
                "Where cop." + fwd.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select cus.* " +
                "From " + fwd.table + " cus " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where cus." + fwd.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public Forwarder selectByPk1(String copId)
        {
            Forwarder cop1 = new Forwarder();
            DataTable dt = new DataTable();
            String sql = "select cus.* " +
                "From " + fwd.table + " cus " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where cus." + fwd.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setImport(dt);
            return cop1;
        }
        private Forwarder setImport(DataTable dt)
        {
            Forwarder fwd1 = new Forwarder();
            if (dt.Rows.Count > 0)
            {
                fwd1.forwarder_id = dt.Rows[0][fwd.forwarder_id].ToString();
                //imp1.cust_id = dt.Rows[0][fwd.cust_id].ToString();
                fwd1.forwarder_code = dt.Rows[0][fwd.forwarder_code].ToString();
                fwd1.forwarder_name_t = dt.Rows[0][fwd.forwarder_name_t].ToString();
                fwd1.forwarder_name_e = dt.Rows[0][fwd.forwarder_name_e].ToString();
                fwd1.active = dt.Rows[0][fwd.active].ToString();

                fwd1.address_t = dt.Rows[0][fwd.address_t].ToString();
                fwd1.address_e = dt.Rows[0][fwd.address_e].ToString();
                fwd1.addr = dt.Rows[0][fwd.addr].ToString();
                fwd1.amphur_id = dt.Rows[0][fwd.amphur_id].ToString();
                fwd1.district_id = dt.Rows[0][fwd.district_id].ToString();

                fwd1.province_id = dt.Rows[0][fwd.province_id].ToString();
                fwd1.zipcode = dt.Rows[0][fwd.zipcode].ToString();
                fwd1.sale_id = dt.Rows[0][fwd.sale_id].ToString();
                fwd1.sale_name_t = dt.Rows[0][fwd.sale_name_t].ToString();
                fwd1.fax = dt.Rows[0][fwd.fax].ToString();

                fwd1.tele = dt.Rows[0][fwd.tele].ToString();
                fwd1.email = dt.Rows[0][fwd.email].ToString();
                fwd1.tax_id = dt.Rows[0][fwd.tax_id].ToString();
                fwd1.remark = dt.Rows[0][fwd.remark].ToString();
                fwd1.contact_name1 = dt.Rows[0][fwd.contact_name1].ToString();

                fwd1.contact_name2 = dt.Rows[0][fwd.contact_name2].ToString();
                fwd1.contact_name1_tel = dt.Rows[0][fwd.contact_name1_tel].ToString();
                fwd1.contact_name2_tel = dt.Rows[0][fwd.contact_name2_tel].ToString();
                fwd1.status_company = dt.Rows[0][fwd.status_company].ToString();
                fwd1.status_vendor = dt.Rows[0][fwd.status_vendor].ToString();

                fwd1.date_create = dt.Rows[0][fwd.date_create].ToString();
                fwd1.date_modi = dt.Rows[0][fwd.date_modi].ToString();
                fwd1.date_cancel = dt.Rows[0][fwd.date_cancel].ToString();
                fwd1.user_create = dt.Rows[0][fwd.user_create].ToString();
                fwd1.user_modi = dt.Rows[0][fwd.user_modi].ToString();

                fwd1.user_cancel = dt.Rows[0][fwd.user_cancel].ToString();
                fwd1.remark2 = dt.Rows[0][fwd.remark2].ToString();
                fwd1.po_due_period = dt.Rows[0][fwd.po_due_period].ToString();
                fwd1.taddr1 = dt.Rows[0][fwd.taddr1].ToString();
                fwd1.taddr2 = dt.Rows[0][fwd.taddr2].ToString();

                fwd1.taddr3 = dt.Rows[0][fwd.taddr3].ToString();
                fwd1.taddr4 = dt.Rows[0][fwd.taddr4].ToString();
                fwd1.eaddr1 = dt.Rows[0][fwd.eaddr1].ToString();
                fwd1.eaddr2 = dt.Rows[0][fwd.eaddr2].ToString();
                fwd1.eaddr3 = dt.Rows[0][fwd.eaddr3].ToString();

                fwd1.eaddr4 = dt.Rows[0][fwd.eaddr4].ToString();
                fwd1.remark3 = dt.Rows[0][fwd.remark3].ToString();
                fwd1.payerorg = dt.Rows[0][fwd.payerorg].ToString();
                fwd1.payerprofile = dt.Rows[0][fwd.payerprofile].ToString();
                fwd1.payeruser = dt.Rows[0][fwd.payeruser].ToString();
            }

            return fwd1;
        }
    }
}


