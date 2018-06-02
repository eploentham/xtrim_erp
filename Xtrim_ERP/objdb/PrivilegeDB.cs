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
    public class PrivilegeDB
    {
        public Privilege pvl;
        ConnectDB conn;

        public List<Privilege> lPvl;
        public DataTable dtPvl;

        public PrivilegeDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            pvl = new Privilege();
            pvl.priv_id = "priv_id";
            pvl.code = "code";
            pvl.desc1 = "desc1";
            pvl.announceno = "announceno";
            pvl.announcedd = "announcedd";
            pvl.announcedesc = "announcedesc";
            pvl.startdate = "startdate";
            pvl.finishdate = "finishdate";
            pvl.permitwarn = "permitwarn";
            pvl.progver = "progver";
            pvl.usrname = "usrname";
            pvl.update_dd = "update_dd";
            pvl.update_tt = "update_tt";
            pvl.status_app = "status_app";
            pvl.sort1 = "sort1";
            pvl.active = "active";

            pvl.table = "b_privilege";
            pvl.pkField = "priv_id";

            lPvl = new List<Privilege>();
            //getlPvl();
        }
        public void setCboPvl(ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectWard();
            foreach (Privilege cus1 in lPvl)
            {
                item = new ComboBoxItem();
                item.Value = cus1.priv_id;
                item.Text = cus1.desc1;
                c.Items.Add(item);
                if (item.Value.Equals(selected))
                {
                    c.SelectedItem = item;
                }
            }
        }
        public void getlPvl()
        {
            //lDept = new List<Department>();

            lPvl.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            dtPvl = dt;
            foreach (DataRow row in dt.Rows)
            {
                Privilege pvl1 = new Privilege();
                pvl1.priv_id = row[pvl.priv_id].ToString();
                pvl1.code = row[pvl.code].ToString();
                //curr1.announceno = row[pvl.announceno].ToString();
                pvl1.desc1 = row[pvl.desc1].ToString();

                lPvl.Add(pvl1);
            }
        }
        public String getIdByCode(String code)
        {
            String id = "";
            foreach (Privilege pvl1 in lPvl)
            {
                if (code.Equals(pvl1.code))
                {
                    id = pvl1.priv_id;
                    break;
                }
            }
            return id;
        }
        public String getIdByDesc(String code)
        {
            String id = "";
            foreach (Privilege pvl1 in lPvl)
            {
                if (code.Equals(pvl1.desc1))
                {
                    id = pvl1.priv_id;
                    break;
                }
            }
            return id;
        }
        public String getIdByName(String name)
        {
            String id = "";
            foreach (Privilege pvl1 in lPvl)
            {
                if (name.Equals(pvl1.desc1))
                {
                    id = pvl1.priv_id;
                    break;
                }
            }
            return id;
        }
        public String insert(Privilege p)
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

            sql = "Insert Into " + pvl.table + "(" + pvl.code + "," + pvl.announceno + "," + pvl.desc1 + "," +
                pvl.date_create + "," + pvl.date_modi + "," + pvl.date_cancel + "," +
                pvl.user_create + "," + pvl.user_modi + "," + pvl.user_cancel + "," +
                pvl.active + "," + pvl.remark + ", " + pvl.sort1 + " " +
                ") " +
                "Values ('" + p.code + "','" + p.announceno.Replace("'", "''") + "','" + p.desc1.Replace("'", "''") + "'," +
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
        public String update(Privilege p)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            sql = "Update " + pvl.table + " Set " +
                " " + pvl.code + " = '" + p.code + "'" +
                "," + pvl.announceno + " = '" + p.announceno.Replace("'", "''") + "'" +
                "," + pvl.desc1 + " = '" + p.desc1.Replace("'", "''") + "'" +
                "," + pvl.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + pvl.date_modi + " = now()" +
                "," + pvl.user_modi + " = '" + p.user_modi + "' " +
                "," + pvl.sort1 + " = '" + p.sort1 + "' " +
                //"," + tmn.status_app + " = '" + p.status_app + "' " +
                "Where " + pvl.pkField + "='" + p.priv_id + "'"
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
        public String insertPrivilege(Privilege p)
        {
            String re = "";

            if (p.priv_id.Equals(""))
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
            String sql = "Delete From  " + pvl.table;
            conn.ExecuteNonQuery(conn.conn, sql);

            return "";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select ugw.*  " +
                "From " + pvl.table + " ugw " +
                " " +
                "Where ugw." + pvl.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select ugw.* " +
                "From " + pvl.table + " ugw " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where ugw." + pvl.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public Privilege selectByPk1(String copId)
        {
            Privilege cop1 = new Privilege();
            DataTable dt = new DataTable();
            String sql = "select ugw.* " +
                "From " + pvl.table + " ugw " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where ugw." + pvl.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setPrivilege(dt);
            return cop1;
        }
        private Privilege setPrivilege(DataTable dt)
        {
            Privilege pti1 = new Privilege();
            if (dt.Rows.Count > 0)
            {
                pti1.priv_id = dt.Rows[0][pvl.priv_id].ToString();
                pti1.code = dt.Rows[0][pvl.code].ToString();
                pti1.announceno = dt.Rows[0][pvl.announceno].ToString();
                pti1.desc1 = dt.Rows[0][pvl.desc1].ToString();
                pti1.startdate = dt.Rows[0][pvl.startdate].ToString();
                pti1.finishdate = dt.Rows[0][pvl.finishdate].ToString();
                pti1.permitwarn = dt.Rows[0][pvl.permitwarn].ToString();
                pti1.progver = dt.Rows[0][pvl.progver].ToString();
                pti1.usrname = dt.Rows[0][pvl.usrname].ToString();
                pti1.update_dd = dt.Rows[0][pvl.update_dd].ToString();
                pti1.update_tt = dt.Rows[0][pvl.update_tt].ToString();
                pti1.announcedd = dt.Rows[0][pvl.announcedd].ToString();
                pti1.announcedesc = dt.Rows[0][pvl.announcedesc].ToString();
                pti1.status_app = dt.Rows[0][pvl.status_app].ToString();
                pti1.sort1 = dt.Rows[0][pvl.sort1].ToString();
            }

            return pti1;
        }
    }
}
