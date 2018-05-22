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
            cont.cont_id = "contact_id";
            cont.cust_id = "cust_id";
            cont.cont_code = "contact_code";
            cont.username = "username";
            cont.password1 = "password1";
            cont.prefix_id = "prefix_id";
            cont.cont_fname_t = "contact_fname_t";
            cont.cont_fname_e = "contact_fname_e";
            cont.cont_lname_t = "contact_lname_t";
            cont.cont_lname_e = "contact_lname_e";
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
            cont.email2 = "email2";
            cont.nick_name = "nick_name";
            cont.work_response = "work_response";
            cont.table_id = "table_id";
            cont.prefix_name_t = "prefix_name_t";

            cont.table = "b_contact";
            cont.pkField = "contact_id";
        }
        private void chkNull(Contact p)
        {
            int chk = 0;
            Decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            p.cont_id = p.cont_id == null ? "" : p.cont_id;

            p.cust_id = p.cust_id == null ? "" : p.cust_id;
            p.cont_code = p.cont_code == null ? "" : p.cont_code;
            p.active = p.active == null ? "" : p.active;
            p.remark = p.remark == null ? "" : p.remark;
            p.username = p.username == null ? "" : p.username;
            p.password1 = p.password1 == null ? "" : p.password1;
            p.cont_fname_t = p.cont_fname_t == null ? "" : p.cont_fname_t;
            p.cont_fname_e = p.cont_fname_e == null ? "" : p.cont_fname_e;
            p.cont_lname_t = p.cont_lname_t == null ? "" : p.cont_lname_t;
            p.cont_lname_e = p.cont_lname_e == null ? "" : p.cont_lname_e;
            p.priority = p.priority == null ? "" : p.priority;
            p.tele = p.tele == null ? "" : p.tele;
            p.mobile = p.mobile == null ? "" : p.mobile;
            p.fax = p.fax == null ? "" : p.fax;
            p.email = p.email == null ? "" : p.email;
            p.posi_id = p.posi_id == null ? "" : p.posi_id;
            p.posi_name = p.posi_name == null ? "" : p.posi_name;
            p.email2 = p.email2 == null ? "" : p.email2;
            p.nick_name = p.nick_name == null ? "" : p.nick_name;
            p.work_response = p.work_response == null ? "" : p.work_response;

            p.prefix_id = int.TryParse(p.prefix_id, out chk) ? chk.ToString() : "0";
            p.table_id = int.TryParse(p.table_id, out chk) ? chk.ToString() : "0";

        }
        public String insert(Contact p)
        {
            String re = "", sql = "";
            p.active = "1";
            //p.ssdata_id = "";

            chkNull(p);
            sql = "Insert Into " + cont.table + "(" + cont.cust_id + "," + cont.cont_code + "," + cont.username + "," +
                cont.password1 + "," + cont.prefix_id + "," + cont.cont_fname_t + "," +
                cont.cont_fname_e + "," + cont.cont_lname_t + "," + cont.cont_lname_e + "," +
                cont.active + "," + cont.priority + "," + cont.tele + "," +
                cont.mobile + "," + cont.fax + "," + cont.email + "," +
                cont.posi_id + "," + cont.posi_name + "," + cont.date_create + "," +
                cont.date_modi + "," + cont.date_cancel + "," + cont.user_create + "," +
                cont.user_modi + "," + cont.user_cancel + ", " + cont.remark + ", " +
                cont.email2 + ", " + cont.nick_name + ", " + cont.work_response + ", " +
                cont.table_id + " " +
                ") " +
                "Values ('" + p.cust_id + "','" + p.cont_code + "','" + p.username.Replace("'", "''") + "'," +
                "'" + p.password1 + "','" + p.prefix_id + "','" + p.cont_fname_t.Replace("'", "''") + "'," +
                "'" + p.cont_fname_e.Replace("'", "''") + "','" + p.cont_lname_t.Replace("'", "''") + "','" + p.cont_lname_e.Replace("'", "''") + "'," +
                "'" + p.active + "','" + p.priority + "','" + p.tele + "'," +
                "'" + p.mobile + "','" + p.fax + "','" + p.email + "'," +
                "'" + p.posi_id + "','" + p.posi_name.Replace("'", "''") + "',now()," +
                "'" + p.date_modi + "','" + p.date_cancel + "','" + p.user_create + "'," +
                "'" + p.user_modi + "','" + p.user_cancel + "','" + p.remark.Replace("'","''") + "',"+
                "'" + p.email2 + "','" + p.nick_name.Replace("'", "''") + "','" + p.work_response.Replace("'", "''") + "', " +
                "'" + p.table_id + "' " +
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

            chkNull(p);
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
                "," + cont.email2 + "='" + p.email2 + "' " +
                "," + cont.date_modi + "=now() " +                
                "," + cont.remark + "='" + p.remark.Replace("'", "''") + "' " +
                "," + cont.user_modi + "= '" + p.user_modi + "' " +
                "," + cont.nick_name + "= '" + p.nick_name + "' " +
                "," + cont.work_response + "= '" + p.work_response + "' " +
                "," + cont.table_id + "= '" + p.table_id + "' " +
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
        public String insertContact(Contact p)
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
        public DataTable selectAll1()
        {
            DataTable dt = new DataTable();
            String sql = "select contact_id, contact_fname_t, contact_lname_t, nick_name, mobile, email  " +
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
            String sql = "select cont.*,pfx."+cont.prefix_name_t+" " +
                "From " + cont.table + " cont " +
                "Left Join b_prefix pfx On cont.prefix_id = pfx.prefix_id " +
                "Where cont." + cont.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cont1 = setContact(dt);
            return cont1;
        }
        public DataTable selectByCusId(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select cont.contact_id, cont.contact_fname_t, cont.contact_lname_t, cont.nick_name, cont.mobile, cont.email, cont.posi_name" +
                ", cont.remark, cont.work_response " +
                "From " + cont.table + " cont " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where cont." + cont.cust_id + " ='" + copId + "' and cont." + cont.active + "='1'";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public String VoidContact(String contId, String userIdVoid)
        {
            DataTable dt = new DataTable();
            String sql = "Update  " + cont.table + " Set " +
                "" + cont.active + "='3' " +
                "," + cont.date_cancel + "=now() " +
                "," + cont.user_cancel + "='" + userIdVoid + "' " +
                "Where " + cont.pkField + "='" + contId + "'";
            conn.ExecuteNonQuery(conn.conn, sql);

            return "1";
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
                cont1.email2 = dt.Rows[0][cont.email2].ToString();
                cont1.nick_name = dt.Rows[0][cont.nick_name].ToString();
                cont1.work_response = dt.Rows[0][cont.work_response].ToString();
                cont1.table_id = dt.Rows[0][cont.table_id].ToString();

                cont1.prefix_name_t = dt.Rows[0][cont.prefix_name_t].ToString();
            }

            return cont1;
        }
    }
}
