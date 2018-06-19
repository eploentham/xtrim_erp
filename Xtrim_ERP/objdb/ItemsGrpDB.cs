using C1.Win.C1Input;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xtrim_ERP.object1;

namespace Xtrim_ERP.objdb
{
    public class ItemsGrpDB
    {
        public ItemsGrp itmG;
        ConnectDB conn;

        public List<ItemsGrp> lexpnC;
        public ItemsGrpDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            itmG = new ItemsGrp();
            itmG.item_grp_id = "item_grp_id";
            itmG.item_grp_code = "item_grp_code";
            itmG.item_grp_name_e = "item_grp_name_e";
            itmG.item_grp_name_t = "item_grp_name_t";
            //tmn.status_app = "status_app";
            itmG.sort1 = "sort1";

            itmG.active = "active";
            itmG.date_create = "date_create";
            itmG.date_modi = "date_modi";
            itmG.date_cancel = "date_cancel";
            itmG.user_create = "user_create";
            itmG.user_modi = "user_modi";
            itmG.user_cancel = "user_cancel";
            //tmn.status_app = "status_app";
            itmG.remark = "remark";

            itmG.table = "b_items_grp";
            itmG.pkField = "item_grp_id";

            lexpnC = new List<ItemsGrp>();
        }
        public void getlexpnC()
        {
            //lDept = new List<Department>();

            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                ItemsGrp curr1 = new ItemsGrp();
                curr1.item_grp_id = row[itmG.item_grp_id].ToString();
                curr1.item_grp_code = row[itmG.item_grp_code].ToString();
                curr1.item_grp_name_e = row[itmG.item_grp_name_e].ToString();
                curr1.item_grp_name_t = row[itmG.item_grp_name_t].ToString();
                lexpnC.Add(curr1);
            }
        }
        public String getIdByCode(String code)
        {
            String id = "";
            foreach (ItemsGrp curr1 in lexpnC)
            {
                if (code.Trim().Equals(curr1.item_grp_code))
                {
                    id = curr1.item_grp_id;
                    break;
                }
            }
            return id;
        }
        public String getIdByName(String name)
        {
            String id = "";
            foreach (ItemsGrp curr1 in lexpnC)
            {
                if (name.Trim().Equals(curr1.item_grp_name_t))
                {
                    id = curr1.item_grp_id;
                    break;
                }
            }
            return id;
        }
        public void setC1CboExpnG(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            if (lexpnC.Count <= 0) getlexpnC();
            //DataTable dt = selectWard();
            foreach (ItemsGrp cus1 in lexpnC)
            {
                item = new ComboBoxItem();
                item.Value = cus1.item_grp_id;
                item.Text = cus1.item_grp_name_t;
                c.Items.Add(item);
                if (item.Value.Equals(selected))
                {
                    c.SelectedText = item.Text;
                }
            }
        }
        private void chkNull(ItemsGrp p)
        {
            int chk = 0;
            Decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            p.item_grp_code = p.item_grp_code == null ? "" : p.item_grp_code;
            p.item_grp_name_e = p.item_grp_name_e == null ? "" : p.item_grp_name_e;
            p.item_grp_name_t = p.item_grp_name_t == null ? "" : p.item_grp_name_t;
            p.remark = p.remark == null ? "" : p.remark;
            p.sort1 = p.sort1 == null ? "" : p.sort1;
        }
        public String insert(ItemsGrp p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            //p.prefix_id = int.TryParse(p.prefix_id, out chk) ? chk.ToString() : "0";
            //p.dept_id = int.TryParse(p.dept_id, out chk) ? chk.ToString() : "0";

            sql = "Insert Into " + itmG.table + "(" + itmG.item_grp_code + "," + itmG.item_grp_name_e + "," + itmG.item_grp_name_t + "," +
                itmG.date_create + "," + itmG.date_modi + "," + itmG.date_cancel + "," +
                itmG.user_create + "," + itmG.user_modi + "," + itmG.user_cancel + "," +
                itmG.active + "," + itmG.remark + ", " + itmG.sort1 + " " +
                ") " +
                "Values ('" + p.item_grp_code + "','" + p.item_grp_name_e.Replace("'", "''") + "','" + p.item_grp_name_t.Replace("'", "''") + "'," +
                "'" + p.date_create + "','" + p.date_modi + "','" + p.date_cancel + "'," +
                "'" + userId + "','" + p.user_modi + "','" + p.user_cancel + "'," +
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
        public String update(ItemsGrp p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);

            sql = "Update " + itmG.table + " Set " +
                " " + itmG.item_grp_code + " = '" + p.item_grp_code + "'" +
                "," + itmG.item_grp_name_e + " = '" + p.item_grp_name_e.Replace("'", "''") + "'" +
                "," + itmG.item_grp_name_t + " = '" + p.item_grp_name_t.Replace("'", "''") + "'" +
                "," + itmG.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + itmG.date_modi + " = now()" +
                "," + itmG.user_modi + " = '" + userId + "' " +
                "," + itmG.sort1 + " = '" + p.sort1 + "' " +
                //"," + tmn.status_app + " = '" + p.status_app + "' " +
                "Where " + itmG.pkField + "='" + p.item_grp_id + "'"
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
        public String insertExpenseGrp(ItemsGrp p, String userId)
        {
            String re = "";

            if (p.item_grp_id.Equals(""))
            {
                re = insert(p, userId);
            }
            else
            {
                re = update(p, userId);
            }

            return re;
        }
        public String deleteAll()
        {
            DataTable dt = new DataTable();
            String sql = "Delete From  " + itmG.table;
            conn.ExecuteNonQuery(conn.conn, sql);

            return "";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select expC.*  " +
                "From " + itmG.table + " expC " +
                " " +
                "Where expC." + itmG.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByCodeLike(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select expC.* " +
                "From " + itmG.table + " expC " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where LOWER(expC." + itmG.item_grp_code + ") like '%" + copId.ToLower() + "%' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public String selectByNameTLike(String copId)
        {
            String currId = "";
            DataTable dt = new DataTable();
            String sql = "select expC.* " +
                "From " + itmG.table + " expC " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where expC." + itmG.item_grp_name_t + " like '%" + copId.ToLower() + "%' ";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count == 1)
            {
                currId = dt.Rows[0][itmG.item_grp_id].ToString();
            }
            return currId;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select expC.* " +
                "From " + itmG.table + " expC " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where expC." + itmG.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public ItemsGrp selectByPk1(String copId)
        {
            ItemsGrp cop1 = new ItemsGrp();
            DataTable dt = new DataTable();
            String sql = "select expC.* " +
                "From " + itmG.table + " expC " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where expC." + itmG.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setExpenseGrp(dt);
            return cop1;
        }
        public ItemsGrp setExpenseGrp(DataTable dt)
        {
            ItemsGrp curr1 = new ItemsGrp();
            if (dt.Rows.Count > 0)
            {
                curr1.item_grp_id = dt.Rows[0][itmG.item_grp_id].ToString();
                curr1.item_grp_code = dt.Rows[0][itmG.item_grp_code].ToString();
                curr1.item_grp_name_e = dt.Rows[0][itmG.item_grp_name_e].ToString();
                curr1.item_grp_name_t = dt.Rows[0][itmG.item_grp_name_t].ToString();
                curr1.active = dt.Rows[0][itmG.active].ToString();
                curr1.date_cancel = dt.Rows[0][itmG.date_cancel].ToString();
                curr1.date_create = dt.Rows[0][itmG.date_create].ToString();
                curr1.date_modi = dt.Rows[0][itmG.date_modi].ToString();
                curr1.user_cancel = dt.Rows[0][itmG.user_cancel].ToString();
                curr1.user_create = dt.Rows[0][itmG.user_create].ToString();
                curr1.user_modi = dt.Rows[0][itmG.user_modi].ToString();
                //pti1.status_app = dt.Rows[0][tmn.status_app].ToString();
                curr1.remark = dt.Rows[0][itmG.remark].ToString();
                curr1.sort1 = dt.Rows[0][itmG.sort1].ToString();
            }

            return curr1;
        }
    }
}
