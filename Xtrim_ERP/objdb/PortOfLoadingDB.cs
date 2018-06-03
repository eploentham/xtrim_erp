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
    public class PortOfLoadingDB
    {
        public PortOfLoading pol;
        ConnectDB conn;

        public List<PortOfLoading> lPol;
        public DataTable dtPol;

        public PortOfLoadingDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            pol = new PortOfLoading();
            pol.port_of_loading_id = "port_of_loading_id";
            pol.port_of_loading_code = "port_of_loading_code";
            pol.port_of_loading_t = "port_of_loading_name_t";
            pol.port_of_loading_e = "port_of_loading_name_e";
            pol.status_app = "status_app";
            pol.sort1 = "sort1";

            pol.active = "active";
            pol.date_create = "date_create";
            pol.date_modi = "date_modi";
            pol.date_cancel = "date_cancel";
            pol.user_create = "user_create";
            pol.user_modi = "user_modi";
            pol.user_cancel = "user_cancel";
            pol.cntrycode = "cntrycode";
            pol.remark = "remark";

            pol.table = "b_port_of_loading";
            pol.pkField = "port_of_loading_id";

            lPol = new List<PortOfLoading>();

            //getlPol();
        }
        public void getlPol()
        {
            //lDept = new List<Position>();

            lPol.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            dtPol = dt;
            foreach (DataRow row in dt.Rows)
            {
                PortOfLoading pti1 = new PortOfLoading();
                pti1.port_of_loading_id = row[pol.port_of_loading_id].ToString();
                pti1.port_of_loading_code = row[pol.port_of_loading_code].ToString();
                pti1.port_of_loading_t = row[pol.port_of_loading_t].ToString();
                pti1.port_of_loading_e = row[pol.port_of_loading_e].ToString();

                lPol.Add(pti1);
            }
        }
        public void setCboPol(ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectWard();
            foreach (PortOfLoading cus1 in lPol)
            {
                item = new ComboBoxItem();
                item.Value = cus1.port_of_loading_id;
                item.Text = cus1.port_of_loading_t;
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
            foreach (PortOfLoading pol1 in lPol)
            {
                if (code.Trim().Equals(pol1.port_of_loading_code))
                {
                    id = pol1.port_of_loading_id;
                    break;
                }
            }
            return id;
        }
        public String getIdByName(String name)
        {
            String id = "";
            foreach (PortOfLoading pti1 in lPol)
            {
                if (name.Trim().Equals(pti1.port_of_loading_t))
                {
                    id = pti1.port_of_loading_id;
                    break;
                }
            }
            return id;
        }
        public String insert(PortOfLoading p)
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

            sql = "Insert Into " + pol.table + "(" + pol.port_of_loading_code + "," + pol.port_of_loading_e + "," + pol.port_of_loading_t + "," +
                pol.date_create + "," + pol.date_modi + "," + pol.date_cancel + "," +
                pol.user_create + "," + pol.user_modi + "," + pol.user_cancel + "," +
                pol.active + "," + pol.remark + ", " + pol.sort1 + ", " +
                pol.status_app + ", " + pol.cntrycode + " " +
                ") " +
                "Values ('" + p.port_of_loading_code + "','" + p.port_of_loading_e.Replace("'", "''") + "','" + p.port_of_loading_t.Replace("'", "''") + "'," +
                "'" + p.date_create + "','" + p.date_modi + "','" + p.date_cancel + "'," +
                "'" + p.user_create + "','" + p.user_modi + "','" + p.user_cancel + "'," +
                "'" + p.active + "','" + p.remark.Replace("'", "''") + "','" + p.sort1 + "'," +
                "'" + p.status_app + "','" + p.cntrycode + "' " +
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
        public String update(PortOfLoading p)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            sql = "Update " + pol.table + " Set " +
                " " + pol.port_of_loading_code + " = '" + p.port_of_loading_code + "'" +
                "," + pol.port_of_loading_e + " = '" + p.port_of_loading_e.Replace("'", "''") + "'" +
                "," + pol.port_of_loading_t + " = '" + p.port_of_loading_t.Replace("'", "''") + "'" +
                "," + pol.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + pol.date_modi + " = now()" +
                "," + pol.user_modi + " = '" + p.user_modi + "' " +
                "," + pol.sort1 + " = '" + p.sort1 + "' " +
                "," + pol.status_app + " = '" + p.status_app + "' " +
                "," + pol.cntrycode + " = '" + p.cntrycode + "' " +
                "Where " + pol.pkField + "='" + p.port_of_loading_id + "'"
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
        public String insertPortImprt(PortOfLoading p)
        {
            String re = "";

            if (p.port_of_loading_id.Equals(""))
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
            String sql = "Delete From  " + pol.table;
            conn.ExecuteNonQuery(conn.conn, sql);

            return "";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select pol.*  " +
                "From " + pol.table + " pol " +
                " " +
                "Where pol." + pol.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select pol.* " +
                "From " + pol.table + " pol " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where pol." + pol.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public PortOfLoading selectByPk1(String copId)
        {
            PortOfLoading cop1 = new PortOfLoading();
            DataTable dt = new DataTable();
            String sql = "select pol.* " +
                "From " + pol.table + " pol " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where pol." + pol.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setPortOfLoading(dt);
            return cop1;
        }
        public DataTable selectByCodeLike(String copId)
        {
            PortOfLoading cop1 = new PortOfLoading();
            DataTable dt = new DataTable();
            String sql = "select pol.* " +
                "From " + pol.table + " pol " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +"Where LOWER(stf." + stf.staff_code + ") like '" + copId.ToLower() + "%'  ";
                "Where LOWER(pol." + pol.port_of_loading_code + ") like '%" + copId.ToLower() + "%' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public PortOfLoading setPortOfLoading(DataTable dt)
        {
            PortOfLoading pti1 = new PortOfLoading();
            if (dt.Rows.Count > 0)
            {
                pti1.port_of_loading_id = dt.Rows[0][pol.port_of_loading_id].ToString();
                pti1.port_of_loading_code = dt.Rows[0][pol.port_of_loading_code].ToString();
                pti1.port_of_loading_e = dt.Rows[0][pol.port_of_loading_e].ToString();
                pti1.port_of_loading_t = dt.Rows[0][pol.port_of_loading_t].ToString();
                pti1.active = dt.Rows[0][pol.active].ToString();
                pti1.date_cancel = dt.Rows[0][pol.date_cancel].ToString();
                pti1.date_create = dt.Rows[0][pol.date_create].ToString();
                pti1.date_modi = dt.Rows[0][pol.date_modi].ToString();
                pti1.user_cancel = dt.Rows[0][pol.user_cancel].ToString();
                pti1.user_create = dt.Rows[0][pol.user_create].ToString();
                pti1.user_modi = dt.Rows[0][pol.user_modi].ToString();
                pti1.status_app = dt.Rows[0][pol.status_app].ToString();
                pti1.remark = dt.Rows[0][pol.remark].ToString();
                pti1.sort1 = dt.Rows[0][pol.sort1].ToString();
                pti1.cntrycode = dt.Rows[0][pol.cntrycode].ToString();
            }

            return pti1;
        }
    }
}
