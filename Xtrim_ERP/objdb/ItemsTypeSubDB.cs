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
    public class ItemsTypeSubDB
    {
        public ItemsTypeSub itmtS;
        ConnectDB conn;

        public List<ItemsTypeSub> litmtS;

        public ItemsTypeSubDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            itmtS = new ItemsTypeSub();
            itmtS.item_type_sub_id = "item_type_sub_id";
            itmtS.item_type_id = "item_type_id";
            itmtS.item_type_sub_code = "item_type_sub_code";
            itmtS.item_type_sub_name_t = "item_type_sub_name_t";
            itmtS.item_type_sub_name_e = "item_type_sub_name_e";
            itmtS.active = "active";
            itmtS.remark = "remark";
            itmtS.date_create = "date_create";
            itmtS.date_modi = "date_modi";
            itmtS.date_cancel = "date_cancel";
            itmtS.user_create = "user_create";
            itmtS.user_modi = "user_modi";
            itmtS.user_cancel = "user_cancel";
            itmtS.f_method_payment_id = "f_method_payment_id";
            itmtS.status_invoice = "status_invoice";
            itmtS.status_tax53 = "status_tax53";
            itmtS.acc_code = "acc_code";
            itmtS.sort1 = "sort1";
            itmtS.status_item_edit = "status_item_edit";
            itmtS.tax_id = "tax_id";
            itmtS.status_hide = "status_hide";

            itmtS.table = "b_items_type_sub";
            itmtS.pkField = "item_type_sub_id";

            litmtS = new List<ItemsTypeSub>();
        }
        public void getlexpnC()
        {
            litmtS = new List<ItemsTypeSub>();

            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                ItemsTypeSub curr1 = new ItemsTypeSub();
                curr1.item_type_sub_id = row[itmtS.item_type_sub_id].ToString();
                curr1.item_type_sub_code = row[itmtS.item_type_sub_code].ToString();
                curr1.item_type_sub_name_e = row[itmtS.item_type_sub_name_e].ToString();
                curr1.item_type_sub_name_t = row[itmtS.item_type_sub_name_t].ToString();
                litmtS.Add(curr1);
            }
        }
        public String getIdByCode(String code)
        {
            String id = "";
            foreach (ItemsTypeSub curr1 in litmtS)
            {
                if (code.Trim().Equals(curr1.item_type_sub_code))
                {
                    id = curr1.item_type_sub_id;
                    break;
                }
            }
            return id;
        }
        public String getIdByName(String name)
        {
            String id = "";
            foreach (ItemsTypeSub curr1 in litmtS)
            {
                if (name.Trim().Equals(curr1.item_type_sub_name_t))
                {
                    id = curr1.item_type_sub_id;
                    break;
                }
            }
            return id;
        }
        public void setC1CboItmTypeSub(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            if (litmtS.Count <= 0) getlexpnC();
            //DataTable dt = selectWard();
            item = new ComboBoxItem();
            item.Value = "";
            item.Text = "";
            c.Items.Add(item);
            foreach (ItemsTypeSub cus1 in litmtS)
            {
                item = new ComboBoxItem();
                item.Value = cus1.item_type_sub_id;
                item.Text = cus1.item_type_sub_name_t;
                c.Items.Add(item);
                if (item.Value.Equals(selected))
                {
                    c.SelectedText = item.Text;
                }
            }
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select itmtS.*  " +
                "From " + itmtS.table + " itmtS " +
                " " +
                "Where itmtS." + itmtS.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectAll1()
        {
            DataTable dt = new DataTable();
            String sql = "select itmtS."+itmtS.item_type_sub_id+","+itmtS.item_type_sub_code+","+itmtS.item_type_sub_name_t+","+itmtS.remark+" " +
                "From " + itmtS.table + " itmtS " +
                " " +
                "Where itmtS." + itmtS.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        private void chkNull(ItemsTypeSub p)
        {
            int chk = 0;
            Decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            p.item_type_sub_code = p.item_type_sub_code == null ? "" : p.item_type_sub_code;
            p.item_type_sub_name_t = p.item_type_sub_name_t == null ? "" : p.item_type_sub_name_t;
            p.item_type_sub_name_e = p.item_type_sub_name_e == null ? "" : p.item_type_sub_name_e;
            p.remark = p.remark == null ? "" : p.remark;
            p.sort1 = p.sort1 == null ? "" : p.sort1;
            p.acc_code = p.acc_code == null ? "" : p.acc_code;
            p.status_invoice = p.status_invoice == null ? "0" : p.status_invoice;
            p.status_tax53 = p.status_tax53 == null ? "0" : p.status_tax53;
            p.status_item_edit = p.status_item_edit == null ? "0" : p.status_item_edit;
            p.status_hide = p.status_hide == null ? "0" : p.status_hide;

            p.item_type_id = int.TryParse(p.item_type_id, out chk) ? chk.ToString() : "0";
            p.f_method_payment_id = int.TryParse(p.f_method_payment_id, out chk) ? chk.ToString() : "0";
            p.tax_id = int.TryParse(p.tax_id, out chk) ? chk.ToString() : "0";
        }
        public String insert(ItemsTypeSub p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            //p.prefix_id = int.TryParse(p.prefix_id, out chk) ? chk.ToString() : "0";
            //p.dept_id = int.TryParse(p.dept_id, out chk) ? chk.ToString() : "0";

            sql = "Insert Into " + itmtS.table + "(" + itmtS.item_type_id + "," + itmtS.item_type_sub_code + "," + itmtS.item_type_sub_name_t + "," +
                itmtS.date_create + "," + itmtS.date_modi + "," + itmtS.date_cancel + "," +
                itmtS.user_create + "," + itmtS.user_modi + "," + itmtS.user_cancel + "," +
                itmtS.active + "," + itmtS.remark + ", " + itmtS.sort1 + ", " +
                itmtS.item_type_sub_name_e + "," + itmtS.f_method_payment_id + ", " + itmtS.status_invoice + ", " +
                itmtS.status_tax53 + "," + itmtS.acc_code + "," + itmtS.status_item_edit + "," +
                itmtS.tax_id + "," + itmtS.status_hide + " " +
                ") " +
                "Values ('" + p.item_type_id + "','" + p.item_type_sub_code.Replace("'", "''") + "','" + p.item_type_sub_name_t.Replace("'", "''") + "'," +
                "'" + p.date_create + "','" + p.date_modi + "','" + p.date_cancel + "'," +
                "'" + userId + "','" + p.user_modi + "','" + p.user_cancel + "'," +
                "'" + p.active + "','" + p.remark.Replace("'", "''") + "','" + p.sort1 + "'," +
                "'" + p.item_type_sub_name_e + "','" + p.f_method_payment_id.Replace("'", "''") + "','" + p.status_invoice + "'," +
                "'" + p.status_tax53 + "','" + p.acc_code.Replace("'", "''") + "','" + p.status_item_edit.Replace("'", "''") + "', " +
                "'" + p.tax_id + "','" + p.status_hide + "' " +
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
        public String update(ItemsTypeSub p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);

            sql = "Update " + itmtS.table + " Set " +
                " " + itmtS.item_type_id + " = '" + p.item_type_id + "'" +
                "," + itmtS.item_type_sub_code + " = '" + p.item_type_sub_code.Replace("'", "''") + "'" +
                "," + itmtS.item_type_sub_name_t + " = '" + p.item_type_sub_name_t.Replace("'", "''") + "'" +
                "," + itmtS.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + itmtS.date_modi + " = now()" +
                "," + itmtS.user_modi + " = '" + userId + "' " +
                "," + itmtS.sort1 + " = '" + p.sort1 + "' " +
                "," + itmtS.item_type_sub_name_e + " = '" + p.item_type_sub_name_e + "' " +
                "," + itmtS.f_method_payment_id + " = '" + p.f_method_payment_id + "' " +
                "," + itmtS.status_invoice + " = '" + p.status_invoice + "' " +
                "," + itmtS.status_tax53 + " = '" + p.status_tax53 + "' " +
                "," + itmtS.acc_code + " = '" + p.acc_code + "' " +
                "," + itmtS.status_item_edit + " = '" + p.status_item_edit + "' " +
                "," + itmtS.tax_id + " = '" + p.tax_id + "' " +
                "," + itmtS.status_hide + " = '" + p.status_hide + "' " +
                "Where " + itmtS.pkField + "='" + p.item_type_sub_id + "'"
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
        public String insertItemsTypeSub(ItemsTypeSub p, String userId)
        {
            String re = "";

            if (p.item_type_sub_id.Equals(""))
            {
                re = insert(p, userId);
            }
            else
            {
                re = update(p, userId);
            }

            return re;
        }
        public DataTable selectByCodeLike(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select itmtS.* " +
                "From " + itmtS.table + " itmtS " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where LOWER(itmtS." + itmtS.item_type_sub_code + ") like '%" + copId.ToLower() + "%' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public String selectByNameTLike(String copId)
        {
            String currId = "";
            DataTable dt = new DataTable();
            String sql = "select itmtS.* " +
                "From " + itmtS.table + " itmtS " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where itmtS." + itmtS.item_type_sub_name_t + " like '%" + copId.ToLower() + "%' ";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count == 1)
            {
                currId = dt.Rows[0][itmtS.item_type_sub_id].ToString();
            }
            return currId;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select itmtS.* " +
                "From " + itmtS.table + " itmtS " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where itmtS." + itmtS.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public ItemsTypeSub selectByPk1(String copId)
        {
            ItemsTypeSub cop1 = new ItemsTypeSub();
            DataTable dt = new DataTable();
            String sql = "select itmtS.* " +
                "From " + itmtS.table + " itmtS " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where itmtS." + itmtS.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setItemsTypeSub(dt);
            return cop1;
        }
        public ItemsTypeSub setItemsTypeSub(DataTable dt)
        {
            ItemsTypeSub curr1 = new ItemsTypeSub();
            if (dt.Rows.Count > 0)
            {
                curr1.item_type_sub_id = dt.Rows[0][itmtS.item_type_sub_id].ToString();
                curr1.item_type_id = dt.Rows[0][itmtS.item_type_id].ToString();
                curr1.item_type_sub_code = dt.Rows[0][itmtS.item_type_sub_code].ToString();
                curr1.item_type_sub_name_t = dt.Rows[0][itmtS.item_type_sub_name_t].ToString();
                curr1.active = dt.Rows[0][itmtS.active].ToString();
                curr1.date_cancel = dt.Rows[0][itmtS.date_cancel].ToString();
                curr1.date_create = dt.Rows[0][itmtS.date_create].ToString();
                curr1.date_modi = dt.Rows[0][itmtS.date_modi].ToString();
                curr1.user_cancel = dt.Rows[0][itmtS.user_cancel].ToString();
                curr1.user_create = dt.Rows[0][itmtS.user_create].ToString();
                curr1.user_modi = dt.Rows[0][itmtS.user_modi].ToString();
                curr1.item_type_sub_name_e = dt.Rows[0][itmtS.item_type_sub_name_e].ToString();
                curr1.remark = dt.Rows[0][itmtS.remark].ToString();
                curr1.sort1 = dt.Rows[0][itmtS.sort1].ToString();
                curr1.f_method_payment_id = dt.Rows[0][itmtS.f_method_payment_id].ToString();
                curr1.status_invoice = dt.Rows[0][itmtS.status_invoice].ToString();
                curr1.status_tax53 = dt.Rows[0][itmtS.status_tax53].ToString();
                curr1.acc_code = dt.Rows[0][itmtS.acc_code].ToString();
                curr1.status_item_edit = dt.Rows[0][itmtS.status_item_edit].ToString();
                curr1.tax_id = dt.Rows[0][itmtS.tax_id].ToString();
                curr1.status_hide = dt.Rows[0][itmtS.status_hide].ToString();
            }
            else
            {
                curr1.item_type_sub_id = "";
                curr1.item_type_id = "";
                curr1.item_type_sub_code = "";
                curr1.item_type_sub_name_t = "";
                curr1.item_type_sub_name_e = "";
                curr1.active = "";
                curr1.remark = "";
                curr1.date_create = "";
                curr1.date_modi = "";
                curr1.date_cancel = "";
                curr1.user_create = "";
                curr1.user_modi = "";
                curr1.user_cancel = "";
                curr1.f_method_payment_id = "";
                curr1.status_invoice = "";
                curr1.status_tax53 = "";
                curr1.acc_code = "";
                curr1.sort1 = "";
                curr1.status_item_edit = "";
                curr1.tax_id = "";
                curr1.status_hide = "";
            }

            return curr1;
        }
    }
}
