using C1.Win.C1Input;
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
    public class TruckDB
    {
        public Truck trk;
        ConnectDB conn;

        public List<Truck> lTmn;
        public DataTable dtTmn;

        public TruckDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            trk = new Truck();
            trk.truck_id = "truck_id";
            trk.truck_code = "truck_code";
            trk.truck_name_e = "truck_name_e";
            trk.truck_name_t = "truck_name_t";
            //trk.status_app = "status_app";
            trk.sort1 = "sort1";

            trk.active = "active";
            trk.date_create = "date_create";
            trk.date_modi = "date_modi";
            trk.date_cancel = "date_cancel";
            trk.user_create = "user_create";
            trk.user_modi = "user_modi";
            trk.user_cancel = "user_cancel";
            //trk.status_app = "status_app";
            trk.remark = "remark";

            trk.table = "b_truck";
            trk.pkField = "truck_id";

            lTmn = new List<Truck>();

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
                Truck pti1 = new Truck();
                pti1.truck_id = row[trk.truck_id].ToString();
                pti1.truck_code = row[trk.truck_code].ToString();
                pti1.truck_name_e = row[trk.truck_name_e].ToString();
                pti1.truck_name_t = row[trk.truck_name_t].ToString();

                lTmn.Add(pti1);
            }
        }
        public C1ComboBox setCboTrkC1(C1ComboBox c)
        {
            DataTable dt = selectAll();
            c.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                ComboBoxItem a1 = new ComboBoxItem();
                a1.Value = row[trk.truck_id].ToString();
                a1.Text = row[trk.truck_name_t].ToString();
                c.Items.Add(a1);
            }
            return c;
        }
        public void setCboTrk(ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectWard();
            foreach (Truck cus1 in lTmn)
            {
                item = new ComboBoxItem();
                item.Value = cus1.truck_id;
                item.Text = cus1.truck_name_t;
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
            foreach (Truck pol1 in lTmn)
            {
                if (code.Trim().Equals(pol1.truck_code))
                {
                    id = pol1.truck_id;
                    break;
                }
            }
            return id;
        }
        public String getIdByName(String name)
        {
            String id = "";
            foreach (Truck pti1 in lTmn)
            {
                if (name.Trim().Equals(pti1.truck_name_t))
                {
                    id = pti1.truck_id;
                    break;
                }
            }
            return id;
        }
        public String insert(Truck p)
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

            sql = "Insert Into " + trk.table + "(" + trk.truck_code + "," + trk.truck_name_e + "," + trk.truck_name_t + "," +
                trk.date_create + "," + trk.date_modi + "," + trk.date_cancel + "," +
                trk.user_create + "," + trk.user_modi + "," + trk.user_cancel + "," +
                trk.active + "," + trk.remark + ", " + trk.sort1 + " " +
                ") " +
                "Values ('" + p.truck_code + "','" + p.truck_name_e.Replace("'", "''") + "','" + p.truck_name_t.Replace("'", "''") + "'," +
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
        public String update(Truck p)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            sql = "Update " + trk.table + " Set " +
                " " + trk.truck_code + " = '" + p.truck_code + "'" +
                "," + trk.truck_name_e + " = '" + p.truck_name_e.Replace("'", "''") + "'" +
                "," + trk.truck_name_t + " = '" + p.truck_name_t.Replace("'", "''") + "'" +
                "," + trk.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + trk.date_modi + " = now()" +
                "," + trk.user_modi + " = '" + p.user_modi + "' " +
                "," + trk.sort1 + " = '" + p.sort1 + "' " +
                //"," + trk.status_app + " = '" + p.status_app + "' " +
                "Where " + trk.pkField + "='" + p.truck_id + "'"
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
        public String insertTruck(Truck p)
        {
            String re = "";

            if (p.truck_id.Equals(""))
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
            String sql = "Delete From  " + trk.table;
            conn.ExecuteNonQuery(conn.conn, sql);

            return "";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select trk.*  " +
                "From " + trk.table + " trk " +
                " " +
                "Where trk." + trk.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select trk.* " +
                "From " + trk.table + " trk " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where trk." + trk.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public Truck selectByPk1(String copId)
        {
            Truck cop1 = new Truck();
            DataTable dt = new DataTable();
            String sql = "select trk.* " +
                "From " + trk.table + " trk " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where trk." + trk.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setPortImport(dt);
            return cop1;
        }
        private Truck setPortImport(DataTable dt)
        {
            Truck pti1 = new Truck();
            if (dt.Rows.Count > 0)
            {
                pti1.truck_id = dt.Rows[0][trk.truck_id].ToString();
                pti1.truck_code = dt.Rows[0][trk.truck_code].ToString();
                pti1.truck_name_e = dt.Rows[0][trk.truck_name_e].ToString();
                pti1.truck_name_t = dt.Rows[0][trk.truck_name_t].ToString();
                pti1.active = dt.Rows[0][trk.active].ToString();
                pti1.date_cancel = dt.Rows[0][trk.date_cancel].ToString();
                pti1.date_create = dt.Rows[0][trk.date_create].ToString();
                pti1.date_modi = dt.Rows[0][trk.date_modi].ToString();
                pti1.user_cancel = dt.Rows[0][trk.user_cancel].ToString();
                pti1.user_create = dt.Rows[0][trk.user_create].ToString();
                pti1.user_modi = dt.Rows[0][trk.user_modi].ToString();
                //pti1.status_app = dt.Rows[0][trk.status_app].ToString();
                pti1.remark = dt.Rows[0][trk.remark].ToString();
                pti1.sort1 = dt.Rows[0][trk.sort1].ToString();
            }

            return pti1;
        }
    }
}
