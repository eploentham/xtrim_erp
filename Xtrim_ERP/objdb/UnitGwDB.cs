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
    public class UnitGwDB
    {
        public UnitGw ugw;
        ConnectDB conn;

        public List<UnitGw> lUgw;

        public UnitGwDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            ugw = new UnitGw();
            ugw.unit_gw_id = "unit_gw_id";
            ugw.unit_gw_code = "unit_gw_code";
            ugw.unit_gw_name_e = "unit_gw_name_e";
            ugw.unit_gw_name_t = "unit_gw_name_t";
            //tmn.status_app = "status_app";
            ugw.sort1 = "sort1";

            ugw.active = "active";
            ugw.date_create = "date_create";
            ugw.date_modi = "date_modi";
            ugw.date_cancel = "date_cancel";
            ugw.user_create = "user_create";
            ugw.user_modi = "user_modi";
            ugw.user_cancel = "user_cancel";
            //tmn.status_app = "status_app";
            ugw.remark = "remark";

            ugw.table = "b_unit_package";
            ugw.pkField = "unit_gw_id";

            lUgw = new List<UnitGw>();
        }
        public void getlUgw()
        {
            //lDept = new List<Department>();

            lUgw.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                UnitGw utp1 = new UnitGw();
                utp1.unit_gw_id = row[ugw.unit_gw_id].ToString();
                utp1.unit_gw_code = row[ugw.unit_gw_code].ToString();
                utp1.unit_gw_name_e = row[ugw.unit_gw_name_e].ToString();
                utp1.unit_gw_name_t = row[ugw.unit_gw_name_t].ToString();

                lUgw.Add(utp1);
            }
        }
        public void setCboUgw(ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectWard();
            foreach (UnitGw cus1 in lUgw)
            {
                item = new ComboBoxItem();
                item.Value = cus1.unit_gw_id;
                item.Text = cus1.unit_gw_name_t;
                c.Items.Add(item);
                if (item.Value.Equals(selected))
                {
                    c.SelectedItem = item;
                }
            }
        }
        public String getIdByCode(String code)
        {
            String id = "";
            foreach (UnitGw ugw1 in lUgw)
            {
                if (code.Trim().Equals(ugw1.unit_gw_code))
                {
                    id = ugw1.unit_gw_id;
                    break;
                }
            }
            return id;
        }
        public String getIdByName(String name)
        {
            String id = "";
            foreach (UnitGw ugw1 in lUgw)
            {
                if (name.Trim().Equals(ugw1.unit_gw_name_t))
                {
                    id = ugw1.unit_gw_id;
                    break;
                }
            }
            return id;
        }
        public String insert(UnitGw p)
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

            sql = "Insert Into " + ugw.table + "(" + ugw.unit_gw_code + "," + ugw.unit_gw_name_e + "," + ugw.unit_gw_name_t + "," +
                ugw.date_create + "," + ugw.date_modi + "," + ugw.date_cancel + "," +
                ugw.user_create + "," + ugw.user_modi + "," + ugw.user_cancel + "," +
                ugw.active + "," + ugw.remark + ", " + ugw.sort1 + " " +
                ") " +
                "Values ('" + p.unit_gw_code + "','" + p.unit_gw_name_e.Replace("'", "''") + "','" + p.unit_gw_name_t.Replace("'", "''") + "'," +
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
        public String update(UnitGw p)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            sql = "Update " + ugw.table + " Set " +
                " " + ugw.unit_gw_code + " = '" + p.unit_gw_code + "'" +
                "," + ugw.unit_gw_name_e + " = '" + p.unit_gw_name_e.Replace("'", "''") + "'" +
                "," + ugw.unit_gw_name_t + " = '" + p.unit_gw_name_t.Replace("'", "''") + "'" +
                "," + ugw.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + ugw.date_modi + " = now()" +
                "," + ugw.user_modi + " = '" + p.user_modi + "' " +
                "," + ugw.sort1 + " = '" + p.sort1 + "' " +
                //"," + tmn.status_app + " = '" + p.status_app + "' " +
                "Where " + ugw.pkField + "='" + p.unit_gw_id + "'"
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
        public String insertUnitGw(UnitGw p)
        {
            String re = "";

            if (p.unit_gw_id.Equals(""))
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
            String sql = "Delete From  " + ugw.table;
            conn.ExecuteNonQuery(conn.conn, sql);

            return "";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select ugw.*  " +
                "From " + ugw.table + " ugw " +
                " " +
                "Where ugw." + ugw.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select ugw.* " +
                "From " + ugw.table + " ugw " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where ugw." + ugw.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public UnitGw selectByPk1(String copId)
        {
            UnitGw cop1 = new UnitGw();
            DataTable dt = new DataTable();
            String sql = "select ugw.* " +
                "From " + ugw.table + " ugw " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where ugw." + ugw.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setUnitGw(dt);
            return cop1;
        }
        private UnitGw setUnitGw(DataTable dt)
        {
            UnitGw pti1 = new UnitGw();
            if (dt.Rows.Count > 0)
            {
                pti1.unit_gw_id = dt.Rows[0][ugw.unit_gw_id].ToString();
                pti1.unit_gw_code = dt.Rows[0][ugw.unit_gw_code].ToString();
                pti1.unit_gw_name_e = dt.Rows[0][ugw.unit_gw_name_e].ToString();
                pti1.unit_gw_name_t = dt.Rows[0][ugw.unit_gw_name_t].ToString();
                pti1.active = dt.Rows[0][ugw.active].ToString();
                pti1.date_cancel = dt.Rows[0][ugw.date_cancel].ToString();
                pti1.date_create = dt.Rows[0][ugw.date_create].ToString();
                pti1.date_modi = dt.Rows[0][ugw.date_modi].ToString();
                pti1.user_cancel = dt.Rows[0][ugw.user_cancel].ToString();
                pti1.user_create = dt.Rows[0][ugw.user_create].ToString();
                pti1.user_modi = dt.Rows[0][ugw.user_modi].ToString();
                //pti1.status_app = dt.Rows[0][tmn.status_app].ToString();
                pti1.remark = dt.Rows[0][ugw.remark].ToString();
                pti1.sort1 = dt.Rows[0][ugw.sort1].ToString();
            }

            return pti1;
        }
    }
}
