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
    public class EntryTypeDB
    {
        public EntryType ett;
        ConnectDB conn;

        public List<EntryType> lEtt;

        public EntryTypeDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            ett = new EntryType();
            ett.entry_type_id = "entry_type_id";
            ett.entry_type_code = "entry_type_code";
            ett.entry_type_name_e = "entry_type_name_e";
            ett.entry_type_name_t = "entry_type_name_t";
            //ett.status_app = "status_app";
            ett.sort1 = "sort1";

            ett.active = "active";
            ett.date_create = "date_create";
            ett.date_modi = "date_modi";
            ett.date_cancel = "date_cancel";
            ett.user_create = "user_create";
            ett.user_modi = "user_modi";
            ett.user_cancel = "user_cancel";
            //ett.status_app = "status_app";
            ett.remark = "remark";

            ett.table = "b_entry_type";
            ett.pkField = "entry_type_id";

            lEtt = new List<EntryType>();

            getlEtt();
        }
        public void setCboEtt(ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectWard();
            foreach (EntryType cus1 in lEtt)
            {
                item = new ComboBoxItem();
                item.Value = cus1.entry_type_id;
                item.Text = cus1.entry_type_name_t;
                c.Items.Add(item);
                if (item.Value.Equals(selected))
                {
                    c.SelectedItem = item;
                }
            }
        }
        public void getlEtt()
        {
            //lDept = new List<Department>();

            lEtt.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                EntryType ett1 = new EntryType();
                ett1.entry_type_id = row[ett.entry_type_id].ToString();
                ett1.entry_type_code = row[ett.entry_type_code].ToString();
                ett1.entry_type_name_e = row[ett.entry_type_name_e].ToString();
                ett1.entry_type_name_t = row[ett.entry_type_name_t].ToString();

                lEtt.Add(ett1);
            }
        }
        public String getIdByCode(String code)
        {
            String id = "";
            foreach (EntryType ett1 in lEtt)
            {
                if (code.Trim().Equals(ett1.entry_type_code))
                {
                    id = ett1.entry_type_id;
                    break;
                }
            }
            return id;
        }
        public String getIdByName(String name)
        {
            String id = "";
            foreach (EntryType ett1 in lEtt)
            {
                if (name.Trim().Equals(ett1.entry_type_name_t))
                {
                    id = ett1.entry_type_id;
                    break;
                }
            }
            return id;
        }
        public String insert(EntryType p)
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

            sql = "Insert Into " + ett.table + "(" + ett.entry_type_code + "," + ett.entry_type_name_e + "," + ett.entry_type_name_t + "," +
                ett.date_create + "," + ett.date_modi + "," + ett.date_cancel + "," +
                ett.user_create + "," + ett.user_modi + "," + ett.user_cancel + "," +
                ett.active + "," + ett.remark + ", " + ett.sort1 + " " +
                ") " +
                "Values ('" + p.entry_type_code + "','" + p.entry_type_name_e.Replace("'", "''") + "','" + p.entry_type_name_t.Replace("'", "''") + "'," +
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
        public String update(EntryType p)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            sql = "Update " + ett.table + " Set " +
                " " + ett.entry_type_code + " = '" + p.entry_type_code + "'" +
                "," + ett.entry_type_name_e + " = '" + p.entry_type_name_e.Replace("'", "''") + "'" +
                "," + ett.entry_type_name_t + " = '" + p.entry_type_name_t.Replace("'", "''") + "'" +
                "," + ett.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + ett.date_modi + " = now()" +
                "," + ett.user_modi + " = '" + p.user_modi + "' " +
                "," + ett.sort1 + " = '" + p.sort1 + "' " +
                //"," + ett.status_app + " = '" + p.status_app + "' " +
                "Where " + ett.pkField + "='" + p.entry_type_id + "'"
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
        public String insertEntryType(EntryType p)
        {
            String re = "";

            if (p.entry_type_id.Equals(""))
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
            String sql = "Delete From  " + ett.table;
            conn.ExecuteNonQuery(conn.conn, sql);

            return "";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select ett.*  " +
                "From " + ett.table + " ett " +
                " " +
                "Where ett." + ett.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select ett.* " +
                "From " + ett.table + " ett " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where ett." + ett.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public EntryType selectByPk1(String copId)
        {
            EntryType cop1 = new EntryType();
            DataTable dt = new DataTable();
            String sql = "select ett.* " +
                "From " + ett.table + " ett " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where ett." + ett.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setEntryType(dt);
            return cop1;
        }
        private EntryType setEntryType(DataTable dt)
        {
            EntryType ett1 = new EntryType();
            if (dt.Rows.Count > 0)
            {
                ett1.entry_type_id = dt.Rows[0][ett.entry_type_id].ToString();
                ett1.entry_type_code = dt.Rows[0][ett.entry_type_code].ToString();
                ett1.entry_type_name_e = dt.Rows[0][ett.entry_type_name_e].ToString();
                ett1.entry_type_name_t = dt.Rows[0][ett.entry_type_name_t].ToString();
                ett1.active = dt.Rows[0][ett.active].ToString();
                ett1.date_cancel = dt.Rows[0][ett.date_cancel].ToString();
                ett1.date_create = dt.Rows[0][ett.date_create].ToString();
                ett1.date_modi = dt.Rows[0][ett.date_modi].ToString();
                ett1.user_cancel = dt.Rows[0][ett.user_cancel].ToString();
                ett1.user_create = dt.Rows[0][ett.user_create].ToString();
                ett1.user_modi = dt.Rows[0][ett.user_modi].ToString();
                //pti1.status_app = dt.Rows[0][ett.status_app].ToString();
                ett1.remark = dt.Rows[0][ett.remark].ToString();
                ett1.sort1 = dt.Rows[0][ett.sort1].ToString();
            }

            return ett1;
        }
    }
}
