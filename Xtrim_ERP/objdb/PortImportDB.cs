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
    public class PortImportDB
    {
        public PortImport pti;
        ConnectDB conn;

        public List<PortImport> lPti;

        public PortImportDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            pti = new PortImport();
            pti.port_import_id = "port_import_id";
            pti.port_import_code = "port_import_code";
            pti.port_import_name_t = "port_import_name_t";
            pti.port_import_name_e = "port_import_name_e";
            pti.active = "active";
            pti.date_create = "date_create";
            pti.date_modi = "date_modi";
            pti.date_cancel = "date_cancel";
            pti.user_create = "user_create";
            pti.user_modi = "user_modi";
            pti.user_cancel = "user_cancel";
            pti.status_app = "status_app";
            pti.remark = "remark";
            pti.sort1 = "sort1";

            pti.table = "b_port_import";
            pti.pkField = "port_import_id";

            lPti = new List<PortImport>();

            //getlPti();
        }
        public void getlPti()
        {
            //lDept = new List<Department>();

            lPti.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                PortImport pti1 = new PortImport();
                pti1.port_import_id = row[pti.port_import_id].ToString();
                pti1.port_import_code = row[pti.port_import_code].ToString();
                pti1.port_import_name_t = row[pti.port_import_name_t].ToString();
                pti1.port_import_name_e = row[pti.port_import_name_e].ToString();

                lPti.Add(pti1);
            }
        }
        public void setCboPti(ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectWard();
            foreach (PortImport cus1 in lPti)
            {
                item = new ComboBoxItem();
                item.Value = cus1.port_import_id;
                item.Text = cus1.port_import_name_t;
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
            foreach (PortImport pti1 in lPti)
            {
                if (code.Trim().Equals(pti1.port_import_code))
                {
                    id = pti1.port_import_id;
                    break;
                }
            }
            return id;
        }
        public String getIdByName(String name)
        {
            String id = "";
            foreach (PortImport pti1 in lPti)
            {
                if (name.Trim().Equals(pti1.port_import_name_t))
                {
                    id = pti1.port_import_id;
                    break;
                }
            }
            return id;
        }
        public String insert(PortImport p)
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

            sql = "Insert Into " + pti.table + "(" + pti.port_import_code + "," + pti.port_import_name_e + "," + pti.port_import_name_t + "," +                
                pti.date_create + "," + pti.date_modi + "," + pti.date_cancel + "," +
                pti.user_create + "," + pti.user_modi + "," + pti.user_cancel + "," +
                pti.active + "," + pti.remark + ", " + pti.sort1 + ", " +
                pti.status_app  + " " +
                ") " +
                "Values ('" + p.port_import_code + "','" + p.port_import_name_e.Replace("'", "''") + "','" + p.port_import_name_t.Replace("'", "''") + "'," +
                "'" + p.date_create + "','" + p.date_modi + "','" + p.date_cancel + "'," +
                "'" + p.user_create + "','" + p.user_modi + "','" + p.user_cancel + "'," +
                "'" + p.active + "','" + p.remark.Replace("'", "''") + "','" + p.sort1 + "'," +
                "'" + p.status_app + "' " +
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
        public String update(PortImport p)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            sql = "Update " + pti.table + " Set " +
                " " + pti.port_import_code + " = '" + p.port_import_code + "'" +
                "," + pti.port_import_name_e + " = '" + p.port_import_name_e.Replace("'", "''") + "'" +
                "," + pti.port_import_name_t + " = '" + p.port_import_name_t.Replace("'", "''") + "'" +                
                "," + pti.remark + " = '" + p.remark.Replace("'", "''") + "'" +                
                "," + pti.date_modi + " = now()" +                
                "," + pti.user_modi + " = '" + p.user_modi + "' " +
                "," + pti.sort1 + " = '" + p.sort1 + "' " +
                "," + pti.status_app + " = '" + p.status_app + "' " +
                "Where " + pti.pkField + "='" + p.port_import_id + "'"
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
        public String insertPortImprt(PortImport p)
        {
            String re = "";

            if (p.port_import_id.Equals(""))
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
            String sql = "Delete From  " + pti.table;
            conn.ExecuteNonQuery(conn.conn, sql);

            return "";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select pti.*  " +
                "From " + pti.table + " pti " +
                " " +
                "Where pti." + pti.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select pti.* " +
                "From " + pti.table + " pti " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where pti." + pti.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public PortImport selectByPk1(String copId)
        {
            PortImport cop1 = new PortImport();
            DataTable dt = new DataTable();
            String sql = "select pti.* " +
                "From " + pti.table + " pti " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where pti." + pti.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setPortImport(dt);
            return cop1;
        }
        public DataTable selectByCodeLike(String copId)
        {
            PortImport cop1 = new PortImport();
            DataTable dt = new DataTable();
            String sql = "select pti.* " +
                "From " + pti.table + " pti " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +"Where LOWER(stf." + stf.staff_code + ") like '" + copId.ToLower() + "%'  ";
                "Where LOWER(pti." + pti.port_import_code + ") like '%" + copId.ToLower() + "%' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public PortImport setPortImport(DataTable dt)
        {
            PortImport pti1 = new PortImport();
            if (dt.Rows.Count > 0)
            {
                pti1.port_import_id = dt.Rows[0][pti.port_import_id].ToString();
                pti1.port_import_code = dt.Rows[0][pti.port_import_code].ToString();
                pti1.port_import_name_e = dt.Rows[0][pti.port_import_name_e].ToString();
                pti1.port_import_name_t = dt.Rows[0][pti.port_import_name_t].ToString();
                pti1.active = dt.Rows[0][pti.active].ToString();
                pti1.date_cancel = dt.Rows[0][pti.date_cancel].ToString();
                pti1.date_create = dt.Rows[0][pti.date_create].ToString();
                pti1.date_modi = dt.Rows[0][pti.date_modi].ToString();
                pti1.user_cancel = dt.Rows[0][pti.user_cancel].ToString();
                pti1.user_create = dt.Rows[0][pti.user_create].ToString();
                pti1.user_modi = dt.Rows[0][pti.user_modi].ToString();
                pti1.status_app = dt.Rows[0][pti.status_app].ToString();
                pti1.remark = dt.Rows[0][pti.remark].ToString();
                pti1.sort1 = dt.Rows[0][pti.sort1].ToString();
            }

            return pti1;
        }
    }
}
