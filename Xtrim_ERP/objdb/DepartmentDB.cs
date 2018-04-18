using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xtrim_ERP.object1;

namespace Xtrim_ERP.objdb
{
    public class DepartmentDB
    {
        public Department dept;
        ConnectDB conn;

        public List<Department> lDept;

        public DepartmentDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            dept = new Department();
            dept.dept_id = "dept_id";
            dept.depart_code = "dept_code";
            dept.depart_name_t = "dept_name_t";
            dept.comp_id = "comp_id";
            dept.dept_parent_id = "dept_parent_id";
            dept.remark = "remark";
            dept.date_create = "date_create";
            dept.date_modi = "date_modi";
            dept.date_cancel = "date_cancel";
            dept.user_create = "user_create";
            dept.user_modi = "user_modi";
            dept.user_cancel = "user_cancel";
            dept.active = "active";

            dept.table = "b_department";
            dept.pkField = "depart_id";

            lDept = new List<Department>();
        }
        public String insert(Department p)
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
            p.comp_id = int.TryParse(p.comp_id, out chk) ? chk.ToString() : "0";
            p.dept_id = int.TryParse(p.dept_id, out chk) ? chk.ToString() : "0";
            p.dept_parent_id = int.TryParse(p.dept_parent_id, out chk) ? chk.ToString() : "0";

            sql = "Insert Into " + dept.table + "(" + dept.depart_code + "," + dept.depart_name_t + "," + dept.comp_id + "," +
                dept.dept_parent_id + "," + dept.remark + "," + dept.date_create + "," +
                dept.date_modi + "," + dept.date_cancel + "," + dept.user_create + "," +
                dept.user_modi + "," + dept.user_cancel + "," + dept.active + " " +
                ") " +
                "Values ('" + p.depart_code + "','" + p.depart_name_t.Replace("'", "''") + "','" + p.comp_id + "'," +
                "'" + p.dept_parent_id + "','" + p.remark.Replace("'", "''") + "',now()," +
                "'" + p.date_modi + "','" + p.date_cancel + "','" + p.user_create + "'," +
                "'" + p.user_modi + "','" + p.user_cancel + "','" + p.active  + "' " +
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
        public String update(Department p)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            p.comp_id = int.TryParse(p.comp_id, out chk) ? chk.ToString() : "0";
            p.dept_id = int.TryParse(p.dept_id, out chk) ? chk.ToString() : "0";
            p.dept_parent_id = int.TryParse(p.dept_parent_id, out chk) ? chk.ToString() : "0";

            sql = "Update " + dept.table + " Set " +
                " " + dept.depart_code + " = '" + p.depart_code + "'" +
                "," + dept.depart_name_t + " = '" + p.depart_name_t.Replace("'", "''") + "'" +
                "," + dept.comp_id + " = '" + p.comp_id + "'" +
                "," + dept.dept_parent_id + " = '" + p.dept_parent_id + "'" +
                "," + dept.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + dept.date_modi + " = now()" +
                "," + dept.user_modi + " = '" + p.user_modi + "'" +                
                "Where " + dept.pkField + "='" + p.dept_id + "'"
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
        public String insertDepartment(Department p)
        {
            String re = "";

            if (p.dept_id.Equals(""))
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
            String sql = "Delete From  " + dept.table;
            conn.ExecuteNonQuery(conn.conn, sql);

            return "";
        }
        public void getlDept()
        {
            //lDept = new List<Department>();

            lDept.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                Department dept1 = new Department();
                dept1.dept_id = row[dept.dept_id].ToString();
                dept1.depart_code = row[dept.depart_code].ToString();
                dept1.depart_name_t = row[dept.depart_name_t].ToString();
                dept1.comp_id = row[dept.comp_id].ToString();
                dept1.dept_parent_id = row[dept.dept_parent_id].ToString();
                dept1.remark = row[dept.remark].ToString();
                dept1.date_create = row[dept.date_create].ToString();
                dept1.date_modi = row[dept.date_modi].ToString();
                dept1.date_cancel = row[dept.date_cancel].ToString();
                dept1.user_create = row[dept.user_create].ToString();
                dept1.user_modi = row[dept.user_modi].ToString();
                dept1.user_cancel = row[dept.user_cancel].ToString();
                dept1.active = row[dept.active].ToString();
                lDept.Add(dept1);
            }
        }
        public String getIdByCode(String code)
        {
            String id = "";
            foreach(Department dept1 in lDept)
            {
                if (code.Trim().Equals(dept1.depart_code.Trim()))
                {
                    id = dept1.dept_id;
                    break;
                }
            }
            return id;
        }
        public String getIdByName(String name)
        {
            String id = "";
            foreach (Department dept1 in lDept)
            {
                if (name.Trim().Equals(dept1.depart_name_t.Trim()))
                {
                    id = dept1.dept_id;
                    break;
                }
            }
            return id;
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select dept.*  " +
                "From " + dept.table + " dept " +
                " " +
                "Where dept." + dept.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select dept.* " +
                "From " + dept.table + " dept " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where dept." + dept.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public Department selectByPk1(String copId)
        {
            Department cop1 = new Department();
            DataTable dt = new DataTable();
            String sql = "select dept.* " +
                "From " + dept.table + " dept " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where dept." + dept.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setDepartment(dt);
            return cop1;
        }
        private Department setDepartment(DataTable dt)
        {
            Department dept1 = new Department();
            if (dt.Rows.Count > 0)
            {
                dept1.dept_id = dt.Rows[0][dept.dept_id].ToString();
                dept1.depart_code = dt.Rows[0][dept.depart_code].ToString();
                dept1.depart_name_t = dt.Rows[0][dept.depart_name_t].ToString();
                dept1.comp_id = dt.Rows[0][dept.comp_id].ToString();
                dept1.dept_parent_id = dt.Rows[0][dept.dept_parent_id].ToString();
                dept1.remark = dt.Rows[0][dept.remark].ToString();
                dept1.date_create = dt.Rows[0][dept.date_create].ToString();
                dept1.date_modi = dt.Rows[0][dept.date_modi].ToString();
                dept1.date_cancel = dt.Rows[0][dept.date_cancel].ToString();
                dept1.user_create = dt.Rows[0][dept.user_create].ToString();
                dept1.user_modi = dt.Rows[0][dept.user_modi].ToString();
                dept1.user_cancel = dt.Rows[0][dept.user_cancel].ToString();
                dept1.active = dt.Rows[0][dept.active].ToString();
            }

            return dept1;
        }
    }
}
