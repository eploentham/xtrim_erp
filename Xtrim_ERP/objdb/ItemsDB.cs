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
    public class ItemsDB
    {
        public Items itm;
        ConnectDB conn;

        public List<Items> lexpn;

        public ItemsDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            itm = new Items();
            itm.item_id = "item_id";
            itm.item_code = "item_code";
            itm.item_name_e = "item_name_e";
            itm.item_name_t = "item_name_t";
            itm.status_app = "status_app";
            itm.sort1 = "sort1";

            itm.active = "active";
            itm.date_create = "date_create";
            itm.date_modi = "date_modi";
            itm.date_cancel = "date_cancel";
            itm.user_create = "user_create";
            itm.user_modi = "user_modi";
            itm.user_cancel = "user_cancel";
            //tmn.status_app = "status_app";
            itm.remark = "remark";

            itm.acc_code = "acc_code";
            itm.status_tax53 = "status_tax53";
            itm.item_grp_id = "item_grp_id";
            itm.item_type_sub_id = "item_type_sub_id";
            itm.item_cat_id = "item_cat_id";
            itm.f_method_payment_id = "f_method_payment_id";
            itm.status_invoice = "status_invoice";
            itm.price1 = "price1";
            itm.price2 = "price2";
            itm.price3 = "price3";
            itm.price4 = "price4";
            itm.price5 = "price5";

            itm.table = "b_items";
            itm.pkField = "item_id";

            lexpn = new List<Items>();

            //getlExpn();
        }
        public void getlExpn()
        {
            //lDept = new List<Department>();

            lexpn.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                Items expn1 = new Items();
                expn1.item_id = row[itm.item_id].ToString();
                expn1.item_code = row[itm.item_code].ToString();
                expn1.item_name_e = row[itm.item_name_e].ToString();
                expn1.item_name_t = row[itm.item_name_t].ToString();

                lexpn.Add(expn1);
            }
        }
        public String getIdByCode(String code)
        {
            String id = "";
            foreach (Items expn1 in lexpn)
            {
                if (code.Trim().Equals(expn1.item_code))
                {
                    id = expn1.item_id;
                    break;
                }
            }
            return id;
        }
        public String getIdByName(String name)
        {
            String id = "";
            foreach (Items expn1 in lexpn)
            {
                if (name.Trim().Equals(expn1.item_name_t))
                {
                    id = expn1.item_id;
                    break;
                }
            }
            return id;
        }
        public String getNameById(String name)
        {
            String id = "";
            foreach (Items expn1 in lexpn)
            {
                if (name.Trim().Equals(expn1.item_id))
                {
                    id = expn1.item_name_t;
                    break;
                }
            }
            return id;
        }
        private void chkNull(Items p)
        {
            int chk = 0;
            Decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            p.status_tax53 = p.status_tax53 == null ? "0" : p.status_tax53;
            p.acc_code = p.acc_code == null ? "" : p.acc_code;
            p.remark = p.remark == null ? "" : p.remark;
            p.sort1 = p.sort1 == null ? "" : p.sort1;
            p.status_app = p.status_app == null ? "" : p.status_app;
            p.item_name_t = p.item_name_t == null ? "" : p.item_name_t;
            p.item_name_e = p.item_name_e == null ? "" : p.item_name_e;
            p.item_code = p.item_code == null ? "" : p.item_code;
            p.status_invoice = p.status_invoice == null ? "0" : p.status_invoice;

            p.item_grp_id = int.TryParse(p.item_grp_id, out chk) ? chk.ToString() : "0";
            p.item_type_sub_id = int.TryParse(p.item_type_sub_id, out chk) ? chk.ToString() : "0";
            p.item_cat_id = int.TryParse(p.item_cat_id, out chk) ? chk.ToString() : "0";
            p.f_method_payment_id = int.TryParse(p.f_method_payment_id, out chk) ? chk.ToString() : "0";

            p.price1 = Decimal.TryParse(p.price1, out chk1) ? chk1.ToString() : "0";
            p.price2 = Decimal.TryParse(p.price2, out chk1) ? chk1.ToString() : "0";
            p.price3 = Decimal.TryParse(p.price3, out chk1) ? chk1.ToString() : "0";
            p.price4 = Decimal.TryParse(p.price4, out chk1) ? chk1.ToString() : "0";
            p.price5 = Decimal.TryParse(p.price5, out chk1) ? chk1.ToString() : "0";
        }
        public String insert(Items p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;


            //p.prefix_id = int.TryParse(p.prefix_id, out chk) ? chk.ToString() : "0";
            //p.dept_id = int.TryParse(p.dept_id, out chk) ? chk.ToString() : "0";
            chkNull(p);
            sql = "Insert Into " + itm.table + "(" + itm.item_code + "," + itm.item_name_e + "," + itm.item_name_t + "," +
                itm.date_create + "," + itm.date_modi + "," + itm.date_cancel + "," +
                itm.user_create + "," + itm.user_modi + "," + itm.user_cancel + "," +
                itm.active + "," + itm.remark + ", " + itm.sort1 + "," +
                itm.acc_code + "," + itm.status_tax53 + ", " + itm.item_grp_id + "," +
                itm.item_type_sub_id + "," + itm.item_cat_id + ", " + itm.status_app + "," +
                itm.f_method_payment_id + "," + itm.status_invoice + "," +
                itm.price1 + "," + itm.price2 + ", " + itm.price3 + ", " +
                itm.price4 + "," + itm.price5 + " " +
                ") " +
                "Values ('" + p.item_code + "','" + p.item_name_e.Replace("'", "''") + "','" + p.item_name_t.Replace("'", "''") + "'," +
                "'" + p.date_create + "','" + p.date_modi + "','" + p.date_cancel + "'," +
                "'" + userId + "','" + p.user_modi + "','" + p.user_cancel + "'," +
                "'" + p.active + "','" + p.remark.Replace("'", "''") + "','" + p.sort1 + "'," +
                "'" + p.acc_code + "','" + p.status_tax53.Replace("'", "''") + "','" + p.item_grp_id + "'," +
                "'" + p.item_type_sub_id + "','" + p.item_cat_id.Replace("'", "''") + "','" + p.status_app + "'," +
                "'" + p.f_method_payment_id + "','" + p.status_invoice.Replace("'", "''") + "'," +
                "'" + p.price1 + "','" + p.price2.Replace("'", "''") + "','" + p.price3 + "'," +
                "'" + p.price4 + "','" + p.price5.Replace("'", "''") + "' " + 
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
        public String update(Items p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);
            sql = "Update " + itm.table + " Set " +
                " " + itm.item_code + " = '" + p.item_code + "'" +
                "," + itm.item_name_e + " = '" + p.item_name_e.Replace("'", "''") + "'" +
                "," + itm.item_name_t + " = '" + p.item_name_t.Replace("'", "''") + "'" +
                "," + itm.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + itm.date_modi + " = now()" +
                "," + itm.user_modi + " = '" + userId + "' " +
                "," + itm.sort1 + " = '" + p.sort1 + "' " +
                "," + itm.acc_code + " = '" + p.acc_code + "' " +
                "," + itm.status_tax53 + " = '" + p.status_tax53 + "' " +
                "," + itm.item_grp_id + " = '" + p.item_grp_id + "' " +
                "," + itm.item_type_sub_id + " = '" + p.item_type_sub_id + "' " +
                "," + itm.item_cat_id + " = '" + p.item_cat_id + "' " +
                "," + itm.status_app + " = '" + p.status_app + "' " +
                "," + itm.f_method_payment_id + " = '" + p.f_method_payment_id + "' " +
                "," + itm.status_invoice + " = '" + p.status_invoice + "' " +
                "," + itm.price1 + " = '" + p.price1 + "' " +
                "," + itm.price2 + " = '" + p.price2 + "' " +
                "," + itm.price3 + " = '" + p.price3 + "' " +
                "," + itm.price4 + " = '" + p.price4 + "' " +
                "," + itm.price5 + " = '" + p.price5 + "' " +
                "Where " + itm.pkField + "='" + p.item_id + "'"
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
        public String insertItem(Items p, String userId)
        {
            String re = "";

            if (p.item_id.Equals(""))
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
            String sql = "Delete From  " + itm.table;
            conn.ExecuteNonQuery(conn.conn, sql);

            return "";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select expn.*  " +
                "From " + itm.table + " expn " +
                " " +
                "Where expn." + itm.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select itm.* " +
                "From " + itm.table + " itm " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where itm." + itm.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public Items selectByPk1(String copId)
        {
            Items cop1 = new Items();
            DataTable dt = new DataTable();
            String sql = "select expn.* " +
                "From " + itm.table + " expn " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where expn." + itm.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setItem(dt);
            return cop1;
        }
        public Items setItem(DataTable dt)
        {
            Items expn1 = new Items();
            if (dt.Rows.Count > 0)
            {
                expn1.item_id = dt.Rows[0][itm.item_id].ToString();
                expn1.item_code = dt.Rows[0][itm.item_code].ToString();
                expn1.item_name_e = dt.Rows[0][itm.item_name_e].ToString();
                expn1.item_name_t = dt.Rows[0][itm.item_name_t].ToString();
                expn1.active = dt.Rows[0][itm.active].ToString();
                expn1.date_cancel = dt.Rows[0][itm.date_cancel].ToString();
                expn1.date_create = dt.Rows[0][itm.date_create].ToString();
                expn1.date_modi = dt.Rows[0][itm.date_modi].ToString();
                expn1.user_cancel = dt.Rows[0][itm.user_cancel].ToString();
                expn1.user_create = dt.Rows[0][itm.user_create].ToString();
                expn1.user_modi = dt.Rows[0][itm.user_modi].ToString();
                //pti1.status_app = dt.Rows[0][tmn.status_app].ToString();
                expn1.remark = dt.Rows[0][itm.remark].ToString();
                expn1.sort1 = dt.Rows[0][itm.sort1].ToString();
                expn1.acc_code = dt.Rows[0][itm.acc_code].ToString();
                expn1.status_tax53 = dt.Rows[0][itm.status_tax53].ToString();
                expn1.item_grp_id = dt.Rows[0][itm.item_grp_id].ToString();
                expn1.item_type_sub_id = dt.Rows[0][itm.item_type_sub_id].ToString();
                expn1.item_cat_id = dt.Rows[0][itm.item_cat_id].ToString();
                expn1.status_app = dt.Rows[0][itm.status_app].ToString();
                expn1.f_method_payment_id = dt.Rows[0][itm.f_method_payment_id].ToString();
                expn1.status_invoice = dt.Rows[0][itm.status_invoice].ToString();
                expn1.price1 = dt.Rows[0][itm.price1].ToString();
                expn1.price2 = dt.Rows[0][itm.price2].ToString();
                expn1.price3 = dt.Rows[0][itm.price3].ToString();
                expn1.price4 = dt.Rows[0][itm.price4].ToString();
                expn1.price5 = dt.Rows[0][itm.price5].ToString();
            }

            return expn1;
        }
        public C1ComboBox setCboItem(C1ComboBox c)
        {
            lexpn.Clear();
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectAll();
            //String aaa = "";
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "000";
            c.Items.Clear();
            c.Items.Add(item1);
            //for (int i = 0; i < dt.Rows.Count; i++)
            foreach (DataRow row in dt.Rows)
            {
                item = new ComboBoxItem();
                item.Text = row[itm.item_name_t].ToString();
                item.Value = row[itm.item_id].ToString();
                c.Items.Add(item);

                Items expn1 = new Items();
                expn1.item_id = row[itm.item_id].ToString();
                expn1.item_code = row[itm.item_code].ToString();
                expn1.item_name_e = row[itm.item_name_e].ToString();
                expn1.item_name_t = row[itm.item_name_t].ToString();

                lexpn.Add(expn1);
            }
            return c;
        }
    }
}
