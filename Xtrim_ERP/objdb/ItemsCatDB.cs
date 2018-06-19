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
    public class ItemsCatDB
    {
        public ItemsCat itmC;
        ConnectDB conn;

        public List<ItemsCat> lexpnC;
        public ItemsCatDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            itmC = new ItemsCat();
            itmC.item_cat_id = "item_cat_id";
            itmC.item_cat_code = "item_cat_code";
            itmC.item_cat_name_e = "item_cat_name_e";
            itmC.item_cat_name_t = "item_cat_name_t";
            //tmn.status_app = "status_app";
            itmC.sort1 = "sort1";

            itmC.active = "active";
            itmC.date_create = "date_create";
            itmC.date_modi = "date_modi";
            itmC.date_cancel = "date_cancel";
            itmC.user_create = "user_create";
            itmC.user_modi = "user_modi";
            itmC.user_cancel = "user_cancel";
            //tmn.status_app = "status_app";
            itmC.remark = "remark";

            itmC.table = "b_items_cat";
            itmC.pkField = "expenses_cat_id";

            lexpnC = new List<ItemsCat>();
        }
        public void getlexpnC()
        {
            //lDept = new List<Department>();
            
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                ItemsCat curr1 = new ItemsCat();
                curr1.item_cat_id = row[itmC.item_cat_id].ToString();
                curr1.item_cat_code = row[itmC.item_cat_code].ToString();
                curr1.item_cat_name_e = row[itmC.item_cat_name_e].ToString();
                curr1.item_cat_name_t = row[itmC.item_cat_name_t].ToString();
                lexpnC.Add(curr1);
            }
        }
        public String getIdByCode(String code)
        {
            String id = "";
            foreach (ItemsCat curr1 in lexpnC)
            {
                if (code.Trim().Equals(curr1.item_cat_code))
                {
                    id = curr1.item_cat_id;
                    break;
                }
            }
            return id;
        }
        public String getIdByName(String name)
        {
            String id = "";
            foreach (ItemsCat curr1 in lexpnC)
            {
                if (name.Trim().Equals(curr1.item_cat_name_t))
                {
                    id = curr1.item_cat_id;
                    break;
                }
            }
            return id;
        }
        public void setC1CboExpnC(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            if (lexpnC.Count <= 0) getlexpnC();
            //DataTable dt = selectWard();
            foreach (ItemsCat cus1 in lexpnC)
            {
                item = new ComboBoxItem();
                item.Value = cus1.item_cat_id;
                item.Text = cus1.item_cat_name_t;
                c.Items.Add(item);
                if (item.Value.Equals(selected))
                {
                    c.SelectedText = item.Text;
                }
            }
        }
        private void chkNull(ItemsCat p)
        {
            int chk = 0;
            Decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            p.item_cat_code = p.item_cat_code == null ? "" : p.item_cat_code;
            p.item_cat_name_e = p.item_cat_name_e == null ? "" : p.item_cat_name_e;
            p.item_cat_name_t = p.item_cat_name_t == null ? "" : p.item_cat_name_t;
            p.remark = p.remark == null ? "" : p.remark;
            p.sort1 = p.sort1 == null ? "" : p.sort1;
        }
        public String insert(ItemsCat p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            //p.prefix_id = int.TryParse(p.prefix_id, out chk) ? chk.ToString() : "0";
            //p.dept_id = int.TryParse(p.dept_id, out chk) ? chk.ToString() : "0";

            sql = "Insert Into " + itmC.table + "(" + itmC.item_cat_code + "," + itmC.item_cat_name_e + "," + itmC.item_cat_name_t + "," +
                itmC.date_create + "," + itmC.date_modi + "," + itmC.date_cancel + "," +
                itmC.user_create + "," + itmC.user_modi + "," + itmC.user_cancel + "," +
                itmC.active + "," + itmC.remark + ", " + itmC.sort1 + " " +
                ") " +
                "Values ('" + p.item_cat_code + "','" + p.item_cat_name_e.Replace("'", "''") + "','" + p.item_cat_name_t.Replace("'", "''") + "'," +
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
        public String update(ItemsCat p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);

            sql = "Update " + itmC.table + " Set " +
                " " + itmC.item_cat_code + " = '" + p.item_cat_code + "'" +
                "," + itmC.item_cat_name_e + " = '" + p.item_cat_name_e.Replace("'", "''") + "'" +
                "," + itmC.item_cat_name_t + " = '" + p.item_cat_name_t.Replace("'", "''") + "'" +
                "," + itmC.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + itmC.date_modi + " = now()" +
                "," + itmC.user_modi + " = '" + userId + "' " +
                "," + itmC.sort1 + " = '" + p.sort1 + "' " +
                //"," + tmn.status_app + " = '" + p.status_app + "' " +
                "Where " + itmC.pkField + "='" + p.item_cat_id + "'"
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
        public String insertExpenseCat(ItemsCat p, String userId)
        {
            String re = "";

            if (p.item_cat_id.Equals(""))
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
            String sql = "Delete From  " + itmC.table;
            conn.ExecuteNonQuery(conn.conn, sql);

            return "";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select expC.*  " +
                "From " + itmC.table + " expC " +
                " " +
                "Where expC." + itmC.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByCodeLike(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select expC.* " +
                "From " + itmC.table + " expC " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where LOWER(expC." + itmC.item_cat_code + ") like '%" + copId.ToLower() + "%' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public String selectByNameTLike(String copId)
        {
            String currId = "";
            DataTable dt = new DataTable();
            String sql = "select expC.* " +
                "From " + itmC.table + " expC " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where expC." + itmC.item_cat_name_t + " like '%" + copId.ToLower() + "%' ";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count == 1)
            {
                currId = dt.Rows[0][itmC.item_cat_id].ToString();
            }
            return currId;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select expC.* " +
                "From " + itmC.table + " expC " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where expC." + itmC.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public ItemsCat selectByPk1(String copId)
        {
            ItemsCat cop1 = new ItemsCat();
            DataTable dt = new DataTable();
            String sql = "select expC.* " +
                "From " + itmC.table + " expC " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where expC." + itmC.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setExpenseCat(dt);
            return cop1;
        }
        public ItemsCat setExpenseCat(DataTable dt)
        {
            ItemsCat curr1 = new ItemsCat();
            if (dt.Rows.Count > 0)
            {
                curr1.item_cat_id = dt.Rows[0][itmC.item_cat_id].ToString();
                curr1.item_cat_code = dt.Rows[0][itmC.item_cat_code].ToString();
                curr1.item_cat_name_e = dt.Rows[0][itmC.item_cat_name_e].ToString();
                curr1.item_cat_name_t = dt.Rows[0][itmC.item_cat_name_t].ToString();
                curr1.active = dt.Rows[0][itmC.active].ToString();
                curr1.date_cancel = dt.Rows[0][itmC.date_cancel].ToString();
                curr1.date_create = dt.Rows[0][itmC.date_create].ToString();
                curr1.date_modi = dt.Rows[0][itmC.date_modi].ToString();
                curr1.user_cancel = dt.Rows[0][itmC.user_cancel].ToString();
                curr1.user_create = dt.Rows[0][itmC.user_create].ToString();
                curr1.user_modi = dt.Rows[0][itmC.user_modi].ToString();
                //pti1.status_app = dt.Rows[0][tmn.status_app].ToString();
                curr1.remark = dt.Rows[0][itmC.remark].ToString();
                curr1.sort1 = dt.Rows[0][itmC.sort1].ToString();
            }

            return curr1;
        }
    }
}
