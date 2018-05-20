using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xtrim_ERP.object1;

namespace Xtrim_ERP.objdb
{
    public class StaffDB
    {
        public Staff stf;
        ConnectDB conn;

        public List<Staff> lStf;

        public StaffDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            stf = new Staff();
            stf.staff_id = "staff_id";
            stf.staff_code = "staff_code";
            stf.username = "username";
            stf.prefix_id = "prefix_id";
            stf.staff_fname_t = "staff_fname_t";
            stf.staff_fname_e = "staff_fname_e";
            stf.staff_lname_t = "staff_lname_t";
            stf.staff_lname_e = "staff_lname_e";
            stf.password1 = "password1";
            stf.active = "active";
            stf.remark = "remark";
            stf.priority = "priority";
            stf.tele = "tele";
            stf.mobile = "mobile";
            stf.fax = "fax";
            stf.email = "email";
            stf.posi_id = "posi_id";
            stf.posi_name = "posi_name";
            stf.date_create = "date_create";
            stf.date_modi = "date_modi";
            stf.date_cancel = "date_cancel";
            stf.user_create = "user_create";
            stf.user_modi = "user_modi";
            stf.user_cancel = "user_cancel";
            stf.pid = "pid";
            stf.logo = "logo";
            stf.dept_id = "dept_id";
            stf.dept_name_t = "dept_name_t";

            stf.table = "b_staff";
            stf.pkField = "staff_id";

