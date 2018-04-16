using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xtrim_ERP.object1;

namespace Xtrim_ERP.objdb
{
    public class ContactDB
    {
        public Contact cont;
        ConnectDB conn;
        public ContactDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            cont = new Contact();
            cont.cont_id = "cont_id";
            cont.cust_id = "cust_id";
            cont.cont_code = "cont_code";
            cont.username = "username";
            cont.password1 = "password1";
            cont.prefix_id = "prefix_id";
            cont.cont_fname_t = "cont_fname_t";
            cont.cont_fname_e = "cont_fname_e";
            cont.cont_lname_t = "cont_lname_t";
            cont.cont_lname_e = "cont_lname_e";
            cont.active = "active";
            cont.priority = "priority";
            cont.tele = "tele";
            cont.mobile = "mobile";
            cont.fax = "fax";
            cont.email = "email";
            cont.posi_id = "posi_id";
            cont.posi_name = "posi_name";
            cont.date_create = "date_create";
            cont.date_modi = "date_modi";
            cont.date_cancel = "date_cancel";
            cont.user_create = "user_create";
            cont.user_modi = "user_modi";
            cont.user_cancel = "user_cancel";
            cont.remark = "remark";

            cont.table = "b_contact";
            cont.pkField = "cont_id";
        }
        public String insert(Contact p)
        {
            String re = "", sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            sql = "Insert Into " + cont.table + "(" + cont.cust_id + "," + cont.cont_code + "," + cont.username + "," +
                cont.password1 + "," + cont.prefix_id + "," + cont.cont_fname_t + "," +
                cont.cont_fname_e + "," + cont.cont_lname_t + "," + cont.cont_lname_e + "," +
                cont.active + "," + cont.priority + "," + cont.tele + "," +
                cont.mobile + "," + cont.fax + "," + cont.email + "," +
                cont.posi_id + "," + cont.posi_name + "," + cont.date_create + "," +
                cont.date_modi + "," + cont.date_cancel + "," + cont.user_create + "," +
                cont.user_modi + "," + cont.user_cancel + ", " + cont.remark + " " +
                ") " +
                "Values ('" + p.cust_id + "','" + p.cont_code + "','" + p.username.Replace("'", "''") + "'," +
                "'" + p.password1 + "','" + p.prefix_id + "','" + p.cont_fname_t.Replace("'", "''") + "'," +
                "'" + p.cont_fname_e.Replace("'", "''") + "','" + p.cont_lname_t.Replace("'", "''") + "','" + p.cont_lname_e.Replace("'", "''") + "'," +
                "'" + p.active + "','" + p.priority + "','" + p.tele + "'," +
                "'" + p.mobile + "','" + p.fax + "','" + p.email + "'," +
                "'" + p.posi_id + "','" + p.posi_name.Replace("'", "''") + "',now()," +
                "'" + p.date_modi + "','" + p.date_cancel + "','" + p.user_create + "','" +
                "'" + p.user_modi + "','" + p.user_cancel + "','" + p.remark.Replace("'","''") + "'"+
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
        public String update(Contact p)
        {
            String re = "", sql = "";

            sql = "Update " + cont.table + " Set " +
                " " + cont.cust_id + "='" + p.cust_id + "' " +
                "," + cont.cont_code + "='" + p.cont_code + "' " +
                "," + cont.username + "='" + p.username + "' " +
                "," + cont.password1 + "='" + p.password1 + "' " +
                "," + cont.prefix_id + "='" + p.prefix_id + "' " +
                "," + cont.cont_fname_t + "='" + p.cont_fname_t + "' " +
                "," + cont.cont_fname_e + "='" + p.cont_fname_e + "' " +
                "," + cont.cont_lname_t + "='" + p.cont_lname_t + "' " +
                "," + cont.cont_lname_e + "='" + p.cont_lname_e + "' " +
                "," + cont.priority + "='" + p.priority + "' " +
                "," + cont.tele + "='" + p.tele + "' " +
                "," + cont.mobile + "='" + p.mobile + "' " +
                "," + cont.fax + "='" + p.fax + "' " +
                "," + cont.email + "='" + p.email + "' " +
                "," + cont.posi_id + "='" + p.posi_id + "' " +
                "," + cont.posi_name + "='" + p.posi_name + "' " +
                //"," + cont.date_create + "='" + p.date_create + "' " +
                "," + cont.date_modi + "=now() " +                
                "," + cont.remark + "='" + p.remark.Replace("'", "''") + "' " +
                "," + cont.user_modi + "= '" + p.user_modi + "' " +
                "Where " + cont.pkField + "='" + p.cont_id + "'"
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
        public String insertStaff(Contact p)
        {
            String re = "";

            if (p.cont_id.Equals(""))
            {
                re = insert(p);
            }
            else
            {
                re = update(p);
            }

            return re;
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select cont.*  " +
                "From " + cont.table + " cont " +
                " " +
                "Where cont." + cont.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select cont.* " +
                "From " + cont.table + " cont " +
                "Where cont." + cont.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public Contact selectByPk1(String copId)
        {
            Contact cont1 = new Contact();
            DataTable dt = new DataTable();
            String sql = "select stf.* " +
                "From " + cont.table + " stf " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where stf." + cont.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cont1 = setContact(dt);
            return cont1;
        }
        private Contact setContact(DataTable dt)
        {
            Contact cont1 = new Contact();
            if (dt.Rows.Count > 0)
            {
                cont1.cont_id = dt.Rows[0][cont.cont_id].ToString();
                cont1.cust_id = dt.Rows[0][cont.cust_id].ToString();
                cont1.cont_code = dt.Rows[0][cont.cont_code].ToString();
                cont1.username = dt.Rows[0][cont.username].ToString();
                cont1.password1 = dt.Rows[0][cont.password1].ToString();

                cont1.prefix_id = dt.Rows[0][cont.prefix_id].ToString();
                cont1.cont_fname_t = dt.Rows[0][cont.cont_fname_t].ToString();
                cont1.cont_fname_e = dt.Rows[0][cont.cont_fname_e].ToString();
                cont1.cont_lname_t = dt.Rows[0][cont.cont_lname_t].ToString();
                cont1.cont_lname_e = dt.Rows[0][cont.cont_lname_e].ToString();

                cont1.active = dt.Rows[0][cont.active].ToString();
                cont1.priority = dt.Rows[0][cont.priority].ToString();
                cont1.tele = dt.Rows[0][cont.tele].ToString();
                cont1.mobile = dt.Rows[0][cont.mobile].ToString();
                cont1.fax = dt.Rows[0][cont.fax].ToString();
                cont1.email = dt.Rows[0][cont.email].ToString();
                cont1.posi_id = dt.Rows[0][cont.posi_id].ToString();
                cont1.posi_name = dt.Rows[0][cont.posi_name].ToString();
                cont1.date_create = dt.Rows[0][cont.date_create].ToString();
                cont1.date_modi = dt.Rows[0][cont.date_modi].ToString();
                cont1.date_cancel = dt.Rows[0][cont.date_cancel].ToString();
                cont1.user_create = dt.Rows[0][cont.user_create].ToString();
                cont1.user_modi = dt.Rows[0][cont.user_modi].ToString();
                cont1.user_cancel = dt.Rows[0][cont.user_cancel].ToString();
                cont1.remark = dt.Rows[0][cont.remark].ToString();
                //cont1.logo = dt.Rows[0][cont.logo].ToString();
            }

            return cont1;
        }
    }
}
