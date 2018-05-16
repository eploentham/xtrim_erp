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
    public class AddressTypeDB
    {
        public AddressType1 addrT;
        ConnectDB conn;

        public List<AddressType1> lAddrT;
        public DataTable dtAddrT;

        public AddressTypeDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            addrT = new AddressType1();
            addrT.address_type_id = "address_type_id";
            addrT.address_name_t = "address_name_t";
            addrT.address_name_e = "address_name_e";
            addrT.date_create = "date_create";
            addrT.date_modi = "date_modi";
            addrT.date_cancel = "date_cancel";
            addrT.user_create = "user_create";
            addrT.user_modi = "user_modi";
            addrT.user_cancel = "user_cancel";
            addrT.active = "active";
            addrT.remark = "remark";

            addrT.table = "b_address_type";
            addrT.pkField = "address_type_id";
        }
        public void getlAddr()
        {
            //lDept = new List<Department>();

            lAddrT.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            dtAddrT = dt;
            foreach (DataRow row in dt.Rows)
            {
                AddressType1 addrT1 = new AddressType1();
                addrT1.address_type_id = row[addrT.address_type_id].ToString();
                addrT1.address_name_e = row[addrT.address_name_e].ToString();
                addrT1.address_name_t = row[addrT1.address_name_t].ToString();
                //addrT1.line_e1 = row[addrT1.line_e1].ToString();
                
                lAddrT.Add(addrT1);
            }
        }
        public void setCboCus(ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectWard();
            foreach (AddressType1 cus1 in lAddrT)
            {
                item = new ComboBoxItem();
                item.Value = cus1.address_type_id;
                item.Text = cus1.address_name_t;
                c.Items.Add(item);
                if (item.Value.Equals(selected))
                {
                    c.SelectedItem = item;
                }
            }
        }
        public String getIdByName(String name)
        {
            String id = "";
            foreach (AddressType1 cus1 in lAddrT)
            {
                if (name.Trim().Equals(cus1.address_name_t.Trim()))
                {
                    id = cus1.address_type_id;
                    break;
                }
            }
            return id;
        }
        private void chkNull(AddressType1 p)
        {
            int chk = 0;
            Decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            
            p.address_type_id = p.address_type_id == null ? "" : p.address_type_id;

            p.address_name_t = p.address_name_t == null ? "" : p.address_name_t;
            p.address_name_e = p.address_name_e == null ? "" : p.address_name_e;
            p.active = p.active == null ? "" : p.active;
            p.remark = p.remark == null ? "" : p.remark;

        }
        public String insert(AddressType1 p)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            sql = "Insert Into " + addrT.table + "(" + addrT.address_name_t + "," + addrT.address_name_e + "," + addrT.remark + "," +
                addrT.date_create + "," + addrT.date_modi + ", " + addrT.date_cancel + ", " +
                addrT.user_create + "," + addrT.user_modi + ", " + addrT.user_cancel + ", " +
                addrT.active +  " " +
                ") " +
                "Values ('" + p.address_name_t.Replace("'", "''") + "','" + p.address_name_e.Replace("'", "''") + "','" + p.remark.Replace("'", "''") + "','" +
                "'" + p.date_create + "','" + p.date_modi + "','" + p.date_cancel + "', " +
                "'" + p.user_create + "','" + p.user_modi + "','" + p.user_cancel + "', " +
                "'" + p.active + "' " +
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
        public String update(AddressType1 p)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);
            sql = "Update " + addrT.table + " Set " +
                " " + addrT.address_name_t + " = '" + p.address_name_t.Replace("'", "''") + "'" +
                "," + addrT.address_name_e + " = '" + p.address_name_e.Replace("'", "''") + "'" +
                "," + addrT.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + addrT.date_modi + " = now()" +                

                "Where " + addrT.pkField + "='" + p.address_type_id + "'"
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
        public String insertAddressType(AddressType1 p)
        {
            String re = "";

            if (p.address_type_id.Equals(""))
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
            String sql = "Delete From  " + addrT.table;
            conn.ExecuteNonQuery(conn.conn, sql);

            return "";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select cop.*  " +
                "From " + addrT.table + " cop " +
                " " +
                "Where cop." + addrT.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        private AddressType1 setAddress(DataTable dt)
        {
            AddressType1 addrT1 = new AddressType1();
            if (dt.Rows.Count > 0)
            {
                addrT1.address_type_id = dt.Rows[0][addrT.address_type_id].ToString();
                addrT1.address_name_e = dt.Rows[0][addrT.address_name_e].ToString();
                addrT1.date_create = dt.Rows[0][addrT.date_create].ToString();
                addrT1.date_modi = dt.Rows[0][addrT.date_modi].ToString();
                addrT1.date_cancel = dt.Rows[0][addrT.date_cancel].ToString();
                addrT1.user_create = dt.Rows[0][addrT.user_create].ToString();
                addrT1.user_modi = dt.Rows[0][addrT.user_modi].ToString();
                addrT1.address_name_t = dt.Rows[0][addrT.address_name_t].ToString();
                addrT1.user_cancel = dt.Rows[0][addrT.user_cancel].ToString();

                addrT1.active = dt.Rows[0][addrT.active].ToString();
                
                addrT1.remark = dt.Rows[0][addrT.remark].ToString();
                
            }

            return addrT1;
        }
    }
}
