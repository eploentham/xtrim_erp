using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xtrim_ERP.object1;

namespace Xtrim_ERP.objdb
{
    public class IncoTermsDB
    {
        public IncoTerms ict;
        ConnectDB conn;

        public List<IncoTerms> lIct;

        public IncoTermsDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            ict = new IncoTerms();
            ict.inco_terms_id = "inco_terms_id";
            ict.inco_terms_code = "inco_terms_code";
            ict.inco_terms_name_e = "inco_terms_name_e";
            ict.inco_terms_name_t = "inco_terms_name_t";
            //ict.status_app = "status_app";
            ict.sort1 = "sort1";

            ict.active = "active";
            ict.date_create = "date_create";
            ict.date_modi = "date_modi";
            ict.date_cancel = "date_cancel";
            ict.user_create = "user_create";
            ict.user_modi = "user_modi";
            ict.user_cancel = "user_cancel";
            //ict.status_app = "status_app";
            ict.remark = "remark";

            ict.table = "b_inco_terms";
            ict.pkField = "inco_terms_id";

            lIct = new List<IncoTerms>();

            //getlIct();
        }
        public void getlIct()
        {
            //lDept = new List<Department>();

            lIct.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                IncoTerms ict1 = new IncoTerms();
                ict1.inco_terms_id = row[ict.inco_terms_id].ToString();
                ict1.inco_terms_code = row[ict.inco_terms_code].ToString();
                ict1.inco_terms_name_e = row[ict.inco_terms_name_e].ToString();
                ict1.inco_terms_name_t = row[ict.inco_terms_name_t].ToString();

                lIct.Add(ict1);
            }
        }
        public String getIdByCode(String code)
        {
            String id = "";
            foreach (IncoTerms ict1 in lIct)
            {
                if (code.Trim().Equals(ict1.inco_terms_code))
                {
                    id = ict1.inco_terms_id;
                    break;
                }
            }
            return id;
        }
        public String getIdByName(String name)
        {
            String id = "";
            foreach (IncoTerms ict1 in lIct)
            {
                if (name.Trim().Equals(ict1.inco_terms_name_t))
                {
                    id = ict1.inco_terms_id;
                    break;
                }
            }
            return id;
        }
        public String insert(IncoTerms p)
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
            //p.prefix_id = int.TryParse(p.prefix_id, out chk) ? chk.ToString() : "0";
            //p.dept_id = int.TryParse(p.dept_id, out chk) ? chk.ToString() : "0";

            sql = "Insert Into " + ict.table + "(" + ict.inco_terms_code + "," + ict.inco_terms_name_e + "," + ict.inco_terms_name_t + "," +
                ict.date_create + "," + ict.date_modi + "," + ict.date_cancel + "," +
                ict.user_create + "," + ict.user_modi + "," + ict.user_cancel + "," +
                ict.active + "," + ict.remark + ", " + ict.sort1 + " " +
                ") " +
                "Values ('" + p.inco_terms_code + "','" + p.inco_terms_name_e.Replace("'", "''") + "','" + p.inco_terms_name_t.Replace("'", "''") + "'," +
                "'" + p.date_create + "','" + p.date_modi + "','" + p.date_cancel + "'," +
                "'" + p.user_create + "','" + p.user_modi + "','" + p.user_cancel + "'," +
                "'" + p.active + "','" + p.remark.Replace("'", "''") + "','" + p.sort1 + "' " +
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
        public String update(IncoTerms p)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            sql = "Update " + ict.table + " Set " +
                " " + ict.inco_terms_code + " = '" + p.inco_terms_code + "'" +
                "," + ict.inco_terms_name_e + " = '" + p.inco_terms_name_e.Replace("'", "''") + "'" +
                "," + ict.inco_terms_name_t + " = '" + p.inco_terms_name_t.Replace("'", "''") + "'" +
                "," + ict.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + ict.date_modi + " = now()" +
                "," + ict.user_modi + " = '" + p.user_modi + "' " +
                "," + ict.sort1 + " = '" + p.sort1 + "' " +
                //"," + ict.status_app + " = '" + p.status_app + "' " +
                "Where " + ict.pkField + "='" + p.inco_terms_id + "'"
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
        public String insertIncoTeams(IncoTerms p)
        {
            String re = "";

            if (p.inco_terms_id.Equals(""))
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
            String sql = "Delete From  " + ict.table;
            conn.ExecuteNonQuery(conn.conn, sql);

            return "";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select ict.*  " +
                "From " + ict.table + " ict " +
                " " +
                "Where ict." + ict.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select ict.* " +
                "From " + ict.table + " ict " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where ict." + ict.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public IncoTerms selectByPk1(String copId)
        {
            IncoTerms cop1 = new IncoTerms();
            DataTable dt = new DataTable();
            String sql = "select ict.* " +
                "From " + ict.table + " ict " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where ict." + ict.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setIncoTeams(dt);
            return cop1;
        }
        public DataTable selectByCodeLike(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select ict.* " +
                "From " + ict.table + " ict " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where LOWER(ict." + ict.inco_terms_code + ") like '%" + copId.ToLower() + "%' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public IncoTerms setIncoTeams(DataTable dt)
        {
            IncoTerms ett1 = new IncoTerms();
            if (dt.Rows.Count > 0)
            {
                ett1.inco_terms_id = dt.Rows[0][ict.inco_terms_id].ToString();
                ett1.inco_terms_code = dt.Rows[0][ict.inco_terms_code].ToString();
                ett1.inco_terms_name_e = dt.Rows[0][ict.inco_terms_name_e].ToString();
                ett1.inco_terms_name_t = dt.Rows[0][ict.inco_terms_name_t].ToString();
                ett1.active = dt.Rows[0][ict.active].ToString();
                ett1.date_cancel = dt.Rows[0][ict.date_cancel].ToString();
                ett1.date_create = dt.Rows[0][ict.date_create].ToString();
                ett1.date_modi = dt.Rows[0][ict.date_modi].ToString();
                ett1.user_cancel = dt.Rows[0][ict.user_cancel].ToString();
                ett1.user_create = dt.Rows[0][ict.user_create].ToString();
                ett1.user_modi = dt.Rows[0][ict.user_modi].ToString();
                //pti1.status_app = dt.Rows[0][ict.status_app].ToString();
                ett1.remark = dt.Rows[0][ict.remark].ToString();
                ett1.sort1 = dt.Rows[0][ict.sort1].ToString();
            }

            return ett1;
        }
    }
}
