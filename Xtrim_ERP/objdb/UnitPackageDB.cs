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
    public class UnitPackageDB
    {
        public UnitPackage utp;
        ConnectDB conn;

        public List<UnitPackage> lUtp;
        public DataTable dtUtp;

        public UnitPackageDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            utp = new UnitPackage();
            utp.unit_package_id = "unit_package_id";
            utp.unit_package_code = "unit_package_code";
            utp.unit_package_name_e = "unit_package_name_e";
            utp.unit_package_name_t = "unit_package_name_t";
            //tmn.status_app = "status_app";
            utp.sort1 = "sort1";

            utp.active = "active";
            utp.date_create = "date_create";
            utp.date_modi = "date_modi";
            utp.date_cancel = "date_cancel";
            utp.user_create = "user_create";
            utp.user_modi = "user_modi";
            utp.user_cancel = "user_cancel";
            //tmn.status_app = "status_app";
            utp.remark = "remark";

            utp.table = "b_unit_package";
            utp.pkField = "unit_package_id";

            lUtp = new List<UnitPackage>();
            //getlPol();
        }
        public void getlPol()
        {
            //lDept = new List<Department>();

            lUtp.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            dtUtp = dt;
            foreach (DataRow row in dt.Rows)
            {
                UnitPackage utp1 = new UnitPackage();
                utp1.unit_package_id = row[utp.unit_package_id].ToString();
                utp1.unit_package_code = row[utp.unit_package_code].ToString();
                utp1.unit_package_name_e = row[utp.unit_package_name_e].ToString();
                utp1.unit_package_name_t = row[utp.unit_package_name_t].ToString();

                lUtp.Add(utp1);
            }
        }
        
        public void setCboUtp(ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectWard();
            foreach (UnitPackage cus1 in lUtp)
            {
                item = new ComboBoxItem();
                item.Value = cus1.unit_package_id;
                item.Text = cus1.unit_package_name_t;
                c.Items.Add(item);
                if (item.Value.Equals(selected))
                {
                    c.SelectedItem = item;
                }
            }
        }
        public void setC1CboUtp(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectWard();
            if (lUtp.Count <= 0) getlPol();
            foreach (UnitPackage cus1 in lUtp)
            {
                item = new ComboBoxItem();
                item.Value = cus1.unit_package_id;
                item.Text = cus1.unit_package_name_t;
                c.Items.Add(item);
                if (item.Value.Equals(selected))
                {
                    //c.SelectedItem = item.Value;
                    c.SelectedText = item.Text;
                }
            }
        }
        public String getIdByCode(String code)
        {
            String id = "";
            foreach (UnitPackage utp1 in lUtp)
            {
                if (code.Trim().Equals(utp1.unit_package_code))
                {
                    id = utp1.unit_package_id;
                    break;
                }
            }
            return id;
        }
        public String getIdByName(String name)
        {
            String id = "";
            foreach (UnitPackage utp1 in lUtp)
            {
                if (name.Trim().Equals(utp1.unit_package_name_t))
                {
                    id = utp1.unit_package_id;
                    break;
                }
            }
            return id;
        }
        public String insert(UnitPackage p)
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

            sql = "Insert Into " + utp.table + "(" + utp.unit_package_code + "," + utp.unit_package_name_e + "," + utp.unit_package_name_t + "," +
                utp.date_create + "," + utp.date_modi + "," + utp.date_cancel + "," +
                utp.user_create + "," + utp.user_modi + "," + utp.user_cancel + "," +
                utp.active + "," + utp.remark + ", " + utp.sort1 + " " +
                ") " +
                "Values ('" + p.unit_package_code + "','" + p.unit_package_name_e.Replace("'", "''") + "','" + p.unit_package_name_t.Replace("'", "''") + "'," +
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
        public String update(UnitPackage p)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            sql = "Update " + utp.table + " Set " +
                " " + utp.unit_package_code + " = '" + p.unit_package_code + "'" +
                "," + utp.unit_package_name_e + " = '" + p.unit_package_name_e.Replace("'", "''") + "'" +
                "," + utp.unit_package_name_t + " = '" + p.unit_package_name_t.Replace("'", "''") + "'" +
                "," + utp.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + utp.date_modi + " = now()" +
                "," + utp.user_modi + " = '" + p.user_modi + "' " +
                "," + utp.sort1 + " = '" + p.sort1 + "' " +
                //"," + tmn.status_app + " = '" + p.status_app + "' " +
                "Where " + utp.pkField + "='" + p.unit_package_id + "'"
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
        public String insertPortImprt(UnitPackage p)
        {
            String re = "";

            if (p.unit_package_id.Equals(""))
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
            String sql = "Delete From  " + utp.table;
            conn.ExecuteNonQuery(conn.conn, sql);

            return "";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select utp.*  " +
                "From " + utp.table + " utp " +
                " " +
                "Where utp." + utp.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select utp.* " +
                "From " + utp.table + " utp " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where utp." + utp.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public UnitPackage selectByPk1(String copId)
        {
            UnitPackage cop1 = new UnitPackage();
            DataTable dt = new DataTable();
            String sql = "select utp.* " +
                "From " + utp.table + " utp " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where utp." + utp.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setPortImport(dt);
            return cop1;
        }
        private UnitPackage setPortImport(DataTable dt)
        {
            UnitPackage pti1 = new UnitPackage();
            if (dt.Rows.Count > 0)
            {
                pti1.unit_package_id = dt.Rows[0][utp.unit_package_id].ToString();
                pti1.unit_package_code = dt.Rows[0][utp.unit_package_code].ToString();
                pti1.unit_package_name_e = dt.Rows[0][utp.unit_package_name_e].ToString();
                pti1.unit_package_name_t = dt.Rows[0][utp.unit_package_name_t].ToString();
                pti1.active = dt.Rows[0][utp.active].ToString();
                pti1.date_cancel = dt.Rows[0][utp.date_cancel].ToString();
                pti1.date_create = dt.Rows[0][utp.date_create].ToString();
                pti1.date_modi = dt.Rows[0][utp.date_modi].ToString();
                pti1.user_cancel = dt.Rows[0][utp.user_cancel].ToString();
                pti1.user_create = dt.Rows[0][utp.user_create].ToString();
                pti1.user_modi = dt.Rows[0][utp.user_modi].ToString();
                //pti1.status_app = dt.Rows[0][tmn.status_app].ToString();
                pti1.remark = dt.Rows[0][utp.remark].ToString();
                pti1.sort1 = dt.Rows[0][utp.sort1].ToString();
            }

            return pti1;
        }
    }
}
