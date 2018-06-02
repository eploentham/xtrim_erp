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
    public class TerminalDB
    {
        public Terminal tmn;
        ConnectDB conn;

        public List<Terminal> lTmn;
        public DataTable dtTmn;

        public TerminalDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            tmn = new Terminal();
            tmn.terminal_id = "terminal_id";
            tmn.terminal_code = "terminal_code";
            tmn.terminal_name_e = "terminal_name_e";
            tmn.terminal_name_t = "terminal_name_t";
            //tmn.status_app = "status_app";
            tmn.sort1 = "sort1";

            tmn.active = "active";
            tmn.date_create = "date_create";
            tmn.date_modi = "date_modi";
            tmn.date_cancel = "date_cancel";
            tmn.user_create = "user_create";
            tmn.user_modi = "user_modi";
            tmn.user_cancel = "user_cancel";
            //tmn.status_app = "status_app";
            tmn.remark = "remark";

            tmn.table = "b_terminal";
            tmn.pkField = "terminal_id";

            lTmn = new List<Terminal>();

            //getlPol();
        }
        public void getlPol()
        {
            //lDept = new List<Position>();

            lTmn.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            dtTmn = dt;
            foreach (DataRow row in dt.Rows)
            {
                Terminal pti1 = new Terminal();
                pti1.terminal_id = row[tmn.terminal_id].ToString();
                pti1.terminal_code = row[tmn.terminal_code].ToString();
                pti1.terminal_name_e = row[tmn.terminal_name_e].ToString();
                pti1.terminal_name_t = row[tmn.terminal_name_t].ToString();

                lTmn.Add(pti1);
            }
        }
        public void setCboTmn(ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectWard();
            foreach (Terminal cus1 in lTmn)
            {
                item = new ComboBoxItem();
                item.Value = cus1.terminal_id;
                item.Text = cus1.terminal_name_t;
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
            foreach (Terminal pol1 in lTmn)
            {
                if (code.Trim().Equals(pol1.terminal_code))
                {
                    id = pol1.terminal_id;
                    break;
                }
            }
            return id;
        }
        public String getIdByName(String name)
        {
            String id = "";
            foreach (Terminal pti1 in lTmn)
            {
                if (name.Trim().Equals(pti1.terminal_name_t))
                {
                    id = pti1.terminal_id;
                    break;
                }
            }
            return id;
        }
        public String insert(Terminal p)
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
            //p.posi_id = int.TryParse(p.posi_id, out chk) ? chk.ToString() : "0";

            sql = "Insert Into " + tmn.table + "(" + tmn.terminal_code + "," + tmn.terminal_name_e + "," + tmn.terminal_name_t + "," +
                tmn.date_create + "," + tmn.date_modi + "," + tmn.date_cancel + "," +
                tmn.user_create + "," + tmn.user_modi + "," + tmn.user_cancel + "," +
                tmn.active + "," + tmn.remark + ", " + tmn.sort1 + " " +
                ") " +
                "Values ('" + p.terminal_code + "','" + p.terminal_name_e.Replace("'", "''") + "','" + p.terminal_name_t.Replace("'", "''") + "'," +
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
        public String update(Terminal p)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            sql = "Update " + tmn.table + " Set " +
                " " + tmn.terminal_code + " = '" + p.terminal_code + "'" +
                "," + tmn.terminal_name_e + " = '" + p.terminal_name_e.Replace("'", "''") + "'" +
                "," + tmn.terminal_name_t + " = '" + p.terminal_name_t.Replace("'", "''") + "'" +
                "," + tmn.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + tmn.date_modi + " = now()" +
                "," + tmn.user_modi + " = '" + p.user_modi + "' " +
                "," + tmn.sort1 + " = '" + p.sort1 + "' " +
                //"," + tmn.status_app + " = '" + p.status_app + "' " +
                "Where " + tmn.pkField + "='" + p.terminal_id + "'"
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
        public String insertPortImprt(Terminal p)
        {
            String re = "";

            if (p.terminal_id.Equals(""))
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
            String sql = "Delete From  " + tmn.table;
            conn.ExecuteNonQuery(conn.conn, sql);

            return "";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select tmn.*  " +
                "From " + tmn.table + " tmn " +
                " " +
                "Where tmn." + tmn.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select tmn.* " +
                "From " + tmn.table + " tmn " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where tmn." + tmn.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public Terminal selectByPk1(String copId)
        {
            Terminal cop1 = new Terminal();
            DataTable dt = new DataTable();
            String sql = "select tmn.* " +
                "From " + tmn.table + " tmn " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where tmn." + tmn.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setPortImport(dt);
            return cop1;
        }
        private Terminal setPortImport(DataTable dt)
        {
            Terminal pti1 = new Terminal();
            if (dt.Rows.Count > 0)
            {
                pti1.terminal_id = dt.Rows[0][tmn.terminal_id].ToString();
                pti1.terminal_code = dt.Rows[0][tmn.terminal_code].ToString();
                pti1.terminal_name_e = dt.Rows[0][tmn.terminal_name_e].ToString();
                pti1.terminal_name_t = dt.Rows[0][tmn.terminal_name_t].ToString();
                pti1.active = dt.Rows[0][tmn.active].ToString();
                pti1.date_cancel = dt.Rows[0][tmn.date_cancel].ToString();
                pti1.date_create = dt.Rows[0][tmn.date_create].ToString();
                pti1.date_modi = dt.Rows[0][tmn.date_modi].ToString();
                pti1.user_cancel = dt.Rows[0][tmn.user_cancel].ToString();
                pti1.user_create = dt.Rows[0][tmn.user_create].ToString();
                pti1.user_modi = dt.Rows[0][tmn.user_modi].ToString();
                //pti1.status_app = dt.Rows[0][tmn.status_app].ToString();
                pti1.remark = dt.Rows[0][tmn.remark].ToString();
                pti1.sort1 = dt.Rows[0][tmn.sort1].ToString();
            }

            return pti1;
        }
    }
}