            lStf = new List<Staff>();
        }
        public void getlStf()
        {
            //lDept = new List<Department>();

            lStf.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                Staff stf1 = new Staff();
                stf1.staff_id = row[stf.staff_id].ToString();
                stf1.staff_code = row[stf.staff_code].ToString();
                stf1.staff_fname_t = row[stf.staff_fname_t].ToString();
                stf1.staff_fname_e = row[stf.staff_fname_e].ToString();
                //cus1.c = row[dept.dept_parent_id].ToString();
                //cus1.remark = row[dept.remark].ToString();
                //cus1.date_create = row[dept.date_create].ToString();
                //cus1.date_modi = row[dept.date_modi].ToString();
                //cus1.date_cancel = row[dept.date_cancel].ToString();
                //cus1.user_create = row[dept.user_create].ToString();
                //cus1.user_modi = row[dept.user_modi].ToString();
                //cus1.user_cancel = row[dept.user_cancel].ToString();
                //cus1.active = row[dept.active].ToString();
                lStf.Add(stf1);
            }
        }
        public String getIdByCode(String code)
        {
            String id = "";
            foreach (Staff stf1 in lStf)
            {
                if (code.Trim().Equals(stf1.staff_code))
                {
                    id = stf1.staff_id;
                    break;
                }
            }
            return id;
        }
        public String getIdByName(String name)
        {
            String id = "";
            foreach (Staff stf1 in lStf)
            {
                if (name.Trim().Equals(stf1.staff_fname_t))
                {
                    id = stf1.staff_id;
                    break;
                }
            }
            return id;
        }
        public String insert(Staff p)
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
            p.prefix_id = int.TryParse(p.prefix_id, out chk) ? chk.ToString() : "0";
            p.dept_id = int.TryParse(p.dept_id, out chk) ? chk.ToString() : "0";


            sql = "Insert Into " + stf.table + "(" + stf.staff_code + "," + stf.username + "," + stf.prefix_id + "," +
                stf.staff_fname_t + "," + stf.staff_fname_e + "," + stf.password1 + "," +
                stf.active + "," + stf.remark + "," + stf.priority + "," +
                stf.tele + "," + stf.mobile + "," + stf.fax + "," +
                stf.email + "," + stf.posi_id + "," + stf.posi_name + "," +
                stf.date_create + "," + stf.date_modi + "," + stf.date_cancel + "," +
                stf.user_create + "," + stf.user_modi + "," + stf.user_cancel + ","+
                stf.staff_lname_t + "," + stf.staff_lname_e + ", " + stf.pid + ", " +
                stf.logo + ", " + stf.dept_id + ", " + stf.dept_name_t + " " +
                ") " +
                "Values ('" + p.staff_code + "','" + p.username + "','" + p.prefix_id + "'," +
                "'" + p.staff_fname_t.Replace("'", "''") + "','" + p.staff_fname_e.Replace("'", "''") + "','" + p.password1 + "'," +
                "'" + p.active + "','" + p.remark + "','" + p.priority + "'," +
                "'" + p.tele + "','" + p.mobile + "','" + p.fax + "'," +
                "'" + p.email + "','" + p.posi_id + "','" + p.posi_name + "'," +
                "now(),'" + p.date_modi + "','" + p.date_cancel + "'," +
                "'" + p.user_create + "','" + p.user_modi + "','" + p.user_cancel + "', " +
                "'" + p.staff_lname_t.Replace("'", "''") + "','" + p.staff_lname_e.Replace("'", "''") + "','" + p.pid + "', " +
                "'" + p.logo+"','" + p.dept_id + "','" + p.dept_name_t.Replace("'", "''") + "' " +
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
        public String update(Staff p)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            p.prefix_id = int.TryParse(p.prefix_id, out chk) ? chk.ToString() : "0";
            p.dept_id = int.TryParse(p.dept_id, out chk) ? chk.ToString() : "0";

            sql = "Update " + stf.table + " Set " +
                " "+stf.staff_code + " = '" + p.staff_code + "'" +
                "," + stf.username + " = '" + p.username.Replace("'","''") + "'" +
                "," + stf.prefix_id + " = '" + p.prefix_id + "'" +
                "," + stf.staff_fname_t + " = '" + p.staff_fname_t.Replace("'", "''") + "'" +
                "," + stf.staff_fname_e + " = '" + p.staff_fname_e.Replace("'", "''") + "'" +
                "," + stf.staff_lname_t + " = '" + p.staff_lname_t.Replace("'", "''") + "'" +
                "," + stf.staff_lname_e + " = '" + p.staff_lname_e.Replace("'", "''") + "'" +
                "," + stf.password1 + " = '" + p.password1.Replace("'", "''") + "'" +
                "," + stf.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + stf.priority + " = '" + p.priority + "'" +
                "," + stf.tele + " = '" + p.tele + "'" +
                "," + stf.mobile + " = '" + p.mobile + "'" +
                "," + stf.fax + " = '" + p.fax + "'" +
                "," + stf.email + " = '" + p.email + "'" +
                "," + stf.posi_id + " = '" + p.posi_id + "'" +
                "," + stf.posi_name + " = '" + p.posi_name.Replace("'", "''") + "'" +
                "," + stf.date_modi + " = now()" +
                "," + stf.pid + " = '" + p.pid + "'" +
                "," + stf.logo + " = '" + p.logo + "' " +
                "," + stf.user_modi + " = '" + p.user_modi + "' " +
                "," + stf.dept_id + " = '" + p.dept_id + "' " +
                "," + stf.dept_name_t + " = '" + p.dept_name_t.Replace("'", "''") + "' " +
                "Where " + stf.pkField + "='" + p.staff_id + "'"
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
        public String insertStaff(Staff p)
        {
            String re = "";

            if (p.staff_id.Equals(""))
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
            String sql = "Delete From  " + stf.table;
            conn.ExecuteNonQuery(conn.conn, sql);

            return "";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select cop.*  " +
                "From " + stf.table + " cop " +
                " " +
                "Where cop." + stf.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectAll1()
        {
            DataTable dt = new DataTable();
            String sql = "Select stf.staff_id, stf.staff_code, concat( stf.staff_fname_t, ' ' , stf.staff_lname_t) as name, stf.mobile, stf.email, stf.posi_name" +
                ", stf.dept_name_t, stf.remark, stf.pid " +
                "From " + stf.table + " stf " +
                //"Left Join b_prefix pfx On stf.prefix_id = pfx.prefix_id " +
                "Where stf." + stf.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select stf.* " +
                "From " + stf.table + " stf " +
                "Where stf." + stf.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public Staff selectByPk1(String copId)
        {
            Staff cop1 = new Staff();
            DataTable dt = new DataTable();
            String sql = "select stf.* " +
                "From " + stf.table + " stf " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where stf." + stf.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setStaff(dt);
            return cop1;
        }
        private Staff setStaff(DataTable dt)
        {
            Staff stf1 = new Staff();
            if (dt.Rows.Count > 0)
            {
                stf1.staff_id = dt.Rows[0][stf.staff_id].ToString();
                stf1.staff_code = dt.Rows[0][stf.staff_code].ToString();
                stf1.username = dt.Rows[0][stf.username].ToString();
                stf1.prefix_id = dt.Rows[0][stf.prefix_id].ToString();
                stf1.staff_fname_t = dt.Rows[0][stf.staff_fname_t].ToString();
                stf1.staff_fname_e = dt.Rows[0][stf.staff_fname_e].ToString();
                stf1.staff_lname_t = dt.Rows[0][stf.staff_lname_t].ToString();
                stf1.staff_lname_e = dt.Rows[0][stf.staff_lname_e].ToString();
                stf1.password1 = dt.Rows[0][stf.password1].ToString();
                stf1.active = dt.Rows[0][stf.active].ToString();
                stf1.remark = dt.Rows[0][stf.remark].ToString();
                stf1.priority = dt.Rows[0][stf.priority].ToString();
                stf1.tele = dt.Rows[0][stf.tele].ToString();
                stf1.mobile = dt.Rows[0][stf.mobile].ToString();
                stf1.fax = dt.Rows[0][stf.fax].ToString();
                stf1.email = dt.Rows[0][stf.email].ToString();
                stf1.posi_id = dt.Rows[0][stf.posi_id].ToString();
                stf1.posi_name = dt.Rows[0][stf.posi_name].ToString();
                stf1.date_create = dt.Rows[0][stf.date_create].ToString();
                stf1.date_modi = dt.Rows[0][stf.date_modi].ToString();
                stf1.date_cancel = dt.Rows[0][stf.date_cancel].ToString();
                stf1.user_create = dt.Rows[0][stf.user_create].ToString();
                stf1.user_modi = dt.Rows[0][stf.user_modi].ToString();
                stf1.user_cancel = dt.Rows[0][stf.user_cancel].ToString();
                stf1.pid = dt.Rows[0][stf.pid].ToString();
                stf1.logo = dt.Rows[0][stf.logo].ToString();
                stf1.dept_id = dt.Rows[0][stf.dept_id].ToString();
                stf1.dept_name_t = dt.Rows[0][stf.dept_name_t].ToString();
            }

            return stf1;
        }
    }
}
