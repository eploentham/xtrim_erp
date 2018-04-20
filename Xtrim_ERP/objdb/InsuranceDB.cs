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
    public class InsuranceDB
    {
        public Insurance insr;
        ConnectDB conn;

        public List<Insurance> lInsr;

        public InsuranceDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            insr = new Insurance();
            insr.insu_id = "insu_id";
            insr.insu_code = "insu_code";
            insr.insu_name_t = "insu_name_t";
            insr.insu_name_e = "insu_name_e";
            insr.active = "active";
            insr.address_t = "address_t";
            insr.address_e = "address_e";
            insr.addr = "addr";
            insr.amphur_id = "amphur_id";
            insr.district_id = "district_id";
            insr.province_id = "province_id";
            insr.zipcode = "zipcode";
            insr.sale_id = "sale_id";
            insr.sale_name_t = "sale_name_t";
            insr.fax = "fax";
            insr.tele = "tele";
            insr.email = "email";
            insr.tax_id = "tax_id";
            insr.remark = "remark";
            insr.contact_name1 = "contact_name1";
            insr.contact_name2 = "contact_name2";
            insr.contact_name1_tel = "contact_name1_tel";
            insr.contact_name2_tel = "contact_name2_tel";
            insr.status_company = "status_company";
            insr.status_vendor = "status_vendor";
            insr.date_create = "date_create";
            insr.date_modi = "date_modi";
            insr.date_cancel = "date_cancel";
            insr.user_create = "user_create";
            insr.user_modi = "user_modi";
            insr.user_cancel = "user_cancel";
            insr.remark2 = "remark2";
            insr.po_due_period = "po_due_period";
            insr.taddr1 = "taddr1";
            insr.taddr2 = "taddr2";
            insr.taddr3 = "taddr3";
            insr.taddr4 = "taddr4";
            insr.eaddr1 = "eaddr1";
            insr.eaddr2 = "eaddr2";
            insr.eaddr3 = "eaddr3";
            insr.eaddr4 = "eaddr4";

            insr.table = "b_insurance";
            insr.pkField = "insu_id";

            lInsr = new List<Insurance>();
            getlInsr();
        }
        //public DataTable selectAll()
        //{
        //    DataTable dt = new DataTable();
        //    String sql = "select insr.*  " +
        //        "From " + insr.table + " insr " +
        //        " " +
        //        "Where insr." + insr.active + " ='1' ";
        //    dt = conn.selectData(conn.conn, sql);

        //    return dt;
        //}
        public String getIdByCode(String code)
        {
            String id = "";
            foreach (Insurance insr1 in lInsr)
            {
                if (code.Trim().Equals(insr1.insu_code))
                {
                    id = insr1.insu_id;
                    break;
                }
            }
            return id;
        }
        public void getlInsr()
        {
            //lDept = new List<Department>();

            lInsr.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                Insurance insr1 = new Insurance();
                insr1.insu_id = row[insr.insu_id].ToString();
                insr1.insu_code = row[insr.insu_code].ToString();

                lInsr.Add(insr1);

            }
        }
        public void setCboInsr(ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectWard();
            foreach (Insurance cus1 in lInsr)
            {
                item = new ComboBoxItem();
                item.Value = cus1.insu_id;
                item.Text = cus1.insu_name_t;
                c.Items.Add(item);
                if (item.Value.Equals(selected))
                {
                    c.SelectedItem = item;
                }
            }
        }
        public String insert(Insurance p)
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

            sql = "Insert Into " + insr.table + "(" + insr.insu_code + "," + insr.insu_name_t + "," + insr.insu_name_e + "," +
                insr.active + "," + insr.address_t + "," + insr.address_e + "," +
                insr.addr + "," + insr.amphur_id + "," + insr.district_id + "," +
                insr.province_id + "," + insr.zipcode + "," + insr.sale_id + "," +
                insr.sale_name_t + "," + insr.fax + "," + insr.tele + "," +
                insr.email + "," + insr.tax_id + "," + insr.remark + "," +
                insr.contact_name1 + "," + insr.contact_name2 + "," + insr.contact_name1_tel + "," +
                insr.contact_name2_tel + "," + insr.status_company + ", " + insr.status_vendor + ", " +
                insr.date_create + "," + insr.date_modi + ", " + insr.date_cancel + ", " +
                insr.user_create + "," + insr.user_modi + ", " + insr.user_cancel + ", " +
                insr.remark2 + "," + insr.po_due_period + ", " + insr.taddr1 + ", " +
                insr.taddr2 + "," + insr.taddr3 + ", " + insr.taddr4 + ", " +
                insr.eaddr1 + "," + insr.eaddr2 + ", " + insr.eaddr3 + ", " +
                insr.eaddr4 + " " +
                ") " +
                "Values ('" + p.insu_code + "','" + p.insu_name_t.Replace("'", "''") + "','" + p.insu_name_e.Replace("'", "''") + "'," +
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
        public String update(Insurance p)
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

            sql = "Update " + insr.table + " Set " +
                " " + insr.insu_code + " = '" + p.insu_code + "'" +
                "," + insr.insu_name_t + " = '" + p.insu_name_t.Replace("'", "''") + "'" +
                "," + insr.insu_name_e + " = '" + p.insu_name_e + "'" +
                "," + insr.address_t + " = '" + p.address_t.Replace("'", "''") + "'" +
                "," + insr.address_e + " = '" + p.address_e.Replace("'", "''") + "'" +
                "," + insr.addr + " = '" + p.addr.Replace("'", "''") + "'" +
                "," + insr.amphur_id + " = '" + p.amphur_id.Replace("'", "''") + "'" +
                "," + insr.district_id + " = '" + p.district_id.Replace("'", "''") + "'" +
                "," + insr.province_id + " = '" + p.province_id.Replace("'", "''") + "'" +
                "," + insr.zipcode + " = '" + p.zipcode + "'" +
                "," + insr.sale_id + " = '" + p.sale_id + "'" +
                "," + insr.sale_name_t + " = '" + p.sale_name_t + "'" +
                "," + insr.fax + " = '" + p.fax + "'" +
                "," + insr.tele + " = '" + p.tele + "'" +
                "," + insr.email + " = '" + p.email + "'" +
                "," + insr.tax_id + " = '" + p.tax_id.Replace("'", "''") + "'" +
                "," + insr.date_modi + " = now()" +
                "," + insr.remark + " = '" + p.remark + "'" +
                "," + insr.contact_name1 + " = '" + p.contact_name1 + "' " +
                "," + insr.contact_name2 + " = '" + p.contact_name2 + "' " +
                "," + insr.contact_name1_tel + " = '" + p.contact_name1_tel + "' " +
                "," + insr.contact_name2_tel + " = '" + p.contact_name2_tel + "' " +
                "," + insr.status_company + " = '" + p.status_company + "' " +
                "," + insr.status_vendor + " = '" + p.status_vendor + "' " +
                "," + insr.user_modi + " = '" + p.user_modi + "' " +
                "," + insr.remark2 + " = '" + p.remark2 + "' " +
                "," + insr.po_due_period + " = '" + p.po_due_period + "' " +
                "," + insr.taddr1 + " = '" + p.taddr1 + "' " +
                "," + insr.taddr2 + " = '" + p.taddr2 + "' " +
                "," + insr.taddr3 + " = '" + p.taddr3 + "' " +
                "," + insr.taddr4 + " = '" + p.taddr4 + "' " +
                "," + insr.eaddr1 + " = '" + p.eaddr1 + "' " +
                "," + insr.eaddr2 + " = '" + p.eaddr2 + "' " +
                "," + insr.eaddr3 + " = '" + p.eaddr3 + "' " +
                "," + insr.eaddr4 + " = '" + p.eaddr4 + "' " +
                //"," + insr.user_modi + " = '" + p.user_modi + "' " +
                "Where " + insr.pkField + "='" + p.insu_id + "'"
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
        public String insertCustomer(Insurance p)
        {
            String re = "";

            if (p.insu_id.Equals(""))
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
            String sql = "Delete From  " + insr.table;
            conn.ExecuteNonQuery(conn.conn, sql);

            return "";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select cop.*  " +
                "From " + insr.table + " cop " +
                " " +
                "Where cop." + insr.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select insr.* " +
                "From " + insr.table + " insr " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where insr." + insr.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public Insurance selectByPk1(String copId)
        {
            Insurance insr1 = new Insurance();
            DataTable dt = new DataTable();
            String sql = "select insr.* " +
                "From " + insr.table + " insr " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where insr." + insr.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            insr1 = setInsurance(dt);
            return insr1;
        }
        public String deleteInsuranceAll()
        {
            DataTable dt = new DataTable();
            String sql = "Delete From  " + insr.table + " ";
            conn.ExecuteNonQuery(conn.conn, sql);

            return "";
        }
        private Insurance setInsurance(DataTable dt)
        {
            Insurance cus1 = new Insurance();
            if (dt.Rows.Count > 0)
            {
                //stf1.staff_id = dt.Rows[0][insr.staff_id].ToString();
                cus1.insu_id = dt.Rows[0][insr.insu_id].ToString();
                cus1.insu_code = dt.Rows[0][insr.insu_code].ToString();
                cus1.insu_name_t = dt.Rows[0][insr.insu_name_t].ToString();
                cus1.insu_name_e = dt.Rows[0][insr.insu_name_e].ToString();
                cus1.active = dt.Rows[0][insr.active].ToString();

                cus1.address_t = dt.Rows[0][insr.address_t].ToString();
                cus1.address_e = dt.Rows[0][insr.address_e].ToString();
                cus1.addr = dt.Rows[0][insr.addr].ToString();
                cus1.amphur_id = dt.Rows[0][insr.amphur_id].ToString();
                cus1.district_id = dt.Rows[0][insr.district_id].ToString();

                cus1.province_id = dt.Rows[0][insr.province_id].ToString();
                cus1.zipcode = dt.Rows[0][insr.zipcode].ToString();
                cus1.sale_id = dt.Rows[0][insr.sale_id].ToString();
                cus1.sale_name_t = dt.Rows[0][insr.sale_name_t].ToString();
                cus1.fax = dt.Rows[0][insr.fax].ToString();

                cus1.tele = dt.Rows[0][insr.tele].ToString();
                cus1.email = dt.Rows[0][insr.email].ToString();
                cus1.tax_id = dt.Rows[0][insr.tax_id].ToString();
                cus1.remark = dt.Rows[0][insr.remark].ToString();
                cus1.contact_name1 = dt.Rows[0][insr.contact_name1].ToString();

                cus1.contact_name2 = dt.Rows[0][insr.contact_name2].ToString();
                cus1.contact_name1_tel = dt.Rows[0][insr.contact_name1_tel].ToString();
                cus1.contact_name2_tel = dt.Rows[0][insr.contact_name2_tel].ToString();
                cus1.status_company = dt.Rows[0][insr.status_company].ToString();
                cus1.status_vendor = dt.Rows[0][insr.status_vendor].ToString();

                cus1.date_create = dt.Rows[0][insr.date_create].ToString();
                cus1.date_modi = dt.Rows[0][insr.date_modi].ToString();
                cus1.date_cancel = dt.Rows[0][insr.date_cancel].ToString();
                cus1.user_create = dt.Rows[0][insr.user_create].ToString();
                cus1.user_modi = dt.Rows[0][insr.user_modi].ToString();

                cus1.user_cancel = dt.Rows[0][insr.user_cancel].ToString();
                cus1.remark2 = dt.Rows[0][insr.remark2].ToString();
                cus1.po_due_period = dt.Rows[0][insr.po_due_period].ToString();
                cus1.taddr1 = dt.Rows[0][insr.taddr1].ToString();
                cus1.taddr2 = dt.Rows[0][insr.taddr2].ToString();

                cus1.taddr3 = dt.Rows[0][insr.taddr3].ToString();
                cus1.taddr4 = dt.Rows[0][insr.taddr4].ToString();
                cus1.eaddr1 = dt.Rows[0][insr.eaddr1].ToString();
                cus1.eaddr2 = dt.Rows[0][insr.eaddr2].ToString();
                cus1.eaddr3 = dt.Rows[0][insr.eaddr3].ToString();

                cus1.eaddr4 = dt.Rows[0][insr.eaddr4].ToString();
            }

            return cus1;
        }
    }
}
