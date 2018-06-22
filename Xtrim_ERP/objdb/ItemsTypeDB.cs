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
    public class ItemsTypeDB
    {
        public ItemsType itmT;
        ConnectDB conn;

        public List<ItemsType> lExpnT;
        public ItemsTypeDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            itmT = new ItemsType();
            itmT.item_type_id = "item_type_id";
            itmT.item_type_code = "item_type_code";
            itmT.item_type_name_e = "item_type_name_e";
            itmT.item_type_name_t = "item_type_name_t";
            //tmn.status_app = "status_app";
            itmT.sort1 = "sort1";

            itmT.active = "active";
            itmT.date_create = "date_create";
            itmT.date_modi = "date_modi";
            itmT.date_cancel = "date_cancel";
            itmT.user_create = "user_create";
            itmT.user_modi = "user_modi";
            itmT.user_cancel = "user_cancel";
            itmT.item_group_id = "item_group_id";
            itmT.remark = "remark";

            itmT.table = "b_items_type";
            itmT.pkField = "item_type_id";

            lExpnT = new List<ItemsType>();

        }
        public void getlExpnT()
        {
            //lDept = new List<Department>();

            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                ItemsType curr1 = new ItemsType();
                curr1.item_type_id = row[itmT.item_type_id].ToString();
                curr1.item_type_code = row[itmT.item_type_code].ToString();
                curr1.item_type_name_e = row[itmT.item_type_name_e].ToString();
                curr1.item_type_name_t = row[itmT.item_type_name_t].ToString();
                lExpnT.Add(curr1);
            }
        }
        public String getIdByCode(String code)
        {
            String id = "";
            foreach (ItemsType curr1 in lExpnT)
            {
                if (code.Trim().Equals(curr1.item_type_code))
                {
                    id = curr1.item_type_id;
                    break;
                }
            }
            return id;
        }
        public String getIdByName(String name)
        {
            String id = "";
            foreach (ItemsType curr1 in lExpnT)
            {
                if (name.Trim().Equals(curr1.item_type_name_t))
                {
                    id = curr1.item_type_id;
                    break;
                }
            }
            return id;
        }
        public void setC1CboItemsT(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            if (lExpnT.Count <= 0) getlExpnT();
            //DataTable dt = selectWard();
            item = new ComboBoxItem();
            item.Value = "";
            item.Text = "";
            c.Items.Add(item);
            foreach (ItemsType cus1 in lExpnT)
            {
                item = new ComboBoxItem();
                item.Value = cus1.item_type_id;
                item.Text = cus1.item_type_name_t;
                c.Items.Add(item);
                if (item.Value.Equals(selected))
                {
                    c.SelectedText = item.Text;
                }
            }
        }
        private void chkNull(ItemsType p)
        {
            int chk = 0;
            Decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            p.item_type_code = p.item_type_code == null ? "" : p.item_type_code;
            p.item_type_name_e = p.item_type_name_e == null ? "" : p.item_type_name_e;
            p.item_type_name_t = p.item_type_name_t == null ? "" : p.item_type_name_t;
            p.remark = p.remark == null ? "" : p.remark;
            p.sort1 = p.sort1 == null ? "" : p.sort1;

            p.item_group_id = p.item_group_id == null ? "0" : p.item_group_id;
        }
        public String insert(ItemsType p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            //p.prefix_id = int.TryParse(p.prefix_id, out chk) ? chk.ToString() : "0";
            //p.dept_id = int.TryParse(p.dept_id, out chk) ? chk.ToString() : "0";

            sql = "Insert Into " + itmT.table + "(" + itmT.item_type_code + "," + itmT.item_type_name_e + "," + itmT.item_type_name_t + "," +
                itmT.date_create + "," + itmT.date_modi + "," + itmT.date_cancel + "," +
                itmT.user_create + "," + itmT.user_modi + "," + itmT.user_cancel + "," +
                itmT.active + "," + itmT.remark + ", " + itmT.sort1 + ", " +
                itmT.item_group_id + "," +
                ") " +
                "Values ('" + p.item_type_code + "','" + p.item_type_name_e.Replace("'", "''") + "','" + p.item_type_name_t.Replace("'", "''") + "'," +
                "'" + p.date_create + "','" + p.date_modi + "','" + p.date_cancel + "'," +
                "'" + userId + "','" + p.user_modi + "','" + p.user_cancel + "'," +
                "'" + p.active + "','" + p.remark.Replace("'", "''") + "','" + p.sort1 + "', " +
                "'" + p.item_group_id + "','" +
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
        public String update(ItemsType p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);

            sql = "Update " + itmT.table + " Set " +
                " " + itmT.item_type_code + " = '" + p.item_type_code + "'" +
                "," + itmT.item_type_name_e + " = '" + p.item_type_name_e.Replace("'", "''") + "'" +
                "," + itmT.item_type_name_t + " = '" + p.item_type_name_t.Replace("'", "''") + "'" +
                "," + itmT.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + itmT.date_modi + " = now()" +
                "," + itmT.user_modi + " = '" + userId + "' " +
                "," + itmT.sort1 + " = '" + p.sort1 + "' " +
                "," + itmT.item_group_id + " = '" + p.item_group_id + "' " +
                "Where " + itmT.pkField + "='" + p.item_type_id + "'"
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
        public String insertItemsType(ItemsType p, String userId)
        {
            String re = "";

            if (p.item_type_id.Equals(""))
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
            String sql = "Delete From  " + itmT.table;
            conn.ExecuteNonQuery(conn.conn, sql);

            return "";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select expC.*  " +
                "From " + itmT.table + " expC " +
                " " +
                "Where expC." + itmT.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByCodeLike(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select expC.* " +
                "From " + itmT.table + " expC " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where LOWER(expC." + itmT.item_type_code + ") like '%" + copId.ToLower() + "%' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public String selectByNameTLike(String copId)
        {
            String currId = "";
            DataTable dt = new DataTable();
            String sql = "select expC.* " +
                "From " + itmT.table + " expC " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where expC." + itmT.item_type_name_t + " like '%" + copId.ToLower() + "%' ";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count == 1)
            {
                currId = dt.Rows[0][itmT.item_type_id].ToString();
            }
            return currId;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select expC.* " +
                "From " + itmT.table + " expC " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where expC." + itmT.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public ItemsType selectByPk1(String copId)
        {
            ItemsType cop1 = new ItemsType();
            DataTable dt = new DataTable();
            String sql = "select expC.* " +
                "From " + itmT.table + " expC " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where expC." + itmT.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setItemsType(dt);
            return cop1;
        }
        public ItemsType setItemsType(DataTable dt)
        {
            ItemsType curr1 = new ItemsType();
            if (dt.Rows.Count > 0)
            {
                curr1.item_type_id = dt.Rows[0][itmT.item_type_id].ToString();
                curr1.item_type_code = dt.Rows[0][itmT.item_type_code].ToString();
                curr1.item_type_name_e = dt.Rows[0][itmT.item_type_name_e].ToString();
                curr1.item_type_name_t = dt.Rows[0][itmT.item_type_name_t].ToString();
                curr1.active = dt.Rows[0][itmT.active].ToString();
                curr1.date_cancel = dt.Rows[0][itmT.date_cancel].ToString();
                curr1.date_create = dt.Rows[0][itmT.date_create].ToString();
                curr1.date_modi = dt.Rows[0][itmT.date_modi].ToString();
                curr1.user_cancel = dt.Rows[0][itmT.user_cancel].ToString();
                curr1.user_create = dt.Rows[0][itmT.user_create].ToString();
                curr1.user_modi = dt.Rows[0][itmT.user_modi].ToString();
                curr1.item_group_id = dt.Rows[0][itmT.item_group_id].ToString();
                curr1.remark = dt.Rows[0][itmT.remark].ToString();
                curr1.sort1 = dt.Rows[0][itmT.sort1].ToString();
            }
            else
            {
                curr1.item_type_id = "";
                curr1.item_type_code = "";
                curr1.item_type_name_e = "";
                curr1.item_type_name_t = "";
                //tmn.status_app = "status_app";
                curr1.sort1 = "";

                curr1.active = "";
                curr1.date_create = "";
                curr1.date_modi = "";
                curr1.date_cancel = "";
                curr1.user_create = "";
                curr1.user_modi = "";
                curr1.user_cancel = "";
                curr1.item_group_id = "";
                curr1.remark = "";
            }

            return curr1;
        }
    }
}
